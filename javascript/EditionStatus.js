// JScript File
var hiddentext="load";
var global_ds="";
var row_num=0;
var chknamemod="";
var glpkgcode;
var glpkgstatus;
var gladtype;
var cityvar;


function e_NewClick()
{ 
    document.getElementById('drpPackageCode').disabled=false;
    document.getElementById('drpadtype').disabled=false;
    document.getElementById('drpStatus').disabled=false;
                     
    document.getElementById('drpPackageCode').value="0";
    document.getElementById('drpadtype').value="0";
    document.getElementById('drpStatus').value="0";     
    if( document.getElementById('drpadtype').disabled== false)
      document.getElementById('drpadtype').focus();
    hiddentext="new";
    Buttonenabledisable(); 
    setButtonImages();   
    return false;
}

function e_CancelClick()
{ 
    document.getElementById('drpPackageCode').value="0";
    document.getElementById('drpadtype').value="0";
    document.getElementById('drpStatus').value="0";     
    document.getElementById('drpPackageCode').disabled=true;
    document.getElementById('drpadtype').disabled=true;
    document.getElementById('drpStatus').disabled=true;
    
    hiddentext="cancel";
    Buttonenabledisable(); 
    setButtonImages();   
    return false;
}

function e_QueryClick()
{
    hiddentext="query";
    document.getElementById('drpPackageCode').disabled=false;
    document.getElementById('drpPackageCode').value="0";
    document.getElementById('drpadtype').disabled=false;
    document.getElementById('drpadtype').value="0";
    document.getElementById('drpStatus').disabled=false;
    document.getElementById('drpStatus').value="0";
    Buttonenabledisable();
    setButtonImages();
    return false;
}

