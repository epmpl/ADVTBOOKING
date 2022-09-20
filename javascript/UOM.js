//this for save and update
var modify="0";
//this flag is for permission
var flag="";
var z="0";
var hiddentext;
var auto="";
var hiddentext1="";
var uomds;

///////global variables for deletion  by dataset.........
var glcode;
var gldesc;
var glalias;  
var gladtype;
   var  gluomtype;             
var chknamemod;
function newclick()
{
			document.getElementById('txtuomcode').value="";
			document.getElementById('txtuomdesc').value="";
			document.getElementById('txtalias').value="";
			document.getElementById('txtSampleImg').value="";
			document.getElementById('txtStyleSheet').value="";
			document.getElementById('drpuomtype').value=0;
			document.getElementById('drpadtype').value=0;
			if(document.getElementById('hiddenauto').value==1)
		     {
		      document.getElementById('txtuomcode').disabled=true;
    	      }
		     else
		       {
		       document.getElementById('txtuomcode').disabled=false;
    	       }
			$('txtsrvcacc').value = "";
			$('txtsubsrvcacc').value = "";
			$('txtsrvcacc').disabled = false
			$('txtsubsrvcacc').disabled = false;
			document.getElementById('txtuomdesc').disabled=false;
			document.getElementById('txtalias').disabled=false;
			document.getElementById('drpuomtype').disabled=false;
            document.getElementById('drpadtype').disabled=false;
            document.getElementById('txtSampleImg').disabled=false;
			document.getElementById('txtStyleSheet').disabled=false;
			
			
			  document.getElementById('txtcol').disabled=false;
            document.getElementById('txtguttwid').disabled=false;
			document.getElementById('txtcolwid').disabled=false;
			
			/*new change ankur 16 feb */
			document.getElementById('drpaddesc').disabled=false;
			document.getElementById('drpaddesc').value="0";
			//////////////////////////////////
             document.getElementById('drpadtype').focus();
             /*new change ankur 19 feb*/
             document.getElementById('drplogo').disabled = false;	
			document.getElementById('txtlogouom').disabled = false;	
			
			document.getElementById('drplogo').value="0";
			document.getElementById('txtlogouom').value="";
			//////////////////////////////////
             
			chkstatus(FlagStatus);
			hiddentext="new";
			document.getElementById('btnSave').disabled = false;	
			document.getElementById('btnNew').disabled = true;	
			document.getElementById('btnQuery').disabled=true;
			flag=0;
            
		setButtonImages();
			return false;
}
function modifyclick()
{
    $('txtsrvcacc').disabled = false
    $('txtsubsrvcacc').disabled = false;
			document.getElementById('txtuomcode').disabled=true;
			document.getElementById('txtuomdesc').disabled=false;
			document.getElementById('txtalias').disabled=false;
			document.getElementById('drpuomtype').disabled=false;
			document.getElementById('drpadtype').disabled=false;
			
			document.getElementById('txtSampleImg').disabled=false;
			document.getElementById('txtStyleSheet').disabled=false;
			
			
				document.getElementById('txtcol').disabled=false;
			document.getElementById('txtguttwid').disabled=false;
			document.getElementById('txtcolwid').disabled=false;
			

			modify="1";
			chkstatus(FlagStatus);
			 hiddentext="modify";
			document.getElementById('btnSave').disabled = false;
			document.getElementById('btnQuery').disabled = true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			
			chknamemod=document.getElementById('txtuomdesc').value;
				
				/*new change ankur 16 feb */
			document.getElementById('drpaddesc').disabled=false;
			//document.getElementById('drpaddesc').value="0";
			//////////////////////////////////
			
			  /*new change ankur 19 feb*/
             document.getElementById('drplogo').disabled = false;	
			document.getElementById('txtlogouom').disabled = false;	
			
			//document.getElementById('drplogo').value="0";
			//document.getElementById('txtlogouom').value="0";
			//////////////////////////////////
			
			document.getElementById('btnExit').disabled=false;			
			flag=1;
			setButtonImages();
			return false;
}

function queryclick()
{
			document.getElementById('txtuomcode').value="";
			document.getElementById('txtuomdesc').value="";
			document.getElementById('txtalias').value="";
			document.getElementById('txtSampleImg').value="";
			document.getElementById('txtStyleSheet').value="";
			document.getElementById('drpuomtype').value=0;
			document.getElementById('drpadtype').value=0
			$('txtsrvcacc').value = "";
			$('txtsubsrvcacc').value = "";

            /*new change ankur 16 feb */
			document.getElementById('drpaddesc').disabled=true;
			document.getElementById('drpaddesc').value="0";
			//////////////////////////////////
			
			  /*new change ankur 19 feb*/
             document.getElementById('drplogo').disabled = true;	
			document.getElementById('txtlogouom').disabled = true;	
			
			document.getElementById('drplogo').value="0";
			document.getElementById('txtlogouom').value="";
			//////////////////////////////////
			
			document.getElementById('txtuomcode').disabled=false;
			document.getElementById('txtuomdesc').disabled=false;
			document.getElementById('txtalias').disabled=false;
			document.getElementById('drpuomtype').disabled=false;
			document.getElementById('drpadtype').disabled = false;
			$('txtsrvcacc').disabled = false;
			$('txtsubsrvcacc').disabled = false;
			z=0;
			modify="0";
			hiddentext="query";
			chkstatus(FlagStatus);
			//updateStatus();

            document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
			setButtonImages();
				document.getElementById('btnExecute').focus();
			return false;
}

