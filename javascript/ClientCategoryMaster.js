// JScript File
var hiddenauto="";
var modify="0";
//this flag is for permission
var flag="";
var z="0";
var hiddentext;
var auto="";
var hiddentext1="";
var ccmds;

///////global variables for deletion  by dataset.........
var glcode;
var glname;
var glalias;
/*********************************************************************************************************/

//*******************************************************************************************************

function newclick()
{      
            document.getElementById('txtclientcatcode').value="";
            document.getElementById('txtclientcatname').value="";
            document.getElementById('txtclientcatalias').value="";
            
           if(document.getElementById('hiddenauto').value==1)
                {
//if((document.getElementById('txtclientcatcode').value=="") &&(document.getElementById('hiddenauto').value!=1))
//  {
                   document.getElementById('txtclientcatcode').disabled=true;
                   
                }
           else
              {
                document.getElementById('txtclientcatcode').disabled=false;
               }
               
              document.getElementById('txtclientcatname').disabled=false;
              document.getElementById('txtclientcatalias').disabled=false;
           
              
             if(document.getElementById('hiddenauto').value==1)
               {
                     document.getElementById('txtclientcatname').focus();
               }
             else
              {
                       document.getElementById('txtclientcatcode').focus();
                       
               }

		
                
	hiddentext="new";
	chkstatus(FlagStatus);
			
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
		
		
	setButtonImages()	
				return false;
	}

/*********************************************************************************************************/

 
 function closeclient()
{
		if(confirm("Do You Want To Skip This Page"))
		{
		window.close();
		return false;
		}
		return false;
}
//********************************************************************************************************

/***********************************************************************************************************/


//**************************************************************************************

function autoornot()
 {
 
   // if(hiddentext=="new" )
   // {
          
          
          if(document.getElementById('hiddenauto').value==1)
            {
            changeoccured();
            //return false;
            }
        else
            {
            userdefine();

           // return false;
            }
   // }


}
/**************************************************************************/
// Auto generated
// This Function is for check that whether this is case for new or modify
/*****************************************************************************/

function changeoccured()
{
if(hiddentext=="new" )
{
// if((document.getElementById('txtclientcatcode').value=="") &&(document.getElementById('hiddenauto').value!=1))
//  {

//if(document.getElementById('hiddenauto').value==1)
			//{
	
            //uppercase3();        
//              document.getElementById('txtclientcatalias').value=document.getElementById('txtclientcatname').value;
//              document.getElementById('txtclientcatalias').focus();
//            //document.getElementById('txtclientcatname').value=document.getElementById('txtclientcatname').value.toUpperCase();
        document.getElementById('txtclientcatname').value=trim(document.getElementById('txtclientcatname').value);
		lstr=document.getElementById('txtclientcatname').value;
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
		
		    if(document.getElementById('txtclientcatname').value!="")
                {

		document.getElementById('txtclientcatname').value=document.getElementById('txtclientcatname').value.toUpperCase();
	    document.getElementById('txtclientcatalias').value=document.getElementById('txtclientcatname').value;
		// str=document.getElementById('txtzonename').value;
		str=mstr;
//		Adsubcat3.catdauto(str,fillcall);
           ClientCategoryMaster.chkclientcatmast(str,fillcall);

		//return false;
                }
            }
            else
            {
            document.getElementById('txtclientcatname').value=document.getElementById('txtclientcatname').value.toUpperCase();
            }
return false;
}

