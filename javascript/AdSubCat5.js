// JScript File
var hiddentext;
var mod="0";
var z=0;
var znk="0";
var auto="";
var hiddentext1="";
var glaobalcatcod;
var glaobalcatname;
var glaobalcatalias;
var glaobalsubcatname;
var name_modify="";
var dscatexecute;
var y;
var dscatdelete;

function catnewclick()
{
 var msg=checkSession();
            if(msg==false)
            return false;
            document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcatname').value="";
            document.getElementById('txtadcatcode').value="";
            document.getElementById('txtalias').value = "";
            document.getElementById('txtsalesorg').value = "";
           if(document.getElementById('hiddenauto').value==1)
                {
                   document.getElementById('txtadcatcode').disabled=true;
                   
                }
           else
              {
                document.getElementById('txtadcatcode').disabled=false;
               }
              document.getElementById('txtadcatname').disabled=false;
              document.getElementById('txtalias').disabled = false;
              document.getElementById('txtsalesorg').disabled = false;
              document.getElementById('drpadvcatcode').disabled=false;
             if(document.getElementById('hiddenauto').value==1)
               {
                        document.getElementById('drpadvcatcode').focus();
               }
             else
              {
                       document.getElementById('drpadvcatcode').focus();
               }
	hiddentext="new";
	chkstatus(FlagStatus);
			
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
		setButtonImages();
				return false;
	}



	
	function catsaveclick()
{
 var msg=checkSession();
            if(msg==false)
            return false;
 document.getElementById('txtadcatcode').value=trim(document.getElementById('txtadcatcode').value);
 document.getElementById('txtadcatname').value=trim(document.getElementById('txtadcatname').value);
 document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
 document.getElementById('drpadvcatcode').value=trim(document.getElementById('drpadvcatcode').value);


//if(flag==1)
//				{
//					if(document.getElementById('drpadvcatcode').value=="0")
//		{
//		
//		alert("You Must Select Ad Category Name");
//		document.getElementById('drpadvcatcode').focus();
//		return false;
//		}
//		else
//		{}
		if(document.getElementById('drpadvcatcode').value=="0")
              {
              alert("You Must Select Ad Sub Category4 Name");
              document.getElementById('drpadvcatcode').focus();
              return false;
              }
  
			 if((document.getElementById('txtadcatcode').value=="")&&(document.getElementById('hiddenauto').value!=1))
              {
                           
			// if(document.getElementById('txtadcatcode').value=="")
			//{
			alert("Please Enter the Sub Category5 Code ");
			document.getElementById('txtadcatcode').focus();
			return false;
			}
			//return false;
		//	}
					
			else if(document.getElementById('txtadcatname').value=="")
			{
			alert("Please Enter the Sub Category5 Name ");
			document.getElementById('txtadcatname').focus();
			return false;
			}
			else if(document.getElementById('txtalias').value=="")
			{
			alert("Please Enter the Alias");
			document.getElementById('txtalias').focus();
			return false;
			}
			
				//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
            var subcatname=document.getElementById('drpadvcatcode').value;  
			var compcode=document.getElementById('hiddencomcode').value;
			var catcode=document.getElementById('txtadcatcode').value;
			var catname=document.getElementById('txtadcatname').value;
		    catname=trim(catname);
			var catalias=document.getElementById('txtalias').value;
			var userid=document.getElementById('hiddenuserid').value;			

			if(mod !="1" && mod !=null)
			{
			 AdSubCat5.chkcatcod(catname,subcatname,call_saveclick);
			}
			else
			{
			 if(name_modify==document.getElementById('txtadcatname').value)
			    {
			        updatecat4();
			    }
			    else
			    {
	           AdSubCat5.chkcatcod(catname,subcatname,call_modifyclick);
	           }
//		     AdSubCat5.catmodify(compcode,subcatname,catname,catcode,catalias,userid);
//		     dscatexecute.Tables[0].Rows[z].Comp_Code=document.getElementById('hiddencomcode').value;
//		     dscatexecute.Tables[0].Rows[z].Sub_Cat_Name=document.getElementById('drpadvcatcode').value;
//		     dscatexecute.Tables[0].Rows[z].Cat_Name=document.getElementById('txtadcatname').value;
//              dscatexecute.Tables[0].Rows[z].Cat_Code=document.getElementById('txtadcatcode').value;
//				dscatexecute.Tables[0].Rows[z].Cat_Alias=document.getElementById('txtalias').value;
//				dscatexecute.Tables[0].Rows[z].userId=document.getElementById('hiddencomcode').value;

//			alert("Data Updated Successfully");

//			document.getElementById('drpadvcatcode').disabled=true;
//            document.getElementById('txtadcatname').disabled=true;
//            document.getElementById('txtadcatcode').disabled=true;
//            document.getElementById('txtalias').disabled=true;
//			
//			
//			document.getElementById('btnSave').disabled=true;
//			
//		    
//			updateStatus();
//			if (z==0)
//               {
//                document.getElementById('btnfirst').disabled=true;
//                document.getElementById('btnprevious').disabled=true;
//                }

//             if(z==(dscatexecute.Tables[0].Rows.length-1))
//              {
//                document.getElementById('btnNext').disabled=true;
//	            document.getElementById('btnLast').disabled=true;
//              }       
//			
//			mod="0";
//		  document.getElementById('btnModify').disabled=true;	
		
			}
			return false;
}
function call_saveclick(response)
{
			var ds=response.value;
			if(ds.Tables[0].Rows.length > 0)
			{
			alert("This Sub Category5 Name  Is Already Exist, Try Another Code !!!!");
			
			 document.getElementById('drpadvcatcode').value=0;
//            document.getElementById('txtadcatname').value="";
//            document.getElementById('txtadcatcode').value="";
//            document.getElementById('txtalias').value=""
			
			
			return false;
			} 
			else
			{
			var subcatname=document.getElementById('drpadvcatcode').value;  
			var compcode=document.getElementById('hiddencomcode').value;
			var catcode=document.getElementById('txtadcatcode').value;
			var catname=document.getElementById('txtadcatname').value;
		    var catalias=document.getElementById('txtalias').value;
			var userid=document.getElementById('hiddenuserid').value;
			var ip2 = document.getElementById('ip1').value;
			var sapecode = document.getElementById('txtsalesorg').value;
			AdSubCat5.savecat4(compcode, subcatname, catname, catalias, catcode, userid, ip2, sapecode);

				alert("Data Saved Successfully");
				


			document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcatname').value="";
            document.getElementById('txtadcatcode').value="";
            document.getElementById('txtalias').value = "";
            document.getElementById('txtsalesorg').value = "";
						
//			document.getElementById('drpadvcatcode').value=true;
//            document.getElementById('txtadcat3name').value=true;
//            document.getElementById('txtadcat3code').value=true;
//            document.getElementById('txtalias').value=true;
								
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
			catcancelclick('AdSubCat5');
			return false;
}


function call_modifyclick(response)
{
      var ds=response.value;
			if(ds.Tables[0].Rows.length > 0)
			{
			    alert("This Sub Category5 Name  Is Already Exist, Try Another Code !!!!");
		        document.getElementById('drpadvcatcode').value=0;
		        document.getElementById('txtadcatcode').value="";	
		        document.getElementById('txtadcatname').value="";	
		        document.getElementById('txtalias').value="";
			    return false;
			}
			else
			{
			  var subcatname=document.getElementById('drpadvcatcode').value;  
			var compcode=document.getElementById('hiddencomcode').value;
			var catcode=document.getElementById('txtadcatcode').value;
			var catname=document.getElementById('txtadcatname').value;
		    catname=trim(catname);
			var catalias=document.getElementById('txtalias').value.toUpperCase();
			var userid=document.getElementById('hiddenuserid').value;
			var ip2 = document.getElementById('ip1').value;
			var sapecode = document.getElementById('txtsalesorg').value;
			 AdSubCat5.catmodify(compcode,subcatname,catname,catcode,catalias,userid,ip2,sapecode);
		     dscatexecute.Tables[0].Rows[z].Comp_Code=document.getElementById('hiddencomcode').value;
		     dscatexecute.Tables[0].Rows[z].Sub_Cat_Name=document.getElementById('drpadvcatcode').value;
		     dscatexecute.Tables[0].Rows[z].Cat_Name=document.getElementById('txtadcatname').value;
              dscatexecute.Tables[0].Rows[z].Cat_Code=document.getElementById('txtadcatcode').value;
				dscatexecute.Tables[0].Rows[z].Cat_Alias=document.getElementById('txtalias').value;
				dscatexecute.Tables[0].Rows[z].userId=document.getElementById('hiddencomcode').value;

			alert("Data Updated Successfully");

			document.getElementById('drpadvcatcode').disabled=true;
            document.getElementById('txtadcatname').disabled=true;
            document.getElementById('txtadcatcode').disabled=true;
            document.getElementById('txtalias').disabled = true;
            document.getElementById('txtsalesorg').disabled =true;
			
			
			//document.getElementById('btnSave').disabled=true;
			
		    
			updateStatus();
			if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==(dscatexecute.Tables[0].Rows.length-1))
              {
                document.getElementById('btnNext').disabled=true;
	            document.getElementById('btnLast').disabled=true;
              }       
			
			mod="0";
		    if(document.getElementById('btnModify').disabled==false)
		    document.getElementById('btnModify').focus();	
		
			}
		//	catcancelclick('AdSubCat5');
		setButtonImages();
			return false;
  
}


