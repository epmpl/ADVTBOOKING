// JScript File



var browser = navigator.appName;

function tabvalue123(event) {
    var keycode = event.keyCode ? event.keyCode : event.which

    if (keycode == 13) {

        if (document.activeElement.id == 'txtagency') {
        
            if (document.getElementById('txtagency').value == "" || document.getElementById('txtagency').value != "") {

                document.getElementById('txtsperson').focus();
                return false;
            }
        }

        if (document.activeElement.id == 'txtsperson') {

            if (document.getElementById('txtsperson').value == "" || document.getElementById('txtsperson').value != "") {

                document.getElementById('txtcust').focus();
                return false;
            }
        }



        if (document.activeElement.id == 'txtcust') {

            if (document.getElementById('txtcust').value == "" || document.getElementById('txtcust').value != "") {

                document.getElementById('txtfromdate').focus();
                return false;
            }
        }




        if (document.activeElement.id == 'txtfromdate') {

            if (document.getElementById('txtfromdate').value == "" || document.getElementById('txtfromdate').value != "") {

                document.getElementById('txttodate').focus();
                return false;
            }
        }





        if (document.activeElement.id == 'txttodate') {

            if (document.getElementById('txttodate').value == "" || document.getElementById('txttodate').value != "") {

                document.getElementById('txtsheldate').focus();
                return false;
            }
        }




        if (document.activeElement.id == 'txttodate') {

            if (document.getElementById('txttodate').value == "" || document.getElementById('txttodate').value != "") {

                document.getElementById('txtsheldate').focus();
                return false;
            }
        }






        if (document.activeElement.id == 'txtsheldate') {

            if (document.getElementById('txtsheldate').value == "" || document.getElementById('txtsheldate').value != "") {

                document.getElementById('insertntodate').focus();
                return false;
            }
        }



        if (document.activeElement.id == 'insertntodate') {

            if (document.getElementById('insertntodate').value == "" || document.getElementById('insertntodate').value != "") {

                document.getElementById('drpStatus').focus();
                return false;
            }
        }





        if (document.activeElement.id == 'drpStatus') {

            if (document.getElementById('drpStatus').value == "" || document.getElementById('drpStatus').value != "") {

                document.getElementById('txttext').focus();
                return false;
            }
        }




        if (document.activeElement.id == 'txttext') {

            if (document.getElementById('txttext').value == "" || document.getElementById('txttext').value != "") {

                document.getElementById('BtnRun').focus();
                return false;
            }
        }




        return false;

    }

}







 function checkfontname()
 {
  if(document.getElementById('radh1').checked==true)
    document.getElementById('txttext').className = "btexthindi";
  else
    document.getElementById('txttext').className = "btext1";
 }
function insertclient()
{

//document.getElementById('hiddenquery').value="query";
//if(document.getElementById('hiddenquery').value=="query")
//{
    if(document.activeElement.id=="lstclient")
    {
    if(document.getElementById('lstclient').value=="0")
        {
        alert("Please select the client");
        return false;
        }
        document.getElementById("divclient").style.display="none";
        
        var w = document.report1.lstclient.selectedIndex;
        var clientnameadd=document.report1.lstclient.options[w].text;
        var arrclient=clientnameadd.split('+');
        var nameagen = document.report1.lstclient.options[w].text;
           
//        var page=document.getElementById('lstclient').value;
//        agencycodeglo=page;
//         var xml = new ActiveXObject("Microsoft.XMLHTTP");
//         xml.Open( "GET","agency_list.aspx?page="+page+"&value=1", false );
//         xml.Send();
//         var id=xml.responseText;
//         
//         var split=id.split("+");
//         var nameagen=split[0];
//         var agenadd1=split[1];
//         var agenadd2=split[2];
//         var agenadd3=split[3];
        
         
        
        document.getElementById('txtcust').value=nameagen;
        document.getElementById('hdnclient').value=document.getElementById('lstclient').value;
        
        document.getElementById("divclient").style.display='none';
        
        return false;
    }
    
    
//}

}






