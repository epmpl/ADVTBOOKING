function rePrint() {
   // alert("tt");
   // return false;
    var grid = document.getElementById('DataGrid1');
    var bookingid = "";
    var aa = document.getElementById('hdnlength').value;
    for (var j = 0; j < aa; j++) {


        if (document.getElementById('chkN' + j).checked == true) {

            bookid = document.getElementById('chkN' + j).value;
            bookingid += bookid + ",";
        }
    }
  //  alert(bookingid);
    printreceipt("", bookingid);
    return false;
}
function insertcashdetail() {
   
    var temp;
    var pp;
    var ro;
    if (document.getElementById('drppaymode').value == "0") {


        alert("Please Select Paymode");
        document.getElementById('drppaymode').focus();
        return false;
        
    }

    var aa = document.getElementById('hdnlength').value;

    for (var i = 0; i <aa; i++) {

        if (document.getElementById('chk' + i).checked == true) {
            bookid = document.getElementById('chk' + i).value;
            var res = cash_rcptformult.insertcashdetail(bookid);
            if (res.error != null) {
                alert(res.error.description);
            }
            temp = res.value.Tables[0].Rows[0].RECPTNO;

            updatercpt(temp);
            i = aa;
           // return false;
            
        }
       
     }
     document.getElementById('btnsubmit').click();

     document.getElementById('btnmodify').disabled = true;
     return false;
  
}


function updatercpt(temp) {
    var kk = 0;
    var bookingid = "";

    var crdmnth = document.getElementById('drpmonth').value;
    var crdyear = document.getElementById('drpyear').value;
    var crdname = document.getElementById('txtcardname').value;
    var crdtype = document.getElementById('drptype').value;
    var crdnumber = document.getElementById('txtcardno').value;
    var chkno = document.getElementById('ttextchqno').value;
    var chkdate = document.getElementById('ttextchqdate').value;
    var chkamt = document.getElementById('ttextchqamt').value;
    var chkbankname = document.getElementById('ttextbankname').value;


    var billamt=0;
    var grid = document.getElementById('DataGrid1');
    var aa = document.getElementById('hdnlength').value;
    for (var j = 0; j < aa; j++) {


        if (document.getElementById('chk' + j).checked == true) {

            billamt = billamt + parseFloat(grid.rows[j + 1].cells[7].innerHTML)
        
            kk = kk + 1;
            bookid = document.getElementById('chk' + j).value;
            ro = cash_rcptformult.updatero(document.getElementById('hiddencompcode').value, document.getElementById('drppaymode').value, bookid, temp, crdmnth, crdyear, crdname, crdtype, crdnumber, chkno, chkdate, chkamt, chkbankname);
              bookingid+=bookid + ",";
        }
    }


    document.getElementById('txtbillamt').value = billamt;

    document.getElementById('drppaymode').value = "0";

    document.getElementById('view').style.display = "none";

    document.getElementById('txtcashdiscount').value = "";
    document.getElementById('drpcashrecieved').value = "";
    document.getElementById('txtcardname').value = "";
    document.getElementById('drptype').value = "0";
    document.getElementById('drpmonth').value = "0";
    document.getElementById('drpyear').value = "0";

    document.getElementById('txtcardno').value = "";
    document.getElementById('ttextchqno').value = "";
    document.getElementById('ttextchqamt').value = "";

    document.getElementById('ttextchqdate').value = "";
    document.getElementById('ttextbankname').value = "";
  
    

    printreceipt(temp, bookingid);


  



    


    return false;
 
}






function executeclick(bookingid123) {


    var cioid = bookingid123;
    var compcode = document.getElementById('hiddencomcode').value;

    var userid = document.getElementById('hiddenuserid').value;
    var res = cash_rcptformult.checkreci(cioid, compcode, userid);
    ds = res.value;
    if (ds.Tables[0].Rows.length > 0) {
   

            cash_rcptformult.execute(cioid, document.getElementById('hiddencompcode').value, '', document.getElementById('hiddendateformat').value, exec_callback);
            document.getElementById('btnmodify').disabled = false;
            return false;
  
  
    }
    else {
        alert("Please Enter Right Booking Id");
        cleardata();
        document.getElementById('btnmodify').disabled = true;
        document.getElementById('txtbookingid').value = "";
        document.getElementById('txtbookingid').focus();
        return false;
    }

}

function cleardata() {
    document.getElementById('txtagency12').value = "";
    document.getElementById('hdnagencytxt').value = "";

    if (document.getElementById("DataGrid1") != null)
        document.getElementById("DataGrid1").outerHTML = "";

    document.getElementById('txtexecutive').value = "";
    document.getElementById('hdnexecutive').value = "";




    document.getElementById('txtvalidityfrom').value = "";
    document.getElementById('txttilldate').value = "";
    
    
    
    
    document.getElementById('btnmodify').disabled = true;
    document.getElementById('txtbookingid').value = "";
    document.getElementById('txtagency').value = "";
    document.getElementById('txtclient').value = "";
    document.getElementById('txtadsubcat2').value = "";
    document.getElementById('txtcardrate').value = "";
    document.getElementById('txtagreedamount').value = "";
    document.getElementById('txtretainername').value = "";
    document.getElementById('txtpaymode').value = "";
    document.getElementById('txtaddagecomm').value = "";
    document.getElementById('txtpageposition').value = "";
    document.getElementById('txtrono').value = "";
    document.getElementById('txtrostatus').value = "";
    document.getElementById('txtgrossamt').value = "";
    document.getElementById('txtspecialcharge').value = "";
    document.getElementById('txtexecutivename').value = "";
    document.getElementById('txtbookingtype').value = "";
    document.getElementById('txtoutstanding').value = "";
    document.getElementById('txtadcategory').value = "";
    document.getElementById('txtpositionpre').value = "";
    document.getElementById('txtarea').value = "";
    document.getElementById('txtretainercommission').value = "";
    document.getElementById('txtuom').value = "";
    document.getElementById('txtagtradediscount').value = "";
    document.getElementById('txtpositionpremium').value = "";
    document.getElementById('txtadsubcat1').value = "";
    document.getElementById('txtheight').value = "";
    document.getElementById('txtwidth').value = "";
    document.getElementById('txtpackage').value = "";
    document.getElementById('txtcolourtype').value = "";
    document.getElementById('txtnoofinsertion').value = "";
    document.getElementById('txtpublishdate').value = "";
    document.getElementById('txtcontractname').value = "";
    document.getElementById('txtschemetype').value = "";
    document.getElementById('txtpaid').value = "";
    document.getElementById('txtcardamount').value = "";
    document.getElementById('txtspecialdiscount').value = "";
    document.getElementById('txtdiscount').value = "";
    document.getElementById('txtagreedrate').value = "";
    document.getElementById('txtlines').value = "";
    document.getElementById('txtspacediscount').value = "";
    document.getElementById('txtadsubcat3').value = "";
    document.getElementById('txtadsubcat4').value = "";
    document.getElementById('txtratecode').value = "";
    document.getElementById('txtbillamount').value = "";
    //document.getElementById('txtremarks').value="";
    document.getElementById('txtdiscountamt').value = "";
    document.getElementById('txtPagePrem').value = "";
    document.getElementById('txtPagePremamt').value = "";
    document.getElementById('txtpositionpremiumamt').value = "";
    document.getElementById('txtspecialdiscount').value = "";
    document.getElementById('txtspecialdiscountamt').value = "";
    document.getElementById('txtspacediscount').value = "";
    document.getElementById('txtspacediscountamt').value = "";
    document.getElementById('txtSumAmt').value = "";
    document.getElementById('txtretainercommissionamt').value = "";
    document.getElementById('txtagtradediscountamt').value = "";
    document.getElementById('txtaddagecommamt').value = "";
    return false;
}

