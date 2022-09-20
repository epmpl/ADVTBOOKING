// JScript File for Caption Master
//Declaration of Global Varible Funcion
var hiddentext;
var mod="0";
var z=0;
var name_modify="";
var gadtype;
var gcapname; 
var gcapcode;
var browser = navigator.appName;  

//Starting of Functions
function newclick()
{
    document.getElementById('drpadtype').value="0";
    document.getElementById('txtcaption').value="";
    document.getElementById('txtcapcode').value="";
    
    document.getElementById('drpadtype').disabled=false;
    document.getElementById('txtcaption').disabled=false;
    hiddentext="new";
    document.getElementById('btnSave').disabled = false;	
    document.getElementById('btnNew').disabled = true;	
    document.getElementById('btnQuery').disabled=true;
    setButtonImages();
	    return false;
}
function saveclick()
{
    var chmandat;
document.getElementById('txtcaption').value=trim(document.getElementById('txtcaption').value);
   
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat = document.getElementById('lbladtype').textContent;
        }
        else
        {
            chmandat = document.getElementById('lbladtype').innerText;
        }
        if (chmandat.indexOf('*') >= 0) {
            if (document.getElementById('drpadtype').value == "0" || document.getElementById('drpadtype').value == "") {
                alert("Please Select Ad Type");
                if (document.getElementById('drpadtype').disabled == false)
                    document.getElementById('drpadtype').focus();
                return false;
            }
        }
        if(browser!="Microsoft Internet Explorer")
        {
            chmandat = document.getElementById('lblcaption').textContent;
        }
        else
        {
            chmandat = document.getElementById('lblcaption').innerText;
        }
        if (chmandat.indexOf('*') >= 0) {
            if (document.getElementById('txtcaption').value == "") {
                alert("Please Select Caption");
                if (document.getElementById('txtcaption').disabled == false)
                    document.getElementById('txtcaption').focus();
                return false;
            }
        }
    var compcode=document.getElementById('hiddencompcode').value;
    var adtype=document.getElementById('drpadtype').value;
    var caption=document.getElementById('txtcaption').value;
    

//var res=CaptionMaster.chkname(compcode,pubname,catname,subcatname,refname);
//ds=res.value;

    if(mod !="1")
    {
//        if(ds.Tables[0].Rows.length !=0)
//        {
//        alert("This name is already assign");
//        document.getElementById('txtname').value="";
//        document.getElementById('txtname').focus();
//        return false;
//        }
//        else
//        {
        call_saveclick();
//        return false;
//        }
    }
    else
    {
//        if(name_modify==document.getElementById('txtname').value)
//			    {
//			        updatepubcat();
//			    }
//        else
//        {
//            if(ds.Tables[0].Rows.length > 1)
//            {
//            alert("This name is already assign");
//            document.getElementById('txtname').value="";
//            document.getElementById('txtname').focus();
//            return false;
//            }
//            else
            updatepubcat();
//        }
//    return false;
    }
    return false;
 }
function  updatepubcat()
{
    var compcode=document.getElementById('hiddencompcode').value;
    var adtype=document.getElementById('drpadtype').value;
    var caption=document.getElementById('txtcaption').value;
    var pcaptioncode=document.getElementById('txtcapcode').value;
    
     CaptionMaster.CAPTION_INS_UPD_DEL(compcode,adtype,caption,"U",pcaptioncode);
           // dscatexecute.Tables[0].Rows[z].CAPTION_CODE=document.getElementById('txtcapcode').value;
			dscatexecute.Tables[0].Rows[z].AD_TYPE=document.getElementById('drpadtype').value;
			dscatexecute.Tables[0].Rows[z].CAPTION_NAME=document.getElementById('txtcaption').value;
			
    alert("Data Updated Successfully");
        updateStatus();
        if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==(dscatexecute.Tables[0].Rows.length-1))
              {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
              }       

         document.getElementById('drpadtype').disabled=true;
         document.getElementById('txtcaption').disabled=true;
         setButtonImages();
			 if(document.getElementById('btnModify').disabled==false)      
	          document.getElementById('btnModify').focus();
	mod="0";
			return false;
}

