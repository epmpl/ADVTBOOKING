// JScript File
var form_name="";
function permission()
{
var comp_code=document.getElementById('hiddencompcode').value;
var user_id=document.getElementById('hiddenuserid').value;
reportmenu.chk_permission(comp_code,user_id,form_name,call_permission);
}
function call_permission(response)
{
var id = "";
var ds=response.value;

if(ds!=null && ds.Tables.length>0)
{
       if (ds.Tables[0].Rows.length > 0)
        {
           if (document.getElementById('hiddenconnection').value == "orcl") {
               id = ds.Tables[0].Rows[0].Button_id;
           }
           else if (document.getElementById('hiddenconnection').value == "sql") {
               id = ds.Tables[0].Rows[0].button_id;
           }
           else {
               id = ds.Tables[0].Rows[0].Button_id;
           }
        }
        if(id ==0 || id=="no" || id=="0")
	    {
		alert("You Are Not Authorised To See This Form");
		return false;

	    }
	    else
	    {
//        if ((id == "15") || (id == "7"))
//        {
          window.open(form_name+'.aspx');
        }
//        else
//        {
//            alert('You Are Not Authorised To See This Form');
//            return false;
//        }
}
else
window.open('../login.aspx');
}



function adofday()//all ads of a day
{
form_name="report";
permission();
//window.open("report.aspx");
}

function adofage()//all ads of the agency
{
form_name="report2";
permission();
//window.open("report2.aspx");
}

function adofagencli()//all ads of the client
{
form_name="agencyclient";
permission();
//window.open("agencyclient.aspx");
}

function liadofholdcan()//status based ad list
{
form_name="report3";
permission();
//window.open("report3.aspx");
}


function divatonrp()//deviation report
{
form_name="Deviationreport";
permission();
//window.open("Deviationreport.aspx");
}
function pagepre()//page premium report
{
form_name="pagepreviewreport";
permission();
//window.open("pagepreviewreport.aspx");
}
function IssBuss()//issue wise business report
{
form_name="IssueWiseBussiness";
permission();
 //window.open("IssueWiseBussiness.aspx");
}

function RevneueSummary()//revenue summary report
{
form_name="RevenueSummarryReport";
permission();
   //window.open("RevenueSummarryReport.aspx");
}
function TopAgency()//top agency/client analysis report
{
form_name="Ageanalysis";
permission();
   //window.open("Ageanalysis.aspx");
}
function Executivewise()//executive wise report
{
form_name="ExecutiveReport";
permission();
   //window.open("ExecutiveReport.aspx");
}
function avaipagepre()//available premium dates
{
form_name="availablepremium";
permission();
//window.open("availablepremium.aspx");
}
function category()//category wise report
{
form_name="categorywisereport";
permission();
//window.open("categorywisereport.aspx");
}

function summerized()//status wise daily summarized report
{
form_name="summarized_report";
permission();
//window.open("summarized_report.aspx");
}

function clientdet()//pi report
{
form_name="piproduct";
permission();
//window.open("piproduct.aspx");
}

function contractt()//pi contract report
{
form_name="picontractreport";
permission();
//window.open("picontractreport.aspx");
}

function representative()//executive/retainer wise business report
{
form_name="representative_ledger";
permission();
 //window.open("representative_ledger.aspx");
}

function reotype()//executive/retainer wise business report
{
    form_name = "reotype";
    permission();
    //window.open("representative_ledger.aspx");
}

function issueprint()//issue wise printing center report
{
form_name="issuewisereport";
permission();
//window.open("issuewisereport.aspx");
}

function schedule()//schedule register report
{
form_name="ScheduleRegister";
permission();
//window.open("ScheduleRegister.aspx");
}

function attendenceregister()//AttendenceRegister report
{
form_name="AttendenceRegister";
permission();
//window.open("ScheduleRegister.aspx");
}

function complete()//complete report
{
form_name="billwisexls";
permission();
// window.open("billwisexls.aspx");
}
function netreport()//net amount report
{
form_name="Net_amt_xlsreport";
permission();
//window.open("Net_amt_xlsreport.aspx");
}
function ro_agency()//ro report agency wise
{
form_name="RO_Agency_Wise";
permission();
//window.open("Net_amt_xlsreport.aspx");
}