/*********************************************/
//auto generated
//this is used for increment in code
/*********************************************/
//*******************************************************************************************************
/**********************************************************************************************************/
function fillcall(res)
		{
		var ds=res.value;
		var newstr="";
		
//		if(ds.Tables[0].Rows.length !=0)
//		{
//		    alert("This Client Category Name has already been assigned !! ");
//		   // document.getElementById('txtclientcatcode').focus();
//		    
//  //		         document.getElementById('txtclientcatcode').value="";
// //				document.getElementById('txtclientcatname').value="";	
////				document.getElementById('txtclientcatalias').value="";
//			
//		     
//    		
//		    return false;
//		 }
//		 else
//		 {
//		        if(hiddentext=="new" )
		        //{
		            if(ds.Tables[1].Rows.length==0)
		            {
		                newstr=null;
		            }
		            else
		            {
		               newstr=ds.Tables[1].Rows[0].clientcat_Code;
		             }
		            if(newstr==0)
		              {
		                            str=str.toUpperCase();
		                            document.getElementById('txtclientcatcode').value=str.substr(0,2)+ "1";
		                            //newstr=document.getElementById('txtadcatcode').value;
		               }
		             else if(newstr>=1)
		             {
		                   str=str.toUpperCase();
		                   var Autoincrement=parseInt(ds.Tables[1].Rows[0].clientcat_Code)+1;
		                   document.getElementById('txtclientcatcode').value=str.substr(0,2)+ Autoincrement;
		             }
		             else if(newstr !=null )
		             {
		                  document.getElementById('txtclientcatname').value=trim(document.getElementById('txtclientcatname').value);
		                 // var code="";
		                   var code=newstr.substr(2,4);
		                  str=str.toUpperCase();
		                   code++;
		                   document.getElementById('txtclientcatcode').value=str.substr(0,2)+ code;
		               // document.getElementById('txtbillid').value=str.substr(1,3)+ code;
		               }
		               else
		               {
		                    str=str.toUpperCase();
		                    document.getElementById('txtclientcatcode').value=str.substr(0,2)+ "0";
		                            //document.getElementById('txtbillid').value=str.substr(0,2)+ "00";
		               }
		         
		     //}
	
		}

//*******************************************************************************************************

function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtclientcatcode').disabled=false;
        document.getElementById('txtclientcatname').value=document.getElementById('txtclientcatname').value.toUpperCase();
        document.getElementById('txtclientcatalias').value=document.getElementById('txtclientcatname').value;
        auto=document.getElementById('hiddenauto').value;
         //return false;
        }

return false;
}
/*********************************************************************************************************/		
		function cancelclick()
		{
		   document.getElementById('txtclientcatcode').value="";
		   document.getElementById('txtclientcatname').value="";
		   document.getElementById('txtclientcatalias').value="";
		   
		        document.getElementById('txtclientcatcode').disabled=true;
				document.getElementById('txtclientcatname').disabled=true;
				document.getElementById('txtclientcatalias').disabled=true;
				

				document.getElementById('btnNew').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExit').disabled=false;
				document.getElementById('btnDelete').disabled=true;
				
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				
				document.getElementById('btnDelete').disabled=true;
				
				modify="0";
				document.getElementById('btnNew').focus();
				
				setButtonImages()
				return false;

		}
/*******************************************************************************************************/



//*******************************************************************************************************
	function saveclick()
		{
	 
	 document.getElementById('txtclientcatcode').value=trim(document.getElementById('txtclientcatcode').value);
     document.getElementById('txtclientcatname').value=trim(document.getElementById('txtclientcatname').value);
     document.getElementById('txtclientcatalias').value=trim(document.getElementById('txtclientcatalias').value);
     
        //if(document.getElementById('hiddenauto').value!=1)
         // {
          
	      //if(document.getElementById('txtclientcatcode').value=="") 
	        if((document.getElementById('txtclientcatcode').value=="") &&(document.getElementById('hiddenauto').value!=1))
		       {

				alert("Please Enter Client Category Code");
				document.getElementById('txtclientcatcode').focus();
				return false;
		        }
		    
		 
		else if(document.getElementById('txtclientcatname').value=="")
		{
				alert("Please Enter Client Category name");
				document.getElementById('txtclientcatname').focus();
				return false;
		}
		else if(document.getElementById('txtclientcatalias').value=="")
		{
				alert("Please Enter Alias");
				document.getElementById('txtclientcatalias').focus();
				return false
		}

		var ccmcode=document.getElementById('txtclientcatcode').value;
		var ccmname=document.getElementById('txtclientcatname').value;
		var ccmalias=document.getElementById('txtclientcatalias').value;
		
		var compcode=document.getElementById('hiddencompcode').value;
		
		var userid=document.getElementById('hiddenuserid').value;
		
       
		if(modify!="1")
		{
			
			ClientCategoryMaster.checkccm(ccmcode,compcode,userid,ccmname,call_save);
		}
		else
		{
		
		///////////////this is to chk the duplicacy for name at the time for save 
		
		ClientCategoryMaster.chkname(ccmcode,ccmname,compcode,call_chkname);
			
			
			//flag=0;
		}
		setButtonImages()
		return false;
}

