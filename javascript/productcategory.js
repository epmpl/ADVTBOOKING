// JScript File

var hiddentext;
var auto="";
var hiddentext1="";
var mod="";
function Newproduct()
{
//alert('sdsd');
 document.getElementById('txtprodesc').disabled=false;
 document.getElementById('txtprodesc').focus();
 return false;
 }

//               document.getElementById('txtproductcode').value="";
//				document.getElementById('txtprodesc').value="";	
//				document.getElementById('txtalias').value="";
//				 if(document.getElementById('hiddenauto').value==1)
//		         {
//		          document.getElementById('txtproductcode').disabled=true;
//    	          }
//		         else
//		           {
//		           document.getElementById('txtproductcode').disabled=false;
//    	           }
//				
//				document.getElementById('txtprodesc').disabled=false;
//				document.getElementById('txtalias').disabled=false;
//				if(document.getElementById('hiddenauto').value==1)
//		         {
//		          document.getElementById('txtprodesc').focus();
//    	          }
//		         else
//		           {
//		           document.getElementById('txtproductcode').focus();
//    	           }
//    	           
//    	           hiddentext="new";
//			chkstatus(FlagStatus);
//			
//	document.getElementById('btnSave').disabled = false;	
//	document.getElementById('btnNew').disabled = true;	
//	document.getElementById('btnQuery').disabled=true;
//		
//				return false;

//else
//{

//   document.getElementById('txtproductcode').focus();
//       return ;

//}




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

//function saveproduct1()
//{
//setTimeout('saveproduct()',5000);
//}
function saveproduct()
{
	document.getElementById('txtprodesc').value=trim(document.getElementById('txtprodesc').value);
// var code=document.getElementById("txtproductcode").value;  
// var name=document.getElementById("txtprodesc").value;
// var alias=document.getElementById("txtalias").value;
   if(document.getElementById("drpindustry").value=="0")  
    {
           alert("Please Select Industry");
            document.getElementById('drpindustry').focus();
            return false;
    
    }
 if(document.getElementById('hiddenauto').value!="1")
 {
 if(document.getElementById("txtproductcode").value=="")
    {
        alert("Please Enter Product Code");
        if(document.getElementById('txtproductcode').disabled==false)
            document.getElementById('txtproductcode').focus();
        return false;
         
    }
    //return false;
  }
//    else
//     {
//        alert("Please Enter Product Code");
//        document.getElementById('txtproductcode').focus();
//        return false;
//          
//     } 
//     return false;
 //}
   
    
  if(document.getElementById("txtprodesc").value=="")  
    {

            alert("Please Enter Product Name");
            document.getElementById('txtprodesc').focus();
            return false;
    
    }
    
  if(document.getElementById("txtalias").value=="")  
    {
           alert("Please Enter Product Alias");
            document.getElementById('txtalias').focus();
            return false;
    
    }
  
    
    return;

}
function closeproduct()
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
 document.getElementById('txtprodesc').value=trim(document.getElementById('txtprodesc').value.toUpperCase());
                   if((document.getElementById('hiddenauto').value=="1"))
   
              {
                    changeoccured();
                    //document.getElementById('txtalias').focus();
                    return false;
              }
                else
                {
                    userdefine();
                    return false;
                 }
    
 //             }
//        }
//    }
//  } 
//    

return ;
}




function changeoccured()
{

//  if(document.getElementById('drpindustry').value!="0")
//  {
  if((document.getElementById('hiddenauto').value=="1"))
			{
	
            uppercase3();
           
           }
            else
            {
            document.getElementById('txtalias').value=document.getElementById('txtprodesc').value.toUpperCase();
            return ;
            }
//            }
//            else
//            {
//            if(document.getElementById('pnew').value!="0")
//            {
//            alert("Please select industry first");
//            document.getElementById('drpindustry').focus();
//            document.getElementById('txtprodesc').value="";
//            return false;
//            }
//            }
            
return ;
}

