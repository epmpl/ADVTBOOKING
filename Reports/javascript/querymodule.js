
// JScript File



function keySort(dropdownlist,caseSensitive)
 {
  // check the keypressBuffer attribute is defined on the dropdownlist 
  var undefined; 
  if (dropdownlist.keypressBuffer == undefined) { 
    dropdownlist.keypressBuffer = ''; 
  } 
  // get the key that was pressed 
  var key = String.fromCharCode(window.event.keyCode); 
  dropdownlist.keypressBuffer += key;
  if (!caseSensitive) {
    // convert buffer to lowercase
    dropdownlist.keypressBuffer = dropdownlist.keypressBuffer.toLowerCase();
  }
  // find if it is the start of any of the options 
  var optionsLength = dropdownlist.options.length; 
  for (var n=0; n<optionsLength; n++) { 
    var optionText = dropdownlist.options[n].text; 
    if (!caseSensitive)
     {
      optionText = optionText.toLowerCase();
    }
    if (optionText.indexOf(dropdownlist.keypressBuffer,0) == 0) { 
      dropdownlist.selectedIndex = n; 
      return false; // cancel the default behavior since 
                    // we have selected our own value 
    } 
  } 
  // reset initial key to be inline with default behavior 
  dropdownlist.keypressBuffer = key; 
  return true; // give default behavior 
} 
/////////////////////////////////////////////////////////////////////////////


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
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name,ds.Tables[0].Rows[i].SUB_Agency_Code/*ds.Tables[0].Rows[i].SUB_Agency_Code*/);
  
       pkgitem.options.length;
       
    }
    }
    document.getElementById('txtagency').value="";
    document.getElementById("lstagency").value="0";
     document.getElementById("lstagency").disabled=false;
   
    document.getElementById("lstagency").focus();
     return false;
}

function bindproductname_callback(response)
{       
    ds=response.value;
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


var pkgitem = document.getElementById("lstproduct");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Product-","0");
    pkgitem.options.length = 1; 
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].prod_desc,ds.Tables[0].Rows[i].prod_cat_code);
        
       pkgitem.options.length;
       
    }
    }
    document.getElementById('txtproduct').value="";
    document.getElementById("lstproduct").value="0";
     document.getElementById("lstproduct").disabled=false;
   
   // document.getElementById("lstproduct").focus();
     return false;
}
// to bind brand on change of subsubcat


function call_bindbrand(response)
{
                    ds=response.value;
                          var pkgitem = document.getElementById("drpbrand");
                          pkgitem.options.length=0;
            pkgitem.options[0] = new Option("-Select Brand-","0");
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
        {


        //alert(pkgitem);
      
            pkgitem.options.length = 1; 
            //pkgitem.options[0]=new Option("--Select City--","0");
            //alert(pkgitem.options.length);
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].brand_name,ds.Tables[0].Rows[i].brand_code);
                
               pkgitem.options.length;
               
            }
            }
           // document.getElementById('drpbrand').focus();
             return false;


}



function call_bindsubcat(response)
{
                    ds=response.value;
                          var pkgitem = document.getElementById("dpsubcat");
                      
                          pkgitem.options.length=0;
            pkgitem.options[0] = new Option("-Select Subcategory-","0");
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
        {
            //alert(pkgitem);
            pkgitem.options.length = 1; 
            //pkgitem.options[0]=new Option("--Select City--","0");
            //alert(pkgitem.options.length);
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].pro_sub_name,ds.Tables[0].Rows[i].pro_subcat_code);
                
               pkgitem.options.length;
               
            }
          }
            //Queries_Module.getsubsubcategory(page,document.getElementById('hiddencompcode').value,call_bindsubsubcat);
            //document.getElementById('dpsubcat').focus();
             return false;


}






function bindclientname_callback(response)
{       
    ds=response.value;
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


var pkgitem = document.getElementById("lstclient");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Client-","0");
    pkgitem.options.length = 1; 
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name,ds.Tables[0].Rows[i].Cust_Code);
        
       pkgitem.options.length;
       
    }
    
    }
    document.getElementById('txtclient').value="";
    document.getElementById("lstclient").value="0";
    document.getElementById("lstclient").focus();
     return false;
}
// for f2