function call_chkname(res)
{
    var ds=res.value;
    if(ds.Tables[0].Rows.length>0)
    {
       alert("This  Client Category Name has already been assigned");
       document.getElementById('txtclientcatname').focus();
       return false;
    }
     else
     {

        var ccmcode=document.getElementById('txtclientcatcode').value;
		var ccmname=document.getElementById('txtclientcatname').value;
		var ccmalias=document.getElementById('txtclientcatalias').value;
		
		var compcode=document.getElementById('hiddencompcode').value;
		
		var userid=document.getElementById('hiddenuserid').value;
		
             ClientCategoryMaster.update(ccmcode,ccmname,ccmalias,compcode,userid);
			  ccmds.Tables[0].Rows[z].clientcat_code= document.getElementById('txtclientcatcode').value;
			ccmds.Tables[0].Rows[z].clientcat_name=document.getElementById('txtclientcatname').value;
			ccmds.Tables[0].Rows[z].clientcat_alias=document.getElementById('txtclientcatalias').value;
			
			alert("Data Updated Successfully");
			
			document.getElementById('btnModify').disabled=false;
            updateStatus()
			
			        									
					document.getElementById('btnfirst').disabled=false;
									
					document.getElementById('btnnext').disabled=false;					
					document.getElementById('btnprevious').disabled=false;			
					document.getElementById('btnlast').disabled=false;
			        if(z==0)
			        {
			        document.getElementById('btnfirst').disabled=true;				
			        document.getElementById('btnprevious').disabled=true;
			        }
			        if(z==ccmds.Tables[0].Rows.length-1)
			        {
			        document.getElementById('btnnext').disabled=true;					
			        document.getElementById('btnlast').disabled=true;
			        }

			document.getElementById('txtclientcatcode').disabled=true;
			document.getElementById('txtclientcatname').disabled=true;
			document.getElementById('txtclientcatalias').disabled=true;
			
			document.getElementById('btnSave').disabled=true;
			//document.getElementById('btnModify').disabled=true;
		
			modify="0";
}
setButtonImages();
}

/******************************************************/
function call_save(response)
{
		var ds=response.value;
		if(ds.Tables[1].Rows.length > 0)
		{
		    alert("This Client Category Name has already been assigned");
		    document.getElementById('txtclientcatname').focus();
		    
//		         document.getElementById('txtclientcatcode').value="";
// 			    document.getElementById('txtclientcatname').value="";	
//				document.getElementById('txtclientcatalias').value="";
		    return false;
		}
		if(ds.Tables[0].Rows.length > 0)
		{
			alert("This Code Has Already Been Assigned");
//			document.getElementById('txtclientcatcode').value="";
//			document.getElementById('txtclientcatname').value="";
//			document.getElementById('txtclientcatalias').value="";
            //document.getElementById('txtclientcatcode').focus();
			return false;
		}
		else
		{
			var ccmcode=document.getElementById('txtclientcatcode').value;
			var ccmname=document.getElementById('txtclientcatname').value;
			var ccmalias=document.getElementById('txtclientcatalias').value;
			
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
		
		ClientCategoryMaster.insert(ccmcode,ccmname,ccmalias,compcode,userid);

			alert("Data Saved Successfully");
			
		    

			document.getElementById('txtclientcatcode').value="";
			document.getElementById('txtclientcatname').value="";
			document.getElementById('txtclientcatalias').value="";
							     
			document.getElementById('txtclientcatcode').disabled=true;
			document.getElementById('txtclientcatname').disabled=true;
			document.getElementById('txtclientcatalias').disabled=true;
                        
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
			
			
			document.getElementById('btnNew').focus();
			
		}
		cancelclick('ClientCategoryMaster');
		return false;
}


/********************************************************************************************************/

