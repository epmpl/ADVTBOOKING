// JScript File

var hiddentext;
var auto="";
var hiddentext1="";
var mod;
//function new_status_master()
//{
// document.getElementById('txtstatusname').disabled=false;
// document.getElementById('txtstatusname').focus();
// //return;
//}

function eventcalling11(event)
{

if(event.keyCode==97) 
    event.keyCode= 65;
if(event.keyCode==98) 
    event.keyCode= 66;
if(event.keyCode==99) 
    event.keyCode= 67;
if(event.keyCode==100) 
    event.keyCode= 68;
if(event.keyCode==101) 
    event.keyCode= 69;
if(event.keyCode==102) 
    event.keyCode= 70;
if(event.keyCode==103) 
    event.keyCode= 71;
if(event.keyCode==104) 
    event.keyCode= 72;
if(event.keyCode==105) 
    event.keyCode= 73;
if(event.keyCode==106) 
    event.keyCode= 74;
if(event.keyCode==107) 
    event.keyCode= 75;
if(event.keyCode==108) 
    event.keyCode= 76;
if(event.keyCode==109) 
    event.keyCode= 77;
if(event.keyCode==110) 
    event.keyCode= 78;
if(event.keyCode==111) 
    event.keyCode= 79;
if(event.keyCode==112) 
    event.keyCode= 80;
if(event.keyCode==113) 
    event.keyCode= 81;
if(event.keyCode==114) 
    event.keyCode= 82;
if(event.keyCode==115) 
    event.keyCode= 83;
if(event.keyCode==116) 
    event.keyCode= 84;
if(event.keyCode==117) 
    event.keyCode= 85;
if(event.keyCode==118) 
    event.keyCode= 86;
if(event.keyCode==119) 
    event.keyCode= 87;
if(event.keyCode==120) 
    event.keyCode= 88;
if(event.keyCode==121) 
    event.keyCode= 89;
if(event.keyCode==122) 
    event.keyCode= 90;
}

function save_status_master()
{
 var msg=checkSession();
        if(msg==false)
        return false;
  if(document.getElementById("txtstatusname").value=="")  
    {

            alert("Please Enter Status Name");
            document.getElementById('txtstatusname').focus();
            return false;
    
    }
	document.getElementById('txtstatusname').value=trim(document.getElementById('txtstatusname').value);
	if(document.getElementById("txtstatuscode").value=="" && document.getElementById('hiddenauto').value=="1")
	{
	    //autogen11();
	    document.getElementById('pnew').value="1";
	    return false;
	}
 //if(document.getElementById('hiddenauto').value!="1")
// {
 if(document.getElementById("txtstatuscode").value=="")
    {
        alert("Please Enter Status Code");
        if(document.getElementById('txtstatuscode').disabled==false)
        {
          document.getElementById('txtstatuscode').focus();
          return false;
        }
        return false;
         
    }
//}

    return;
}
function close_status_master()
{
  if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
			return false;
   

}
var hiddenauto="";
function autogen11()
 {
            if((document.getElementById('hiddenauto').value=="1"))
   
              {
                    
                    changeoccured();
                    //return false;
              }
                else
                {
                    userdefine();
                    return false;
                 }

return false;
}

function changeoccured()
{
 
  if((document.getElementById('hiddenauto').value=="1") && (document.getElementById('pnew').value=="1"))
			{
            uppercase3();
           }
            else
            {
            document.getElementById('txtstatusname').value=document.getElementById('txtstatusname').value.toUpperCase();
           // return ;
            }
return false;
}

function uppercase3()
		{
		  document.getElementById('txtstatusname').value=trim(document.getElementById('txtstatusname').value);
		  lstr=document.getElementById('txtstatusname').value;
		  cstr=lstr.substring(0,1);
            var mstr="";
            			   if(lstr.indexOf(" ")==1)
			            {
			            var leng=lstr.length;
			           mstr= cstr + lstr.substring(2,leng);
			            }
			            else
			            {
			             var leng=lstr.length;
			            mstr=cstr + lstr.substring(1,leng);
			            }
		    if(document.getElementById('txtstatusname').value!="")
                {
               
        
		document.getElementById('txtstatusname').value=document.getElementById('txtstatusname').value.toUpperCase();
	    str=mstr;
		status_master.adchkadvcode(str,fillcall);
		return false;
                }
                // document.getElementById('btnSave').focus();
     return false;
		
}

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length>0)
		    {
                //		        if(document.getElementById('query').value!="0")
                //		        {
                //		            if(document.getElementById("txtstatusname").value!=mod)
                //		            {
                //		                alert("This Status Name has already been assigned !! ");
                //    		            document.getElementById("txtstatusname").value="";
                //    		            document.getElementById('txtstatusname').focus();
                //		                return false;
                //        		    
                //		            }
                //                }
                  alert("This Status Name has already been assigned !! ");
   		          document.getElementById("txtstatusname").value="";
                  document.getElementById('txtstatusname').focus();
		          return false;
		    
		     }
	        else
	        {
		          if(document.getElementById('pnew').value=="1")
                  {
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].Status_code;
		                        }
		                    if(newstr !=null )
		                        {
		                       // var code=newstr.substr(2,4);
		                       var code=newstr;
		                       str=str.toUpperCase();
		                        code++;
		                        document.getElementById('txtstatuscode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          str=str.toUpperCase();
		                          document.getElementById('txtstatuscode').value=str.substr(0,2)+ "0";
		                          }
		                          document.getElementById('btnSave').focus();
		                          return false;
		           }
		                          
		          }

                 return false;
		}
		
function userdefine()
    {
        if(document.getElementById('hiddenauto').value!="1")
        {
        
        document.getElementById('txtstatuscode').disabled=false;
        document.getElementById('txtstatusname').value=document.getElementById('txtstatusname').value.toUpperCase();
        auto=document.getElementById('hiddenauto').value;
        document.getElementById('btnSave').focus();
         return false;
        }

return false;


}


function chkquery11()
{

document.getElementById('pnew').value="0";
return;

}
function update1()
{

hiddenmod=document.getElementById('txtstatusname').value;
return;

}

function clearstatus()
{

document.getElementById('btnNew').focus();
givebuttonpermission('status_master');
document.getElementById('txtstatuscode').value="";
document.getElementById('txtstatusname').value="";
}