function executeclick()
{
			var txtuomcode=document.getElementById('txtuomcode').value;
			var txtuomdesc=document.getElementById('txtuomdesc').value;
			var txtalias=document.getElementById('txtalias').value;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var adtype=document.getElementById('drpadtype').value;
			var uomtype=document.getElementById('drpuomtype').value;
			          glcode=txtuomcode;
                      gldesc=txtuomdesc;
                      glalias=txtalias;
                      gladtype=adtype;
                      gluomtype=uomtype;
                      var acc_cd = document.getElementById('txtsrvcacc').value;
                      var sacc_cd = document.getElementById('txtsubsrvcacc').value;

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
              UOM.execute(compcode, userid, txtuomcode, txtuomdesc, txtalias, adtype, uomtype, call_execute);
			updateStatus();
			
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
			document.getElementById('btnExit').disabled=false;			
			return false;
}
function call_execute(response)
{
			//var ds=response.value;
                    uomds =response.value;			
			updateStatus();
			if(uomds.Tables[0].Rows.length <= 0)
			{
					alert("Your search criteria does not exist");
					document.getElementById('btnModify').disabled=true;
				    document.getElementById('btnDelete').disabled=true;
				    document.getElementById('txtuomcode').disabled=true;
					document.getElementById('txtuomdesc').disabled=true;
					document.getElementById('txtalias').disabled=true;
					document.getElementById('drpuomtype').disabled=true;
					document.getElementById('drpadtype').disabled=true;
					/*new change ankur 16 feb*/
					document.getElementById('drpaddesc').disabled=true;
					/////////////
					$('txtsrvcacc').disabled = true;
					$('txtsubsrvcacc').disabled = true;
					  /*new change ankur 19 feb*/
             document.getElementById('drplogo').disabled = false;	
			document.getElementById('txtlogouom').disabled = false;	
			
			document.getElementById('drplogo').value="0";
			document.getElementById('txtlogouom').value="";
			//////////////////////////////////
					
					cancelclick('UOM');
					return false;
			}
			else
			{
					var txtuomcode=document.getElementById('txtuomcode').value=uomds.Tables[0].Rows[0].UOM_Code;
					var txtuomdesc=document.getElementById('txtuomdesc').value=uomds.Tables[0].Rows[0].UOM_Name;
					var txtalias=document.getElementById('txtalias').value=uomds.Tables[0].Rows[0].UOM_Alias;
					var acc_cd = document.getElementById('txtsrvcacc').value = uomds.Tables[0].Rows[0].ACC_CD;

			        var sacc_cd = document.getElementById('txtsubsrvcacc').value = uomds.Tables[0].Rows[0].SACC_CD;

					if (uomds.Tables[0].Rows[0].SAC_CODE == null)
					{
					    document.getElementById('txtsrvcacc').value = "";
					}
					else
					{
					    $('txtsrvcacc').value = uomds.Tables[0].Rows[0].SAC_CODE;
					}


					if (uomds.Tables[0].Rows[0].SUB_SAC_CODE == null) {
					    document.getElementById('txtsubsrvcacc').value = "";
					}
					else
					{
					    $('txtsubsrvcacc').value = uomds.Tables[0].Rows[0].SUB_SAC_CODE;
					}
//        var column=document.getElementById('txtcol').value=uomds.Tables[0].Rows[0].COLUMN1;
//        var gutwidth=document.getElementById('txtguttwid').value=uomds.Tables[0].Rows[0].GUTTERWIDTH;
//        var colwidth=document.getElementById('txtcolwid').value=uomds.Tables[0].Rows[0].COLUMNWIDTH;



if(uomds.Tables[0].Rows[0].COLUMNWIDTH==null)
					{
					    document.getElementById('txtcolwid').value="";
					}
					else
					{
					    document.getElementById('txtcolwid').value=uomds.Tables[0].Rows[0].COLUMNWIDTH;
					}	

if(uomds.Tables[0].Rows[0].GUTTERWIDTH==null)
					{
					    document.getElementById('txtguttwid').value="";
					}
					else
					{
					    document.getElementById('txtguttwid').value=uomds.Tables[0].Rows[0].GUTTERWIDTH;
					}		
					
					
					
			if(uomds.Tables[0].Rows[0].COLUMN1==null)
					{
					    document.getElementById('txtcol').value="";
					}
					else
					{
					    document.getElementById('txtcol').value=uomds.Tables[0].Rows[0].COLUMN1;
					}		
					
					
					
					
					
					if(uomds.Tables[0].Rows[0].sample_img_hm==null)
					{
					    document.getElementById('txtSampleImg').value="";
					}
					else
					{
					    document.getElementById('txtSampleImg').value=uomds.Tables[0].Rows[0].sample_img_hm;
					}
					
					if(uomds.Tables[0].Rows[0].stylesheetname==null)
					{
					    document.getElementById('txtStyleSheet').value="";
					}
					else
					{
					    document.getElementById('txtStyleSheet').value=uomds.Tables[0].Rows[0].stylesheetname;
					}					
					
					
                    document.getElementById('drpuomtype').value=uomds.Tables[0].Rows[0].UOM_Type;
                    document.getElementById('drpadtype').value=uomds.Tables[0].Rows[0].Ad_Type;
                    /*new change ankur 16 feb*/
                    document.getElementById('drpaddesc').value=uomds.Tables[0].Rows[0].uom_desc;
                    //////////////
                    /*new change ankur 19 feb*/
                    document.getElementById('drplogo').value=uomds.Tables[0].Rows[0].Logo;
                    if(uomds.Tables[0].Rows[0].Logo_Uom!=null)
                    {
			        document.getElementById('txtlogouom').value=uomds.Tables[0].Rows[0].Logo_Uom;
			        }
			        else
			        {
			           document.getElementById('txtlogouom').value="";
			        }
                    //////////////////
					var userid=document.getElementById('hiddenuserid').value;
					 //document.getElementById('btnModify').focus();
					document.getElementById('btnfirst').disabled=true;
				    document.getElementById('btnprevious').disabled=true;
				    document.getElementById('btnnext').disabled=false;
				    document.getElementById('btnlast').disabled=false;
					if(uomds.Tables[0].Rows.length==1)
					{
					document.getElementById('btnfirst').disabled=true;
				    document.getElementById('btnprevious').disabled=true;
				    document.getElementById('btnnext').disabled=true;
				    document.getElementById('btnlast').disabled=true;
    				
					}
					

					document.getElementById('txtuomcode').disabled=true;
					document.getElementById('txtuomdesc').disabled = true;
					$('txtsrvcacc').disabled = true;
					$('txtsubsrvcacc').disabled = true;
					document.getElementById('txtalias').disabled=true;
					document.getElementById('drpuomtype').disabled=true;
					document.getElementById('drpadtype').disabled=true;
			}
			setButtonImages();
			return false;
}

