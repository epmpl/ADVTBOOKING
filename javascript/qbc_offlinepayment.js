// JScript File
//Remove Space

function LTrim( value ) {
	
	var re = /\s*((\S+\s*)*)/;
	return value.replace(re, "$1");
	
}

// Removes ending whitespaces
function RTrim( value ) {
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}

// Removes leading and ending whitespaces
function trim( value ) 

{
	
	return LTrim(RTrim(value));
	
}
function savedata()
{
  if(trim(document.getElementById('txtchqno').value)=="")
  {
    alert("Please enter Cheque No.");
    document.getElementById('txtchqno').focus();
    return false;
  }
  if(trim(document.getElementById('txtamount').value)=="")
  {
    alert("Please enter Amount");
    document.getElementById('txtamount').focus();
    return false;
  }
  if(document.getElementById('lblfilename').value=="")
  {
    alert("Please Upload Attachment");
  
    return false;
  }
    var res=qbc_offlinepayment.saveData(document.getElementById('txtreceiptno').value,document.getElementById('txtchqno').value,document.getElementById('txtchqdate').value,document.getElementById('txtamount').value,document.getElementById('drpchqmode').value,document.getElementById('txtbankname').value,document.getElementById('txtbankbranch').value,document.getElementById('hiddenfilename').value,document.getElementById('hiddendateformat').value);
    if(res.error!=null)
    {
        alert(res.error.description);
        return false;
    }   
    alert("Payment Details Saved");
    return false;
}
//==============Function for tab============
function tabvalue11 (event,id)
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
            else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image" )
            {
                event.keyCode=13;
                return event.keyCode;

            }
            else if(document.activeElement.type=="file")
            document.getElementById('Button1').focus();
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