function e_SaveClick()
{
    if(document.getElementById('drpadtype').value=="0" || document.getElementById('drpadtype').options.value==0)
    {
        alert('Please select Ad Type');
        document.getElementById('drpadtype').focus();
        return false;
    }
    if(document.getElementById('drpPackageCode').value=="0" || document.getElementById('drpPackageCode').options.value==0)
    {
        alert('Please select Package');
        document.getElementById('drpPackageCode').focus();
        return false;
    }
    if(document.getElementById('drpStatus').value=="0" || document.getElementById('drpStatus').options.value==0)
    {
        alert('Please select status');
        document.getElementById('drpStatus').focus();
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
    if(hiddentext=="new")
    {
      // hiddentext=="save";
        var compcode=document.getElementById('hiddencompcode').value;
        var userid=document.getElementById('hiddenuserid').value;
        var adtype=document.getElementById('drpadtype').value;
        var pkgcode=document.getElementById('drpPackageCode').value;
        var pkgstatus=document.getElementById('drpStatus').value;
        var chkExisting=EditionStatus.ExistingPkgStatus(compcode,adtype,pkgcode);
        var ds =chkExisting.value;
        if(chkExisting.value==null)
        {
            alert(chkExisting.error.description);
            return false;
        }
        if(ds.Tables[0].Rows.length >0)
        {
         alert("This package  is already assigned.");
         return false;
        }
        EditionStatus.savePackageStatus(compcode,userid,adtype,pkgcode,pkgstatus,"","");
        alert("Data Saved Successfully.");
           
    }
    if(hiddentext=="modify")
    {
        var compcode=document.getElementById('hiddencompcode').value;
        var userid=document.getElementById('hiddenuserid').value;
        var adtype=document.getElementById('drpadtype').value;
        var pkgcode=document.getElementById('drpPackageCode').value;
        var pkgstatus=document.getElementById('drpStatus').value;
        var recordid=document.getElementById('hiddenrecordid').value;
         if(chknamemod==document.getElementById('drpPackageCode').value)
           {
               EditionStatus.modifyPackageStatus(compcode,adtype,pkgcode,pkgstatus,recordid,"","");   
               alert("Data Modified Successfully."); 
               	document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnDelete').disabled=false;
				document.getElementById('btnsave').disabled=true;	
				document.getElementById('btnmodify').disabled=false;
				document.getElementById('btncancel').disabled=false;	
				document.getElementById('btnquery').disabled=false;	
                 if(row_num==0)
		        {
		        document.getElementById('btnfirst').disabled=true;				
		        document.getElementById('btnprevious').disabled=true;
		        }
		        if(row_num==global_ds.Tables[0].Rows.length-1)
		        {
		        document.getElementById('btnnext').disabled=true;					
		        document.getElementById('btnlast').disabled=true;
		        }
		        document.getElementById('drpadtype').disabled=true;
		        document.getElementById('drpPackageCode').disabled=true;
		        document.getElementById('drpStatus').disabled=true;
		        
               
           }
           else
           {
                var chkExisting=EditionStatus.ExistingPkgStatus(compcode,adtype,pkgcode);
                var ds =chkExisting.value;
                if(chkExisting.value==null)
                {
                    alert(chkExisting.error.description);
                    return false;
                }
                if(ds.Tables[0].Rows.length >0)
                {
                 alert("This entry is already assigned.");
                 return false;
                }
                
                EditionStatus.modifyPackageStatus(compcode,adtype,pkgcode,pkgstatus,recordid, "","");   
                alert("Data Modified Successfully."); 
                /*document.getElementById('btnNew').disabled=true;
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=false;
				document.getElementById('btnDelete').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;	*/	
										
				document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnDelete').disabled=false;
                 if(row_num==0)
		        {
		        document.getElementById('btnfirst').disabled=true;				
		        document.getElementById('btnprevious').disabled=true;
		        }
		        if(row_num==global_ds.Tables[0].Rows.length-1)
		        {
		        document.getElementById('btnnext').disabled=true;					
		        document.getElementById('btnlast').disabled=true;
		        }
		        document.getElementById('drpadtype').disabled=true;
		        document.getElementById('drpPackageCode').disabled=true;
		        document.getElementById('drpStatus').disabled=true;
                //return false; 
         }
      setButtonImages();
       return false;    
    }
    // Buttonenabledisable();
    e_CancelClick();
    setButtonImages();
    return false;    
}

function e_ModifyClick()
{
    document.getElementById('drpPackageCode').disabled=false;
    document.getElementById('drpadtype').disabled=false;
    document.getElementById('drpStatus').disabled=false;
    chknamemod= document.getElementById('drpPackageCode').value;
    hiddentext="modify";
    Buttonenabledisable(); 
    setButtonImages();   
    return false;
}

function e_DeleteClick()
{
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
         var compcode=document.getElementById('hiddencompcode').value;
        var userid=document.getElementById('hiddenuserid').value;
        var adtype=document.getElementById('drpadtype').value;
        var pkgcode=document.getElementById('drpPackageCode').value;
        EditionStatus.deletePackageStatus(compcode,adtype,pkgcode);  
        alert('Data Deleted Successfully.'); 
        //row_num;
        EditionStatus.bindEntry(compcode,gladtype,glpkgcode,glpkgstatus,delcall);
        return false;
    }

}

