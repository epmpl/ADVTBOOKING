// JScript File
var hiddentext;
var auto="";
var hiddentext1="";
var mod;

function eventcalling(event)
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

function saveindustry()
{
document.getElementById('txtindustryname').value=trim(document.getElementById('txtindustryname').value);
document.getElementById('txtindustrycode').value=trim(document.getElementById('txtindustrycode').value);
 if(document.getElementById('hiddenauto').value!="1")
 {
 if(document.getElementById('txtindustrycode').value=="")
    {
        alert("Please Enter Industry Code");
        document.getElementById('txtindustrycode').focus();
        return false;
         
    }
  }
  if(document.getElementById('txtindustryname').value=="")  
    {
            alert("Please Enter Industry Name");
            document.getElementById('txtindustryname').focus();
            return false;
    }
    
  if(document.getElementById('txtindustryalias').value=="")  
    {
           alert("Please Enter Industry Alias");
            document.getElementById('txtindustryalias').focus();
            return false;
    
    }
    return;

}
function closeindustry()
{
  if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
			return false;
   

}
var hiddenauto="";

function autogen()
 {
 //if(hiddentext=="new" )
//            {
            if((document.getElementById('hiddenauto').value=="1"))
   
              {
                    changeoccured();
                   // return false;
              }
                else
               {
                    userdefine();
                   // return false;
                }
  
            // }
//return false ;
}




function changeoccured()
{

  
  if((document.getElementById('hiddenauto').value=="1"))
			{
	
           document.getElementById('txtindustryname').value=trim(document.getElementById('txtindustryname').value);
		  lstr=document.getElementById('txtindustryname').value;
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
		    if(document.getElementById('txtindustryname').value!="")
                {
		document.getElementById('txtindustryname').value=document.getElementById('txtindustryname').value.toUpperCase();
	    if(document.getElementById('pnew').value=="1")
                            {
	    document.getElementById('txtindustryalias').value=document.getElementById('txtindustryname').value;
	    }
		str=mstr;
		IndustryMaster.adchkadvcode(/*cod,*/str,fillcall);
		//return false;
                }
		
// return false;
           
           }
            else
            {
            document.getElementById('txtindustryname').value=document.getElementById('txtindustryname').value.toUpperCase();
            //return false;
            }
//return false ;
}

/*function uppercase3()
		{
		  document.getElementById('txtindustryname').value=trim(document.getElementById('txtindustryname').value);
		  lstr=document.getElementById('txtindustryname').value;
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
		    if(document.getElementById('txtindustryname').value!="")
                {
		document.getElementById('txtindustryname').value=document.getElementById('txtindustryname').value.toUpperCase();
	    if(document.getElementById('pnew').value=="1")
                            {
	    document.getElementById('txtindustryalias').value=document.getElementById('txtindustryname').value;
	    }
		str=mstr;
		IndustryMaster.adchkadvcode(/*cod,str,fillcall);*/
		//return false;
               // }
		       
               
// return false;
		
//}

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    if(document.getElementById('query').value!="0")
		    {
		    if(document.getElementById("txtindustryname").value!=mod)
		    {
		    alert("This Industry Name has already been assigned !! ");
		    
		    document.getElementById('txtindustryname').value="";
		    document.getElementById('txtindustryalias').value="";
		    
		    document.getElementById('txtindustryname').focus();
    		}
    		}
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
		                         newstr=ds.Tables[1].Rows[0].industry_code;
		                        }
		                    if(newstr !=null )
		                        {
		                       var code=newstr;
		                        code++;
		                        str=str.toUpperCase();
		                        document.getElementById('txtindustrycode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                         str=str.toUpperCase();
		                          document.getElementById('txtindustrycode').value=str.substr(0,2)+ "0";
		                          }
		                          ///document.getElementById('btnSave').focus();
		                         //return false;
		                          }
		     }
	//return false;
		}
		
function userdefine()
    {
       if(document.getElementById('hiddenauto').value!="1")
        {
        
        document.getElementById('txtindustrycode').disabled=false;
        document.getElementById('txtindustryname').value=document.getElementById('txtindustryname').value.toUpperCase();
        document.getElementById('txtindustryalias').value=document.getElementById('txtindustryname').value;
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

return false;
}

function chkquery1()
{
document.getElementById('pnew').value="0";
return;
}
function update1()
{
mod=document.getElementById('txtindustryname').value;
return;
}

function clearindustry() {
    document.getElementById('txtindustrycode').value = "";
    document.getElementById('txtindustryname').value = "";
    document.getElementById('txtindustryalias').value = "";
    givebuttonpermission('IndustryMaster');
}