function tabvaluebyid(event)
 {

    var keycode = event.keyCode ? event.keyCode : event.which
//    document.getElementById('hiddenquery').value="query";
    //if(document.getElementById('hiddenquery').value=="query")


    if (keycode == 27) 
{


    if(document.activeElement.id=="lstagency")
    {
        document.getElementById("divagency").style.display="none";
        document.getElementById("txtagency").focus();
        return false;
    }
    else if(document.activeElement.id=="lstsperson")
    {
        document.getElementById("divsperson").style.display="none";
        document.getElementById("txtsperson").focus();
        return false;
    }
     else if(document.activeElement.id=="lstclient")
    {
        document.getElementById("divclient").style.display="none";
        document.getElementById("txtcust").focus();
      }
  }
  
  
  
  
  


   {



       if (keycode == 113) 
      {



                         if (document.activeElement.id == "txtagency") 
                        {
                        document.getElementById("divsperson").style.display = "none";
                        if (document.getElementById("divclient").style.display == "block")
                        {
                        document.getElementById("divclient").style.display = "none"
                        }


                        document.getElementById("divagency").style.display = "block";
                        /////////////////// 



                        var activeid=document.activeElement.id;
                        var listboxid="lstagency";
                        var objchannel=document.getElementById(listboxid);
                        var divid="divagency";

                        aTag = eval(document.getElementById(activeid))
                        var btag;
                        var leftpos=0;
                        var toppos=0;        
                        do {
                        aTag = eval(aTag.offsetParent);
                        leftpos    += aTag.offsetLeft;
                        toppos += aTag.offsetTop;
                        btag=eval(aTag)
                        } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");  


                        document.getElementById("divagency").style.display="block";




                        document.getElementById("divagency").style.top=document.getElementById(activeid).offsetHeight + toppos + "px";
                        document.getElementById("divagency").style.left=document.getElementById(activeid).offsetLeft + leftpos+"px";



                        ///////////////////
                        document.getElementById('lstagency').focus();
                        search.bindagencyname(document.getElementById('hiddencompcode').value.toUpperCase(), document.getElementById('txtagency').value.toUpperCase(), bindagencyname_callback);
                        }

                        else if (document.activeElement.id == "txtcust")
                         {
                        document.getElementById("divsperson").style.display = "none";
                        if (document.getElementById("divagency").style.display = "block") 
                        {
                        document.getElementById("divagency").style.display = "none"
                        }
                        document.getElementById("divclient").style.display = "block";
                        ///////
                        



                        var activeid = document.activeElement.id;
                        var listboxid = "lstclient";
                        var objchannel = document.getElementById(listboxid);
                        var divid = "divclient";

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


                        document.getElementById("divclient").style.display = "block";




                        document.getElementById("divclient").style.top = document.getElementById(activeid).offsetHeight + toppos + "px";
                        document.getElementById("divclient").style.left = document.getElementById(activeid).offsetLeft + leftpos + "px";


                       
                       
                       
                       
                       
                       
                       
                       ////////
                        document.getElementById('lstclient').focus();
                        search.bindclientname(document.getElementById('hiddencompcode').value, document.getElementById('txtcust').value.toUpperCase(), bindclientname_callback);
                        }

                        else if (document.activeElement.id == "txtsperson") {
                        document.getElementById("divclient").style.display = "none";
                        if (document.getElementById("divagency").style.display = "block") {
                        document.getElementById("divagency").style.display = "none"
                        }
                        document.getElementById("divsperson").style.display = "block";


                        var activeid = document.activeElement.id;
                        var listboxid = "lstsperson";
                        var objchannel = document.getElementById(listboxid);
                        var divid = "divsperson";

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


                        document.getElementById("divsperson").style.display = "block";
                       
                      
//                       
//                        if (screen.width <= 1024) {
//                        document.getElementById('divsperson').style.top = 162;
//                        document.getElementById('divsperson').style.left = 447;
//                        }
//                        else {
//                        document.getElementById('divsperson').style.top = 175;
//                        document.getElementById('divsperson').style.left = 555;
//                    }
                        //


                        document.getElementById("divsperson").style.top = document.getElementById(activeid).offsetHeight + toppos + "px";
                        document.getElementById("divsperson").style.left = document.getElementById(activeid).offsetLeft + leftpos + "px";





//                  
                        document.getElementById('divsperson').focus();
                        search.bindusername(document.getElementById('txtsperson').value.toUpperCase(), bindusername_callback);
                        }

                        }



                    }



                
  
  
  

  if (keycode == 13)
    {
        
        if(document.activeElement.id=="lstagency")
        {
            document.getElementById('hdnagency').value=document.getElementById('lstagency').value;
            document.getElementById("divagency").style.display="none";

            var w = document.report1.lstagency.selectedIndex;
            var nameagen = document.report1.lstagency.options[w].text;
            document.getElementById('txtagency').value=nameagen;
            
            document.getElementById('txtagency').focus();
            return false;
        }
         if(document.activeElement.id=="lstsperson")
        {
        document.getElementById('hdnsperson').value=document.getElementById('lstsperson').value;
            document.getElementById("divsperson").style.display="none";

            var w = document.report1.lstsperson.selectedIndex;
            var nameagen = document.report1.lstsperson.options[w].text;
            document.getElementById('txtsperson').value=nameagen;
            document.getElementById('txtsperson').focus();
            return false;
        }
         if(document.activeElement.id=="lstclient")
        {
        document.getElementById('hdnclient').value=document.getElementById('lstclient').value;
            document.getElementById("divclient").style.display="none";

            var w = document.report1.lstclient.selectedIndex;
            var clientnameadd=document.report1.lstclient.options[w].text;
            var arrclient=clientnameadd.split('+');
            var nameagen = document.report1.lstclient.options[w].text;
            
            document.getElementById('txtcust').value=nameagen;
            document.getElementById('txtcust').focus();
            return false;
        }

        if (document.activeElement.id == 'txtcust') {
            if (document.getElementById('txtcust').value == "" || document.getElementById('txtcust').value != "") {
                document.getElementById('txtfromdate').focus();
                return false;
            }
        }


        if (document.activeElement.id == 'txtfromdate') {
            if (document.getElementById('txtfromdate').value == "" || document.getElementById('txtfromdate').value != "") {
                document.getElementById('txttodate').focus();
                return false;
            }
        }




        if (document.activeElement.id == 'txttodate') {
            if (document.getElementById('txttodate').value == "" || document.getElementById('txttodate').value != "") {
                document.getElementById('txtsheldate').focus();
                return false;
            }
        }



        if (document.activeElement.id == 'txtsheldate') {
            if (document.getElementById('txtsheldate').value == "" || document.getElementById('txtsheldate').value != "") {
                document.getElementById('insertntodate').focus();
                return false;
            }
        }
        
        
        
        
        
        
    }


    if (keycode == 8 || keycode == 46) {


        if (document.activeElement.id == "txtagency") {

            document.getElementById('txtagency').value = '';
            document.getElementById('txtagency').focus();


        }



        if (document.activeElement.id == "txtsperson") {

            document.getElementById('txtsperson').value = '';
            document.getElementById('txtsperson').focus();


        }




        if (document.activeElement.id == "txtcust") {

            document.getElementById('txtcust').value = '';
            document.getElementById('txtcust').focus();


        }



    }
    
    
    
//}
}