function tabvaluebyid(id)
{
    document.getElementById('hiddenquery').value="query";
if(document.getElementById('hiddenquery').value=="query")
{
if(event.keyCode==113)  
{
 if(document.activeElement.id=="txtagency")
    {
    if( document.getElementById("divclient").style.display=="block")
   {
   document.getElementById("divclient").style.display="none"
    }
    else if( document.getElementById("divproduct").style.display="block")
    {
    document.getElementById("divproduct").style.display="none"
    }
        document.getElementById("divagency").style.display="block";
        document.getElementById('divagency').style.top=260;
        document.getElementById('divagency').style.left=760;
        document.getElementById('lstagency').focus();
//        Agent_master.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txtsagencycode').value,bindagencyname_callback);
        Queries_Module.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('txtagency').value,bindagencyname_callback);
    }
    else if(document.activeElement.id=="txtproduct")
    {
     document.getElementById('dpsubcat').innerHTML=""
     if( document.getElementById("divclient").style.display=="block")
   {
   document.getElementById("divclient").style.display="none"
    }
    else if( document.getElementById("divagency").style.display="block")
    {
    document.getElementById("divagency").style.display="none"
    }
      
        document.getElementById("divproduct").style.display="block";
        document.getElementById('divproduct').style.top=308;
        document.getElementById('divproduct').style.left=760;
        Queries_Module.bindProductcategory(document.getElementById('hiddencompcode').value,document.getElementById('txtproduct').value,bindproductname_callback);
        document.getElementById('lstproduct').focus();
    }
    else if(document.activeElement.id=="txtclient")
    {
     if( document.getElementById("divproduct").style.display=="block")
   {
   document.getElementById("divproduct").style.display="none"
    }
    else if( document.getElementById("divagency").style.display="block")
    {
    document.getElementById("divagency").style.display="none"
    }
        document.getElementById("divclient").style.display="block";
        document.getElementById('divclient').style.top=284;
        document.getElementById('divclient').style.left=760;
        document.getElementById('lstclient').focus();
        Queries_Module.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtclient').value,bindclientname_callback);
    }
    
}
else if(event.keyCode==27)
{
 if(document.activeElement.id=="lstagency")
 {
 if( document.getElementById("divagency").style.display=="block")
   {
   document.getElementById("divagency").style.display="none"
    }
 }
 if(document.activeElement.id=="lstclient")
 {
 if( document.getElementById("divclient").style.display=="block")
   {
   document.getElementById("divclient").style.display="none"
    }
 }
 if(document.activeElement.id=="lstproduct")
 {
 if( document.getElementById("divproduct").style.display=="block")
   {
   document.getElementById("divproduct").style.display="none"
    }
 }
}

else if(event.keyCode==13 || event.keyCode==9 && event.shiftKey==false)
{
    if(document.activeElement.id=="lstagency")
    {
    if(document.getElementById('lstagency').value=="0")
        {
        alert("Please select the agency");
        return false;
        }
        document.getElementById("divagency").style.display="none";
        
        
        var page=document.getElementById('lstagency').value;
        agencycodeglo=page;
         var xml = new ActiveXObject("Microsoft.XMLHTTP");
         xml.Open( "GET","agency_list.aspx?page="+page+"&value=0", false );
         xml.Send();
         var id=xml.responseText;
         
         var split=id.split("+");
         var nameagen=split[0];
         var code=split[1];
         var agenadd1=split[2];
         var agenadd2=split[3];
         var agenadd3=split[4];
                       
        document.getElementById('txtagency').value=nameagen;
//        document.getElementById('txtadd').value=agenadd1;
//        document.getElementById('txtaddress1').value=agenadd2;
//        document.getElementById('txtaddress2').value=agenadd3;
        //document.getElementById('txtagencyaddress').focus();
        document.getElementById('txtagency').focus();
        
//        Agent_master.SubAgencyBind(page,document.getElementById('hiddencompcode').value,"0",call_bindagsub);
        return false;
    }
    
    else if(document.activeElement.id=="lstproduct")
    {
    if(document.getElementById('lstproduct').value=="0")
        {
        alert("Please select the agency");
        return false;
        }
        document.getElementById("divproduct").style.display="none";
        
        
        var page=document.getElementById('lstproduct').value;
        agencycodeglo=page;
         var xml = new ActiveXObject("Microsoft.XMLHTTP");
         xml.Open( "GET","agency_list.aspx?page="+page+"&value=2", false );
         xml.Send();
         var id=xml.responseText;
         
          var split=id.split("+");
         var nameagen=split[0];
         var agenadd1=split[1];
         var agenadd2=split[2];
         var agenadd3=split[3];
        
         
        
          document.getElementById('txtproduct').value=nameagen;
//        document.getElementById('txtadd').value=agenadd1;
//        document.getElementById('txtaddress1').value=agenadd2;
//        document.getElementById('txtaddress2').value=agenadd3;
//        document.getElementById('drpagetyp').focus();
        document.getElementById('txtproduct').value=id;
      //  document.getElementById('txtproduct').focus();
        
        
        //document.getElementById('drpbrand').focus();
//////////        Queries_Module.getbrand(page,document.getElementById('hiddencompcode').value,call_bindbrand);
        Queries_Module.getsubcategory(page,document.getElementById('hiddencompcode').value,call_bindsubcat);
        document.getElementById("divproduct").style.display='none';
        
        return false;
        }
         
         
//////////////////         document.getElementById('txtproduct').value=id;
//////////////////        
//////////////////        
//////////////////        //document.getElementById('drpbrand').focus();
//////////////////        Queries_Module.getbrand(page,document.getElementById('hiddencompcode').value,call_bindproduct);
//         var split=id.split("+");
//         var nameagen=split[0];
//         var code=split[1];
//         var agenadd1=split[2];
//         var agenadd2=split[3];
//         var agenadd3=split[4];
//                       
//        document.getElementById('txtproduct').value=nameagen;
////        document.getElementById('txtadd').value=agenadd1;
////        document.getElementById('txtaddress1').value=agenadd2;
////        document.getElementById('txtaddress2').value=agenadd3;
//        //document.getElementById('txtagencyaddress').focus();
//        
//        
////        Agent_master.SubAgencyBind(page,document.getElementById('hiddencompcode').value,"0",call_bindagsub);
        //return false;
    
   // }
    
    else if(document.activeElement.id=="lstclient")
    {
       if(document.getElementById('lstclient').value=="0")
        {
        alert("Please select the client");
        return false;
        }
        document.getElementById("divclient").style.display="none";
              
        var page=document.getElementById('lstclient').value;
        agencycodeglo=page;
         var xml = new ActiveXObject("Microsoft.XMLHTTP");
         xml.Open( "GET","agency_list.aspx?page="+page+"&value=1", false );
         xml.Send();
         var id=xml.responseText;
         
         var split=id.split("+");
         var nameagen=split[0];
         var code=split[1];
         var agenadd1=split[2];
         var agenadd2=split[3];
         var agenadd3=split[4];
                       
        document.getElementById('txtclient').value=nameagen;
//        document.getElementById('txtadd').value=agenadd1;
//        document.getElementById('txtaddress1').value=agenadd2;
//        document.getElementById('txtaddress2').value=agenadd3;
        //document.getElementById('txtagencyaddress').focus();
        document.getElementById('txtclient').focus();
        
        
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

	
function insertagency()
{
//var x=id.value;
document.getElementById('hiddenquery').value="query";
if(document.getElementById('hiddenquery').value=="query")
{
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
           
        var page=document.getElementById('lstagency').value;
        agencycodeglo=page;
         var xml = new ActiveXObject("Microsoft.XMLHTTP");
         xml.Open( "GET","agency_list.aspx?page="+page+"&value=0", false );
         xml.Send();
         var id=xml.responseText;
         
         var split=id.split("+");
         var nameagen=split[0];
         var agenadd1=split[1];
         var agenadd2=split[2];
         var agenadd3=split[3];
        
         
        
        document.getElementById('txtagency').value=nameagen;
//        document.getElementById('txtadd').value=agenadd1;
//        document.getElementById('txtaddress1').value=agenadd2;
//        document.getElementById('txtaddress2').value=agenadd3;
        document.getElementById('txtclient').focus();
        
        document.getElementById("divagency").style.display='none';
        
        return false;
    }
    
    
}

	}

function insertproduct()
{

document.getElementById('hiddenquery').value="query";
if(document.getElementById('hiddenquery').value=="query")
{
    if(document.activeElement.id=="lstproduct")
    {
    if(document.getElementById('lstproduct').value=="0")
        {
        alert("Please select the product");
        return false;
        }
        document.getElementById("divproduct").style.display="none";
        
        //alert(document.getElementById('lstagency').value);
       //alert(document.getElementById('lstagency').value);
           
        var page=document.getElementById('lstproduct').value;
        agencycodeglo=page;
         var xml = new ActiveXObject("Microsoft.XMLHTTP");
         xml.Open( "GET","agency_list.aspx?page="+page+"&value=2", false );
         xml.Send();
         var id=xml.responseText;
         var split=id.split("+");
         var nameagen=split[0];
         var agenadd1=split[1];
         var agenadd2=split[2];
         var agenadd3=split[3];
        
         
        
          document.getElementById('txtproduct').value=nameagen;
//        document.getElementById('txtadd').value=agenadd1;
//        document.getElementById('txtaddress1').value=agenadd2;
//        document.getElementById('txtaddress2').value=agenadd3;
        
        document.getElementById('txtproduct').value=id;
        
        
        //document.getElementById('drpbrand').focus();
//////////        Queries_Module.getbrand(page,document.getElementById('hiddencompcode').value,call_bindbrand);
        Queries_Module.getsubcategory(page,document.getElementById('hiddencompcode').value,call_bindsubcat);
        document.getElementById("divproduct").style.display='none';
        
        return false;
    }
    
    
}

}	

function insertclient()
{

document.getElementById('hiddenquery').value="query";
if(document.getElementById('hiddenquery').value=="query")
{
    if(document.activeElement.id=="lstclient")
    {
    if(document.getElementById('lstclient').value=="0")
        {
        alert("Please select the client");
        return false;
        }
        document.getElementById("divclient").style.display="none";
        
        //alert(document.getElementById('lstagency').value);
       //alert(document.getElementById('lstagency').value);
           
        var page=document.getElementById('lstclient').value;
        agencycodeglo=page;
         var xml = new ActiveXObject("Microsoft.XMLHTTP");
         xml.Open( "GET","agency_list.aspx?page="+page+"&value=1", false );
         xml.Send();
         var id=xml.responseText;
         
         var split=id.split("+");
         var nameagen=split[0];
         var agenadd1=split[1];
         var agenadd2=split[2];
         var agenadd3=split[3];
        
         
        
        document.getElementById('txtclient').value=nameagen;
//        document.getElementById('txtadd').value=agenadd1;
//        document.getElementById('txtaddress1').value=agenadd2;
//        document.getElementById('txtaddress2').value=agenadd3;
//        document.getElementById('drpagetyp').focus();
          document.getElementById('dppub1').focus();
        
        document.getElementById("divclient").style.display='none';
        
        return false;
    }
    
    
}

}	



function selectsubcat()
{

//var page=document.getElementById('hiddencompcode').value;
var lstproduct=document.getElementById('lstproduct').value;
var dpsubcat=document.getElementById('dpsubcat').value;
   
document.getElementById('dpsubcat1').value=document.getElementById('dpsubcat').value;
var compcode=document.getElementById('hiddencompcode').value;
//Queries_Module.getsubsubcategory(page,document.getElementById('hiddencompcode').value,call_bindsubsubcat);
  Queries_Module.getsubsubcategory(lstproduct,dpsubcat,compcode,call_bindsubsubcategory);
return false;
}

function call_bindsubsubcategory(response)
{
                    ds=response.value;
                          var pkgitem = document.getElementById("dpsubsubcat");
                          pkgitem.options.length=0;
            pkgitem.options[0] = new Option("-Select SubSub Category-","0");
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
        {


        //alert(pkgitem);
      
            pkgitem.options.length = 1; 
            //pkgitem.options[0]=new Option("--Select City--","0");
            //alert(pkgitem.options.length);
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].prosubname,ds.Tables[0].Rows[i].prosubcode);
                
               pkgitem.options.length;
               
            }
            }
            //document.getElementById('dpsubsubcat').focus();
             return false;


}

