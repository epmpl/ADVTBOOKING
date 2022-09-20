// JScript File
var hiddentext;
var mod="0";
var z="0";
var znk="0";
var auto="";
var hiddentext1="";
var glaobalbgid;
var glaobalbgname;
var glaobalbgalias;
var glaobalpub;
var glaobaledit;
 var glaobalcat;
 var glaobalcat2;
 var glaobalcat3;
 var glaobalcat4;
 var glaobalcat5;
var glaobalcoltyp;
var dsbgexecute;
var y;
var dsbgdelete;

var chknamemod;

function bgnewclick()
{
            dsbgexecute=null;
            document.getElementById('txtbgid').value="";
            document.getElementById('txtbgname').value="";
            document.getElementById('txtbgalias').value="";
            
            /*new change ankur*/
            document.getElementById('drppub').value="0";
            document.getElementById('drpedition').length="0";
            document.getElementById('drpcat').value="0";
            document.getElementById('drpcat2').length="1";
            document.getElementById('drpcat3').length="1";
            document.getElementById('drpcat4').length="1";
            document.getElementById('drpcat5').length="1";
            document.getElementById('drpcat2').value="0";
            document.getElementById('drpcat3').value="0";
            document.getElementById('drpcat4').value="0";
            document.getElementById('drpcat5').value="0";
            document.getElementById('drpbgamttype').value="0";
            document.getElementById('drpcolortype').value="0";
            document.getElementById('txtbgamt').value="";
            
            document.getElementById('txtbgamt').disabled=false;
            document.getElementById('drpbgamttype').disabled=false;
            document.getElementById('drppub').disabled=false;
            document.getElementById('drpedition').disabled=false;
            document.getElementById('drpcat').disabled=false;
            document.getElementById('drpcat2').disabled=false;
            document.getElementById('drpcat3').disabled=false;
            document.getElementById('drpcat4').disabled=false;
              document.getElementById('drpcat5').disabled=false;
            document.getElementById('drpcolortype').disabled=false;
            
            
            ///////////////////////////////
            
           if(document.getElementById('hiddenauto').value==1)
                {
                   document.getElementById('txtbgid').disabled=true;
                }
           else
              {
                document.getElementById('txtbgid').disabled=false;
               }
              document.getElementById('txtbgname').disabled=false;
              document.getElementById('txtbgalias').disabled=false;
             if(document.getElementById('hiddenauto').value==1)
               {
                        document.getElementById('txtbgname').focus();
               }
             else
              {
                       document.getElementById('txtbgid').focus();
               }
	hiddentext="new";
	chkstatus(FlagStatus);
			
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
		setButtonImages();
				return false;
	}			