function exec_callback(response) {
    var ds = response.value;
    if (ds != null) {
        var len = ds.Tables[0].Rows.length;
        if (len != "0") {
            document.getElementById('hiddenuomdesc').value = ds.Tables[0].Rows[0].uom_desc;
            if (document.getElementById('hiddenrefresh').value == '1' && ds.Tables[2].Rows.length > 0) {
                if (ds.Tables[0].Rows[0].AgencyName != ds.Tables[2].Rows[0].AgencyName) {
                    document.getElementById('txtagency').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtagency').style.backgroundColor = "#FFFFFF";
                }
                if (ds.Tables[0].Rows[0].AgencySubCode != ds.Tables[2].Rows[0].AgencySubCode) {
                    document.getElementById('txtagencysubcode').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtagencysubcode').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Client != ds.Tables[2].Rows[0].Client) {
                    document.getElementById('txtclient').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtclient').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Agency_type != ds.Tables[2].Rows[0].Agency_type) {
                    document.getElementById('txtagencytype').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtagencytype').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Agency_address != ds.Tables[2].Rows[0].Agency_address) {
                    document.getElementById('txtadress2').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtadress2').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Client_address != ds.Tables[2].Rows[0].Client_address) {
                    document.getElementById('txtaddress1').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtaddress1').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Agency_status != ds.Tables[2].Rows[0].Agency_status) {
                    document.getElementById('txtstatus').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtstatus').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].PayMode != ds.Tables[2].Rows[0].PayMode) {
                    document.getElementById('txtpaymode').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtpaymode').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Agency_credit != ds.Tables[2].Rows[0].Agency_credit) {
                    document.getElementById('txtcreditperiod').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtcreditperiod').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].RO_No != ds.Tables[2].Rows[0].RO_No) {
                    document.getElementById('txtrono').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtrono').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].RO_Date != ds.Tables[2].Rows[0].RO_Date) {
                    document.getElementById('txtrodate').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtrodate').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].ro_status != ds.Tables[2].Rows[0].ro_status) {
                    document.getElementById('txtrostatus').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtrostatus').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Dockit_no != ds.Tables[2].Rows[0].Dockit_no) {
                    document.getElementById('txtdockitno').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtdockitno').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Key_no != ds.Tables[2].Rows[0].Key_no) {
                    document.getElementById('txtkeyno').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtkeyno').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].execname != ds.Tables[2].Rows[0].execname) {
                    document.getElementById('txtexecutivename').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtexecutivename').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Executive_zone != ds.Tables[2].Rows[0].Executive_zone) {
                    document.getElementById('txtexecutivezone').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtexecutivezone').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Agency_out != ds.Tables[2].Rows[0].Agency_out) {
                    document.getElementById('txtoutstanding').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtoutstanding').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].categoryname != ds.Tables[2].Rows[0].categoryname) {
                    document.getElementById('txtadcategory').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtadcategory').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].subcategoryname != ds.Tables[2].Rows[0].subcategoryname) {
                    document.getElementById('txtadsubcat').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtadsubcat').style.backgroundColor = "#FFFFFF";
                }
                if (ds.Tables[0].Rows[0].Brand != ds.Tables[2].Rows[0].Brand) {
                    document.getElementById('txtbrand').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtbrand').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].product != ds.Tables[2].Rows[0].product) {
                    document.getElementById('txtproduct').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtproduct').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].UOM != ds.Tables[2].Rows[0].UOM) {
                    document.getElementById('txtuom').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtuom').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].PagePremium != ds.Tables[2].Rows[0].PagePremium) {
                    document.getElementById('txtpagepremium').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtpagepremium').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].PositionPremium != ds.Tables[2].Rows[0].PositionPremium) {
                    document.getElementById('txtpositionpremium').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtpositionpremium').style.backgroundColor = "#FFFFFF";
                }
                if (ds.Tables[0].Rows[0].Ad_size_column != ds.Tables[2].Rows[0].Ad_size_column) {
                    document.getElementById('txtnoofcolumns').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtnoofcolumns').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Ad_size_height != ds.Tables[2].Rows[0].Ad_size_height) {
                    document.getElementById('txtheight').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtheight').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Ad_size_width != ds.Tables[2].Rows[0].Ad_size_width) {
                    document.getElementById('txtwidth').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtwidth').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Currency != ds.Tables[2].Rows[0].Currency) {
                    document.getElementById('txtcurrencytype').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtcurrencytype').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Insertion_date != ds.Tables[2].Rows[0].Insertion_date) {
                    document.getElementById('txtpublishdate').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtpublishdate').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].No_of_insertion != ds.Tables[2].Rows[0].No_of_insertion) {
                    document.getElementById('txtnoofinsertion').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtnoofinsertion').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Contract_name != ds.Tables[2].Rows[0].Contract_name) {
                    document.getElementById('txtcontractname').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtcontractname').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Paid_ins != ds.Tables[2].Rows[0].Paid_ins) {
                    document.getElementById('txtpaid').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtpaid').style.backgroundColor = "#FFFFFF";
                }
                if (ds.Tables[0].Rows[0].Card_amount != ds.Tables[2].Rows[0].Card_amount) {
                    document.getElementById('txtcardamount').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtcardamount').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Agrred_rate != ds.Tables[2].Rows[0].Agrred_rate) {
                    document.getElementById('txtagreedrate').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtagreedrate').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Special_discount != ds.Tables[2].Rows[0].Special_discount) {
                    document.getElementById('txtspecialdiscount').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtspecialdiscount').style.backgroundColor = "#FFFFFF";
                }

                if (ds.Tables[0].Rows[0].Discount != ds.Tables[2].Rows[0].Discount) {
                    document.getElementById('txtdiscount').style.backgroundColor = "#FFFF80";
                }
                else {
                    document.getElementById('txtdiscount').style.backgroundColor = "#FFFFFF";
                }

            }
            if (ds.Tables[0].Rows[0].uom_desc == null) {
                document.getElementById('txtlines').value = "";
                document.getElementById('txtarea').value = "";
            }
            else {
                if (ds.Tables[0].Rows[0].uom_desc == 'CD') {
                    document.getElementById('txtlines').value = "";
                    document.getElementById('txtarea').value = ds.Tables[0].Rows[0].Total_area;
                }
                else {
                    document.getElementById('txtlines').value = ds.Tables[0].Rows[0].Total_area;
                    document.getElementById('txtarea').value = "";
                }
                //document.getElementById('txtlines').value=ds.Tables[0].Rows[0].Total_area;
            }
            if (ds.Tables[0].Rows[0].AgencyName == null) {
                document.getElementById('txtagency').value == "";
            }
            else {
                document.getElementById('txtagency').value = ds.Tables[0].Rows[0].AgencyName;
            }

            if (ds.Tables[0].Rows[0].Package_code == null) {
                document.getElementById('txtpackage').value = "";
            }
            else {
                if (ds.Tables[0].Rows[0].Package_code.indexOf(",") > 0) {
                    var s1 = ds.Tables[0].Rows[0].Package_code.split(",");
                    var pkg_name = "";
                    for (var k_ = 0; k_ < s1.length; k_++) {
                        var ds_pkg = cash_rcptformult.getPackageName(document.getElementById('hiddencompcode').value, s1[k_]);
                        if (ds_pkg.value != null) {
                            if (pkg_name == "")
                                pkg_name = ds_pkg.value.Tables[0].Rows[0].Package_Name;
                            else
                                pkg_name = pkg_name + "," + ds_pkg.value.Tables[0].Rows[0].Package_Name;
                        }
                    }
                    document.getElementById('txtpackage').value = pkg_name;
                }
                else {
                    var ds_pkg = cash_rcptformult.getPackageName(document.getElementById('hiddencompcode').value, ds.Tables[0].Rows[0].Package_code);
                    if (ds_pkg.value != null) {
                        document.getElementById('txtpackage').value = ds_pkg.value.Tables[0].Rows[0].Package_Name;
                    }
                }
            }
            if (ds.Tables[0].Rows[0].Card_rate == null) {
                document.getElementById('txtcardrate').value = "";
            }
            else {
                document.getElementById('txtcardrate').value = ds.Tables[0].Rows[0].Card_rate;
            }
            if (ds.Tables[0].Rows[0].Client == null) {
                document.getElementById('txtclient').value = "";
            }
            else {
                document.getElementById('txtclient').value = ds.Tables[0].Rows[0].Client;
            }
            if (ds.Tables[0].Rows[0].Agreed_amount == null || ds.Tables[0].Rows[0].Agreed_amount == "" || ds.Tables[0].Rows[0].Agreed_amount == "0") {
                document.getElementById('txtagreedamount').value = "";
            }
            else {
                document.getElementById('txtagreedamount').value = ds.Tables[0].Rows[0].Agreed_amount;
            }
            if (ds.Tables[0].Rows[0].Space_discount == null) {
                document.getElementById('txtspacediscountamt').value = "";
            }
            else {
                document.getElementById('txtspacediscountamt').value = ds.Tables[0].Rows[0].Space_discount;
            }

            if (ds.Tables[0].Rows[0].Space_disc_per == null) {
                document.getElementById('txtspacediscount').value = "";
                document.getElementById('txtspacediscountamt').value = "";
            }
            else {
                document.getElementById('txtspacediscount').value = ds.Tables[0].Rows[0].Space_disc_per;
                if (document.getElementById('txtarea').value != "")
                    document.getElementById('txtspacediscountamt').value = (parseFloat(ds.Tables[0].Rows[0].Space_disc_per) * parseFloat(document.getElementById('txtarea').value) * parseFloat(document.getElementById('txtcardrate').value) / 100).toFixed(2);
            }
            if (ds.Tables[0].Rows[0].Special_charges == null || ds.Tables[0].Rows[0].Special_charges == "") {
                document.getElementById('txtspecialcharge').value = "";
            }
            else {
                document.getElementById('txtspecialcharge').value = (parseFloat(ds.Tables[0].Rows[0].Special_charges)).toFixed(2);
            }
            if (ds.Tables[0].Rows[0].RETAINER1 == null || ds.Tables[0].Rows[0].RETAINER1 == "") {
                document.getElementById('txtretainername').value = "";
            }
            else {
                document.getElementById('txtretainername').value = ds.Tables[0].Rows[0].RETAINER1;
            }
            if (ds.Tables[0].Rows[0].PayMode == null || ds.Tables[0].Rows[0].PayMode == "") {
                document.getElementById('txtpaymode').value = "";
            }
            else {
                document.getElementById('txtpaymode').value = ds.Tables[0].Rows[0].PayMode;
            }
            if (ds.Tables[0].Rows[0].ADD_AGENCY_COMM == null || ds.Tables[0].Rows[0].ADD_AGENCY_COMM == "") {
                document.getElementById('txtaddagecomm').value = "";
            }
            else {
                document.getElementById('txtaddagecomm').value = ds.Tables[0].Rows[0].ADD_AGENCY_COMM;
            }
            if (ds.Tables[0].Rows[0].ADD_AGENCY_COMM_AMT == null || ds.Tables[0].Rows[0].ADD_AGENCY_COMM_AMT == "") {
                document.getElementById('txtaddagecommamt').value = "";
            }
            else {
                document.getElementById('txtaddagecommamt').value = (parseFloat(ds.Tables[0].Rows[0].ADD_AGENCY_COMM_AMT)).toFixed(2);
            }

            if (ds.Tables[0].Rows[0].RO_No == null || ds.Tables[0].Rows[0].RO_No == "") {
                document.getElementById('txtrono').value = "";
            }
            else {
                document.getElementById('txtrono').value = ds.Tables[0].Rows[0].RO_No;
            }
            if (ds.Tables[0].Rows[0].Book_type == null || ds.Tables[0].Rows[0].Book_type == "") {
                document.getElementById('txtbookingtype').value = "";
            }
            else {
                document.getElementById('txtbookingtype').value = ds.Tables[0].Rows[0].Book_type;
            }
            if (ds.Tables[0].Rows[0].ro_status == null) {
                document.getElementById('txtrostatus').value = "";
            }
            else {
                if (ds.Tables[0].Rows[0].ro_status == '1') {
                    document.getElementById('txtrostatus').value = 'Confirm';
                }
                else {
                    document.getElementById('txtrostatus').value = 'UnConfirm';
                }
            }
            if (ds.Tables[0].Rows[0].PagePremium == null) {
                document.getElementById('txtpageposition').value = "";
            }
            else {
                document.getElementById('txtpageposition').value = ds.Tables[0].Rows[0].PagePremium;
            }



            if (ds.Tables[0].Rows[0].Subcat3 == null || ds.Tables[0].Rows[0].Subcat3 == "0") {
                document.getElementById('txtadsubcat2').value = "";
            }
            else {
                document.getElementById('txtadsubcat2').value = ds.Tables[0].Rows[0].Subcat3;
            }
            if (ds.Tables[0].Rows[0].execname == null) {
                document.getElementById('txtexecutivename').value = "";
            }
            else {
                document.getElementById('txtexecutivename').value = ds.Tables[0].Rows[0].execname;
            }
            if (ds.Tables[0].Rows[0].Scheme_type_code == null) {
                document.getElementById('txtschemetype').value = "";
            }
            else {
                document.getElementById('txtschemetype').value = ds.Tables[0].Rows[0].Scheme_type_code;
            }
            if (ds.Tables[0].Rows[0].Agency_out == null) {
                document.getElementById('txtoutstanding').value = "";
            }
            else {
                document.getElementById('txtoutstanding').value = ds.Tables[0].Rows[0].Agency_out;
            }
            if (ds.Tables[0].Rows[0].categoryname == null) {
                document.getElementById('txtadcategory').value = "";
            }
            else {
                document.getElementById('txtadcategory').value = ds.Tables[0].Rows[0].categoryname;
            }

            if (ds.Tables[0].Rows[0].Bill_amount == null) {
                document.getElementById('txtbillamount').value = "";
            }
            else {
                document.getElementById('txtbillamount').value = (parseFloat(ds.Tables[0].Rows[0].Bill_amount)).toFixed(2);
            }
            if (ds.Tables[0].Rows[0].Rate_code == null) {
                document.getElementById('txtratecode').value = "";
            }
            else {
                document.getElementById('txtratecode').value = ds.Tables[0].Rows[0].Rate_code;
            }
            if (ds.Tables[0].Rows[0].UOM == null) {
                document.getElementById('txtuom').value = ""
            }
            else {
                document.getElementById('txtuom').value = ds.Tables[0].Rows[0].UOM;
            }
            if (ds.Tables[0].Rows[0].Subcat4 == null || ds.Tables[0].Rows[0].Subcat4 == "null") {
                document.getElementById('txtadsubcat3').value = "";
            }
            else {
                document.getElementById('txtadsubcat3').value = ds.Tables[0].Rows[0].Subcat4;
            }
            if (ds.Tables[0].Rows[0].subcat5 == null || ds.Tables[0].Rows[0].subcat5 == "") {
                document.getElementById('txtadsubcat4').value = "";
            }
            else {
                document.getElementById('txtadsubcat4').value = ds.Tables[0].Rows[0].subcat5;
            }
            if (ds.Tables[0].Rows[0].PositionPremium == null || ds.Tables[0].Rows[0].PositionPremium == "") {
                document.getElementById('txtpositionpre').value = "";
            }
            else {
                document.getElementById('txtpositionpre').value = ds.Tables[0].Rows[0].PositionPremium;
            }
            if (ds.Tables[0].Rows[0].RETAINER_COMM1 == null || ds.Tables[0].Rows[0].RETAINER_COMM1 == "") {
                document.getElementById('txtretainercommission').value = "";
            }
            else {
                document.getElementById('txtretainercommission').value = ds.Tables[0].Rows[0].RETAINER_COMM1;
            }
            if (ds.Tables[0].Rows[0].RETAINER_COMM_AMT == null || ds.Tables[0].Rows[0].RETAINER_COMM_AMT == "") {
                document.getElementById('txtretainercommissionamt').value = "";
            }
            else {
                document.getElementById('txtretainercommissionamt').value = (parseFloat(ds.Tables[0].Rows[0].RETAINER_COMM_AMT)).toFixed(2);
            }
            if (ds.Tables[0].Rows[0].Trade_disc == null) {
                document.getElementById('txtagtradediscount').value = "";
            }
            else {
                document.getElementById('txtagtradediscount').value = ds.Tables[0].Rows[0].Trade_disc;
                if (ds.Tables[0].Rows[0].Gross_amount != null)
                    document.getElementById('txtagtradediscountamt').value = (parseFloat(ds.Tables[0].Rows[0].Trade_disc) * parseFloat(ds.Tables[0].Rows[0].Gross_amount) / 100).toFixed(2);
            }
            if (ds.Tables[0].Rows[0].Ad_size_height == null) {
                document.getElementById('txtheight').value = "";
            }
            else {
                document.getElementById('txtheight').value = ds.Tables[0].Rows[0].Ad_size_height;
            }
            if (ds.Tables[0].Rows[0].Ad_size_width == null) {
                document.getElementById('txtwidth').value = ""
            }
            else {
                document.getElementById('txtwidth').value = ds.Tables[0].Rows[0].Ad_size_width;
            }
            if (ds.Tables[0].Rows[0].subcategoryname == null) {
                document.getElementById('txtadsubcat1').value = "";
            }
            else {
                document.getElementById('txtadsubcat1').value = ds.Tables[0].Rows[0].subcategoryname;
            }
            if (ds.Tables[0].Rows[0].Ad_size_height == null) {
                document.getElementById('txtheight').value = "";
            }
            else {
                document.getElementById('txtheight').value = ds.Tables[0].Rows[0].Ad_size_height;
            }
            if (ds.Tables[0].Rows[0].Ad_size_width == null) {
                document.getElementById('txtwidth').value = "";
            }
            else {
                document.getElementById('txtwidth').value = ds.Tables[0].Rows[0].Ad_size_width;
            }
            if (ds.Tables[0].Rows[0].Insertion_date == null) {
                document.getElementById('txtpublishdate').value = "";
            }
            else {
                document.getElementById('txtpublishdate').value = ds.Tables[0].Rows[0].Insertion_date;
            }
            if (ds.Tables[0].Rows[0].No_of_insertion == null) {
                document.getElementById('txtnoofinsertion').value = "";
            }
            else {
                document.getElementById('txtnoofinsertion').value = ds.Tables[0].Rows[0].No_of_insertion;
            }

            if (ds.Tables[0].Rows[0].Contract_name == null) {
                document.getElementById('txtcontractname').value = "";
            }
            else {
                document.getElementById('txtcontractname').value = ds.Tables[0].Rows[0].Contract_name;
            }
            if (ds.Tables[0].Rows[0].Paid_ins == null) {
                document.getElementById('txtpaid').value = "";
            }
            else {
                document.getElementById('txtpaid').value = ds.Tables[0].Rows[0].Paid_ins;
            }
            if (ds.Tables[0].Rows[0].Card_amount == null) {
                document.getElementById('txtcardamount').value = "";
            }
            else {
                document.getElementById('txtcardamount').value = (parseFloat(ds.Tables[0].Rows[0].Card_amount)).toFixed(2);
            }
            if (ds.Tables[0].Rows[0].Agrred_rate == null || ds.Tables[0].Rows[0].Agrred_rate == "" || ds.Tables[0].Rows[0].Agrred_rate == "0") {
                document.getElementById('txtagreedrate').value = ""
            }
            else {
                document.getElementById('txtagreedrate').value = ds.Tables[0].Rows[0].Agrred_rate;
            }
            if (ds.Tables[0].Rows[0].Color_cod == null) {
                document.getElementById('txtcolourtype').value = ""
            }
            else {
                document.getElementById('txtcolourtype').value = ds.Tables[0].Rows[0].Color_cod;
            }
            if (ds.Tables[0].Rows[0].Gross_amount == null) {
                document.getElementById('txtgrossamt').value = ""
            }
            else {
                document.getElementById('txtgrossamt').value = (parseFloat(ds.Tables[0].Rows[0].Gross_amount)).toFixed(2);
            }
         
            if (ds.Tables[0].Rows[0].Special_discount == null) {
                document.getElementById('txtspecialdiscountamt').value = "";
            }
            else {
                document.getElementById('txtspecialdiscountamt').value = ds.Tables[0].Rows[0].Special_discount;
            }
            if (ds.Tables[0].Rows[0].Special_disc_per == null) {
                document.getElementById('txtspecialdiscount').value = "";
                document.getElementById('txtspecialdiscountamt').value = "";
            }
            else {
                document.getElementById('txtspecialdiscount').value = ds.Tables[0].Rows[0].Special_disc_per;
                if (document.getElementById('txtarea').value != "")
                    document.getElementById('txtspecialdiscountamt').value = (parseFloat(ds.Tables[0].Rows[0].Special_disc_per) * parseFloat(document.getElementById('txtarea').value) * parseFloat(document.getElementById('txtcardrate').value) / 100).toFixed(2);
            }

            if (ds.Tables[0].Rows[0].Discount == null || ds.Tables[0].Rows[0].Discount == "") {
                document.getElementById('txtdiscountamt').value = "";
            }
            else {
                if (ds.Tables[0].Rows[0].Discount != "0")
                    document.getElementById('txtdiscountamt').value = parseFloat(document.getElementById('txtcardamount').value) - parseFloat(document.getElementById('txtagreedamount').value); //ds.Tables[0].Rows[0].Discount;
            }
            if (ds.Tables[0].Rows[0].Discount_per == null || ds.Tables[0].Rows[0].Discount_per == "") {
                document.getElementById('txtdiscount').value = "";
            }
            else {
                document.getElementById('txtdiscount').value = ds.Tables[0].Rows[0].Discount_per;
            }

            if (ds.Tables[0].Rows[0].Ad_type_code == null || ds.Tables[0].Rows[0].Ad_type_code == "") {
                document.getElementById('hiddenadtype').value = "";
            }
            else {
                document.getElementById('hiddenadtype').value = ds.Tables[0].Rows[0].Ad_type_code;
            }

            //for page premium
            var page_premium = 0;
            if (ds.Tables[0].Rows[0].Prem_per == null || ds.Tables[0].Rows[0].Prem_per == "" || ds.Tables[0].Rows[0].Prem_per == "null") {
                document.getElementById('txtPagePrem').value = "";
                document.getElementById('txtPagePremamt').value = "";
            }
            else {
                document.getElementById('txtPagePrem').value = ds.Tables[0].Rows[0].Prem_per;
                if (document.getElementById('txtcardamount').value != "") {
                    page_premium = document.getElementById('txtPagePremamt').value = (parseFloat(document.getElementById('txtcardamount').value) * parseFloat(document.getElementById('txtPagePrem').value) / 100).toFixed(2);
                }
            }
            //for position premium
            if (ds.Tables[0].Rows[0].Page_amount == null || ds.Tables[0].Rows[0].Page_amount == "") {
                document.getElementById('txtpositionpremium').value = "";
                document.getElementById('txtpositionpremiumamt').value = "";
            }
            else {
                document.getElementById('txtpositionpremium').value = ds.Tables[0].Rows[0].Page_amount;
                if (document.getElementById('txtcardamount').value != "") {
                    document.getElementById('txtpositionpremiumamt').value = ((parseFloat(page_premium) + parseFloat(document.getElementById('txtcardamount').value)) * parseFloat(document.getElementById('txtpositionpremium').value) / 100).toFixed(2);
                }
            }

            //calculate net amount **********************************************
            if (document.getElementById('txtarea').value != "")
                var tot_area = document.getElementById('txtarea').value;
            else
                var tot_area = 1;

            if (document.getElementById('txtspacediscountamt').value == "")
                var disc_space = 0;
            else
                var disc_space = document.getElementById('txtspacediscountamt').value;

            if (document.getElementById('txtspecialdiscountamt').value == "")
                var disc_special = 0;
            else
                var disc_special = document.getElementById('txtspecialdiscountamt').value;

            if (document.getElementById('txtdiscountamt').value == "")
                var disc_amt = 0;
            else
                var disc_amt = document.getElementById('txtdiscountamt').value;
            var pos_premium = "0";
            if (document.getElementById('txtpositionpremiumamt').value != "") {
                pos_premium = document.getElementById('txtpositionpremiumamt').value;
            }
            if (document.getElementById('txtagreedamount').value != "" && document.getElementById('txtagreedamount').value != "0")
                document.getElementById('txtSumAmt').value = parseFloat(document.getElementById('txtagreedamount').value).toFixed(2);
            else {


                if (document.getElementById('txtcardamount').value == "") {
                    document.getElementById('txtcardamount').value = 0;
                }
                document.getElementById('txtSumAmt').value = (parseFloat(document.getElementById('txtcardamount').value) + parseFloat(page_premium) + parseFloat(pos_premium) - parseFloat(disc_amt) - parseFloat(disc_space) - parseFloat(disc_special)).toFixed(2);

            }
            //*****************************

            if (ds.Tables[0].Rows[0].Bullet_Desc == null)
                document.getElementById('txt_eyecater').value = "";
            else
                document.getElementById('txt_eyecater').value = ds.Tables[0].Rows[0].Bullet_Desc;

            /////////////

            if (ds.Tables[0].Rows[0].Bullet_premium == null)
                document.getElementById('txt_eyecaterprem').value = "";
            else
                document.getElementById('txt_eyecaterprem').value = ds.Tables[0].Rows[0].Bullet_premium;
            var browser = navigator.appName;

            if (ds.Tables[0].Rows[0].DOCTYPE != null) {
                var doctype = ds.Tables[0].Rows[0].DOCTYPE;
                if (doctype == "RCP")
                    doctype = "Cash Receipt";
                else if (doctype == "CA")
                    doctype = "Cash Refund Receipt";
                if (browser != "Microsoft Internet Explorer") {
                    document.getElementById('lbldoctype').textContent = doctype;
                }
                else {
                    document.getElementById('lbldoctype').innerText = doctype;
                }
            }
            else {
                if (browser != "Microsoft Internet Explorer") {
                    document.getElementById('lbldoctype').textContent = "";
                }
                else {
                    document.getElementById('lbldoctype').innerText = "";
                }
            }
            //////////////

        }
    }

}
// JScript File