function selectvarient()
{
  
//var compcode=document.getElementById('hiddencompcode').value;
//var drpbrand=document.getElementById('drpbrand').value;
//document.getElementById('dpbrand1').value=document.getElementById('drpbrand').value;;

////Queries_Module.getsubsubcategory(page,document.getElementById('hiddencompcode').value,call_bindsubsubcat);
//  Queries_Module.getvarient(compcode,drpbrand,call_bindforvarient);
//return false;
}

function call_bindforvarient(response)
{
                    ds=response.value;
                          var pkgitem = document.getElementById("dpvarient");
                          pkgitem.options.length=0;
            pkgitem.options[0] = new Option("--Select Variant--","0");
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
        {


        //alert(pkgitem);
      
            pkgitem.options.length = 1; 
            //pkgitem.options[0]=new Option("--Select City--","0");
            //alert(pkgitem.options.length);
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].varient_name,ds.Tables[0].Rows[i].varient_code);
                
               pkgitem.options.length;
               
            }
            }
          //  document.getElementById('dpvarient').focus();
             return false;

  
}


function selectbrand()
{

//var page=document.getElementById('hiddencompcode').value;
//var dpsubcat=document.getElementById('dpsubcat').value;
var dpsubsubcat=document.getElementById('dpsubsubcat').value;
document.getElementById('dpsubsubcat1').value=document.getElementById('dpsubsubcat').value;
var compcode=document.getElementById('hiddencompcode').value;
//Queries_Module.getsubsubcategory(page,document.getElementById('hiddencompcode').value,call_bindsubsubcat);
  Queries_Module.getbrand(/*dpsubcat,*/dpsubsubcat,compcode,call_bindbrand);
return false;
}


