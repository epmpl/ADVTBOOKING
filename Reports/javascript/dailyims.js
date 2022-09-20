 function cleardata()
    {
   
    document.getElementById('txtarea').value="";
    document.getElementById('txtfromdate').value="";
    document.getElementById('txttodate').value="";
    document.getElementById('drpadtype').value="0";
 document.getElementById('drpdestination').value="0";
     document.getElementById('dppubcent').value="0";
      document.getElementById('drpuom').value="0";
     return false;
    }
    
     function exit() {
        if (confirm("Do you want to skip this page ?")) {
            window.close();
            return false;
        }
        return false;


    }
    function sub()
    {
    if(document.getElementById('drpadtype').value=="0"||document.getElementById('drpadtype').value=="")
    {
    alert("Please Select Ad-Type")
    document.getElementById('drpadtype').focus();
    return false;
    }
    if(document.getElementById('txtfromdate').value=="")
    {
    alert("Please Select From Date")
    document.getElementById('txtfromdate').focus();
    return false;
    }
    if(document.getElementById('txttodate').value=="")
    {
    alert("Please Select To Date")
    document.getElementById('txttodate').focus();
    return false;
}
document.getElementById('hiddenedition').value = document.getElementById('dpedition').value;
document.getElementById('hiddensupp').value = document.getElementById('dpsuppliment12').value;
  if(document.getElementById('drpadtype').value=="CL0")
  {
  if( document.getElementById('drpuom').value=="0"||document.getElementById('drpuom').value=="")
  {
   alert("Please Select UOM")
    document.getElementById('drpuom').focus();
    return false;
}

var des = document.getElementById('dpedition').options.selectedIndex;
if (des != -1)
    document.getElementById('hiddeneditionname').value = document.getElementById('dpedition').options[des].text;
  }

}

////////////////////////////bined edition,publication ///////////////////
function bind_edition4() {
    var comp_code = document.getElementById('hiddencompcode').value;
    var pub_cent = "";
    var publication = document.getElementById('dppub1').value;

    Reports_dailymis.edition_bind(publication, pub_cent, comp_code, call_bind_edition);
}


function suppforstatus() {
    var compcode = document.getElementById('hiddencompcode').value;
    var userid = document.getElementById('hiddenuserid').value;
    var edition = document.getElementById('dpedition').value;
    Reports_dailymis.bindsupp(compcode, userid, edition, call_suppforstatus);
    return false;
}
function call_suppforstatus(response) {
    var ds = response.value;
    // var pkgitem = document.getElementById("dpsuppliment"); 
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById('dpsuppliment12');
        pkgitem.options[0] = new Option("---Select Supplement---", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < response.value.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(response.value.Tables[0].Rows[i].supplement, response.value.Tables[0].Rows[i].supp_code);
            pkgitem.options.length;
        }
    }
    return false;
}
function call_bind_edition(response) {
    ds = response.value;
    var edition = document.getElementById('dpedition');
    edition.options.length = 0;
    edition.options[0] = new Option("--Select Edition Name--");
    document.getElementById("dpedition").options.length = 1;
    if (ds != null && ds.Tables.length > 0) {
        for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
            edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Edition_alias, ds.Tables[0].Rows[i].edition_code);
            edition.options.length;
        }

    }
    return false
}
    