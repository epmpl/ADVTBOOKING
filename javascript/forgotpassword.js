// JScript File

function submitClick()
{
var res=Forgetpassword.submitClick(document.getElementById('txtemail').value);
var ds=res.value;
if(ds==null)
{
    alert(res.error.description);
    return false;
}
if(ds.Tables[0].Rows.length<=0)
{
    alert("E-mail ID does not Exist.");
    return false;
}
}

function clientemailcheck(q) 
{
	var theurl=document.Form1.txtemail.value;

	if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(theurl) || document.getElementById('txtemail').value=="")
	{
		return (true)
	}
	alert("Invalid E-mail Address! Please re-enter.")
	   document.getElementById("txtemail").value="";
	document.getElementById("txtemail").focus();
	return (false)
}



