// JScript File
function binddepocode()
{
    var agencycode=document.getElementById('drpagency').value; 
    Aduser.binddepo(agencycode,call_binddepo);
}

function call_binddepo(res)
{
    var ds=res.value;
		    //
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            document.getElementById('txtgenno').value=ds.Tables[0].Rows[0].GEN_NO;
        }
    }

}

function updategenno()
{
    var agencycode=document.getElementById('drpagency').value;
    var genno=document.getElementById('txtmodgenno').value;
    if(genno=="")
    {
        alert("Please Enter Modified Gen No");
        document.getElementById('txtmodgenno').focus();
        return false;
    } 
    if(parseInt(genno)<=parseInt(document.getElementById('txtgenno').value))
    {
        alert("Modify Gen No Should be Greater than Gen No");
        document.getElementById('txtmodgenno').value="";
        document.getElementById('txtmodgenno').focus();
        return false;
    }
    Aduser.updategno(agencycode,genno);
    document.getElementById('drpagency').value="0";
    document.getElementById('txtmodgenno').value="";
    document.getElementById('txtgenno').value="";
    alert("Data Modified Successfully");
    return false;
}

function exitclick()
{
			if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
			return false;
}