// JScript File
function bindQBC()
{
PublishAudit.fillQBC(document.getElementById('drpcenter').value,bindQBC_callback);
}
function bindQBC_callback(response)
{
    //alert(response.value);
    var ds=response.value;
    agcatby = document.getElementById("drpbranch");
 agcatby.options.length = 1; 
    agcatby.options[0]=new Option("--Select Branch--","0");
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);
    var j=1;
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        agcatby.options[j] = new Option(ds.Tables[0].Rows[i].Branch_Name,ds.Tables[0].Rows[i].Branch_Code);
        
       j++;
       
    }
    }
}




function cleardata()
{
        document.getElementById('txttilldate').value="";
		document.getElementById('txtvalidityfrom').value="";
		document.getElementById('drpadtype').value="0";
		document.getElementById('drpcenter').value="0";
		document.getElementById('drpbranch').options.length="0";
		if(document.getElementById('btnPublish')!=null)
		    document.getElementById('btnPublish').style.visibility="hidden";
		if(document.getElementById("DataGrid1")!=null)
		    document.getElementById("DataGrid1").outerHTML="";
    return false;
		
}

function display()
{
if(count==0)
{
   document.getElementById('divgrid1').style.display='none';
   count = count + 1;
}
else
{
    document.getElementById('divgrid1').style.display='block';
}
}


function executeclick()
{
//chk="e";
////var advtype=document.getElementById('drpadvtype').value;
//document.getElementById('ListBox1').value;
////var edition=document.getElementById('drpedition').value;

var todate=document.getElementById('txtvalidityfrom').value;
var fromdate=document.getElementById('txttilldate').value;

if(document.getElementById('drpadtype').value=="0")
              {
              alert("Please Select Ad Type");
              document.getElementById('drpadtype').focus();
              return false;
              }
// else if(document.getElementById('drprevenu').value=="0") 
//              {
//              alert("Please Select Revenue Center");
//              document.getElementById('drprevenu').focus();
//              return false;
//              }            
if(todate=="" || fromdate=="")
{
    alert('Please Fill Date');
    return false;
}
else
{
var dateformat = document.getElementById('hiddendateformat').value;
	document.getElementById('divgrid1').style.display='block';
	//document.getElementById('DataGrid1').style.Visibility=true;	
		if(dateformat=="dd/mm/yyyy")
							{
								var txtfrom=document.getElementById('txtvalidityfrom').value;
								var txtto=document.getElementById('txttilldate').value;
								
								var txtfrom1=txtfrom.split("/");
								var dd=txtfrom1[0];
								var mm=txtfrom1[1];
								var yy=txtfrom1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								var txtto1=txtto.split("/");
								var dd1=txtto1[0];
								var mm1=txtto1[1];
								var yy1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
								
							}
							else if(dateformat=="mm/dd/yyyy")
							{
								fromdate=document.getElementById('txtvalidityfrom').value;
								todate=document.getElementById('txttilldate').value;
							}
								
							else if(dateformat=="yyyy/mm/dd")
							{
								var txt=document.getElementById('txtvalidityfrom').value;
								var txt1=txt.split("/");
								var yy=txt1[0];
								var mm=txt1[1];
								var dd=txt1[2];
								fromdate=mm+'/'+dd+'/'+yy;
								var txtto=document.getElementById('txttilldate').value;
								var txtto1=txtto.split("/");
								var yy1=txtto1[0];
								var mm1=txtto1[1];
								var dd1=txtto1[2];
								todate=mm1+'/'+dd1+'/'+yy1;
							}
							if(dateformat==null || dateformat=="" || dateformat=="undefined")
							{
								alert("dateformat  is either null or undefined");
								fromdate=document.getElementById('txtvalidityfrom').value;
								todate=document.getElementById('txttilldate').value;
							}
						
		if(todate != "" || todate != null || todate != "undefined")
		{
			tdate = new Date(todate);
			fdate= new Date(fromdate);
			
			if(tdate=="NaN" || tdate=="NaN")
			{
//			if(document.getElementById('btnPublish')!=null)
//            document.getElementById('btnPublish').style.visibility="visible";
			alert('Please enter date in correct format');
			if(document.getElementById('btnPublish')!=null)
		    document.getElementById('btnPublish').style.visibility="hidden";
			
			return false;
			
			
			}
			
			
			
			if(tdate<fdate)
			{
			alert("Valid To date must be greater than Valid From date");
			document.getElementById('txttilldate').disabled=false;
			document.getElementById('txttilldate').focus();
			return false;
			}
//			if(tdate)
//			{
//			alert("dateformat  is either null or undefined");
//			document.getElementById('txttilldate').disabled=false;
//			document.getElementById('txttilldate').focus();
//			return false;
//			}
//			if(fdate)
//			{
//			alert("dateformat  is either null or undefined");
//			document.getElementById('txtvalidityfrom').disabled=false;
//			document.getElementById('txtvalidityfrom').focus();
//			return false;
//			}


		}


}
//var branch = document.getElementById('hiddenbranch').value;
if(document.getElementById('drpbranch').selectedIndex!='-1' && document.getElementById('drpbranch').selectedIndex!='0')
    document.getElementById('hiddenbranch').value=document.getElementById('drpbranch').options[document.getElementById('drpbranch').selectedIndex].text;
else
    document.getElementById('hiddenbranch').value="";    
if(document.getElementById('btnPublish')!=null)
document.getElementById('btnPublish').style.visibility="visible";

}
function publishAudit()
{
    if(document.getElementById("DataGrid1")==null)
        return false;
    str=document.getElementById("DataGrid1");
    var insert_id="";
    var chk_insert="";
    for(var i=0;i<document.getElementById("DataGrid1").rows.length-1;i++)
    {
        var chkid="chk" + i;
        insert_id="";
        if(document.getElementById(chkid).checked==true)
        {   
            insert_id = document.getElementById(chkid).value;
            PublishAudit.updateStatus(insert_id);
            chk_insert=insert_id;
//            if(insert_id=="")
//                insert_id = document.getElementById(chkid).value;
//            else
//                insert_id = "'"+insert_id + "','" + document.getElementById(chkid).value+"'";   
        }
    }
    if(chk_insert=="")
    {
        alert("Please select atleast One Insertion for Publish Audit");
        return false;
    }
    
   // executeclick();
   alert("Publish Audit Completed Successfully");
//   var compcode =document.getElementById('hiddencomcode').value;
//   var dateformat = document.getElementById('hiddendateformat').value;
//   var adtype=document.getElementById('drpadtype').value;
//   var fromdate=document.getElementById('txtvalidityfrom').value;
//   var	tilldate=document.getElementById('txttilldate').value;
//   var branch=document.getElementById('drpbranch').value;
//   var publication=document.getElementById('drpcenter').value;
//     PublishAudit.refreshgrid(compcode,dateformat,tilldate, fromdate,  publication, adtype,  branch,callback_refreshgrid);
}

//function callback_refreshgrid(response)
//{
//var ds=response.value;
//document.getElementById('DataGrid1').dataSrc=ds;

//document.getElementByI("DataGrid1").DataSource=ds;

//document.getElementById("DataGrid1").Bind();
//}
function clientdate()
{
    if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==47)||(event.keyCode==11))
    {

        return true;
    }
    else
    {
        return false;
    }
}