function pkg()
{
var adtype=document.getElementById('dpdadtype').value;
//document.getElementById('dpsubsubcat1').value=document.getElementById('dpsubsubcat').value;
var compcode=document.getElementById('hiddencompcode').value;
//Queries_Module.getsubsubcategory(page,document.getElementById('hiddencompcode').value,call_bindsubsubcat);
  Queries_Module.pkg(/*dpsubcat,*/dpsubsubcat,compcode,call_bindbrand);
return false;

}

function windowclose()
{
window.close();
}




//for grid

// JScript File
var test="1";
function ttttt()
{

if(event.keyCode==27)  
{
    if(document.activeElement.id=="txtclient")
    {
    document.getElementById("divclient").style.display="none";
    }
    if(document.activeElement.id=="txtagency")
    {
    document.getElementById("divagency").style.display="none";
    }
    
}

    
    if(event.keyCode==113)  
            {
             
                 if(document.activeElement.id=="txtclient")
                {
                    document.getElementById("divclient").style.display="block";
                    
       
       
        document.getElementById('divclient').style.top=180;
        document.getElementById('divclient').style.leeportft=750;             
                    
//                    if(browser!="Microsoft Internet Explorer")
//                    {
     //
     //                   document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop-6)+"px";
          //              document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 3+"px";
//                    }
//                    else
//                    {
 //                       document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6+"px";
   //                     document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9+"px";
//                    }
                    billing.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtclient').value,bindclientname_callback);
                }
                
                ////////////////////////////////////////
                
                  if(document.activeElement.id=="txtagency")
                {
                    document.getElementById("divagency").style.display="block";
                    
       
       
        document.getElementById('divagency').style.top=150;
        document.getElementById('divagency').style.left=1015;             
                    
//                    if(browser!="Microsoft Internet Explorer")
//                    {
     //
     //                   document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop-6)+"px";
          //              document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 3+"px";
//                    }
//                    else
//                    {
 //                       document.getElementById('divclient').style.top=parseInt(document.getElementById('txtclient').offsetTop) + parseInt(document.getElementById('sectd').offsetTop) + parseInt(document.getElementById('tdclient').offsetTop) + parseInt(document.getElementById('tbl1').offsetTop) + parseInt(document.getElementById('tbl2').offsetTop) + parseInt(document.getElementById('tbl3').offsetTop) + parseInt(document.getElementById('OuterTable').offsetTop) + 6+"px";
   //                     document.getElementById('divclient').style.left=parseInt(document.getElementById('txtclient').offsetLeft) + parseInt(document.getElementById('sectd').offsetLeft) + parseInt(document.getElementById('tdclient').offsetLeft) + parseInt(document.getElementById('tbl1').offsetLeft) + parseInt(document.getElementById('tbl2').offsetLeft) + parseInt(document.getElementById('tbl3').offsetLeft) + parseInt(document.getElementById('OuterTable').offsetLeft) + 9+"px";
//                    }
                   
                    
                     billing.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('txtagency').value,bindagencyname_callback);
                }
                
                /////////////////
                 
             
            }
}



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
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name,ds.Tables[0].Rows[i].code_subcode/*ds.Tables[0].Rows[i].SUB_Agency_Code*/);
  
       pkgitem.options.length;
       
    }
    }
    document.getElementById('txtagency').value="";
    document.getElementById("lstagency").value="0";
     document.getElementById("lstagency").disabled=false;
   
    //document.getElementById("lstagency").focus();
     return false;
}