function printreceipt(receiptno, cioid) {

    var ds_mode = "";
    var paymode = "";
    var recptno = receiptno;

    var cls_matter = "";
   // document.getElementById('btnsubmit').click();
    var lngth = cioid.split(',');
   //  document.getElementById('hdnlength').value = lngth.length;

    var ln = lngth.length; //document.getElementById('hdnlength').value;
    var agency = document.getElementById('txtagency12').value;
    var coid = document.getElementById('txtbookingid').value;
//    if (agency != "" || coid != "") {
//        print_receipt(receiptno, cioid);
//    }
//    else 
   if (cioid != "") {
        if (ds_mode == undefined || ds_mode == "")
            window.open('rcptformultiplebookid.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter + '&length=' + ln, '', 'width=700px,height=550px,resizable=1,left=0,top=0,scrollbars=yes');
        else {
            if (paymode == "Cash" || paymode == "CASH" || paymode == "cash")
                window.open('rcptformultiplebookid.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter + '&length=' + ln, '', 'width=700px,height=550px,resizable=1,left=0,top=0,menubar=yes,scrollbars=yes');

            else
                window.open('Receiptonly.aspx?cioid=' + cioid + '&rcptno=' + rcptno + '&compcode=' + compcode, '', 'width=700px,height=550px,resizable=1,left=0,top=0,scrollbars=yes');
        }
    }
    else {
        alert("Please get the Booking id");
    }
    return false;
}



function F2fillagencycr_allagency(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        if (document.activeElement.id == "txtagency12") {

       
        
        
            var compcode = document.getElementById('hiddencompcode').value;
            var agn = document.getElementById('txtagency12').value;
            document.getElementById("div1").style.display = "block";
            document.getElementById('div1').style.top = 215 + "px"; //314//290
            document.getElementById('div1').style.left = 580 + "px"; //395//1004
            document.getElementById('lstagency').focus();
            cash_rcptformult.fillF2_CreditAgency(compcode, agn, bindAgency_callback1);
        }
    }
    else if (((key == 8) || (key == 46)) || (event.ctrlKey == true && key == 88)) {

        if (document.activeElement.id == "txtagency12") {
            document.getElementById('txtagency12').value = "";
            //document.getElementById('hdnagency1').value = "";
            return false;
        }
        return key;
    }
}
function bindAgency_callback1(res) {
    var ds_AccName = res.value;

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstagency");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Agency Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Agency_Name, ds_AccName.Tables[0].Rows[i].Agency_Code);
            pkgitem.options.length;
        }
    }

    var aTag = eval(document.getElementById('txtagency12'))
    var btag;
    var leftpos = 0;
    var toppos = 0;
    do {
        aTag = eval(aTag.offsetParent);
        leftpos += aTag.offsetLeft;
        toppos += aTag.offsetTop;
        btag = eval(aTag)
    } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
    var tot = document.getElementById('div1').scrollLeft;
    var scrolltop = document.getElementById('div1').scrollTop;
    document.getElementById('div1').style.left = document.getElementById('txtagency12').offsetLeft + leftpos - tot + "px";
    document.getElementById('div1').style.top = document.getElementById('txtagency12').offsetTop + toppos - scrolltop + "px"; //"510px";



    document.getElementById("lstagency").value = "0";
    document.getElementById("div1").value = "";
    document.getElementById('lstagency').focus();

    return false;

}

