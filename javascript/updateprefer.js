// JScript File for preference

var browser = navigator.appName;

function datesave()
{
/*if(document.getElementById('hdntdsnametype').value=="")
{
alert('Please select by f2 Assesy Type For Retainer Comm');
document.getElementById('txttdsnametype').value="";
return false;
}
if(document.getElementById('hdntdssecname').value=="")
{
alert('Please select by f2 Sec Code For Retainer Comm');
document.getElementById('txtTdsSecName').value="";
return false;
}*/


var insdate="";
var agencycomm="";

var compcode=document.getElementById('hiddencode').value;
var userid=document.getElementById('hiddenuserid').value;
var dateformat=document.getElementById('drpdateformat').value;
var code=document.getElementById('drpcodetype').value;
var curr=document.getElementById('drpcurr').value;
var ratecode=document.getElementById('drprategroup').value;
var checkrate=document.getElementById('drpcheckrate').value;
var breakup=document.getElementById('drpbreakup').value;
var bwcode=document.getElementById('txtbwcode').value;
var filename=document.getElementById('drpfilename').value;
var tfn=document.getElementById('txttfn').value;
var insbreak=document.getElementById('drpinsbreak').value;
var prem=document.getElementById('drppremtype').value;
var dealtype=document.getElementById('drpdealtype').value;
var RO_OUTSTAND_P=document.getElementById('DRPRO_OUTSTAND_P').value;


 var pre=document.getElementById('txtprefix').value;
var suff=document.getElementById('txtsuffix').value;
var chkfinancestatus=document.getElementById('chkfinance').checked;

var ratecomp=document.getElementById('drpratecompany').value;
var dayrate=document.getElementById('drpdayrate').value;
/*Changes by Manish for audit*/
var audit=document.getElementById('drpaudit').value;
var chkval= document.getElementById("txtcut").value
var repeatday = document.getElementById("drprepeatingdaytype").value;
var premiumedit = document.getElementById("drpeditableintransaction").value;




/***********/

/*Changes by Manish for Insert Date*/
if(document.getElementById('chkinsertdate').checked)
    insdate="y";
else
    insdate="n";
/***********/

/*Changes by Manish for Insert Date*/
if(document.getElementById('chkagencycomm').checked)
    agencycomm="y";
else
    agencycomm="n";
/***********/


pre=trim(pre);
suff=trim(suff);



if(chkfinancestatus==true)
   {
    chkfinancestatus="Y";
   }
else
{
  chkfinancestatus="N";

}
 
chkfinancestatus=trim(chkfinancestatus);

var voucherst=document.getElementById('drpvoucherst').value;


voucherst=trim(voucherst);

/////////this is to get the Ad category list box value 

                            var objpack=document.getElementById('drpadcat');
                            var temp="";
                            var tempcode="";
                            var tempval="";
                            var tempvalcode="";
                       
                            var adcode="";
                            var i=objpack.options.length;
                            var j;

                                for(j=0;j<i;j++)
                                {
                                    if(parseInt(i)>0)
                                    {
                                        tempval=objpack[j].value;
                                        //tempvalcode=objpack[j].value;
                                        
                                        if(objpack[j].selected==true)
                                        {
                                                if(temp!="")
                                                {
                                                    temp=tempval;
                                                    tempvalcode=temp;
                                                   
                                                    adcode=tempvalcode+","+adcode;
                                                   
                                                    
                                                    
                                                }
                                                else
                                                {
                                                    temp=tempval;
                                                    tempvalcode=temp;
                                                 
                                                    adcode=tempvalcode;
                                                   
                                                }
                                                
                                        }
                                    }
                                
                                }



var rodatetime=document.getElementById('drprodatetime').value;
var spacearea=document.getElementById('drpspacearea').value;
var vat=document.getElementById('drpvat').value;
var bookstat=document.getElementById('drpbookingstat').value;
var cio_id=document.getElementById('drpcioid').value;
var receipt_no=document.getElementById('drpreceipt').value;
//


/*new change ankur*/
var uom=document.getElementById('drpuom').value;
var bgcolor=document.getElementById('drpbg').value;
var validdates=document.getElementById('drpvalid').value;
//////////////////////////////////////////////////////////

/*new change ankur for agency*/
var agencyratecode=document.getElementById('drpageratecode').value;

var rateaudit=document.getElementById('drprateaudit').value;
var billaudit=document.getElementById('drpbillaudit').value;
var billtype=document.getElementById('drpbilledtype').value;
var invoice_no=document.getElementById('drpinvoice').value;


// new changes for billing

var displaybilltype=document.getElementById('drpdisplaybillnew').value;
var classifiedbilltype=document.getElementById('drpclassifiedbill').value;
var billform=document.getElementById('drpbillformat').value;
var rateck=document.getElementById('drpratechk').value;
var allpakg=document.getElementById('drpallpkg').value;


var rostatus;
if(document.getElementById('chbres').checked==true)
{
rostatus="1";
}
else
{
rostatus="0";
}

var copybooking=document.getElementById('drpcopybooking').value;
var addagencycomm=document.getElementById('drpagncomm').value;
var agbretainercomm=document.getElementById('drpagnlinkretainer').value;
var subrate=document.getElementById('drpsubrate').value;

var Includeclassi=document.getElementById('drpIncludeClassi').value;

var Receipt_format=document.getElementById('drp_receiptformat').value;

var cash_receipt=document.getElementById('drpcashreceipt').value;

var bill_orderwiselast=document.getElementById('drp_billorderwiselast').value;

var floor_chk=document.getElementById('drpfloor').value;
/*new change for circulation*/

var Unsoldflag=document.getElementById('drpUEF').value;
var Supplystopper=document.getElementById('txtSSP').value;
var drpRokeychk=document.getElementById('drprokey').value;

var Agencycomm_seq=document.getElementById('drpagencycomm').value;
var creditreciept=document.getElementById('drpcreditrecpt').value;
var dockitbooking=document.getElementById('drpdockitbooking').value;
/*new change ankur for agency*/
var schemetype=document.getElementById('drpscheme').value;

var cashindisplay=document.getElementById('drpinclcashdisp').value;
var cashinclassified=document.getElementById('drpinclcashcls').value;
var rate_audit_pref=document.getElementById('drprateaudit_pref').value;

var barcoding_allow = document.getElementById('drpbarcode').value;
var fmgbills=document.getElementById('drpfmgbills').value;


var billed_cashdis=document.getElementById('drp_billdisp_ca').value;
var billed_cashcls=document.getElementById('drp_billcls_ca').value;
var approval=document.getElementById('drpapproval').value;
var packegeentry=document.getElementById('txtpackegeentry').value;


var v_drpbackdate=document.getElementById('drpbackdate').value;
var allowprevbooking=document.getElementById('drpallowprevbooking').value;
var cash_billtype=document.getElementById('drp_cashbill').value;
var cash_disc=document.getElementById('drpcashdis').value;
var cash_amt=document.getElementById('txtcsamt').value;
 var seperate_cashier=document.getElementById('drpsep_rate').value;  
 var disp_bill=document.getElementById('drpdispbillcr').value;
 var clas_bill=document.getElementById('drpclasbillcr').value;
 var mantimepost=document.getElementById('drpmtpostallow').value;
 var bkdaypost=document.getElementById('txtbkpost').value;
 var maxterutn=document.getElementById('txtmaxret').value;
 var cir_return=document.getElementById('txtreturn').value;
 var noofchkbounc=document.getElementById('txtchkbounce').value;
 var noofdaychkrec=document.getElementById('txtchkreceive').value;
 var retday=document.getElementById('txtreturndate').value;
 var chngsuppord=document.getElementById('txtchgsupporder').value;
 var max_publishday=document.getElementById('txtmaxpubday').value; 
 var billno_period=document.getElementById('drpbill_periodicity').value;     
 var spl_trans_edit=document.getElementById('drpspl_trans_edit').value; 
 var spl_dis_trans_editable=document.getElementById('drpspl_dis_trans_editable').value; 
 var mul_pac_sel_trans=document.getElementById('drpmul_pac_sel_trans').value; 
 var shmon_minword=document.getElementById('drpshmon_minword').value; 
 var tradon_spcrg=document.getElementById('drptradon_spcrg').value; 
 var rateauth=document.getElementById('drprateaut').value; 
 var f2day=document.getElementById('txtf2day').value; 
 var rateauditmodify=document.getElementById('drprateaudit_modify').value;
 var bindrevenuecenter = document.getElementById('drpbindrevenuecenter').value;
 
 
 // for receipt entry in collection 
 
  var led_allow=document.getElementById('drp_led_allow').value; 
 var clear_allow=document.getElementById('drp_clear_allow').value;
 /////pam
 var paging = document.getElementById('txtpaging').value;
   var print = document.getElementById('txtprint').value;
   
   
   ////
   var allowpage=document.getElementById('Drophead').value;
  
   
   var agency=document.getElementById('drpagency').value;
   var region=document.getElementById('drpregion').value;
   
   if(agency=="0" && region=="0")
   {
     agency="M";
     region="NE"
   }
  






  //FOR BILLING 
  
 var BILL_GENERATION=document.getElementById('drp_genratebill').value; 
 var PUBLICATION_CENTER=document.getElementById('drp_publication').value;       
 
 //for booking
  var chq_clearence=document.getElementById('drp_retainer_bank').value;
  
  
 var allow_discount_prem=document.getElementById('drpallow_prem').value;       
 
 var  billing_scheme = document.getElementById('drp_scheme_billing').value;
 
 
 var  ALLOW_PDC=document.getElementById('txt_allowed_cdp').value;
 
 var ad_type_for_manul_bill=document.getElementById('drp_adtype').value;
 
 var genrate_agency_code=document.getElementById('drpgencycodegeneration').value;
 var aotosupply=document.getElementById('drpAutosupplypostingrequired').value;
 var dispauditbk=document.getElementById('drpdispauditbk').value;
  var Authorization =document.getElementById('drpAuthorization').value;
  
  var UNSOLDAPPROVAL=document.getElementById('drpUNSOLDAPPROVAL').value;
 
 var UNSOLDPHYSICAL=document.getElementById('drpUNSOLDPHYSICAL').value;
 var INCLUDEUNSOLD=document.getElementById('drpINCLUDEUNSOLD').value;
 var INCLUDEUNSOLDININSERTIONFEEPROCESS=document.getElementById('drpINCLUDEUNSOLDININSERTIONFEEPROCESS').value;
  var UNSOLDONSUPPLYORRECEIVEDDATE =document.getElementById('drpUNSOLDONSUPPLYORRECEIVEDDATE').value;
  var Agencyunblockapproval=document.getElementById('drpAgencyunblockapproval').value;
 var UnblockApprovalOutsideCreditLimit=document.getElementById('drpUnblockApprovalOutsideCreditLimit').value;
  var billingpublicationwise =document.getElementById('drpbillingpublicationwise').value;
    var ALLOW_FOLLOW_DT_BOOOK= document.getElementById('drpALLOW_FOLLOW_DT_BOOOK').value; 
    var subscription_paid_supply_type= document.getElementById('drpsubscription_paid_supply_type').value;
    var subscription_free_supply_type= document.getElementById('drpsubscription_free_supply_type').value;
    var CURRENCY_MEASUREMENT = document.getElementById('drpCURRENCY_MEASUREMENT').value;
  
    var drpadddiscount = document.getElementById('drpadddiscount').value;
    var cancharges = document.getElementById('drpcancharges').value;
    var entry_type = document.getElementById('drpentry_type').value;
    var ApprovalWith = document.getElementById('drpApprovalWith').value;
    var Auto_TDS_Credit_Note = document.getElementById('drpAuto_TDS_Credit_Note').value;
    if (document.getElementById('drpAuto_TDS_Credit_Note').value == "Y") {
        if (document.getElementById('txtTDS_Reason').value == "") {
            alert("Please Enter TDS Reason")
            document.getElementById('txtTDS_Reason').focus();
            return false;
        }



        if (document.getElementById('txtDebit_Account_Head').value == "") {
            alert("Please Enter Debit Account Head")
            document.getElementById('txtDebit_Account_Head').focus();
            return false;
        }

        if (document.getElementById('txtcredit_Account_Head').value == "") {
            alert("Please Enter Credit Account Head")
            document.getElementById('txtcredit_Account_Head').focus();
            return false;
        }
        var TDS_Reason = document.getElementById('txtTDS_Reason').value;
        var res = updateprefer.getresoname(document.getElementById('hiddencode').value, TDS_Reason.toUpperCase())
        if (res.value == "" || res.value == null) {

            alert("TDS Reason Code Entered By You Is Not Present In DataBase")
            document.getElementById('txtTDS_Reason').focus();
            document.getElementById('txtTDS_Reason').value = "";
            return false;
        }
        
        var Debit_Account_Head = document.getElementById('txtDebit_Account_Head').value;
        var res = updateprefer.getaccountna(document.getElementById('hiddencode').value, Debit_Account_Head.toUpperCase())
        if (res.value == "" || res.value == null) {

            alert("Debit Account Head Entered By You Is Not Present In DataBase")
            document.getElementById('txtDebit_Account_Head').focus();
            document.getElementById('txtDebit_Account_Head').value = "";
            return false;
        }
        
        var credit_Account_Head = document.getElementById('txtcredit_Account_Head').value;
    }
    else {
        var TDS_Reason = document.getElementById('txtTDS_Reason').value;
        var Debit_Account_Head = document.getElementById('txtDebit_Account_Head').value;
        var credit_Account_Head = document.getElementById('txtcredit_Account_Head').value;
    }





    var service_tax_credit_note = document.getElementById('drpauto_service_tax_credit_note').value;

    if (document.getElementById('drpauto_service_tax_credit_note').value == "Y") {
        if (document.getElementById('txtTax_Reason').value == "") {
            alert("Please Enter Service Tax Reason Code")
            document.getElementById('txtTax_Reason').focus();
            return false;
        }



        if (document.getElementById('txtDebit_Account_Head_For_Service_Tax').value == "") {
            alert("Please Enter Debit Account Head For Service Tax")
            document.getElementById('txtDebit_Account_Head_For_Service_Tax').focus();
            return false;
        }

        if (document.getElementById('txtCredit_Account_Head_For_Service_Tax').value == "") {
            alert("Please Enter Credit Account Head For Service Tax")
            document.getElementById('txtCredit_Account_Head_For_Service_Tax').focus();
            return false;
        }

        var Tax_Reason = document.getElementById('txtTax_Reason').value;

        var res = updateprefer.getresoname(document.getElementById('hiddencode').value, Tax_Reason.toUpperCase())
        if (res.value == "" || res.value == null) {

            alert("Service Tax Reason Code Entered By You Is Not Present In DataBase")
            document.getElementById('txtTax_Reason').focus();
            document.getElementById('txtTax_Reason').value = "";
            return false;
        }
        
        
        
        var Debit_Account_Service_Tax = document.getElementById('txtDebit_Account_Head_For_Service_Tax').value;

        var res = updateprefer.getaccountna(document.getElementById('hiddencode').value, Debit_Account_Service_Tax.toUpperCase())
        if (res.value == "" || res.value == null) {

            alert("Debit Account Head For Service Tax Entered By You Is Not Present In DataBase")
            document.getElementById('txtDebit_Account_Head_For_Service_Tax').focus();
            document.getElementById('txtDebit_Account_Head_For_Service_Tax').value = "";
            return false;
        }
        
        
        var Credit_Account_Service_Tax = document.getElementById('txtCredit_Account_Head_For_Service_Tax').value;
    }
    else {

        var Tax_Reason = document.getElementById('txtTax_Reason').value;
        var Debit_Account_Service_Tax = document.getElementById('txtDebit_Account_Head_For_Service_Tax').value;
        var Credit_Account_Service_Tax = document.getElementById('txtCredit_Account_Head_For_Service_Tax').value;
    }
    var Auto_Patrakar_Credit_Note = document.getElementById('drpAuto_Patrakar_Kalyan_Kosh_Credit_Note').value;

    if (document.getElementById('drpAuto_Patrakar_Kalyan_Kosh_Credit_Note').value == "Y") {
        if (document.getElementById('txtPatrakar_Kalyan_Kosh_Reason').value == "") {
            alert("Please Enter Patrakar Kalyan Kosh Reason")
            document.getElementById('txtPatrakar_Kalyan_Kosh_Reason').focus();
            return false;
        }



        if (document.getElementById('txtDebit_Account_Head_For_Patrakar_Kalyan_Kosh').value == "") {
            alert("Please Enter Debit Account Head For Patrakar Kalyan Kosh")
            document.getElementById('txtDebit_Account_Head_For_Patrakar_Kalyan_Kosh').focus();
            return false;
        }

        if (document.getElementById('txtCredit_Account_Head_For_Patrakar_Kalyan_Kosh').value == "") {
            alert("Please Enter Credit Account Head For Patrakar Kalyan Kosh")
            document.getElementById('txtCredit_Account_Head_For_Patrakar_Kalyan_Kosh').focus();
            return false;
        }
        var Patrakar_Reason = document.getElementById('txtPatrakar_Kalyan_Kosh_Reason').value;
        var res = updateprefer.getresoname(document.getElementById('hiddencode').value, Patrakar_Reason.toUpperCase())
        if (res.value == "" || res.value == null) {

            alert("Patrakar Kalyan Kosh Reason Code Entered By You Is Not Present In DataBase")
            document.getElementById('txtPatrakar_Kalyan_Kosh_Reason').focus();
            document.getElementById('txtPatrakar_Kalyan_Kosh_Reason').value = "";
            return false;
        }
        
        
        var Debit_Account_Head_For_Patrakar = document.getElementById('txtDebit_Account_Head_For_Patrakar_Kalyan_Kosh').value;


        var res = updateprefer.getaccountna(document.getElementById('hiddencode').value, Debit_Account_Head_For_Patrakar.toUpperCase())
        if (res.value == "" || res.value == null) {

            alert("Debit Account Head For Patrakar Kalyan Kosh Entered By You Is Not Present In DataBase")
            document.getElementById('txtDebit_Account_Head_For_Patrakar_Kalyan_Kosh').focus();
            document.getElementById('txtDebit_Account_Head_For_Patrakar_Kalyan_Kosh').value = "";
            return false;
        }
        
        
        var Credit_Account_Head_For_Patrakar = document.getElementById('txtCredit_Account_Head_For_Patrakar_Kalyan_Kosh').value;
    }
    else {
        var Patrakar_Reason = document.getElementById('txtPatrakar_Kalyan_Kosh_Reason').value;
        var Debit_Account_Head_For_Patrakar = document.getElementById('txtDebit_Account_Head_For_Patrakar_Kalyan_Kosh').value;
        var Credit_Account_Head_For_Patrakar = document.getElementById('txtCredit_Account_Head_For_Patrakar_Kalyan_Kosh').value;
    }

    var Auto_Bank_Credit_Note = document.getElementById('drpAuto_Bank_Charges_Credit_Note').value;

    if (document.getElementById('drpAuto_Bank_Charges_Credit_Note').value == "Y") {
        if (document.getElementById('txtBank_Charges_Reason').value == "") {
            alert("Please Enter Bank Charges Reason")
            document.getElementById('txtBank_Charges_Reason').focus();
            return false;
        }



        if (document.getElementById('txtDebit_Account_Head_For_Bank_Charges').value == "") {
            alert("Please Enter Debit Account Head For Bank Charges")
            document.getElementById('txtDebit_Account_Head_For_Bank_Charges').focus();
            return false;
        }

        if (document.getElementById('txtCredit_Account_Head_For_Bank_Charges').value == "") {
            alert("Please Enter Credit Account Head For Bank Charges")
            document.getElementById('txtCredit_Account_Head_For_Bank_Charges').focus();
            return false;
        }

        var Bank_Reason = document.getElementById('txtBank_Charges_Reason').value;
        var res = updateprefer.getresoname(document.getElementById('hiddencode').value, Bank_Reason.toUpperCase())
        if (res.value == "" || res.value == null) {

            alert("Bank Charges Reason Code Entered By You Is Not Present In DataBase")
            document.getElementById('txtBank_Charges_Reason').focus();
            document.getElementById('txtBank_Charges_Reason').value = "";
            return false;
        }
        
        
        var Debit_Account_Bank = document.getElementById('txtDebit_Account_Head_For_Bank_Charges').value;
        var res = updateprefer.getaccountna(document.getElementById('hiddencode').value, Debit_Account_Bank.toUpperCase())
        if (res.value == "" || res.value == null) {

            alert("Debit Account Head For Bank Charges Entered By You Is Not Present In DataBase")
            document.getElementById('txtDebit_Account_Head_For_Bank_Charges').focus();
            document.getElementById('txtDebit_Account_Head_For_Bank_Charges').value = "";
            return false;
        }
        
        
        
        
        var Credit_Account_Bank = document.getElementById('txtCredit_Account_Head_For_Bank_Charges').value;
    }
    else {

        var Bank_Reason = document.getElementById('txtBank_Charges_Reason').value;
        var Debit_Account_Bank = document.getElementById('txtDebit_Account_Head_For_Bank_Charges').value;
        var Credit_Account_Bank = document.getElementById('txtCredit_Account_Head_For_Bank_Charges').value;
    }
    var BARCODE = document.getElementById('drp_barcode').value;
    var WEIGHT_CAL = document.getElementById('drpweightcal').value;
    var GEN_RCT_TYP = document.getElementById('drpgenerate_recipt_no').value;
    var misdata = document.getElementById("drp_misdata").value;
    var allowpremium = document.getElementById("drpallowpremium").value;
    var financecode = document.getElementById("drpfinancecode").value;
    var executivepub = document.getElementById("drpexecutive").value;
    var mrv = document.getElementById("drpmrv").value;
    var fixed_tran_amt=document.getElementById("txtfxd_tran_amt").value;
    var trade_dis_based= document.getElementById("drptradedis").value;



    var executivecreditlimit = document.getElementById("drpexec").value;

    var ret = document.getElementById("retno").value;
    
    var bankrecorequired=document.getElementById("drpbankkreco").value;
    

    var retcomm = document.getElementById("drpretcomm").value;
    var supplbill = document.getElementById("drpsuppbill").value;
    var tdstypname = document.getElementById("txttdsnametype").value;
    var tdssecname = document.getElementById("txtTdsSecName").value;
    
    var txtretonoverdue=document.getElementById("txtretonoverdue").value;
    var txtdoconoverdue=document.getElementById("txtdoconoverdue").value;
    var drpallowbooking=document.getElementById("drpallowbooking").value;
    var drpchkfordupreq=document.getElementById("drpchkfordupreq").value;
    var alowwithutro=document.getElementById("ddlwithutro").value;
    var commonfrid=document.getElementById("drpcommongrid").value;
    var drpreciptno = document.getElementById("drpreciptno").value;
    var drpret_exec = document.getElementById("drpret_exec").value;
    var drpcashrecacc = document.getElementById("drpcashrecacc").value;
    
    ///add by anuja for agreed rate check
 var daysbook = document.getElementById("txtdaybookagr").value;


//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
//                    if(browser!="Microsoft Internet Explorer")
//                    {
//                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
//                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       }

       var txtvalue = document.getElementById('Textvalue').value;
       
       
       var flag1;
       var flag=document.getElementById('txtflag').value;
       if(flag=="Y")
       {
      flag1 =document.getElementById('txtflag').value;
       }
       else
       {
       flag1 =document.getElementById('txtflag').value;
       }


       updateprefer.chkprefer(compcode, userid, dateformat, code, curr, ratecode, checkrate, breakup, bwcode, rostatus, filename, tfn, insbreak, prem, dealtype, pre, suff, chkfinancestatus, voucherst, adcode, rodatetime, spacearea, vat, bookstat, cio_id, receipt_no, uom, bgcolor, validdates, agencyratecode, audit, insdate, agencycomm, rateaudit, billaudit, billtype, invoice_no, copybooking, ratecomp, addagencycomm, agbretainercomm, subrate, displaybilltype, classifiedbilltype, billform, rateck, allpakg, dayrate, schemetype, Includeclassi, Receipt_format, cash_receipt, bill_orderwiselast, floor_chk, Unsoldflag, Supplystopper, drpRokeychk, Agencycomm_seq, creditreciept, cashindisplay, cashinclassified, rate_audit_pref, barcoding_allow, fmgbills, billed_cashdis, billed_cashcls, v_drpbackdate, dockitbooking, allowprevbooking, chkval, cash_billtype, approval, packegeentry, cash_disc, cash_amt, seperate_cashier, disp_bill, clas_bill, mantimepost, bkdaypost, maxterutn, cir_return, noofchkbounc, noofdaychkrec, retday, chngsuppord, max_publishday, billno_period, spl_trans_edit, spl_dis_trans_editable, mul_pac_sel_trans, shmon_minword, tradon_spcrg, rateauth, f2day, rateauditmodify, bindrevenuecenter, led_allow, clear_allow, repeatday, premiumedit, BILL_GENERATION, PUBLICATION_CENTER, allow_discount_prem, billing_scheme, ALLOW_PDC, ad_type_for_manul_bill, RO_OUTSTAND_P, genrate_agency_code, dispauditbk, aotosupply, Authorization, UNSOLDAPPROVAL, UNSOLDPHYSICAL, INCLUDEUNSOLD, INCLUDEUNSOLDININSERTIONFEEPROCESS, UNSOLDONSUPPLYORRECEIVEDDATE, Agencyunblockapproval, UnblockApprovalOutsideCreditLimit, billingpublicationwise, ALLOW_FOLLOW_DT_BOOOK, paging, print, allowpage, agency, region, subscription_paid_supply_type, subscription_free_supply_type, CURRENCY_MEASUREMENT, drpadddiscount, cancharges, entry_type, ApprovalWith, Auto_TDS_Credit_Note, TDS_Reason, Debit_Account_Head, credit_Account_Head, service_tax_credit_note, Tax_Reason, Debit_Account_Service_Tax, Credit_Account_Service_Tax, Auto_Patrakar_Credit_Note, Patrakar_Reason, Debit_Account_Head_For_Patrakar, Credit_Account_Head_For_Patrakar, Auto_Bank_Credit_Note, Bank_Reason, Debit_Account_Bank, Credit_Account_Bank, BARCODE, WEIGHT_CAL, GEN_RCT_TYP, misdata, allowpremium, financecode, executivepub, executivecreditlimit, mrv, chq_clearence, fixed_tran_amt, trade_dis_based, retcomm, supplbill, tdstypname, tdssecname, ret, bankrecorequired, txtretonoverdue, txtdoconoverdue, drpallowbooking, drpchkfordupreq, alowwithutro, commonfrid, drpreciptno, txtvalue, flag1, drpret_exec,drpcashrecacc,daysbook,callbak_datedave);

return false;
}
function changefun()
{
  if(document.getElementById('drpagency').value=="M")
  document.getElementById('drpregion').value="NE";
  if(document.getElementById('drpagency').value=="N")
  document.getElementById('drpregion').value="E";
  return false;
}