function delcall(responsed)
{
  
    global_ds= responsed.value;
	len=global_ds.Tables[0].Rows.length;
	
	if(global_ds.Tables[0].Rows.length==0)
	{
	    document.getElementById('drpadtype').value="0";
		document.getElementById('drpPackageCode').value="";
		document.getElementById('drpStatus').value="0";
		alert("No More Data is here to be deleted");
		e_CancelClick();
	 }
	else if(row_num==-1 ||row_num>=global_ds.Tables[0].Rows.length)
	{
		// bindpackage_All();
            if(global_ds.Tables[0].Rows[0].ad_type!=null)
               document.getElementById('drpadtype').value= global_ds.Tables[0].Rows[0].ad_type;
            else
               document.getElementById('drpadtype').value=""; 
               
            if(global_ds.Tables[0].Rows[0].packagecode!=null)
            {
                 cityvar=global_ds.Tables[0].Rows[0].packagecode;
                bindpackage(document.getElementById('drpadtype').value);
               document.getElementById('drpPackageCode').value= global_ds.Tables[0].Rows[0].packagecode;
               }
            else
               document.getElementById('drpPackageCode').value=""; 
               
            if(global_ds.Tables[0].Rows[0].status!=null)
               document.getElementById('drpStatus').value= global_ds.Tables[0].Rows[0].status;
            else
               document.getElementById('drpStatus').value=""; 
               setButtonImages();
		return false;
	}
	else
	{
	       // bindpackage_All();
            if(global_ds.Tables[0].Rows[row_num].ad_type!=null)
               document.getElementById('drpadtype').value= global_ds.Tables[0].Rows[row_num].ad_type;
            else
               document.getElementById('drpadtype').value=""; 
               
            if(global_ds.Tables[0].Rows[row_num].packagecode!=null)
            {
                cityvar=global_ds.Tables[0].Rows[row_num].packagecode;
                bindpackage(document.getElementById('drpadtype').value);
               document.getElementById('drpPackageCode').value= global_ds.Tables[0].Rows[row_num].packagecode;
               }
            else
               document.getElementById('drpPackageCode').value=""; 
               
            if(global_ds.Tables[0].Rows[row_num].status!=null)
               document.getElementById('drpStatus').value= global_ds.Tables[0].Rows[row_num].status;
            else
               document.getElementById('drpStatus').value=""; 
          setButtonImages();     
		return false;
	}
       
}

function e_ExecuteClick()
{
row_num=0;
    if(hiddentext=="query")
    {
        hiddentext="execute";
        var compcode=document.getElementById('hiddencompcode').value;
        var userid=document.getElementById('hiddenuserid').value;
        var adtype=document.getElementById('drpadtype').value;
        gladtype=adtype;
        var pkgcode=document.getElementById('drpPackageCode').value;
        glpkgcode=pkgcode
        var pkgstatus=document.getElementById('drpStatus').value;
        glpkgstatus=pkgstatus;
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
        var ds_1=EditionStatus.bindEntry(compcode,adtype,pkgcode,pkgstatus);
        if(ds_1.value==null)
        {
            alert(ds_1.error.description);
            return false;
        }
        global_ds=ds_1.value;
        if(global_ds.Tables[0].Rows.length==0)
        {
            alert('No record found');
            return false;
        }
        if(global_ds.Tables[0].Rows.length!=0)
        {
            //bindpackage_All();
            if(global_ds.Tables[0].Rows[row_num].ad_type!=null)
               document.getElementById('drpadtype').value= global_ds.Tables[0].Rows[row_num].ad_type;
            else
               document.getElementById('drpadtype').value=""; 
               
               cityvar=global_ds.Tables[0].Rows[row_num].packagecode;
               bindpackage(document.getElementById('drpadtype').value);
//            if(global_ds.Tables[0].Rows[row_num].packagecode!=null)
//               document.getElementById('drpPackageCode').value= global_ds.Tables[0].Rows[row_num].packagecode;
//            else
//               document.getElementById('drpPackageCode').value=""; 
               
            if(global_ds.Tables[0].Rows[row_num].status!=null)
               document.getElementById('drpStatus').value= global_ds.Tables[0].Rows[row_num].status;
            else
               document.getElementById('drpStatus').value=""; 
               
            document.getElementById('hiddenrecordid').value=global_ds.Tables[0].Rows[row_num].record_id;  
             document.getElementById('drpadtype').disabled=true;
             document.getElementById('drpPackageCode').disabled=true;
             document.getElementById('drpStatus').disabled=true;
                
            
        }
        Buttonenabledisable();
        document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
       if(global_ds.Tables[0].Rows.length==1)
       {
       document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
       } 
        
    }  
    setButtonImages();
    return false;  
}