function ClickAgaency1(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click") {
        if (document.activeElement.id == "lstagency") {
            if (document.getElementById('lstagency').value == "0") {
                alert("Please select Agency Name");
                return false;
            }

            var page = document.getElementById('lstagency').value;
            agencycode = page;
            for (var k = 0; k <= document.getElementById('lstagency').length - 1; k++) {
                if (document.getElementById('lstagency').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstagency').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstagency').options[k].innerText;
                    }
                    document.getElementById('txtagency12').value = abc;
                    document.getElementById('hdnagencytxt').value = page;
                   // document.getElementById('hdnagency1').value = page;

                    document.getElementById("div1").style.display = "none";
                    document.getElementById('txtagency12').focus();
                    return false;

                }
            }
        }
    }
    else if (key == 27) {

        document.getElementById("div1").style.display = "none";
        document.getElementById('txtagency12').focus();
    }
}



/////////------------------------------------


function fillexecutive(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113) {
        if (document.activeElement.id == "txtexecutive") {
            var compcode = document.getElementById('hiddencompcode').value;
            var agn = document.getElementById('txtexecutive').value;
            document.getElementById("div2").style.display = "block";
            document.getElementById('div2').style.top = 215 + "px"; //314//290
            document.getElementById('div2').style.left = 580 + "px"; //395//1004
            document.getElementById('lstexecutive').focus();
            cash_rcptformult.bindExec(document.getElementById('hiddencompcode').value, document.getElementById('txtexecutive').value, "0", "0", document.getElementById('drpadtype').value, bindexecutive);
        }
    }
    else if (((key == 8) || (key == 46)) || (event.ctrlKey == true && key == 88)) {

        if (document.activeElement.id == "txtexecutive") {
            document.getElementById('txtexecutive').value = "";
            //document.getElementById('hdnagency1').value = "";
            return false;
        }
        return key;
    }
}
function bindexecutive(res) {
    var ds_AccName = res.value;

    if (ds_AccName != null && typeof (ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) {
        var pkgitem = document.getElementById("lstexecutive");
        pkgitem.options.length = 0;
        pkgitem.options[0] = new Option("-Select Executive Name-", "0");
        pkgitem.options.length = 1;
        for (var i = 0; i < ds_AccName.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].exec_name, ds_AccName.Tables[0].Rows[i].exe_no);
            pkgitem.options.length;
        }
    }

    var aTag = eval(document.getElementById('txtexecutive'))
    var btag;
    var leftpos = 0;
    var toppos = 0;
    do {
        aTag = eval(aTag.offsetParent);
        leftpos += aTag.offsetLeft;
        toppos += aTag.offsetTop;
        btag = eval(aTag)
    } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
    var tot = document.getElementById('div2').scrollLeft;
    var scrolltop = document.getElementById('div2').scrollTop;
    document.getElementById('div2').style.left = document.getElementById('txtexecutive').offsetLeft + leftpos - tot + "px";
    document.getElementById('div2').style.top = document.getElementById('txtexecutive').offsetTop + toppos - scrolltop + "px"; //"510px";



    document.getElementById("lstexecutive").value = "0";
    document.getElementById("div2").value = "";
    document.getElementById('lstexecutive').focus();

    return false;

}