function bindclientname_callback(response)
{
         
    ds=response.value;
    var pkgitem = document.getElementById("lstclient");
     pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Client-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);

   
    //alert(pkgitem.options.length);
    pkgitem.options.length = 1; 
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name,ds.Tables[0].Rows[i].Cust_Code);
        
       pkgitem.options.length;
       
    }
    
    }
    document.getElementById('txtclient').value="";
    document.getElementById("lstclient").value="0";
     document.getElementById("lstclient").disabled=false;
    //document.getElementById("lstclient").focus();
    
     return false;
}

////////////////this function is called when we open the list box of agency than on mouse click it get the agency
/*change*/
function insertclient()
{


    if(document.activeElement.id=="lstclient")
    {
    if(document.getElementById('lstclient').value=="0")
        {
        alert("Please select the client");
        return false;
        }
        document.getElementById("divclient").style.display="none";
        
        //alert(document.getElementById('lstagency').value);
       //alert(document.getElementById('lstagency').value);
           
        var page=document.getElementById('lstclient').value;
        agencycodeglo=page;
         var xml = new ActiveXObject("Microsoft.XMLHTTP");
         xml.Open( "GET","agencylist2.aspx?page="+page+"&value=1", false );
         xml.Send();
         var id=xml.responseText;
         
         var split=id.split("+");
         var nameagen=split[0];
         var agenadd1=split[1];
         var agenadd2=split[2];
         var agenadd3=split[3];
        
         
        
        document.getElementById('txtclient').value=nameagen;
//        document.getElementById('txtadd').value=agenadd1;
//        document.getElementById('txtaddress1').value=agenadd2;
//        document.getElementById('txtaddress2').value=agenadd3;
//        document.getElementById('drpagetyp').focus();
         // document.getElementById('dppub1').focus();
        
        document.getElementById("divclient").style.display='none';
        
        return false;
    }
    
    


}	


function insertagency()
{

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
           
        var page=document.getElementById('lstagency').value;
        agencycodeglo=page;
         var xml = new ActiveXObject("Microsoft.XMLHTTP");
         xml.Open( "GET","agencylist2.aspx?page="+page+"&value=0", false );
         xml.Send();
         var id=xml.responseText;
         
         var split=id.split("+");
         var nameagen=split[0];
         var agenadd1=split[1];
         var agenadd2=split[2];
         var agenadd3=split[3];
        
         
        
        document.getElementById('txtagency').value=nameagen;
//        document.getElementById('txtadd').value=agenadd1;
//        document.getElementById('txtaddress1').value=agenadd2;
//        document.getElementById('txtaddress2').value=agenadd3;
        document.getElementById('txtclient').focus();
        
        document.getElementById("divagency").style.display='none';
        
        return false;
    }
    
    


	}
	
	
	function checklenthbill()
{
document.getElementById('divgrid1').style.display="none";
alert('Seaching criteria does not produce any result');

return false;



}
	
	
function  checkboxid(obj1)
{
var j1=1;
var i=3;
var ciobookid="";
var insertion="";
var edition="";
var j;
var one=0;
var str1="DataGrid1_ctl02_Checkbox1";
if(document.getElementById("DataGrid1")==null)
{
  alert('please check atleast 1 id from grid' );
  return false;
}
else
{
	for(j=1;j<document.getElementById("DataGrid1").rows.length-1;j++)				
	{  
		if(document.getElementById("DataGrid1_ctl0"+ i +"_Checkbox1").checked==true)
		{		
		ciobookid=document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
        //insertion= 	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
        //edition=  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
		j1=2;
		one=one+1;
		}
		i=i+1;
		
		                 
				
   }
}
        if(one>1)
        {
            alert('Please Select only one CheckBox for modify');
            return false;
        }
				
        if(j1==1)
        {
            alert('Please Select atlest one CheckBox for modify');
            return false;
        }
				 
}

 function  checklenthbill1()
 {
 alert ('this bill can not be printed');
  return false;
 
 }
				 
				 
				 
				 