function updatecat4()
{
           var subcatname=document.getElementById('drpadvcatcode').value;  
			var compcode=document.getElementById('hiddencomcode').value;
			var catcode=document.getElementById('txtadcatcode').value;
			var catname=document.getElementById('txtadcatname').value;
		    catname=trim(catname);
			var catalias=document.getElementById('txtalias').value.toUpperCase();
			var userid=document.getElementById('hiddenuserid').value;
			var ip2 = document.getElementById('ip1').value;
			var sapecode = document.getElementById('txtsalesorg').value;
			AdSubCat5.catmodify(compcode, subcatname, catname, catcode, catalias, userid, ip2, sapecode);
		     dscatexecute.Tables[0].Rows[z].Comp_Code=document.getElementById('hiddencomcode').value;
		     dscatexecute.Tables[0].Rows[z].Sub_Cat_Name=document.getElementById('drpadvcatcode').value;
		     dscatexecute.Tables[0].Rows[z].Cat_Name=document.getElementById('txtadcatname').value;
              dscatexecute.Tables[0].Rows[z].Cat_Code=document.getElementById('txtadcatcode').value;
				dscatexecute.Tables[0].Rows[z].Cat_Alias=document.getElementById('txtalias').value;
				dscatexecute.Tables[0].Rows[z].userId=document.getElementById('hiddencomcode').value;
			
				alert("Data Updated Successfully");

			document.getElementById('drpadvcatcode').disabled=true;
            document.getElementById('txtadcatname').disabled=true;
            document.getElementById('txtadcatcode').disabled=true;
            document.getElementById('txtalias').disabled = true;
            document.getElementById('txtsalesorg').disabled = true;


			
			document.getElementById('btnSave').disabled=true;
			
		    
			updateStatus();
			if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==(dscatexecute.Tables[0].Rows.length-1))
              {
                document.getElementById('btnNext').disabled=true;
	            document.getElementById('btnLast').disabled=true;
              }       
			
			mod="0";
		    if(document.getElementById('btnModify').disabled==false)
		    document.getElementById('btnModify').focus();
		
	//		catcancelclick('AdSubCat5');    
	    setButtonImages();
			return false;
}
/*********************************************Auto Generate***********************/
function autoornot()
 {
 
//    if(hiddentext=="new" )
//    {
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
    //}
//return false;
}

// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
if(hiddentext=="new" )
//    {

//  if(document.getElementById('hiddenauto').value==1)
			{
	
            //uppercase3();
            document.getElementById('txtadcatname').value=trim(document.getElementById('txtadcatname').value);
		   lstr=document.getElementById('txtadcatname').value;
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
		
		    if(document.getElementById('txtadcatname').value!="")
                {

		document.getElementById('txtadcatname').value=document.getElementById('txtadcatname').value.toUpperCase();
	    document.getElementById('txtalias').value=document.getElementById('txtadcatname').value;
		var subcatname=document.getElementById('drpadvcatcode').value; 
		str=mstr;
		AdSubCat5.catdauto(str,subcatname,fillcall);
		return false;
                }
          }
      else
            {
            document.getElementById('txtadcatname').value=document.getElementById('txtadcatname').value.toUpperCase();
            }
         return false;
     //}       
               

}


//auto generated
//this is used for increment in code

/*function uppercase3()
		{
		document.getElementById('txtadcatname').value=trim(document.getElementById('txtadcatname').value);
		lstr=document.getElementById('txtadcatname').value;
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
		
		    if(document.getElementById('txtadcatname').value!="")
                {

		document.getElementById('txtadcatname').value=document.getElementById('txtadcatname').value.toUpperCase();
	    document.getElementById('txtalias').value=document.getElementById('txtadcatname').value;
		// str=document.getElementById('txtzonename').value;
		str=mstr;
		AdSubCat5.catdauto(str,fillcall);
		return false;
                }
		       
               
 //return false;
		
}*/

