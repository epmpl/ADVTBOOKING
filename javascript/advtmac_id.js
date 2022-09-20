////////////////////////////////////////////////////new added//////////////////////
var browser = navigator.appName;
var dsexecute;
var z = 0;
var val;
var mflag=0;

function fndnull(val){
    if(val==null || val=="null" || val=="undefined"){
        val=""
    }
    return val
}

function Exit() {
    if (confirm("Do You want to skip the page?")) {
        window.close();
        return false;
    }
    return false;

}



function blankfields() {

    if (document.getElementById("hdn_user_right").value == "0" || document.getElementById("hdn_user_right").value == "") {
//        alert("You are not Authorized to see this form")
//        window.close();
//        return false;
    }
    else {



        document.getElementById('btnNew').disabled = false;
        document.getElementById('btnNew').focus();
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnModify').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnDelete').disabled = true;
        setButtonImages();

      
        document.getElementById('Button4').style.display = 'none';
      

        //document.getElementById('btnCancel').disabled = true;
        return false;
  }
}








function filluser() {
    if (event.keyCode == 113) {
        if (document.activeElement.id == "txtuseridname") {
            document.getElementById('lstuser').value = "";
            document.getElementById("divuser").style.display = "block";
            document.getElementById('divuser').style.width = '100px';
            document.getElementById('divuser').style.top = 125 + "px";
            document.getElementById('divuser').style.left = 550 + "px";
            var extra1 = document.getElementById('txtuseridname').value.toUpperCase();
            advtmac_id.fill_user(extra1, binduser_callback)
        }
    }
    else if (event.keyCode == 8 || event.keyCode == 46) {
    document.getElementById('txtuseridname').value = "";
    document.getElementById('txtuseridcode').value = "";
    document.getElementById('txtbranchname').value = "";
    document.getElementById('txtfirstname').value = "";
    document.getElementById('txtlastname').value = "";
    
        return true;
    }
    else if (event.ctrlKey == true && event.keyCode == 88) {
    document.getElementById('txtuseridname').value = "";
    document.getElementById('txtuseridcode').value = "";
    document.getElementById('txtbranchname').value = "";
    document.getElementById('txtfirstname').value = "";
    document.getElementById('txtlastname').value = "";
        return true;
    }
    else if (event.keyCode == 27) {
    document.getElementById("divuser").style.display = "none";
    }
}


function binduser_callback(res) {
    ds = res.value;
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstuser");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select User-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].username, ds.Tables[0].Rows[i].userid);
            pkgitem.options.length;
        }
    }
    document.getElementById("lstuser").value = "0";
    document.getElementById('txtuseridname').value = "";
    document.getElementById('txtuseridcode').value = "";
    document.getElementById("lstuser").focus();
    return false;
}


function onclickuser() {
    if (event.keyCode == 13 || event.type == "click") {
        if (document.activeElement.id == "lstuser") {
            if (document.getElementById('lstuser').value == "0") {
                return false;
            }
            document.getElementById("divuser").style.display = "none";
            var page = document.getElementById('lstuser').value;
            for (var k = 0; k <= document.getElementById("lstuser").length - 1; k++) {
                if (document.getElementById('lstuser').options[k].value == page) {
                    var abc = document.getElementById('lstuser').options[k].innerText;
                    document.getElementById('txtuseridname').value = abc;
                    document.getElementById('txtuseridcode').value = page;
                    var compcode = document.getElementById('txtcompcode').value;
                    advtmac_id.getfirstlastname(compcode, page, testcall);

                    document.getElementById('txtmachinename').focus();
                    return false;
                }
            }
        }
    }
    else if (event.keyCode == 27) {
    document.getElementById("divuser").style.display = "none";
    }
}

function testcall(ress) {
    ds = ress.value;
    //document.getElementById('txtbranchname').value = fndnull(ds.Tables[1].Rows[0].Branch_Name);
    document.getElementById('txtfirstname').value = ds.Tables[0].Rows[0].FIRSTNAME;
    document.getElementById('txtlastname').value = ds.Tables[0].Rows[0].LASTNAME;

    //document.getElementById('txtbranchname').disabled = true;
    document.getElementById('txtfirstname').disabled = true;
    document.getElementById('txtlastname').disabled = true;
    
    return false;
}