function bgsaveclick()
{
    document.getElementById('txtbgid').value=trim(document.getElementById('txtbgid').value);
    document.getElementById('txtbgname').value=trim(document.getElementById('txtbgname').value);
    document.getElementById('txtbgalias').value=trim(document.getElementById('txtbgalias').value);
    var browser=navigator.appName;
    var bc="";
  
//			 if(document.getElementById('hiddenauto').value!=1)
//              {
			     if(document.getElementById('txtbgid').value==""&&(document.getElementById('hiddenauto').value!=1))
			        {
			        alert("Please Fill BgColor Id");
			        document.getElementById('txtbgid').focus();
			        return false;
			        }
			//return false;
			//}
			
			
			else if((document.getElementById('txtbgname').value==""))
			{
			
			    if(browser!="Microsoft Internet Explorer")
                {
                    bc=document.getElementById('lblbgname').textContent;
                }
                else
                {
                    bc=document.getElementById('lblbgname').innerText; 
                } 
                if(bc.indexOf('*')>= 0 )
	            {
	                   
                    alert('Please Enter '+(bc.replace('*', "")));
                    document.getElementById('txtbgname').focus();
                    return false;
	                
	            }
			}
			else if(document.getElementById('txtbgalias').value=="")
			{
			
			    if(browser!="Microsoft Internet Explorer")
                {
                    bc=document.getElementById('lblbgalias').textContent;
                }
                else
                {
                    bc=document.getElementById('lblbgalias').innerText; 
                } 
                if(bc.indexOf('*')>= 0 )
	            {
	                   
                    alert('Please Enter '+(bc.replace('*', "")));
                    document.getElementById('txtbgalias').focus();
                    return false;
	                
	            }
			}
			/*new change ankur*/
			else if(document.getElementById('drppub').value=="0" && document.getElementById('hiddenpubforbg').value=="yes")
			{
			    if(browser!="Microsoft Internet Explorer")
                {
                    bc=document.getElementById('lbppub').textContent;
                }
                else
                {
                    bc=document.getElementById('lbppub').innerText; 
                } 
                if(bc.indexOf('*')>= 0 )
	            {
	                   
                    alert('Please Enter '+(bc.replace('*', "")));
                    document.getElementById('drppub').focus();
                    return false;
	                
	            }
			}
			else if((document.getElementById('drpedition').value=="0" || document.getElementById('drpedition').value=="") && document.getElementById('hiddenpubforbg').value=="yes")
			{
			    if(browser!="Microsoft Internet Explorer")
                {
                    bc=document.getElementById('lbedition').textContent;
                }
                else
                {
                    bc=document.getElementById('lbedition').innerText; 
                } 
                if(bc.indexOf('*')>= 0 )
	            {
	                   
                    alert('Please Enter '+(bc.replace('*', "")));
                    document.getElementById('drpedition').focus();
                    return false;
	                
	            }
			}
			
			else if(document.getElementById('drpcat').value=="0" && document.getElementById('hiddenpubforbg').value=="yes")
			{
			    if(browser!="Microsoft Internet Explorer")
                {
                    bc=document.getElementById('lbcat').textContent;
                }
                else
                {
                    bc=document.getElementById('lbcat').innerText; 
                } 
                if(bc.indexOf('*')>= 0 )
	            {
	                   
                    alert('Please Enter '+(bc.replace('*', "")));
                    document.getElementById('drpcat').focus();
                    return false;
	                
	            }
			}
			
			else if(document.getElementById('drpcolortype').value=="0" && document.getElementById('hiddenpubforbg').value=="yes")
			{
			    if(browser!="Microsoft Internet Explorer")
                {
                    bc=document.getElementById('lbcolortype').textContent;
                }
                else
                {
                    bc=document.getElementById('lbcolortype').innerText; 
                } 
                if(bc.indexOf('*')>= 0 )
	            {
	                   
                    alert('Please Enter '+(bc.replace('*', "")));
                    document.getElementById('drpcolortype').focus();
                    return false;
	                
	            }
			}
			 if((document.getElementById('drpbgamttype').value=="0" && document.getElementById('txtbgamt').value!="") ||(document.getElementById('drpbgamttype').value!="0" && document.getElementById('txtbgamt').value==""))
			{          
                    alert("Please Enter BgAmount");
                    //document.getElementById('txtbgamt').focus();
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

			////////////////////////////////////////////////////
              
			var companycode=document.getElementById('hiddencomcode').value;
			var bgid=trim(document.getElementById('txtbgid').value);
			var bgname=document.getElementById('txtbgname').value;
			bgname=trim(bgname);
						
			var bgalias=trim(document.getElementById('txtbgalias').value);
			var UserId=document.getElementById('hiddenuserid').value;	
			
			 /*new change ankur*/
            var pub=document.getElementById('drppub').value;
            var edit=document.getElementById('drpedition').value;
            var cat=document.getElementById('drpcat').value;
//            var cat2=document.getElementById('drpcat2').value;
//            var cat3=document.getElementById('drpcat3').value;
//            var cat4=document.getElementById('drpcat4').value;
//            var cat5=document.getElementById('drpcat5').value;
            var coltyp=document.getElementById('drpcolortype').value;
            
          
            
            
            ///////////////////////////////		

			if(mod !="1" && mod !=null)
			{
			//alert(BgColor);
			/*new change ankur*/
		     BgColor.chkbgid(bgid,pub,edit,cat,coltyp,bgname,call_saveclick);
			}
			else
			{
			
	/*new change ankur*/
		var str=trim(document.getElementById('txtbgname').value);
	        var pub=document.getElementById('drppub').value;
            var edit=document.getElementById('drpedition').value;
            var cat=document.getElementById('drpcat').value;
            var coltyp=document.getElementById('drpcolortype').value;
		    
		    if(chknamemod!=document.getElementById('txtbgname').value)
            {
		        BgColor.bgdauto(str,pub,edit,cat,coltyp,call_modify);
		    }
		    else
		    {
		        updatebg();
		    }
		}
		    
			return false;
}

function call_modify(response)
{
        var ds=response.value;
        
    	    if(document.getElementById('hiddenpubforbg').value=="yes" && ds.Tables[2].Rows.length > 0)
		    {
		        alert("Bg name,Publication,Edition,Category and colortype should be unique ");
		        return false;
		    }
		
	        if(ds.Tables[2].Rows.length !=0 && document.getElementById('hiddenpubforbg').value!="yes")
	        {
	        alert("This Bg Name has already assigned !! ");
		    
//		         document.getElementById('txtbgid').value="";
//				document.getElementById('txtbgname').value="";	
//				document.getElementById('txtbgalias').value="";
			
	        return false;
	        }
	        updatebg();
		    
}
function updatebg()
{	    
		    var companycode=document.getElementById('hiddencomcode').value;
			var bgid=trim(document.getElementById('txtbgid').value);
			var bgname=document.getElementById('txtbgname').value;
			bgname=trim(bgname);
						
			var bgalias=trim(document.getElementById('txtbgalias').value);
		
			
			 /*new change ankur*/
            var pub=document.getElementById('drppub').value;
            var edit=document.getElementById('drpedition').value;
            var cat=document.getElementById('drpcat').value;
            var cat2=document.getElementById('drpcat2').value;
            var cat3=document.getElementById('drpcat3').value;
            var cat4=document.getElementById('drpcat4').value;
            var cat5=document.getElementById('drpcat5').value;
            var coltyp=document.getElementById('drpcolortype').value;
            var ip2=document.getElementById('ip1').value;
             var bgtype=document.getElementById('drpbgamttype').value;
            var bgamt=document.getElementById('txtbgamt').value;
		    BgColor.bgmodify(bgid,bgname,bgalias,pub,edit,cat,cat2,cat3,cat4,cat5,coltyp,ip2,companycode,bgtype,bgamt);
		    
		    dsbgexecute.Tables[0].Rows[z].BG_TYPE=document.getElementById('drpbgamttype').value;
		    dsbgexecute.Tables[0].Rows[z].BG_AMT=document.getElementById('txtbgamt').value;  
            dsbgexecute.Tables[0].Rows[z].bgid=document.getElementById('txtbgid').value;
		    dsbgexecute.Tables[0].Rows[z].bgname=document.getElementById('txtbgname').value;
			dsbgexecute.Tables[0].Rows[z].bgalias=document.getElementById('txtbgalias').value;
			
			dsbgexecute.Tables[0].Rows[z].Publication=document.getElementById('drppub').value;
		    dsbgexecute.Tables[0].Rows[z].Edition=document.getElementById('drpedition').value;
			dsbgexecute.Tables[0].Rows[z].Category=document.getElementById('drpcat').value;
			dsbgexecute.Tables[0].Rows[z].Category2=document.getElementById('drpcat2').value;
			dsbgexecute.Tables[0].Rows[z].Category3=document.getElementById('drpcat3').value;
			dsbgexecute.Tables[0].Rows[z].Category4=document.getElementById('drpcat4').value;
			dsbgexecute.Tables[0].Rows[z].Category5=document.getElementById('drpcat5').value;
            dsbgexecute.Tables[0].Rows[z].Colortype=document.getElementById('drpcolortype').value;

			alert("Data Modified Successfully");
            
            document.getElementById('drpbgamttype').disabled=true;
            document.getElementById('txtbgamt').disabled=true;
			document.getElementById('txtbgid').disabled=true;
			document.getElementById('txtbgname').disabled=true;
			document.getElementById('txtbgalias').disabled=true;
			
			 /*new change ankur*/
            document.getElementById('drppub').disabled=true;
            document.getElementById('drpedition').disabled=true;
            document.getElementById('drpcat').disabled=true;
            document.getElementById('drpcolortype').disabled=true;
             document.getElementById('drpcat2').disabled=true;
            document.getElementById('drpcat3').disabled=true;
             document.getElementById('drpcat4').disabled=true;
             document.getElementById('drpcat5').disabled=true;
            ///////////////////////////////	
			
			
			document.getElementById('btnSave').disabled=true;
			
		    
			updateStatus();
			mod="0";
			if (z==0)
            {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
            }

             if(z==(dsbgexecute.Tables[0].Rows.length-1))
              {
                document.getElementById('btnNext').disabled=true;
	            document.getElementById('btnLast').disabled=true;
              } 
		
		setButtonImages();
		    return false;
}
			
 	
function call_saveclick(response)
{
			var ds=response.value;
			
			if(document.getElementById('hiddenpubforbg').value=="yes" && ds.Tables[1].Rows.length > 0)
			{
			    alert("Bg name,Publication,Edition,Category and colortype should be unique ");
			    return false;
			}
			
			if(ds.Tables[0].Rows.length > 0)
			{
			alert("This BgColor Id Is Already Exist, Try Another Code !!!!");
			
			    document.getElementById('txtbgid').value="";
//				document.getElementById('txtbgname').value="";	
//				document.getElementById('txtbgalias').value="";
			
			
			return false;
			} 
			else if(ds.Tables[1].Rows.length > 0)
			{
			    alert("This BgColor Name Is Already Exist, Try Another Code !!!!");
			    //document.getElementById('txtbgid').value="";
				document.getElementById('txtbgname').value="";	
				document.getElementById('txtbgalias').value="";
			    return false;
			} 
			else
			{
				var companycode=document.getElementById('hiddencomcode').value;
				var bgid=document.getElementById('txtbgid').value;
				var bgname=document.getElementById('txtbgname').value;
				var bgalias=document.getElementById('txtbgalias').value;
				var UserId=document.getElementById('hiddenuserid').value;	
				
				
				 /*new change ankur*/
            var pub=document.getElementById('drppub').value;
            var edit=document.getElementById('drpedition').value;
            var cat=document.getElementById('drpcat').value;
            var cat2=document.getElementById('drpcat2').value;
            var cat3=document.getElementById('drpcat3').value;
            var cat4=document.getElementById('drpcat4').value;
            var cat5=document.getElementById('drpcat5').value;
            var coltyp=document.getElementById('drpcolortype').value;
            var bgtype=document.getElementById('drpbgamttype').value;
            var bgamt=document.getElementById('txtbgamt').value;
            
          
            
            
            ///////////////////////////////			

				/*new change ankur*/
				var ip2=document.getElementById('ip1').value;
				BgColor.bgSave(bgid,bgname,bgalias,pub,edit,cat,cat2,cat3,cat4,cat5,coltyp,ip2,companycode,bgtype,bgamt);		

				alert("Data Saved Successfully");
				

                document.getElementById('txtbgamt').value="";
                document.getElementById('drpbgamttype').value="0";
				document.getElementById('txtbgid').value="";
				document.getElementById('txtbgname').value="";
				document.getElementById('txtbgalias').value="";
				
				document.getElementById('txtbgamt').disabled=true;
				document.getElementById('drpbgamttype').disabled=true;		
				document.getElementById('txtbgid').disabled=true;
				document.getElementById('txtbgname').disabled=true;
				document.getElementById('txtbgalias').disabled=true;
				
				
				 /*new change ankur*/
            var pub=document.getElementById('drppub').value="0";
            var edit=document.getElementById('drpedition').value="0";
            var cat=document.getElementById('drpcat').value="0";
           // var cat2=document.getElementById('drpcat2').value="0";
           
            var coltyp=document.getElementById('drpcolortype').value="0";
            
          var pub=document.getElementById('drppub').disabled=true;
            var edit=document.getElementById('drpedition').disabled=true;
            var cat=document.getElementById('drpcat').disabled=true;
           //  var cat2=document.getElementById('drpcat2').disabled=true;
            var coltyp=document.getElementById('drpcolortype').disabled=true;
            
            
            ///////////////////////////////	
								
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
			bgcancelclick('BgColor');
			return false;
}


/*********************************************Auto Generate***********************/
function autoornot()
 {
 
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
//return false;
}

// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
if(hiddentext=="new" )

  //if(document.getElementById('hiddenauto').value==1)
			{
	
            document.getElementById('txtbgname').value=trim(document.getElementById('txtbgname').value);
		lstr=document.getElementById('txtbgname').value;
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
		
		    if(document.getElementById('txtbgname').value!="")
                {

		document.getElementById('txtbgname').value=document.getElementById('txtbgname').value.toUpperCase();
	    document.getElementById('txtbgalias').value=document.getElementById('txtbgname').value;
	    var pub=document.getElementById('drppub').value;
            var edit=document.getElementById('drpedition').value;
            var cat=document.getElementById('drpcat').value;
            var coltyp=document.getElementById('drpcolortype').value;
            
		// str=document.getElementById('txtzonename').value;
		str=mstr;
		BgColor.bgdauto(str,pub,edit,cat,coltyp,fillcall);
		//return false;
                }
		       
               
       //return false;
           
           }
            else
            {
            document.getElementById('txtbgname').value=document.getElementById('txtbgname').value.toUpperCase();
            }
            //document.getElementById('btnSave').disabled=true;
            //document.getElementById('btnModify').disabled=true;
           // BgColor.bgdauto(fillcall);
              return false;

}


//auto generated
//this is used for increment in code

/*function uppercase3()
		{
		document.getElementById('txtbgname').value=trim(document.getElementById('txtbgname').value);
		lstr=document.getElementById('txtbgname').value;
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
		
		    if(document.getElementById('txtbgname').value!="")
                {

		document.getElementById('txtbgname').value=document.getElementById('txtbgname').value.toUpperCase();
	    document.getElementById('txtbgalias').value=document.getElementById('txtbgname').value;
	    var pub=document.getElementById('drppub').value;
            var edit=document.getElementById('drpedition').value;
            var cat=document.getElementById('drpcat').value;
            var coltyp=document.getElementById('drpcolortype').value;
            
		// str=document.getElementById('txtzonename').value;
		str=mstr;
		BgColor.bgdauto(str,pub,edit,cat,coltyp,fillcall);
		return false;
                }
		       
               
 return false;
		
}*/

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		/*new change ankur 9 feb*/
//			if(document.getElementById('hiddenpubforbg').value=="yes" && ds.Tables[0].Rows.length > 0)
//			{
//			    alert("Bg name,Publication,Edition,Category and colortype should be unique ");
//			    return false;
//			}
		
		    if(ds.Tables[2].Rows.length !=0 && document.getElementById('hiddenpubforbg').value!="yes")
		    {
		    alert("This Bg Name has already assigned !! ");
		    
		         document.getElementById('txtbgid').value="";
				document.getElementById('txtbgname').value="";	
				document.getElementById('txtbgalias').value="";
			    document.getElementById('txtbgname').focus();
		  
    		
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
		                         newstr=ds.Tables[1].Rows[0].bgid;
		                        }
		                        if(newstr==0)
		                        {
		                            document.getElementById('txtbgid').value=str.substr(0,2)+ "1";
		                        }
		                        else if(newstr>=1)
		                        {
		                        var Autoincrement=parseInt(ds.Tables[1].Rows[0].bgid)+1;
		                            document.getElementById('txtbgid').value=str.substr(0,2)+ Autoincrement;
		                        }
		                        
		                    else if(newstr !=null )
		                        {
		                        document.getElementById('txtbgname').value=trim(document.getElementById('txtbgname').value);
		                        var code=newstr.substr(2,4);
		                       var code=newstr;
		                        code++;
		                        str=str.toUpperCase();
		                        document.getElementById('txtbgid').value=str.substr(0,2)+ code;
		                       // document.getElementById('txtbillid').value=str.substr(1,3)+ code;
		                         }
		                         
		                    else
		                         {
		                         str=str.toUpperCase();
		                          document.getElementById('txtbgid').value=str.substr(0,2)+ "0";
		                          //document.getElementById('txtbillid').value=str.substr(0,2)+ "00";
		                          }
		                          }
		     }
	//return false;
		}
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtbgid').disabled=false;
        document.getElementById('txtbgname').value=document.getElementById('txtbgname').value.toUpperCase();
        document.getElementById('txtbgalias').value=document.getElementById('txtbgname').value;
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
    document.getElementById('txtbgname').value=trim(document.getElementById('txtbgname').value);
     }