function change_regfun()
{
  if(document.getElementById('drpregion').value=="E")
  document.getElementById('drpagency').value="N";
  if(document.getElementById('drpregion').value=="NE")
  document.getElementById('drpagency').value="M";
  return false;
}

function show_supply_div(special_variable)
{

document.getElementById('hdsviewgrid1').style.display="block";
document.getElementById('hdsviewgrid').style.display="block";

//document.getElementById('hdsviewgrid1_growth').style.display="none";
//document.getElementById('hdsviewgrid1_growth_data').style.display="none";

var buf = new StringBuffer();
var aa="";
var buf1 = new StringBuffer();
var aa1="";
var hs =0;
var hs1 =0;


}


function callbak_datedave(res)
{
var ds=res.value;
if(ds=="N")
{
alert("Data Saved Successfully");
return false;
}
else
{
alert("Data Updated Successfully");
return false;
}
return false;

}


function changevis(opendiv)
{

if(opendiv=="general1")
{
            document.getElementById('lblgeneral').disabled=false;
            document.getElementById('lbladvertisement').disabled=true;
            document.getElementById('lbladbilling').disabled=true;
            document.getElementById('lbladaccount').disabled=true;
            document.getElementById('lblcirculation').disabled=true;
            document.getElementById('lblfinance').disabled=true;
            document.getElementById('lblpayroll').disabled=true; 
            document.getElementById('lblnewsprint').disabled=true;
            document.getElementById('lblstores').disabled=true;
return false;
}


else if(opendiv=="advertisement1")
{
            document.getElementById('lblgeneral').disabled=true;
            document.getElementById('lbladvertisement').disabled=false;
            document.getElementById('lbladbilling').disabled=true;
            document.getElementById('lbladaccount').disabled=true;
            document.getElementById('lblcirculation').disabled=true;
            document.getElementById('lblfinance').disabled=true;
            document.getElementById('lblpayroll').disabled=true; 
            document.getElementById('lblnewsprint').disabled=true;
            document.getElementById('lblstores').disabled=true;
             document.getElementById('lblpam').disabled=true;
            
return false;
}

else if(opendiv=="adbilling1")
{
            document.getElementById('lblgeneral').disabled=true;
            document.getElementById('lbladvertisement').disabled=true;
              
        
            document.getElementById('lbladbilling').disabled=false;
            document.getElementById('lbladaccount').disabled=true;
            document.getElementById('lblcirculation').disabled=true;
            document.getElementById('lblfinance').disabled=true;
            document.getElementById('lblpayroll').disabled=true; 
            document.getElementById('lblnewsprint').disabled=true;
            document.getElementById('lblstores').disabled=true;
                document.getElementById('lblpam').disabled=true;
                
return false;
}

else if(opendiv=="adaccount1")
    {
            document.getElementById('lblgeneral').disabled=true;
            document.getElementById('lbladvertisement').disabled=true;
                      

            document.getElementById('lbladbilling').disabled=true;
            document.getElementById('lbladaccount').disabled=false;
            document.getElementById('lblcirculation').disabled=true;
            document.getElementById('lblfinance').disabled=true;
            document.getElementById('lblpayroll').disabled=true; 
            document.getElementById('lblnewsprint').disabled=true;
            document.getElementById('lblstores').disabled=true;
            document.getElementById('lblpam').disabled=true;
return false;
}


else if(opendiv=="circulation1")
{
            document.getElementById('lblgeneral').disabled=true;
            document.getElementById('lbladvertisement').disabled=true;
                      
        
            document.getElementById('lbladbilling').disabled=true;
            document.getElementById('lbladaccount').disabled=true;
            document.getElementById('lblcirculation').disabled=false;
            document.getElementById('lblfinance').disabled=true;
            document.getElementById('lblpayroll').disabled=true; 
            document.getElementById('lblnewsprint').disabled=true;
            document.getElementById('lblstores').disabled=true;
                document.getElementById('lblpam').disabled=true;
            
return false;
}


else if(opendiv=="finance1")
{
            document.getElementById('lblgeneral').disabled=true;
            document.getElementById('lbladvertisement').disabled=true;
                      
        
            document.getElementById('lbladbilling').disabled=true;
            document.getElementById('lbladaccount').disabled=true;
            document.getElementById('lblcirculation').disabled=true;
            document.getElementById('lblfinance').disabled=false;
            document.getElementById('lblpayroll').disabled=true; 
            document.getElementById('lblnewsprint').disabled=true;
            document.getElementById('lblstores').disabled=true;
                document.getElementById('lblpam').disabled=true;
return false;
}


else if(opendiv=="payroll1")
{
            document.getElementById('lblgeneral').disabled=true;
            document.getElementById('lbladvertisement').disabled=true;
          
        
            document.getElementById('lbladbilling').disabled=true;
            document.getElementById('lbladaccount').disabled=true;
            document.getElementById('lblcirculation').disabled=true;
            document.getElementById('lblfinance').disabled=true;
            document.getElementById('lblpayroll').disabled=false;
            document.getElementById('lblnewsprint').disabled=true;
            document.getElementById('lblstores').disabled=true;
                document.getElementById('lblpam').disabled=true;
return false;
}
else if(opendiv=="newsprint1")
{
            document.getElementById('lblgeneral').disabled=true;
            document.getElementById('lbladvertisement').disabled=true;
                      
        
            document.getElementById('lbladbilling').disabled=true;
            document.getElementById('lbladaccount').disabled=true;
            document.getElementById('lblcirculation').disabled=true;
            document.getElementById('lblfinance').disabled=true;
            document.getElementById('lblpayroll').disabled=true; 
            document.getElementById('lblnewsprint').disabled=false;
            document.getElementById('lblstores').disabled=true;
                document.getElementById('lblpam').disabled=true;
return false;
}

else if(opendiv=="stores1")
{
            document.getElementById('lblgeneral').disabled=true;
            document.getElementById('lbladvertisement').disabled=true;
          
        
            document.getElementById('lbladbilling').disabled=true;
            document.getElementById('lbladaccount').disabled=true;
            document.getElementById('lblcirculation').disabled=true;
            document.getElementById('lblfinance').disabled=true;
            document.getElementById('lblpayroll').disabled=true; 
            document.getElementById('lblnewsprint').disabled=true;
            document.getElementById('lblstores').disabled=false;
                document.getElementById('lblpam').disabled=true;
return false;
}

else if(opendiv=="pam1")
{
            document.getElementById('lblgeneral').disabled=true;
            document.getElementById('lbladvertisement').disabled=true;
          
        
            document.getElementById('lbladbilling').disabled=true;
            document.getElementById('lbladaccount').disabled=true;
            document.getElementById('lblcirculation').disabled=true;
            document.getElementById('lblfinance').disabled=true;
            document.getElementById('lblpayroll').disabled=true; 
            document.getElementById('lblnewsprint').disabled=true;
            document.getElementById('lblstores').disabled=true;
             document.getElementById('lblpam').disabled=false;
return false;
}

    
else
        {  
            return false;
       }
       
      
}