function fillcall(res)
		{
		var ds=res.value;
		var newstr;
		if(ds.Tables[0].Rows.length !=0)
		{
		    alert("This Sub Category5 Name has already been assigned !! ");
		    
		         document.getElementById('txtadcatcode').value="";
				document.getElementById('txtadcatname').value="";	
				document.getElementById('txtalias').value="";
			     document.getElementById('txtadcatname').focus();
		  
    		
		    return false;
		 }
		 else
//		 {
//		        if(hiddentext=="new" )
		        {
		            if(ds.Tables.length>1 && ds.Tables[1].Rows.length==0)
		            {
		                newstr=null;
		            }
		            else
		            {
		                if(ds.Tables.length>1)
		                    newstr=ds.Tables[1].Rows[0].Cat_Code;
		             }
		            if(newstr==0)
		              {
		                            str=str.toUpperCase();
		                            document.getElementById('txtadcatcode').value=str.substr(0,2)+ "1";
		                            //newstr=document.getElementById('txtadcatcode').value;
		                           
		               }
		             else if(newstr>=1)
		             {
		                   var Autoincrement=parseInt(ds.Tables[1].Rows[0].Cat_Code)+1;
		                    str=str.toUpperCase();
		                   document.getElementById('txtadcatcode').value=str.substr(0,2)+ Autoincrement;
		                  
		             }
		             else if(newstr !=null )
		             {
		                  document.getElementById('txtadcatname').value=trim(document.getElementById('txtadcatname').value);
		                   var code=newstr.substr(2,4);
		                   var code=newstr;
		                   code++;
		                   str=str.toUpperCase();
		                   document.getElementById('txtadcatcode').value=str.substr(0,2)+ code;
		               // document.getElementById('txtbillid').value=str.substr(1,3)+ code;
		               }
		               else
		               {
		                     str=str.toUpperCase();
		                    document.getElementById('txtadcatcode').value=str.substr(0,2)+ "0";
		                    
		                    
		                            //document.getElementById('txtbillid').value=str.substr(0,2)+ "00";
		               }
		         //}
		     }
	//return false;
		}
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtadcatcode').disabled=false;
        document.getElementById('txtadcatname').value=document.getElementById('txtadcatname').value.toUpperCase();
        document.getElementById('txtalias').value=document.getElementById('txtadcatname').value;
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

return false;
}

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
function check()
{
    document.getElementById('txtadcatname').value=trim(document.getElementById('txtadcatname').value);
 }

//*******************************************************************************//
//**************************This Function For Modify Button**********************//
//*******************************************************************************//
function catmodifyclick()
{

			document.getElementById('drpadvcatcode').disabled=true;
            document.getElementById('txtadcatname').disabled=false;
            document.getElementById('txtadcatcode').disabled=true;
            document.getElementById('txtalias').disabled = false;
            document.getElementById('txtsalesorg').disabled = false;
					
				
				chkstatus(FlagStatus);
              name_modify=document.getElementById('txtadcatname').value;
				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				//document.getElementById('btnModify').disabled=false;
				
				document.getElementById('btnSave').focus();
				   mod="1";
				 hiddentext="mod";	
					setButtonImages();						
				return false;
}
//*******************************************************************************//
//*************************This Function For Query Button***********************//
//*******************************************************************************//

function catqueryclick()
{
			document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcatname').value="";
            document.getElementById('txtadcatcode').value="";
            document.getElementById('txtalias').value="";
				z=0;
				document.getElementById('drpadvcatcode').disabled=false;
				document.getElementById('txtadcatname').disabled=false;
				document.getElementById('txtadcatcode').disabled=false;
				document.getElementById('txtalias').disabled=false;
				chkstatus(FlagStatus);
	//document.getElementById('btnNew').disabled=true;				
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
	setButtonImages();
		document.getElementById('btnExecute').focus();
				hiddentext="query";
										
				
				return false;
}

//*******************************************************************************//
//**********************This Function For Execute Button*************************//
//*******************************************************************************//