function chekvalidaton()
{



//garima
var check=1;



	
				 
      if(document.getElementById('drpbillstatus').value=="0")
             {
            
                alert('Please Enter  Bill Type');
                return false;
            
              }
              
               if(document.getElementById('dpdadtype').value=="0")
             {
            
                alert('Please Enter  Adtype');
               return false;
            
              }
              if(document.getElementById("billgen").checked==true || document.getElementById("billprev").checked==true||document.getElementById("billreprint").checked==true)
              
            {
            check=2;
            }
            if(check==1)
            {
            alert('Please select atleast one radio button');
               return false;
            }
            
            /////
            
            if(document.getElementById('dpdadtype').value=="CL0")
            {
            
            
             if(document.getElementById('txtfrmdate').value=="")
             {
            
                alert('Please Enter  From Date');
                return false;
            
              }
               if(document.getElementById('txttodate1').value=="")
             {
            
                alert('Please Enter  Dateto');
                return false;
            
              }
            
            
            
            
            
            var dateformat=document.getElementById('hiddendateformat').value;
            if(dateformat=="mm/dd/yyyy")
            {
            var strfromdate=document.getElementById('txtfrmdate').value;
            var strdateto=document.getElementById('txttodate1').value;
            var strfromdate1mon=strfromdate.split('/')[0]
            var strdateto1mon=strdateto.split('/')[0]
             var strfromdate1year=strfromdate.split('/')[2]
            var strdateto1year=strdateto.split('/')[2]
            }
            else
            if(dateformat=="dd/mm/yyyy")
            {
            
               var strfromdate=document.getElementById('txtfrmdate').value;
            var strdateto=document.getElementById('txttodate1').value;
            var strfromdate1mon=strfromdate.split('/')[1]
            var strdateto1mon=strdateto.split('/')[1]
             var strfromdate1year=strfromdate.split('/')[2]
            var strdateto1year=strdateto.split('/')[2]
            }
            else         
            
            {
             var strfromdate=document.getElementById('txtfrmdate').value;
            var strdateto=document.getElementById('txttodate1').value;
            var strfromdate1mon=strfromdate.split('/')[1]
            var strdateto1mon=strdateto.split('/')[1]
             var strfromdate1year=strfromdate.split('/')[0]
            var strdateto1year=strdateto.split('/')[0]
            }
            
            if(strfromdate1mon==strdateto1mon && strfromdate1year==strdateto1year)
            {
            }
            else
            {
            alert('selected from date  and Date to  must be of same year and month');
              return false;
            }
            
            }
              
				 
				 
}

function  checkvisible(obj)
{

//var checkst=1;
//  var str1="DataGrid1_ctl02_Checkbox1";
////              if (document.getElementById("billgen").checked ==true && document.getElementById("drpbillstatus").value=="2" )
////                {
//                for(j=1;j<document.getElementById('DataGrid1').rows.length;j++)
//				
//				{
//				document.getElementById(str1). disabled=true;
//				var  str2=str1.split('_')[1]
//				
//				
//				var str3=str2.split('l')[1]
//				var str4=str2.split('l')[0]
//				str3=str3
//				str3=Number(str3)+1;
//				if(str3>=10)
//				{
//				str1="DataGrid1_ctl"+str3+"_Checkbox1";
//				}
//				else
//				{
//				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
//				 } 
//				}
//                document.getElementById('btnnext').disabled= true;
//                
//                
////                  }  
////               
//                
//                ////////////////ALL///////////////////////
////                else
////                if (document.getElementById("billgen").checked ==true&&document.getElementById("drpbillstatus").value=="1")
////                {
//                for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
//				
//				{
//				if(document.getElementById("DataGrid1").rows[j].cells[10].innerHTML=="billed")
//				
//				{
//				document.getElementById(str1). disabled=true;
//				}
//				else
//				
//				{
//				checkst=2;
//				}
//				var  str2=str1.split('_')[1]
//				
//				
//				var str3=str2.split('l')[1]
//				var str4=str2.split('l')[0]
//				str3=str3
//				str3=Number(str3)+1;
//				if(str3>=10)
//				{
//				str1="DataGrid1_ctl"+str3+"_Checkbox1";
//				}
//				else
//				{
//				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
//				 } 
//				}
//                
//                if(checkst==2)
//                {
//                document.getElementById('btnnext').disabled= false;
//                
//                }
//                else
//                
//                {
//                document.getElementById('btnnext').disabled= true;
//                }
//                
//                
//                
//                    
////                }
//                
//                ///all with preview
//                
////                 else
////                if ((document.getElementById("billprev").checked ==true&&document.getElementById("drpbillstatus").value=="1")||(document.getElementById("billreprint").checked ==true&&document.getElementById("drpbillstatus").value=="1"))
////                {
//                
//                
//                for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
//				
//				{
//				if((document.getElementById("DataGrid1").rows[j].cells[10].innerHTML=="publish")||(document.getElementById("DataGrid1").rows[j].cells[10].innerHTML=="audit by rate"))
//				
//				{
//				document.getElementById(str1). disabled=true;
//				}
//				else
//				
//				{
//				checkst=2;
//				}
//				var  str2=str1.split('_')[1]
//				
//				
//				var str3=str2.split('l')[1]
//				var str4=str2.split('l')[0]
//				str3=str3
//				str3=Number(str3)+1;
//				if(str3>=10)
//				{
//				str1="DataGrid1_ctl"+str3+"_Checkbox1";
//				}
//				else
//				{
//				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
//				 } 
//				}
//                
//                if(checkst==2)
//                {
//                document.getElementById('btnnext').disabled= false;
//                
//                }
//                else
//                
//                {
//                document.getElementById('btnnext').disabled= true;
//                }
//                
//                
//                
//                    
////                }
//                
//                
//                /////////
//                
////                 else
////                if ((document.getElementById("billprev").checked ==true&&document.getElementById("drpbillstatus").value=="3")||(document.getElementById("billreprint").checked ==true&&document.getElementById("drpbillstatus").value=="3"))
////                {
//                for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
//				
//				{
//				if((document.getElementById("DataGrid1").rows[j].cells[10].innerHTML=="publish")||(document.getElementById("DataGrid1").rows[j].cells[10].innerHTML=="audit by rate"))				
//				{
//				document.getElementById(str1). disabled=true;
//				}
//				else
//				
//				{
//				checkst=2;
//				}
//				var  str2=str1.split('_')[1]
//				
//				
//				var str3=str2.split('l')[1]
//				var str4=str2.split('l')[0]
//				str3=str3
//				str3=Number(str3)+1;
//				if(str3>=10)
//				{
//				str1="DataGrid1_ctl"+str3+"_Checkbox1";
//				}
//				else
//				{
//				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
//				 } 
//				}
//                
//                if(checkst==2)
//                {
//                document.getElementById('btnnext').disabled= false;
//                
//                }
//                else
//                
//                {
//                document.getElementById('btnnext').disabled= true;
//                }
//                
//                
//                
//                    
//                //}
//                
//                          
////                
}




  /*function SelectHi(grdid,obj,objlist)
			{ 		
			
			 onclick="SelectHi('DataGrid1',this,'Checkbox1');"
				
				
				var j1;
				var j;
				var str1="DataGrid1_ctl02_Checkbox1";
				for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				   // document.getElementById("DataGrid1").rows[j].cells[7].childNodes[0].checked=true;
				if(objlist=="Checkbox1")
				{		 
				
				
			document.getElementById(str1).checked=false;
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				
				
				
				}
				return false;
			
				
			}  */
			
			
			
			
			
			



