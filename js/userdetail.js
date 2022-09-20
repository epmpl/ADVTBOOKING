

var flag="true";

function isEmailAddress(email)
{
var email_string = new String(email);
var at_index = email_string.indexOf("@");
if (at_index>0)
{
var dot_index = email_string.indexOf('.', at_index);
if ((dot_index>at_index+1) && (email_string.length>dot_index+1))
{
return true;
}

}
}
 function chkvalid()
{
if (document.getElementById('txtemailid').value=="")
{
alert("Enter Email !");
document.getElementById('txtemailid').focus();
return false;
}
else if (!isEmailAddress(document.getElementById('txtemailid').value))
{
alert("Please Enter valid Email Address");
//alert(" **@**.** ");

document.getElementById('txtemailid').focus();
return false;
}
}

function login()
{
  if(document.getElementById('txtloginid').value=="")
  {
  alert('Plaese Enter The Login Id');
  document.getElementById('txtloginid').focus();
//    document.getElementById('txtloginid').style.visibility='visible';
    return false;
  }

else if(document.getElementById('txtfirstname').value=="")
  {
    alert('Plaese Enter The firstname');
    document.getElementById('txtfirstname').focus();
    return false;
  }
else if(document.getElementById('txtlastname').value=="")
  {
  alert('Plaese Enter The lastname');
  document.getElementById('txtlastname').focus();
  return false;
  }
  else if(document.getElementById('txtpassword').value=="")
  {
  alert('Plaese Enter The password');
  document.getElementById('txtpassword').focus();
  return false;
  }
else if(document.getElementById('txtrepassword').value=="")
  {
  alert('Plaese Enter The repassword');
  document.getElementById('txtrepassword').focus();
  return false;
  }
else if(document.getElementById('txtquestion').value=="0")
  {
  alert('Plaese Chosse The Question');
  document.getElementById('txtquestion').focus();
  return false;
  }
else  if(document.getElementById('txtanswer').value=="")
  {
  alert('Plaese Enter The answer');
  document.getElementById('txtanswer').focus();
  return false;
  }
else if(document.getElementById('txtmobileno').value=="")
  {
  alert('Plaese Enter The mobileno');
  document.getElementById('txtmobileno').focus();
  return false;
  }
  else if(document.getElementById('txtcontactno0').value=="")
  {
  alert('Plaese Enter The contactno0');
  document.getElementById('txtcontactno0').focus();
  return false;
  }
  else if(document.getElementById('txtcontactno1').value=="")
  {
  alert('Plaese Enter The contactno01');
  document.getElementById('txtcontactno1').focus();
  return false;
  }
  else if(document.getElementById('txtcontactno2').value=="")
  {
  alert('Plaese Enter The contactno2');
  document.getElementById('txtcontactno2').focus();
  return false;
  }
  else if(document.getElementById('checkbox1').checked==false)
  {
  alert('Plaese Accept the terms and condotion');
  document.getElementById('checkbox1').focus();
  return false;
  }
}


///*****************************************************/
//function colorchang()
//{
//alert('ab');
//document.getElementById('submit_info').disabled=true;
// document.getElementById('submit_info').style.background-color="red";
// 
// .style.borderColor='gray';
// }
//document.getElementById('toolsbox_bgcolor').disabled=true;
//        document.getElementById('toolsbox_bgcolor').style.borderColor='gray';
//        

/*********************************************************************************
************Auto Generated Code
*********************************************************************************/

// Auto generated
// This Function is for check that whether this is case for new or modify



function Autoornot()
		{
		    if(document.getElementById('txtloginid').value!="")
                {
                 
        
		//document.getElementById('txtloginid').value=document.getElementById('txtloginid').value.toUpperCase();
	   // document.getElementById('txtzonealias').value=document.getElementById('txtloginid').value;
		 str=document.getElementById('txtloginid').value;
		Userdetail.chkzonecodename(str,fillcall);
		return ;
     }
	return ;
 }

function fillcall(res)
	{
	var ds=res.value;
	var newstr;
	if(ds.Tables[0].Rows.length!=0)
		  {
		   //alert("This Login ID has already Exits !! ");
		   //document.getElementById('lblmsg').innerText='This Login ID has already Exits';
		   document.getElementById('lblmsg').style.visibility='visible';
    	   return;
   	    //else{ document.getElementById('lblmsg').style.visibility='hidden';}
    }
		
		        else
		        {
		          document.getElementById('lblmsg').style.visibility='hidden';
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].userid;
		                        }
		                    if(newstr !=null )
		                        {
		                        //var code=newstr.substr(2,4);
		                        var code=newstr;
		                        code++;
		                        document.getElementById('Autocode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                      {
		                        document.getElementById('Autocode').value=str.substr(0,2)+ "0";
		                        }
		     }
		     
		     
		     
	return false ;
		}
		
//function userdefine()
//    {
//        if(hiddentext=="new")
//        {
//        
//        document.getElementById('txtzonecode').disabled=false;
//        document.getElementById('txtzonename').value=document.getElementById('txtzonename').value.toUpperCase();
//        document.getElementById('txtzonealias').value=document.getElementById('txtzonename').value;
//        auto=document.getElementById('hiddenauto').value;
//         return false;
//        }

//return false;
//}
/*****************************************************************/
//function chkpasswd()
//{
//if(document.getElementById('txtrepassword').value=="")
//{
//document.getElementById('lblrepwd').style.visibility='visible';
////alert('Please Enter The RePassword');
////document.getElementById('txtrepassword').focus();
//return ;
//}
//else
//{
// document.getElementById('lblrepwd').style.visibility='hidden';
//}
//return false;
//}
function repassword()
{
   if(document.getElementById('txtpassword').value!=document.getElementById('txtrepassword').value)
{
//if(flag=="false")
//{
//document.getElementById('lblmsgrepwd').style.visibility='visible';
// document.getElementById('lblmsgrepwd').style.visibility='visible';
document.getElementById('lblmsgrepwd').style.visibility='visible';
document.getElementById('txtrepassword').value="";
document.getElementById('txtrepassword').focus();
//return false;
//}
return false;
}
 else
    {
	  document.getElementById('lblmsgrepwd').style.visibility='hidden';
	  return;
	}
return false;
}
function pwdlength()
{
    if(document.getElementById('txtpassword').value.length < 6)
    {
    document.getElementById('txtpassword').value="";
    document.getElementById('txtpassword').focus();
        document.getElementById('lblpwdlen').style.visibility='visible';
//        flag="false";
        
        return false;
    }
    else{document.getElementById('lblpwdlen').style.visibility='hidden';//flag="true";
    }
}

function lblhidden()
{
    document.getElementById('lblmsg').style.visibility='hidden';
    document.getElementById('lblmsgrepwd').style.visibility='hidden';
    document.getElementById('lblpwdlen').style.visibility='hidden';
    ////document.getElementById('lblrepwd').style.visibility='hidden';
    ////document.getElementById('txtloginid').style.visibility='hidden';
}

function cancel1()
{
        document.getElementById('txtloginid').value="";
         document.getElementById('txtfirstname').value="";
         document.getElementById('txtlastname').value="";
         document.getElementById('txtpassword').value="";
         document.getElementById('txtrepassword').value="";
         document.getElementById('txtquestion').value="";
         document.getElementById('txtanswer').value="";
         document.getElementById('txtemailid').value="";
         document.getElementById('txtmobileno').value="";
         document.getElementById('txtcontactno0').value="";
         document.getElementById('txtcontactno1').value="";
         document.getElementById('txtcontactno2').value="";
         return false;

}