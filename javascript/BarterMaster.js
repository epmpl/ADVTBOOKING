// JScript File
var hiddentext;
var mod="0";
var z="0";
var znk="0";
var auto="";
var hiddentext1="";
var glaobalcod;
var glaobalname;
var glaobalaccode;
var glaobalcompcode
var glaobaluserid

var dsexecute;
var y;
var dsdelete;
function newclick()
{
    document.getElementById('txtName').value="";
    document.getElementById('txtCode').value="";
    document.getElementById('txtAccode').value="";
    if(document.getElementById('hiddenauto').value==1)
    {
     document.getElementById('txtCode').disabled=true;
    }
    else
    {
     document.getElementById('txtCode').disabled=false;
    }
    document.getElementById('txtName').disabled=false;
    document.getElementById('txtAccode').disabled=false;
    if(document.getElementById('hiddenauto').value==1)
    {
      document.getElementById('txtName').focus();
    }
    else
    {
     document.getElementById('txtCode').focus();
    }
    hiddentext="new";
	chkstatus(FlagStatus);
			
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
		
				return false;
   
}
//***********************************************************************************************************//
//**********************************Button Save**************************************************************//
//***********************************************************************************************************//

function saveclick()
{
    document.getElementById('txtName').value=trim(document.getElementById('txtName').value);
    document.getElementById('txtCode').value=trim(document.getElementById('txtCode').value);
    document.getElementById('txtAccode').value=trim(document.getElementById('txtAccode').value);
    
     if(document.getElementById('hiddenauto').value!=1)
              {
                           
			 if(document.getElementById('txtCode').value=="")
			{
			alert("Please Fill Code ");
			document.getElementById('txtCode').focus();
			return false;
			}
			return false;
			}
					
			else if(document.getElementById('txtName').value=="")
			{
			alert("Please Fill Name ");
			document.getElementById('txtName').focus();
			return false;
			}
			else if(document.getElementById('txtAccode').value=="")
			{
			alert("Please Fill Ac code ");
			document.getElementById('txtAccode').focus();
			return false;
			}
            var compcode=document.getElementById('hiddencomcode').value;
			var name=document.getElementById('txtName').value;
			var code=document.getElementById('txtCode').value;
		    var accode=document.getElementById('txtAccode').value;
			var userid=document.getElementById('hiddenuserid').value;			

			if(mod !="1" && mod !=null)
			{
			
			BarterMaster.chkcode(code,call_saveclick);
			}
			else
			{
	
		     BarterMaster.modify(compcode,name,code,accode,userid);
		     dsexecute.Tables[0].Rows[z].Comp_Code=document.getElementById('hiddencomcode').value;
		     dsexecute.Tables[0].Rows[z].Bat_Name=document.getElementById('txtName').value;
		     dsexecute.Tables[0].Rows[z].Bat_Code=document.getElementById('txtCode').value;
             dsexecute.Tables[0].Rows[z].Bat_Ac_Code=document.getElementById('txtAccode').value;
			dsexecute.Tables[0].Rows[z].userId=document.getElementById('hiddencomcode').value;

			alert("Data Modified Successfully");

			document.getElementById('txtName').disabled=true;
           document.getElementById('txtCode').disabled=true;
            document.getElementById('txtAccode').disabled=true;
						
			document.getElementById('btnSave').disabled=true;
			
		    updateStatus();
		mod="0";
		
			}
		return false;
		}
function call_saveclick(response)
{
			var ds=response.value;
			if(ds.Tables[0].Rows.length > 0)
			{
			alert("This Cod  Is Already Exist, Try Another Code !!!!");
			
			 document.getElementById('txtName').value="";
            document.getElementById('txtCode').value="";
            document.getElementById('txtAccode').value=""
			
			return false;
			} 
			else
			{
			var compcode=document.getElementById('hiddencomcode').value;
			var name=document.getElementById('txtName').value;
			var code=document.getElementById('txtCode').value;
		    var accode=document.getElementById('txtAccode').value;
			var userid=document.getElementById('hiddenuserid').value;
				
			BarterMaster.save(compcode,name,code,accode,userid);		

				alert("Data Saved Successfully");
				


			 document.getElementById('txtName').value="";
            document.getElementById('txtCode').value="";
            document.getElementById('txtAccode').value="";
						
							
				document.getElementById('btnNew').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnCancel').disabled=false;		
				document.getElementById('btnExit').disabled=false;	
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;
			}
			cancelclick('BarterMaster');
			return false;
}