//*******************************************************************************//
//**************************This Function For Modify Button**********************//
//*******************************************************************************//
function bgmodifyclick()
{
               // document.getElementById('btnModify').disabled=true;
				document.getElementById('txtbgid').disabled=true;
				document.getElementById('txtbgname').disabled=false;
				document.getElementById('txtbgalias').disabled=false;
				
				document.getElementById('txtbgname').focus();
				 /*new change ankur*/
        
            
            var pub=document.getElementById('drppub').disabled=false;
            var edit=document.getElementById('drpedition').disabled=false;
            var cat=document.getElementById('drpcat').disabled=false;
            var cat2=document.getElementById('drpcat2').disabled=false;
            var cat3=document.getElementById('drpcat3').disabled=false;
            var cat4=document.getElementById('drpcat4').disabled=false;
            var cat5=document.getElementById('drpcat5').disabled=false;
            var coltyp=document.getElementById('drpcolortype').disabled=false;
            
            document.getElementById('drpbgamttype').disabled=false;
            document.getElementById('txtbgamt').disabled=false;
            
            chknamemod=	trim(document.getElementById('txtbgname').value);
            ///////////////////////////////	
					
				
				chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnModify').disabled=true;
				
			
				   mod="1";
				 hiddentext="mod";	
				setButtonImages();
				return false;
}
//*******************************************************************************//
//*************************This Function For Query Button***********************//
//*******************************************************************************//