function bind_controls()
{
    if(global_ds.Tables[0].Rows.length!=0)
    {
        if(global_ds.Tables[0].Rows[row_num].ad_type!=null)
           document.getElementById('drpadtype').value= global_ds.Tables[0].Rows[row_num].ad_type;
        else
           document.getElementById('drpadtype').value=""; 
            cityvar=global_ds.Tables[0].Rows[row_num].packagecode;
           bindpackage(global_ds.Tables[0].Rows[row_num].ad_type);
//        if(global_ds.Tables[0].Rows[row_num].packagecode!=null)
//           document.getElementById('drpPackageCode').value= global_ds.Tables[0].Rows[row_num].packagecode;
//        else
//           document.getElementById('drpPackageCode').value=""; 
           
        if(global_ds.Tables[0].Rows[row_num].status!=null)
           document.getElementById('drpStatus').value= global_ds.Tables[0].Rows[row_num].status;
        else
           document.getElementById('drpStatus').value=""; 
           
        document.getElementById('hiddenrecordid').value=global_ds.Tables[0].Rows[row_num].record_id;        
    }
}

function e_FirstClick()
{
    document.getElementById('btnfirst').disabled=true;
    document.getElementById('btnprevious').disabled=true;
    document.getElementById('btnnext').disabled=false;
    document.getElementById('btnlast').disabled=false;    
    row_num=0;    

    bind_controls();    
     
    if(document.getElementById('btnModify').disabled==false)
    {
        document.getElementById('btnModify').focus();
    }
    setButtonImages();
    return false;
}

function e_LastClick()
{
    document.getElementById('btnfirst').disabled=false;
    document.getElementById('btnprevious').disabled=false;
    document.getElementById('btnnext').disabled=true;
    document.getElementById('btnlast').disabled=true;
    
    row_num=global_ds.Tables[0].Rows.length-1;    

    bind_controls();  
     
    if(document.getElementById('btnModify').disabled==false)
    {
        document.getElementById('btnModify').focus();
    }
    setButtonImages();
    return false;
}
function e_PreviousClick()
{
    row_num--;
    if(row_num>=0)
        bind_controls();
    if(document.getElementById('btnModify').disabled==false)
    {
        document.getElementById('btnModify').focus();
    }   
   
    document.getElementById('btnnext').disabled=false;
    document.getElementById('btnlast').disabled=false;
    row_num=row_num-1;
    if(row_num>=0)
    {
        row_num=row_num+1;
        setButtonImages();
        return false;
    }
    else
    {
        document.getElementById('btnprevious').disabled=true;
        document.getElementById('btnfirst').disabled=true;
        row_num=row_num+1;
    }
    setButtonImages();
    return false;   
}
function e_NextClick()
{
    row_num=row_num+1;    
    document.getElementById('btnprevious').disabled=false;
    document.getElementById('btnfirst').disabled=false;
    
    if(row_num<global_ds.Tables[0].Rows.length)
       bind_controls();
     
          if(document.getElementById('btnModify').disabled==false)
    	  {
      	    document.getElementById('btnModify').focus();
		  }
    row_num=row_num+1;
    if(row_num<global_ds.Tables[0].Rows.length)
    {
        row_num=row_num-1;
        setButtonImages();
        return false;
    }
    else
    {
        document.getElementById('btnnext').disabled=true;
        document.getElementById('btnlast').disabled=true;
        row_num=row_num-1;
    }
    setButtonImages();
    return false;
}

function e_ExitClick()
{
    if(confirm("Do You Want To Skip This Page"))
    {	
        window.close();
        return false;
    }
    return false;
}
function bindpackage(adtyp)
{    
   if(typeof(adtyp)=="object")
    {
    var adtypecode=adtyp.value;
    }
    else
    {
    var adtypecode=adtyp;
    }
    
if(adtypecode !="0")
{
   // var adtypecode=document.getElementById('drpadtype').value;
    var compcode=document.getElementById('hiddencompcode').value;
    
     var ds_package=EditionStatus.addpackage1(compcode,adtypecode); 
     if(ds_package.value==null)
     {
        alert(ds_package.error.description);
        return false;
     }
     var pkgitem = document.getElementById("drpPackageCode");
     pkgitem.options[0]=new Option("--Select Package--","0");
     pkgitem.options.length = 1;
     for (var i = 0  ; i < ds_package.value.Tables[0].Rows.length; ++i)
     {
        pkgitem.options[pkgitem.options.length] = new Option(ds_package.value.Tables[0].Rows[i].Package_Name,ds_package.value.Tables[0].Rows[i].Combin_Code);        
        pkgitem.options.length;       
    } 
     if(cityvar == undefined || cityvar=="")
     {
        document.getElementById('drpPackageCode').value="0";
     
     }
     else
     {
          document.getElementById('drpPackageCode').value=cityvar;
          cityvar="";
     } 
  }
}

