// JScript File
function deletedata()
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
    if(document.getElementById('drpdelition').value=="0")
    {
     alert("Please Select Status For Deletion");
     document.getElementById('drpdelition').focus();
        return false;
    }
    
    var dateformat=document.getElementById('hiddendateformat').value;
    var fdat=document.getElementById('txtFromDate').value
    var tdat=document.getElementById('txtToDate').value;
    
                    var dateformat=document.getElementById('hiddendateformat').value;
                
                            if(dateformat=="dd/mm/yyyy")
            {
            var txt2=fdat.split("/");
            var dd=txt2[0];
            var mm=txt2[1];
            var yy=txt2[2];
            fdat=mm+'/'+dd+'/'+yy;
            }
            else if(dateformat=="yyyy/mm/dd")
            {
            var txt2=fdat.split("/");
            var dd=txt2[2];
            var mm=txt2[1];
            var yy=txt2[0];
            fdat=mm+'/'+dd+'/'+yy;
            }
            if(dateformat=="dd/mm/yyyy")
            {
            var txt2=tdat.split("/");
            var dd=txt2[0];
            var mm=txt2[1];
            var yy=txt2[2];
            tdat=mm+'/'+dd+'/'+yy;
            }
            else if(dateformat=="yyyy/mm/dd")
            {
            var txt2=tdat.split("/");
            var dd=txt2[2];
            var mm=txt2[1];
            var yy=txt2[0];
            tdat=mm+'/'+dd+'/'+yy;
            }

    
    
    
    
    
    
    
    var fdate=new Date(fdat);
    var tdate= new Date(tdat);
    
    
    if(fdate>tdate)
    {
        alert(" ToDate should be greater than Fromdate");
        document.getElementById('txtToDate').value="";
        document.getElementById('txtToDate').focus();
        return false;
    }
    
    var curdate=new Date();
    //var tdate=new date();
    var dd=curdate.getDate();
    var mm=curdate.getMonth()+1;
    var yyyy=curdate.getFullYear();
    
    	    var curdate1=mm+'/'+dd+'/'+yyyy;
			var curdate1d=dd+'/'+mm+'/'+yyyy;
			var curdate1y=yyyy+'/'+mm+'/'+dd;
   
   	    if(dateformat=="mm/dd/yyyy")
		{
		var tdate=new Date(document.getElementById('txtToDate').value);
		var cdate=new Date(curdate1);
	         if(tdate>=cdate)
             {
                alert(" ToDate should be less than Current Date");
                document.getElementById('txtToDate').focus();
                return false;
             }
		}
		
		if(dateformat=="dd/mm/yyyy")
		{
		var tdate=new Date(document.getElementById('txtToDate').value);
		var cdate=new Date(curdate1d);
	         if(tdate>=cdate)
             {
                alert(" ToDate should be less than Current Date");
                document.getElementById('txtToDate').focus();
                return false;
             }
		}
		
		if(dateformat=="yyyy/mm/dd")
		{
		var tdate=new Date(document.getElementById('txtToDate').value);
		var cdate=new Date(curdate1y);
	         if(tdate>cdate)
             {
                alert(" ToDate should be less than Current Date");
                document.getElementById('txtToDate').focus();
                return false;
             }
		}
		
		if(dateformat=="dd/mm/yyyy")
							{   
							   
								var txtfrom=document.getElementById('txtFromDate').value;
								var txtto=document.getElementById('txtToDate').value;
								
								var txtfrom1=txtfrom.split("/");
								var dd=txtfrom1[0];
								var mm=txtfrom1[1];
								var yy=txtfrom1[2];
								fromdate=mm+'/'+dd+'/'+yy;
																
							}
							else if(dateformat=="mm/dd/yyyy")
							{
								fromdate=document.getElementById('txtFromDate').value;
								todate=document.getElementById('txtToDate').value;
							}
								
							else if(dateformat=="yyyy/mm/dd")
							{
								var txt=document.getElementById('txtFromDate').value;
								var txt1=txt.split("/");
								var yy=txt1[0];
								var mm=txt1[1];
								var dd=txt1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								var txtto=document.getElementById('txtToDate').value;
								var txtto1=txtto.split("/");
								var yy1=txtto1[0];
								var mm1=txtto1[1];
								var dd1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
							}
							if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								fromdate=document.getElementById('txtFromDate').value;
								todate=document.getElementById('txtToDate').value;
							}
			
		
		
   
 
//    var fromdate=document.getElementById('txtFromDate').value;
//    var todate=document.getElementById('txtToDate').value;
    var status=document.getElementById('drpdelition').value;
    
    deletion.chkdate(fromdate,todate,calldelete);
    return false;
  }
  
function calldelete(response)
{
    var ds=response.value;
     var dateformat=document.getElementById('hiddendateformat').value;
    var fromdate=document.getElementById('txtFromDate').value;
    var todate=document.getElementById('txtToDate').value;
    
       var status=document.getElementById('drpdelition').value;
       if(dateformat=="dd/mm/yyyy")
							{   
							   
								var txtfrom=document.getElementById('txtFromDate').value;
								var txtto=document.getElementById('txtToDate').value;
								
								var txtfrom1=txtfrom.split("/");
								var dd=txtfrom1[0];
								var mm=txtfrom1[1];
								var yy=txtfrom1[2];
								fromdate=mm+'/'+dd+'/'+yy;
																
							}
							else if(dateformat=="mm/dd/yyyy")
							{
								fromdate=document.getElementById('txtFromDate').value;
								todate=document.getElementById('txtToDate').value;
							}
								
							else if(dateformat=="yyyy/mm/dd")
							{
								var txt=document.getElementById('txtFromDate').value;
								var txt1=txt.split("/");
								var yy=txt1[0];
								var mm=txt1[1];
								var dd=txt1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								var txtto=document.getElementById('txtToDate').value;
								var txtto1=txtto.split("/");
								var yy1=txtto1[0];
								var mm1=txtto1[1];
								var dd1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
							}
							if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								fromdate=document.getElementById('txtFromDate').value;
								todate=document.getElementById('txtToDate').value;
							}
    
    if(ds.Tables[0].Rows.length>0)
    {
        boolReturn = confirm("Are you sure you wish to delete this?");
		if(boolReturn==1)
		{
		
		
		deletion.statusdelete(fromdate,todate,status);
		alert ("Data Deleted Successfully");
		document.getElementById('txtFromDate').value="";
        document.getElementById('txtToDate').value="";
        document.getElementById('drpdelition').value="0"
        return false;
       }
    }
    else
    {
        alert("Data not fround");
    	document.getElementById('txtFromDate').value="";
       document.getElementById('txtToDate').value="";
       document.getElementById('drpdelition').value="0"
        return false;
    }
  return false; 
 }
 



function Checkdate(input)
{
var dateformat=document.getElementById('hiddendateformat').value;
	
    if(dateformat=="mm/dd/yyyy")
	{ 
		 var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
	   
	}
	if(dateformat=="yyyy/mm/dd")
	 
	{
		var validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
	}
	if(dateformat=="dd/mm/yyyy")
	{
		var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
	}

	if (!validformat.test(input.value))
	{
		if(input.value=="")
		{
		return true;
		}
		alert(" Please fill the date in "+dateformat+" format");
		document.getElementById('txtFromDate').value="";
		document.getElementById('txtFromDate').focus();
		return false;
	}
}