function billingreg()//billing register
{
form_name="BillRegister";
permission();
//window.open("BillRegister.aspx");
}

function barterbill()//booking wise report
{
form_name="BarterBill";
permission();
//window.open("BarterBill.aspx");
}

function valuerep()//barter wise report
{
form_name="valueReport";
permission();
//window.open("valueReport.aspx");
}

function retainCom()//retainer commission report
{
form_name="Retaincom";
permission();
//window.open("Retaincom.aspx");
}

function moneyrecieved()//money recieved report
{
form_name="moneyrecievedreport";
permission();
//window.open("moneyrecievedreport.aspx");
}

function datewise_billing()//money recieved report
{
form_name="datewise_billing_report";
permission();
//window.open("moneyrecievedreport.aspx");
}
function weekwise_billing()//money recieved report
{
form_name="weekly_monthly_reports";
permission();
//window.open("moneyrecievedreport.aspx");
}
function offline()//offline mode report
{
form_name="Offline_Mode_Report";
permission();
//window.open("moneyrecievedreport.aspx");
}

function vtsreport()
{
form_name="VTS";
permission();
//window.open("moneyrecievedreport.aspx");
}

function bookingreport()
{
form_name="BookingDetail";
permission();
//window.open("moneyrecievedreport.aspx");
}



function issueedition()
{
form_name="insertion";
permission();
}

function catgwise()
{
form_name="ctreport_main";
permission();
}
function reportprefer()
{
        var winid="";
	    for ( var index = 0; index < 200; index++ ) 
               { 
               
              winid=window.open('reportprefer.aspx','Prachi','resizable=0,toolbar=0,top=244,left=210,width=700px,height=200px');
           
               winid.focus();
                 return false;
	           }

	       }

function dealrep()//Deal report
{
    form_name = "DealReport";
   permission();
   //window.open("summarized_report.aspx");
}
function unregisteredclient()//Deal report
{
    form_name = "unregisteredclientreport";
    permission();
    //window.open("summarized_report.aspx");
}
function Boxregister()//Deal report
{
    form_name = "boxno";
    permission();
    //window.open("summarized_report.aspx");
}
function auditor_comment()//Deal report
{
    form_name = "rpt_auditor_comment";
    permission();
    //window.open("summarized_report.aspx");
}
function ad_rep_roapproval_detail()//Deal report
{
    form_name = "ad_rep_roapproval_detail";
    permission();
    //window.open("summarized_report.aspx");
}


function issuebillreport() {
    form_name = "issuebillreport";
    permission();


}

function cardrat(){
    form_name = "RateCard";
    permission();


}
function ctrdatereport() {
    form_name = "ctrdatereport";
    permission();


}

function targetanalisis() {
    form_name = "targetanalisis";
    permission();


}


function Ad_bussiness_target()
{
   form_name = "Ad_bussiness_target";
    permission();

}

function case_register_rep()
{
    form_name = "case_register_rep";
permission();
//window.open("report.aspx");
}
function Ad_bussiness_target() {
    form_name = "Ad_bussiness_target";
    permission();

}

function eyecather_report() {
    form_name = "eyecater_report";
   permission();
    //window.open("report.aspx");
}


function CrditDebit() {
    form_name = "CrditDebit";
    permission();
    //window.open("report.aspx");
}


function qbc_alleditions_rpt() {
    form_name = "qbc_alleditions_rpt";
    permission();
    //window.open("report.aspx");
}

function admasterreport() {
    form_name = "ad_masterreport";
    permission();
    //window.open("report.aspx");
}
function invoice() {
    form_name = "invoice_register";
    permission();
    //window.open("report.aspx");
}
function all_mast() {
    form_name = "AGENCY_MAST";
    permission();
    //window.open("report.aspx");
}

function con_schedule() {
    form_name = "consolidated_sch_reg";
    permission();
    //window.open("report.aspx");
}

function month_bill() {
    form_name = "rpt_monthly_bill";
    permission();
    //window.open("report.aspx");
}

function bookingmaterialdata() {
    //form_name = "bookingmaterialdata";
    //permission();
    window.open("bookingmaterialdata.aspx");

}

function bookingmasterrpt() {
    //form_name = "bookingmaterialdata";
    //permission();
    window.open("booking_master_report.aspx");

}
