var browser = navigator.appName;
var ds_new = "";

function pagerefresh() {
    if (document.getElementById("hdn_user_right").value == "0" || document.getElementById("hdn_user_right").value == "") {
         alert("You are not Authorized to see this form")
       window.close();
        return false;
    }
    else {
    }
}

    function closeme() {
        if (confirm("Do you want to skip this page")) {
            window.close();
            return false;
        }
        return false;
    }
    
    function chk_branch(id) {
    //var k=id.split("_")
        // var res = CngPrintingCenter.branch_chk(document.getElementById('prin_code_'+k[1]).value,document.getElementById('hdnuserid').value)
        var k = id.split("_")
       
        var res = "";
      
        if (browser != "Microsoft Internet Explorer") {
            res = CngPrintingCenter.branch_chk(document.getElementById('prin_code_' + k[1]).innerHTML, document.getElementById('hdnuserid').value)
        }
        else {
            res = CngPrintingCenter.branch_chk(document.getElementById('prin_code_' + k[1]).value, document.getElementById('hdnuserid').value)
        }

        ds_new = res.value;
        var flag = "";
        if (ds_new.Tables[0].Rows.length > 0) {
            for (var l = 0; l < ds_new.Tables[0].Rows.length; l++) {
                if (document.getElementById('hdnbranch').value == ds_new.Tables[0].Rows[l].Branch_Code) {
                    flag = 1;
                }
            }

            if (flag != 1) {
                alert("Please Change The Branch Too!");
                branch_display();
                return false;
            }
        }
        else {
            alert('No Branch have Permission For The Selected Printing Center.Please Select Valid Printing Center!')
            return false;
        }
        return false;
    }

    function branch_display() {
    var result="";
        if (ds_new.Tables[0].Rows.length > 0) {
            result = "<div align='right'  style=overflow:auto;height:200px;width:300px><table align='left' border=0>";
            result += "<tr>"
            result += "<td   bgcolor=#7DAAE3 style='font-size:15px;text-align:center;border:1px solid #7DAAE3;width:10%;'>Select</td>"
            result += "<td   bgcolor=#7DAAE3 style='font-size:15px;;text-align:center;border:1px solid #7DAAE3;width:40%;'>Branch Code</td>"
            result += "<td   bgcolor=#7DAAE3 style='font-size:15px;text-align:center;border:1px solid #7DAAE3;width:50%;'>Branch Name</td>"
            result += "</tr>";
            for (var m = 0; m < ds_new.Tables[0].Rows.length; m++) {
                result += "<tr>";
                result += "<td class=LblText style='text-align:left;'><input id=rdob_" + m + " type=radio name=cngcent></td>";
                result += "<td class=LblText id=bran_code_" + m + " value=" + ds_new.Tables[0].Rows[m].Branch_Code.toString() + ">" + ds_new.Tables[0].Rows[m].Branch_Code.toString() + "</td>";
                result += "<td class=LblText>" + ds_new.Tables[0].Rows[m].Branch_Name.toString() + "</td>";
                result += "</tr>";
            }
            result += "</table></div>";

            document.getElementById('getbranch').innerHTML = result;
        }
        return false;
    }

    function submitnew_company() {
        var newprintingcentercode = "";
        var newprintingcentername = "";
        var newbranchcode = "";
        var newbranchname = "";
        for (var i = 1; i <= document.getElementById("result").childNodes[0].childNodes[0].childNodes[0].children.length - 1; i++) {
            if (document.getElementById("result").childNodes[0].childNodes[0].childNodes[0].childNodes[i].childNodes[0].childNodes[0].checked == true) {
                newprintingcentercode = document.getElementById("result").childNodes[0].childNodes[0].childNodes[0].childNodes[i].childNodes[1].childNodes[0].nodeValue
                newprintingcentername = document.getElementById("result").childNodes[0].childNodes[0].childNodes[0].childNodes[i].childNodes[2].childNodes[0].nodeValue
                break;
            }
        }
        if (document.getElementById("getbranch").childNodes.length > 0) {
            for (var x = 1; x <= document.getElementById("getbranch").childNodes[0].childNodes[0].childNodes[0].children.length - 1; x++) {
                if (document.getElementById("getbranch").childNodes[0].childNodes[0].childNodes[0].childNodes[x].childNodes[0].childNodes[0].checked == true) {
                    newbranchcode = document.getElementById("getbranch").childNodes[0].childNodes[0].childNodes[0].childNodes[x].childNodes[1].childNodes[0].nodeValue
                    newbranchname = document.getElementById("getbranch").childNodes[0].childNodes[0].childNodes[0].childNodes[x].childNodes[2].childNodes[0].nodeValue
                    break;
                }
            }
        }

        if (newprintingcentercode == "") {
            alert("Please Select Printing Center!")
            return false;
        }

        if (document.getElementById("getbranch").childNodes.length > 0) {
            if (newbranchcode == "") {
                alert("Please Select Branch!")
                return false;
            }
        }
        
        var aa = CngPrintingCenter.changeprintingcenter(newprintingcentercode, newprintingcentername, newbranchcode, newbranchname)
        alert("You have successfully changed your company")
        window.location.href = "Default.aspx";

    }