function clickexecutive(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click") {
        if (document.activeElement.id == "lstexecutive") {
            if (document.getElementById('lstexecutive').value == "0") {
                alert("Please select Agency Name");
                return false;
            }

            var page = document.getElementById('lstexecutive').value;
            agencycode = page;
            for (var k = 0; k <= document.getElementById('lstexecutive').length - 1; k++) {
                if (document.getElementById('lstexecutive').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstexecutive').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstexecutive').options[k].innerText;
                    }
                    document.getElementById('txtexecutive').value = abc;
                    document.getElementById('hdnexecutive').value = page;
                    // document.getElementById('hdnagency1').value = page;

                    document.getElementById("div2").style.display = "none";
                    document.getElementById('txtexecutive').focus();
                    return false;

                }
            }
        }
    }
    else if (key == 27) {

        document.getElementById("div2").style.display = "none";
        document.getElementById('txtexecutive').focus();
    }
}




function selectAll() {
    document.getElementById('btnmodify').disabled = false;
    if (document.getElementById("checkall").checked == true) {
        for (var k = 0; k < document.getElementById("DataGrid1").rows.length - 1; k++) {
            var chkid = "chk" + k;
            if (document.getElementById(chkid).disabled == false)
                document.getElementById(chkid).checked = true;
        }
    }
    else {
        for (var k = 0; k < document.getElementById("DataGrid1").rows.length - 1; k++) {
            var chkid = "chk" + k;
            document.getElementById(chkid).checked = false;
        }
    }
}




