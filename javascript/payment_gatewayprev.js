var browser = navigator.appName;
var cityvar;
var country = "";

function ClientEmailCheck(val) {
    var theurl = document.getElementById('txtemail').value;

    if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById('txtemail').value == "") {
        return (true)
    }
    alert("Invalid E-mail address! Please re-enter.")
    document.getElementById('txtemail').value = "";
    document.getElementById('txtemail').focus();
    return false;
}
function addcount(cou) {


    if (typeof (cou) == "object") {
        var country = cou.value;
    }
    else {
        var country = cou;
    }
    if (country != "0") {
        payment_gatewayprev.addcou(country, callcount);
    }
    else {
        document.getElementById("drpcity").options.length = 1;
    }
    return false;
}

function callcount(res) {

    var ds = res.value;
    var pkgitem = document.getElementById("drpcity");
    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        pkgitem.options.length = 1;
        pkgitem.options[0] = new Option("--Select City--", "0");
        for (var i = 0; i < res.value.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name, res.value.Tables[0].Rows[i].City_Code);

            pkgitem.options.length;

        }
        if (cityvar == undefined || cityvar == "") {
            document.getElementById('drpcity').value = "0";

        }
        else {
            document.getElementById('drpcity').value = cityvar;
            // addregcity();
            cityvar = "";
        }
    }
    else {

        pkgitem.options.length = 1;
        pkgitem.options[0] = new Option("--Select City--", "0");
        //  addregcity();
        document.getElementById('drpcity').value = "0";

        return false;

    }

    return false;
}

function submitdata() {


    if (document.getElementById("txtcountry").value == "" || document.getElementById("txtcountry").value == "0") {
        alert(" Please Select Country");
        document.getElementById("txtcountry").focus();
        return false;
    }
    if (document.getElementById("drpcity").value == "" || document.getElementById("drpcity").value == "0") {
        alert(" Please Select City");
        document.getElementById("drpcity").focus();
        return false;
    }
    if (document.getElementById("txtemail").value == "") {
        alert(" Please Enter EmailId");
        document.getElementById("txtemail").focus();
        return false;
    }
    if (document.getElementById("txtadres").value == "") {
        alert(" Please Enter Address");
        document.getElementById("txtadres").focus();
        return false;
    }
    //  document.getElementById("hdncontry").value = document.getElementById("txtcountry").value;
    document.getElementById("hdnpincode").value = document.getElementById("txtpincode").value;
    document.getElementById("hdncity").value = document.getElementById("drpcity").value;
    document.getElementById("hdnmail").value = document.getElementById("txtemail").value;
    document.getElementById("hdnadress").value = document.getElementById("txtadres").value;
    if (document.getElementById("chek1").checked == true) {
    }
    else {
        alert('Please check the checkbox');
        return false;
    }
}