//code for for div


function checktab(opendiv)
{

  if(opendiv=="general")
    {
     
            document.getElementById('lblgeneral').disabled=false;
            document.getElementById('drp_General').style.display="block";
           document.getElementById('drp_Advertisement').style.display="none";
           document.getElementById('drp_Adbilling').style.display="none";
            document.getElementById('drp_AdAccount').style.display="none";
            document.getElementById('drp_Circulation').style.display="none";
            document.getElementById('drp_pam').style.display="none";
            
            
//            document.getElementById('drp_Finance').style.display="none";
//            document.getElementById('drp_Payroll').style.display="none";
//            document.getElementById('drp_Newsprint').style.display="none";
//            document.getElementById('drp_Stores').style.display="none";
//            //document.getElementById('drp_update').style.display="block";
            

            document.getElementById('lblgeneral').className="btnlink";
            document.getElementById('lblgeneral').className="btnlink";
            document.getElementById('lbladvertisement').className="btnlink";
          
        
            document.getElementById('lbladbilling').className="btnlink";
            document.getElementById('lbladaccount').className="btnlink";
            document.getElementById('lblcirculation').className="btnlink";
            document.getElementById('lblfinance').className="btnlink";
            document.getElementById('lblpayroll').className="btnlink"; 
            document.getElementById('lblnewsprint').className="btnlink";
            document.getElementById('lblstores').className="btnlink";
             document.getElementById('lblpam').className="btnlink";
            
            
            
            
            /*document.getElementById('drpdateformat').value= "";
            document.getElementById('drpcodetype').value= "";
            document.getElementById('drpcurr').value= "";
            document.getElementById('txtdecimal').value= "";*/

            return false;
       }
   
       
    else if(opendiv=="advertisement")
    {   
       document.getElementById('lbladvertisement').disabled=false;
       
       
            document.getElementById('drp_General').style.display="none";
            document.getElementById('drp_Advertisement').style.display="block";
           document.getElementById('drp_Adbilling').style.display="none";
            document.getElementById('drp_AdAccount').style.display="none";
            document.getElementById('drp_Circulation').style.display="none";
                  document.getElementById('drp_pam').style.display="none";
//            document.getElementById('drp_Finance').style.display="none";
//            document.getElementById('drp_Payroll').style.display="none";
//            document.getElementById('drp_Newsprint').style.display="none";
//            document.getElementById('drp_Stores').style.display="none";
            //document.getElementById('DropDownList1').style.display="block";
            
//     
            
           
             document.getElementById('lblgeneral').className="btnlink";
            document.getElementById('lbladvertisement').className="btnlink";
          
        
            document.getElementById('lbladbilling').className="btnlink";
            document.getElementById('lbladaccount').className="btnlink";
            document.getElementById('lblcirculation').className="btnlink";
            document.getElementById('lblfinance').className="btnlink";
            document.getElementById('lblpayroll').className="btnlink"; 
            document.getElementById('lblnewsprint').className="btnlink";
            document.getElementById('lblstores').className="btnlink";
             document.getElementById('lblpam').className="btnlink";
           
            return false;
           }

else if(opendiv=="adbilling")
    {   
             document.getElementById('lbladbilling').disabled=false;
            document.getElementById('drp_General').style.display="none";
            document.getElementById('drp_Advertisement').style.display="none";
            document.getElementById('drp_Adbilling').style.display="block";
            document.getElementById('drp_AdAccount').style.display="none";
            document.getElementById('drp_Circulation').style.display="none";
                  document.getElementById('drp_pam').style.display="none";
//            document.getElementById('drp_Finance').style.display="none";
//            document.getElementById('drp_Payroll').style.display="none";
//            document.getElementById('drp_Newsprint').style.display="none";
//            document.getElementById('drp_Stores').style.display="none";
//            //document.getElementById('DropDownList2').style.display="block";

            
         
            
            
           document.getElementById('lblgeneral').className="btnlink";
  
            document.getElementById('lbladvertisement').className="btnlink";
          
        
            document.getElementById('lbladbilling').className="btnlink";
            document.getElementById('lbladaccount').className="btnlink";
            document.getElementById('lblcirculation').className="btnlink";
            document.getElementById('lblfinance').className="btnlink";
            document.getElementById('lblpayroll').className="btnlink"; 
            document.getElementById('lblnewsprint').className="btnlink";
            document.getElementById('lblstores').className="btnlink";
             document.getElementById('lblpam').className="btnlink";
           
            return false;
            
      }      


else if(opendiv=="adaccount")
    {   
        document.getElementById('lbladaccount').disabled=false;
            document.getElementById('drp_General').style.display="none";
            document.getElementById('drp_Advertisement').style.display="none";
            document.getElementById('drp_Adbilling').style.display="none";
            document.getElementById('drp_AdAccount').style.display="block";
            document.getElementById('drp_Circulation').style.display="none";
                  document.getElementById('drp_pam').style.display="none";
            
//            document.getElementById('drp_Finance').style.display="none";
//            document.getElementById('drp_Payroll').style.display="none";
//            document.getElementById('drp_Newsprint').style.display="none";
//            document.getElementById('drp_Stores').style.display="none";
           // document.getElementById('DropDownList3').style.display="block";
            
        
           
           document.getElementById('lblgeneral').className="btnlink";
  
            document.getElementById('lbladvertisement').className="btnlink";
          
        
            document.getElementById('lbladbilling').className="btnlink";
            document.getElementById('lbladaccount').className="btnlink";
            document.getElementById('lblcirculation').className="btnlink";
            document.getElementById('lblfinance').className="btnlink";
            document.getElementById('lblpayroll').className="btnlink"; 
            document.getElementById('lblnewsprint').className="btnlink";
            document.getElementById('lblstores').className="btnlink";
             document.getElementById('lblpam').className="btnlink";
            return false;
      }      

else if(opendiv=="circulation")
    {   
       document.getElementById('lblcirculation').disabled=false;
            document.getElementById('drp_General').style.display="none";
            document.getElementById('drp_Advertisement').style.display="none";
            document.getElementById('drp_Adbilling').style.display="none";
            document.getElementById('drp_AdAccount').style.display="none";
            document.getElementById('drp_Circulation').style.display="block";
                  document.getElementById('drp_pam').style.display="none";
//            document.getElementById('drp_Finance').style.display="none";
//            document.getElementById('drp_Payroll').style.display="none";
//            document.getElementById('drp_Newsprint').style.display="none";
//            document.getElementById('drp_Stores').style.display="none";
////            document.getElementById('DropDownList4').style.display="block";
//            
            
           
              
           document.getElementById('lblgeneral').className="btnlink";
  
            document.getElementById('lbladvertisement').className="btnlink";
          
        
            document.getElementById('lbladbilling').className="btnlink";
            document.getElementById('lbladaccount').className="btnlink";
            document.getElementById('lblcirculation').className="btnlink";
            document.getElementById('lblfinance').className="btnlink";
            document.getElementById('lblpayroll').className="btnlink"; 
            document.getElementById('lblnewsprint').className="btnlink";
            document.getElementById('lblstores').className="btnlink";
             document.getElementById('lblpam').className="btnlink";
            return false;
      }      

else if(opendiv=="finance")
    {   
        document.getElementById('lblfinance').disabled=false;
            document.getElementById('drp_General').style.display="none";
            document.getElementById('drp_Advertisement').style.display="none";
            document.getElementById('drp_Adbilling').style.display="none";
            document.getElementById('drp_AdAccount').style.display="none";
            document.getElementById('drp_Circulation').style.display="none";
                  document.getElementById('drp_pam').style.display="none";
//            document.getElementById('drp_Finance').style.display="block";
//            document.getElementById('drp_Payroll').style.display="none";
//            document.getElementById('drp_Newsprint').style.display="none";
//            document.getElementById('drp_Stores').style.display="none";
////            document.getElementById('DropDownList5').style.display="block";
//            
            
                 
           document.getElementById('lblgeneral').className="btnlink";
  
            document.getElementById('lbladvertisement').className="btnlink";
          
        
            document.getElementById('lbladbilling').className="btnlink";
            document.getElementById('lbladaccount').className="btnlink";
            document.getElementById('lblcirculation').className="btnlink";
            document.getElementById('lblfinance').className="btnlink";
            document.getElementById('lblpayroll').className="btnlink"; 
            document.getElementById('lblnewsprint').className="btnlink";
            document.getElementById('lblstores').className="btnlink";
             document.getElementById('lblpam').className="btnlink";
            return false;
      }   
else if(opendiv=="payroll")
    {   
             document.getElementById('lblpayroll').disabled=false;
            document.getElementById('drp_General').style.display="none";
            document.getElementById('drp_Advertisement').style.display="none";
            document.getElementById('drp_Adbilling').style.display="none";
            document.getElementById('drp_AdAccount').style.display="none";
            document.getElementById('drp_Circulation').style.display="none";
                  document.getElementById('drp_pam').style.display="none";
//            document.getElementById('drp_Finance').style.display="none";
//            document.getElementById('drp_Payroll').style.display="block";
//            document.getElementById('drp_Newsprint').style.display="none";
//            document.getElementById('drp_Stores').style.display="none";
////            document.getElementById('DropDownList6').style.display="block";
            
        document.getElementById('lblgeneral').className="btnlink";
  
            document.getElementById('lbladvertisement').className="btnlink";
          
        
            document.getElementById('lbladbilling').className="btnlink";
            document.getElementById('lbladaccount').className="btnlink";
            document.getElementById('lblcirculation').className="btnlink";
            document.getElementById('lblfinance').className="btnlink";
            document.getElementById('lblpayroll').className="btnlink"; 
            document.getElementById('lblnewsprint').className="btnlink";
            document.getElementById('lblstores').className="btnlink";
             document.getElementById('lblpam').className="btnlink";
            return false;
      }      
   
else if(opendiv=="newsprint")
    {   
         document.getElementById('lblnewsprint').disabled=false;
            document.getElementById('drp_General').style.display="none";
            document.getElementById('drp_Advertisement').style.display="none";
            document.getElementById('drp_Adbilling').style.display="none";
            document.getElementById('drp_AdAccount').style.display="none";
            document.getElementById('drp_Circulation').style.display="none";
                  document.getElementById('drp_pam').style.display="none";
//            document.getElementById('drp_Finance').style.display="none";
//            document.getElementById('drp_Payroll').style.display="none";
//            document.getElementById('drp_Newsprint').style.display="block";
//            document.getElementById('drp_Stores').style.display="none";
////            document.getElementById('DropDownList7').style.display="block";
//            
               
       
        
        document.getElementById('lblgeneral').className="btnlink";
  
            document.getElementById('lbladvertisement').className="btnlink";
          
        
            document.getElementById('lbladbilling').className="btnlink";
            document.getElementById('lbladaccount').className="btnlink";
            document.getElementById('lblcirculation').className="btnlink";
            document.getElementById('lblfinance').className="btnlink";
            document.getElementById('lblpayroll').className="btnlink"; 
            document.getElementById('lblnewsprint').className="btnlink";
            document.getElementById('lblstores').className="btnlink";
             document.getElementById('lblpam').className="btnlink";
            return false;
      }      
else if(opendiv=="stores")
    {   
              document.getElementById('lblstores').disabled=false;
            document.getElementById('drp_General').style.display="none";
            document.getElementById('drp_Advertisement').style.display="none";
            document.getElementById('drp_Adbilling').style.display="none";
            document.getElementById('drp_AdAccount').style.display="none";
            document.getElementById('drp_Circulation').style.display="none";
                  document.getElementById('drp_pam').style.display="none";
//            document.getElementById('drp_Finance').style.display="none";
//            document.getElementById('drp_Payroll').style.display="none";
//            document.getElementById('drp_Newsprint').style.display="none";
//            document.getElementById('drp_Stores').style.display="block";
//            document.getElementById('DropDownList8').style.display="block";
//            
            
                
        document.getElementById('lblgeneral').className="btnlink";
  
            document.getElementById('lbladvertisement').className="btnlink";
          
        
            document.getElementById('lbladbilling').className="btnlink";
            document.getElementById('lbladaccount').className="btnlink";
            document.getElementById('lblcirculation').className="btnlink";
            document.getElementById('lblfinance').className="btnlink";
            document.getElementById('lblpayroll').className="btnlink"; 
            document.getElementById('lblnewsprint').className="btnlink";
            document.getElementById('lblstores').className="btnlink";
            document.getElementById('lblpam').className="btnlink";
            document.getElementById('lblpam').className="btnlink"; 
            return false;
           
      }   
      
      else if(opendiv=="pam")
    {   
              document.getElementById('lblpam').disabled=false;
            document.getElementById('drp_General').style.display="none";
            document.getElementById('drp_Advertisement').style.display="none";
            document.getElementById('drp_Adbilling').style.display="none";
            document.getElementById('drp_AdAccount').style.display="none";
            document.getElementById('drp_Circulation').style.display="none";
             document.getElementById('drp_pam').style.display="block";
//            document.getElementById('drp_Finance').style.display="none";
//            document.getElementById('drp_Payroll').style.display="none";
//            document.getElementById('drp_Newsprint').style.display="none";
//            document.getElementById('drp_Stores').style.display="none";
//            document.getElementById('DropDownList8').style.display="block";
//            
            
                
        document.getElementById('lblgeneral').className="btnlink";
  
            document.getElementById('lbladvertisement').className="btnlink";
          
        
            document.getElementById('lbladbilling').className="btnlink";
            document.getElementById('lbladaccount').className="btnlink";
            document.getElementById('lblcirculation').className="btnlink";
            document.getElementById('lblfinance').className="btnlink";
            document.getElementById('lblpayroll').className="btnlink"; 
            document.getElementById('lblnewsprint').className="btnlink";
            document.getElementById('lblstores').className="btnlink";
            document.getElementById('lblpam').className="btnlink";
            
            return false;
           
      }         
    

    
else
        {  
            return false;
       }
      


}