//*******************************************************************************//
//**************************This Function For Modify Button**********************//
//*******************************************************************************//
function modifyclick()
{

			
            document.getElementById('txtName').disabled=false;
            document.getElementById('txtCode').disabled=true;
            document.getElementById('txtAccode').disabled=false;
					
				
				chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnModify').disabled=true;
				
			
				   mod="1";
				 hiddentext="mod";	
											
				return false;
}

//*******************************************************************************//
//*************************This Function For Query Button***********************//
//*******************************************************************************//

function queryclick()
{
			document.getElementById('txtName').value="";
            document.getElementById('txtCode').value="";
            document.getElementById('txtAccode').value=""
				z=0;
			document.getElementById('txtName').disabled=false;
            document.getElementById('txtCode').disabled=false;
            document.getElementById('txtAccode').disabled=false;
					
	       document.getElementById('btnQuery').disabled=true;
	       document.getElementById('btnExecute').disabled=false;
	       document.getElementById('btnSave').disabled=true;
				hiddentext="query";
										
				
				return false;
}

//*******************************************************************************//
//**********************This Function For Execute Button*************************//
//*******************************************************************************//

function executeclick()
{


               z=0;
			var compcode=document.getElementById('hiddencomcode').value;
			var name=document.getElementById('txtName').value;
			glaobalname=name;
			var code=document.getElementById('txtCode').value;
			glaobalcode=code;
			var accode=document.getElementById('txtAccode').value;
			glaobalaccode=accode;
			var userid=document.getElementById('hiddenuserid').value;			

				
			BarterMaster.execute(compcode,name,code,accode,userid,checkcall);		
			updateStatus();
			document.getElementById('txtName').disabled=true;
            document.getElementById('txtCode').disabled=true;
            document.getElementById('txtAccode').disabled=true;
			
			mod="0";
			            document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=false;					
						document.getElementById('btnprevious').disabled=true;			
						document.getElementById('btnlast').disabled=false;
						document.getElementById('btnModify').disabled=false;
						
						 document.getElementById('btnNew').disabled=true;
				        document.getElementById('btnExecute').disabled=true;
						
						
						document.getElementById('btnDelete').disabled=false;
							
			
			return false;
}

//*******************************************************************************//
//********************This Is The Responce Of The Execute Button*****************//
//*******************************************************************************//	
function checkcall(response)
{
//			var ds=response.value;
			dsexecute=response.value;
			if(dsexecute.Tables[0].Rows.length > 0)
			{
			   document.getElementById('hiddencomcode').value=dsexecute.Tables[0].Rows[0].Comp_Code;
			   document.getElementById('txtName').value=dsexecute.Tables[0].Rows[0].Bat_Name;
			 	document.getElementById('txtCode').value=dsexecute.Tables[0].Rows[0].Bat_Code;
				document.getElementById('txtAccode').value=dsexecute.Tables[0].Rows[0].Bat_Ac_Code;
				document.getElementById('hiddenuserid').value=dsexecute.Tables[0].Rows[0].userId;
				
					
				
			document.getElementById('txtCode').disabled=true;
			document.getElementById('txtName').disabled=true;
			document.getElementById('txtAccode').disabled=true;
						
			}
			
			else
			{
				alert("Your Search Produce No Result!!!!");
			cancelclick('BarterMaster');
			}

            if(dsexecute.Tables[0].Rows.length ==1)
			{
			    document.getElementById('btnfirst').disabled=true;				
			   document.getElementById('btnnext').disabled=true;					
			    document.getElementById('btnprevious').disabled=true;			
			   document.getElementById('btnlast').disabled=true;
			}
			
			return false;
}
//*******************************************************************************//
//*************************This Function For First Button************************//
//********************************************************//

