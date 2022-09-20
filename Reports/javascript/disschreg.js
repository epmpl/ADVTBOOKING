
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
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name,ds.Tables[0].Rows[i].code_subcode/*ds.Tables[0].Rows[i].SUB_Agency_Code*/);
  
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
            //clientreport.getsubsubcategory(page,document.getElementById('hiddencompcode').value,call_bindsubsubcat);
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
        document.getElementById('divagency').style.top=203;
        document.getElementById('divagency').style.left=570;
        document.getElementById('lstagency').focus();
//        Agent_master.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txtsagencycode').value,bindagencyname_callback);
        clientreport.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('txtagency').value,bindagencyname_callback);
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
        document.getElementById('divproduct').style.top=253;
        document.getElementById('divproduct').style.left=570;
        clientreport.bindProductcategory(document.getElementById('hiddencompcode').value,document.getElementById('txtproduct').value,bindproductname_callback);
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
        document.getElementById('divclient').style.top=227;
        document.getElementById('divclient').style.left=570;
        document.getElementById('lstclient').focus();
        clientreport.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtclient').value,bindclientname_callback);
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
//////////        clientreport.getbrand(page,document.getElementById('hiddencompcode').value,call_bindbrand);
        clientreport.getsubcategory(page,document.getElementById('hiddencompcode').value,call_bindsubcat);
        document.getElementById("divproduct").style.display='none';
        
        return false;
        }
         
         
//////////////////         document.getElementById('txtproduct').value=id;
//////////////////        
//////////////////        
//////////////////        //document.getElementById('drpbrand').focus();
//////////////////        clientreport.getbrand(page,document.getElementById('hiddencompcode').value,call_bindproduct);
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
//////////        clientreport.getbrand(page,document.getElementById('hiddencompcode').value,call_bindbrand);
        clientreport.getsubcategory(page,document.getElementById('hiddencompcode').value,call_bindsubcat);
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
//clientreport.getsubsubcategory(page,document.getElementById('hiddencompcode').value,call_bindsubsubcat);
  clientreport.getsubsubcategory(lstproduct,dpsubcat,compcode,call_bindsubsubcategory);
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
  
var compcode=document.getElementById('hiddencompcode').value;
var drpbrand=document.getElementById('drpbrand').value;
document.getElementById('dpbrand1').value=document.getElementById('drpbrand').value;;

//clientreport.getsubsubcategory(page,document.getElementById('hiddencompcode').value,call_bindsubsubcat);
  clientreport.getvarient(compcode,drpbrand,call_bindforvarient);
return false;
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
//clientreport.getsubsubcategory(page,document.getElementById('hiddencompcode').value,call_bindsubsubcat);
  clientreport.getbrand(/*dpsubcat,*/dpsubsubcat,compcode,call_bindbrand);
return false;
}


function selectvalue()
{
document.getElementById('dpvarient1').value=document.getElementById('dpvarient').value;
//document.getElementById('dpregion').focus();
return false;

}


/*********************               new     shachi            ************************/


function datenullcheck()
{
        if(document.getElementById('txtfrmdate').value== "")
        {
                alert('Please fill the From Date first.');
                document.getElementById('txtfrmdate').focus();
                return false;
        }
        else if(document.getElementById('txttodate1').value== "")
        {
               alert('Please fill the To Date first.');
               document.getElementById('txttodate1').focus();
               return false;
        }
}




function check_dat()
{
               // checkdate(input);
                var dateformat = document.getElementById('hiddendateformat').value;
                var todate=document.getElementById('txttodate1').value;
                var fromdate=document.getElementById('txtfrmdate').value; 
                var todate1 = "";
                var fromdate1 = "";
     
     if((todate != "") && (fromdate != ""))
     {

             
            
                        
//                       
//                        var dd=todate.getDate();
//                        var mm=todate.getMonth()+1;
//                        var yyyy=todate.getFullYear();
//                         
//    	                var currdate1=mm+'/'+dd+'/'+yyyy;
            			
                       
   	                        if(dateformat=="mm/dd/yyyy")
		                    {
		                                 todate1=new Date(todate);
		                                 fromdate1=new Date(fromdate);
	                                     if(todate1<=fromdate1)
                                         {
                                                    alert('To date should be greater than From date.');
                                                    document.getElementById('txttodate1').value="";
                                                    document.getElementById('txtfrmdate').value="";
                                                    document.getElementById('txtfrmdate').focus();
                                                    return false;
                                         }
		                    }
                    		
		                    if(dateformat=="dd/mm/yyyy")
		                    {
		                                 var split=(todate).split("/");
                                         var dd1=split[0];
                                         var mm1=split[1];
		                                 var yyyy1=split[2];
            		                     
		                                 todate1 = mm1+'/'+dd1+'/'+yyyy1;
		                                 
		                                 
		                                 var split1=(fromdate).split("/");
                                         var dd11=split1[0];
                                         var mm11=split1[1];
		                                 var yyyy11=split1[2];
            		                     
		                                 fromdate1 = mm11+'/'+dd11+'/'+yyyy11;
		                                 
		                                 
		                                 var todate1=new Date(todate1);
		                                 var fromdate1=new Date(fromdate1);
	                                     if(todate1<=fromdate1)
                                         {
                                                    alert('To date should be greater than From date.');
                                                    document.getElementById('txttodate1').value="";
                                                    document.getElementById('txtfrmdate').value="";
                                                    document.getElementById('txtfrmdate').focus();
                                                    return false;
                                         }
		                    }
                    		
		                    if(dateformat=="yyyy/mm/dd")
		                    {
		                    
		                                 var split=(fromdate).split("/");
                                         var dd1=split[0];
                                         var mm1=split[1];
		                                 var yyyy1=split[2];
            		                     
		                                 fromdate1 = mm1+'/'+dd1+'/'+yyyy1;
		                                 
		                                 var split1=(todate).split("/");
                                         var dd11=split1[0];
                                         var mm11=split1[1];
		                                 var yyyy11=split1[2];
            		                     
		                                 todate1 = mm11+'/'+dd11+'/'+yyyy11;
            		        
            		                     var todate1=new Date(todate1);
		                                 var fromdate1=new Date(fromdate1);
	                                     if(todate1<=fromdate1)
                                         {
                                                    alert('To date should be greater than From date.');
                                                    document.getElementById('txttodate1').value="";
                                                    document.getElementById('txtfrmdate').value="";
                                                    document.getElementById('txtfrmdate').focus();
                                                    return false;
                                         }
		                    
		                              
		                    }
                        
               
                
          }    
                
    
}