function save_process() {

    var compcode = document.getElementById('txtcompcode').value;
    var username = document.getElementById('txtuseridname').value;
    var usercode = document.getElementById('txtuseridcode').value;
    if (document.getElementById('txtuseridcode').value == "") {
        alert("Please Select User ID By F2");
        document.getElementById('txtuseridname').focus();
        return false;
    }

    advtmac_id.getfirstlastname(compcode, usercode);
    
    
    var machinename = document.getElementById('txtmachinename').value;
    if (document.getElementById('txtmachinename').value == "") {
        alert("Please Select Machine Name");
        document.getElementById('txtmachinename').focus();
        return false;
    }

    var machineip = document.getElementById('txtmachineip').value;

    if (document.getElementById('txtmachineip').value == "") {
        alert("Please Select Machine IP");
        document.getElementById('txtmachineip').focus();
        return false;
    }
    var macip = document.getElementById('txtmacid').value;

    if (document.getElementById('txtmacid').value == "") {
        alert("Please Select MAC ID");
        document.getElementById('txtmacid').focus();
        return false;
    }
    var remark = document.getElementById('txtremark').value;
    var location = document.getElementById('txtlocation').value;
    if(mflag=="U"){
    var extra3="U";
    }
    else{
        extra3="I";
    }
    advtmac_id.savedata(compcode, usercode, machinename, machineip, macip, remark, location, username,extra3);
    alert("Data Saved Successfully");
    atmCancelclick('advtmac_id');
    
}



function atmNewclick() {

 
    document.getElementById('txtcompname').value = document.getElementById('hiddcompname').value;
    document.getElementById('txtcompcode').value = document.getElementById('hiddencomcode').value;
    document.getElementById('txtcompname').disabled = true;
    document.getElementById('txtcompcode').disabled = true;
    document.getElementById('txtuseridname').disabled = false;
    document.getElementById('txtuseridcode').disabled = false;
    document.getElementById('txtmachinename').disabled = false;
    document.getElementById('txtmachineip').disabled = false;
    document.getElementById('txtmacid').disabled = false;
    document.getElementById('txtremark').disabled = false;
    document.getElementById('txtlocation').disabled = false;

    
    document.getElementById('txtuseridname').value = "";
    document.getElementById('txtuseridcode').value = "";
    document.getElementById('txtmachinename').value = "";
    document.getElementById('txtmachineip').value = "";
    document.getElementById('txtmacid').value = "";
    document.getElementById('txtremark').value = "";
    document.getElementById('txtlocation').value = "";

    document.getElementById('btnNew').disabled = true;
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnQuery').disabled = true; 
     document.getElementById('Button4').disabled= true;
         document.getElementById('Button4').style.display="none";
    setButtonImages();
    return false;
}


function atmCancelclick(formname) {

    document.getElementById('txtcompname').value = "";
    document.getElementById('txtcompcode').value = "";
    document.getElementById('txtuseridname').value = "";
    document.getElementById('txtuseridcode').value = "";
    document.getElementById('txtmachinename').value = "";
    document.getElementById('txtmachineip').value = "";
    document.getElementById('txtmacid').value = "";
    document.getElementById('txtremark').value = "";
    document.getElementById('txtlocation').value = "";

    document.getElementById('txtbranchname').value = "";
    document.getElementById('txtfirstname').value = "";
    document.getElementById('txtlastname').value = "";

    document.getElementById('txtcompname').disabled = true;
    document.getElementById('txtcompcode').disabled = true;
    document.getElementById('txtuseridname').disabled = true;
    document.getElementById('txtuseridcode').disabled = true;
    document.getElementById('txtmachinename').disabled = true;
    document.getElementById('txtmachineip').disabled = true;
    document.getElementById('txtmacid').disabled = true;
    document.getElementById('txtremark').disabled = true;
    document.getElementById('txtlocation').disabled = true;

    document.getElementById('txtbranchname').disabled = true;
    document.getElementById('txtfirstname').disabled = true;
    document.getElementById('txtlastname').disabled = true;
    
    
    
    document.getElementById('Button4').disabled = true;
    document.getElementById('Td14').style.display = 'none';
    document.getElementById('view19').style.display = 'none';

    document.getElementById('btnExecute').disabled = true;

    document.getElementById('btnNew').disabled = false;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('btnQuery').disabled = false; 
     document.getElementById('Button4').style.display ='none';
    setButtonImages();
    return false;
}


