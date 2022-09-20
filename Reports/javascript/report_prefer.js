// JScript File

function updateprefer()
{
var pubcent=document.getElementById('dpdpubcentpermit').value;
var comp=document.getElementById('hiddencompcode').value;
if(document.getElementById('dpdpubcentpermit').value=="0")
{
document.getElementById('hiddenpermission').value="0";
}
else
{
document.getElementById('hiddenpermission').value="1";
}
var acs=document.getElementById('hiddenpermission').value;


Reports_reportprefer.update_prefer(pubcent,comp,acs);
alert('Preference Updated Successfully');
return false;

}

function accessrights()
{
if(document.getElementById('dpdpubcentpermit').value=="0")
{
alert('You can not open this form if you dont allow pubcent permission')// want to give any permission to publication center')
}
else
{
window.open("access_rights.aspx");
}
}