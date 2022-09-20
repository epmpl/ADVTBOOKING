// JScript File

function tabvalue (id)
{



if(event.keyCode==13)
{

//btnsubmit

if(document.activeElement.id==id)
{
    document.getElementById('btnsubmit').focus();
    event.keyCode=13;
return event.keyCode;

}

else 
if(document.activeElement.type=="button" || document.activeElement.type=="submit")
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

