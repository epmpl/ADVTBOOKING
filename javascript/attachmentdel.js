

var ds;
function setnewfocus()
{
document.getElementById('txtrecptno').enable=true;
document.getElementById('txtrecptno').value="";
document.getElementById('txtrecptno').focus();
return false;
}

function del()
{
var res;
var recptno=document.getElementById("txtrecptno").value;
var compcode=document.getElementById("hiddencompcode").value

res=Attachmentdelete.selectval(compcode,recptno);
ds=res.value;
if(ds.Tables[0].Rows.length>0)
	{
		boolReturn = confirm("Are you sure you want to delete this?");
	        if(boolReturn==1)
	        {
	          Attachmentdelete.deletefun(compcode,recptno);
        		
	        }     
	        else
	        {
	        return false;
	        }
	        alert("Data Deleted Successfully!");
	        setnewfocus();
	}
	else
	{
	alert("Receipt Number Does Not Exist!");
	setnewfocus();
	return false;
	}
	

	
return false;


}




