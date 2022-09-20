function ok() {
    if (document.getElementById('ttextchqno').value == "") {
        alert("Please Enter Cheque No.");
        document.getElementById('ttextchqno').focus();
        return false;
    }

        if (document.getElementById('txtdummydate').value == "") {
            alert("Please Enter Cheque Date");
            document.getElementById('txtdummydate').focus();
            return false;
        }
 
        if (document.getElementById('ttextbankname').value == "") {
            alert("Please Enter Bank Name");
            document.getElementById('ttextbankname').focus();
            return false;
        }
   
    window.opener.document.getElementById('hiddenchequeno').value = document.getElementById('ttextchqno').value;
    window.opener.document.getElementById('hiddenchequedate').value = document.getElementById('txtdummydate').value;
    window.opener.document.getElementById('hiddenbankname').value = document.getElementById('ttextbankname').value;
    window.opener.document.getElementById('hdnflagdetail').value = "true";
    window.close();
    return false;
}