function atmQueryclick() {
    document.getElementById('Button4').disabled = false;
    document.getElementById('Button4').style.display = "block";
    document.getElementById('Td14').style.display = 'none';
    document.getElementById('view19').style.display = 'none';
   
    document.getElementById('btnQuery').disabled = true;
    document.getElementById('btnExecute').disabled = false;
    document.getElementById('btnSave').disabled = true;
    document.getElementById('txtcompname').value = document.getElementById('hiddcompname').value;
    document.getElementById('txtcompcode').value = document.getElementById('hiddencomcode').value;
    document.getElementById('txtcompname').disabled = true;
    document.getElementById('txtcompcode').disabled = true;
    document.getElementById('txtuseridname').disabled = false;
    document.getElementById('txtuseridcode').disabled = false;
    document.getElementById('txtmachinename').disabled = false;
    document.getElementById('txtmachineip').disabled = false;
    document.getElementById('txtmacid').disabled = false;
    document.getElementById('txtremark').disabled = false;
    document.getElementById('txtlocation').disabled = false;
    document.getElementById('txtuseridname').value = "";
    document.getElementById('txtuseridcode').value = "";
    document.getElementById('txtmachinename').value = "";
    document.getElementById('txtmachineip').value = "";
    document.getElementById('txtmacid').value = "";
    document.getElementById('txtremark').value = "";
    document.getElementById('txtlocation').value = "";
    setButtonImages();
    return false;
}


function atmExecuteclick(querytype) {
    var compname = document.getElementById('hiddcompname').value;
    var compcode = document.getElementById('hiddencomcode').value;
    document.getElementById('txtcompname').disabled = true;
    document.getElementById('txtcompcode').disabled = true;
    var username = document.getElementById('txtuseridname').value;
    var usercode = document.getElementById('txtuseridcode').value;
//    if (usercode == "")
//     {
//        alert("Please Select User Name By F2");
//        document.getElementById('txtuseridname').focus();
//        return false;
//    }
      var machinename = document.getElementById('txtmachinename').value;
      var machineip = document.getElementById('txtmachineip').value;
      var macid = document.getElementById('txtmacid').value;
      var remark = document.getElementById('txtremark').value;
      var location = document.getElementById('txtlocation').value;
      if (querytype == "execute")
       {
        advtmac_id.atmexecute(compcode, usercode, machinename, machineip, macid, remark, location, checkcall1);
      } else 
      {
      advtmac_id.atmexecute(compcode, usercode, machinename, machineip, macid, remark, location, callbackview);
      
      document.getElementById('Td14').style.display ='block';
             document.getElementById('view19').style.display ='block';
             
      document.getElementById('Button4').disabled = true;
  }
  document.getElementById('txtfirstname').disabled = true;
  document.getElementById('txtlastname').disabled = true;
  document.getElementById('txtbranchname').disabled = true;
      
      document.getElementById('txtuseridname').disabled = true;
      document.getElementById('txtuseridcode').disabled = true;
      document.getElementById('txtmachinename').disabled = true;
      document.getElementById('txtmachineip').disabled = true;
      document.getElementById('txtmacid').disabled = true;
      document.getElementById('txtremark').disabled = true;
      document.getElementById('txtlocation').disabled = true;
      document.getElementById('btnfirst').disabled = true;
      document.getElementById('btnprevious').disabled = true;
      document.getElementById('btnnext').disabled = false;
      document.getElementById('btnlast').disabled = false;
      document.getElementById('btnModify').disabled = false;
      document.getElementById('btnDelete').disabled = false;
      
    return false;
}

