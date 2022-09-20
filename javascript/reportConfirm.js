// JScript File
function validate()
{//debugger;
    if(document.getElementById("txtFromDate").value=="")
    {
        alert("Please enter From Date");
        document.getElementById("txtFromDate").focus();
        return false;
    }
    
    if(document.getElementById("txtToDate").value=="")
    {
        alert("Please enter To Date");
        document.getElementById("txtToDate").focus();
        return false;
    }
    
//    var formname= document.location.pathname.split('/')[2].split('.')[0].toString();
//    if(formname=="qbcTransfer_User")
//    {
//        if(document.getElementById("drpUser").value=="0")
//        {
//            alert("Please select User");
//            document.getElementById("drpUser").focus();
//            return false;
//        }
//    }
    
//    if(document.getElementById("drpStatus").value=="0")
//    {
//        alert("Please select Satus");
//        document.getElementById("drpStatus").focus();
//        return false;
//    }
    var dateformat=document.getElementById("hiddendateformat").value;
    var fDate="";
    var tDate="";
    if(dateformat=="yyyy/mm/dd")
    {
        var input=document.getElementById("txtFromDate");
        var yearfield=input.value.split("/")[0]
        var monthfield=input.value.split("/")[1]
        var dayfield=input.value.split("/")[2]
        fDate = monthfield+"/"+dayfield+"/"+yearfield;
    }
    if(dateformat=="mm/dd/yyyy")
    {
        var input=document.getElementById("txtFromDate");
        var yearfield=input.value.split("/")[2]
        var monthfield=input.value.split("/")[0]
        var dayfield=input.value.split("/")[1]
        //var dayobj = new Date(monthfield-1, dayfield, yearfield)
        fDate = monthfield+"/"+dayfield+"/"+yearfield;
    }
    if(dateformat=="dd/mm/yyyy")
    {
        var input=document.getElementById("txtFromDate");
        var yearfield=input.value.split("/")[2]
        var monthfield=input.value.split("/")[1]
        var dayfield=input.value.split("/")[0]
        //var dayobj = new Date(dayfield, monthfield-1, yearfield)
        fDate= monthfield+"/"+dayfield+"/"+yearfield;
    }
    
    ///////////////////To Date
    if(dateformat=="yyyy/mm/dd")
    {
        var input=document.getElementById("txtToDate");
        var yearfield=input.value.split("/")[0]
        var monthfield=input.value.split("/")[1]
        var dayfield=input.value.split("/")[2]
        tDate = monthfield+"/"+dayfield+"/"+yearfield;
    }
    if(dateformat=="mm/dd/yyyy")
    {
        var input=document.getElementById("txtToDate");
        var yearfield=input.value.split("/")[2]
        var monthfield=input.value.split("/")[0]
        var dayfield=input.value.split("/")[1]
        //var dayobj = new Date(monthfield-1, dayfield, yearfield)
        tDate = monthfield+"/"+dayfield+"/"+yearfield;
    }
    if(dateformat=="dd/mm/yyyy")
    {
        var input=document.getElementById("txtToDate");
        var yearfield=input.value.split("/")[2]
        var monthfield=input.value.split("/")[1]
        var dayfield=input.value.split("/")[0]
        //var dayobj = new Date(dayfield, monthfield-1, yearfield)
        tDate= monthfield+"/"+dayfield+"/"+yearfield;
    }
    
    var fDate1=new Date(fDate);
    var tDate1=new Date(tDate);
    
    if(tDate1<fDate1)
    {
        alert("To date should be Greater than From Date");
        document.getElementById("txtToDate").focus();
        return false;
    }
}


//Number Only Validator

function ClientisNumber(event)
{
	if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11)|| (event.keyCode==13)|| (event.keyCode==8))
	{
		
		return true;
	}
	else
	{
		return false;
	}
	
}