function LTrim( value )
{

var re = /\s*((\S+\s*)*)/;
 return value.replace(re, "$1"); 
}

// Removes ending whitespaces
function RTrim( value ) {
 
 var re = /((\s*\S+)*)\s*/;
  return value.replace(re, "$1");

}

// Removes leading and ending whitespaces
function trim( value )
{
 
 return LTrim(RTrim(value)); 
}

function Chkchange()
{
    if(document.getElementById("chkinsertdate").checked==true)
    {
       document.getElementById("txtcut").disabled=false;
    }
    else
    {
    document.getElementById("txtcut").disabled=true;
    document.getElementById("txtcut").value="";
    }
}
function chkcutt()
{
var sau=parseFloat(document.getElementById('txtcut').value);
//document.getElementById('txtsharing').value=sau;

if(sau>24)
{
    alert("Cut Off Time should not be greater than 24");
    document.getElementById('txtcut').value="";
    document.getElementById('txtcut').focus();
    return false;
}
var num=document.getElementById('txtcut').value;
var tomatch=/^\d*(\.\d{1,2})?document.getElementById/;
if (tomatch.test(num))
{
return true;
}
else
{
alert("Input error");
document.getElementById('txtcut').value="";
document.getElementById('txtcut').focus();

return false; 

}
}
// Removes leading and ending whitespaces
//function trim( value ) 

