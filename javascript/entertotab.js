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
    else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
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

function tabvalue (event,id)
{


var browser=navigator.appName;
//alert(event.which);
 if(browser!="Microsoft Internet Explorer")
 {
        if(event.which==13)
        {
        if(document.activeElement.id==id)
        {
            if(document.getElementById('btnSave').disabled==false)
            {
        document.getElementById('btnSave').focus();
            }
        return;

        }
        else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
        {
            event.which=13;
            return event.which;

        }
        else
        {
        //alert(event.keyCode);
        event.which=9;
        //alert(event.keyCode);
        return event.which;
        }
        }
 }       
else
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
            else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
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
        
        if(event.keyCode==120)
        {
           var formname=document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/")+1,document.URLUnencoded.lastIndexOf("."));
           window.open("Help.aspx?formname="+formname);
          
        }
}

}


//----------------------------For SchemeMaster--------------------------------------------------//

function tabvaluescheme (event,id)
{
    var browser=navigator.appName;
    if(browser!="Microsoft Internet Explorer")
    {
        if(event.which==13)
        {
        if(document.activeElement.id==id)
        {
            document.getElementById("tblgrid").rows(1).cells(0).children[0].focus();
        }
        else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
        {
            event.which=13;
            return event.which;

        }
        else
        {
            event.which=9;
            return event.which;
        }
        }
     }       
    else
    {
       if(event.keyCode==13)
         {
           if(document.activeElement.id==id)
            {
                document.getElementById("tblgrid").rows(1).cells(0).children[0].focus();
            }
            if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")// || document.activeElement.type=="text")
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
        
        if(event.keyCode==120)
        {
           var formname=document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/")+1,document.URLUnencoded.lastIndexOf("."));
           window.open("Help.aspx?formname="+formname);
          
        }
      }
 }

function pholeminlength(id)
{
if(document.getElementById(id).value.length < 4)
    {
    alert("Min. length can't be less than 4 digit");
    document.getElementById(id).value="";
    document.getElementById(id).focus();
    return false;
    }
}
function panvalidate(id)
{
if(document.getElementById(id).value.length < 5)
    {
    alert("Min. length can't be less than 5 digit");
    document.getElementById(id).value="";
    document.getElementById(id).focus();
    return false;
    }
}

///Changes the background color on focus
function changebackcolor(e) {
    var idfocus = e.id;
    if (idfocus != "") {
        document.getElementById(idfocus).style.backgroundColor = "";
    }
    document.getElementById(idfocus).style.backgroundColor = "#FFFF80";
    idfocus = e.id;
    return true;
}