amount=0;
function booking(id,amt) {

    document.getElementById('btnmodify').disabled = false;

    document.getElementById('lblpaymode123').disabled = false;

    document.getElementById('drppaymode').disabled = false;
    
    document.getElementById('hdnamt').value=+parseFloat(amt);
     if( document.getElementById(id).checked==true)
     {
     amount = amount+parseFloat(amt);
     
     document.getElementById('ttexttobil1').value=amount;
     }
     else
     {
      amount = amount-parseFloat(amt);
    document.getElementById('ttexttobil1').value=amount;
    }
    return true;
   
}




function submit123() {


    var res=cash_rcptformult.submitclick(document.getElementById('hiddendateformat').value, document.getElementById('txtvalidityfrom').value, document.getElementById('txttilldate').value, document.getElementById('txtbookingid').value, document.getElementById('txtagency12').value, document.getElementById('txtexecutive').value, document.getElementById('hiddencompcode').value, document.getElementById('drpadtype').value, document.getElementById('txtbookingid').value);

    return false;
}




function FOCUS_FIRST() {
    document.getElementById('txtagency12').focus();
    document.getElementById('txtagency12').value = "";
    document.getElementById('hdnagencytxt').value = "";



}

function entertotab(event) {




    if (event.keyCode == 13 || event.keyCode == 9) {
        if (document.activeElement.id == "txtagency12") {
            if (document.getElementById('txtagency12').value == "" || document.getElementById('txtagency12').value != "") {
                document.getElementById('drpadtype').focus();
                return false;
            }
        }

      
        if (document.activeElement.id == "drpadtype") {
            if (document.getElementById('drpadtype').value == "" || document.getElementById('drpadtype').value != "") {
                document.getElementById('txtexecutive').focus();
                return false;
            }
        }


        if (document.activeElement.id == "txtexecutive") {

          
            if (document.getElementById('txtexecutive').value == "" || document.getElementById('txtexecutive').value != "") {
                document.getElementById('txtvalidityfrom').focus();
                return false;
            }
        }

        

        if (document.activeElement.id == "txtvalidityfrom") {


            if (document.getElementById('txtvalidityfrom').value == "") {


                alert("Please Select Valid From")
                document.getElementById('txtvalidityfrom').focus();

                return false;
            }
            else {
                document.getElementById('txtbookingid').focus();
            
            return false;
            
            }
        }




        if (document.activeElement.id == "txtbookingid") {
            if (document.getElementById('txtbookingid').value == "" || document.getElementById('txtbookingid').value != "") {
                document.getElementById('txttilldate').focus();

                return false;
            }



        }



        if (document.activeElement.id == "txttilldate") {
            if (document.getElementById('txttilldate').value == "") {
            
            alert("Please Select  Valid To Date ")
                document.getElementById('txttilldate').focus();
                return false;
            }

            else {
                document.getElementById('drpadjusted').focus();

                return false;
            }
        }



        return false;


    } 
}



function eventcalling(event) {

    if (event.keyCode == 97)
        event.keyCode = 65;
    if (event.keyCode == 98)
        event.keyCode = 66;
    if (event.keyCode == 99)
        event.keyCode = 67;
    if (event.keyCode == 100)
        event.keyCode = 68;
    if (event.keyCode == 101)
        event.keyCode = 69;
    if (event.keyCode == 102)
        event.keyCode = 70;
    if (event.keyCode == 103)
        event.keyCode = 71;
    if (event.keyCode == 104)
        event.keyCode = 72;
    if (event.keyCode == 105)
        event.keyCode = 73;
    if (event.keyCode == 106)
        event.keyCode = 74;
    if (event.keyCode == 107)
        event.keyCode = 75;
    if (event.keyCode == 108)
        event.keyCode = 76;
    if (event.keyCode == 109)
        event.keyCode = 77;
    if (event.keyCode == 110)
        event.keyCode = 78;
    if (event.keyCode == 111)
        event.keyCode = 79;
    if (event.keyCode == 112)
        event.keyCode = 80;
    if (event.keyCode == 113)
        event.keyCode = 81;
    if (event.keyCode == 114)
        event.keyCode = 82;
    if (event.keyCode == 115)
        event.keyCode = 83;
    if (event.keyCode == 116)
        event.keyCode = 84;
    if (event.keyCode == 117)
        event.keyCode = 85;
    if (event.keyCode == 118)
        event.keyCode = 86;
    if (event.keyCode == 119)
        event.keyCode = 87;
    if (event.keyCode == 120)
        event.keyCode = 88;
    if (event.keyCode == 121)
        event.keyCode = 89;
    if (event.keyCode == 122)
        event.keyCode = 90;

}


function notchar2() {
    insert = document.getElementById('txtinsertion').value;
    if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9) || (event.keyCode == 46)) {
        if (document.activeElement.id == 'txtinsertion' && event.keyCode == 46)
            return false;
        else
            return true;
    }
    else {
        return false;
    }
}