//{
//	
//	return LTrim(RTrim(value));
//	
//}
function Auto_TDS_Credit_Noteenbel() {

    if (document.getElementById("drpAuto_TDS_Credit_Note").value == "Y") {
        document.getElementById("txtDebit_Account_Head").disabled = false;
        document.getElementById("txtcredit_Account_Head").disabled = false;
        document.getElementById("txtTDS_Reason").disabled = false;
    }
    else {
        document.getElementById("txtTDS_Reason").disabled = true;
        document.getElementById("txtDebit_Account_Head").disabled = true;
        document.getElementById("txtcredit_Account_Head").disabled = true;
        document.getElementById("txtTDS_Reason").value = "";
        document.getElementById("txtDebit_Account_Head").value = "";
        document.getElementById("txtcredit_Account_Head").value = "";
    }
    return false;
}


function auto_service_tax_credit_noteenbel() {

    if (document.getElementById("drpauto_service_tax_credit_note").value == "Y") {
        document.getElementById("txtDebit_Account_Head_For_Service_Tax").disabled = false;
        document.getElementById("txtCredit_Account_Head_For_Service_Tax").disabled = false;
        document.getElementById("txtTax_Reason").disabled = false;
    }
    else {
        document.getElementById("txtTax_Reason").disabled = true;
        document.getElementById("txtDebit_Account_Head_For_Service_Tax").disabled = true;
        document.getElementById("txtCredit_Account_Head_For_Service_Tax").disabled = true;
        document.getElementById("txtTax_Reason").value = "";
        document.getElementById("txtDebit_Account_Head_For_Service_Tax").value = "";
        document.getElementById("txtCredit_Account_Head_For_Service_Tax").value = "";
    }
    return false;

}