function bgqueryclick()
{
        dsbgexecute=null;
        hiddentext="query";
				document.getElementById('txtbgid').value="";
				document.getElementById('txtbgname').value="";	
				document.getElementById('txtbgalias').value="";
				document.getElementById('drpbgamttype').value="0";
				document.getElementById('txtbgamt').value="";
				
				/*new change ankur*/
				    var pub=document.getElementById('drppub').value="0";
            var edit=document.getElementById('drpedition').value="0";
            var cat=document.getElementById('drpcat').value="0";
            var cat2=document.getElementById('drpcat2').value="0";
            var cat3=document.getElementById('drpcat3').value="0";
            var cat4=document.getElementById('drpcat4').value="0";
            var cat5=document.getElementById('drpcat5').value="0";
            var coltyp=document.getElementById('drpcolortype').value="0";
            
//            var pub=document.getElementById('drppub').disabled=true;
//            var edit=document.getElementById('drpedition').disabled=true;
//            var cat=document.getElementById('drpcat').disabled=true;
//            var cat2=document.getElementById('drpcat2').disabled=true;
//            var cat3=document.getElementById('drpcat3').disabled=true;
//            var cat4=document.getElementById('drpcat4').disabled=true;
//            var cat5=document.getElementById('drpcat5').disabled=true;
            
            var coltyp=document.getElementById('drpcolortype').disabled=true;
            
            ///////////////////////////////////////////////////////////////
				
				z=0;
				document.getElementById('txtbgamt').disabled=true;
				document.getElementById('drpbgamttype').disabled=true;
				document.getElementById('txtbgid').disabled=false;
				document.getElementById('txtbgname').disabled=false;
				document.getElementById('txtbgalias').disabled=false;
				
				document.getElementById('drppub').disabled=true;
				document.getElementById('drpedition').disabled=true;
				document.getElementById('drpcat').disabled=true;
				document.getElementById('drpcat2').disabled=true;
                document.getElementById('drpcat3').disabled=true;
                document.getElementById('drpcat4').disabled=true;
                document.getElementById('drpcat5').disabled=true;
				document.getElementById('drpcolortype').disabled=true;
				
				chkstatus(FlagStatus);
					
	document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
//	document.getElementById('txtbgname').focus();
	document.getElementById('btnExecute').focus();
	
				hiddentext="query";
					setButtonImages();					
				//document.getElementById('btnExecute').focus();
				return false;
}
//*******************************************************************************//
//**********************This Function For Execute Button*************************//
//*******************************************************************************//

