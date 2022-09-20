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
        document.getElementById('head').style.display = 'block';
        document.getElementById('scroll_1').style.display = 'block';

        var result1 = "";
        var result2 = "";
        var userid = document.getElementById('hdnuserid').value;
        var center = document.getElementById('hdnunitcode').value;
        var aa = cngbranch.Getdata(userid, center)
        ds_table = aa.value;

        
        if (ds_table.Tables[0].Rows.length > 0) {

            result1 += "<table  id='table-header1' cellpadding='0' cellspacing='0'>";
            result1 += "<tr><th   bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Branch Name</th>"
            result1 += "<th bgcolor=#7DAAE3 style='font-size:10px;font-weight:bold;text-align:center;border:1px solid #7DAAE3;'>Branch Code</th>"
            result1 += "</tr>";
            result1 += "</table>";
            document.getElementById('table_header1').style.width = '800px';
            document.getElementById('head').innerHTML = result1.toString();
            for (var i = 0; i <= ds_table.Tables[0].Rows.length - 1; i++) {
                result2 += "<tr><td style='border:1px solid #7DAAE3; text-align=center;font-size:12px;' ><font  text-align='left' ><input id=rdo_" + i + " type=radio name=cngcom >" + ds_table.Tables[0].Rows[i].Branch_Name + "</font></td>";
                result2 += "<td style='border:1px solid #7DAAE3; text-align=center;font-size:12px;' ><font  text-align='left' >" + ds_table.Tables[0].Rows[i].Branch_Code + "</font></td></tr>";
               
            }
            result2 += "</table>";
            
            var sttemp = "<TABLE runat='server' id='table_body' cellSpacing=0 cellPadding=0>";
            document.getElementById('scroll_1').innerHTML = sttemp + result2.toString();
            //alert(document.getElementById('scroll_1').innerHTML)
            document.getElementById('table_body').style.width = '800px';
            fix1();

        }


    }
}


function submitnew_branch123() {

    var newcomcode = ""
    var newcomname = ""
    for (i = 0; i < document.getElementById("scroll_1").childNodes[0].childNodes[0].children.length-1; i++) {
       
        if (document.getElementById('rdo_'+ i).checked == true) {

            if (browser != "Microsoft Internet Explorer") {
                newcomcode = document.getElementById("scroll_1").childNodes[0].childNodes[0].childNodes[i].childNodes[1].textContent
                newcomname = document.getElementById("scroll_1").childNodes[0].childNodes[0].childNodes[i].childNodes[0].textContent
            }
            else {

                newcomcode = document.getElementById("scroll_1").childNodes[0].childNodes[0].childNodes[i].childNodes[1].innerText
                newcomname = document.getElementById("scroll_1").childNodes[0].childNodes[0].childNodes[i].childNodes[0].innerText
                break;

            }
        }
    }
    var aa = cngbranch.changeBRANCH(newcomcode, newcomname)
    alert("You have successfully changed your Branch")
    window.location.href = "default.aspx";
}


function closeme() {
    if (confirm("Do you want to skip this page")) {
        window.close();
        return false;
    }
    return false;
}

function submitnew_branch() {
    var newcomcode = ""
    var newcomname = ""
    for (i = 1; i < document.getElementById("result").childNodes[0].childNodes[0].children.length - 1; i++) {
        if (document.getElementById("result").childNodes[0].childNodes[0].childNodes[i].childNodes[0].childNodes[0].checked == true) {


            if (browser != "Microsoft Internet Explorer") {
                newcomcode = document.getElementById("result").childNodes[0].childNodes[0].childNodes[i].childNodes[1].textContent
                newcomname = document.getElementById("result").childNodes[0].childNodes[0].childNodes[i].childNodes[0].textContent
            }
            else {

                newcomcode = document.getElementById("result").childNodes[0].childNodes[0].childNodes[i].childNodes[1].innerText
                newcomname = document.getElementById("result").childNodes[0].childNodes[0].childNodes[i].childNodes[0].innerText
                break;

            }
        }
    }
    var aa = cngbranch.changeBRANCH(newcomcode, newcomname)
    alert("You have successfully changed your Branch")
    window.location.href = "default.aspx";
}