var brow_ver = 8;
var browser = navigator.appName;
var browser_info = window.navigator.userAgent;
var report = 0
var _delagency_error = "";
var flag_rsupply = 0;
var _old_sustype = "";
var _old_susdt = "";
var _old_suspend = "";
var replacevalue_g = "";
var _flg_exp_tab = false;
var _flg_cont_tab = false;
var _flg_sup_tab = false;
var _flg_bank_tab = false;
var _flg_remark_tab = false;
var _flg_credit_tab = false;
var abccity = "";
var deletedval = 0;
var agencycode = "";
var subagcode = "";
var replacevalue = ""
var replacevaluecons = ""
var dsexec = "";
var expds = "";
var fndnextval = 0;
var exec_con = "";
var dsexp = "";
var exec_supp = ""
var modify = "False";
var modifydate = "No";
var getexpname_len = "0";
var getexpcode_len = "0"
var getexpfreq_len = "0"
var getexpflag_len = "0"
var getexpsuptyp_len = "0"
var getexpcreditth_len = "0"
var cityval = "";
var cityval_ABC = "";
var cityname_ABC = ""
var distval = ""
var stateval = ""
var countryval = ""
var cityname = ""
var distname = ""
var statename = ""
var countryname = ""
var talukcode = "";
var exectefuncol = "";
var exectefunvalue = "";
var exectefuntab = "";
var fill_con_role = "";
var race_code = "";
var expub_code = ""
var exedtn_code = ""
var exsubedtn_code = ""
var cityval2 = ""
var cityval3 = ""
var distval2 = ""
var stateval2 = ""
var countryval2 = ""
var talukcode2 = ""
var replaceremarkvalue = ""
var xmlDoc = null;
var xmlDoc1 = null;
var xmlObj = null;
var xmlObj_sup = null;

var req = null;
var req1 = null;
var focsflg = "F"
var exc = ""
// add some variables for fast update
var lblpersonaltab = false;
var lblagencytab = false;
var lblbillingtab = false;
var lblExpencestab = false;
var lblcontactpersonstab = false;
var lblsupplydetailstab = false;
var lblSecurity = false;
var lblbankguarantee = false;
var lblmultiremarkalert = false;
var lblcredit = false;
function pagerefresh() {
    if (document.getElementById("hdn_user_right").value == "0" || document.getElementById("hdn_user_right").value == "") {
        alert("You are not Authorized to see this form")
        window.close();
        return false;
    }
    else {
    }
}

/////////
function submitnew_company() {
    if (browser == "Microsoft Internet Explorer") {
        var b_version = navigator.appVersion;
        //    var version = parseFloat(b_version);
        var vers = b_version.split("(");
        var vers1 = vers[1].split(";");
        var vers2 = vers1[1].split(" ")
        var vers3 = vers2[2].split(".")
        var version = vers3[0];
        //alert(version);

        var newcomcode = ""
        var newcomname = ""
        if (version == 9) {
            for (i = 1; i <= document.getElementById("result").childNodes[0].childNodes[0].children.length - 1; i++) {
                if (document.getElementById("result").childNodes[0].childNodes[0].childNodes[i].childNodes[0].childNodes[0].checked == true) {
                    newcomcode = document.getElementById("result").childNodes[0].childNodes[0].childNodes[i].childNodes[1].childNodes[0].nodeValue
                    newcomname = document.getElementById("result").childNodes[0].childNodes[0].childNodes[i].childNodes[2].childNodes[0].nodeValue
                    break;
                }
            }
        }
        else {
            for (i = 1; i < document.getElementById("result").childNodes[0].childNodes[0].children.length - 1; i++) {
                if (document.getElementById("result").childNodes[0].childNodes[0].childNodes[i].childNodes[0].childNodes[0].checked == true) {
                    newcomcode = document.getElementById("result").childNodes[0].childNodes[0].childNodes[i].childNodes[1].childNodes[0].nodeValue
                    newcomname = document.getElementById("result").childNodes[0].childNodes[0].childNodes[i].childNodes[2].childNodes[0].nodeValue
                    break;
                }
            }
        }
    }
    else if (browser != "Microsoft Internet Explorer") {
        var newcomcode = ""
        var newcomname = ""

        for (i = 1; i <= document.getElementById("result").childNodes[0].childNodes[0].children.length - 1; i++) {
            if (document.getElementById("result").childNodes[0].childNodes[0].childNodes[i].childNodes[0].childNodes[0].checked == true) {
                newcomcode = document.getElementById("result").childNodes[0].childNodes[0].childNodes[i].childNodes[1].childNodes[0].nodeValue
                newcomname = document.getElementById("result").childNodes[0].childNodes[0].childNodes[i].childNodes[2].childNodes[0].nodeValue
                break;
            }
        }
    }
    var aa = cngcompany.changecompany(newcomcode, newcomname)
    alert("You have successfully changed your company")
    window.location.href = "default.aspx";

}

function closeme() {
    if (confirm("Do you want to skip this page")) {
        window.close();
        return false;
    }
    return false;
}