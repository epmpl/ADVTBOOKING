// JScript File
function exitclick()
{
		if(confirm("Do You Want To Skip This Page"))
		{
		window.close();
		return false;
		}
		return false;
}
function resetVal()
{
     if(document.getElementById('txtagency').disabled==false)
    {
        document.getElementById('txtagency').value="";
    } 
    document.getElementById('txtsperson').value="";
    document.getElementById('txtcust').value="";
    document.getElementById('txtfromdate').value="";
    document.getElementById('txttodate').value="";
    document.getElementById('txtsheldate').value="";
    document.getElementById('insertntodate').value="";
    document.getElementById('txttext').value="";
    if(document.getElementById('DataGrid1')!=null)
    {
        document.getElementById('DataGrid1').outerText="";
    }
    //document.getElementById('DataGrid1').innerHTML="";
    //document.getElementById("DataGrid1").rows.length=0;
    return false;
}
function validation()
{
     var flag="0";
     var flag1="0";
     var fromdate="";
     var todate="";
     var sheldate="";
     var inserdate="";
     
     document.getElementById('txtagency').value=trim(document.getElementById('txtagency').value);
     
     document.getElementById('txtsperson').value=trim(document.getElementById('txtsperson').value);
     
     document.getElementById('txtcust').value=trim(document.getElementById('txtcust').value);
     
    if(document.getElementById('txtagency').value!="" )
    {
        flag="1";
    }
    if(document.getElementById('txtsperson').value!="" )
    {
        flag="1";
    }
    if(document.getElementById('txtcust').value!="" )
    {
        flag="1";
    }
    if(document.getElementById('txtfromdate').value!="" )
    {
        fromdate=document.getElementById('txtfromdate').value;
        var dateformat=document.getElementById('hiddendateformat').value;
        if(dateformat=="dd/mm/yyyy")
        {
            var arrfromdate=fromdate.split('/');
            var dd=arrfromdate[0];
            var mm=arrfromdate[1];
            var yy=arrfromdate[2];
            fromdate=mm+"/"+dd+"/"+yy;
            fromdate=new Date(fromdate);
        }
        if(dateformat=="yyyy/mm/dd")
        {
            var arrfromdate=fromdate.split('/');
            var dd=arrfromdate[2];
            var mm=arrfromdate[1];
            var yy=arrfromdate[0];
            fromdate=mm+"/"+dd+"/"+yy;
            fromdate=new Date(fromdate);
        }
        if(dateformat=="mm/dd/yyyy")
        {
            fromdate=new Date(fromdate);
        }
        flag="1";
        
    }
    if(document.getElementById('txttodate').value!="" )
    {
        todate=document.getElementById('txttodate').value;
        var dateformat=document.getElementById('hiddendateformat').value;
        if(dateformat=="dd/mm/yyyy")
        {
            var arrtodate=todate.split('/');
            var dd=arrtodate[0];
            var mm=arrtodate[1];
            var yy=arrtodate[2];
            todate=mm+"/"+dd+"/"+yy;
            todate=new Date(todate);
        }
        if(dateformat=="yyyy/mm/dd")
        {
            var arrtodate=todate.split('/');
            var dd=arrtodate[2];
            var mm=arrtodate[1];
            var yy=arrtodate[0];
            todate=mm+"/"+dd+"/"+yy;
            todate=new Date(todate);
        }
        if(dateformat=="mm/dd/yyyy")
        {
            todate=new Date(todate);
        }
        flag="1";
    }
    if(document.getElementById('txtsheldate').value!="" )
    {
        sheldate=document.getElementById('txtsheldate').value;
        var dateformat=document.getElementById('hiddendateformat').value;
        if(dateformat=="dd/mm/yyyy")
        {
            var arrsheldate=sheldate.split('/');
            var dd=arrsheldate[0];
            var mm=arrsheldate[1];
            var yy=arrsheldate[2];
            sheldate=mm+"/"+dd+"/"+yy;
            sheldate=new Date(sheldate);
        }
        if(dateformat=="yyyy/mm/dd")
        {
            var arrsheldate=sheldate.split('/');
            var dd=arrsheldate[2];
            var mm=arrsheldate[1];
            var yy=arrsheldate[0];
            sheldate=mm+"/"+dd+"/"+yy;
            sheldate=new Date(sheldate);
        }
        if(dateformat=="mm/dd/yyyy")
        {
            sheldate=new Date(sheldate);
        }
        flag="1";
        
    }
    if(document.getElementById('insertntodate').value!="" )
    {
        inserdate=document.getElementById('insertntodate').value;
        var dateformat=document.getElementById('hiddendateformat').value;
        if(dateformat=="dd/mm/yyyy")
        {
            var arrinserdate=inserdate.split('/');
            var dd=arrinserdate[0];
            var mm=arrinserdate[1];
            var yy=arrinserdate[2];
            inserdate=mm+"/"+dd+"/"+yy;
            inserdate=new Date(inserdate);
        }
        if(dateformat=="yyyy/mm/dd")
        {
            var arrinserdate=inserdate.split('/');
            var dd=arrinserdate[2];
            var mm=arrinserdate[1];
            var yy=arrinserdate[0];
            inserdate=mm+"/"+dd+"/"+yy;
            inserdate=new Date(inserdate);
        }
        if(dateformat=="mm/dd/yyyy")
        {
            inserdate=new Date(inserdate);
        }
        flag="1";
    }
    if(document.getElementById('txttext').value!="" )
    {
        flag="1";
    }
    if(document.getElementById('drpStatus').value!="0")
    {
        flag="1";
    }
    if(flag=="0")
    {
        alert('Please Fill at least One Field')
        return false;
    }
    if(document.getElementById('txtfromdate').value!="")
    {
        if(document.getElementById('txttodate').value=="")
        {
            
            alert('Please Enter Order To Date');
            document.getElementById('txttodate').focus();
            return false;
        }
    }
    if(document.getElementById('txtsheldate').value!="")
    {
        if(document.getElementById('insertntodate').value=="")
        {
           
            alert('Please Enter Insertion To Date');
            document.getElementById('insertntodate').focus();
            return false;
        }

        if(document.getElementById('txtsheldate').value!="" && document.getElementById('insertntodate').value!="")
        {
            if(inserdate<sheldate)
            {
                alert('To Insertion Date should not be less than Insertion From Date');
                document.getElementById('insertntodate').value="";
                return false;
            }
        }
        
    }
    if(todate<fromdate)
    {
        alert('To Date should not be less than From Date');
        document.getElementById('txttodate').value="";
        document.getElementById('txttodate').focus();
        return false;
    }
    if(document.getElementById('insertntodate').value!="" && document.getElementById('txtsheldate').value=="")
    {
        alert('Please Enter Insertion From Date');
        document.getElementById('txtsheldate').focus();
        return false;
        
    }
    if(document.getElementById('txttodate').value!="" && document.getElementById('txtfromdate').value=="")
    {
        alert('Please Enter Order From Date');
        document.getElementById('txtfromdate').focus();
        return false;
        
    }
}

//function clearHidden()
//{
//    document.getElementById('hdnagency').value="";
//    document.getElementById('hdnsperson').value="";
//    document.getElementById('hdnclient').value="";
//}

function ClientisDate(event)
{
	if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11)|| (event.keyCode==13)|| (event.keyCode==8) || (event.keyCode==47))
	{
		
		return true;
	}
	else
	{
		return false;
	}
	
}
