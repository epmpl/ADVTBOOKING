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
//  document.getElementById('drpproduct').focus();
//}

}
/*
function saveproductsubcode()
{

	document.getElementById('txtprosubname').value=trim(document.getElementById('txtprosubname').value);
 
 if(document.getElementById("drpproduct").value=="0")  
    {
      if(document.getElementById("hiddendrpproduct").value=="1")
      {
            alert("Please Select Product Name");
            document.getElementById('drpproduct').focus();
            return false;
       }
    }
  
 
 if(document.getElementById('hiddenauto').value!="1")
 {
 if(document.getElementById("txtprosubcode").value=="")
    {
        alert("Please Enter Product Sub Name");
        document.getElementById('txtprosubname').focus();
        return false;
   
    
    }
 // return ;
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
   
    
  if(document.getElementById("txtprosubname").value=="")  
    {
       if(document.getElementById("hiddensubproname").value=="1")
        {
            alert("Please Enter Product Sub Name");
            document.getElementById('txtprosubname').focus();
            return false;
        }
    }
    
  if(document.getElementById("txtalias").value=="")  
    {
        if(document.getElementById("txtalias").value=="1")
           {
            alert("Please Enter Product Alias");
            document.getElementById('txtalias').focus();
            return false;
            }
    
    }
    
    return ;
    
}
*/
//------------------------------------------------------------
function saveproductsubcode()
{
    document.getElementById('txtprosubname').value=trim(document.getElementById('txtprosubname').value);
    document.getElementById('txtprosubcode').value=trim(document.getElementById('txtprosubcode').value);
    document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
    
    
     if(document.getElementById("drpproduct").value=="0")
      {
            alert("Please Select Product Name");
            document.getElementById('drpproduct').focus();
            return false;
       }
       
        if(document.getElementById("txtprosubcode").value=="")
         {
            alert("Please Enter Product Sub Name");
            document.getElementById('txtprosubname').focus();
            return false;    
        }
       if(document.getElementById("txtprosubname").value=="")
        {
            alert("Please Enter Product Sub Name");
            document.getElementById('txtprosubname').focus();
            return false;
        }
        
         if(document.getElementById("txtalias").value=="")
           {
            alert("Please Enter Product Alias");
            document.getElementById('txtalias').focus();
            return false;
            }
            
          if(document.getElementById("txtprosubcode").value=="")
          {
            alert("Please Enter Product Code");
            document.getElementById('txtprosubcode').focus();
            return false;
          }
          return;
}
//-------------------------------------------------------------------------------------------------------------

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
return ;
}



//txtprosubcode .Text = "";
//        txtprosubname .Text = "";
//        txtalias .Text = "";
//        drpproduct


function changeoccured()
{

  
  if(document.getElementById('hiddenauto').value=="1" )
			{
	
            uppercase3();
           
           }
            else
            {
             document.getElementById('txtprosubname').value=document.getElementById('txtprosubname').value.toUpperCase();
             document.getElementById('txtalias').value=document.getElementById('txtprosubname').value;
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
		document.getElementById('txtprosubname').value=document.getElementById('txtprosubname').value.toUpperCase();
		 document.getElementById('txtprosubname').value=trim(document.getElementById('txtprosubname').value);
		  document.getElementById('txtalias').value=document.getElementById('txtprosubname').value;
		 lstr=document.getElementById('txtprosubname').value;
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
		 
		    if(document.getElementById('txtprosubname').value!="")
                {
                 
       
        
		document.getElementById('txtprosubname').value=document.getElementById('txtprosubname').value.toUpperCase();
	    document.getElementById('txtalias').value=document.getElementById('txtprosubname').value;
	    document.getElementById('txtalias').focus();
		 //str=document.getElementById('txtprosubname').value;
		 str=mstr;
		//cod=document.getElementById('txtadvcatcode').value;
		var procode=document.getElementById('drpproduct').value;
		ProductSubCategory.adchkadvcode(/*cod,*/str,procode,fillcall);
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
		    alert("This Product Sub Name has already assigned !! ");
		    document.getElementById("txtprosubname").value="";
		    document.getElementById("txtalias").value="";
		    
		    document.getElementById('txtprosubname').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].pro_subcat_code;
		                        }
		                    if(newstr !=null )
		                        {
		                        //var code=newstr.substr(2,4);
		                        var code=newstr;
		                        code++;
		                        document.getElementById('txtprosubcode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtprosubcode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
       // if(document.getElementById('hiddenauto').value=="1")
       
        //{
        
        document.getElementById('txtprosubcode').disabled=false;
        document.getElementById('txtprosubname').value=document.getElementById('txtprosubname').value.toUpperCase();
        document.getElementById('txtalias').value=document.getElementById('txtprosubname').value;
        document.getElementById('txtalias').focus();
        auto=document.getElementById('hiddenauto').value;
         //return false;
        //}

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
    document.getElementById('drpproduct').disabled=false;
    document.getElementById('drpproduct').focus();


}


function ClientSpecialcharname()
{
	if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==8)||(event.keyCode==189)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==9 || event.keyCode==32)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==44)||(event.keyCode==45)||(event.keyCode==46)||(event.keyCode==47)||(event.keyCode==92))
	{
		return true;
	}
	else
	{
		return false;
	}
}

function blanksubcat()
{

document.getElementById('drpproduct').value="0";
document.getElementById('txtprosubcode').value="";
document.getElementById('txtprosubname').value="";
document.getElementById('txtalias').value="";
givebuttonpermission('ProductSubCategory');


}