//function batfirstclick()
//{

//			BarterMaster.fpnl(firstcall);
//						
//			document.getElementById('txtName').disabled=true;
//			document.getElementById('txtCode').disabled=true;
//			document.getElementById('txtAccode').disabled=true;
//			
//			document.getElementById('btnprevious').disabled=true;	
//			document.getElementById('btnlast').disabled=false;	
//			document.getElementById('btnfirst').disabled=true;
//			document.getElementById('btnnext').disabled=false;
//			
//			document.getElementById('btnNew').disabled=true;
//			document.getElementById('btnSave').disabled=true;
//			document.getElementById('btnModify').disabled=false;
//			document.getElementById('btnDelete').disabled=false;
//			document.getElementById('btnQuery').disabled=true;
//			document.getElementById('btnExecute').disabled=true;
//			document.getElementById('btnCancel').disabled=false;		
//			document.getElementById('btnfirst').disabled=true;				
//			document.getElementById('btnnext').disabled=false;					
//			document.getElementById('btnprevious').disabled=true;			
//			document.getElementById('btnlast').disabled=false;	
//			document.getElementById('btnExit').disabled=false;
//			
//			return false;
//}

//*******************************************************************************//
//********************This Function For First Button*******************//
//*******************************************************************************//	
function firstclick()
{
			//var dszoneexecute=response.value;
	
			   document.getElementById('txtName').value=dsexecute.Tables[0].Rows[0].Bat_Name;
			 	document.getElementById('txtCode').value=dsexecute.Tables[0].Rows[0].Bat_Code;
				document.getElementById('txtAccode').value=dsexecute.Tables[0].Rows[0].Bat_Ac_Code;
			z=0;
			updateStatus();

		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;
			return false;
}


//*******************************************************************************//
//***********************This Function For Previous Button***********************//
//*******************************************************************************//


//function batpreviousclick()
//{			
//			BarterMaster.fpnl(previouscall);

//			  document.getElementById('txtName').disabled=true;
//			document.getElementById('txtCode').disabled=true;
//			document.getElementById('txtAccode').disabled=true;
//			return false;
//}
//*******************************************************************************//
//********************This Function For Previous Button****************//
//*******************************************************************************//
function previousclick()
{
		//var dszoneexecute=response.value;
		var a=dsexecute.Tables[0].Rows.length;
		z--;
		if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
				 document.getElementById('txtName').value=dsexecute.Tables[0].Rows[z].Bat_Name;
			 	document.getElementById('txtCode').value=dsexecute.Tables[0].Rows[z].Bat_Code;
				document.getElementById('txtAccode').value=dsexecute.Tables[0].Rows[z].Bat_Ac_Code;
			updateStatus();
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;
			}
			else
			{
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				return false;
			}
		}
		else
		{		document.getElementById('btnnext').disabled=false;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				return false;
		}
		if(z==0)
		{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}
		return false;
}

//*******************************************************************************//
//*************************This Function For Last Button*************************//
//*******************************************************************************//

//function batlastclick()
//{
//			BarterMaster.fpnl(lastcall);

//			document.getElementById('txtName').disabled=true;
//			document.getElementById('txtCode').disabled=true;
//			document.getElementById('txtAccode').disabled=true;
//						
//			return false;
//}
//*******************************************************************************//
//********************This Function For Last Button*******************//
//*******************************************************************************//
function lastclick()
{
			//var dszoneexecute=response.value;
			var y=dsexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;
			
			    document.getElementById('txtName').value=dsexecute.Tables[0].Rows[z].Bat_Name;
			 	document.getElementById('txtCode').value=dsexecute.Tables[0].Rows[z].Bat_Code;
				document.getElementById('txtAccode').value=dsexecute.Tables[0].Rows[z].Bat_Ac_Code;
			updateStatus();
			
		        document.getElementById('btnnext').disabled=true;
		        document.getElementById('btnlast').disabled=true;
		        document.getElementById('btnfirst').disabled=false;
		        document.getElementById('btnprevious').disabled=false;
			return false;
}