function catexecuteclick()
{
            var msg=checkSession();
            if(msg==false)
            return false;

            z=0;
			var compcode=document.getElementById('hiddencomcode').value;
			var subcatname=document.getElementById('drpadvcatcode').value;
			glaobalsubcatname=subcatname;
			var catcode=document.getElementById('txtadcatcode').value;
			glaobalcatcode=catcode;
			var catname=document.getElementById('txtadcatname').value;
			glaobalcatname=catname;
			var catalias=document.getElementById('txtalias').value;
			glaobalcatalias=catalias;
			var userid=document.getElementById('hiddenuserid').value;			

			//BillStatus.billexecute1(companycode,zonecode,zonename,alias,UserId,checkcall);	
			//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
AdSubCat5.catexecute1(compcode, subcatname,catcode, catname, catalias,userid,checkcall);
					
			updateStatus();
			document.getElementById('drpadvcatcode').disabled=true;
			document.getElementById('txtadcatcode').disabled=true;
			document.getElementById('txtadcatname').disabled=true;
			document.getElementById('txtalias').disabled=true;
			document.getElementById('txtsalesorg').disabled = true;
			mod="0";
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
		    if(document.getElementById('btnModify').disabled==false)					
		       document.getElementById('btnModify').focus();	
							
			
			return false;
}

//*******************************************************************************//
//********************This Is The Responce Of The Execute Button*****************//
//*******************************************************************************//	
function checkcall(response)
{
			//var ds=response.value;
			dscatexecute=response.value;
			if(dscatexecute.Tables[0].Rows.length > 0)
			{
			   //document.getElementById('hiddencomcode').value=dscatexecute.Tables[0].Rows[0].Comp_Code;
			   document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[0].Sub_Cat_Name;
			 	document.getElementById('txtadcatcode').value=dscatexecute.Tables[0].Rows[0].Cat_Code;
				document.getElementById('txtadcatname').value=dscatexecute.Tables[0].Rows[0].Cat_Name;
				document.getElementById('txtalias').value = dscatexecute.Tables[0].Rows[0].Cat_Alias;

				if (dscatexecute.Tables[0].Rows[0].SAPECODE != null) {
				    document.getElementById('txtsalesorg').value = dscatexecute.Tables[0].Rows[0].SAPECODE;
				}
				else {
				    document.getElementById('txtsalesorg').value = "";
				}
				
				//document.getElementById('hiddenuserid').value=dscatexecute.Tables[0].Rows[0].userId;
				
					
				document.getElementById('drpadvcatcode').disabled=true;
			document.getElementById('txtadcatcode').disabled=true;
			document.getElementById('txtadcatname').disabled=true;
			document.getElementById('txtalias').disabled = true;
			document.getElementById('txtsalesorg').disabled = true;
						
			}
			
			else
			{
				alert("Your Search Produce No Result!!!!");
			catcancelclick('AdSubCat5');
			}

            if(dscatexecute.Tables[0].Rows.length ==1)
			{
			    document.getElementById('btnfirst').disabled=true;				
			   document.getElementById('btnnext').disabled=true;					
			    document.getElementById('btnprevious').disabled=true;			
			   document.getElementById('btnlast').disabled=true;
			}
			setButtonImages();
			return false;
}
//*******************************************************************************//
//*************************This Function For First Button************************//
//********************************************************//

//function catfirstclick()
//{

//			AdSubCat5.catfpnl(firstcall);
//						
//			document.getElementById('drpadvcatcode').disabled=true;
//			document.getElementById('txtadcatcode').disabled=true;
//			document.getElementById('txtadcatname').disabled=true;
//			document.getElementById('txtalias').disabled=true;
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
function firstcall()
{
 var msg=checkSession();
            if(msg==false)
            return false;
			//var dszoneexecute=response.value;
	
			    document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[0].Sub_Cat_Name;
			 	document.getElementById('txtadcatcode').value=dscatexecute.Tables[0].Rows[0].Cat_Code;
				document.getElementById('txtadcatname').value=dscatexecute.Tables[0].Rows[0].Cat_Name;
				document.getElementById('txtalias').value = dscatexecute.Tables[0].Rows[0].Cat_Alias;
				if (dscatexecute.Tables[0].Rows[0].SAPECODE != null) {
				    document.getElementById('txtsalesorg').value = dscatexecute.Tables[0].Rows[0].SAPECODE;
				}
				else {
				    document.getElementById('txtsalesorg').value = "";
				}
			z=0;
			updateStatus();

		document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnExit').disabled=false;
				setButtonImages();
			return false;
}

//*******************************************************************************//
//*************************This Function For Last Button*************************//
//*******************************************************************************//

//function catlastclick()
//{
//			AdSubCat5.catfpnl(lastcall);

//			 document.getElementById('drpadvcatcode').disabled=true;
//			document.getElementById('txtadcatcode').disabled=true;
//			document.getElementById('txtadcatname').disabled=true;
//			document.getElementById('txtalias').disabled=true;
//						
//			return false;
//}