function cancelclick(formname)
{
				document.getElementById('txtuomcode').value="";
				document.getElementById('txtuomdesc').value = "";
				$('txtsrvcacc').value = "";
				$('txtsubsrvcacc').value = "";
				document.getElementById('txtalias').value="";
					
				document.getElementById('txtSampleImg').value="";
			    document.getElementById('txtStyleSheet').value="";
			    
			    
			    document.getElementById('txtcol').value="";
					
				document.getElementById('txtguttwid').value="";
			    document.getElementById('txtcolwid').value="";
			    
				document.getElementById('drpuomtype').value=0;
				document.getElementById('drpadtype').value=0;

                /*new change ankur 16 feb*/
					document.getElementById('drpaddesc').disabled=true;
					document.getElementById('drpaddesc').value="0";
					/////////////
					
					
					  /*new change ankur 19 feb*/
             document.getElementById('drplogo').disabled = false;	
			document.getElementById('txtlogouom').disabled = false;	
			
			document.getElementById('drplogo').value="0";
			document.getElementById('txtlogouom').value="";
			//////////////////////////////////

				document.getElementById('txtuomcode').disabled=true;
				document.getElementById('txtuomdesc').disabled = true;
				$('txtsrvcacc').disabled = true;
				$('txtsubsrvcacc').disabled = true;
				document.getElementById('txtalias').disabled=true;
				document.getElementById('drpuomtype').disabled=true;
				document.getElementById('drpadtype').disabled=true;
				
					document.getElementById('drplogo').disabled=true;
				
				document.getElementById('txtSampleImg').disabled=true;
			    document.getElementById('txtStyleSheet').disabled=true;

				
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
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnDelete').disabled=true;
setButtonImages();
				modify="0";
				if(FlagStatus!=2 && FlagStatus!=4 && FlagStatus!=6)
				{
				document.getElementById('btnNew').disabled=false;
				document.getElementById('btnNew').focus();
				}
				//getPermission(formname);
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

function saveclick()
{
document.getElementById('txtuomdesc').value=trim(document.getElementById('txtuomdesc').value);
document.getElementById('txtalias').value=trim(document.getElementById('txtalias').value);
document.getElementById('txtuomcode').value=trim(document.getElementById('txtuomcode').value);
document.getElementById('txtSampleImg').value=trim(document.getElementById('txtSampleImg').value);
document.getElementById('txtStyleSheet').value=trim(document.getElementById('txtStyleSheet').value);
document.getElementById('txtcol').value=trim(document.getElementById('txtcol').value);
document.getElementById('txtguttwid').value=trim(document.getElementById('txtguttwid').value);
document.getElementById('txtcolwid').value = trim(document.getElementById('txtcolwid').value);
document.getElementById('hdnsrvcacc').value = trim(document.getElementById('hdnsrvcacc').value);
document.getElementById('hdnsubsrvcacc').value = trim(document.getElementById('hdnsubsrvcacc').value);


        var browser=navigator.appName;
         if(document.getElementById('drpadtype').value=="0")
		{
				alert("Please Select Ad Type");
				document.getElementById('drpadtype').focus();
				return false;
		}
		else if((document.getElementById('txtuomcode').value=="") &&(document.getElementById('hiddenauto').value!=1))
		{
				alert("Please Enter UOM Code");
				document.getElementById('txtuomcode').focus();
				return false;
		}
		else if(document.getElementById('txtuomdesc').value=="")
		{
				alert("Please Enter UOM Name");
				document.getElementById('txtuomdesc').focus();
				return false;
		}
		else if(document.getElementById('txtalias').value=="")
		{
				alert("Please Enter Alias");
				document.getElementById('txtalias').focus();
				return false
		}
		
		else if(document.getElementById('drpuomtype').value=="0")
		{
				alert("Please Select UOM Type");
				document.getElementById('drpuomtype').focus();
				return false
		}
		else if(document.getElementById('drpaddesc').value=="0")
		{
				alert("Please Select Uom Description");
				document.getElementById('drpaddesc').focus();
				return false
		}
		/*new change ankur 16 feb*/
		else if(document.getElementById('drpadtype')=="CL0" && document.getElementById('drpaddesc').value=="0")
		{
		    alert("Please select UOM Type");
		    document.getElementById('drpaddesc').focus();
		    return false;
		}
				
	   else if (document.getElementById('drpadtype').value!="DI0" && trim(document.getElementById('txtStyleSheet').value)== "" )
	   {
	    alert("Please Enter Style Sheet");
                document.getElementById('txtStyleSheet').focus();
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
		//*****************By Manish Verma******************************	    
	  /*  var bc="";
    
        if(browser!="Microsoft Internet Explorer")
        {
            bc=document.getElementById('txtStyleSheet').textContent;
        }
        else
        {
            bc=document.getElementById('txtStyleSheet').innerText; 
        } 
        if(bc.indexOf('*')>= 0 )
	    {
	        if(trim(document.getElementById('txtStyleSheet').value)== "" )
	        {   
	            alert('Please Enter '+(bc.replace('*', "")));
                document.getElementById('txtStyleSheet').focus();
                return false;
	        }
	    }*/
        //*******************************************************************************
		var txtuomcode=document.getElementById('txtuomcode').value;
		var txtuomdesc=document.getElementById('txtuomdesc').value;
		var txtalias=document.getElementById('txtalias').value;
		var txtuomtype=document.getElementById('drpuomtype').value;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
        var adtype=document.getElementById('drpadtype').value;
        
        var sampleimg=document.getElementById('txtSampleImg').value;
        var stylesheet=document.getElementById('txtStyleSheet').value;
        
        var column=document.getElementById('txtcol').value;
        var gutwidth=document.getElementById('txtguttwid').value;
        var colwidth=document.getElementById('txtcolwid').value;
        var acc_cd = document.getElementById('hdnsrvcacc').value;

        
					/////////////
					
					
					  /*new change ankur 19 feb*/
            
			
			var logo=document.getElementById('drplogo').value;
			var logouom=trim(document.getElementById('txtlogouom').value);
			//////////////////////////////////
        
		if(modify!="1" && modify!=null)
		{
		
UOM.checkuom(txtuomcode,txtuomdesc,compcode,userid,call_save);
		}
		else
		{       
		        var str= document.getElementById('txtuomdesc').value;
		    	UOM.chkuomcode(str,call_modify);
		}
		return false;
}

function call_modify(response)
{
    var ds=response.value;
        if(chknamemod!=document.getElementById('txtuomdesc').value)
        {
            if(ds.Tables[0].Rows.length!=0)
            {
                alert("This UOM name has already assigned !! ");
                document.getElementById('txtuomdesc').value="";
                document.getElementById('txtuomdesc').focus();
                return false;
            }
        }
   
        var txtuomcode=document.getElementById('txtuomcode').value;
		var txtuomdesc=document.getElementById('txtuomdesc').value;
		var txtalias=document.getElementById('txtalias').value;
		var txtuomtype=document.getElementById('drpuomtype').value;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
        var adtype=document.getElementById('drpadtype').value;
        var sampleimg=document.getElementById('txtSampleImg').value;
        var stylesheet=document.getElementById('txtStyleSheet').value;
        var uom_desc=document.getElementById('drpaddesc').value;
    	var logo=document.getElementById('drplogo').value;
		var logouom=trim(document.getElementById('txtlogouom').value);
        var ip2=document.getElementById('ip1').value;
        
         var column=document.getElementById('txtcol').value;
            var gutwidth=document.getElementById('txtguttwid').value;
            var colwidth=document.getElementById('txtcolwid').value;
            var acc_cd = document.getElementById('hdnsrvcacc').value;
            var sacc_cd = document.getElementById('hdnsubsrvcacc').value;
        
        
        
            UOM.update(txtuomcode, txtuomdesc, txtalias, compcode, userid, txtuomtype, adtype, sampleimg, stylesheet, uom_desc, logo, logouom, ip2, column, gutwidth, colwidth, acc_cd, sacc_cd);
			alert("Data Update Successfully");
			uomds.Tables[0].Rows[z].UOM_Code= document.getElementById('txtuomcode').value;
			uomds.Tables[0].Rows[z].UOM_Name=document.getElementById('txtuomdesc').value;
			uomds.Tables[0].Rows[z].UOM_Alias=document.getElementById('txtalias').value;
			uomds.Tables[0].Rows[z].UOM_Type = document.getElementById('drpuomtype').value;
			uomds.Tables[0].Rows[z].Ad_Type = document.getElementById('drpadtype').value;
			
			//uom_desc
			uomds.Tables[0].Rows[z].SAC_CODE = document.getElementById('txtsrvcacc').value;
			uomds.Tables[0].Rows[z].SUB_SAC_CODE = document.getElementById('txtsubsrvcacc').value;
			
			uomds.Tables[0].Rows[z].sample_img_hm=document.getElementById('txtSampleImg').value;
			uomds.Tables[0].Rows[z].stylesheetname=document.getElementById('txtStyleSheet').value;
			
			
			uomds.Tables[0].Rows[z].COLUMN1=document.getElementById('txtcol').value;
			uomds.Tables[0].Rows[z].GUTTERWIDTH=document.getElementById('txtguttwid').value;
			uomds.Tables[0].Rows[z].COLUMNWIDTH=document.getElementById('txtcolwid').value;
			
			/*new change ankur 16 feb*/
			uomds.Tables[0].Rows[z].uom_desc=document.getElementById('drpaddesc').value;
			
			    document.getElementById('btnNew').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=false;
				document.getElementById('btnDelete').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;		
										
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnlast').disabled=false;
				$('txtsrvcacc').disabled = true;
				$('txtsubsrvcacc').disabled = true;

			document.getElementById('txtuomcode').disabled=true;
			document.getElementById('txtuomdesc').disabled=true;
			document.getElementById('txtalias').disabled=true;
			document.getElementById('drpuomtype').disabled=true;
            document.getElementById('drpadtype').disabled=true;
            document.getElementById('drpaddesc').disabled=true;
            document.getElementById('txtSampleImg').disabled=true;
			document.getElementById('txtStyleSheet').disabled=true;
			
			document.getElementById('txtcol').disabled=true;
            document.getElementById('txtguttwid').disabled=true;
			document.getElementById('txtcolwid').disabled=true;
			
			
			
					  /*new change ankur 19 feb*/
            
			
			document.getElementById('drplogo').disabled=true;
			document.getElementById('txtlogouom').disabled=true;
			//////////////////////////////////
            
			modify="0";
			flag=0;
			updateStatus();
			if(z==0)
		        {
		        document.getElementById('btnfirst').disabled=true;				
		        document.getElementById('btnprevious').disabled=true;
		        }
		        if(z==uomds.Tables[0].Rows.length-1)
		        {
		        document.getElementById('btnnext').disabled=true;					
		        document.getElementById('btnlast').disabled=true;
		        }
		        setButtonImages();
			return false;
}

function call_save(response)
{
		var ds=response.value;
		if(ds.Tables[0].Rows.length > 0)
		{
			alert("This Code Has Been Assigned");
			document.getElementById('txtuomcode').value="";
			document.getElementById('txtuomcode').focus();
			return false;
		}
		
        if(ds.Tables[1].Rows.length > 0)
        {
            alert("This UOM Name Has Been Assigned");
            document.getElementById('txtuomdesc').value="";
            document.getElementById('txtalias').value="";
            document.getElementById('txtuomdesc').focus();
            return false;
        }
        
		else
		{
			var txtuomcode=document.getElementById('txtuomcode').value;
			var txtuomdesc=document.getElementById('txtuomdesc').value;
			var txtalias=document.getElementById('txtalias').value;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var txtuomtype=document.getElementById('drpuomtype').value;
            var adtype=document.getElementById('drpadtype').value;
            
            var sampleimg=document.getElementById('txtSampleImg').value;
            var stylesheet=document.getElementById('txtStyleSheet').value;
            var uom_desc=document.getElementById('drpaddesc').value;
            /*new change ankur 19 feb*/
            
			var logo=document.getElementById('drplogo').value;
			var logouom=trim(document.getElementById('txtlogouom').value);
            var column=document.getElementById('txtcol').value;
            var gutwidth=document.getElementById('txtguttwid').value;
            var colwidth=document.getElementById('txtcolwid').value;
            var acc_cd = document.getElementById('hdnsrvcacc').value;
            var sacc_cd = document.getElementById('hdnsubsrvcacc').value;
			//////////////////////////////////
            
            /*new change ankur 16 feb*/
            var ip2=document.getElementById('ip1').value;
            UOM.insert(txtuomcode, txtuomdesc, txtalias, compcode, userid, txtuomtype, adtype, sampleimg, stylesheet, uom_desc, logo, logouom, ip2, column, gutwidth, colwidth, acc_cd, sacc_cd);

			alert("Data Saved Successfully");
			
		    

			document.getElementById('txtuomcode').value="";
			document.getElementById('txtuomdesc').value="";
			document.getElementById('txtalias').value="";
            document.getElementById('drpadtype').value=0;
            /*new change ankur 16 feb*/
            document.getElementById('drpaddesc').value="0";
            $('txtsrvcacc').value = "";
            $('txtsubsrvcacc').value = "";
            
			document.getElementById('txtcol').value="";
			document.getElementById('txtguttwid').value="";
			document.getElementById('txtcolwid').value="";
            
            
            
            document.getElementById('drpaddesc').disabled=true;
            //////////
            
            
					  /*new change ankur 22 feb*/
            
			
			document.getElementById('drplogo').disabled=true;
			document.getElementById('txtlogouom').disabled=true;
			
			
					  
            
			
			document.getElementById('drplogo').value="0";
			document.getElementById('txtlogouom').value="";
			//////////////////////////////////
			//////////////////////////////////
            
			document.getElementById('txtuomcode').disabled=true;
			document.getElementById('txtuomdesc').disabled=true;
			document.getElementById('txtalias').disabled=true;
            document.getElementById('drpadtype').disabled=true;
            
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
		cancelclick('UOM');
		return false;
}

function firstclick()
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
UOM.first(call_first);
		return false;
}

function call_first(response)
{
		//var ds=response.value;
		z=0;
		var txtuomcode=document.getElementById('txtuomcode').value=uomds.Tables[0].Rows[0].UOM_Code;
		var txtuomdesc=document.getElementById('txtuomdesc').value=uomds.Tables[0].Rows[0].UOM_Name;
		var txtalias=document.getElementById('txtalias').value=uomds.Tables[0].Rows[0].UOM_Alias;
		
		
		
		  if(uomds.Tables[0].Rows[0].COLUMNWIDTH==null)
					{
					    document.getElementById('txtcolwid').value="";
					}
					else
					{
					    document.getElementById('txtcolwid').value=uomds.Tables[0].Rows[0].COLUMNWIDTH;
					}	

if(uomds.Tables[0].Rows[0].GUTTERWIDTH==null)
					{
					    document.getElementById('txtguttwid').value="";
					}
					else
					{
					    document.getElementById('txtguttwid').value=uomds.Tables[0].Rows[0].GUTTERWIDTH;
					}		
					
					
					
			if(uomds.Tables[0].Rows[0].COLUMN1==null)
					{
					    document.getElementById('txtcol').value="";
					}
					else
					{
					    document.getElementById('txtcol').value=uomds.Tables[0].Rows[0].COLUMN1;
					}		
		
		if(uomds.Tables[0].Rows[z].sample_img_hm==null)
	    {
	        document.getElementById('txtSampleImg').value="";
	    }
	    else
	    {
	        document.getElementById('txtSampleImg').value=uomds.Tables[0].Rows[z].sample_img_hm;
	    }
		
	    if(uomds.Tables[0].Rows[z].stylesheetname==null)
	    {
	        document.getElementById('txtStyleSheet').value="";
	    }
	    else
	    {
	        document.getElementById('txtStyleSheet').value=uomds.Tables[0].Rows[z].stylesheetname;
	    }
		
        document.getElementById('drpuomtype').value=uomds.Tables[0].Rows[0].UOM_Type;
        document.getElementById('drpadtype').value=uomds.Tables[0].Rows[0].Ad_Type;
        document.getElementById('txtsrvcacc').value = uomds.Tables[0].Rows[a].SAC_CODE;
        document.getElementById('txtsubsrvcacc').value = uomds.Tables[0].Rows[a].SUB_SAC_CODE;
        /*new change ankur 16 feb*/
        document.getElementById('drpaddesc').value=uomds.Tables[0].Rows[0].uom_desc;
        
          /*new change ankur 22 feb*/
                    document.getElementById('drplogo').value=uomds.Tables[0].Rows[0].Logo;
                    if(uomds.Tables[0].Rows[0].Logo_Uom!=null)
                    {
			        document.getElementById('txtlogouom').value=uomds.Tables[0].Rows[0].Logo_Uom;
			        }
			        else
			        {
			             document.getElementById('txtlogouom').value="";
			        }
                    //////////////////
        
		updateStatus();
		 //document.getElementById('btnmodify').focus();

		document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnlast').disabled=false;	
		setButtonImages();	
		return false;
}

function lastclick()
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
UOM.first(call_last);
		return false;
}

function call_last(response)
{
		//var ds=response.value;
		var y=uomds.Tables[0].Rows.length;
		var a=y-1;
		z=a;

		var txtuomcode=document.getElementById('txtuomcode').value=uomds.Tables[0].Rows[a].UOM_Code;
		var txtuomdesc=document.getElementById('txtuomdesc').value=uomds.Tables[0].Rows[a].UOM_Name;
		var txtalias=document.getElementById('txtalias').value=uomds.Tables[0].Rows[a].UOM_Alias;
		
		
		  if(uomds.Tables[0].Rows[a].COLUMNWIDTH==null)
					{
					    document.getElementById('txtcolwid').value="";
					}
					else
					{
					    document.getElementById('txtcolwid').value=uomds.Tables[0].Rows[a].COLUMNWIDTH;
					}	

if(uomds.Tables[0].Rows[a].GUTTERWIDTH==null)
					{
					    document.getElementById('txtguttwid').value="";
					}
					else
					{
					    document.getElementById('txtguttwid').value=uomds.Tables[0].Rows[a].GUTTERWIDTH;
					}		
					
					
					
			if(uomds.Tables[0].Rows[a].COLUMN1==null)
					{
					    document.getElementById('txtcol').value="";
					}
					else
					{
					    document.getElementById('txtcol').value=uomds.Tables[0].Rows[a].COLUMN1;
					}		
					
		
		if(uomds.Tables[0].Rows[z].sample_img_hm==null)
	    {
	        document.getElementById('txtSampleImg').value="";
	    }
	    else
	    {
	        document.getElementById('txtSampleImg').value=uomds.Tables[0].Rows[z].sample_img_hm;
	    }
		
	    if(uomds.Tables[0].Rows[z].stylesheetname==null)
	    {
	        document.getElementById('txtStyleSheet').value="";
	    }
	    else
	    {
	        document.getElementById('txtStyleSheet').value=uomds.Tables[0].Rows[z].stylesheetname;
	    }
		
		document.getElementById('drpuomtype').value=uomds.Tables[0].Rows[a].UOM_Type;
		document.getElementById('drpadtype').value=uomds.Tables[0].Rows[a].Ad_Type;

		
    /*new change ankur 16 feb*/

		if (uomds.Tables[0].Rows[a].SAC_CODE == null) {
		    document.getElementById('txtsrvcacc').value = "";
		}
		else {
		    $('txtsrvcacc').value = uomds.Tables[0].Rows[a].SAC_CODE;
		}


		if (uomds.Tables[0].Rows[a].SUB_SAC_CODE == null) {
		    document.getElementById('txtsubsrvcacc').value = "";
		}
		else {
		    $('txtsubsrvcacc').value = uomds.Tables[0].Rows[a].SUB_SAC_CODE;
		}

        document.getElementById('drpaddesc').value=uomds.Tables[0].Rows[a].uom_desc;
        
          /*new change ankur 22 feb*/
                    document.getElementById('drplogo').value=uomds.Tables[0].Rows[a].Logo;
                    if(uomds.Tables[0].Rows[a].Logo_Uom!=null)
                    {
			        document.getElementById('txtlogouom').value=uomds.Tables[0].Rows[a].Logo_Uom;
			        }
			        else
			        {
			           document.getElementById('txtlogouom').value="";
			        }
                    //////////////////
		
		updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
		 //document.getElementById('btnmodify').focus();
setButtonImages();
		return false;
}

function previousclick()
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
UOM.first(call_previous);
		return false;
}