function modifyclick()
{
			document.getElementById('txtclientcatcode').disabled=true;
			document.getElementById('txtclientcatname').disabled=false;
			document.getElementById('txtclientcatalias').disabled=false;
			
			
			chkstatus(FlagStatus);
			
			document.getElementById('btnSave').disabled = false;
			document.getElementById('btnQuery').disabled = true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			
			
			modify="1";
			 hiddentext="modify";
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
			
			//document.getElementById('btnExecute').disabled=false;
			
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnExit').disabled=false;	
			
			//document.getElementById('txtclientcatname').disabled=false;
			
			document.getElementById('txtclientcatname').focus();
			document.getElementById('btnModify').disabled=true;	
							
			flag=1;
			setButtonImages()
			return false;
}


/*******************************************************************************************************/
function queryclick()
{
			document.getElementById('txtclientcatcode').value="";
			document.getElementById('txtclientcatname').value="";
			document.getElementById('txtclientcatalias').value="";
			
			
			document.getElementById('txtclientcatcode').disabled=false;
			document.getElementById('txtclientcatname').disabled=false;
			document.getElementById('txtclientcatalias').disabled=false;
			
			z=0;
			modify="0";
			hiddentext="query";
			chkstatus(FlagStatus);
			//updateStatus();

            document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;
			
			//document.gatElementById('txtclientcatname').focus();
			
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnExecute').focus();
			
			setButtonImages()
			return false;
}
/******************************************************************************************************/

/********************************************************************************************************/
function executeclick()
{


               z=0;
			var compcode=document.getElementById('hiddencomcode').value;
			
		
			var ccmcode=document.getElementById('txtclientcatcode').value;
			glcode=ccmcode;
			var ccmname=document.getElementById('txtclientcatname').value;
			glname=ccmname;
			var ccmalias=document.getElementById('txtclientcatalias').value;
			glalias=ccmalias;
			var userid=document.getElementById('hiddenuserid').value;			

			//BillStatus.billexecute1(companycode,zonecode,zonename,alias,UserId,checkcall);	
			ClientCategoryMaster.execute(ccmcode,ccmname,ccmalias,compcode,userid,call_execute);
			
		
			document.getElementById('txtclientcatcode').disabled=true;
			document.getElementById('txtclientcatname').disabled=true;
			document.getElementById('txtclientcatalias').disabled=true;
			
			mod="0";
			
			updateStatus();
            document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;
			
			if(document.getElementById('btnModify').disabled==false)
			    document.getElementById('btnModify').focus();
							
			setButtonImages()
			return false;
}
//*******************************************************************************************************
function call_execute(response)
{
		//var ccmds=response.value;
	    ccmds=response.value;
			if(ccmds.Tables[0].Rows.length > 0)
			{
			  // document.getElementById('hiddencomcode').value=ccmds.Tables[0].Rows[0].comp_code;
			   
			  
			 	document.getElementById('txtclientcatcode').value=ccmds.Tables[0].Rows[0].clientcat_code
				document.getElementById('txtclientcatname').value=ccmds.Tables[0].Rows[0].clientcat_name
				document.getElementById('txtclientcatalias').value=ccmds.Tables[0].Rows[0].clientcat_alias
				//document.getElementById('hiddenuserid').value=ccmds.Tables[0].Rows[0].userId;
				
					
			
			document.getElementById('txtclientcatcode').disabled=true;
			document.getElementById('txtclientcatname').disabled=true;
			document.getElementById('txtclientcatalias').disabled=true;
						
			}
			
			else
			{
				alert("Your Search Produce No Result!!!!");
			cancelclick('ClientCategoryMaster');
			//return false;
			}

            if(ccmds.Tables[0].Rows.length ==1)
			{
			    document.getElementById('btnfirst').disabled=true;				
			   document.getElementById('btnnext').disabled=true;					
			    document.getElementById('btnprevious').disabled=true;			
			   document.getElementById('btnlast').disabled=true;
			}
			setButtonImages();
			return false;
}
/***************************************************************************/
/**********************************************************************************************************/

