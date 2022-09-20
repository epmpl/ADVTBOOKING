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
//    document.getElementById('pnew').value="1";
////if(document.getElementById('hiddenauto').value=="1")
//// {
////  document.getElementById('drpproduct').focus();
////}

}

function saveproductsubcode()
{
document.getElementById('txtbrandname').value=trim(document.getElementById('txtbrandname').value);
document.getElementById('txtbrandalias').value=trim(document.getElementById('txtbrandalias').value);
document.getElementById('txtbrandcode').value=trim(document.getElementById('txtbrandcode').value);

if(document.getElementById("dpdproductcategory").value=="0")  
    {

            alert("Please Select Product Category Name");
            document.getElementById('dpdproductcategory').focus();
            return false;
    }
    
    if(document.getElementById('hiddenauto').value!="1")
 {
 if(document.getElementById("txtbrandcode").value=="")
   {
        alert("Please Enter Brand Code");
   document.getElementById('txtbrandcode').focus();
        return false;
   
    
  }
 
  }
  
 
 
 if(document.getElementById("txtbrandname").value=="")
   {
        alert("Please Enter Brand Name");
        document.getElementById('txtbrandname').focus();
        return false;
   
    
  }
     
  
    
  if(document.getElementById("txtbrandalias").value=="")  
    {
            {
            alert("Please Enter Brand Alias");
            document.getElementById('txtbrandalias').focus();
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
    if(document.getElementById("dpdproductcategory").value=="0")  
    {
        if(document.getElementById('pnew').value == "1")
        {
            alert("Please Select Category Name");
            document.getElementById('txtbrandname').value="";
            document.getElementById('dpdproductcategory').focus();
            return false;
        }
        else
        {
             return false;
        }
    }
    document.getElementById('txtbrandname').value=document.getElementById('txtbrandname').value.toUpperCase();

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
        var productcategory=document.getElementById('dpdproductcategory').value;
        if(document.getElementById('dpdproductsubcategory')!=null || document.getElementById('drpproduct')!=null )
        {
            var productsubcategory=document.getElementById('dpdproductsubcategory').value;
            var product=document.getElementById('drpproduct').value;
        }
        else
        {
            var productsubcategory="0";
            var product="0";
        }
        var resp=BrandMaster.adchkadvcode(document.getElementById('txtbrandname').value,productcategory,productsubcategory,product,document.getElementById("hiddencompcode").value );
        var ds=resp.value;		
        if(ds.Tables[0].Rows.length!=0)
        {
            alert("This Product Brand Name has already assigned !! ");
            document.getElementById("txtbrandname").value="";
            document.getElementById('txtbrandname').focus();
            return false;
        }
        return false;
    }
  return ;
}



//txtprosubcode .Text = "";
//        txtprosubname .Text = "";
//        txtalias .Text = "";
//        drpproduct


function changeoccured()
{

  document.getElementById('txtbrandname').value=document.getElementById('txtbrandname').value.toUpperCase();
           
  if(document.getElementById('hiddenauto').value=="1" )
			{
	
            uppercase3();
           
           }
            else
            {
             document.getElementById('txtbrandname').value=document.getElementById('txtbrandname').value.toUpperCase();
             document.getElementById('txtbrandalias').value=document.getElementById('txtbrandname').value;
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
		 document.getElementById('txtbrandname').value=trim(document.getElementById('txtbrandname').value);
		  document.getElementById('txtbrandalias').value=document.getElementById('txtbrandname').value;
		 lstr=document.getElementById('txtbrandname').value;
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
		 
		    if(document.getElementById('txtbrandname').value!="")
                {
        document.getElementById('txtbrandname').value=document.getElementById('txtbrandname').value.toUpperCase();
	    document.getElementById('txtbrandalias').value=document.getElementById('txtbrandname').value;
		 //str=document.getElementById('txtprosubname').value;
		 str=mstr;
		//cod=document.getElementById('txtadvcatcode').value;
		var productcategory=document.getElementById('dpdproductcategory').value;
		if(document.getElementById('dpdproductsubcategory')!=null || document.getElementById('drpproduct')!=null )
		{
		var productsubcategory=document.getElementById('dpdproductsubcategory').value;
		var product=document.getElementById('drpproduct').value;
		}
		else
		{
		var productsubcategory="0";
		var product="0";
		}
		var compcode = document.getElementById('hiddencompcode').value;
		BrandMaster.adchkadvcode(str,productcategory,productsubcategory,product,compcode, fillcall);
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
		    alert("This Product Brand Name has already assigned !! ");
		    document.getElementById("txtbrandname").value="";
		    document.getElementById("txtbrandalias").value="";
		    
		    document.getElementById('txtbrandname').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].brand_code;
		                        }
		                    if(newstr !=null )
		                        {
		                        //var code=newstr.substr(2,4);
		                        var code=newstr;
		                       
		                        code++;
		                        document.getElementById('txtbrandcode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtbrandcode').value=str.substr(0,2)+ "0";
		                          }
		                            document.getElementById('txtbrandalias').focus();
    	
		     }
	return false;
		}
		
function userdefine()
    {
        if(document.getElementById('pnew').value=="1")
       {
        
        document.getElementById('txtbrandcode').disabled=false;
        document.getElementById('txtbrandname').value=document.getElementById('txtbrandname').value.toUpperCase();
        document.getElementById('txtbrandalias').value=document.getElementById('txtbrandname').value;
        auto=document.getElementById('hiddenauto').value;
        var productcategory=document.getElementById('dpdproductcategory').value;
		if(document.getElementById('dpdproductsubcategory')!=null || document.getElementById('drpproduct')!=null )
		{
		var productsubcategory=document.getElementById('dpdproductsubcategory').value;
		var product=document.getElementById('drpproduct').value;
		}
		else
		{
		var productsubcategory="0";
		var product="0";
		}
		var resp=BrandMaster.adchkadvcode(document.getElementById('txtbrandname').value,productcategory,productsubcategory,product);
		var ds=resp.value;		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Product Brand Name has already assigned !! ");
		    document.getElementById("txtbrandname").value="";
		    document.getElementById("txtbrandalias").value="";
		    
		    document.getElementById('txtbrandname').focus();
    		
		    return false;
		    }
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
    document.getElementById('dpdproductcategory').disabled=false;
    document.getElementById('dpdproductcategory').focus();
}


//function chkquery1()
//{

//document.getElementById('hiddenauto').value="query";
//return;

//}// JScript File