function Auto_Patrakar_Kalyan_Kosh_Credit_Noteenbel() {

    if (document.getElementById("drpAuto_Patrakar_Kalyan_Kosh_Credit_Note").value == "Y") {
        document.getElementById("txtPatrakar_Kalyan_Kosh_Reason").disabled = false;
        document.getElementById("txtDebit_Account_Head_For_Patrakar_Kalyan_Kosh").disabled = false;
        document.getElementById("txtCredit_Account_Head_For_Patrakar_Kalyan_Kosh").disabled = false;
    }
    else {
        document.getElementById("txtPatrakar_Kalyan_Kosh_Reason").disabled = true;
        document.getElementById("txtDebit_Account_Head_For_Patrakar_Kalyan_Kosh").disabled = true;
        document.getElementById("txtCredit_Account_Head_For_Patrakar_Kalyan_Kosh").disabled = true;
        document.getElementById("txtPatrakar_Kalyan_Kosh_Reason").value = "";
        document.getElementById("txtDebit_Account_Head_For_Patrakar_Kalyan_Kosh").value = "";
        document.getElementById("txtCredit_Account_Head_For_Patrakar_Kalyan_Kosh").value = "";
    }
    return false;

}


function drpAuto_Bank_Charges_Credit_Noteenbel() {
    if (document.getElementById("drpAuto_Bank_Charges_Credit_Note").value == "Y") {
        document.getElementById("txtBank_Charges_Reason").disabled = false;
        document.getElementById("txtDebit_Account_Head_For_Bank_Charges").disabled = false;
        document.getElementById("txtCredit_Account_Head_For_Bank_Charges").disabled = false;
    }
    else {
        document.getElementById("txtCredit_Account_Head_For_Bank_Charges").disabled = true;
        document.getElementById("txtBank_Charges_Reason").disabled = true;
        document.getElementById("txtDebit_Account_Head_For_Bank_Charges").disabled = true;
        document.getElementById("txtBank_Charges_Reason").value = "";
        document.getElementById("txtDebit_Account_Head_For_Bank_Charges").value = "";
        document.getElementById("txtCredit_Account_Head_For_Bank_Charges").value = "";
    }
    return false;

}