function cancelclick(formname)
{
				document.getElementById('txtclientcatcode').value="";
				document.getElementById('txtclientcatname').value="";
				document.getElementById('txtclientcatalias').value="";
			

				document.getElementById('txtclientcatcode').disabled=true;
				document.getElementById('txtclientcatname').disabled=true;
				document.getElementById('txtclientcatalias').disabled=true;
				
				document.getElementById('btnNew').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExit').disabled=false;
				document.getElementById('btnDelete').disabled=true;
				
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnNew').disabled=false;
				document.getElementById('btnExecute').disabled=true;


				modify="0";
				document.getElementById('btnNew').focus();
				
				givebuttonpermission(formname);
				setButtonImages()
				return false;
}
/**********************************************************************************************************/
function firstclick()
{
		ClientCategoryMaster.first(call_first);
		return false;
}
/**********************************************/

function firstclick()
{
		//var ds=response.value;
		z=0;
		var ccmcode=document.getElementById('txtclientcatcode').value=ccmds.Tables[0].Rows[0].clientcat_code;
		var cmdesc=document.getElementById('txtclientcatname').value=ccmds.Tables[0].Rows[0].clientcat_name;
		var ccmalias=document.getElementById('txtclientcatalias').value=ccmds.Tables[0].Rows[0].clientcat_alias;
		
   
		updateStatus();

		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnlast').disabled=false;
		
		if(document.getElementById('btnModify').disabled==false)	
				document.getElementById('btnModify').focus();
		setButtonImages()
		return false;
}
/***********************************************************************************************************/

function lastclick()
{
		ClientCategoryMaster.first(call_last);
		setButtonImages()
		return false;
}
/******************************************/

function lastclick()
{
		//var ds=response.value;
		var y=ccmds.Tables[0].Rows.length;
		var a=y-1;
		z=a;

		var ccmcode=document.getElementById('txtclientcatcode').value=ccmds.Tables[0].Rows[a].clientcat_code;
		var ccmname=document.getElementById('txtclientcatname').value=ccmds.Tables[0].Rows[a].clientcat_name;
		var ccmalias=document.getElementById('txtclientcatalias').value=ccmds.Tables[0].Rows[a].clientcat_alias;
		
	
		updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
		
		if(document.getElementById('btnModify').disabled==false)
			document.getElementById('btnModify').focus();

setButtonImages()

		return false;
}
/********************************************************************************************************/

function previousclick()
{
		ClientCategoryMaster.first(call_previous);
		setButtonImages()
		return false;
}
/***********************************************/

function previousclick()
{
	//	var ds=response.value;
		var a=ccmds.Tables[0].Rows.length;
        updateStatus();
		z--;
		if(z != -1  )
		{
		if(z >= 0 && z < a)
		{
			var ccmcode=document.getElementById('txtclientcatcode').value=ccmds.Tables[0].Rows[z].clientcat_code;
			var ccmname=document.getElementById('txtclientcatname').value=ccmds.Tables[0].Rows[z].clientcat_name;
			var ccmalias=document.getElementById('txtclientcatalias').value=ccmds.Tables[0].Rows[z].clientcat_alias;
			

			
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=false;				
			document.getElementById('btnprevious').disabled=false;				
			document.getElementById('btnlast').disabled=false;			
			document.getElementById('btnExit').disabled=false;
			
			if(document.getElementById('btnModify').disabled==false)
				document.getElementById('btnModify').focus();
		}
		else
		{
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			
			if(document.getElementById('btnModify').disabled==false)
				document.getElementById('btnModify').focus();
		}	
		}
		else
		{
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			
			if(document.getElementById('btnModify').disabled==false)
				document.getElementById('btnModify').focus();
		}	
		
		if(z==0)
		{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			
			if(document.getElementById('btnModify').disabled==false)
				document.getElementById('btnModify').focus();
		}
		setButtonImages()
		return false;
}
/**********************************************************************************************************/

function nextclick()
{
			ClientCategoryMaster.first(call_next);
			setButtonImages()
			return false;
}
/**********************************************************/