function call_previous(response)
{
	//	var ds=response.value;
		var a=uomds.Tables[0].Rows.length;

		z--;
		if(z != -1  )
		{
		if(z >= 0 && z < a)
		{
			var txtuomcode=document.getElementById('txtuomcode').value=uomds.Tables[0].Rows[z].UOM_Code;
			var txtuomdesc=document.getElementById('txtuomdesc').value=uomds.Tables[0].Rows[z].UOM_Name;
			var txtalias=document.getElementById('txtalias').value=uomds.Tables[0].Rows[z].UOM_Alias;
			
			
			
			
			    if(uomds.Tables[0].Rows[z].COLUMNWIDTH==null)
					{
					    document.getElementById('txtcolwid').value="";
					}
					else
					{
					    document.getElementById('txtcolwid').value=uomds.Tables[0].Rows[z].COLUMNWIDTH;
					}	

if(uomds.Tables[0].Rows[z].GUTTERWIDTH==null)
					{
					    document.getElementById('txtguttwid').value="";
					}
					else
					{
					    document.getElementById('txtguttwid').value=uomds.Tables[0].Rows[z].GUTTERWIDTH;
					}		
					
					
					
			if(uomds.Tables[0].Rows[z].COLUMN1==null)
					{
					    document.getElementById('txtcol').value="";
					}
					else
					{
					    document.getElementById('txtcol').value=uomds.Tables[0].Rows[z].COLUMN1;
					}		
					
					
			
			if(uomds.Tables[0].Rows[z].sample_img_hm==null)
		    {
		        document.getElementById('txtSampleImg').value="";
		    }
		    else
		    {
		        document.getElementById('txtSampleImg').value=uomds.Tables[0].Rows[z].sample_img_hm;
		    }
			
		    if(uomds.Tables[0].Rows[z].stylesheetname==null)
		    {
		        document.getElementById('txtStyleSheet').value="";
		    }
		    else
		    {
		        document.getElementById('txtStyleSheet').value=uomds.Tables[0].Rows[z].stylesheetname;
		    }
			
			document.getElementById('drpuomtype').value=uomds.Tables[0].Rows[z].UOM_Type;
			document.getElementById('drpadtype').value=uomds.Tables[0].Rows[z].Ad_Type;
			if (uomds.Tables[0].Rows[z].SAC_CODE == null) {
			    document.getElementById('txtsrvcacc').value = "";
			}
			else {
			    $('txtsrvcacc').value = uomds.Tables[0].Rows[z].SAC_CODE;
			}


			if (uomds.Tables[0].Rows[z].SUB_SAC_CODE == null) {
			    document.getElementById('txtsubsrvcacc').value = "";
			}
			else {
			    $('txtsubsrvcacc').value = uomds.Tables[0].Rows[z].SUB_SAC_CODE;
			}
			
        /*new change ankur 16 feb*/
        document.getElementById('drpaddesc').value=uomds.Tables[0].Rows[z].uom_desc;
        
          /*new change ankur 22 feb*/
                    document.getElementById('drplogo').value=uomds.Tables[0].Rows[z].Logo;
                    if(uomds.Tables[0].Rows[z].Logo_Uom!=null)
                    {
			        document.getElementById('txtlogouom').value=uomds.Tables[0].Rows[z].Logo_Uom;
			        }
			        else
			        {
			         document.getElementById('txtlogouom').value="";
			        }
                    //////////////////
			
			updateStatus();
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=false;				
			document.getElementById('btnprevious').disabled=false;				
			document.getElementById('btnlast').disabled=false;			
			document.getElementById('btnExit').disabled=false;
			   //document.getElementById('btnmodify').focus();
		}
		else
		{
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			   //document.getElementById('btnmodify').focus();
		}	
		}
		else
		{
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			   //document.getElementById('btnmodify').focus();
		}	
		
		if(z==0)
		{
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			   //document.getElementById('btnmodify').focus();
		}
		setButtonImages();
		return false;
}

