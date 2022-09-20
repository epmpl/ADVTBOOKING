// JScript File

function btngo1()
{
  var name=document.getElementById('loginid').value;
  
  forgetpass.forpass(name,callback_pass);
  return false;

}

function callback_pass(as)
{
 var ds=as.value;
 
if(ds.Tables[0].Rows.length!=0)
		  {
		   //alert("This Login ID has already Exits !! ");
		   //document.getElementById('lblmsg').innerText='This Login ID has already Exits';
		   var x=ds.Tables[0].Rows[0].userpassword;
		   alert('Your Password is '+ (x));
	
    }
		

}

//function lblhidden1()
//{
//    document.getElementById('lblmsg1').style.visibility='hidden';
////    document.getElementById('lblmsgrepwd').style.visibility='hidden';
////    document.getElementById('lblpwdlen').style.visibility='hidden';
//}