var row_count = 0;
function callbackview(res) 
{
var hdsview="";
var j=1
ds = res.value;
    if (ds == null) {
        alert("Your search can not produce any result..")
        document.getElementById('Button4').disabled = true;
         document.getElementById('Button4').style.display ='none';
       return false;
    }
    else 
    {
        row_count = ds.Tables[0].Rows.length;
        hdsview += "<table Width='600px' style='border:1px solid #7DAAE3;margin-top:1px;margin-bottom:1px;margin-left:4px;' cellpadding='0' cellspacing='0'>"  
        if (row_count > 0)
         {
             for (var i = 0; i < row_count; i++)
             { 
                     hdsview+="<tr>"
                     hdsview+="<td width='50px'align='center' style='border:1px solid #7DAAE3;padding-right:2px;' align='right'>"
                     hdsview+="<font style='font-size:10px;font-weight:bold;vertical-align:right;padding-top:4px;padding-bottom:2px; text-align:right;'>"+j;"</font>"
                     hdsview+="</td>"

                     var ds_view_name = ds.Tables[0].Rows[i].USER_ID
			         if(ds_view_name!=null)
		             {
		                 hdsview += "<td id=tdGroup_" + j + " width='50px' align='right'  style='border:1px solid #7DAAE3;' >"
                     hdsview += "<font class='clickFieldinGrid'align='right' >" + ds.Tables[0].Rows[i].USER_ID + "</font>"
                     hdsview+="</td>"
                     }
                      else
                      {
                          hdsview += "<td width='50px' align='right' style='border:1px solid #7DAAE3;padding-right:2px;'>&nbsp;"
                             hdsview+="</td>"
                      }
                      var ds_view_str = ds.Tables[0].Rows[i].USER_NAME
			         if(ds_view_str!=null)
		             {
		                 hdsview += "<td width='100px' align='left'  style='border:1px solid #7DAAE3;padding-left:2px;' onclick='javascript:return getDataInHeader(this.id);'>"
		             hdsview += "<font class='gridview'   >" + ds.Tables[0].Rows[i].USER_NAME + "</font>"
                     hdsview+="</td>"
                     }
                     else
                      {
                          hdsview += "<td width='100px' style='border:1px solid #7DAAE3;padding-left:2px;'>&nbsp;"
                             hdsview+="</td>"
                      } 
                     var ds_views_str=ds.Tables[0].Rows[i].MACHINE_NAME
			         if(ds_views_str!=null)
		             {
		                 hdsview += "<td width='150px' align='left'  style='border:1px solid #7DAAE3;padding-left:2px;'>"
                     hdsview+="<font class='gridview' >"+ds.Tables[0].Rows[i].MACHINE_NAME+"</font>"
                     hdsview+="</td>"
                     }
                     else
                      {
                          hdsview += "<td width='150px' style='border:1px solid #7DAAE3;padding-left:2px;'>&nbsp;"
                             hdsview+="</td>"
                      } 
                     var ds_views_str=ds.Tables[0].Rows[i].MACHINE_IP
                     if(ds_views_str!=null)
		             {
		                 hdsview += "<td width='100px' align='left' style='border:1px solid #7DAAE3;padding-left:2px;'>"
                         hdsview+="<font class='gridview' >"+ds.Tables[0].Rows[i].MACHINE_IP+"</font>"
                         hdsview+="</td>"
                     }
                    else
                      {
                          hdsview += "<td width='100px' style='border:1px solid #7DAAE3;padding-left:2px;'>&nbsp;"
                             hdsview+="</td>"
                      } 
                      var ds_views_str=ds.Tables[0].Rows[i].MACHINE_MAC_ADDR
                     if(ds_views_str!=null)
		             {
		                 hdsview += "<td width='150px' align='left' style='border:1px solid #7DAAE3;padding-left:2px;'>"
                         hdsview+="<font class='gridview' >"+ds.Tables[0].Rows[i].MACHINE_MAC_ADDR+"</font>"
                         hdsview+="</td>" 
                     }
                      else
                      {
                          hdsview += "<td width='150px' style='border:1px solid #7DAAE3;padding-left:2px;'>&nbsp;"
                             hdsview+="</td>"
                      }
                     hdsview+="</tr>"
                     document.getElementById('view19').innerHTML = hdsview;  
			         j++
                  }
                   hdsview+="</table>"
        } 
		else
         {
			 hdsview+="<table width='600px;'>"
             hdsview+="<tr>"
             hdsview += "<td width='600px'>"
             hdsview+="<font Style='font-family:arial;font-weight:bold;font-size:18px;'>You have no detail </font></strong>"
             hdsview+="</td>"
    		 hdsview+="</tr>"
             hdsview+="</table>"
             hdsview =hdsview+ "<BR>"
             document.getElementById('view19').innerHTML = hdsview;  
			 return false;
            }   
        }    
    }