//*******************************************************************************//
//**************************This Function For Next Button*************************//
//*******************************************************************************//

function batnextclick()
{
		BarterMaster.fpnl(nextcall);
		      			    
			document.getElementById('txtName').disabled=true;
			document.getElementById('txtCode').disabled=true;
			document.getElementById('txtAccode').disabled=true;
		
		return false;
}

//*******************************************************************************//
//**************************This Function For Next Button*************************//
//*******************************************************************************//

function nextcall(response)
{
	//var dszoneexecute=response.value;
	var dsexecute=response.value;
	var a=dsexecute.Tables[0].Rows.length;
	z++;
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
			  document.getElementById('txtName').value=dsexecute.Tables[0].Rows[z].Bat_Name;
			 	document.getElementById('txtCode').value=dsexecute.Tables[0].Rows[z].Bat_Code;
				document.getElementById('txtAccode').value=dsexecute.Tables[0].Rows[z].Bat_Ac_Code
			
		    updateStatus();
		    
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
		else
	{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
	}
	}
	else
	{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
	}
	if(z==a-1)
	{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
	}
	return false;

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


//*******************************************************************************//
//*************************This Function For Delete Button***********************//
//*******************************************************************************//
function deleteclick()
{

        updateStatus();
		   var compcode=document.getElementById('hiddencomcode').value;
			var name=document.getElementById('txtName').value;
			var code=document.getElementById('txtCode').value;
		    var accode=document.getElementById('txtAccode').value;
			var userid=document.getElementById('hiddenuserid').value;
		boolReturn = confirm("Are you sure you wish to delete this?");
		if(boolReturn==1)
		{
		alert ("Data Deleted Successfully");
		
		
            document.getElementById('txtName').value="";
            document.getElementById('txtCode').value="";
            document.getElementById('txtAccode').value="";
		
		BarterMaster.batdelete(code);
		BarterMaster.fpnl(delcall);
		//batnextclick();
		//executeclick();
		
		
		}     
	else
	{
	return false;
	}
	return false;
}
//*******************************************************************************//
//*******************This Is The Responce Of The delete Button*******************//
//*******************************************************************************//

function delcall(res)
{
	dsexecute= res.value;
	len=dsexecute.Tables[0].Rows.length;
	
	if(dsexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		 document.getElementById('txtName').value="";
            document.getElementById('txtCode').value="";
            document.getElementById('txtAccode').value="";
		cancelclick('BarterMaster');
		
		return false;
	}
	else if(z>=len || z==-1)
	{            
		        document.getElementById('hiddencomcode').value=dsexecute.Tables[0].Rows[0].Comp_Code;
			   document.getElementById('txtName').value=dsexecute.Tables[0].Rows[0].Bat_Name;
			 	document.getElementById('txtCode').value=dsexecute.Tables[0].Rows[0].Bat_Code;
				document.getElementById('txtAccode').value=dsexecute.Tables[0].Rows[0].Bat_Ac_Code;
				document.getElementById('hiddenuserid').value=dsexecute.Tables[0].Rows[0].userId;
			
	}
  else if(len !=-1 && z >= 0)
	{
		if(z <= len-1)
		{
			  document.getElementById('txtName').value=dsexecute.Tables[0].Rows[z].Bat_Name;
			 	document.getElementById('txtCode').value=dsexecute.Tables[0].Rows[z].Bat_Code;
				document.getElementById('txtAccode').value=dsexecute.Tables[0].Rows[z].Bat_Ac_Code
	     }
	  }   
	
return false;
}