function bgexecuteclick()
{


               z=0;
			var companycode=document.getElementById('hiddencomcode').value;
			var bgid=document.getElementById('txtbgid').value;
			glaobalbgid=bgid;
			var bgname=document.getElementById('txtbgname').value;
			glaobalbgname=bgname;
			var bgalias=document.getElementById('txtbgalias').value;
			glaobalbgalias=bgalias;
			
			var pub=document.getElementById('drppub').value;
			glaobalpub=pub;
            var edit=document.getElementById('drpedition').value;
            glaobaledit=edit;
            var cat=document.getElementById('drpcat').value;
            glaobalcat=cat;
//            var cat2=document.getElementById('drpcat2').value;
//            glaobalcat2=cat2;
//            var cat3=document.getElementById('drpcat3').value;
//            glaobalcat3=cat3;
//            var cat4=document.getElementById('drpcat4').value;
//            glaobalcat4=cat4;
//            var cat5=document.getElementById('drpcat5').value;
//            glaobalca5t=cat5;
            var coltyp=document.getElementById('drpcolortype').value;
			glaobalcoltyp=coltyp;
			var UserId=document.getElementById('hiddenuserid').value;			

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
BgColor.bgexecute1(bgid,bgname,bgalias,companycode,checkcall);		
			updateStatus();
			document.getElementById('txtbgid').disabled=true;
			document.getElementById('txtbgname').disabled=true;
			document.getElementById('txtbgalias').disabled=true;
			
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
			dsbgexecute=response.value;
			if(dsbgexecute == null)
			{
			    alert(response.error.description);
			    return false;
			}
			if(dsbgexecute.Tables[0].Rows.length > 0)
			{   
			    if(dsbgexecute.Tables[0].Rows[0].BG_TYPE==null || dsbgexecute.Tables[0].Rows[0].BG_TYPE=="")
			    {
			    document.getElementById('drpbgamttype').value="0";
			    }
			    else
			    {
			    document.getElementById('drpbgamttype').value=dsbgexecute.Tables[0].Rows[0].BG_TYPE;
			    }
			    if(dsbgexecute.Tables[0].Rows[0].BG_AMT==null)
			    {
			    document.getElementById('txtbgamt').value="";
			    }
			    else
			    {
			    document.getElementById('txtbgamt').value=dsbgexecute.Tables[0].Rows[0].BG_AMT;
			    }
			 	document.getElementById('txtbgid').value=dsbgexecute.Tables[0].Rows[0].bgid;
				document.getElementById('txtbgname').value=dsbgexecute.Tables[0].Rows[0].bgname;
				document.getElementById('txtbgalias').value=dsbgexecute.Tables[0].Rows[0].bgalias;
				
					/*new change ankur*/
				    document.getElementById('drppub').value=dsbgexecute.Tables[0].Rows[0].Publication;
                    filledit();				    
			document.getElementById('drpedition').value=dsbgexecute.Tables[0].Rows[0].Edition;
            
            document.getElementById('drpcat').value=dsbgexecute.Tables[0].Rows[0].Category;
            
            fillAdCat2();
           // BgColor.fillCat2(document.getElementById('drpcat').value,fillCat2_callback);
            
            
            //BgColor.fillCat3(document.getElementById('drpcat2').value,fillCat3_callback);
       //     document.getElementById('drpcat3').value=dsbgexecute.Tables[0].Rows[0].Category3;
//            
//            document.getElementById('drpcat4').value=dsbgexecute.Tables[0].Rows[0].Category4;
//            document.getElementById('drpcat5').value=dsbgexecute.Tables[0].Rows[0].Category5;
           
            document.getElementById('drpcolortype').value=dsbgexecute.Tables[0].Rows[0].Colortype;
            
            document.getElementById('txtbgamt').disabled=true;
            document.getElementById('drpbgamttype').disabled=true;
            document.getElementById('drppub').disabled=true;
            document.getElementById('drpedition').disabled=true;
            document.getElementById('drpcat').disabled=true;
            document.getElementById('drpcat2').disabled=true;
            document.getElementById('drpcat3').disabled=true;
            document.getElementById('drpcat4').disabled=true;
            document.getElementById('drpcat5').disabled=true;
            document.getElementById('drpcolortype').disabled=true;
            
            ///////////////////////////////////////////////////////////////
					
				document.getElementById('txtbgid').disabled=true;
				document.getElementById('txtbgname').disabled=true;
				document.getElementById('txtbgalias').disabled=true;
						
			}
			
			else
			{
				alert("Your Search Produce No Result!!!!");
			bgcancelclick('BgColor');
			    return false;
			}

            if(dsbgexecute.Tables[0].Rows.length ==1)
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
//*******************************************************************************//
/*function bgfirstclick()
{

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
BgColor.bgfpnl(firstcall);
						
			document.getElementById('txtbgid').disabled=true;
		    document.getElementById('txtbgname').disabled=true;
			document.getElementById('txtbgalias').disabled=true;
			
			document.getElementById('btnprevious').disabled=true;	
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnnext').disabled=false;
			
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnExit').disabled=false;
			
			return false;
}*/
//*******************************************************************************//
//********************This Is The Responce Of The First Button*******************//
//*******************************************************************************//	
function bgfirstclick()
{
			//var dszoneexecute=response.value;
	           //var a=dsbgexecute.Tables[0].Rows.length;
	           if(dsbgexecute.Tables[0].Rows[0].BG_TYPE==null || dsbgexecute.Tables[0].Rows[0].BG_TYPE=="")
	           {
	           document.getElementById('drpbgamttype').value="0";
	           }
	           else
	           {
	            document.getElementById('drpbgamttype').value=dsbgexecute.Tables[0].Rows[0].BG_TYPE;
	            }
	            if(dsbgexecute.Tables[0].Rows[0].BG_AMT==null)
	            {
	            document.getElementById('txtbgamt').value="";
	            }
	            else
	            {
			    document.getElementById('txtbgamt').value=dsbgexecute.Tables[0].Rows[0].BG_AMT;
			    }
			    document.getElementById('txtbgid').value=dsbgexecute.Tables[0].Rows[0].bgid;
				document.getElementById('txtbgname').value=dsbgexecute.Tables[0].Rows[0].bgname;
				document.getElementById('txtbgalias').value=dsbgexecute.Tables[0].Rows[0].bgalias;
					/*new change ankur*/
				    document.getElementById('drppub').value=dsbgexecute.Tables[0].Rows[0].Publication;
                    filledit();				    
				    document.getElementById('drpedition').value=dsbgexecute.Tables[0].Rows[0].Edition;
            document.getElementById('drpcat').value=dsbgexecute.Tables[0].Rows[0].Category;
            fillAdCat2();
            document.getElementById('drpcolortype').value=dsbgexecute.Tables[0].Rows[0].Colortype;
            
            document.getElementById('drppub').disabled=true;
            document.getElementById('drpedition').disabled=true;
            document.getElementById('drpcat').disabled=true;
            document.getElementById('drpcat2').disabled=true;
            document.getElementById('drpcat3').disabled=true;
            document.getElementById('drpcat4').disabled=true;
            document.getElementById('drpcat5').disabled=true;
            document.getElementById('drpcolortype').disabled=true;
            
            ///////////////////////////////////////////////////////////////
				
			z=0;
			updateStatus();

		    document.getElementById('btnCancel').disabled=false;
            document.getElementById('btnfirst').disabled=true;
            document.getElementById('btnnext').disabled=false;
            document.getElementById('btnprevious').disabled=true;
            document.getElementById('btnlast').disabled=false;
            document.getElementById('btnExit').disabled=false;
            setButtonImages();
            if(document.getElementById('btnModify').disabled==false)
		       document.getElementById('btnModify').focus();
			return false;
}
//*******************************************************************************//
//*************************This Function For Last Button*************************//
//*******************************************************************************//

/*function bglastclick()
{
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
BgColor.bgfpnl(lastcall);

			   document.getElementById('txtbgid').disabled=true;
				document.getElementById('txtbgname').disabled=true;
				document.getElementById('txtbgalias').disabled=true;
						
			return false;
}*/

//*******************************************************************************//
//********************This Is The Responce Of The last Button*******************//
//*******************************************************************************//
function bglastclick()
{
			//var dszoneexecute=response.value;
			var y=dsbgexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;
			
			if(dsbgexecute.Tables[0].Rows[z].BG_TYPE==null || dsbgexecute.Tables[0].Rows[z].BG_TYPE=="")
			{
			     document.getElementById('drpbgamttype').value="0";
			}
			else
			{
			 document.getElementById('drpbgamttype').value=dsbgexecute.Tables[0].Rows[z].BG_TYPE;
			}
			if(dsbgexecute.Tables[0].Rows[z].BG_AMT==null)
			{
			document.getElementById('txtbgamt').value="";
			}
			else
			{
			   document.getElementById('txtbgamt').value=dsbgexecute.Tables[0].Rows[z].BG_AMT;
			}
			    document.getElementById('txtbgid').value=dsbgexecute.Tables[0].Rows[z].bgid;
				document.getElementById('txtbgname').value=dsbgexecute.Tables[0].Rows[z].bgname;
				document.getElementById('txtbgalias').value=dsbgexecute.Tables[0].Rows[z].bgalias;
				
				
				
					/*new change ankur*/
				    document.getElementById('drppub').value=dsbgexecute.Tables[0].Rows[z].Publication;
                    filledit();				    
				    document.getElementById('drpedition').value=dsbgexecute.Tables[0].Rows[z].Edition;
            document.getElementById('drpcat').value=dsbgexecute.Tables[0].Rows[z].Category;
            fillAdCat2();
            document.getElementById('drpcolortype').value=dsbgexecute.Tables[0].Rows[z].Colortype;
            
            document.getElementById('drpbgamttype').disabled=true;
            document.getElementById('txtbgamt').disabled=true;
            document.getElementById('drppub').disabled=true;
            document.getElementById('drpedition').disabled=true;
            document.getElementById('drpcat').disabled=true;
            document.getElementById('drpcat2').disabled=true;
            document.getElementById('drpcat3').disabled=true;
            document.getElementById('drpcat4').disabled=true;
            document.getElementById('drpcat5').disabled=true;
            document.getElementById('drpcolortype').disabled=true;
            
            ///////////////////////////////////////////////////////////////
				
			updateStatus();
			
		        document.getElementById('btnnext').disabled=true;
		        document.getElementById('btnlast').disabled=true;
		        document.getElementById('btnfirst').disabled=false;
		        document.getElementById('btnprevious').disabled=false;
		        setButtonImages();
		        if(document.getElementById('btnModify').disabled==false)
		        document.getElementById('btnModify').focus();
			return false;
}


//*******************************************************************************//
//***********************This Function For Previous Button***********************//
//*******************************************************************************//


/*function bgpreviousclick()
{			
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
BgColor.bgfpnl(previouscall);

			    document.getElementById('txtbgid').disabled=true;
				document.getElementById('txtbgname').disabled=true;
				document.getElementById('txtbgalias').disabled=true;
			return false;
}*/
//*******************************************************************************//
//********************This Is The Responce Of The Previous Button****************//
//*******************************************************************************//
function bgpreviousclick()
{
		//var dszoneexecute=response.value;
		var a=dsbgexecute.Tables[0].Rows.length;
		z--;
		if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{   
			if(dsbgexecute.Tables[0].Rows[z].BG_TYPE==null || dsbgexecute.Tables[0].Rows[z].BG_TYPE=="")
			{
			    document.getElementById('drpbgamttype').value="0";
			}
			else
			{
			   document.getElementById('drpbgamttype').value=dsbgexecute.Tables[0].Rows[z].BG_TYPE;
			}
			if(dsbgexecute.Tables[0].Rows[z].BG_AMT==null)
			{
			    document.getElementById('txtbgamt').value="";
			}
			else
			{
			  document.getElementById('txtbgamt').value=dsbgexecute.Tables[0].Rows[z].BG_AMT;
			}
				 document.getElementById('txtbgid').value=dsbgexecute.Tables[0].Rows[z].bgid;
				document.getElementById('txtbgname').value=dsbgexecute.Tables[0].Rows[z].bgname;
				document.getElementById('txtbgalias').value=dsbgexecute.Tables[0].Rows[z].bgalias;
				
					/*new change ankur*/
				    document.getElementById('drppub').value=dsbgexecute.Tables[0].Rows[z].Publication;
                    filledit();				    
				    document.getElementById('drpedition').value=dsbgexecute.Tables[0].Rows[z].Edition;
            document.getElementById('drpcat').value=dsbgexecute.Tables[0].Rows[z].Category;
            fillAdCat2();
            document.getElementById('drpcolortype').value=dsbgexecute.Tables[0].Rows[z].Colortype;
            
            document.getElementById('drppub').disabled=true;
            document.getElementById('drpedition').disabled=true;
            document.getElementById('drpcat').disabled=true;
            document.getElementById('drpcat2').disabled=true;
            document.getElementById('drpcat3').disabled=true;
            document.getElementById('drpcat4').disabled=true;
            document.getElementById('drpcat5').disabled=true;
            document.getElementById('drpcolortype').disabled=true;
            
            ///////////////////////////////////////////////////////////////
				
			updateStatus();
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

/*function bgnextclick()
{
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
BgColor.bgfpnl(nextcall);

		        document.getElementById('txtbgid').disabled=true;
				document.getElementById('txtbgname').disabled=true;
				document.getElementById('txtbgalias').disabled=true;
		
		return false;
}*/


//*******************************************************************************//
//********************This Is The Responce Of The Next Button*******************//
//*******************************************************************************//
function bgnextclick()
{
	//var dszoneexecute=response.value;
	var a=dsbgexecute.Tables[0].Rows.length;
	z++;
	updateStatus();
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
		    if(dsbgexecute.Tables[0].Rows[z].BG_TYPE==null || dsbgexecute.Tables[0].Rows[z].BG_TYPE=="")
		    {
		        document.getElementById('drpbgamttype').value="0";
		    }
		    else
		    {
		        document.getElementById('drpbgamttype').value=dsbgexecute.Tables[0].Rows[z].BG_TYPE;
		    }
		    if(dsbgexecute.Tables[0].Rows[z].BG_AMT==null)
		    {
			   document.getElementById('txtbgamt').value="";
			}
			else
			{
			    document.getElementById('txtbgamt').value=dsbgexecute.Tables[0].Rows[z].BG_AMT;
			}
			document.getElementById('txtbgid').value=dsbgexecute.Tables[0].Rows[z].bgid;
				document.getElementById('txtbgname').value=dsbgexecute.Tables[0].Rows[z].bgname;
				document.getElementById('txtbgalias').value=dsbgexecute.Tables[0].Rows[z].bgalias;
				
				
					/*new change ankur*/
				    document.getElementById('drppub').value=dsbgexecute.Tables[0].Rows[z].Publication;
                    filledit();				    
				    document.getElementById('drpedition').value=dsbgexecute.Tables[0].Rows[z].Edition;
            document.getElementById('drpcat').value=dsbgexecute.Tables[0].Rows[z].Category;
            fillAdCat2();
            document.getElementById('drpcolortype').value=dsbgexecute.Tables[0].Rows[z].Colortype;
            
            document.getElementById('txtbgamt').disabled=true;
            document.getElementById('drpbgamttype').disabled=true;
            document.getElementById('drppub').disabled=true;
            document.getElementById('drpedition').disabled=true;
            document.getElementById('drpcat').disabled=true;
            document.getElementById('drpcat2').disabled=true;
            document.getElementById('drpcat3').disabled=true;
            document.getElementById('drpcat4').disabled=true;
            document.getElementById('drpcat5').disabled=true;
            document.getElementById('drpcolortype').disabled=true;
            
            ///////////////////////////////////////////////////////////////
				
			
		    
		    
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
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
	        setButtonImages();
	return false;

}

function bgexitclick()
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
function bgdeleteclick()
{

        updateStatus();
		var companycode=document.getElementById('hiddencomcode').value;
		var bgid=document.getElementById('txtbgid').value;
		var bgname=document.getElementById('txtbgname').value;
		var bgalias=document.getElementById('txtbgalias').value;
		var UserId=document.getElementById('hiddenuserid').value;			
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
		alert ("Data Deleted Successfully");
		
//		document.getElementById('txtbgid').value="";
//		document.getElementById('txtbgname').value="";	
//		document.getElementById('txtbgalias').value="";
		
var ip2=document.getElementById('ip1').value;		
BgColor.bgdelete(bgid,ip2);
	 BgColor.bgexecute1(glaobalbgid,glaobalbgname,glaobalbgalias,companycode,delcall);
		//bgnextclicktest();
		
		
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
	 dsbgexecute= res.value;
	len=dsbgexecute.Tables[0].Rows.length;
	
	if(dsbgexecute.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		document.getElementById('txtbgid').value="";
		document.getElementById('txtbgname').value="";	
		document.getElementById('txtbgalias').value="";
		
		
		
		bgcancelclick('BgColor');
		
		return false;
	}
	else if(z>=len || z==-1)
	{
	        if(dsbgexecute.Tables[0].Rows[0].BG_TYPE==null || dsbgexecute.Tables[0].Rows[0].BG_TYPE=="")
	        {
	        document.getElementById('drpbgamttype').value="0";
	        }
	        else
	        {
	        document.getElementById('drpbgamttype').value=dsbgexecute.Tables[0].Rows[0].BG_TYPE;
	        }
	        if(dsbgexecute.Tables[0].Rows[0].BG_AMT==null)
	        {
	        document.getElementById('txtbgamt').value="";
	        }
	        else
	        {
			    document.getElementById('txtbgamt').value=dsbgexecute.Tables[0].Rows[0].BG_AMT;
			}
		document.getElementById('txtbgid').value=dsbgexecute.Tables[0].Rows[0].bgid;
				document.getElementById('txtbgname').value=dsbgexecute.Tables[0].Rows[0].bgname;
				document.getElementById('txtbgalias').value=dsbgexecute.Tables[0].Rows[0].bgalias;
				
				
				
					/*new change ankur*/
				    document.getElementById('drppub').value=dsbgexecute.Tables[0].Rows[0].Publication;
                    filledit();				    
				    document.getElementById('drpedition').value=dsbgexecute.Tables[0].Rows[0].Edition;
            document.getElementById('drpcat').value=dsbgexecute.Tables[0].Rows[0].Category;
            document.getElementById('drpcolortype').value=dsbgexecute.Tables[0].Rows[0].Colortype;
            
            document.getElementById('drpbgamttype').disabled=true;
            document.getElementById('txtbgamt').disabled=true;
            document.getElementById('drppub').disabled=true;
            document.getElementById('drpedition').disabled=true;
            document.getElementById('drpcat').disabled=true;
            document.getElementById('drpcolortype').disabled=true;
            
            ///////////////////////////////////////////////////////////////
	}
	else
	{
	            if(dsbgexecute.Tables[0].Rows[z].BG_TYPE==null || dsbgexecute.Tables[0].Rows[z].BG_TYPE=="")
	            {
	            document.getElementById('drpbgamttype').value="0";
	            }
	            else
	            {
	            document.getElementById('drpbgamttype').value=dsbgexecute.Tables[0].Rows[z].BG_TYPE;
	            }
	            if(dsbgexecute.Tables[0].Rows[z].BG_AMT==null)
	            {
	            document.getElementById('txtbgamt').value="";
	            }
	            else
	            {
			    document.getElementById('txtbgamt').value=dsbgexecute.Tables[0].Rows[z].BG_AMT;
			    }
		       document.getElementById('txtbgid').value=dsbgexecute.Tables[0].Rows[z].bgid;
				document.getElementById('txtbgname').value=dsbgexecute.Tables[0].Rows[z].bgname;
				document.getElementById('txtbgalias').value=dsbgexecute.Tables[0].Rows[z].bgalias;
				
				
					/*new change ankur*/
				    document.getElementById('drppub').value=dsbgexecute.Tables[0].Rows[z].Publication;
                    filledit();				    
				    document.getElementById('drpedition').value=dsbgexecute.Tables[0].Rows[z].Edition;
            document.getElementById('drpcat').value=dsbgexecute.Tables[0].Rows[z].Category;
            document.getElementById('drpcolortype').value=dsbgexecute.Tables[0].Rows[z].Colortype;
            
            document.getElementById('drppub').disabled=true;
            document.getElementById('drpedition').disabled=true;
            document.getElementById('drpcat').disabled=true;
            document.getElementById('drpcolortype').disabled=true;
            
            ///////////////////////////////////////////////////////////////
	}
	        if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==dsbgexecute.Tables[0].Rows.length)
              {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
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
//*******************************************************************************//
//**************************This Function For Cancle button**********************//
//*******************************************************************************//


function bgcancelclick(formname)
{
               dsbgexecute=null;
				document.getElementById('txtbgid').value="";
				document.getElementById('txtbgname').value="";	
				document.getElementById('txtbgalias').value="";
				document.getElementById('txtbgamt').value="";
				document.getElementById('drpbgamttype').value="0";
				
				document.getElementById('drpbgamttype').disabled=true;
				document.getElementById('txtbgamt').disabled=true;
				document.getElementById('txtbgid').disabled=true;
				document.getElementById('txtbgname').disabled=true;
				document.getElementById('txtbgalias').disabled=true;
				
				
					/*new change ankur*/
				    var pub=document.getElementById('drppub').value="0";
            var edit=document.getElementById('drpedition').value="0";
            var cat=document.getElementById('drpcat').value="0";
            var cat=document.getElementById('drpcat2').value="0";
            var cat=document.getElementById('drpcat3').value="0";
            var cat=document.getElementById('drpcat4').value="0";
            var cat=document.getElementById('drpcat5').value="0";
            var coltyp=document.getElementById('drpcolortype').value="0";
            
            var pub=document.getElementById('drppub').disabled=true;
            var edit=document.getElementById('drpedition').disabled=true;
            var cat=document.getElementById('drpcat').disabled=true;
            var cat=document.getElementById('drpcat2').disabled=true;
            var cat=document.getElementById('drpcat3').disabled=true;
            var cat=document.getElementById('drpcat4').disabled=true;
            var cat=document.getElementById('drpcat5').disabled=true;
            var coltyp=document.getElementById('drpcolortype').disabled=true;
            
            ///////////////////////////////////////////////////////////////
				
				
				document.getElementById('btnModify').disabled=true;
			    document.getElementById('btnQuery').disabled=false;
			    document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').disabled=true;
				
				dsbgexecute=null;
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
					
				/*document.getElementById('btnNew').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExit').disabled=false;
			    document.getElementById('btnCancel').disabled=false;
			
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
			
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;*/
					givebuttonpermission(formname);
					setButtonImages();
				return false;
}

function bgnextclicktest()
{
		BgColor.bgfpnl(nextcalltest);

		        document.getElementById('txtbgid').disabled=true;
				document.getElementById('txtbgname').disabled=true;
				document.getElementById('txtbgalias').disabled=true;
		
		return false;
}


//*******************************************************************************//
//********************This Is The Responce Of The Next Button*******************//
//*******************************************************************************//
function nextcalltest(response)
{
	//var dszoneexecute=response.value;
	var a=dsbgexecute.Tables[0].Rows.length;
	znk++;
	if(znk !=-1 && znk >= 0)
	{
		if(znk <= a-1)
		{
			document.getElementById('txtbgid').value=dsbgexecute.Tables[0].Rows[znk].bgid;
				document.getElementById('txtbgname').value=dsbgexecute.Tables[0].Rows[znk].bgname;
				document.getElementById('txtbgalias').value=dsbgexecute.Tables[0].Rows[znk].bgalias;
			
		    updateStatus();
		    
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			
			
			
		}
		else
	{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			
			document.getElementById('btnDelete').disabled=false
	}
	}
	else
	{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		
			document.getElementById('btnDelete').disabled=false
	}
	if(znk==a-1)
	{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
	}
	return false;

}

	/*new change ankur*/
	///*************This function is used for focusing the edition name***************///
function filledit()
{    
	
	if(document.getElementById('drppub').value!="0")
    {
    var pubname=document.getElementById('drppub').value;

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
BgColor.addedition(pubname,callbind);

    }
    else
    {
        var pkgitem=document.getElementById('drpedition');
        pkgitem.options[0]=new Option("-Select Edititon--","0");
        pkgitem.options.length = 1; 
        return false;
         
    }

return false;

   
    
   return false;
}

function callbind(res)
{

    var ds=res.value;
    var pkgitem = document.getElementById("drpedition");
     

    if(ds!= null && typeof(ds) == "object" && ds.Tables[1].Rows.length > 0) 
    {
            var pkgitem=document.getElementById('drpedition');
             pkgitem.options[0]=new Option("-Select Edititon-","0");
         
    //var pkgitem = document.getElementById("drpcity");
    //alert(pkgitem);
        pkgitem.options.length = 1; 
        //alert(pkgitem.options.length);
        for (var i = 0  ; i < res.value.Tables[1].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[1].Rows[i].Edition_Alias,res.value.Tables[1].Rows[i].Edition_Code);
            
           pkgitem.options.length;
           
        }
//        if (z==0)
//        {
//        document.getElementById('drpedition').value=dsbgexecute.Tables[0].Rows[0].Edition;
//        }
//        
//        if (z>=1)
//        {
//        document.getElementById('drpedition').value=dsbgexecute.Tables[0].Rows[z].Edition;
//        }
        
        if(dsbgexecute!=undefined && dsbgexecute!="" && dsbgexecute!=null)
        {
            var len=dsbgexecute.Tables[0].Rows.length;
            if(z>=len || z==-1)
	        {
                document.getElementById('drpedition').value=dsbgexecute.Tables[0].Rows[0].Edition;
            }
            else
            {
                document.getElementById('drpedition').value=dsbgexecute.Tables[0].Rows[z].Edition;
            }
        }
        


    return false;
    }
    else
    {
                var pkgitem=document.getElementById('drpedition');
                pkgitem.options.length=0;
             pkgitem.options[0]=new Option("-Select Edititon-","0");
    }
}
//////////////////////////////////////////////////////////////////////////////////////////////			
var glo_cat2;
function fillAdCat2()
{
//dan
compcode=document.getElementById("hiddencomcode").value;
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
BgColor.fillCat2(document.getElementById('drpcat').value,compcode,fillCat2_callback);
    
}

function fillCat2_callback(response)
{
    var ds=response.value;
    var title=document.getElementById('drpcat2');
    title.options.length=0;
    title.options[0]=new Option("--Select Ad Category2--","0");
    var title1=document.getElementById('drpcat3');
    title1.options.length=0;
    title1.options[0]=new Option("--Select Ad Category3--","0");
    document.getElementById('drpcat4').options.length=0;
    document.getElementById('drpcat4').options[0]=new Option("--Select Ad Category4--","0");
    document.getElementById('drpcat5').options.length=0;
    document.getElementById('drpcat5').options[0]=new Option("--Select Ad Category5--","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for(i=0;i<=ds.Tables[0].Rows.length-1;i++)
        {
            title.options[i+1]=new Option(ds.Tables[0].Rows[i].Adv_Subcat_Name,ds.Tables[0].Rows[i].Adv_Subcat_Code);
            title.options.length;
        }
    }
    if(dsbgexecute!=undefined && dsbgexecute!="" && dsbgexecute!=null)
    {
        
        if(hiddentext=="mod")
        {
            
           //document.getElementById('drpcat4').value=dsbgexecute.Tables[0].Rows[z].Category4;
            document.getElementById('drpcat2').value="0";
            return false;
        }
        else
        {
            document.getElementById('drpcat2').value=dsbgexecute.Tables[0].Rows[z].Category2;
        }
//    document.getElementById('drpcat3').options[0]=new Option("--Select Ad Category3--","0");
//    document.getElementById('drpcat4').options[0]=new Option("--Select Ad Category4--","0");
//    document.getElementById('drpcat5').options[0]=new Option("--Select Ad Category5--","0");
        fillAdCat3();
    }
}



function fillAdCat3()
{
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
BgColor.fillCat3(document.getElementById('drpcat2').value,fillCat3_callback);
    
}
function fillCat3_callback(response)
{
    var ds=response.value;
    var pkgitem = document.getElementById("drpcat3");
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Ad Category3--","0");
    //alert(pkgitem.options.length);
     document.getElementById('drpcat4').options.length=0;
    document.getElementById('drpcat4').options[0]=new Option("--Select Ad Category4--","0");
    document.getElementById('drpcat5').options.length=0;
    document.getElementById('drpcat5').options[0]=new Option("--Select Ad Category5--","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].catname,ds.Tables[0].Rows[i].catcode);
            
           pkgitem.options.length;
           
        }
    }
    if(dsbgexecute!=undefined && dsbgexecute!="" && dsbgexecute!=null)
    {
       
        if(hiddentext=="mod")
        {
            
           //document.getElementById('drpcat4').value=dsbgexecute.Tables[0].Rows[z].Category4;
            document.getElementById('drpcat3').value="0";
            return false;
        }
        else
        {
            document.getElementById('drpcat3').value=dsbgexecute.Tables[0].Rows[z].Category3;
        }
      //  document.getElementById('drpcat3').value="0";
        fillAdCat4();
    }
    
  //   document.getElementById("drpcat3").value=glo_cat3;
    return false;
}


function fillAdCat4()
{
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
BgColor.fillCat4(document.getElementById('drpcat3').value,document.getElementById('hiddencomcode').value,fillCat4_callback);
}

function fillCat4_callback(response)
{
    var ds=response.value;
    var pkgitem = document.getElementById("drpcat4");
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Ad Category4--","0");
    //alert(pkgitem.options.length);
    document.getElementById('drpcat5').options.length=0;
    document.getElementById('drpcat5').options[0]=new Option("--Select Ad Category5--","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cat_Name,ds.Tables[0].Rows[i].Cat_Code);
            
           pkgitem.options.length;
           
        }
    }
    if(dsbgexecute!=undefined && dsbgexecute!="" && dsbgexecute!=null)
    {
        if(hiddentext=="mod")
        {
            
           document.getElementById('drpcat4').value=dsbgexecute.Tables[0].Rows[z].Category4;
            document.getElementById('drpcat4').value="0";
            return false;
        }
        else
        {
            document.getElementById('drpcat4').value=dsbgexecute.Tables[0].Rows[z].Category4;
        }
       // document.getElementById('drpcat4').value="0";
        fillAdCat5();
    }
  //   document.getElementById("drpcat3").value=glo_cat3;
    return false;
}

function fillAdCat5()
{
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
BgColor.fillCat5(document.getElementById('drpcat4').value,document.getElementById('hiddencomcode').value,fillCat5_callback);
}

function fillCat5_callback(response)
{
    var ds=response.value;
    var pkgitem = document.getElementById("drpcat5");
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Ad Category5--","0");
    //alert(pkgitem.options.length);
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cat_Name,ds.Tables[0].Rows[i].Cat_Code);
            
           pkgitem.options.length;
           
        }
    }
    if(dsbgexecute!=undefined && dsbgexecute!="" && dsbgexecute!=null)
    {
        document.getElementById('drpcat5').value=dsbgexecute.Tables[0].Rows[z].Category5;
        //document.getElementById('drpcat5').value="0";
    }
  //   document.getElementById("drpcat3").value=glo_cat3;
    return false;
}
function fixper()
{
//document.getElementById('txtbulletcjar').value="";
var x = document.getElementById('drpbgamttype').value;
    if(x=="P")
        {
            document.getElementById('txtbgamt').MaxLength=4;
            if(document.getElementById('txtbgamt').value >100)
                {
                    alert('Percentage should not be greater than 100');
                    document.getElementById('txtbgamt').value="";
                    document.getElementById('txtbgamt').focus();
                }
            else
                {
                    var a = document.getElementById('txtbgamt').value;
                    if(a!="")
                    {
//                        if(a.indexOf('%')==-1)
//                        {
                            document.getElementById('txtbgamt').value = a ;//+ "%";
//                        }
                    }
                }
        }
        if(x=="F")
        {
        var fld=document.getElementById('txtbgamt').value;
		if(fld!="")
			{
			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
			if(fld.match(/^\d+(\.\d{2})?$/i))
			{
			return true;
			}
			else
			{
			alert("Input error")
			document.getElementById('txtbgamt').value="";
			document.getElementById('txtbgamt').focus();
			return false;
			}
			}
        }
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

function clearbgcolor() {
    bgcancelclick('BgColor');
    givebuttonpermission('BgColor')
}