function bindpackage_All()
{    
    var adtypecode=document.getElementById('drpadtype').value;
    var compcode=document.getElementById('hiddencompcode').value;
    
     var ds_package=EditionStatus.addpackage1(compcode,adtypecode); 
     if(ds_package.value==null)
     {
        alert(ds_package.error.description);
        return false;
     }
     var pkgitem = document.getElementById("drpPackageCode");
     pkgitem.options[0]=new Option("--Select Package--","0");
     pkgitem.options.length = 1;
     for (var i = 0  ; i < ds_package.value.Tables[0].Rows.length; ++i)
     {
        pkgitem.options[pkgitem.options.length] = new Option(ds_package.value.Tables[0].Rows[i].Package_Name,ds_package.value.Tables[0].Rows[i].Combin_Code);        
        pkgitem.options.length;       
    } 
}

function Buttonenabledisable()
{
    var compcode=document.getElementById('hiddencompcode').value;
    var userid=document.getElementById('hiddenuserid').value;
    var res=EditionStatus.CheckPermission(compcode,userid,'');
    var ds1=res.value;
    if(ds1==null)
    {
        alert(res.error.description);
        return false;
    }
    if(ds1.Tables[0].Rows.length>0)
    {
        var id=ds1.Tables[0].Rows[0].Button_id;
    }
    
     if(hiddentext=="load")
    {
          
        document.getElementById('btnQuery').disabled=false;
        document.getElementById('btnExecute').disabled=true;
        document.getElementById('btnCancel').disabled=false;
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnSave').disabled=true;
        document.getElementById('btnModify').disabled=true;        
        document.getElementById('btnprevious').disabled=true;
        document.getElementById('btnExit').disabled=false;
         if(id==7 || id==15 || id==9 || id==11 || id==13 || id==1 || id==5 || id==3)
        {
             document.getElementById('btnNew').disabled = false;	
        }      
        else
        {
            document.getElementById('btnNew').disabled = true;	
        }
    }
    else if(hiddentext=="new")
    {
        if(id==7 || id==15 || id==9 || id==11 || id==13 || id==1 || id==5 || id==3)
        {
            document.getElementById('btnSave').disabled = false;	
         }   
        document.getElementById('btnNew').disabled = true;	
        document.getElementById('btnQuery').disabled=true;
        document.getElementById('btnExecute').disabled=true;
        
        document.getElementById('btnModify').disabled=true;
        document.getElementById('btnDelete').disabled=true;  
        document.getElementById('btnCancel').disabled=false;
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnnext').disabled=true;
        document.getElementById('btnlast').disabled=true;        
        document.getElementById('btnprevious').disabled=true;
        document.getElementById('btnExit').disabled=false;
      
    }
    else if(hiddentext=="cancel")
    {
        document.getElementById('btnSave').disabled = true;	
         if(id==7 || id==15 || id==11 || id==13 || id==9 || id==1 || id==5 || id==3)
        {
        document.getElementById('btnNew').disabled = false;	
        }
        document.getElementById('btnQuery').disabled=false;
        document.getElementById('btnExecute').disabled=true;
        
        document.getElementById('btnModify').disabled=true;
        document.getElementById('btnDelete').disabled=true;  
        document.getElementById('btnCancel').disabled=false;
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnnext').disabled=true;
        document.getElementById('btnlast').disabled=true;        
        document.getElementById('btnprevious').disabled=true;
        document.getElementById('btnExit').disabled=false;
    }
    else if(hiddentext=="query")
    {
        document.getElementById('btnSave').disabled = true;	
        document.getElementById('btnNew').disabled = true;	
        document.getElementById('btnQuery').disabled=true;
        document.getElementById('btnModify').disabled=true;
        document.getElementById('btnDelete').disabled=true;  
        document.getElementById('btnCancel').disabled=false;
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnnext').disabled=true;
        document.getElementById('btnlast').disabled=true;        
        document.getElementById('btnprevious').disabled=true;
        document.getElementById('btnExecute').disabled=false;
        document.getElementById('btnCancel').disabled=false;
        document.getElementById('btnExit').disabled=false;
        
    }
   else if(hiddentext=="execute")
    {
        document.getElementById('btnSave').disabled = true;	
        document.getElementById('btnNew').disabled = true;	
        document.getElementById('btnQuery').disabled=false;
         if(id==7 || id==15 || id==11 || id==14 || id==10 || id==2 || id==3 || id==6)
        {
        document.getElementById('btnModify').disabled=false;
        }
          if(id==7 || id==15 || id==13 || id==14 || id==12 || id==4 || id==5 || id==6)
        {
        document.getElementById('btnDelete').disabled=false;  
        }
        document.getElementById('btnCancel').disabled=false;
        document.getElementById('btnfirst').disabled=false;
        document.getElementById('btnnext').disabled=false;
        document.getElementById('btnlast').disabled=false;        
        document.getElementById('btnprevious').disabled=false;
        document.getElementById('btnExecute').disabled=true;
        document.getElementById('btnCancel').disabled=false;
        document.getElementById('btnExit').disabled=false;
        
    }
   else if(hiddentext=="modify")
    {
        document.getElementById('btnSave').disabled = false;	
        document.getElementById('btnNew').disabled = true;	
        document.getElementById('btnQuery').disabled=true;
        document.getElementById('btnModify').disabled=true;
        document.getElementById('btnDelete').disabled=true;  
        document.getElementById('btnCancel').disabled=false;
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnnext').disabled=true;
        document.getElementById('btnlast').disabled=true;        
        document.getElementById('btnprevious').disabled=true;
        document.getElementById('btnExecute').disabled=true;
        document.getElementById('btnCancel').disabled=false;
        document.getElementById('btnExit').disabled=false;
    }
   else  if(hiddentext=="save")
    {
        document.getElementById('btnSave').disabled = true;	
          if(id==7 || id==15 || id==11 || id==13 || id==9 || id==1)
        {
        document.getElementById('btnNew').disabled = false;	
        }
        document.getElementById('btnQuery').disabled=false;
        document.getElementById('btnModify').disabled=true;
        document.getElementById('btnDelete').disabled=true;  
        document.getElementById('btnCancel').disabled=false;
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnnext').disabled=true;
        document.getElementById('btnlast').disabled=true;        
        document.getElementById('btnprevious').disabled=true;
        document.getElementById('btnExecute').disabled=true;
        document.getElementById('btnCancel').disabled=false;
        document.getElementById('btnExit').disabled=false;
    }
    
     
		/*    if(id=="1"||id=="9")
		   {
			 document.getElementById('btnNew').disabled=false;
			 document.getElementById('btnDelete').disabled=true;
		     document.getElementById('btnSave').disabled=true;
			 document.getElementById('btnModify').disabled=true;
			   FlagStatus=1;
		   }
		   	if(id=="2"||id=="10")
		   {
			
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnSave').disabled=true;
			  FlagStatus=2;
	       }
		if(id=="3"||id=="11")
		{
			document.getElementById('btnNew').disabled=false;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnModify').disabled=true;		
			document.getElementById('btnSave').disabled=true;
			  FlagStatus=3;
			
		}
		if(id=="4"||id=="12" )
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnModify').disabled=true;	
			  FlagStatus=4;	
			
		}
		if(id=="5" ||id=="13")
		{
			document.getElementById('btnNew').disabled=false;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnModify').disabled=true;	
			  FlagStatus=5;	
			
		}
		if(id=="6"||id=="14")
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;		
			document.getElementById('btnDelete').disabled=true;
			FlagStatus = 6;
			
		}
		if(id=="7"||id=="15")
		{
			document.getElementById('btnNew').disabled=false;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			FlagStatus = 7;
			
		}*/
		
//		if(id==2||id==3)
//	{
//		document.getElementById('btnQuery').disabled=false;
//		document.getElementById('btnExecute').disabled=true;
//		document.getElementById('btnSave').disabled=true;
//		document.getElementById('btnModify').disabled=false;
//		document.getElementById('btnfirst').disabled=false;				
//		document.getElementById('btnnext').disabled=false;					
//		document.getElementById('btnprevious').disabled=false;			
//		document.getElementById('btnlast').disabled=false;
//		document.getElementById('btnDelete').disabled=true;
//	}
//	if(id==4 ||id==12)
//	{
//		document.getElementById('btnDelete').disabled=false;
//		document.getElementById('btnExecute').disabled=true;
//		document.getElementById('btnSave').disabled=true;
//		document.getElementById('btnQuery').disabled=false;
//		document.getElementById('btnModify').disabled=true;
//		document.getElementById('btnfirst').disabled=false;				
//		document.getElementById('btnnext').disabled=false;					
//		document.getElementById('btnprevious').disabled=false;			
//		document.getElementById('btnlast').disabled=false;
//	
//	}
//	if(id==5||id==13)
//	{
//		document.getElementById('btnDelete').disabled=false;
//		document.getElementById('btnExecute').disabled=true;
//		document.getElementById('btnSave').disabled=true;
//		document.getElementById('btnQuery').disabled=false;
//		document.getElementById('btnModify').disabled=true;
//		document.getElementById('btnfirst').disabled=false;				
//		document.getElementById('btnnext').disabled=false;					
//		document.getElementById('btnprevious').disabled=false;			
//		document.getElementById('btnlast').disabled=false;
//		
//	}
//	if(id==6||id==7||id==15)
//	{
//		document.getElementById('btnDelete').disabled=false;
//		document.getElementById('btnExecute').disabled=true;
//		document.getElementById('btnSave').disabled=true;
//		document.getElementById('btnQuery').disabled=false;
//		document.getElementById('btnModify').disabled=false;
//		document.getElementById('btnfirst').disabled=false;				
//		document.getElementById('btnnext').disabled=false;					
//		document.getElementById('btnprevious').disabled=false;			
//		document.getElementById('btnlast').disabled=false;
//		
//	}
//	if(id==1 || id==0 ||id==9)
//	{
//		document.getElementById('btnDelete').disabled=true;
//		document.getElementById('btnExecute').disabled=true;
//		document.getElementById('btnSave').disabled=true;
//		document.getElementById('btnQuery').disabled=false;
//		document.getElementById('btnModify').disabled=true;
//		document.getElementById('btnfirst').disabled=true;				
//		document.getElementById('btnnext').disabled=true;					
//		document.getElementById('btnprevious').disabled=true;			
//		document.getElementById('btnlast').disabled=true;
//		
//	}
	if(hiddentext=="load")
	{
	      document.getElementById('btnSave').disabled=true;
          document.getElementById('btnModify').disabled=true; 
	}
}

