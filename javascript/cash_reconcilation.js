function openform() {
    var optn = document.getElementById("drpoptn").value;
    cash_reconcilation.setSessionmis_run(optn)
    window.open("cash_recon_form.aspx");
    return false;
}