function getDataInHeader(tdID)
{
}

function checkcall1(response) {
    ds = response.value;
    if (ds.Tables[0].Rows.length <= 0) {
        alert("Your search can't produce any result");
        atmCancelclick('advtmac_id');
        return false;
    }
    else {
        dsexecute = response.value;



        document.getElementById('txtcompname').value = document.getElementById('hiddcompname').value;
        document.getElementById('txtcompcode').value = document.getElementById('hiddencomcode').value;
        document.getElementById('txtcompname').disabled = true;
        document.getElementById('txtcompcode').disabled = true;

        document.getElementById('txtuseridname').value = dsexecute.Tables[0].Rows[0].USER_NAME;
        document.getElementById('txtuseridcode').value = dsexecute.Tables[0].Rows[0].USER_ID;
        document.getElementById('txtmachinename').value = dsexecute.Tables[0].Rows[0].MACHINE_NAME;
        document.getElementById('txtmachineip').value = dsexecute.Tables[0].Rows[0].MACHINE_IP;
        document.getElementById('txtmacid').value = dsexecute.Tables[0].Rows[0].MACHINE_MAC_ADDR;
        document.getElementById('txtremark').value = dsexecute.Tables[0].Rows[0].REMARKS;
        document.getElementById('txtlocation').value = dsexecute.Tables[0].Rows[0].LOCATION;
        
        if (dsexecute.Tables[0].Rows.length == 1) {
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnlast').disabled = true;
        }
        if (z == 0) {
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnprevious').disabled = true;
        }
        if (z == dsexecute.Tables[0].Rows.length - 1) {
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnlast').disabled = true;
        }
        setButtonImages();
        return false;
    }
}


function atmModifyclick() {
    mflag="U";
    document.getElementById('txtcompname').value = document.getElementById('hiddcompname').value;
    document.getElementById('txtcompcode').value = document.getElementById('hiddencomcode').value;
    document.getElementById('txtcompname').disabled = true;
    document.getElementById('txtcompcode').disabled = true;

    document.getElementById('txtuseridname').disabled = true;
    document.getElementById('txtuseridcode').disabled = true;
    document.getElementById('txtmachinename').disabled = false;
    document.getElementById('txtmachineip').disabled = false;
    document.getElementById('txtmacid').disabled = false;
    document.getElementById('txtremark').disabled = false;
    document.getElementById('txtlocation').disabled = false;
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnCancel').disabled = false;
    document.getElementById('btnDelete').disabled = true;
    var extra3="U";
    setButtonImages();
    return false;
}


function atmfirstclick() {
    z = 0;

    document.getElementById('txtcompname').value = document.getElementById('hiddcompname').value;
    document.getElementById('txtcompcode').value = document.getElementById('hiddencomcode').value;
    document.getElementById('txtcompname').disabled = true;
    document.getElementById('txtcompcode').disabled = true;

    document.getElementById('txtuseridname').value = dsexecute.Tables[0].Rows[0].USER_NAME;
    document.getElementById('txtuseridcode').value = dsexecute.Tables[0].Rows[0].USER_ID;
    document.getElementById('txtmachinename').value = dsexecute.Tables[0].Rows[0].MACHINE_NAME;
    document.getElementById('txtmachineip').value = dsexecute.Tables[0].Rows[0].MACHINE_IP;
    document.getElementById('txtmacid').value = dsexecute.Tables[0].Rows[0].MACHINE_MAC_ADDR;
    document.getElementById('txtremark').value = dsexecute.Tables[0].Rows[0].REMARKS;
    document.getElementById('txtlocation').value = dsexecute.Tables[0].Rows[0].LOCATION;
    document.getElementById('btnnext').disabled = false;
    document.getElementById('btnlast').disabled = false;
    document.getElementById('btnfirst').disabled = true;
    document.getElementById('btnprevious').disabled = true;
    setButtonImages();
    return false;
}