function fill_tds(event) {
    var key1 = event.keyCode ? event.keyCode : event.which;

    if (key1 == 13 || event.type == "click") {
        document.getElementById('hiddenquery').value = "query";
        if (document.getElementById('hiddenquery').value == "query") {
            if (document.getElementById('lsttds').value == "0") {
                alert("Please Select the TDS");
                return false;
            }

            var page = document.getElementById('lsttds').value;
            for (var k = 0; k <= document.getElementById("lsttds").length - 1; k++) {
                if (document.getElementById('lsttds').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lsttds').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lsttds').options[k].innerHTML;
                    }
                }
            }

           // document.getElementById('txtpartyTDSseccode').value = page;
            document.getElementById('txttdsnametype').value = abc;
            document.getElementById('hdntdsnametype').value = abc;
      
            document.getElementById("divtds").style.display = 'none';
       //     document.getElementById("txtpartyTDSsecname").focus();
           return false;
        }
    }

}
function fill_assay(event) {

    var key1 = event.keyCode ? event.keyCode : event.which;

    if (key1 == 13 || event.type == "click") {
 
        document.getElementById('hiddenquery').value = "query";
        if (document.getElementById('hiddenquery').value == "query") {
            if (document.getElementById('lstassay').value == "0") {
                alert("Please Select the Assay Type");
                return false;
            }


            var page = document.getElementById('lstassay').value;
    
            
            for (var k = 0; k <= document.getElementById("lstassay").length - 1; k++) {
                if (document.getElementById('lstassay').options[k].value == page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstassay').options[k].textContent;
                      //  alert(abc)
                        
                    }
                    else {
                        var abc = document.getElementById('lstassay').options[k].innerHTML;

                    }
                }
            }

  
            document.getElementById('txtTdsSecName').value = abc.split('~')[0];
           document.getElementById('hdntdssecname').value = abc.split('~')[0];
            document.getElementById("divassay").style.display = 'none';
        //    document.getElementById("txtassesy").focus();
           return false;

        }

    }
}