//*******************************************************************************//
//********************This Function For Last Button*******************//
//*******************************************************************************//
function lastcall()
{
 var msg=checkSession();
            if(msg==false)
            return false;
			//var dszoneexecute=response.value;
			var y=dscatexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;
			
			    document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[z].Sub_Cat_Name;
			 	document.getElementById('txtadcatcode').value=dscatexecute.Tables[0].Rows[z].Cat_Code;
				document.getElementById('txtadcatname').value=dscatexecute.Tables[0].Rows[z].Cat_Name;
				document.getElementById('txtalias').value = dscatexecute.Tables[0].Rows[z].Cat_Alias;
				if (dscatexecute.Tables[0].Rows[z].SAPECODE != null) {
				    document.getElementById('txtsalesorg').value = dscatexecute.Tables[0].Rows[z].SAPECODE;
				}
				else {
				    document.getElementById('txtsalesorg').value = "";
				}
			updateStatus();
			
		        document.getElementById('btnnext').disabled=true;
		        document.getElementById('btnlast').disabled=true;
		        document.getElementById('btnfirst').disabled=false;
		        document.getElementById('btnprevious').disabled=false;
		        setButtonImages();
			return false;
}


//*******************************************************************************//
//***********************This Function For Previous Button***********************//
//*******************************************************************************//


//function catpreviousclick()
//{			
//			AdSubCat5.catfpnl(previouscall);

//			    document.getElementById('drpadvcatcode').disabled=true;
//			document.getElementById('txtadcatcode').disabled=true;
//			document.getElementById('txtadcatname').disabled=true;
//			document.getElementById('txtalias').disabled=true;
//			return false;
//}

//*******************************************************************************//
//********************This Function For Previous Button****************//
//*******************************************************************************//
function previouscall()
{
 var msg=checkSession();
            if(msg==false)
            return false;
		//var dszoneexecute=response.value;
		var a=dscatexecute.Tables[0].Rows.length;
		z--;
		if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
				 document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[z].Sub_Cat_Name;
			 	document.getElementById('txtadcatcode').value=dscatexecute.Tables[0].Rows[z].Cat_Code;
				document.getElementById('txtadcatname').value=dscatexecute.Tables[0].Rows[z].Cat_Name;
				document.getElementById('txtalias').value = dscatexecute.Tables[0].Rows[z].Cat_Alias;


				if (dscatexecute.Tables[0].Rows[z].SAPECODE != null) {
				    document.getElementById('txtsalesorg').value = dscatexecute.Tables[0].Rows[z].SAPECODE;
				}
				else {
				    document.getElementById('txtsalesorg').value = "";
				}
			updateStatus();
					document.getElementById('btnfirst').disabled=false;				
		document.getElementById('btnnext').disabled=false;				
		document.getElementById('btnprevious').disabled=false;				
		document.getElementById('btnlast').disabled=false;			
		document.getElementById('btnExit').disabled=false;
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
		setButtonImages();
		return false;
}
		
//*******************************************************************************//
//**************************This Function For Next Button*************************//
//*******************************************************************************//

//function catnextclick()
//{
//	AdSubCat5.catfpnl(nextcall);

//		        
//			    document.getElementById('drpadvcatcode').disabled=true;
//			document.getElementById('txtadcatcode').disabled=true;
//			document.getElementById('txtadcatname').disabled=true;
//			document.getElementById('txtalias').disabled=true;
//		
//		return false;
//}


//*******************************************************************************//
//********************This Is The Responce Of The Next Button*******************//
//*******************************************************************************//
function catnextclick(response)
{
 var msg=checkSession();
            if(msg==false)
            return false;
//	var dszoneexecute=response.value;
	//dscatexecute=response.value;
	var a=dscatexecute.Tables[0].Rows.length;
	z++;
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
			 document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[z].Sub_Cat_Name;
			 	document.getElementById('txtadcatcode').value=dscatexecute.Tables[0].Rows[z].Cat_Code;
				document.getElementById('txtadcatname').value=dscatexecute.Tables[0].Rows[z].Cat_Name;
				document.getElementById('txtalias').value = dscatexecute.Tables[0].Rows[z].Cat_Alias;
				if (dscatexecute.Tables[0].Rows[z].SAPECODE != null) {
				    document.getElementById('txtsalesorg').value = dscatexecute.Tables[0].Rows[z].SAPECODE;
				}
				else {
				    document.getElementById('txtsalesorg').value = "";
				}
			
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
	setButtonImages();
	return false;

}


