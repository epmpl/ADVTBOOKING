// JScript File
var hiddenauto="";

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
if(event.keyCode==39) 
    event.keyCode= 0;
}
function upperCode()
{
    document.getElementById('txtpubcode').value=trim(document.getElementById('txtpubcode').value.toUpperCase());
     if(document.getElementById('pnew').value=="1")
        {
    if(document.getElementById('txtpubcode').value!="")
    {
        var res=PublisherMaster.checkdupCode(document.getElementById('txtpubcode').value);
        var ds=res.value;
        if(ds!=null)
        {
            if(ds.Tables[0].Rows.length>0)
            {
                alert("Publisher Code already Exist.");
                 document.getElementById('txtpubcode').value="";
                if(document.getElementById('txtpubcode').disabled==false)
                    document.getElementById('txtpubcode').focus();
                return false;
            }
        }
     }   
     }
		return ;
}
function uppercase1()
{
		
		document.getElementById('txtaddress').value=trim(document.getElementById('txtaddress').value.toUpperCase());
		return ;
		
}
function uppercaseAlias()
{
		
		document.getElementById('txtpubalias').value=trim(document.getElementById('txtpubalias').value.toUpperCase());
		return ;
		
}
function exitclick()
{
  if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
			return false;

   

}

function autoornot()
{
   document.getElementById('txtpubname').value=trim(document.getElementById('txtpubname').value.toUpperCase());
    if(document.getElementById('hiddenauto').value=="1")
    {
    changeoccured();
    return false ;
    }
else
    {
    userdefine();

    return false;
    }
//    }
//return ;
}

function changeoccured()
{

  
  if(document.getElementById('hiddenauto').value=="1" )
			{
	
            uppercase3();
           
           }
            else
            {
             document.getElementById('txtpubname').value=document.getElementById('txtpubname').value.toUpperCase();
             document.getElementById('txtpubalias').value=document.getElementById('txtpubname').value;
            return ;
            }
//return false;
return;
}

//auto generated
//this is used for increment in code
function uppercase3()
		{
		 document.getElementById('txtpubname').value=trim(document.getElementById('txtpubname').value);
		//		  document.getElementById('txtpubalias').value=document.getElementById('txtpubname').value;
		 lstr=document.getElementById('txtpubname').value;
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
		 
		    if(document.getElementById('txtpubname').value!="")
                {
                 
       
        
		document.getElementById('txtpubname').value=document.getElementById('txtpubname').value.toUpperCase();
       if(document.getElementById('pnew').value=="1")
        {
    	   document.getElementById('txtpubalias').value=document.getElementById('txtpubname').value;
    	}   
		 //str=document.getElementById('txtpubname').value;
		 str=mstr;
		//cod=document.getElementById('txtadvcatcode').value;
		PublisherMaster.adchkadvcode(/*cod,*/str,fillcall);
		return false;
                }
		       
               
 return false;
		
}
function fillcallName(res)
{
    		var ds=res.value;
	    	
	    	var newstr;
	    	  if(ds.Tables[0].Rows.length>0)
	    	  {
	    	      alert("This Publisher Name has already assigned !! ");
		    document.getElementById("txtpubname").value="";
		    document.getElementById("txtpubalias").value="";
		    document.getElementById('txtpubname').focus();
		     return false;
	    	  }
}	    	
		    
function fillcall(res)
{
    		var ds=res.value;
	    	
	    	var newstr;
		    //saurabh change
		    
		    if(ds.Tables[0].Rows.length!=0)
		    {   
		      if(document.getElementById("hidden_b").value !=document.getElementById("txtpubname").value)
		      {
		        if(document.getElementById('hiddensaurabh').value=="1")
		        {
		    alert("This Publisher Name has already assigned !! ");
		    document.getElementById("txtpubname").value="";
		    document.getElementById("txtpubalias").value="";
		    document.getElementById('txtpubname').focus();
    		
		    return false;
		    }
		    }
		    }
		    else
		    {
		        if(document.getElementById('pnew').value=="1")
                {
                
                var saurabh=parseFloat(document.getElementById('txtpubname').value);
                
                
		                if(ds.Tables[1].Rows.length==0)
		                {
		                   newstr=null;
		                }
		                else
		                {
		                   newstr=ds.Tables[1].Rows[0].Pcode;
		                }
		                if(newstr !=null )
		                {
		                  //var code=newstr.substr(2,4);
		                   var code=newstr;
		                   code++;
		                   str=str.toUpperCase();
		                   document.getElementById('txtpubcode').value=str.substr(0,2)+ code;
		                }
		                else
		                {
		                    str=str.toUpperCase();
		                   document.getElementById('txtpubcode').value=str.substr(0,2)+ "0";
		                }
		           
		           document.getElementById('txtpubalias').focus();
		           
		           if(saurabh==0)
                    {
                    alert("Publisher Name should not be zero.");
                    document.getElementById('txtpubcode').value="";
                    document.getElementById('txtpubname').value="";
                    document.getElementById('txtpubalias').value="";
                    document.getElementById('txtpubname').focus();
                    }
                    
		        }             
		        
		    }
	        return false;
}
		
function userdefine()
    {
    document.getElementById('txtpubname').value=document.getElementById('txtpubname').value.toUpperCase();
     document.getElementById('txtpubalias').value=document.getElementById('txtpubname').value;
        if(document.getElementById('hiddenauto').value=="1")
        {
        
        document.getElementById('txtpubcode').disabled=false;
       
        
        auto=document.getElementById('hiddenauto').value;
         return false;
        }
        if(document.getElementById('pnew').value=="1")
         PublisherMaster.adchkadvcode(document.getElementById('txtpubname').value,fillcallName);
document.getElementById('txtpubalias').focus();
return false;


}

function chkquery()
{

     document.getElementById('pnew').value="0";
     return ;

//if(document.getElementById('hiddenauto').value=="0")
//   {
//     
//   }

}

function chksharing()
{
var sau=parseFloat(document.getElementById('txtsharing').value);
//document.getElementById('txtsharing').value=sau;

if(sau>100)
{
    alert("Shaing (%) should not be greater than 100");
    document.getElementById('txtsharing').value="";
    document.getElementById('txtsharing').focus();
    return false;
}

var num=document.getElementById('txtsharing').value;
var tomatch=/^\d*(\.\d{1,2})?$/;
if (tomatch.test(num))
{
return true;
}
else
{
alert("Input error");
document.getElementById('txtsharing').value="";
document.getElementById('txtsharing').focus();

return false; 

}

}
