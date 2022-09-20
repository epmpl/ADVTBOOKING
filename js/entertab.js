// JScript File

function tabvalue (id)
{
alert(event.keyCode)
if(event.keyCode==13)
{
savedialog()
if(document.activeElement.id==id)
{
document.getElementById('saveT').focus();
return false;

}
else if(document.activeElement.type=="button" || document.activeElement.type=="cancle")
{
event.keyCode=13;
return event.keyCode;

}
else
{
    event.keyCode=9;
    return event.keyCode;
}
}



}