function  checkboxidnew()
{

var checkradio="";


//if(document.getElementById("billgen").checked ==true &&  document.getElementById("DataGrid1").rows[j].cells[0].innerHTML==)

if (document.getElementById("billprev").checked == true)
            {
                checkradio="1";
            }
            else
                if (document.getElementById("billgen").checked ==true)
                {
                    checkradio="2";
                }
                 else
                    if (document.getElementById("billreprint").checked ==true)
                    {
                        checkradio ="3";
                    }
                else
                {
                    checkradio ="4";
                }

//var checkradio=document.getElementById("hiddenradio").value;
if(checkradio=="4")
{
alert('please select altest once Billing type');
return false;
}
var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
agencycode="";


				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				
				
				if(agencycode=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[7].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[7].innerHTML;
				
			}
				
				
				
				
			// ciobookid= ciobookid+","+	document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
			//var insertion= 	document.getElementById("DataGrid1").rows[j].cells[2].innerHTML;
			//var edition=  document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
			j1=2;
			//bookaudit.updatestatus(ciobookid,insertion,edition);
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 window.open('invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt);
				  
				   
				 
				 
				 

				 
				
				


}



/////


function  blankgrid()
{
if(document.getElementById("DataGrid1")!=null)
{

document.getElementById("DataGrid1").outerText='';
return false;
}

if(document.getElementById("DataGrid2")!=null)
{

document.getElementById("DataGrid2").outerText='';
return false;
}


}


///////////


function SelectHi(grdid,obj,objlist)
{ 	

var str3="";
if(document.getElementById(obj.id).checked==true)
{ 
	var j1;
	var j;
	var str1=obj.id;
	for(j=1;j<document.getElementById(grdid).rows.length;j++)
	{
	    if(objlist=="Checkbox4")
	    {
	        if(document.getElementById(str1).disabled==false)
	        {
            document.getElementById(str1).checked=true;
            }
	    var  str2=str1.split('_')[1]
	    str3=str2.split('l')[1]
	    var str4=str2.split('l')[0]
	    str3=str3
	    str3=Number(str3)+1;
	        if(str3>=10)
	        {
	        str1= grdid+"_ctl"+str3+"_Checkbox1";
	        }	    
	        else
	        {
	         str1=grdid+"_ctl0"+str3+"_Checkbox1";
	        }
	    }
	}
}	
else
{ 
	var j1;
	var j;
	var str1=obj.id;
	var strn= grdid+"_ctl"+str3+"_"+ objlist
	    for(j=1;j<document.getElementById(grdid).rows.length;j++)
	    {
	        if(objlist=="Checkbox4")
	        {
            document.getElementById(str1).checked=false;
	        var  str2=str1.split('_')[1]				
	        var str3=str2.split('l')[1]
	        var str4=str2.split('l')[0]
	        str3=str3
	        str3=Number(str3)+1;
	            if(str3>=10)
	            {
	            str1=grdid+"_ctl"+str3+"_Checkbox1";
	            }
	            else
	            {
	             str1=grdid+"_ctl0"+str3+"_Checkbox1";
	            }
	        }
	    }
	return false;
}
} 
			
function  checkvisiblecla()
{

document.getElementById('div1').style.display="block";

var checkst=1;
  var str1="DataGrid2_ctl02_Checkbox1";
              if (document.getElementById("billgen").checked ==true && document.getElementById("drpbillstatus").value=="2" )
                {
                for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)
				
				{
				document.getElementById(str1). disabled=true;
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 
				}
                document.getElementById('btnnext').disabled= true;
                
                
                    
                }
                
                ////////////////ALL///////////////////////
                else
                if (document.getElementById("billgen").checked ==true&&document.getElementById("drpbillstatus").value=="1")
                {
                for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)
				
				{
				if(document.getElementById("DataGrid2").rows[j].cells[7].innerHTML=="billed")
				
				{
				document.getElementById(str1). disabled=true;
				}
				else
				
				{
				checkst=2;
				}
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 
				}
                
                if(checkst==2)
                {
                document.getElementById('btnnext').disabled= false;
                
                }
                else
                
                {
                document.getElementById('btnnext').disabled= true;
                }
                
                
                
                    
                }
                
                ///all with preview
                
                 else
                if ((document.getElementById("billprev").checked ==true&&document.getElementById("drpbillstatus").value=="1")||(document.getElementById("billreprint").checked ==true&&document.getElementById("drpbillstatus").value=="1"))
                {
                
                
                for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)
				
				{
				if((document.getElementById("DataGrid2").rows[j].cells[7].innerHTML=="publish")||(document.getElementById("DataGrid2").rows[j].cells[7].innerHTML=="audit by rate"))
				
				{
				document.getElementById(str1). disabled=true;
				}
				else
				
				{
				checkst=2;
				}
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 
				}
                
                if(checkst==2)
                {
                document.getElementById('btnnext').disabled= false;
                
                }
                else
                
                {
                document.getElementById('btnnext').disabled= true;
                }
                
                
                
                    
                }
                
                
                /////////
                
                 else
                if ((document.getElementById("billprev").checked ==true&&document.getElementById("drpbillstatus").value=="3")||(document.getElementById("billreprint").checked ==true&&document.getElementById("drpbillstatus").value=="3"))
                {
                for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)
				
				{
				if((document.getElementById("DataGrid2").rows[j].cells[9].innerHTML=="publish")||(document.getElementById("DataGrid2").rows[j].cells[9].innerHTML=="audit by rate"))				
				{
				document.getElementById(str1). disabled=true;
				}
				else
				
				{
				checkst=2;
				}
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 
				}
                
                if(checkst==2)
                {
                document.getElementById('btnnext').disabled= false;
                
                }
                else
                
                {
                document.getElementById('btnnext').disabled= true;
                }
                
                
                
                    
                }
                   
                
}