function catexitclick()
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
function catdeleteclick()
{
 var msg=checkSession();
            if(msg==false)
            return false;
        updateStatus();
		   var subcatname=document.getElementById('drpadvcatcode').value;  
			var compcode=document.getElementById('hiddencomcode').value;
			var catcode=document.getElementById('txtadcatcode').value;
			var catname=document.getElementById('txtadcatname').value;
		    var alias=document.getElementById('txtalias').value;
			var userid=document.getElementById('hiddenuserid').value;		
		boolReturn = confirm("Are you sure you wish to delete this?");
				//dan
 var strtextd="";
  var  httpRequest =null;
     httpRequest= new XMLHttpRequest();
     if (httpRequest.overrideMimeType) {
          httpRequest.overrideMimeType('text/xml'); 
          }
          //httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
 
            httpRequest.open( "GET","checksessiondan.aspx", false );
            httpRequest.send('');
            //alert(httpRequest.readyState);
            if (httpRequest.readyState == 4) 
            {
                //alert(httpRequest.status);
                if (httpRequest.status == 200) 
                {
                    strtextd=httpRequest.responseText;
                }
                else 
                {
                    //alert('There was a problem with the request.');
                    if(browser!="Microsoft Internet Explorer")
                    {
                        //alert(xmlObjMessage.childNodes[1].childNodes[21].childNodes[0].nodeValue);
                    }
                }
            }
              if(strtextd!="sess")
       {
       alert('session expired');
           window.location.href="Default.aspx";
           return false;
       } 
		if(boolReturn==1)
		{
		var ip2=document.getElementById('ip1').value;
		AdSubCat5.catdelete(catcode,ip2);
		alert ("Data Deleted Successfully");
		
		document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcatname').value="";
            document.getElementById('txtadcatcode').value="";
            document.getElementById('txtalias').value="";
            document.getElementById('txtsalesorg').value = "";

//AdSubCat5.catdelete(catcode);
		AdSubCat5.catexecute1(compcode, glaobalsubcatname, glaobalcatname, glaobalcatcode, glaobalcatalias,userid,delcall);
		//BgColor.bgexecute2(glaobalbgid,glaobalbgname,glaobalbgalias,delcall);
		//catnextclicktest();
		
		
		}     
//	else
//	{
//	return false;
//	}
	return false;
}
//*******************************************************************************//
//*******************This Is The Responce Of The delete Button*******************//
//*******************************************************************************//

function delcall(res)
{
	 dscatexecute= res.value;
	len=dscatexecute.Tables[0].Rows.length;
	
	if(dscatexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcatname').value="";
            document.getElementById('txtadcatcode').value="";
            document.getElementById('txtalias').value = "";

            document.getElementById('txtsalesorg').value = "";
		catcancelclick('AdSubCat5');
		
		return false;
	}
	else if(z>=len || z==-1)
	{
		document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[0].SUB_CAT_NAME;
			 	document.getElementById('txtadcatcode').value=dscatexecute.Tables[0].Rows[0].CAT_CODE;
				document.getElementById('txtadcatname').value=dscatexecute.Tables[0].Rows[0].CAT_NAME;
				document.getElementById('txtalias').value = dscatexecute.Tables[0].Rows[0].CAT_ALIAS;
				if (dscatexecute.Tables[0].Rows[0].SAPECODE != null) {
				    document.getElementById('txtsalesorg').value = dscatexecute.Tables[0].Rows[0].SAPECODE;
				}
				else {
				    document.getElementById('txtsalesorg').value = "";
				}
			
	}
	else
	{
		       document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[z].SUB_CAT_NAME;
			 	document.getElementById('txtadcatcode').value=dscatexecute.Tables[0].Rows[z].CAT_CODE;
				document.getElementById('txtadcatname').value=dscatexecute.Tables[0].Rows[z].CAT_NAME;
				document.getElementById('txtalias').value = dscatexecute.Tables[0].Rows[z].CAT_ALIAS;
				if (dscatexecute.Tables[0].Rows[z].SAPECODE != null)
				{
				    document.getElementById('txtsalesorg').value = dscatexecute.Tables[0].Rows[z].SAPECODE;
				}
				else {
				    document.getElementById('txtsalesorg').value = "";
				}
			
	}
		if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==(dscatexecute.Tables[0].Rows.length-1))
              {
                 document.getElementById('btnnext').disabled = true;
                 document.getElementById('btnlast').disabled = true;
              }       
	setButtonImages();
return false;
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