//function fillcall_modify(res)
//{
//}
//auto generated
//this is used for increment in code
function uppercase3()
		{
		  document.getElementById('txtprodesc').value=trim(document.getElementById('txtprodesc').value);
		 // document.getElementById('txtalias').value=document.getElementById('txtprodesc').value;
		  lstr=document.getElementById('txtprodesc').value;
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
		    if(document.getElementById('txtprodesc').value!="")
                {
               
        
		document.getElementById('txtprodesc').value=document.getElementById('txtprodesc').value.toUpperCase();
	    if(document.getElementById('pnew').value=="1")
                            {
	    document.getElementById('txtalias').value=document.getElementById('txtprodesc').value;
	    }
		// str=document.getElementById('txtprodesc').value;
		// cod=document.getElementById('txtadvcatcode').value;
		str=mstr;
		var indus=document.getElementById('drpindustry').value;
		var compcode = document.getElementById('hiddencompcode').value;
		ProductCategory.adchkadvcode(/*cod,*/str,indus,compcode,fillcall);
		return false;
                }
		       
               
 return false;
		
}

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    if(document.getElementById("txtprodesc").value!=mod)
		    {
		    if(document.getElementById("query").value!="1")
		    {
		    alert("This Product name has already been assigned !! ");
		    
		    document.getElementById("txtprodesc").value="";
		    if(document.getElementById('pnew').value=="1")
            {
		    document.getElementById("txtalias").value="";
		    document.getElementById("txtproductcode").value="";
		    }
		    document.getElementById('txtprodesc').focus();
    		
		    return false;
		    }
		    }
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
		                         newstr=ds.Tables[1].Rows[0].prod_cat_code;
		                        }
		                    if(newstr !=null )
		                        {
		                       // var code=newstr.substr(2,4);
		                       var code=newstr;
		                        str=str.toUpperCase()
		                        code++;
		                        
		                        document.getElementById('txtproductcode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                           str=str.toUpperCase()
		                          document.getElementById('txtproductcode').value=str.substr(0,2)+ "0";
		                          }
		     }
		     }
	return false;
		}
		
function userdefine()
    {
        if(document.getElementById('hiddenauto').value=="1")
        {
        
        document.getElementById('txtproductcode').disabled=false;
        document.getElementById('txtprodesc').value=document.getElementById('txtprodesc').value.toUpperCase();
        document.getElementById('txtalias').value=document.getElementById('txtprodesc').value;
        auto=document.getElementById('hiddenauto').value;
         return false;
        }
          document.getElementById('txtalias').value=document.getElementById('txtprodesc').value;
document.getElementById('txtalias').focus();
return false;


}


function chkquery1()
{

document.getElementById('pnew').value="0";
return;

}
function update1()
{
mod=document.getElementById('txtprodesc').value;
return;
}
function setButtonImages()
{
    if(document.getElementById('btnNew').disabled==true)
        document.getElementById('btnNew').src="btimages/new-off.jpg";
    else
        document.getElementById('btnNew').src="btimages/new.jpg";
        
    if(document.getElementById('btnSave').disabled==true)
        document.getElementById('btnSave').src="btimages/save-off.jpg";
    else
        document.getElementById('btnSave').src="btimages/save.jpg";
        
    if(document.getElementById('btnModify').disabled==true)
        document.getElementById('btnModify').src="btimages/modify-off.jpg";
    else
        document.getElementById('btnModify').src="btimages/modify.jpg";
        
    if(document.getElementById('btnQuery').disabled==true)
        document.getElementById('btnQuery').src="btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src="btimages/query.jpg";
    
    if(document.getElementById('btnExecute').disabled==true)
        document.getElementById('btnExecute').src="btimages/execute-off.jpg";
    else
        document.getElementById('btnExecute').src="btimages/execute.jpg";
        
    if(document.getElementById('btnCancel').disabled==true)
        document.getElementById('btnCancel').src="btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src="btimages/clear.jpg";
        
    if(document.getElementById('btnfirst').disabled==true)
        document.getElementById('btnfirst').src="btimages/first-off.jpg";
    else
        document.getElementById('btnfirst').src="btimages/first.jpg";
        
    if(document.getElementById('btnprevious').disabled==true)
        document.getElementById('btnprevious').src="btimages/previous-off.jpg";
    else
        document.getElementById('btnprevious').src="btimages/previous.jpg";
        
    if(document.getElementById('btnnext').disabled==true)
        document.getElementById('btnnext').src="btimages/next-off.jpg";
    else
        document.getElementById('btnnext').src="btimages/next.jpg";
        
    if(document.getElementById('btnlast').disabled==true)
        document.getElementById('btnlast').src="btimages/last-off.jpg";
    else
        document.getElementById('btnlast').src="btimages/last.jpg";   
        
    if(document.getElementById('btnDelete').disabled==true)
        document.getElementById('btnDelete').src="btimages/delete-off.jpg";
    else
        document.getElementById('btnDelete').src="btimages/delete.jpg";
        
    if(document.getElementById('btnExit').disabled==true)
        document.getElementById('btnExit').src="btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src="btimages/exit.jpg";
}
function blankcat()
{

document.getElementById('drpindustry').value="0";
document.getElementById('txtproductcode').value="";
document.getElementById('txtprodesc').value="";
document.getElementById('txtalias').value="";
givebuttonpermission('ProductCategory');

}