function checklenthbillcla()
{

alert('Seaching criteria does not produce any result');
return false;



}

function modify()
{
var adtype="";
var j1=1;
var i=3;
var a=3;
var ciobookid="";
var insertion="";
var edition="";
var j;
var one=0;
var str1="DataGrid1_ctl02_Checkbox1";
    if(document.getElementById("DataGrid1")==null)
    {
      alert('please check atleast 1 id from grid' );
      return false;
    }
    else
    {
        for(j=1;j<document.getElementById("DataGrid1").rows.length-1;j++)	
        ///for(j=1;j<8;j++)				
        {  
            if(a<10)
            {
                if(document.getElementById("DataGrid1_ctl0"+ a +"_Checkbox1").checked==true)
                {


                {		
                ciobookid=document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
                adtype=document.getElementById("DataGrid1").rows[j].cells[29].innerHTML;
                //insertion= 	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
                //edition=  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
                j1=2;
                one=one+1;
                }
                i=i+1;



                }

            }
            else
            {
                if(document.getElementById("DataGrid1_ctl"+ a +"_Checkbox1").checked==true)
                {


                {		
                ciobookid=document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
                adtype=document.getElementById("DataGrid1").rows[j].cells[29].innerHTML;
                //insertion= 	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
                //edition=  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
                j1=2;
                one=one+1;
                }
                i=i+1;



                }

            }
            a=a+1;

        }
    if(one>1)
    {
        alert('Please Select only one CheckBox for modify');
        return false;
    }
			
    if(j1==1)
    {
        alert('Please Select atlest one CheckBox for modify');
        return false;
    }
	

    if(confirm('Do you want to modify this transaction?'))
	{
    var frombooking="querymod";
    //var clientname=document.getElementById('txtclient').value;
    
    
    if(adtype=="DI0")
    {
    
    window.open('Booking_master.aspx?frombooking='+frombooking+'&ciobookid='+ciobookid,'','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
    }
    else
    {
   // window.open('Booking_master.aspx?frombooking='+frombooking+'&ciobookid='+ciobookid,'','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
    window.open('Classified_Booking.aspx?frombooking='+frombooking+'&ciobookid='+ciobookid,'','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
    }
    
}
}
}



//}
function sorting(field,fieldid)
{
var imgsplit=fieldid.split("~")[1];

//alert(imgsplit)

var imageid=$(fieldid).childNodes[1].id


//alert(imageid)
var newimageid="";
if($(fieldid).childNodes[1].id.indexOf("down")>-1)
{
    newimageid=imageid.replace("down","up");
//alert(newimageid)
}
else if($(fieldid).childNodes[1].id.indexOf("up")>-1)
{
    newimageid=imageid.replace("up","down");
   // alert(newimageid)
}
if(document.getElementById("ctrlIds")!=null)
    document.getElementById("ctrlIds").value=imageid+","+newimageid;//Manish Verma
//if(imageidimgpubdown)
    document.getElementById('hiddencioid').value=field;
   if(document.getElementById(imageid).style.display=="block")
   {
        document.getElementById(newimageid).style.display="block";
        document.getElementById(imageid).style.display="none";
        document.getElementById('hiddenascdesc').value="desc";
   }
   else if(document.getElementById(newimageid).style.display=="block")
   {
        document.getElementById(newimageid).style.display="none";
        document.getElementById(imageid).style.display="block";
        document.getElementById('hiddenascdesc').value="asc";
        
   }
   
    
    
    document.form1.submit();
    

}

