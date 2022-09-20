// JScript File

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

function newclick()
{
    
//if(document.getElementById('hiddenauto').value=="1")
// {
//  document.getElementById('drpbrand').focus();
//}

}

function saveproductsubcode()
{

	document.getElementById('txtvarientname').value=trim(document.getElementById('txtvarientname').value);
	document.getElementById('txtvarientcode').value=trim(document.getElementById('txtvarientcode').value);
	document.getElementById('txtvarientalias').value=trim(document.getElementById('txtvarientalias').value);
 
 if(document.getElementById("drpbrand").value=="0")  
    {
//      if(document.getElementById("hiddendrpproduct").value=="1")
//      {
            alert("Please Select Brand Name");
            document.getElementById('drpbrand').focus();
            return false;
       //}
    }
    
    if(document.getElementById('hiddenauto').value!="1")
 {
 if(document.getElementById("txtvarientcode").value=="")
   {
        alert("Please Enter Variant Code");
        document.getElementById('txtvarientcode').focus();
        return false;
   
    
  }
 
  }
  
 
 
 if(document.getElementById("txtvarientname").value=="")
   {
        alert("Please Enter Variant Name");
        document.getElementById('txtvarientname').focus();
        return false;
   
    
  }
 
  
//    else
//     {
//        alert("Please Enter Product Code");
//        document.getElementById('txtprosubcode').focus();
//        return false;
//          
//     } 
//     return false;
// }
   
    
  
    
  if(document.getElementById("txtvarientalias").value=="")  
    {
            {
            alert("Please Enter Variant Alias");
            document.getElementById('txtvarientalias').focus();
            return false;
            }
    
    }
    
    return;
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
var hiddenauto="";


function autoornot()
 {
 if(document.getElementById("drpbrand").value=="0")  
    {
//      if(document.getElementById("hiddendrpproduct").value=="1")
//      {
       if(document.getElementById('pnew').value=="1")
          {
            alert("Please Select Brand Name");
            document.getElementById('txtvarientname').value="";
            document.getElementById('drpbrand').focus();
            return false;
          }  
    }
 document.getElementById('txtvarientname').value=document.getElementById('txtvarientname').value.toUpperCase();
  if(document.getElementById('pnew').value=="1")
  {
  
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
    }
    else
    {
    document.getElementById('txtvarientname').value=document.getElementById('txtvarientname').value.toUpperCase();
       // document.getElementById('txtvarientalias').value=document.getElementById('txtvarientname').value;
        auto=document.getElementById('hiddenauto').value;
        brand=document.getElementById('drpbrand').value;
        var resp=VarientMaster.adchkadvcode(document.getElementById('txtvarientname').value,brand);
        var ds=resp.value;		
        if(document.getElementById('heddentext').value=="modify")
        {
		    if(ds.Tables[0].Rows.length!=0 && document.getElementById('hiddenmodtxt').value != document.getElementById('txtvarientname').value)
		    {
		    alert("This Variant Name has already assigned !! ");
		    document.getElementById("txtvarientname").value="";
		    
		    document.getElementById('txtvarientname').focus();
    		
		    return false;
		    }
        }
         return false;
        }

return ;
}



//txtprosubcode .Text = "";
//        txtprosubname .Text = "";
//        txtalias .Text = "";
//        drpbrand


function changeoccured()
{

  
  if(document.getElementById('hiddenauto').value=="1" )
			{
	
            uppercase3();
           
           }
            else
            {
             document.getElementById('txtvarientname').value=document.getElementById('txtvarientname').value.toUpperCase();
             document.getElementById('txtvarientalias').value=document.getElementById('txtvarientname').value;
            return ;
            }
return false;
}

//function fillcall_modify(res)
//{
//}
//auto generated
//this is used for increment in code
function uppercase3()
		{
		 document.getElementById('txtvarientname').value=trim(document.getElementById('txtvarientname').value);
		  document.getElementById('txtvarientalias').value=document.getElementById('txtvarientname').value;
		 lstr=document.getElementById('txtvarientname').value;
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
		 
		    if(document.getElementById('txtvarientname').value!="")
                {
                 
       
        
		document.getElementById('txtvarientname').value=document.getElementById('txtvarientname').value.toUpperCase();
	    document.getElementById('txtvarientalias').value=document.getElementById('txtvarientname').value;
		 brand=document.getElementById('drpbrand').value;
		 str=mstr;
		//cod=document.getElementById('txtadvcatcode').value;
		VarientMaster.adchkadvcode(str,brand,fillcall);
		return false;
                }
		       
                document.getElementById('txtvarientalias').focus();
    	
 return false;
		
}

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Variant Name has already assigned !! ");
		    document.getElementById("txtvarientname").value="";
		    document.getElementById("txtvarientalias").value="";
		    
		    document.getElementById('txtvarientname').focus();
    		
		    return false;
		    }
		
		        else
		        {
		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].varient_code;
		                        }
		                    if(newstr !=null )
		                        {
		                        //var code=newstr.substr(2,4);
		                        var code=newstr;
		                        code++;
		                        document.getElementById('txtvarientcode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtvarientcode').value=str.substr(0,2)+ "0";
		                          }
		                          document.getElementById('txtvarientalias').focus();
		     }
		      
	return false;
		}
		
function userdefine()
    {
        if(document.getElementById('hiddenauto').value!="1")
        {
        
        document.getElementById('txtvarientcode').disabled=false;
        document.getElementById('txtvarientname').value=document.getElementById('txtvarientname').value.toUpperCase();
        document.getElementById('txtvarientalias').value=document.getElementById('txtvarientname').value;
        auto=document.getElementById('hiddenauto').value;
        brand=document.getElementById('drpbrand').value;
        var resp=VarientMaster.adchkadvcode(document.getElementById('txtvarientname').value,brand);
        var ds=resp.value;		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Variant Name has already assigned !! ");
		    document.getElementById("txtvarientname").value="";
		    document.getElementById("txtvarientalias").value="";
		    
		    document.getElementById('txtvarientname').focus();
    		
		    return false;
		    }
		    document.getElementById('txtvarientalias').focus();
//		    else if(ds.Tables[1].Rows.length!=0)
//		    {
//		    alert("This Variant Code has already assigned !! ");
//		    document.getElementById("txtvarientname").value="";
//		    document.getElementById("txtvarientalias").value="";
//		    
//		    document.getElementById('txtvarientname').focus();
//    		
//		    return false;
//		    }
         return false;
        }

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

function focus()
{
    document.getElementById('drpbrand').disabled=false;
    document.getElementById('drpbrand').focus();


}
function clearvarient()
{

document.getElementById("drpbrand").value="0";
document.getElementById("txtvarientcode").value="";
document.getElementById("txtvarientname").value="";
document.getElementById("txtvarientalias").value="";
document.getElementById('btnNew').focus();
givebuttonpermission('VarientMaster');


return false;
}


//function chkquery1()
//{

//document.getElementById('hiddenauto').value="query";
//return;

//}// JScript File

