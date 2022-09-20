// JScript File

function printreceipt() {
    if (document.getElementById('txtciobookid').value != "")
        document.getElementById('hiddencioid').value = document.getElementById('txtciobookid').value;
    if (document.getElementById('hiddencioid').value == '')
        document.getElementById('hiddencioid').value = document.getElementById('txtciobookid').value;
    var cioid = document.getElementById('hiddencioid').value;
    var paymode = document.getElementById('hiddenpaymode').value;
    var clientname = document.getElementById('hiddenclientname').value;
    var compcode = document.getElementById('hiddencompcode').value;
    var rcptno = document.getElementById('hiddenreceiptno').value;
    var dateformate = document.getElementById('hiddendateformat').value;
    var usercode = document.getElementById('hiddenuserid').value;
    var ds_mode = "";
    if (clientname.indexOf("(") >= 0) {
        clientname = clientname.split("(");
        client_split = clientname[1];
        client_split = client_split.replace(")", "");
        clientname = client_split;
        ds_mode = Classified_Booking.getclientinfo(compcode, clientname);
    }
    else
        ds_mode = Classified_Booking.getclientinfo(compcode, clientname);

    //get compose matter for print on receipt
    var ds_matter = Classified_Booking.getMatterPreview(cioid);
    var cls_matter = "";
    if (ds_matter.value == null)
        cls_matter = "";
    else if (ds_matter.value.Tables[0].Rows[0] == undefined)
        cls_matter = "";
    else
        cls_matter = ds_matter.value.Tables[0].Rows[0].RTFformat;



    if (cioid != "") {
        var client = "";
        if (document.getElementById('hiddenclientname').value == "") {
            client = document.getElementById('txtclient').value;
        }
        else {
            client = document.getElementById('hiddenclientname').value;
        }
        var clientadd = "";
        if (document.getElementById('hiddenclientaddress').value == "") {
            document.getElementById('hiddenclientaddress').value = document.getElementById('txtclientadd').value;
        }
        clientadd = document.getElementById('hiddenclientaddress').value;
        var receiptno = document.getElementById('hiddenreceiptno').value;
        if (document.getElementById('txtreceipt').value != "") {
            receiptno = document.getElementById('txtreceipt').value;
        }
        // window.open("Receipt_Ht_Jab.aspx?cioid="+cioid+"&clientname="+client+"&clientadd="+clientadd+"&receiptno="+receiptno);//,'','width=1000px,height=550px,resizable=1,left=0,top=0,scrollbars=yes');
        var quotation = document.getElementById('hiddenquotation').value;
        if (clientfromconfig == "SP") {

            if (quotation == 'Q') {
                var mainbookingid = cioid;
                if (ds_mode == undefined || ds_mode == "")
                    window.open('quotationprint_nam.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter + '&mainbookingid=' + mainbookingid + '&quotation=' + quotation + '&dateformate=' + dateformate + '&usercode=' + usercode + '&compcode=' + compcode, '', 'width=700px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
                else {
                    if (paymode == "Cash" || paymode == "CASH" || paymode == "cash")
                        window.open('quotationprint_nam.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter + '&mainbookingid=' + mainbookingid + '&quotation=' + quotation + '&dateformate=' + dateformate + '&usercode=' + usercode + '&compcode=' + compcode, '', 'width=700px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
                    else
                        window.open('quotationprint_nam.aspx?cioid=' + cioid + '&rcptno=' + rcptno + '&mainbookingid=' + mainbookingid + '&quotation=' + quotation + '&dateformate=' + dateformate + '&usercode=' + usercode + '&compcode=' + compcode, '', 'width=700px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
                }

            }
            else {
                var formname = "BOOKING ORDER";
                if (ds_mode == undefined || ds_mode == "")
                    window.open('allbookingreceipt_nam.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter + '&formname=' + formname + '&dateformate=' + dateformate + '&usercode=' + usercode + '&compcode=' + compcode + '&clientcode=' + clientfromconfig, '', 'width=700px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
                else {
                    if (paymode == "Cash" || paymode == "CASH" || paymode == "cash")
                        window.open('allbookingreceipt_nam.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter + '&formname=' + formname + '&dateformate=' + dateformate + '&usercode=' + usercode + '&compcode=' + compcode + '&clientcode=' + clientfromconfig, '', 'width=700px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
                    else
                        window.open('allbookingreceipt_nam.aspx?cioid=' + cioid + '&rcptno=' + rcptno + '&formname=' + formname + '&dateformate=' + dateformate + '&usercode=' + usercode + '&compcode=' + compcode + '&clientcode=' + clientfromconfig, '', 'width=700px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
                }



            }

        }
        else {
            if (ds_mode == undefined || ds_mode == "") {
                window.open('classifiedreceipt_bill.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter, '', 'width=700px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
            }
            else {
                if (paymode == "Cash" || paymode == "CASH" || paymode == "cash") {
                    window.open('classifiedreceipt_bill.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter, '', 'width=700px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
                }
                else {
                    window.open('Receiptonly.aspx?cioid=' + cioid + '&rcptno=' + rcptno + '&compcode=' + compcode, '', 'width=700px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
                }
            }
        }
    }
    else {
        alert("Please get the Booking id");
    }
    return false;
}

// JScript File

function printreceipt_display() {
    if (document.getElementById('hiddencioid').value == '')
        document.getElementById('hiddencioid').value = document.getElementById('txtciobookid').value;
    var cioid = document.getElementById('hiddencioid').value;
    var paymode = document.getElementById('hiddenpaymode').value;
    var clientname = document.getElementById('hiddenclientname').value;
    var compcode = document.getElementById('hiddencompcode').value;
    var rcptno = document.getElementById('hiddenreceiptno').value;
    var dateformate = document.getElementById('hiddendateformat').value;
    var usercode = document.getElementById('hiddenuserid').value;
    // var clientcd=document.getElementById('').value;
    var ds_mode = "";
    var cls_matter = "";
    if (clientname.indexOf("(") >= 0) {
        clientname = clientname.split("(");
        client_split = clientname[1];
        client_split = client_split.replace(")", "");
        clientname = client_split;
        ds_mode = Booking_master.getclientinfo(compcode, clientname);
    }
    else
        ds_mode = Booking_master.getclientinfo(compcode, clientname);

    if (cioid != "") {
        var quotation = document.getElementById('hiddenquotation').value;
        if (clientfromconfig == "SP") {

            if (quotation == 'Q') {
                var mainbookingid = cioid;
                if (ds_mode == undefined || ds_mode == "")
                    window.open('quotationprint_nam.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter + '&mainbookingid=' + mainbookingid + '&quotation=' + quotation + '&dateformate=' + dateformate + '&usercode=' + usercode + '&compcode=' + compcode, '', 'width=800px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
                else {
                    if (paymode == "Cash" || paymode == "CASH" || paymode == "cash")

                        window.open('quotationprint_nam.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter + '&mainbookingid=' + mainbookingid + '&quotation=' + quotation + '&dateformate=' + dateformate + '&usercode=' + usercode + '&compcode=' + compcode, '', 'width=800px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
                    else

                        window.open('quotationprint_nam.aspx?cioid=' + cioid + '&rcptno=' + rcptno + '&mainbookingid=' + mainbookingid + '&quotation=' + quotation + '&dateformate=' + dateformate + '&usercode=' + usercode + '&compcode=' + compcode, '', 'width=730px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
                }
            }
            else {
                var formname = "BOOKING ORDER";
                if (ds_mode == undefined || ds_mode == "")
                    window.open('allbookingreceipt_nam.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter + '&formname=' + formname + '&dateformate=' + dateformate + '&usercode=' + usercode + '&compcode=' + compcode + '&clientcode=' + clientfromconfig, '', 'width=800px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
                else {
                    if (paymode == "Cash" || paymode == "CASH" || paymode == "cash")

                        window.open('allbookingreceipt_nam.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter + '&formname=' + formname + '&dateformate=' + dateformate + '&usercode=' + usercode + '&compcode=' + compcode + '&clientcode=' + clientfromconfig, '', 'width=800px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
                    else

                        window.open('allbookingreceipt_nam.aspx?cioid=' + cioid + '&rcptno=' + rcptno + '&formname=' + formname + '&dateformate=' + dateformate + '&usercode=' + usercode + '&compcode=' + compcode + '&clientcode=' + clientfromconfig, '', 'width=730px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
                }


            }

        }
        else {
            if (ds_mode == undefined || ds_mode == "") {
                window.open('classifiedreceipt_bill.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter, '', 'width=800px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
            }
            else {
                if (paymode == "Cash" || paymode == "CASH" || paymode == "cash")
                    window.open('classifiedreceipt_bill.aspx?cioid=' + cioid + '&clsmatter=' + cls_matter, '', 'width=800px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');

                else
                    window.open('Receiptonly.aspx?cioid=' + cioid + '&rcptno=' + rcptno + '&compcode=' + compcode, '', 'width=730px,height=550px,resizable=1,left=0,top=0,scrollbars=yes,menubar=yes');
            }
        }
    }
    else {
        alert("Please get the Booking id");
    }
    return false;
}