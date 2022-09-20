// JScript File
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

//drpproduct.SelectedValue = "0";
//                drpsubproduct.SelectedValue = "0";
//                txtprosubsubcode.Text = "";
//                txtprosubsubname.Text = "";
//                txtalias.Text = "";


function saveproduct()
{

	document.getElementById('txtprosubsubname').value=trim(document.getElementById('txtprosubsubname').value);
// var code=document.getElementById("txtprosubsubcode").value;  
// var name=document.getElementById("txtprosubsubname").value;
// var alias=document.getElementById("txtalias").value;
// if(document.getElementById('hiddenauto').value!="1")
// {
  
     if(document.getElementById("drpproduct").value=="0")  
    {
       if(document.getElementById("hidedrpproduct").value=="1")
         {
           alert("Please Select Product Name");
            document.getElementById('drpproduct').focus();
            return false;
          }
     }
    
    
    
    if(document.getElementById("drpsubproduct").value=="0")  
    {
      if(document.getElementById("hidedrpsubproduct").value=="1")
       {
           alert("Please Select Product Sub Name");
            document.getElementById('drpsubproduct').focus();
            return false;
        }
    }
    
   
     if(document.getElementById('hiddenauto').value!="1")  
       {
          if(document.getElementById("txtprosubsubcode").value=="")  
          {   
            alert("Please Enter Product Sub Sub Code");
            document.getElementById('txtprosubsubcode').focus();
            return false;
          }
        }
//    if(document.getElementById("txtprosubsubname").value=="")
//          {
//            alert("Please Enter Product Sub Sub Name");
//            document.getElementById('txtprosubsubname').focus();
//            return false;
//          }
         // return false;
       
    
  if(document.getElementById("txtprosubsubname").value=="")
    {
       if(document.getElementById("hidesubsubname").value=="1")
          {
           alert("Please Enter Product Sub Sub Name");
            document.getElementById('txtprosubsubname').focus();
            return false;
           }
      
    }
    
  if(document.getElementById("txtalias").value=="")  
    {
       if(document.getElementById("hidesubsubalias").value=="1")
        {
           alert("Please Enter Product Sub Sub Alias");
            document.getElementById('txtalias').focus();
            return false;
         }
     }
    
     
    
   
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
 
         if(document.getElementById('query').value=="1")
          {
          
         
    if(document.getElementById('hiddenauto').value=="1")
    {
        changeoccured();
        return false;
    }
else
    {
    userdefine();

    return false;
    }
    }
return ;
}