function showcreditdetail() {
    document.getElementById('view').style.display = "block";
    if (document.getElementById('drppaymode').value == "CA0") {
        if (!confirm("Are you sure want to take paymode Cash")) {
            document.getElementById('drppaymode').value = 0;
        }
    }
    var ag = cash_rcptformult.GETCASH_PAY(document.getElementById('hiddencompcode').value, document.getElementById('drppaymode').value);
    var ds_n = ag.value;
    var cashdiscount = 'N';
    if (ds_n != null && ds_n.Tables[0].Rows.length > 0) {
        cashdiscount = ds_n.Tables[0].Rows[0].CASHDISCOUNT;
    }

    if (document.getElementById('drppaymode').value == "CR0" || document.getElementById('drppaymode').value == "DE0" || document.getElementById('drppaymode').value == "CR1")  //CR0 is Credit Card code
    {
        document.getElementById('tdcarname').style.display = "";
        document.getElementById('tdtxtcarname').style.display = "";
        document.getElementById('tdtype').style.display = "";
        document.getElementById('tddrptyp').style.display = "";
        document.getElementById('tdexdat').style.display = "";
        document.getElementById('tdtxtexdat').style.display = "";
        document.getElementById('tdcardno').style.display = "";
        document.getElementById('tdtxtcarno').style.display = "";
       // document.getElementById('hiddenbillpay').value = document.getElementById('drppaymode').value;
         
        document.getElementById('txtcardname').disabled = false;
        document.getElementById('drptype').disabled = false;
        document.getElementById('drpmonth').disabled = false;
        document.getElementById('drpyear').disabled = false;
        document.getElementById('txtcardno').disabled = false;

       
        document.getElementById('tdchqno').style.display = "none";
       // document.getElementById('tdourbank').style.display = "none";
        document.getElementById('tdchqdate').style.display = "none";
        document.getElementById('tdchqamt').style.display = "none";
        document.getElementById('tdbankname').style.display = "none";
       // document.getElementById('tdourbank').style.display = "none";


        document.getElementById('tdtextchqno').style.display = "none";
        document.getElementById('tdtextchqdate').style.display = "none";
        document.getElementById('tdtextchqamt').style.display = "none";
        document.getElementById('tdtextbankname').style.display = "none";
        //document.getElementById('tdtextourbank').style.display = "none";
        //document.getElementById("txtreceipt").value = "";
        document.getElementById('cashrecvd').style.display = "none";
        //  document.getElementById('tdcashrecvd').style.display="none";
        document.getElementById('drpcashrecieved').disabled = true;
        document.getElementById('txtcashdiscount').disabled = true;
    }
    else if (document.getElementById('drppaymode').value == "CH0" || document.getElementById('drppaymode').value == "DD0" || document.getElementById('drppaymode').value == "DE1" || document.getElementById('drppaymode').value == 'PO0' || document.getElementById('drppaymode').value == 'AD0')  //CR0 is Credit Card code and DD0 is demand draft
    {
        document.getElementById('ttextchqno').disabled = false;
        document.getElementById('ttextchqdate').disabled = false;
        document.getElementById('ttextchqamt').disabled = false;
        document.getElementById('ttextbankname').disabled = false;
        //document.getElementById('drpourbank').disabled = false;

        document.getElementById('tdchqno').style.display = "";
       // document.getElementById('tdourbank').style.display = "";
        document.getElementById('tdchqdate').style.display = "";
        document.getElementById('tdchqamt').style.display = "";
        document.getElementById('tdbankname').style.display = "";
         document.getElementById('lbtobil1').style.display = "block";
        document.getElementById('ttexttobil1').style.display = "block";

        document.getElementById('tdtextchqno').style.display = "";
      //  document.getElementById('tdtextourbank').style.display = "";
        document.getElementById('tdtextchqdate').style.display = "";
        document.getElementById('tdtextchqamt').style.display = "";
        document.getElementById('tdtextbankname').style.display = "";
        ///document.getElementById('hiddenbillpay').value = document.getElementById('drppaymode').value;

        //document.getElementById('tdrec').style.display = "none";
        //document.getElementById('receipt').style.display = "none";
        //document.getElementById('print').style.display = //"none";
        document.getElementById('tdcarname').style.display = "none";
        document.getElementById('tdtxtcarname').style.display = "none";
        document.getElementById('tdtype').style.display = "none";
        document.getElementById('tddrptyp').style.display = "none";
        document.getElementById('tdexdat').style.display = "none";
        
        

        document.getElementById('tdtxtexdat').style.display = "none";
        document.getElementById('tdcardno').style.display = "none";
        document.getElementById('tdtxtcarno').style.display = "none";

        //document.getElementById("txtreceipt").value = "";
        document.getElementById('cashrecvd').style.display = "none";
        // document.getElementById('tdcashrecvd').style.display="none";
        document.getElementById('drpcashrecieved').disabled = true;
        document.getElementById('txtcashdiscount').disabled = true;
    }
    else if (document.getElementById('drppaymode').value == "CA0") {
        document.getElementById('tdcarname').style.display = "none";
        document.getElementById('tdtxtcarname').style.display = "none";
        document.getElementById('tdtype').style.display = "none";
        document.getElementById('tddrptyp').style.display = "none";
        document.getElementById('tdexdat').style.display = "none";
      
        
        


        document.getElementById('lbtobil1').style.display = "none";
        document.getElementById('ttexttobil1').style.display = "none";

        document.getElementById('tdtxtexdat').style.display = "none";
        document.getElementById('tdcardno').style.display = "none";
        document.getElementById('tdtxtcarno').style.display = "none";

        document.getElementById('txtcardname').value = "";
        document.getElementById('drptype').value = "0";
        document.getElementById('drpmonth').value = "0";
        document.getElementById('drpyear').value = "0";
        document.getElementById('txtcardno').value = "";
        //document.getElementById("txtreceipt").value = "";

        document.getElementById('tdchqno').style.display = "none";
      //  document.getElementById('tdourbank').style.display = "none";
        document.getElementById('tdchqdate').style.display = "none";
        document.getElementById('tdchqamt').style.display = "none";
        document.getElementById('tdbankname').style.display = "none";

        document.getElementById('tdtextchqno').style.display = "none";
       // document.getElementById('tdtextourbank').style.display = "none";
        document.getElementById('tdtextchqdate').style.display = "none";
        document.getElementById('tdtextchqamt').style.display = "none";
        document.getElementById('tdtextbankname').style.display = "none";

        document.getElementById('ttextchqno').value = "";
        document.getElementById('ttextchqdate').value = "";
        document.getElementById('ttextchqamt').value = "";
        document.getElementById('ttextbankname').value = "";
       // document.getElementById('drpourbank').value = "0";
        document.getElementById('cashrecvd').style.display = "";
        //document.getElementById('tdcashrecvd').style.display="";
        document.getElementById('drpcashrecieved').disabled = false;
        document.getElementById('txtcashdiscount').disabled = false;
        
       /// document.getElementById('hiddenbillpay').value = document.getElementById('drppaymode').value;

    }
    else {
        document.getElementById('cashrecvd').style.display = "none";
        // document.getElementById('tdcashrecvd').style.display="none";
        document.getElementById('drpcashrecieved').disabled = true;
        document.getElementById('txtcashdiscount').disabled = true;
        document.getElementById('tdcarname').style.display = "none";
        document.getElementById('tdtxtcarname').style.display = "none";
        document.getElementById('tdtype').style.display = "none";
        document.getElementById('tddrptyp').style.display = "none";
        document.getElementById('tdexdat').style.display = "none";
        
document.getElementById('lbtobil1').style.display = "none";
        document.getElementById('ttexttobil1').style.display = "none";

        document.getElementById('tdtxtexdat').style.display = "none";
        document.getElementById('tdcardno').style.display = "none";
        document.getElementById('tdtxtcarno').style.display = "none";

        document.getElementById('txtcardname').value = "";
        document.getElementById('drptype').value = "0";
        document.getElementById('drpmonth').value = "0";
        document.getElementById('drpyear').value = "0";
        document.getElementById('txtcardno').value = "";
        //document.getElementById("txtreceipt").value = "";

        document.getElementById('tdchqno').style.display = "none";
       // document.getElementById('tdourbank').style.display = "none";
        document.getElementById('tdchqdate').style.display = "none";
        document.getElementById('tdchqamt').style.display = "none";
        document.getElementById('tdbankname').style.display = "none";

        document.getElementById('tdtextchqno').style.display = "none";
     //   document.getElementById('tdtextourbank').style.display = "none";
        document.getElementById('tdtextchqdate').style.display = "none";
        document.getElementById('tdtextchqamt').style.display = "none";
        document.getElementById('tdtextbankname').style.display = "none";

        document.getElementById('ttextchqno').value = "";
        document.getElementById('ttextchqdate').value = "";
        document.getElementById('ttextchqamt').value = "";
        document.getElementById('ttextbankname').value = "";
       // document.getElementById('drpourbank').value = "0";
        //document.getElementById('hiddenbillpay').value = document.getElementById('drppaymode').value;
    }
    if (cashdiscount == 'N') {
        document.getElementById('cashrecvd').style.display = "none";
        document.getElementById('drpcashrecieved').disabled = true;
        document.getElementById('txtcashdiscount').disabled = true;
    }
    else {
        document.getElementById('cashrecvd').style.display = "";
        document.getElementById('drpcashrecieved').disabled = false;
        document.getElementById('txtcashdiscount').disabled = false;
    }
    return false;
}


