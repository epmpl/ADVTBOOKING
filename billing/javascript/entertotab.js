// JScript File

function tabvalue (id)
{



if(event.keyCode==13)
{
if(document.activeElement.id==id)
{
    if(document.getElementById('btnSave').disabled==false)
    {
document.getElementById('btnSave').focus();
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