//txtprosubsubcode .Text = "";
//        txtprosubsubname .Text = "";
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
            document.getElementById('txtprosubsubname').value=document.getElementById('txtprosubsubname').value.toUpperCase();
            
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
		document.getElementById('txtprosubsubname').value=document.getElementById('txtprosubsubname').value.toUpperCase();
		document.getElementById('txtprosubsubname').value=trim(document.getElementById('txtprosubsubname').value);
		lstr=document.getElementById('txtprosubsubname').value;
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
		    if(document.getElementById('txtprosubsubname').value!="")
                {
                 
                 
        
		document.getElementById('txtprosubsubname').value=document.getElementById('txtprosubsubname').value.toUpperCase();
	    document.getElementById('txtalias').value=document.getElementById('txtprosubsubname').value;
	    document.getElementById('txtalias').focus();
		 //str=document.getElementById('txtprosubsubname').value;
		//cod=document.getElementById('txtadvcatcode').value;
		str=mstr;
	    var procode=document.getElementById('drpproduct').value;
	    var prosubcode=document.getElementById('drpsubproduct').value;
		product_subsub_category.adchkadvcode(/*cod,*/str,procode,prosubcode,fillcall);
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
		    alert("This Product Sub Sub name has already assigned !! ");
		    
		    document.getElementById("txtprosubsubname").value="";
		    document.getElementById("txtalias").value="";
		    
		    document.getElementById('txtprosubsubname').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].prosubcode;
		                        }
		                    if(newstr !=null )
		                        {
//		                        var code=newstr.substr(2,4);
                                var code=newstr;
		                        code++;
		                        document.getElementById('txtprosubsubcode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtprosubsubcode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(document.getElementById('hiddenauto').value!="1")
        {
        
        document.getElementById('txtprosubsubcode').disabled=false;
        document.getElementById('txtprosubsubname').value=document.getElementById('txtprosubsubname').value.toUpperCase();
        document.getElementById('txtalias').value=document.getElementById('txtprosubsubname').value;
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

return false;


}

function chkquery()
{

     document.getElementById('query').value="0";

//if(document.getElementById('hiddenauto').value=="0")
//   {
//     
//   }

}



//function newclick()
//{

function newclick()
{
   



    document.getElementById("drpproduct").disabled=false;
    document.getElementById("drpproduct").focus();
  return;
 
// }
// else
// {
//   
//  document.getElementById('txtprosubsubcode').focus();
//  return;
// 
// }
// return;



}

function focus1()
{
   



    document.getElementById("drpproduct").disabled=false;
    document.getElementById("drpproduct").focus();
  return;
  }

function focus2()
{
   



//    document.getElementById("drpsubproduct").disabled=false;
//    document.getElementById("drpsubproduct").focus();
  return;
  }

//*******************************************************************************//
//*************************This Function For Delete Button***********************//
//*******************************************************************************//
//function ProductDeleteclick()
//{

//        updateStatus();
//var glaobalzonecode;
//var glaobalzonename;
//var glaobalzonealias;
//		var compcode=document.getElementById('hiddencomcode').value;
//		var 
//		
//		var zonecode=document.getElementById('txtzonecode').value;
//		var zonename=document.getElementById('txtzonename').value;
//		var alias=document.getElementById('txtzonealias').value;
//		var UserId=document.getElementById('hiddenuserid').value;			
//		boolReturn = confirm("Are you sure you wish to delete this?");
//		if(boolReturn==1)
//		{
//		alert ("Data Deleted Successfully");
//		product_subsub_category.Advdelete(compcode,zonecode,zonename,alias,UserId);
//		
//		product_subsub_category.Advexecute1(companycode,glaobalzonecode,glaobalzonename,glaobalzonealias,UserId,delcall);	
//		}     
//	else
//	{
//	return false;
//	}
//	return false;
//}

//*******************************************************************************//
//*******************This Is The Responce Of The delete Button*******************//
//*******************************************************************************//

//function delcall(res)
//{
//	 dszoneexecute= res.value;
//	len=dszoneexecute.Tables[0].Rows.length;
//	
//	if(dszoneexecute.Tables[0].Rows.length==0)
//	{
//		alert("No More Data is here to be deleted");
//		
//		document.getElementById('txtzonecode').value="";
//		document.getElementById('txtzonename').value="";	
//		document.getElementById('txtzonealias').value="";
//		ZoneCancelclick('ZoneMaster');
//		
//		return false;
//	}
//	else if(z>=len || z==-1)
//	{
//		document.getElementById('txtzonecode').value=dszoneexecute.Tables[0].Rows[0].Zone_Code;
//		document.getElementById('txtzonename').value=dszoneexecute.Tables[0].Rows[0].Zone_Name;
//		document.getElementById('txtzonealias').value=dszoneexecute.Tables[0].Rows[0].Zone_Alias;
//	}
//	else
//	{
//		document.getElementById('txtzonecode').value=dszoneexecute.Tables[0].Rows[z].Zone_Code;
//		document.getElementById('txtzonename').value=dszoneexecute.Tables[0].Rows[z].Zone_Name;
//		document.getElementById('txtzonealias').value=dszoneexecute.Tables[0].Rows[z].Zone_Alias;
//	}
//		
//	
//return false;
//}


//function newclick()
//{
//   document.getElementById('txtprosubsubname').disabled=false; 
//   document.getElementById('txtprosubsubname').focus();
//  return;


//}