function ShowDiv() {
    if (document.getElementById('hdnbutton').value == "btnsavepay" || document.getElementById('hdnbutton').value == "btnSave") {
        document.getElementById('g1').style.display = 'block';
        document.getElementById('btnsubmit').click();

       
    }
    else {

        if (document.getElementById('txtvalidityfrom').value == "") {

            alert("Please Select Valid From Date  ")
            document.getElementById('txtvalidityfrom').focus();
            return false;
        }


        if (document.getElementById('txttilldate').value == "") 
        {

            alert("Please Select Valid To Date ")
            document.getElementById('txtvalidityfrom').focus();
            return false;



        }

        document.getElementById('g1').style.display = 'block';
        document.getElementById('btnsubmit').click();

    }
   



   
}


///////////////////add by anuja
function insertcashdetail1() {

    var temp;
    var pp;
    var ro;
    if (document.getElementById('drppaymode').value == "0") {


        alert("Please Select Paymode");
        document.getElementById('drppaymode').focus();
        return false;

    }

    var aa = document.getElementById('hdnlength').value;

    for (var i = 0; i <=aa; i++) {

        if (document.getElementById('chk' + i).checked == true) {
            bookid = document.getElementById('chk' + i).value;
            var res = cash_rcptformult.insertcashdetail1(bookid, document.getElementById('hdnbutton').value, document.getElementById('drppaymode').value);
            if (res.error != null) {
                alert(res.error.description);
            }
            if (res.value.Tables[0].Rows[0].RECPTNO != null && res.value.Tables[0].Rows[0].RECPTNO != "null")
                temp = res.value.Tables[0].Rows[0].RECPTNO;
            else
                temp = "";
            updatercpt1(temp);
            i = aa;
            // return false;

        }

    }
    document.getElementById('btnsubmit').click();

    document.getElementById('btnmodify').disabled = true;
    return false;

}

function updatercpt1(temp) {
    var kk = 0;
    var bookingid = "";

    var crdmnth = document.getElementById('drpmonth').value;
    var crdyear = document.getElementById('drpyear').value;
    var crdname = document.getElementById('txtcardname').value;
    var crdtype = document.getElementById('drptype').value;
    var crdnumber = document.getElementById('txtcardno').value;
    var chkno = document.getElementById('ttextchqno').value;
    var chkdate = document.getElementById('ttextchqdate').value;
    var chkamt = document.getElementById('ttextchqamt').value;
    var chkbankname = document.getElementById('ttextbankname').value;


    var billamt = 0;
    var grid = document.getElementById('DataGrid1');
    var aa = document.getElementById('hdnlength').value;
    for (var j = 0; j < aa; j++) {


        if (document.getElementById('chk' + j).checked == true) {

            amount = amount + parseFloat(grid.rows[j + 1].cells[8].innerHTML)

            kk = kk + 1;
            bookid = document.getElementById('chk' + j).value;
            ro = cash_rcptformult.updatero1(document.getElementById('hiddencompcode').value, document.getElementById('drppaymode').value, bookid, temp, crdmnth, crdyear, crdname, crdtype, crdnumber, chkno, chkdate, chkamt, chkbankname, document.getElementById('hdnbutton').value);
            bookingid += bookid + ",";
        }
    }

    amount = 0;
    document.getElementById('txtbillamt').value = amount;

    document.getElementById('drppaymode').value = "0";

    document.getElementById('view').style.display = "none";

    document.getElementById('txtcashdiscount').value = "";
    document.getElementById('drpcashrecieved').value = "";
    document.getElementById('txtcardname').value = "";
    document.getElementById('drptype').value = "0";
    document.getElementById('drpmonth').value = "0";
    document.getElementById('drpyear').value = "0";

    document.getElementById('txtcardno').value = "";
    document.getElementById('ttextchqno').value = "";
    document.getElementById('ttextchqamt').value = "";

    document.getElementById('ttextchqdate').value = "";
    document.getElementById('ttextbankname').value = "";
    printreceipt(temp, bookingid);
    //print_receipt(temp, bookingid)

    return false;

}

function print_receipt(receiptno, cioid) {
    var compcode = document.getElementById('hdncompcode').value;
    var dateformat = document.getElementById('hdndateformate').value;
    var printingname = document.getElementById('txtprint_cent').value;
    var branch = document.getElementById('dpbranch').value;
    var fromdate = document.getElementById('txtvalidityfrom').value;
    var todate = document.getElementById('txttilldate').value;
    var agency = document.getElementById('txtagency12').value;
    var adtype = document.getElementById('drpadtype').value;
    var executive = document.getElementById('txtexecutive').value;
    var coid = document.getElementById('txtbookingid').value;
    var adjusted = document.getElementById('drpadjusted').value;
    var amount = document.getElementById('txtbillamt').value;
    var agcode = document.getElementById('hdnagencytxt').value;
    var agsubcode = document.getElementById('hdnagsubcode').value;
    //var cioid = bookingid123;
    var ds_mode = "";
    var paymode = "";
    var recptno = receiptno;

    var cls_matter = "";
    // document.getElementById('btnsubmit').click();
    var lngth = cioid.split(',');
    //  document.getElementById('hdnlength').value = lngth.length;

    var ln = lngth.length; //document.getElementById('hdnlength').value;
    //var agency = document.getElementById('txtagency12').value;

    if (cioid != "") {
        if (ds_mode == undefined || ds_mode == "")
            window.open('Dainnik_receipt.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter + '&length=' + ln + "&printingname=" + printingname + "&branch=" + branch + "&fromdate=" + fromdate + "&todate=" + todate + "&agency=" + agency + "&coid=" + coid + "&adtype=" + adtype + "&executive=" + executive + "&adjusted=" + adjusted + "&amount=" + amount + "&compcode=" + compcode + "&dateformat=" + dateformat + "&agcode=" + agcode + "&agsubcode=" + agsubcode, '', 'width=700px,height=550px,resizable=1,left=0,top=0,scrollbars=yes');
        else {
            if (paymode == "Cash" || paymode == "CASH" || paymode == "cash")
                window.open('Dainnik_receipt.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter + '&length=' + ln, '', 'width=700px,height=550px,resizable=1,left=0,top=0,menubar=yes,scrollbars=yes');

            else
                window.open("Dainnik_receipt.aspx?printingname=" + printingname + "&branch=" + branch + "&fromdate=" + fromdate + "&todate=" + todate + "&agency=" + agency + "&adtype=" + adtype + "&executive=" + executive + "&coid=" + coid + "&adjusted=" + adjusted + "&amount=" + amount + "&compcode=" + compcode + "&dateformat=" + dateformat + "&agcode=" + agcode + "&agsubcode=" + agsubcode, "gaurav", "resizable=yes,scrollbars=yes,toolbar=yes,titlebar=yes,menubar=yes,status=yes");
        }
    }



    //Branchstrobj = Transfer_Entry_Form.BranchNameReturn(document.getElementById('hiddencompcode').value, drp_unit, drp_unit1);
    //Branchstr = Branchstrobj.value;


    return false;
}

