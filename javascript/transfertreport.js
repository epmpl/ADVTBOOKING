// JScript File

function submitreport()
{
    var fromdate=document.getElementById('txtFromDate').value;
    var todate=document.getElementById('txtToDate').value;
    if(document.getElementById('txtFromDate').value=="")
    {
        alert("Please Enter The FromDate");
        document.getElementById('txtFromDate').focus();
        return false;
    }
    if(document.getElementById('txtToDate').value=="")
    {
        alert("Please Enter The ToDate");
        document.getElementById('txtToDate').focus();
        return false;
    }
    var fdate=new Date(document.getElementById('txtFromDate').value);
    var tdate= new Date(document.getElementById('txtToDate').value);
    
    
    if(fdate>tdate)
    {
        alert(" ToDate should be greater than Fromdate");
        document.getElementById('txtToDate').value="";
        document.getElementById('txtToDate').focus();
        return false;
    }
      
}