/*********************************************Auto Generate***********************/
function autoornot()
 {
     
    
    if(hiddentext=="new" )
    {
          if(document.getElementById('hiddenauto').value==1)
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

}
// Auto generated
// This Function is for check that whether this is case for new or modify
function changeoccured()
{

if(hiddentext=="new" )
{
if(document.getElementById('hiddenauto').value==1)
{
 document.getElementById('txtName').value=trim(document.getElementById('txtName').value);
		lstr=document.getElementById('txtName').value;
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
		
		    if(document.getElementById('txtName').value!="")
                {

		document.getElementById('txtName').value=document.getElementById('txtName').value.toUpperCase();
	    document.getElementById('txtAccode').value=document.getElementById('txtName').value;
		str=mstr;
		BarterMaster.Auto(str,fillcall);
		return false;
               }
               return false;
     }
  }
}
function fillcall(res)
		{
		var ds=res.value;
		var newstr;
		if(ds.Tables[0].Rows.length!=0 )
		{
		    alert("This Name has already assigned !! ");
		    
//		         document.getElementById('txtbgid').value="";
//				document.getElementById('txtbgname').value="";	
//				document.getElementById('txtbgalias').value="";
			
		  
    		
		    return false;
		 }
		 else
		 {
		        if(hiddentext=="new" )
		        {
		            if(ds.Tables[1].Rows.length==0)
		            {
		                newstr=null;
		            }
		            else
		            {
		               newstr=ds.Tables[1].Rows[0].Bat_Code;
		             }
		            if(newstr==0)
		              {
		                            document.getElementById('txtCode').value=str.substr(0,2)+ "1";
		                            //newstr=document.getElementById('txtadcatcode').value;
		               }
		             else if(newstr>=1)
		             {
		                   var Autoincrement=parseInt(ds.Tables[1].Rows[0].Bat_Code)+1;
		                   document.getElementById('txtCode').value=str.substr(0,2)+ Autoincrement;
		             }
		             else if(newstr !=null )
		             {
		                  document.getElementById('txtName').value=trim(document.getElementById('txtName').value);
		                   var code=newstr.substr(2,4);
		                   var code=newstr;
		                   code++;
		                   document.getElementById('txtCode').value=str.substr(0,2)+ code;
		               // document.getElementById('txtbillid').value=str.substr(1,3)+ code;
		               }
		               else
		               {
		                    document.getElementById('txtCode').value=str.substr(0,2)+ "0";
		                            //document.getElementById('txtbillid').value=str.substr(0,2)+ "00";
		               }
		         }
		     }
	return false;
		}

function userdefine()
{
 if(hiddentext=="new")
        {
        
        document.getElementById('txtCode').disabled=false;
        document.getElementById('txtName').value=document.getElementById('txtName').value.toUpperCase();
        document.getElementById('txtaccode').value=document.getElementById('txtName').value;
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

return false;
}
//***********************************************************************************//
function uppercase()
{

}

//********************************************************************************************//
function LTrim( value )
 {
	
	var re = /\s*((\S+\s*)*)/;
	return value.replace(re, "$1");
	
}

// Removes ending whitespaces
function RTrim( value ) {
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}

// Removes leading and ending whitespaces
function trim( value ) 
{
	
	return LTrim(RTrim(value));
	
}

//*******************************************************************************//
//*********************This For The Do The laters in capital laters**************//
//*******************************************************************************//	
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
//*******************************************************************************//
//**************************This Function For Cancle button**********************//
//*******************************************************************************//


function cancelclick(formname)
{
				
            document.getElementById('txtName').value="";
            document.getElementById('txtCode').value="";
            document.getElementById('txtAccode').value="";
				
			
			document.getElementById('txtCode').disabled=true;
			document.getElementById('txtName').disabled=true;
			document.getElementById('txtAccode').disabled=true;
				
				
				
				document.getElementById('btnModify').disabled=true;
			    document.getElementById('btnQuery').disabled=false;
			    document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').disabled=true;
				
				
			//getPermission(formname);
				mod="0";
				
					chkstatus(FlagStatus);
					
					
					
					if(document.getElementById('btnNew').disabled==false)
					{
					   
						document.getElementById('btnNew').focus();
					}
						
					else
					{
						document.getElementById('btnNew').disabled=false;
						document.getElementById('btnNew').focus();
						
					}
					
				
					givebuttonpermission(formname);
				return false;
}