function tabvalue(event) {
    var key1 = event.keyCode ? event.keyCode : event.which;
    /***************************************************************************/


    if (key1 == 113) {
        //   alert("1");

        if (document.activeElement.id == "txtTdsSecName") {

            // var extra1 = (document.getElementById('txtpartyTDSsecname').value).toUpperCase();
            var extra2 = "";

            //     document.getElementById('txtpartyTDSsecname').value = "";
            var compcode = document.getElementById('hiddencompcode').value;
            //document.getElementById('divtds').style.top = 430 + "px";
            //document.getElementById('divtds').style.left = 728 + "px";
            var dateformat = "'dd/mm/yyyy'";
            var asseytype = "";
            //                                        document.getElementById("txtassesycode").value
            //                                        var seccode="";
            var vchdate = "";
            activeid = document.activeElement.id;
            aTag = eval(document.getElementById(activeid))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            var tot = document.getElementById('divassay').scrollLeft;
            var scrolltop = document.getElementById('divassay').scrollTop;
            document.getElementById('divassay').style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById('divassay').style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";



            document.getElementById("divassay").style.display = "block";
            document.getElementById('lstassay').focus();
            var MYRESULR_BILL = updateprefer.fill_tds1(compcode, "", "", "", "", "", "");
            ds = MYRESULR_BILL.value;
            if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
                var pkgitem = document.getElementById("lstassay");
                pkgitem.options.length = 0;
                pkgitem.options[0] = new Option("-Select Assay Type-", "0");
                pkgitem.options.length = 1;

                for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                    // pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].ASSESY_DESC, ds.Tables[0].Rows[i].ASSESY_CODE);
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].ASSESY_NAME + "~" + ds.Tables[0].Rows[i].ASSESY_TYPE, ds.Tables[0].Rows[i].ASSESY_NAME);
                    pkgitem.options.length;
                }
                document.getElementById("divassay").disabled = false;
                // document.getElementById('lsttds').focus();
            }

            //if (document.activeElement.id == "lsttds") {

            //fill_tds();
            //                                  $("txturladd").disabled=false;
            //    


            //    }
            return false;

        }

        else if (document.activeElement.id == "txttdsnametype") {
            activeid = document.activeElement.id;
            var extra1 = "";
            var extra2 = "";
            // var Doc = "";
            var Compcode = document.getElementById('hiddencompcode').value;
            var Doc = "";
            document.getElementById('txtpartyTDSseccode').value;
            //var assyname=document.getElementById('txtassesy').value;
            var Unit = ""; //document.getElementById('hdnunit').value;
            var dateformat = "";
            activeid = document.activeElement.id;
            aTag = eval(document.getElementById(activeid))
            var btag;
            var leftpos = 0;
            var toppos = 0;
            do {
                aTag = eval(aTag.offsetParent);
                leftpos += aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag = eval(aTag)
            } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
            var tot = document.getElementById('divtds').scrollLeft;
            var scrolltop = document.getElementById('divtds').scrollTop;
            document.getElementById('divtds').style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
            document.getElementById('divtds').style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";



            document.getElementById("divtds").style.display = "block";
            document.getElementById('lsttds').focus();
            var res12 = updateprefer.bind_assesy(Compcode, Unit, dateformat, extra1, extra2, "", Doc)
            //var res12 = fin_accountmast.bind_assesy(Compcode, Doc, assyname, dateformat, extra1, extra2,"")
            ds = res12.value;
            if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
                var pkgitem = document.getElementById("lsttds");
                pkgitem.options.length = 0;
                pkgitem.options[0] = new Option("-Select TDS-", "0");
                pkgitem.options.length = 1;

            }




            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].SEC_NAME, ds.Tables[0].Rows[i].SEC_CODE);
                pkgitem.options.length;
            }

            document.getElementById("divtds").disabled = false;
            document.getElementById('lsttds').focus();

            return false;
        }
          
       
        
    }
    else if(key1==8)
    {
    if (document.activeElement.id == "txttdsnametype")
    {
document.getElementById('hdntdsnametype').value="";
    }
   
     if (document.activeElement.id == "txtTdsSecName")
    {
document.getElementById('hdntdssecname').value="";
    }
    }



}



 
    function NumericValidation(eventObj) {
        var keycode;

        if (eventObj.keyCode) //For IE
            keycode = eventObj.keyCode;
        else if (eventObj.Which)
            keycode = eventObj.Which;  // For FireFox
        else
            keycode = eventObj.charCode; // Other Browser

        if (keycode != 8) //if the key is the backspace key
        {
            if (keycode < 48 || keycode > 57) //if not a number
                return false; // disable key press
            else
                return true; // enable key press
        }
    }
    
    
    
    //===========
    
    
    
    function value123() {



        
 
 var value = document.getElementById('Textvalue').value;
   if (value < 0) 
   {
     alert("Commision should not less than zero");
     document.getElementById('Textvalue').value="";
     
     return false;
   }
   else if(value == 0)
   {

       alert("Commision can not be zero");
     document.getElementById('Textvalue').value="";
     return false;
   
   }
   if (value > 100)
   {
       alert("Commision should not be more then to 100");
    document.getElementById('Textvalue').value="";
    return false;
    }
   
 }


 

 