/*-----For---Upper Case-------------*/
function uppercase1()
{
document.getElementById('txtadcatcode').value=document.getElementById('txtadcatcode').value.toUpperCase();
return ;
}
		
function uppercase2()
{
document.getElementById('txtalias').value=document.getElementById('txtalias').value.toUpperCase();
return ;
}

//*******************************************************************************//
//**************************This Function For Cancle button**********************//
//*******************************************************************************//


function catcancelclick(formname)
{
           chkstatus(FlagStatus);
           givebuttonpermission(formname);
			document.getElementById('drpadvcatcode').value=0;
            document.getElementById('txtadcatname').value="";
            document.getElementById('txtadcatcode').value="";
            document.getElementById('txtalias').value="";
            document.getElementById('txtsalesorg').value = "";
				document.getElementById('drpadvcatcode').disabled=true;
			document.getElementById('txtadcatcode').disabled=true;
			document.getElementById('txtadcatname').disabled=true;
			document.getElementById('txtsalesorg').disabled = true;
				
				
				
				/*document.getElementById('btnModify').disabled=true;
			    document.getElementById('btnQuery').disabled=false;
			    document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').disabled=true;*/
				if(document.getElementById('btnNew').disable==false)
				  document.getElementById('btnNew').focus();
				
				
			//getPermission(formname);
				mod="0";
				
					
					
					
					
					/*if(document.getElementById('btnNew').disabled==false)
					{
					   
						document.getElementById('btnNew').focus();
					}
						
					else
					{
						document.getElementById('btnNew').disabled=false;
						document.getElementById('btnNew').focus();
						
					}*/
					
				setButtonImages();
				return false;
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

function clearadsub() {
    catcancelclick('AdSubCat5');
    document.getElementById('btnNew').focus();
    givebuttonpermission('AdSubCat5');

}

//function catnextclicktest()
//{
//		AdSubCat5.catfpnl(nextcalltest);

//		        document.getElementById('drpadvcatcode').disabled=true;
//			document.getElementById('txtadcatcode').disabled=true;
//			document.getElementById('txtadcatname').disabled=true;
//			document.getElementById('txtalias').disabled=true;
//		
//		return false;
//}


////*******************************************************************************//
////********************This Is The Responce Of The Next Button*******************//
////*******************************************************************************//
//function nextcalltest(response)
//{
//	//var dszoneexecute=response.value;
//	var a=dscatexecute.Tables[0].Rows.length;
//	znk++;
//	if(znk !=-1 && znk >= 0)
//	{
//		if(znk <= a-1)
//		{
//			
//		       document.getElementById('drpadvcatcode').value=dscatexecute.Tables[0].Rows[znk].Sub_Cat_Name;
//			 	document.getElementById('txtadcatcode').value=dscatexecute.Tables[0].Rows[znk].Cat_Code;
//				document.getElementById('txtadcatname').value=dscatexecute.Tables[0].Rows[znk].Cat_Name;
//				document.getElementById('txtalias').value=dscatexecute.Tables[0].Rows[znk].Cat_Alias;
//			
//		    updateStatus();
//		    
//			document.getElementById('btnnext').disabled=false;
//			document.getElementById('btnlast').disabled=false;
//			document.getElementById('btnfirst').disabled=false;
//			document.getElementById('btnprevious').disabled=false;
//			document.getElementById('btnfirst').disabled=false;
//			document.getElementById('btnprevious').disabled=false;
//			document.getElementById('btnDelete').disabled=false;
//			
//			
//			
//		}
//		else
//	{
//			document.getElementById('btnnext').disabled=true;
//			document.getElementById('btnlast').disabled=true;
//			document.getElementById('btnfirst').disabled=false;
//			document.getElementById('btnprevious').disabled=false;
//			
//			document.getElementById('btnDelete').disabled=false
//	}
//	}
//	else
//	{
//			document.getElementById('btnnext').disabled=true;
//			document.getElementById('btnlast').disabled=true;
//			document.getElementById('btnfirst').disabled=false;
//			document.getElementById('btnprevious').disabled=false;
//		
//			document.getElementById('btnDelete').disabled=false
//	}
//	if(znk==a-1)
//	{
//			document.getElementById('btnnext').disabled=true;
//			document.getElementById('btnlast').disabled=true;
//			document.getElementById('btnfirst').disabled=false;
//			document.getElementById('btnprevious').disabled=false;
//	}
//	return false;
//}
//function down(e)
//{
//alert(e.keyCode)
//return false;
//}