function atmpreviousclick() {
    z--;

    var x = dsexecute.Tables[0].Rows.length;


    if (z > x) {
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        return false;
    }
    if (z != -1 && z >= 0) {
        if (dsexecute.Tables[0].Rows.length != z) {
            document.getElementById('txtuseridname').value = dsexecute.Tables[0].Rows[z].USER_NAME;
            document.getElementById('txtuseridcode').value = dsexecute.Tables[0].Rows[z].USER_ID;
            document.getElementById('txtmachinename').value = dsexecute.Tables[0].Rows[z].MACHINE_NAME;
            document.getElementById('txtmachineip').value = dsexecute.Tables[0].Rows[z].MACHINE_IP;
            document.getElementById('txtmacid').value = dsexecute.Tables[0].Rows[z].MACHINE_MAC_ADDR;
            document.getElementById('txtremark').value = dsexecute.Tables[0].Rows[z].REMARKS;
            document.getElementById('txtlocation').value = dsexecute.Tables[0].Rows[z].LOCATION;

            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnprevious').disabled = false;
            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnlast').disabled = false;

        }
        else {
            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnlast').disabled = false;
            document.getElementById('btnfirst').disabled = true;
            document.getElementById('btnprevious').disabled = true;
            return false;
        }
    }
    else {
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnlast').disabled = false;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        return false;
    }


    if (z <= 0) {
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = false;
        document.getElementById('btnlast').disabled = false;
       // setButtonImages();
        return false;
    }
   setButtonImages();
    return false;

}



function atmnextclick() {
    z++;
    //ds=response.value;
    var x = dsexecute.Tables[0].Rows.length;
    if (z <= x && z >= 0) {
        if (dsexecute.Tables[0].Rows.length != z && z != -1) {
            document.getElementById('txtuseridname').value = dsexecute.Tables[0].Rows[z].USER_NAME;
            document.getElementById('txtuseridcode').value = dsexecute.Tables[0].Rows[z].USER_ID;
            document.getElementById('txtmachinename').value = dsexecute.Tables[0].Rows[z].MACHINE_NAME;
            document.getElementById('txtmachineip').value = dsexecute.Tables[0].Rows[z].MACHINE_IP;
            document.getElementById('txtmacid').value = dsexecute.Tables[0].Rows[z].MACHINE_MAC_ADDR;
            document.getElementById('txtremark').value = dsexecute.Tables[0].Rows[z].REMARKS;
            document.getElementById('txtlocation').value = dsexecute.Tables[0].Rows[z].LOCATION;
            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnprevious').disabled = false;
            document.getElementById('btnnext').disabled = false;
            document.getElementById('btnlast').disabled = false;

        }
        else {
            document.getElementById('btnfirst').disabled = false;
            document.getElementById('btnprevious').disabled = false;
            document.getElementById('btnnext').disabled = true;
            document.getElementById('btnlast').disabled = true;
            return false;
        }
    }
    else {
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        return false;
    }

    if (z == x - 1) {
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnfirst').disabled = false;
        document.getElementById('btnprevious').disabled = false;
    }
    setButtonImages();
    return false;
}