function call_saveclick(response)
{

     var compcode=document.getElementById('hiddencompcode').value;
    var adtype=document.getElementById('drpadtype').value;
    var caption=document.getElementById('txtcaption').value;
    
    CaptionMaster.CAPTION_INS_UPD_DEL(compcode,adtype,caption,"I","");
    alert("Data Saved Successfully");
    
    document.getElementById('drpadtype').value="0";
    document.getElementById('txtcaption').value="";
    document.getElementById('txtcapcode').value="";
            
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
			
			cancelclick('CaptionMaster');
			return false;
}
function modifyclick()
{
     mod="1";
	 hiddentext="mod";	
	document.getElementById('btnQuery').disabled = true;
	document.getElementById('btnExecute').disabled=true;
	document.getElementById('btnModify').disabled=false;
	document.getElementById('btnSave').disabled = false;
	document.getElementById('btnSave').focus();
	
	name_modify=document.getElementById('txtcaption').value;
	    chkstatus(FlagStatus);
         document.getElementById('drpadtype').disabled=true;
         document.getElementById('txtcaption').disabled=false;
    setButtonImages();
return false;
}
function queryclick()
{
    document.getElementById('drpadtype').value=0;
    document.getElementById('txtcaption').value="";
    document.getElementById('txtcapcode').value="";
    z=0;
    document.getElementById('drpadtype').disabled=false;
    document.getElementById('txtcaption').disabled=false;
     
    document.getElementById('btnQuery').disabled=true;
	document.getElementById('btnExecute').disabled=false;
	document.getElementById('btnSave').disabled=true;
				hiddentext="query";
		setButtonImages();				
	document.getElementById('btnExecute').focus();
return false;
}
function executeclick()
{
z=0;
    var compcode=document.getElementById('hiddencompcode').value;
    
    var adtype=document.getElementById('drpadtype').value;
        gadtype=adtype;
    var caption=document.getElementById('txtcaption').value;
        gcapname=caption;
    var capcode=document.getElementById('txtcapcode').value;
        gcapcode=capcode;
    
CaptionMaster.execute(compcode,adtype,capcode,caption,callexec);
    updateStatus();
    
     document.getElementById('drpadtype').disabled=true;
     document.getElementById('txtcaption').disabled=true;
     
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
function callexec(response)
{
    var ds=response.value;
	dscatexecute=response.value;
	    if(dscatexecute.Tables[0].Rows.length > 0)
	    { 
			 	document.getElementById('txtcapcode').value=dscatexecute.Tables[0].Rows[0].CAPTION_CODE;
				document.getElementById('drpadtype').value=dscatexecute.Tables[0].Rows[0].AD_TYPE;
				document.getElementById('txtcaption').value=dscatexecute.Tables[0].Rows[0].CAPTION_NAME;
				
				document.getElementById('drpadtype').disabled=true;
                document.getElementById('txtcaption').disabled=true;
	    }
	    else
	    {
	        alert("Your Search Produce No Result!!!!");
			cancelclick('CaptionMaster');
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
function firstclick()
{

			 	document.getElementById('txtcapcode').value=dscatexecute.Tables[0].Rows[0].CAPTION_CODE;
				document.getElementById('drpadtype').value=dscatexecute.Tables[0].Rows[0].AD_TYPE;
				document.getElementById('txtcaption').value=dscatexecute.Tables[0].Rows[0].CAPTION_NAME;
				
				z=0;
			updateStatus();

		document.getElementById('btnCancel').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnnext').disabled=false;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnExit').disabled=false;
		//fillAdCat1();
		setButtonImages();
			return false;
}
function previousclick()
{
var a=dscatexecute.Tables[0].Rows.length;
		z--;
		if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
			  document.getElementById('txtcapcode').value=dscatexecute.Tables[0].Rows[z].CAPTION_CODE;
			  document.getElementById('drpadtype').value=dscatexecute.Tables[0].Rows[z].AD_TYPE;
		      document.getElementById('txtcaption').value=dscatexecute.Tables[0].Rows[z].CAPTION_NAME;
				
			updateStatus();
            document.getElementById('btnfirst').disabled=false;				
            document.getElementById('btnnext').disabled=false;				
            document.getElementById('btnprevious').disabled=false;				
            document.getElementById('btnlast').disabled=false;			
            document.getElementById('btnExit').disabled=false;
				//fillAdCat1();
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
function nextclick()
{
var a=dscatexecute.Tables[0].Rows.length;
	z++;
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
		 
		 	document.getElementById('txtcapcode').value=dscatexecute.Tables[0].Rows[z].CAPTION_CODE;
			document.getElementById('drpadtype').value=dscatexecute.Tables[0].Rows[z].AD_TYPE;
		    document.getElementById('txtcaption').value=dscatexecute.Tables[0].Rows[z].CAPTION_NAME;
		    updateStatus();
		    
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			//fillAdCat1();
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
function lastclick()
{
var y=dscatexecute.Tables[0].Rows.length;
			var a=y-1;
			z=a;

		 	document.getElementById('txtcapcode').value=dscatexecute.Tables[0].Rows[z].CAPTION_CODE;
			document.getElementById('drpadtype').value=dscatexecute.Tables[0].Rows[z].AD_TYPE;
		    document.getElementById('txtcaption').value=dscatexecute.Tables[0].Rows[z].CAPTION_NAME;
			
			updateStatus();
			//fillAdCat1();
		      document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
		setButtonImages();
			return false;
}
function exitclick()
{
//if(confirm("Do You Want To Skip This Page"))
			//{
				window.close();
				return false;
			//}
			//return false;
}
function deleteclick()
{
    updateStatus();
    var compcode=document.getElementById('hiddencompcode').value;
    var adtype=document.getElementById('drpadtype').value;
    var caption=document.getElementById('txtcaption').value;
    var pcaptioncode=document.getElementById('txtcapcode').value;
    
    if( confirm("Are You Sure To Delete The Data ?"));
    {
        CaptionMaster.CAPTION_INS_UPD_DEL(compcode,adtype,caption,"D",pcaptioncode);
        alert ("Data Deleted Successfully");
        document.getElementById('drpadtype').value="0";
        document.getElementById('txtcaption').value="";

       CaptionMaster.execute(compcode,gadtype,gcapcode,gcapname,delcall);
     }
		     return false;
}
function delcall(res)
{
 dscatexecute1= res.value;
	len=dscatexecute1.Tables[0].Rows.length;
	
	if(dscatexecute1.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		 cancelclick('CaptionMaster');
		return false;
	}
	        else if(z>=len || z==-1)
	        {
			
			 	document.getElementById('txtcapcode').value=dscatexecute.Tables[0].Rows[0].CAPTION_CODE;
			    document.getElementById('drpadtype').value=dscatexecute.Tables[0].Rows[0].AD_TYPE;
		        document.getElementById('txtcaption').value=dscatexecute.Tables[0].Rows[0].CAPTION_NAME;
        			
	        }
	        else
	        {
	         
			 	document.getElementById('txtcapcode').value=dscatexecute.Tables[0].Rows[z].CAPTION_CODE;
			    document.getElementById('drpadtype').value=dscatexecute.Tables[0].Rows[z].AD_TYPE;
		        document.getElementById('txtcaption').value=dscatexecute.Tables[0].Rows[z].CAPTION_NAME;
	        }
		if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==dscatexecute1.Tables[0].Rows.length)
              {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
              }       
            if(dscatexecute1.Tables[0].Rows.length ==1)
			{
		        document.getElementById('btnfirst').disabled=true;				
		       document.getElementById('btnnext').disabled=true;					
		        document.getElementById('btnprevious').disabled=true;			
		       document.getElementById('btnlast').disabled=true;
			}
	setButtonImages();
return false;
}
function cancelclick()
{
        document.getElementById('drpadtype').value="0";
        document.getElementById('txtcaption').value="";
        document.getElementById('txtcapcode').value="";
        
         document.getElementById('drpadtype').disabled=true;
         document.getElementById('txtcaption').disabled=true;
         
         document.getElementById('btnModify').disabled=true;
			    document.getElementById('btnQuery').disabled=false;
			    document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnSave').disabled=true;
				
				mod="0";
				
					//chkstatus(FlagStatus);
					
					
					
					if(document.getElementById('btnNew').disabled==false)
					{
					   
						document.getElementById('btnNew').focus();
					}
						
					else
					{
						document.getElementById('btnNew').disabled=false;
						document.getElementById('btnNew').focus();
						
					}
					//givebuttonpermission(formname);
					setButtonImages();
				return false;
}
//=========function to change image of buttons
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
function bindcat2(cat1)
{
var res2=PubCatRef.fillCat2(cat1);
ds1=res2.value;
var pkgitem = document.getElementById("drpadvcatcode");
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Sub Category--","0");
for (var i = 0  ; i < ds1.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds1.Tables[0].Rows[i].Adv_Subcat_Name,ds1.Tables[0].Rows[i].Adv_Subcat_Code);
        
       pkgitem.options.length;   
    }
}