function insertagency(event)
{

    if(document.activeElement.id=="lstagency")
    {
    if(document.getElementById('lstagency').value=="0")
        {
        alert("Please select the agency");
        return false;
        }
        document.getElementById("divagency").style.display="none";

        var w = document.report1.lstagency.selectedIndex;
        var nameagen = document.report1.lstagency.options[w].text;
           
     // var agenadd3=split[3];
        
         
        
          document.getElementById('txtagency').value=nameagen;
          document.getElementById('hdnagency').value=document.getElementById('lstagency').value;



          document.getElementById("divagency").style.display = 'none';
        
        
        
        
        return false;
    }
    
    


}
	
	
	function bindagencyname_callback(response)
{       
    ds=response.value;
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


    var pkgitem = document.getElementById("lstagency");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Agency-","0");
    pkgitem.options.length = 1; 
  
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        if(document.getElementById('hiddendatabase').value=="orcl")
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name,ds.Tables[0].Rows[i].code_subcode);
        }
        else
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name,ds.Tables[0].Rows[i].code_subcode);
        }
        
       pkgitem.options.length;
       
    }
    }
    document.getElementById('txtagency').value="";
    document.getElementById("lstagency").value="0";
     document.getElementById("lstagency").disabled=false;
   
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
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        var add="";
        if(ds.Tables[0].Rows[i].Add1!=null)
        {
            add=ds.Tables[0].Rows[i].Add1;
        }
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name+"+"+add,ds.Tables[0].Rows[i].Cust_Code);
        
       pkgitem.options.length;
       
    }
    
    }
    document.getElementById('txtclient').value="";
    document.getElementById("lstclient").value="0";
    document.getElementById("lstclient").focus();
     return false;
}