function atmlastclick() {
    //ds= response.value;
    var x = dsexecute.Tables[0].Rows.length;
    z = x - 1;
    x = x - 1;

    document.getElementById('txtuseridname').value = dsexecute.Tables[0].Rows[x].USER_NAME;
    document.getElementById('txtuseridcode').value = dsexecute.Tables[0].Rows[x].USER_ID;
    document.getElementById('txtmachinename').value = dsexecute.Tables[0].Rows[x].MACHINE_NAME;
    document.getElementById('txtmachineip').value = dsexecute.Tables[0].Rows[x].MACHINE_IP;
    document.getElementById('txtmacid').value = dsexecute.Tables[0].Rows[x].MACHINE_MAC_ADDR;
    document.getElementById('txtremark').value = dsexecute.Tables[0].Rows[x].REMARKS;
    document.getElementById('txtlocation').value = dsexecute.Tables[0].Rows[x].LOCATION;
    document.getElementById('btnnext').disabled = true;
    document.getElementById('btnlast').disabled = true;
    document.getElementById('btnfirst').disabled = false;
    document.getElementById('btnprevious').disabled = false;
    setButtonImages();
    return false;
}



function setButtonImages() {
    if (document.getElementById('btnNew').disabled == true)
        document.getElementById('btnNew').src = "btimages/new-off.jpg";
    else
        document.getElementById('btnNew').src = "btimages/new.jpg";

    if (document.getElementById('btnSave').disabled == true)
        document.getElementById('btnSave').src = "btimages/save-off.jpg";
    else
        document.getElementById('btnSave').src = "btimages/save.jpg";

    if (document.getElementById('btnModify').disabled == true)
        document.getElementById('btnModify').src = "btimages/modify-off.jpg";
    else
        document.getElementById('btnModify').src = "btimages/modify.jpg";

    if (document.getElementById('btnQuery').disabled == true)
        document.getElementById('btnQuery').src = "btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src = "btimages/query.jpg";

    if (document.getElementById('btnExecute').disabled == true)
        document.getElementById('btnExecute').src = "btimages/execute-off.jpg";
    else
        document.getElementById('btnExecute').src = "btimages/execute.jpg";

    if (document.getElementById('btnCancel').disabled == true)
        document.getElementById('btnCancel').src = "btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src = "btimages/clear.jpg";

    if (document.getElementById('btnfirst').disabled == true)
        document.getElementById('btnfirst').src = "btimages/first-off.jpg";
    else
        document.getElementById('btnfirst').src = "btimages/first.jpg";

    if (document.getElementById('btnprevious').disabled == true)
        document.getElementById('btnprevious').src = "btimages/previous-off.jpg";
    else
        document.getElementById('btnprevious').src = "btimages/previous.jpg";

    if (document.getElementById('btnnext').disabled == true)
        document.getElementById('btnnext').src = "btimages/next-off.jpg";
    else
        document.getElementById('btnnext').src = "btimages/next.jpg";

    if (document.getElementById('btnlast').disabled == true)
        document.getElementById('btnlast').src = "btimages/last-off.jpg";
    else
        document.getElementById('btnlast').src = "btimages/last.jpg";

    if (document.getElementById('btnDelete').disabled == true)
        document.getElementById('btnDelete').src = "btimages/delete-off.jpg";
    else
        document.getElementById('btnDelete').src = "btimages/delete.jpg";

    if (document.getElementById('btnExit').disabled == true)
        document.getElementById('btnExit').src = "btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src = "btimages/exit.jpg";
}






 function Delete_Record()
{

            document.getElementById('Td14').style.display = 'none';
            document.getElementById('view19').style.display = 'none';
            document.getElementById('Button4').disabled= true;

            document.getElementById('txtcompname').value = document.getElementById('hiddcompname').value;
            var compcode = document.getElementById('hiddencomcode').value;
            var username = document.getElementById('txtuseridname').value;
            var userid = document.getElementById('txtuseridcode').value;

            boolReturn = confirm("Are you sure you wish to delete this?");
            
            
            
            var machinename = document.getElementById('txtmachinename').value;
            var machineip = document.getElementById('txtmachineip').value;
            var macip = document.getElementById('txtmacid').value;
            var remark = document.getElementById('txtremark').value;
            var location = document.getElementById('txtlocation').value;
            if (boolReturn == 1) {
                var result = advtmac_id.datadelete(compcode, username, userid, machinename, machineip, macip, remark, location);





                alert("Data delete successfully")
                atmCancelclick('advtmac_id');


            }
            else {
                return false;
            }
      }