//-----------------------------------------------//
function chkstatus(FlagStatus)
{
	if(FlagStatus==0||FlagStatus==8)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnDelete').disabled=true;	
			document.getElementById('btnSave').disabled=true;	
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=true;
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=true;	
			alert("You Are Not Authorised To See This Form");
			return false;
					
		}
		if(FlagStatus==1||FlagStatus==9)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnDelete').disabled=true;	
			document.getElementById('btnSave').disabled=false;	
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;	
			return false;
		}
		if(FlagStatus==2||FlagStatus==10)
		{
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnModify').disabled=true;		
			document.getElementById('btnExit').disabled=false;		
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;	
			return false;
		
		}
		
		if(FlagStatus==3||FlagStatus==11)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnSave').disabled=false;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
		}
		
		if(FlagStatus==4||FlagStatus==12)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
		}
		if(FlagStatus==5||FlagStatus==13)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
		}
		if(FlagStatus==6||FlagStatus==14)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
		}
		if(FlagStatus==7||FlagStatus==15)
		{
			document.getElementById('btnNew').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;		
			
			
			document.getElementById('btnModify').disabled=true;		
			
			document.getElementById('btnSave').disabled=false;
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;		
		}
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

function clearedition() {
    e_CancelClick();
    Buttonenabledisable();
}