//function nextclick()
//{
//		UOM.first(call_next);
//			return false;
//}

function nextclick()
{
		//var ds=response.value;
		var a=uomds.Tables[0].Rows.length;
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

		z++;
		if(z !=-1 && z >= 0)
		{
		    if(z <= a-1)
		    {
			    var txtuomcode=document.getElementById('txtuomcode').value=uomds.Tables[0].Rows[z].UOM_Code;
			    var txtuomdesc=document.getElementById('txtuomdesc').value=uomds.Tables[0].Rows[z].UOM_Name;
			    var txtalias=document.getElementById('txtalias').value=uomds.Tables[0].Rows[z].UOM_Alias;
			    
			    
			    
			    if(uomds.Tables[0].Rows[z].COLUMNWIDTH==null)
					{
					    document.getElementById('txtcolwid').value="";
					}
					else
					{
					    document.getElementById('txtcolwid').value=uomds.Tables[0].Rows[z].COLUMNWIDTH;
					}	

if(uomds.Tables[0].Rows[z].GUTTERWIDTH==null)
					{
					    document.getElementById('txtguttwid').value="";
					}
					else
					{
					    document.getElementById('txtguttwid').value=uomds.Tables[0].Rows[z].GUTTERWIDTH;
					}		
					
					
					
			if(uomds.Tables[0].Rows[z].COLUMN1==null)
					{
					    document.getElementById('txtcol').value="";
					}
					else
					{
					    document.getElementById('txtcol').value=uomds.Tables[0].Rows[z].COLUMN1;
					}		
					
					
					
					
    			
			    if(uomds.Tables[0].Rows[z].sample_img_hm==null)
			    {
			        document.getElementById('txtSampleImg').value="";
			    }
			    else
			    {
			        document.getElementById('txtSampleImg').value=uomds.Tables[0].Rows[z].sample_img_hm;
			    }
    			
			    if(uomds.Tables[0].Rows[z].stylesheetname==null)
			    {
			        document.getElementById('txtStyleSheet').value="";
			    }
			    else
			    {
			        document.getElementById('txtStyleSheet').value=uomds.Tables[0].Rows[z].stylesheetname;
			    }
    			
			    document.getElementById('drpuomtype').value=uomds.Tables[0].Rows[z].UOM_Type;
			    document.getElementById('drpadtype').value=uomds.Tables[0].Rows[z].Ad_Type;
			    if (uomds.Tables[0].Rows[z].SAC_CODE == null) {
			        document.getElementById('txtsrvcacc').value = "";
			    }
			    else {
			        $('txtsrvcacc').value = uomds.Tables[0].Rows[z].SAC_CODE;
			    }


			    if (uomds.Tables[0].Rows[z].SUB_SAC_CODE == null) {
			        document.getElementById('txtsubsrvcacc').value = "";
			    }
			    else {
			        $('txtsubsrvcacc').value = uomds.Tables[0].Rows[z].SUB_SAC_CODE;
			    }
			    
        /*new change ankur 16 feb*/
        document.getElementById('drpaddesc').value=uomds.Tables[0].Rows[z].uom_desc;
        
        
          /*new change ankur 22 feb*/
                    document.getElementById('drplogo').value=uomds.Tables[0].Rows[z].Logo;
                    if(uomds.Tables[0].Rows[z].Logo_Uom!=null)
                    {
			        document.getElementById('txtlogouom').value=uomds.Tables[0].Rows[z].Logo_Uom;
			        }
			        else
			        {
			         document.getElementById('txtlogouom').value="";
			        }
                    //////////////////
			    
			    updateStatus();
			    document.getElementById('btnnext').disabled=false;
			    document.getElementById('btnlast').disabled=false;
			    document.getElementById('btnfirst').disabled=false;
			    document.getElementById('btnprevious').disabled=false;
			 if( document.getElementById('btnModify').disabled==false)
			      document.getElementById('btnModify').focus();
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

function deleteclick()
{
		var txtuomcode=document.getElementById('txtuomcode').value;
		var txtuomdesc=document.getElementById('txtuomdesc').value;
		var txtalias=document.getElementById('txtalias').value;
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
        var adtype=document.getElementById('drpadtype').value;
        var uomtype = document.getElementById('drpuomtype').value;
        var acc_cd = document.getElementById('hdnsrvcacc').value;
        var sacc_cd = document.getElementById('hdnsubsrvcacc').value;
		if(confirm("Are You Sure Want To Delete The Data"))
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
       var ip2=document.getElementById('ip1').value;
UOM.deleteit(txtuomcode,compcode,userid,ip2);
			alert("Date Deleted Successfully");
			UOM.execute(glcode, gldesc, glalias, compcode, userid, gladtype, gluomtype, acc_cd,sacc_cd, call_delete);
			//UOM.first(call_delete);
		}
		return false;
}

function call_delete(response)
{
	uomds=response.value;
	//var ds=response.value;
	var a=uomds.Tables[0].Rows.length;
	var y=a-1;
	
	if( a <=0 )
	{
		alert("There Is No More Data To Be Deleted");
		document.getElementById('txtuomcode').value="";
		document.getElementById('txtuomdesc').value="";
		document.getElementById('txtalias').value="";
		
        /*new change ankur 16 feb*/
        document.getElementById('drpaddesc').value="";
		cancelclick('UOM');
		return false;
	}
	
	else if(z==-1 ||z>=a )
	{
		var txtuomcode=document.getElementById('txtuomcode').value=uomds.Tables[0].Rows[0].UOM_Code;
		var txtuomdesc=document.getElementById('txtuomdesc').value=uomds.Tables[0].Rows[0].UOM_Name;
		var txtalias=document.getElementById('txtalias').value=uomds.Tables[0].Rows[0].UOM_Alias;
		document.getElementById('drpadtype').value=uomds.Tables[0].Rows[0].Ad_Type;
		if (uomds.Tables[0].Rows[a].SAC_CODE == null) {
		    document.getElementById('txtsrvcacc').value = "";
		}
		else {
		    $('txtsrvcacc').value = uomds.Tables[0].Rows[a].SAC_CODE;
		}


		if (uomds.Tables[0].Rows[a].SUB_SAC_CODE == null) {
		    document.getElementById('txtsubsrvcacc').value = "";
		}
		else {
		    $('txtsubsrvcacc').value = uomds.Tables[0].Rows[a].SUB_SAC_CODE;
		}
        /*new change ankur 16 feb*/
        document.getElementById('drpaddesc').value=uomds.Tables[0].Rows[0].uom_desc;
        
          /*new change ankur 22 feb*/
                    document.getElementById('drplogo').value=uomds.Tables[0].Rows[0].Logo;
			        document.getElementById('txtlogouom').value=uomds.Tables[0].Rows[0].Logo_Uom;
			        if(uomds.Tables[0].Rows[0].sample_img_hm==null)
			    {
			        document.getElementById('txtSampleImg').value="";
			    }
			    else
			    {
			        document.getElementById('txtSampleImg').value=uomds.Tables[0].Rows[0].sample_img_hm;
			    }
    			
			    if(uomds.Tables[0].Rows[0].stylesheetname==null)
			    {
			        document.getElementById('txtStyleSheet').value="";
			    }
			    else
			    {
			        document.getElementById('txtStyleSheet').value=uomds.Tables[0].Rows[0].stylesheetname;
			    }
                    //////////////////
        setButtonImages();
		return false;
	}
	else
	{
		var txtuomcode=document.getElementById('txtuomcode').value=uomds.Tables[0].Rows[z].UOM_Code;
		var txtuomdesc=document.getElementById('txtuomdesc').value=uomds.Tables[0].Rows[z].UOM_Name;
		var txtalias=document.getElementById('txtalias').value=uomds.Tables[0].Rows[z].UOM_Alias;
		document.getElementById('drpadtype').value = uomds.Tables[0].Rows[z].Ad_Type;

        
		if (uomds.Tables[0].Rows[z].SAC_CODE == null) {
		    document.getElementById('txtsrvcacc').value = "";
		}
		else {
		    $('txtsrvcacc').value = uomds.Tables[0].Rows[z].SAC_CODE;
		}


		if (uomds.Tables[0].Rows[z].SUB_SAC_CODE == null) {
		    document.getElementById('txtsubsrvcacc').value = "";
		}
		else {
		    $('txtsubsrvcacc').value = uomds.Tables[0].Rows[z].SUB_SAC_CODE;
		}
        /*new change ankur 16 feb*/
        document.getElementById('drpaddesc').value=uomds.Tables[0].Rows[z].uom_desc;
          /*new change ankur 22 feb*/
                    document.getElementById('drplogo').value=uomds.Tables[0].Rows[z].Logo;
                    if(uomds.Tables[0].Rows[z].Logo_Uom!=null)
                    {
			        document.getElementById('txtlogouom').value=uomds.Tables[0].Rows[z].Logo_Uom;
			        }
			        else
			        {
			           document.getElementById('txtlogouom').value="";
			        }
			        if(uomds.Tables[0].Rows[z].sample_img_hm==null)
			    {
			        document.getElementById('txtSampleImg').value="";
			    }
			    else
			    {
			        document.getElementById('txtSampleImg').value=uomds.Tables[0].Rows[z].sample_img_hm;
			    }
    			
			    if(uomds.Tables[0].Rows[z].stylesheetname==null)
			    {
			        document.getElementById('txtStyleSheet').value="";
			    }
			    else
			    {
			        document.getElementById('txtStyleSheet').value=uomds.Tables[0].Rows[z].stylesheetname;
			    }
                    //////////////////
        
	}
	setButtonImages();
	return false;
}


function autoornot()
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
return false;
}


// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{
if(hiddentext=="new" )
			{
	
            uppercase3();
           
           }
            else
            {
            
            document.getElementById('txtuomdesc').value=document.getElementById('txtuomdesc').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

function uppercase3()
		{
		    if(document.getElementById('txtuomdesc').value!="")
                {
      document.getElementById('txtuomdesc').value=document.getElementById('txtuomdesc').value.toUpperCase();
      document.getElementById('txtuomdesc').value=trim(document.getElementById('txtuomdesc').value);


      
	  document.getElementById('txtalias').value=trim(document.getElementById('txtuomdesc').value);
		 str=document.getElementById('txtuomdesc').value;
		UOM.chkuomcode(str,fillcall);
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
		    alert("This UOM name has already assigned !! ");
		     document.getElementById('txtuomdesc').value="";
	           document.getElementById('txtalias').value="";
	
		    document.getElementById('txtuomdesc').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].UOM_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        var code=newstr;//.substr(2,4);
		                        code++;
		                        document.getElementById('txtuomcode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtuomcode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtuomcode').disabled=false;
        document.getElementById('txtuomdesc').value=document.getElementById('txtuomdesc').value.toUpperCase();
        document.getElementById('txtalias').value=document.getElementById('txtuomdesc').value;
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

return false;
}

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


function clearuom() {
    document.getElementById('btnNew').focus();
    givebuttonpermission('UOM');
    cancelclick('UOM');
}


  function chkenterndtab(event) {
  

   var key = event.keyCode ? event.keyCode : event.which;
   if (key == 13)
       if (document.activeElement.id == "drpadtype") {
       document.getElementById('drpuomtype').focus();
   } else
       if (document.activeElement.id == "drpuomtype") {
       document.getElementById('drpaddesc').focus();
   }
   else
       if (document.activeElement.id == "drpaddesc") {
           document.getElementById('drplogo').focus();
       }
       else
           if (document.activeElement.id == "drplogo") {
               document.getElementById('txtlogouom').focus();
       }
       else
           if (document.activeElement.id == "txtlogouom") {
               document.getElementById('txtuomdesc').focus();
       }
       else
           if (document.activeElement.id == "txtuomdesc") {
               document.getElementById('txtalias').focus();
       }
       else
           if (document.activeElement.id == "txtalias") {
               document.getElementById('txtSampleImg').focus();
       }
       else
           if (document.activeElement.id == "txtSampleImg") {
               document.getElementById('txtStyleSheet').focus();
           }
           else
               if (document.activeElement.id == "txtStyleSheet") {
                   document.getElementById('txtcol').focus();
           }
           else
               if (document.activeElement.id == "txtcol") {
                   document.getElementById('txtguttwid').focus();
           }
           else
               if (document.activeElement.id == "txtguttwid") {
                   document.getElementById('txtcolwid').focus();
           }
           else
               if (document.activeElement.id == "txtcolwid") {
                   document.getElementById('btnSave').focus();
           }
  }

  function fillservicecode(event) {
      var key = event.keyCode ? event.keyCode : event.which;
      if (key == 113) {
          if (document.activeElement.id == "txtsrvcacc") {
              $('lstservicecode').value = "";

              var pcompcode = $('hiddencompcode').value;
              var psac_code = "";
              var psac_name = $('txtsrvcacc').value;
              var pcreated_by = $('hiddenuserid').value;
              var pcode = "";
              var pfreez_flag = "";
              var pdateformat = $('hiddendateformat').value;
              var ptrn_type = "E";
              var extra1 = "";
              var extra2 = "";
              var extra3 = "";
              var extra4 = "";
              var extra5 = "";
              var extra6 = "";
              var extra7 = "";
              var extra8 = "";
              var extra9 = "";
              var extra10 = "";
              activeid = document.activeElement.id;
              aTag = eval(document.getElementById(activeid))
              var btag;
              var leftpos = 0;
              var toppos = 0;
              do {
                  aTag = eval(aTag.offsetParent);
                  leftpos += aTag.offsetLeft;
                  toppos += aTag.offsetTop;
                  btag = eval(aTag)
              } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
              var tot = document.getElementById('divservicecode').scrollLeft;
              var scrolltop = document.getElementById('divservicecode').scrollTop;
              document.getElementById('divservicecode').style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
              document.getElementById('divservicecode').style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";



              $("divservicecode").style.display = "block";


              $('lstservicecode').focus();
              UOM.fill_Service(pcompcode, psac_code, psac_name, pcreated_by, pcode, pfreez_flag, pdateformat, ptrn_type, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10, callback_fillservice)
          }
      }
      else if (event.keyCode == 8 || event.keyCode == 46) {
          $('txtsrvcacc').value = "";
          $('hdnsrvcacc').value = "";

          return false;
      }

      else if (event.ctrlKey == true && event.keyCode == 88) {
          $('txtsrvcacc').value = "";

          $('hdnsrvcacc').value = "";

          return false;
      }
      else if (event.keyCode == 9) {
          return event.keyCode;
      }

      return true;
  }

  function onclickservice(event) {
      var browser = navigator.appName;
      if (event.keyCode == 13 || event.type == "click") {
          if (document.activeElement.id == "lstservicecode") {
              if ($('lstservicecode').value == "0") {
                  $('txtsrvcacc').value = "";
                  $('hdnsrvcacc').value = "";
                  $("divservicecode").style.display = "none";
                  $('txtsrvcacc').focus();
                  return false;
              }
              $("divservicecode").style.display = "none";
              var page = $('lstservicecode').value;
              agencycodeglo = page;
              for (var k = 0; k <= $("lstservicecode").length - 1; k++) {
                  if ($('lstservicecode').options[k].value == page) {
                      if (browser != "Microsoft Internet Explorer") {
                          var abc = $('lstservicecode').options[k].textContent;
                      }
                      else {
                          var abc = $('lstservicecode').options[k].innerText;
                      }
                      //var abc=$('lstpubtyp').options[k].innerText;
                      var SPT = abc.split('~')
                      $('txtsrvcacc').value = SPT[0];
                      $('hdnsrvcacc').value = SPT[1];
                      $('txtsrvcacc').focus();
                      return false;
                  }
              }
          }
      }
      else if (event.keyCode == 27) {
          $('divservicecode').style.display = "none";
          $('txtsrvcacc').focus();
          return false;
      }
  }

  function callback_fillservice(res) {
      ds = res.value;
      if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {


          var pkgitem = $("lstservicecode");
          pkgitem.options.length = 0;
          pkgitem.options[0] = new Option("-Select Service Accounting Code-", "0");
          pkgitem.options.length = 1;

          for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
              pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].SAC_NAME + "~" + ds.Tables[0].Rows[i].SAC_CODE, ds.Tables[0].Rows[i].SAC_CODE);


              pkgitem.options.length;
          }
      }
      $("lstservicecode").value = "0";
      return false;
  }

  /////////////////////////////////new add for sub service code--kanishk--///////////////////////////////

  function fillsubservicecode(event) {

      if ($('txtsrvcacc').value == "") {
          alert("Please Select Service Acoounting Code");
          $('txtsrvcacc').focus();
          return false;
      }

      var key = event.keyCode ? event.keyCode : event.which;
      if (key == 113) {
          if (document.activeElement.id == "txtsubsrvcacc") {
              $('lstsubservicecode').value = "";

              var pcompcode = $('hiddencompcode').value;
              var pssac_code = "";
              var psac_code = $('hdnsrvcacc').value;
              var pssac_name = $('txtsubsrvcacc').value;
              var pcode = "";
              var pfreez_flag = "";
              var pcreated_by = $('hiddenuserid').value;
              var pdateformat = $('hiddendateformat').value;
              var ptrn_type = "E";
              var extra1 = "";
              var extra2 = "";
              var extra3 = "";
              var extra4 = "";
              var extra5 = "";
              var extra6 = "";
              var extra7 = "";
              var extra8 = "";
              var extra9 = "";
              var extra10 = "";
              activeid = document.activeElement.id;
              aTag = eval(document.getElementById(activeid))
              var btag;
              var leftpos = 0;
              var toppos = 0;
              do {
                  aTag = eval(aTag.offsetParent);
                  leftpos += aTag.offsetLeft;
                  toppos += aTag.offsetTop;
                  btag = eval(aTag)
              } while (aTag.tagName != "BODY" && aTag.tagName != "HTML");
              var tot = document.getElementById('divsubservicecode').scrollLeft;
              var scrolltop = document.getElementById('divsubservicecode').scrollTop;
              document.getElementById('divsubservicecode').style.left = document.getElementById(activeid).offsetLeft + leftpos - tot + "px";
              document.getElementById('divsubservicecode').style.top = document.getElementById(activeid).offsetTop + toppos - scrolltop + "px"; //"510px";



              $("divsubservicecode").style.display = "block";


              $('lstsubservicecode').focus();
              UOM.fill_subService(pcompcode, pssac_code, psac_code, pssac_name, pcode, pfreez_flag, pcreated_by, pdateformat, ptrn_type, extra1, extra2, extra3, extra4, extra5, extra6, extra7, extra8, extra9, extra10, callback_fillsubservice)
          }
      }
      else if (event.keyCode == 8 || event.keyCode == 46) {
          $('txtsubsrvcacc').value = "";
          $('hdnsubsrvcacc').value = "";

          return false;
      }

      else if (event.ctrlKey == true && event.keyCode == 88) {
          $('txtsubsrvcacc').value = "";

          $('hdnsubsrvcacc').value = "";

          return false;
      }
      else if (event.keyCode == 9) {
          return event.keyCode;
      }

      return true;
  }

  function onclicksubservice(event) {
      var browser = navigator.appName;
      if (event.keyCode == 13 || event.type == "click") {
          if (document.activeElement.id == "lstsubservicecode") {
              if ($('lstsubservicecode').value == "0") {
                  $('txtsubsrvcacc').value = "";
                  $('hdnsubsrvcacc').value = "";
                  $("divsubservicecode").style.display = "none";
                  $('txtsubsrvcacc').focus();
                  return false;
              }
              $("divsubservicecode").style.display = "none";
              var page = $('lstsubservicecode').value;
              agencycodeglo = page;
              for (var k = 0; k <= $("lstsubservicecode").length - 1; k++) {
                  if ($('lstsubservicecode').options[k].value == page) {
                      if (browser != "Microsoft Internet Explorer") {
                          var abc = $('lstsubservicecode').options[k].textContent;
                      }
                      else {
                          var abc = $('lstsubservicecode').options[k].innerText;
                      }
                      //var abc=$('lstpubtyp').options[k].innerText;
                      var SPT = abc.split('~')
                      $('txtsubsrvcacc').value = SPT[0];
                      $('hdnsubsrvcacc').value = SPT[1];
                      $('txtsubsrvcacc').focus();
                      return false;
                  }
              }
          }
      }
      else if (event.keyCode == 27) {
          $('divsubservicecode').style.display = "none";
          $('txtsubsrvcacc').focus();
          return false;
      }
  }

  function callback_fillsubservice(res) {
      ds = res.value;
      if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {


          var pkgitem = $("lstsubservicecode");
          pkgitem.options.length = 0;
          pkgitem.options[0] = new Option("-Select sub Service Accounting Code-", "0");
          pkgitem.options.length = 1;

          for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
              pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].SUB_SAC_NAME + "~" + ds.Tables[0].Rows[i].SUB_SAC_CODE, ds.Tables[0].Rows[i].SUB_SAC_CODE);


              pkgitem.options.length;
          }
      }
      $("lstsubservicecode").value = "0";
      return false;
  }