function bindusername_callback(response)
{
    ds=response.value;
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {


        var pkgitem = document.getElementById("lstsperson");
        pkgitem.options.length = 0; 
        pkgitem.options[0]=new Option("-Select Sales Person-","0");
        pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].username,ds.Tables[0].Rows[i].userid);

            pkgitem.options.length;

        }

    }
        document.getElementById('txtsperson').value="";
        document.getElementById("lstsperson").value="0";
        document.getElementById("lstsperson").focus();
        return false;
}


function insertspeson()
{

  if(document.activeElement.id=="lstsperson")
    {
    if(document.getElementById('lstsperson').value=="0")
        {
        alert("Please select the Sales Person");
        return false;
        }
        document.getElementById("divagency").style.display="none";

        var w = document.report1.lstsperson.selectedIndex;
        var nameagen = document.report1.lstsperson.options[w].text;
           
    // var agenadd3=split[2];
        
         
        
        document.getElementById('txtsperson').value=nameagen;
                          document.getElementById('hdnsperson').value=document.getElementById('lstsperson').value;


        
        document.getElementById("divsperson").style.display='none';
        
        return false;
    }
}


function openPrintReceipt(cioid,client,clientadd,receiptno)
{
     window.open("Reciept_Ht.aspx?cioid="+cioid+"&clientname="+client+"&clientadd="+clientadd+"&receiptno="+receiptno);//,'','width=1000px,height=550px,resizable=1,left=0,top=0,scrollbars=yes');
}
function openbooking(cioid,id,length,adtype)
{
 document.getElementById('hiddenbookingid').value=cioid;

  window.open('QBC.aspx?search=true&cioid='+document.getElementById('hiddenbookingid').value+'&userid='+document.getElementById('hiddenusername').value,'','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');


}

function clientchange()
{
    document.getElementById('hdnclient').value="";
}

function agencychange(event) {

    document.getElementById('hdnagency').value = "";
    activeid = document.activeElement.id;
    document.getElementById("divagencyclient").style.display = "block";
    var divid = "divagencyclient";
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
    var tot = document.getElementById('divagencyclient').scrollLeft;
    var scrolltop = document.getElementById('divagencyclient').scrollTop;
    document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
    document.getElementById(divid).style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";
}

function spersonchange()
{
    document.getElementById('hdnsperson').value = "";

}








function F2fillclientcr_allclient(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        divid = "divclient";
        listboxid = "lstclient";
        txtbxid = eval(document.getElementById('txtcust'))
        txtboxid = "txtcust";

        activeid = document.activeElement.id;
        if (document.activeElement.id == "txtcust") {
            //$('txtagency').value="";
            var compcode = document.getElementById('hiddencompcode').value;
            var client = document.getElementById('txtcust').value.toUpperCase();
            document.getElementById("divclient").style.display = "block";

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
            var tot = document.getElementById('divclient').scrollLeft;
            var scrolltop = document.getElementById('divclient').scrollTop;
            document.getElementById(divid).style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById(divid).style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";
            
            
            
            
            
            
            
            
            
            
//            document.getElementById('divclient').style.top = 215 + "px";
//            document.getElementById('divclient').style.left = 580 + "px";

            search.fillF2_Creditclient(compcode, client, bindclient_callbackaa);

            document.getElementById('lstclient').focus();
            
            
        }
    }

}





function bindclient_callbackaa(res) {
    var ds_AccName = res.value;

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        
        
        
        var pkgitem = document.getElementById("lstclient");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Client Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Cust_Name, ds_AccName.Tables[0].Rows[i].Cust_Code);
            pkgitem.options.length;
        }
    }

//   yId(divid).style.top = document.getElementById(txtboxid).offsetTop + toppos - scrolltop + "px"; //"510px";
// var btag;
//    var leftpos = 0;
//    var toppos = 0;
//    do {
//        txtbxid = eval(txtbxid.offsetParent);
//        leftpos += txtbxid.offsetLeft;
//        toppos += txtbxid.offsetTop;
//        btag = eval(txtbxid)
//    } while (txtbxid.tagName != "BODY" && txtbxid.tagName != "HTML");
//    var tot = document.getElementById('div2').scrollLeft;
//    var scrolltop = document.getElementById('div2').scrollTop;
//    document.getElementById(divid).style.left = document.getElementById(txtboxid).offsetLeft + leftpos - tot + "px";
//    document.getElementB


//    document.getElementById("lstclient1").value = "0";
    //    document.getElementById("div2").value = "";

    document.getElementById('txtcust').value = "";
    document.getElementById("lstclient").value = "0";
    document.getElementById("lstclient").focus();

//    document.getElementById('lstclient1').focus();

    return false;

}


