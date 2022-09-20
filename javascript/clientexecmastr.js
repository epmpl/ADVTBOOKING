// JScript File


var code10="";

//*********************submit client product****************************

function clientprodsave()
{

		    var	client_code=document.getElementById('hiddenclientcode').value;
            var client_name=document.getElementById('dclient').value;
            var exec_code=document.getElementById('drpExecutive').value;
         	var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
		//	var execcode1 = document.getElementById('drpproductexec').value;
			clientexecutivemast.saveclient(client_code,client_name,exec_code,compcode,userid);
			window.location=window.location;
			return false;
			}

//**********************delete client product******************************
function deleteclientprod()
{

var	client_code=document.getElementById('hiddenclientcode').value;
var compcode=document.getElementById('hiddencompcode').value; 
var client_name=document.getElementById('dclient').value;
 var exec_code=document.getElementById('drpExecutive').value;
           
var userid=document.getElementById('hiddenuserid').value; 
var datagrid=document.getElementById('DataGrid1');
//var exec_name = document.getElementById('drpproductexec').value; 

var j;
var k=0;
var i=document.getElementById("DataGrid1").rows.length -1;

   for(j=0;j<i;j++)
	{
	var str="DataGrid1__ctl_CheckBox1"+j;
	if(document.getElementById(str).checked==true)
	   {
	   k=k+1;
	    var code10=document.getElementById(str).value;
	
	   }
	}
	if(k==1)
	{
	    var gridrowlen=document.getElementById('DataGrid1').rows.length-1;
	    if(gridrowlen==1)
	    {
	        alert('One record should be present here');
	        return false;
	    }
	  clientexecutivemast.deleteclient(client_code,client_name,exec_code,compcode,userid,code10);
	  window.location=window.location;
	  return false;
	}
	
	else
	{
	  alert("You Can Select One Row At A Time");
	  return false;
	}
	
	
	return false;

}




		

function uppercase1()
{
				document.getElementById('codetext').value=document.getElementById('codetext').value.toUpperCase();
return ;
}
		
function uppercase2()
{
				document.getElementById('prodtext').value=document.getElementById('prodtext').value.toUpperCase();
return ;
}
function charval()
{
			if((event.keyCode>=48 && event.keyCode<=57)||
			(event.keyCode==127)||(event.keyCode==37)||
			(event.keyCode>=97 && event.keyCode<=122)||
			(event.keyCode>=65 && event.keyCode<=90)||
			(event.keyCode==9))
			{
			return true;
			}
			else
			{
			return false;
			}
}

	

function charval1()
{
			if((event.keyCode>=97 && event.keyCode<=122)||(event.keyCode>=48 && event.keyCode<=57)||
			(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==37)||(event.keyCode==32))
			{
			return true;
			}
			else
			{
			return false;
			}
}

function clearclick17()
{
			document.getElementById('drpExecutive').value="0";
		//	document.getElementById('drpproductexec').value="0";
		
		    code10=""
			
			if(document.getElementById('hiddenchk').value!="1")
			{
			var j;
			var k=0;
			//var DataGrid1__ctl_CheckBox1= new Array();
			var i=document.getElementById("DataGrid1").rows.length -1;

			for(j=0;j<i;j++)
				{
						var str="DataGrid1__ctl_CheckBox1"+j;         
						document.getElementById(str).checked=false;
				}
        }
        document.getElementById('btndelete').disabled=true;
        return false;
}
		
//****************************selected value***************************


function selected(ab)
{
var id=ab;
var client_code=document.getElementById('hiddenclientcode').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var datagrid=document.getElementById('DataGrid1');
			 if(document.getElementById(id).checked==false)
             {
            //flag="0";
            clearclick17();
            //document.getElementById(ab).checked=false;
            return;// false;
       
            }
var j;
var t=1;
var k=0;
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	var str="DataGrid1__ctl_CheckBox1" + j;
		document.getElementById(str).checked=false;
                        document.getElementById(id).checked=true;
	if(document.getElementById(str).checked==true)
	{
	   k=k+1;
	   code10=document.getElementById(str).value;
	}
	}
	if(k==1)
	{
			if(document.getElementById('hiddenchk').value!="2")
                {
					document.getElementById('btndelete').disabled=false;
					}
					else
					{
					    document.getElementById('btndelete').disabled=true;
					}
	clientexecutivemast.bandcontact12(client_code,compcode,userid,code10,call_select12);
	return;
	
	}
	else
	{
	alert("You Can Select One Row At A Time");
	return;
	}
	return false;
	

}
function call_select12(response)
{

var ds=response.value;
document.getElementById('dclient').value=ds.Tables[0].Rows[0].CLIENT_NAME;	
document.getElementById('drpExecutive').value=ds.Tables[0].Rows[0].EXEC_CODE;
//document.getElementById('drpproductexec').value=ds.Tables[0].Rows[0].exec_code;	
return false;

}
///to chk whether product is upadted or inserted
function xyz()
{
           if(document.getElementById('drpExecutive').value=="0")
			{
				alert("Please Select Executive");
				document.getElementById('drpExecutive').focus();
				return false;
			}	
var client_code=document.getElementById('hiddenclientcode').value;
var exec_code=document.getElementById('drpExecutive').value;
//var exec_code = document.getElementById('drpproductexec').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 

//var modifychk11 = document.getElementById('hiddenchk').value; 

                if(document.getElementById('hiddenchk').value=="1")
                {
				//window.location=window.location;
				      clientexecutivemast.chk(client_code,exec_code,compcode,userid,call_xyz);
					
				  //    return;
			    }
			    else
			    {
                       clientexecutivemast.chk(client_code,exec_code,compcode,userid,call_xyz);
                 }

return false;
}


function call_xyz(res)
{
ds=res.value;
if(ds.Tables[0].Rows.length == 0)
  {
      if(code10=="")
      {
       clientprodsave();
       return false;
       }
    else
      {
      document.getElementById('hiddenclientexec').value=code10;
      clientprodupdate();
      return false;
      }
  }
 else
  {
  alert('This Executive has been already alloted to client');
  }
  return false;
 }
   
  



function clientprodupdate()
{

			var client_prod_code=document.getElementById('hiddenclientexec').value;
		    var	client_code=document.getElementById('hiddenclientcode').value;
            var client_name=document.getElementById('dclient').value;
            var exec_code=document.getElementById('drpExecutive').value;
         	var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			//var exec_code=document.getElementById('drpproductexec').value;
			
			clientexecutivemast.updateclient(client_code,client_name,exec_code,compcode,userid,client_prod_code);
			window.location=window.location;
			return false;
	}


function closewindow()
{
    window.close();
}


function tabvalue (id)
{



    if(event.keyCode==13)
    {
        if(document.activeElement.id==id)
        {
            if(document.getElementById('btnsubmit').disabled==false)
            {
                document.getElementById('btnsubmit').focus();
            }
            return;

        }
        else if(document.activeElement.type=="button" || document.activeElement.type=="submit")
        {
            event.keyCode=13;
            return event.keyCode;
        }
        else
        {
            //alert(event.keyCode);
            event.keyCode=9;
            //alert(event.keyCode);
            return event.keyCode;
        }
    }
}