function nextclick()
{
		//var ds=response.value;
		var a=ccmds.Tables[0].Rows.length;
        updateStatus();
		z++;
		if(z !=-1 && z >= 0)
		{
		if(z <= a-1)
		{
			var ccmcode=document.getElementById('txtclientcatcode').value=ccmds.Tables[0].Rows[z].clientcat_code;
			var ccmname=document.getElementById('txtclientcatname').value=ccmds.Tables[0].Rows[z].clientcat_name;
			var txtalias=document.getElementById('txtclientcatalias').value=ccmds.Tables[0].Rows[z].clientcat_alias;
			
	
			
			
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			
			if(document.getElementById('btnModify').disabled==false)
			    document.getElementById('btnModify').focus();
		}
		else
		{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			
			if(document.getElementById('btnModify').disabled==false)
				document.getElementById('btnModify').focus();
		
		}	
		}
		else
		{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			
			if(document.getElementById('btnModify').disabled==false)
				document.getElementById('btnModify').focus();
		
		}	
		if(z==a-1)
		{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			
			if(document.getElementById('btnModify').disabled==false)
				document.getElementById('btnModify').focus();
		
		}
		setButtonImages()
		return false;
}
/********************************************************************************************************/
function deleteclick()
{
		var ccmcode=document.getElementById('txtclientcatcode').value;
		var ccmname=document.getElementById('txtclientcatname').value;
		var ccmalias=document.getElementById('txtclientcatalias').value;
		
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		
    
        
		if(confirm("Are You Sure Want To Delete The Data"))
		{	
			ClientCategoryMaster.deleteit(ccmcode,compcode,userid);
			alert("Date Deleted Successfully");
				ClientCategoryMaster.execute(glcode,glname,glalias,compcode,userid,call_delete);
			
		}
		setButtonImages()
		return false;
}
/**************************************************************/

function call_delete(response)
{
	ccmds=response.value;
	//var ds=response.value;
	var a=ccmds.Tables[0].Rows.length;
	
	var y=a-1;
	
	if( a <=0 )
	{
		alert("There Is No More Data To Be Deleted");
		
		document.getElementById('txtclientcatcode').value="";
		document.getElementById('txtclientcatname').value="";
		document.getElementById('txtclientcatalias').value="";
		cancelclick('ClientCategoryMaster');
		return false;
	}
	
	else if(a==1)
	{
	        document.getElementById('btnfirst').disabled=true;				
			   document.getElementById('btnnext').disabled=true;					
			   document.getElementById('btnprevious').disabled=true;			
			   document.getElementById('btnlast').disabled=true;
			   
			   var ccmcode=document.getElementById('txtclientcatcode').value=ccmds.Tables[0].Rows[0].clientcat_code;
		var ccmname=document.getElementById('txtclientcatname').value=ccmds.Tables[0].Rows[0].clientcat_name;
		var ccmalias=document.getElementById('txtclientcatalias').value=ccmds.Tables[0].Rows[0].clientcat_alias;
			
			  
	}
		
	else  if(z==-1 ||z>=a )
	{
		var ccmcode=document.getElementById('txtclientcatcode').value=ccmds.Tables[0].Rows[0].clientcat_code;
		var ccmname=document.getElementById('txtclientcatname').value=ccmds.Tables[0].Rows[0].clientcat_name;
		var ccmalias=document.getElementById('txtclientcatalias').value=ccmds.Tables[0].Rows[0].clientcat_alias;
			
			document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnnext').disabled=false;					
		 document.getElementById('btnprevious').disabled=true;			
		document.getElementById('btnlast').disabled=false;
		z=0;
		
		
		return false;
	}
	else
	{
        var ccmcode=document.getElementById('txtclientcatcode').value=ccmds.Tables[0].Rows[0].clientcat_code;
		var ccmname=document.getElementById('txtclientcatname').value=ccmds.Tables[0].Rows[0].clientcat_name;
		var ccmalias=document.getElementById('txtclientcatalias').value=ccmds.Tables[0].Rows[0].clientcat_alias;
		
		
		   	
	}
	
//         if (z==0)
//               {
//                document.getElementById('btnfirst').disabled=true;
//                document.getElementById('btnprevious').disabled=true;
//                }

	
	return false;
}


/*********************************************************************************************************/
///for caps

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



function blankclient()
{
cancelclick('ClientCategoryMaster');
givebuttonpermission('ClientCategoryMaster');


}
/********************************************************************************************************/