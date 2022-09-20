var browser = navigator.appName;


function blankfield() {

    document.getElementById('drpbased').value = "B";


}



function adcat_bind() {
    var ad_type = document.getElementById('dpdadtype').value;
    var comp_code = document.getElementById('hiddencompcode').value;

    Reports_case_register_rep.bind_adcat(ad_type, comp_code, call_adcat_bind1);
    return false;
}

function call_adcat_bind1(response) {
    //var=ds;
    ds = response.value;

    var edition = document.getElementById('dpadcatgory');
    edition.options.length = 0;
    edition.options[0] = new Option("--Select Ad Cat--");
    edition.options[0].selected = true;
    document.getElementById("dpadcatgory").options.length = 1;

    for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
        edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name, ds.Tables[0].Rows[i].Adv_Cat_Code);
        edition.options.length;
    }



    return false;
}

function adcat_bind_deviation() {
    var ad_type = document.getElementById('dpdadtype').value;
    var comp_code = document.getElementById('hiddencompcode').value;

    Reports_case_register_rep.bind_adcat(ad_type, comp_code, call_adcat_bind);

}

function adsubcat_bind() {


    var ad_category = "";

    var sel = document.getElementById("dpadcatgory");
    var listLength = sel.options.length;
    for (var i = 1; i < listLength; i++) {
        if (document.getElementById("dpadcatgory").options[i].selected == true) {
            ad_category = ad_category + document.getElementById("dpadcatgory").options[i].value + ",";
        }

    }
    var ad_cat = ad_category.slice(0, -1);

    var comp_code = document.getElementById('hiddencompcode').value;
    Reports_case_register_rep.bind_adsubcat(comp_code, ad_cat, call_adsubcatbind);
    return false;

}

function call_adsubcatbind(response) {
    ds = response.value;
    var brand = document.getElementById('lstadsubcat');
    brand.options.length = 0;
    brand.options[0] = new Option("--Select AdSubCat--");
    document.getElementById("lstadsubcat").options.length = 1;


    if (ds.Tables[0].Rows.length > 0) {
        for (var i = 0; i < ds.Tables[0].Rows.length; i++) {
            brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Subcat_Name, ds.Tables[0].Rows[i].Adv_Subcat_Code);
            brand.options.length;
        }
    }

    return false;
}

function bind_edition13() {
 
    var comp_code = document.getElementById('hiddencompcode').value;
    var pub_cent = document.getElementById('dppubcent').value;
    var publication = document.getElementById('dppub1').value;
    Reports_case_register_rep.edition_bind(publication, pub_cent, comp_code, call_bind_edition);

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


function onclk_run() {
    var compcode = document.getElementById('hiddencompcode').value;
    var adtype = document.getElementById('dpdadtype').value;
    var adcategory = document.getElementById('dpadcatgory').value;
    var adsubcat = document.getElementById('lstadsubcat').value;
    var fromdate = document.getElementById('txtfrmdate').value;
    var todate = document.getElementById('txttodate1').value;
    var alrt;
    if (browser != "Microsoft Internet Explorer")
        alrt = document.getElementById('lbDateFrom').textContent;
    else
        alrt = document.getElementById('lbDateFrom').innerText;

    if (alrt.indexOf('*') >= 0) {
        if (document.getElementById('txtfrmdate').value == "" || document.getElementById('txtfrmdate').value == "0") {
            //alrt.Replace("*","");
            var abc = alrt.replace("*", "");
            alert('Please Enter ' + abc);
            document.getElementById('txtfrmdate').focus();
            return false;
        }
    }
    var alrt;
    if (browser != "Microsoft Internet Explorer")
        alrt = document.getElementById('lbToDate').textContent;
    else
        alrt = document.getElementById('lbToDate').innerText;

    if (alrt.indexOf('*') >= 0) {
        if (document.getElementById('txttodate1').value == "" || document.getElementById('txttodate1').value == "0") {
            //alrt.Replace("*","");
            var abc = alrt.replace("*", "");
            alert('Please Enter ' + abc);
            document.getElementById('txttodate1').focus();
            return false;
        }
    } 
    
    var publication = document.getElementById('dppub1').value;
    var pubcenter = document.getElementById('dppubcent').value;
    var edition = document.getElementById('dpedition').value;
    var printcent = document.getElementById('dpd_printcent').value;
    var branch = document.getElementById('dpd_branch').value;
    var userid = document.getElementById('drpuserid').value;
//    if (document.getElementById('drpuserid').value == "" || document.getElementById('drpuserid').value == "0") {
//        alert('Please Select User ID');
//        return false;
//    }
    
    var destination = document.getElementById('drpdest').value;
    var basedon = document.getElementById('drpbased').value;
    var pubname = document.getElementById('dppub1').options[document.getElementById('dppub1').selectedIndex].text

    if (pubname == "--Select Publication--") {
        pubname = "All";
    }
    else {
        pubname = pubname;
    }

    var editionname = edition;
    if (editionname == "") {
        editionname = "All";
    }
    else {
        editionname = document.getElementById('dpedition').options[document.getElementById('dpedition').selectedIndex].text;
    }

    window.open("case_register_rep_view.aspx?compcode=" + compcode + "&adtype=" + adtype + "&adcategory=" + adcategory + "&adsubcat=" + adsubcat + "&fromdate=" + fromdate + "&todate=" + todate + "&publication=" + publication + "&pubcenter=" + pubcenter + "&edition=" + edition + "&printcent=" + printcent + "&branch=" + branch + "&userid=" + userid + "&destination=" + destination + "&basedon=" + basedon + "&pubname=" + pubname + "&editionname=" + editionname);
    return false;    
}