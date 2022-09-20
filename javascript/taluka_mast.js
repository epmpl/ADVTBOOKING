//jscript file
 var  distcodeexe="";
 var  talcodeexe="";
 var  talnameexe="";
 var  talaliasexe="";
 var talonameexe="";
 var  frzexe="";
 var dsexe = "";
 var next=0;
  var modiflag=0;
  var hiddentext;
 var alrtdist;
 var alrttalname;
 var alrttalalias;
 var alrtnodeldata;
 var alrtexit;
 var alrtdel;
 var alrtmodi;
 var alrtsaved;
 var alrtconfdel;
 var alrtnodata;
var browser=navigator.appName;
var chknamemod;
var xmlDoc=null;
var xmlObj=null;

var req=null;


function loadXML(xmlFile)
{
//   var  httpRequest =null;
//   if(browser!="Microsoft Internet Explorer")
//    { 
//        
//        req = new XMLHttpRequest();
//        //alert(req);
//        req.onreadystatechange = getMessage;
//        req.open("GET",xmlFile, true);
//        req.send('');
//        
//    }
//   else
//    {
//       var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
//       xmlDoc.async="false";
//       xmlDoc.load(xmlFile);
      // xmlObj=xmlDoc.documentElement;
        // alert(xmlObj.childNodes(0).childNodes(0).text);
          
        $('hdnalert').value="Please enter District name.$~$Please enter taluka name.$~$Please enter taluka alias.$~$There is no more data to be deleted.$~$Do you want to skip this page?$~$Data deleted successfully.$~$Data updated successfully.$~$Data Saved successfully with taluka code $~$Are you sure! Do you want to delete this entry?$~$There is not available any entry regarding your Query.";//xmlObj.childNodes[4].childNodes[0].text;
        
        var alert1=$('hdnalert').value;
        var alert=alert1.split("$~$");
    
   
        //$('txt_compcode').title=xmlObj.childNodes[3].childNodes[0].text;
        //$('txt_compname').title=xmlObj.childNodes[3].childNodes[1].text;
        $('drpdistcode').title="DISTRICT Name";//xmlObj.childNodes[3].childNodes[2].text;
        $('txttaluka_code').title="TALUKA CODE";//xmlObj.childNodes[3].childNodes[3].text;
        $('txttaluka_name').title="TALUKA NAME";//xmlObj.childNodes[3].childNodes[4].text;
        $('txt_talukaalias').title="TALUKA ALIAS";//xmlObj.childNodes[3].childNodes[5].text;
        $('txt_talukaoname').title="TALUKA OTH. NAME";//xmlObj.childNodes[3].childNodes[6].text;
        //$('drpfrzflag').title=xmlObj.childNodes[3].childNodes[7].text;
    
         alrtdist=alert[0]
         alrttalname=alert[1]
         alrttalalias=alert[2]
         alrtnodeldata=alert[3]
         alrtexit=alert[4]
         alrtdel=alert[5]
         alrtmodi=alert[6]
         alrtsaved=alert[7]
         alrtconfdel=alert[8]
         alrtnodata=alert[9]
   // }

 }

function getMessage()
{
    var response="";
    if(req.readyState == 4)
        {
            if(req.status == 200)
            {
                response = req.responseText;
                //alert(response);
            }
        }
        
        var parser=new DOMParser();
        xmlDoc=parser.parseFromString(response,"text/xml"); 
        xmlObj=xmlDoc.documentElement;
}

function blankfields()
{

//txt_compcode
//txt_compname
//drpdistcode
//txttaluka_code
//txttaluka_name
//txt_talukaalias
//txt_talukaoname
//drpfrzflag


        document.getElementById('btnNew').disabled = false;
        document.getElementById('btnNew').focus();
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnModify').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnDelete').disabled = true;  
        //document.getElementById('txt_compcode').disabled=true;    
        //document.getElementById('txt_compname').disabled=true;    
        
        document.getElementById('drpdistcode').disabled=true;    
        document.getElementById('txttaluka_code').disabled=true;    
        document.getElementById('txttaluka_name').disabled=true;    
        document.getElementById('txt_talukaalias').disabled=true;    
        document.getElementById('txt_talukaoname').disabled=true;    
        //document.getElementById('drpfrzflag').disabled=true;    
        
        //document.getElementById('txt_compcode').value=document.getElementById('hiddencompcode').value;
        //document.getElementById('txt_compname').value=document.getElementById('hiddencompcode').value;
        
        document.getElementById('drpdistcode').value = "0";
        document.getElementById('txttaluka_code').value = "";
        document.getElementById('txttaluka_name').value = "";
        document.getElementById('txt_talukaalias').value = "";
        document.getElementById('txt_talukaoname').value = "";
        //document.getElementById('drpfrzflag').value = "0";
        //$('button4').style.display='none';
        
        loadXML("XML/taluka_mast.xml")
         return false;
}





function EnableOnNew()
{
        var msg=checkSession();
        if(msg==false)
        return false;
        
        hiddentext="new"
        modifyduplicacyalias="";
        modifyduplicacydesc="";
       /* document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnSave').disabled = false;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnModify').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnDelete').disabled = true;*/
       
                                
       
       
        //document.getElementById('txt_compcode').disabled = true;
        //document.getElementById('txt_compname').disabled = true;
        document.getElementById('drpdistcode').disabled = false;
        if((document.getElementById('hiddenauto').value=="1"))
          document.getElementById('txttaluka_code').disabled = true;
        else
        document.getElementById('txttaluka_code').disabled = false;
        
        document.getElementById('txttaluka_name').disabled = false;
        document.getElementById('txt_talukaalias').disabled = false;
        document.getElementById('txt_talukaoname').disabled = false;
        //document.getElementById('drpfrzflag').disabled = false;
        
        
        document.getElementById('drpdistcode').focus();
       
        //document.getElementById('Button4').disabled= true;
        $('Td14').style.display = 'none';
        $('view19').style.display = 'none';
        $('prepage').style.display='none';
        $('nextpage').style.display='none';
        $('next1').style.display='none';
        
        
        
          
        //document.getElementById('txt_compcode').value=document.getElementById('hiddencompcode').value;
        //document.getElementById('txt_compname').value=document.getElementById('hiddencompcode').value;
          
                                
                                
          
      if(document.getElementById('txttaluka_code').value!="")
      { 
      document.getElementById('txttaluka_code').value="";
      }
      if(document.getElementById('txttaluka_name').value!="")
      { 
      document.getElementById('txttaluka_name').value="";
      }
       if(document.getElementById('txt_talukaalias').value!="")
      { 
      document.getElementById('txt_talukaalias').value="";
      }
      
      if(document.getElementById('txt_talukaoname').value!="")
      { 
      document.getElementById('txt_talukaoname').value="";
      }
      
      document.getElementById('drpdistcode').value='0';
      //document.getElementById('drpfrzflag').value="N";
         chkstatus(FlagStatus);
		document.getElementById('btnSave').disabled = false;	
	    document.getElementById('btnNew').disabled = true;	
	    document.getElementById('btnQuery').disabled=true;
setButtonImages();
        return false;
}


function EnabledOnQuery()
{
hiddentext="query";

//dsexe="";
//        next=0;
        /*document.getElementById('btnNew').disabled = true;
        document.getElementById('btnQuery').disabled = true;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnExecute').disabled = false;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnModify').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnDelete').disabled = true;*/
      
        
       //document.getElementById('txt_compcode').disabled = true;
        //document.getElementById('txt_compname').disabled = true;
        document.getElementById('drpdistcode').disabled = false;
        document.getElementById('txttaluka_code').disabled = false;
        document.getElementById('txttaluka_name').disabled = false;
        document.getElementById('txt_talukaalias').disabled = false;
        document.getElementById('txt_talukaoname').disabled = false;
        //document.getElementById('drpfrzflag').disabled = false;
        
        
        //document.getElementById('txt_compcode').value=document.getElementById('hiddencompcode').value;
        //document.getElementById('txt_compname').value=document.getElementById('hiddencompcode').value;
        
        
        //document.getElementById('btnExecute').focus();
        //$('button4').disabled=true;
        $('Td14').style.display = 'none';
        $('view19').style.display = 'none';
        $('prepage').style.display = 'none';
        $('nextpage').style.display = 'none';
        $('next1').style.display='none';
        
        
        
     if(document.getElementById('txttaluka_code').value!="")
      { 
      document.getElementById('txttaluka_code').value="";
      }
      if(document.getElementById('txttaluka_name').value!="")
      { 
      document.getElementById('txttaluka_name').value="";
      }
       if(document.getElementById('txt_talukaalias').value!="")
      { 
      document.getElementById('txt_talukaalias').value="";
      }
      
      if(document.getElementById('txt_talukaoname').value!="")
      { 
      document.getElementById('txt_talukaoname').value="";
      }
      
      document.getElementById('drpdistcode').value='0';
      //document.getElementById('drpfrzflag').value='0';
        	chkstatus(FlagStatus);

			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;
			setButtonImages();
			document.getElementById('btnExecute').focus();
       return false;
}



function chkduplicacy()
{
        var msg=checkSession();
        if(msg==false)
        return false;
        
        var compval=trim($('hiddencompcode').value);
        var userid=trim($('hdnuserid').value);
        var dist=document.getElementById('drpdistcode').value;
        var t_code=trim(document.getElementById('txttaluka_code').value);
        var t_name=trim(document.getElementById('txttaluka_name').value.toUpperCase());
        var t_alias=trim(document.getElementById('txt_talukaalias').value);
        var t_othername=trim(document.getElementById('txt_talukaoname').value);
      if(document.getElementById('drpdistcode').value=="0")
          {
          alert("Please Select District");
          document.getElementById('drpdistcode').focus();
          return false;
          }
              
       if(document.getElementById('txttaluka_name').value=="")
          {
          alert("Please Enter Taluka Name");
          document.getElementById('txttaluka_name').focus();
          return false;
          }
       if(document.getElementById('txt_talukaalias').value=="")
          {
          alert("Please Enter Taluka Alias");
          document.getElementById('txt_talukaalias').focus();
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
          
          if(modiflag==1) 
          {
               if(chknamemod==trim(document.getElementById('txttaluka_name').value))
               {
                 //updatestate();
       
              taluka_mast.modify(compval,userid,dist,t_code,t_name,t_alias,t_othername,call_modify);
               }
               else
               {
                 taluka_mast.chktaluname(t_name,call_modifyclick);
                return false; 
               }
               
             taluka_mast.modify(compval,userid,dist,t_code,t_name,t_alias,t_othername,call_modify);
             alert("Data Modified Successfully");
             document.getElementById('drpdistcode').disabled=true;
              document.getElementById('txttaluka_name').disabled=true;
               document.getElementById('txt_talukaalias').disabled=true;
                document.getElementById('lbltaluka_code').disabled=true;
                 document.getElementById('btnfirst').disabled=false;				
				document.getElementById('btnnext').disabled=false;					
				document.getElementById('btnprevious').disabled=false;			
				document.getElementById('btnlast').disabled=false;
             if(next==0)
					{
					    document.getElementById('btnfirst').disabled=true;
					    document.getElementById('btnprevious').disabled=true;
					}
					else if(next==dsexe.Tables[0].Rows.length-1)
					{
					    document.getElementById('btnnext').disabled=true;
				    document.getElementById('btnlast').disabled=true;
					}
             if(dsexe.Tables[0].Rows.length==1)
             {
                document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;
             }
             
          }
          else
          {
          
           taluka_mast.chktalucode(compval,userid,dist,t_code,t_name,call_saveclick);
          
          }
      return false; 
}


function call_modifyclick(response)
{
        var compval=trim($('hiddencompcode').value);
        var userid=trim($('hdnuserid').value);
        var dist=document.getElementById('drpdistcode').value;
        var t_code=trim(document.getElementById('txttaluka_code').value);
        var t_name=trim(document.getElementById('txttaluka_name').value.toUpperCase());
        var t_alias=trim(document.getElementById('txt_talukaalias').value);
        var t_othername=trim(document.getElementById('txt_talukaoname').value);
        
         var ds=response.value;
		       if(chknamemod!=document.getElementById('txttaluka_name').value)
			   {
                if(ds.Tables[1].Rows.length >= 1)
                {
                    alert("This Taluka Name Already Exists.");
                    document.getElementById('txttaluka_name').value="";
                    document.getElementById('txt_talukaalias').value="";
                    return false;
                }
                 //updatestate();
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
taluka_mast.modify(compval,userid,dist,t_code,t_name,t_alias,t_othername,call_modify);
alert("Data Modified Successfully");
 document.getElementById('drpdistcode').disabled=true;
              document.getElementById('txttaluka_name').disabled=true;
               document.getElementById('txt_talukaalias').disabled=true;
                document.getElementById('lbltaluka_code').disabled=true;
                setButtonImages();
			}
}


//********************This Is The Responce Of The Save Button*******************//
//*******************************************************************************//
function call_saveclick(response)
{
			var ds=response.value;
			if(document.getElementById('txttaluka_code').value=="")
			{
			    alert("Please Enter Taluka Code");
			    if(document.getElementById('txttaluka_code').disabled==false)
				{
				    document.getElementById('txttaluka_code').focus();
				}
			    return false;
			}
			if(ds.Tables[0].Rows.length > 0)
			{
				alert("This Taluka Code Is Already Exist, Try Another Code !!!!");
				document.getElementById('txttaluka_code').value="";
				if(document.getElementById('txttaluka_code').disabled==false)
				{
				    document.getElementById('txttaluka_code').focus();
				    return false;
				}
				return false;
			} 
			
            if(ds.Tables[1].Rows.length > 0)
            {
                alert("This Taluka Name Is Already Assigned.");
                document.getElementById('txttaluka_name').value="";
                document.getElementById('txt_talukaalias').value="";
                document.getElementById('txttaluka_name').focus();
                return false;
            }
			else
			{
				var compval=document.getElementById('hiddencompcode').value;
				var dist=document.getElementById('drpdistcode').value;
                var t_code=trim(document.getElementById('txttaluka_code').value);
                var t_name=trim(document.getElementById('txttaluka_name').value);
                var t_alias=trim(document.getElementById('txt_talukaalias').value);
                var t_othername=trim(document.getElementById('txt_talukaoname').value);
				var userid=document.getElementById('hdnuserid').value;	

				 taluka_mast.save(compval,userid,dist,t_code,t_name,t_alias,t_othername)
//                if(browser!="Microsoft Internet Explorer")
//                {
//                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
//                }
//                else
//                {
//                    alert(xmlObj.childNodes(0).childNodes(0).text);
//                }
				alert("Data Saved Successfully");

				document.getElementById('txttaluka_code').value="";
				document.getElementById('txttaluka_name').value="";
				document.getElementById('txt_talukaalias').value="";
						
				document.getElementById('txttaluka_code').disabled=true;
				document.getElementById('txttaluka_name').disabled=true;
				document.getElementById('txt_talukaalias').disabled=true;
				
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
            ClearAll();
			return false;
}


function call_modify(response)
{
//         var ds=response.value;
//        if(chknamemod!=document.getElementById('txtcountryname').value)
//        {
//            if(ds.Tables[0].Rows.length!=0)
//            {
//                alert("This Country name has already assigned !! ");
//                document.getElementById('txtcountryname').value="";
//                document.getElementById('txtcountryname').focus();
//                return false;
//            }
//        }

//        
//                    var companycode=document.getElementById('hiddencomcode').value;
//                    var code=document.getElementById('txtcountrycode').value;
//                    var name=document.getElementById('txtcountryname').value;
//                    var alias=document.getElementById('txtcountryalias').value;
//                    var UserId=document.getElementById('hiddenuserid').value;	
//                    
//                    CountryMaster.Advmodify(companycode,code,name,alias,UserId); 
//			        
//			        if(dscountryexecute.Tables[0].Rows[z].Country_Code!=null)
//			        {
//			        dscountryexecute.Tables[0].Rows[z].Country_Code=document.getElementById('txtcountrycode').value;
//			        dscountryexecute.Tables[0].Rows[z].Country_Name=document.getElementById('txtcountryname').value;
//			        dscountryexecute.Tables[0].Rows[z].Country_Alias=document.getElementById('txtcountryalias').value;
//			        }
//					if(browser!="Microsoft Internet Explorer")
//                    {
//                        alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
//                    }
//                    else
//                    {
//                        alert(xmlObj.childNodes(0).childNodes(1).text);
//                    }
//					//alert("Data Modified Successfully");
//					updateStatus();
//					document.getElementById('txtcountrycode').disabled=true;
//					document.getElementById('txtcountryname').disabled=true;
//					document.getElementById('txtcountryalias').disabled=true;
//					
//				   /* document.getElementById('btnNew').disabled=true;
//					document.getElementById('btnSave').disabled=true;
//					document.getElementById('btnModify').disabled=false;
//					document.getElementById('btnDelete').disabled=false;
//					document.getElementById('btnQuery').disabled=false;
//					document.getElementById('btnExecute').disabled=true;
//					document.getElementById('btnCancel').disabled=false;		
//											
//					document.getElementById('btnfirst').disabled=false;				
//					document.getElementById('btnnext').disabled=false;					
//					document.getElementById('btnprevious').disabled=false;			
//					document.getElementById('btnlast').disabled=false;*/
//					updateStatus();
//					if(z==0)
//					{
//					    document.getElementById('btnfirst').disabled=true;
//					    document.getElementById('btnprevious').disabled=true;
//					}
//					else if(z==dscountryexecute.Tables[0].Rows.length-1)
//					{
//					    document.getElementById('btnnext').disabled=true;
//					    document.getElementById('btnlast').disabled=true;
//					}
//					
//					
//					mod="0";
                    //alert("Data Modified Successfully");
                     updateStatus();
                   // ClearAll();
             //   document.getElementById('btnSave').disabled = true;	
              document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                setButtonImages();
				if(document.getElementById('btnModify').disabled == false)				
			    document.getElementById('btnModify').focus();
                    return false;
        
}

//=============================================================================================///
//function checkforduplicacy(res)
//{

//dsd=res.value;
//if(dsd.Tables[0].Rows[0].NAME>="1" || dsd.Tables[0].Rows[0].ALIAS>="1")
//  {
// if(dsd.Tables[0].Rows[0].NAME>="1" && dsd.Tables[0].Rows[0].ALIAS>="1")
//       {
//           
//           if($('txttaluka_name').value==modifyduplicacydesc && $('txt_talukaalias').value==modifyduplicacyalias)
//                {
//                ModifyClass()
//                return false;
//                }
//          
//           else if ($('txttaluka_name').value==modifyduplicacydesc)
//           {
//              alert('The Taluka Alias of this name already exist.No Duplicacy is Allowed.')
//              $('txt_talukaalias').value="";
//              $('txt_talukaalias').value=modifyduplicacyalias;
//              modifyduplicacyalias=$('txt_talukaalias').value;
//              $('txt_talukaalias').focus();
//              return false;
//           }
//           
//           else if ($('txt_talukaalias').value==modifyduplicacyalias )
//           {
//           alert('The Taluka Description  of this name already exist.No Duplicacy is Allowed.')
//           $('txttaluka_name').value="";
//           $('txttaluka_name').value=modifyduplicacydesc;
//           modifyduplicacydesc=$('txttaluka_name').value;
//           $('txttaluka_name').focus();
//           return false;
//           }
//          
//          else
//           
//        {
//        alert('The Taluka Description and Taluka Alias of this name already exist.No Duplicacy is Allowed.')
//        $('txttaluka_name').value="";
//        $('txt_talukaalias').value="";
//        $('txttaluka_name').value=modifyduplicacydesc;
//        $('txt_talukaalias').value=modifyduplicacyalias;
//        modifyduplicacyalias=$('txt_talukaalias').value;
//        modifyduplicacydesc=$('txttaluka_name').value;
//        $('txttaluka_name').focus();
//        return false;
//        }
//     }
// else if (dsd.Tables[0].Rows[0].NAME>="1")
//      {
//      
//      if($('txttaluka_name').value==modifyduplicacydesc)
//                {
//                ModifyClass()
//                return false;
//                }
//       else
//       {
//      
//          alert('The Taluka Description  of this name already exist.No Duplicacy is Allowed.')
//          $('txttaluka_name').value="";
//          $('txttaluka_name').value=modifyduplicacydesc;
//          $('txttaluka_name').focus();
//          return false;
//        }
//      }
// else if (dsd.Tables[0].Rows[0].ALIAS>="1")
//      {
//      
//            if($('txt_talukaalias').value==modifyduplicacyalias)
//                {
//                ModifyClass();
//                return false;
//                }
//                
//             else
//              {
//              alert('The Taluka Alias of this name already exist.No Duplicacy is Allowed.')
//              $('txt_talukaalias').value="";
//              $('txt_talukaalias').focus();
//              return false;
//              }
//      }
// }


//    else if (document.getElementById('btnSave').disabled ==false)
//    {
//        if (modiflag==1)
//            {
//            ModifyClass();
//            return false;
//            }
//        else
//            {
//            generatecode();
//            return false;
//            }
//    }


//}



//function generatecode()
//{
//var compcode = document.getElementById('hiddencompcode').value;                         
//taluka_mast.Autogeneratecode($('hiddencompcode').value,"","","",callback_Savetaluka)
//return false;                                                                        
//}


function Exit()
{
//if(confirm('want to exit??'))
       if(confirm(alrtexit))
       {
         window.close();
         return false;
       }
   return false;
   
}

function ClearAll()
{
//dsexe="";
 hiddentext="clear";
                chkstatus(FlagStatus);
				givebuttonpermission('taluka_mast');
        next=0;
     /*   document.getElementById('btnNew').disabled = false;
        document.getElementById('btnNew').focus();
        document.getElementById('btnQuery').disabled = false;
        document.getElementById('btnCancel').disabled = false;
        document.getElementById('btnExit').disabled = false;
        document.getElementById('btnSave').disabled = true;
        document.getElementById('btnExecute').disabled = true;
        document.getElementById('btnfirst').disabled = true;
        document.getElementById('btnlast').disabled = true;
        document.getElementById('btnModify').disabled = true;
        document.getElementById('btnprevious').disabled = true;
        document.getElementById('btnnext').disabled = true;
        document.getElementById('btnDelete').disabled = true;  */    
                        

        
        //document.getElementById('txt_compcode').disabled= true;
        //document.getElementById('txt_compname').disabled= true;
        document.getElementById('drpdistcode').disabled= true;
        document.getElementById('txttaluka_code').disabled= true;
        document.getElementById('txttaluka_name').disabled= true;
        document.getElementById('txt_talukaalias').disabled =true;
        document.getElementById('txt_talukaoname').disabled= true;
        //document.getElementById('drpfrzflag').disabled= true;
        
        //document.getElementById('Button4').disabled= true;
        
          $('Td14').style.display = 'none';
          $('view19').style.display = 'none';
          $('prepage').style.display='none';
          $('nextpage').style.display='none';
          $('next1').style.display='none';
          modiflag=0;
          
      //document.getElementById('txt_compcode').value=document.getElementById('hiddencompcode').value;
      //document.getElementById('txt_compname').value=document.getElementById('hiddencompcode').value;

      if(document.getElementById('txttaluka_code').value!="")
      { 
      document.getElementById('txttaluka_code').value="";
      }
      if(document.getElementById('txttaluka_name').value!="")
      { 
      document.getElementById('txttaluka_name').value="";
      }
      if(document.getElementById('txt_talukaalias').value!="")
      { 
      document.getElementById('txt_talukaalias').value="";
      }
      if(document.getElementById('txt_talukaoname').value!="")
      { 
      document.getElementById('txt_talukaoname').value="";
      }
      
      if(document.getElementById('drpdistcode').value!="")
      { 
      document.getElementById('drpdistcode').value="0";
      }
      
//      if(document.getElementById('drpfrzflag').value!="")
//      { 
//      document.getElementById('drpfrzflag').value="0";
//      }
      //	if(document.getElementById('btnNew').disable==false)
	      document.getElementById('btnNew').focus();
      setButtonImages();
     return false;
   }
   
   
   function chksplchar(a,b)
{
	var result="false";
	var code="abcdefghijklmnopqrstuvwxyz0123456789"
	var myval=b;
	code=code.toLowerCase()
	myval=myval.toLowerCase()
	for(i=0;i<=myval.length-1;i++)
	{
		for(j=0;j<=code.length-1;j++)
		{
			if(myval.charAt(i)==code.charAt(j))
			{
				result="true";
				break;
			}
		}
	}
	if(myval.length=="0")
	{
	     return "true";
	}
	if(result=="false")
	{
	
     alert('You cannot enter special character in the text field');
	 $(a).focus();
	 return false
	
                    }
	
	else
	{
	    return b;
	}
}
   
   
//function callback_Savetaluka(res)
//{
//   ds = res.value;
//   
//   
// if(modiflag==1)
//   {
//       ModifyClass();
//       return false;
//   }
//   else
//   {
//   
//    
//     
//     var compcode = "'"+document.getElementById('hiddencompcode').value+"'";
//     var uid = "'"+document.getElementById('hdnuserid').value+"'";
//     
//     var str = document.getElementById('tblfields').value;
//     var str1=str.split("$~$");
//     var tablename = str1[str1.length-2];
//    
//     var action = str1[str1.length-1];
//     var finalaction = action.split("#");
//     var insert = finalaction[0];
//     var update = finalaction[1];
//     var del = finalaction[2];
//     var select = finalaction[3];
//     
//     
//      


// 
//     
//    
//    
//    if($('drpdistcode').value=="0")
//        {
//        //alert('enter district')
//        alert(alrtdist)
//        $('drpdistcode').focus();
//        return false;
//        }
//        
//        
//        
//     else if(trim($('txttaluka_name').value)=="")
//     {
//     alert(alrttalname)
//     $('txttaluka_name').value="";
//     $('txttaluka_name').focus();
//     
////     document.getElementById('txttaluka_name').focus();
////     document.getElementById('txttaluka_name').select();
//     return false;
//     }
//     
//     else if(trim($('txt_talukaalias').value)=="")
//     {
//     
//     alert(alrttalalias)
//     $('txt_talukaalias').value="";
//     $('txt_talukaalias').focus();
////     document.getElementById('txt_distname').focus();
////     document.getElementById('txt_distname').select();
//     return false;
//     }
//     
//     
////     else if(trim($('txt_talukaoname').value)=="")
////     {
////     $('txt_talukaoname').value="";
////     
////     }
//                              var nma=trim($('txttaluka_name').value);
//                                     nma=chksplchar ($('txttaluka_name').id,nma.substring(0,1))
//                                                  if(nma==false)
//                                                    {
//                                                    
//                                                    return false;
//                                                    }
//                                                    
//                            
////                            var nma=trim($('txt_talukaoname').value);
////                                    nma=chksplchar ($('txt_talukaoname').id,nma.substring(0,1))
////                                                  if(nma==false)
////                                                    {
////                                                    
////                                                    return false;
////                                                    }
//                                                    
//                            var nma=trim($('txt_talukaalias').value);
//                                    nma=chksplchar ($('txt_talukaalias').id,nma.substring(0,1))
//                                                  if(nma==false)
//                                                    {
//                                                    
//                                                    return false;
//                                                    }
//                                                    
//                                                    
//                                                         
//    $('txttaluka_name').value=trim($('txttaluka_name').value);
//    $('txt_talukaoname').value=trim($('txt_talukaoname').value);
//    $('txt_talukaalias').value=trim($('txt_talukaalias').value);
//     
//        
//        document.getElementById('btnSave').focus();
//     
//     
//        //document.getElementById('txt_compcode').value=document.getElementById('hiddencompcode').value;
//        //document.getElementById('txt_compname').value=document.getElementById('hiddencompcode').value;
//       
//                                   
//        var talcode = ds.Tables[0].Rows[0].VAR_CODE;
//        var casetalcode=talcode.toUpperCase();
//        
//        var distcode = "'"+document.getElementById('drpdistcode').value+"'";
//        var casedistcode=distcode.toUpperCase();
//        
//        
//        var talname = "'"+document.getElementById('txttaluka_name').value+"'";
//        var casetalname=talname.toUpperCase();
//        
//        
//        var talalias = "'"+document.getElementById('txt_talukaalias').value+"'";
//        var casetalalias=talalias.toUpperCase();
//        
//        var taloname = "'"+document.getElementById('txt_talukaoname').value+"'";
//        //var casetaloname=taloname.toUpperCase();
//       var casetaloname=taloname;
//       
////       if ($('drpfrzflag').value=="0")
////         {
////         var frz="'N'";
////         }
////       else
////         {
////         var frz= "'"+document.getElementById('drpfrzflag').value+"'";
////         }
//        
//        
//        var finalval=compcode+"$~$"+casedistcode+"$~$"+"'"+casetalcode+"'"+"$~$"+casetalname+"$~$"+casetalalias+"$~$"+casetaloname+"$~$"+uid+"$~$"+frz;
//        
//        
//        var fi=document.getElementById('tblfields').value.replace("$~$"+tablename,"")
//        fi=fi.replace("$~$"+action,"")
//        
//        taluka_mast.save_tal(fi,finalval,tablename,insert,"","","")
//        
//      
//        // alert('saved');
//        
//        $('txttaluka_code').value=talcode;
//        alert(alrtsaved +casetalcode);


//            blankfields();

//                  
//        //$('txt_compcode').disabled = true;
//        //$('txt_compname').disabled = true;
//        $('drpdistcode').disabled = true;
//        $('txttaluka_code').disabled = true;
//        $('txttaluka_name').disabled = true;
//        $('txt_talukaalias').disabled = true;
//        $('txt_talukaoname').disabled = true;
//        //$('drpfrzflag').disabled = true;
//        
//       

//        return false;
//       }
//    }
    
    
    
    function EnableExecute()
{
var msg=checkSession();
    if(msg==false)
    return false;
// var newnext = next;

       // next=0;
     
      /*  $('btnNew').disabled = true;
        $('btnQuery').disabled = false;
        $('btnCancel').disabled = false;
        $('btnExit').disabled = false;
        $('btnSave').disabled = true;
        $('btnExecute').disabled = true;
        $('btnfirst').disabled = true;
        $('btnlast').disabled = false;
        $('btnModify').disabled = false;
        $('btnprevious').disabled = true;
        $('btnnext').disabled = false;
        $('btnDelete').disabled = false;*/
        
         //$('txt_compcode').disabled = true;
        //$('txt_compname').disabled = true;
        $('drpdistcode').disabled = true;
        $('txttaluka_code').disabled = true;
        $('txttaluka_name').disabled = true;
        $('txt_talukaalias').disabled = true;
        $('txt_talukaoname').disabled = true;
        //$('drpfrzflag').disabled = true;
        if(document.getElementById('btnModify').disabled==false)					
		   document.getElementById('btnModify').focus();
        
        //document.getElementById('txt_compcode').value=document.getElementById('hiddencompcode').value;
        //document.getElementById('txt_compname').value=document.getElementById('hiddencompcode').value;
        
        
        //document.getElementById('Button4').disabled= false;
        
        //$('Button4').style.display ='block';
     
      
        var compcode = document.getElementById('hiddencompcode').value;
        //var uid = "'"+document.getElementById('hdnuserid').value+"'";
        
        var str = $('executefields').value;
        var str1=str.split("$~$");
        var tablename = str1[str1.length-2];
       
        var action = str1[str1.length-1];
        var finalaction = action.split("#");
        var insert = finalaction[0];
        var update = finalaction[1];
        var del = finalaction[2];
        var select = finalaction[3];

         if ($('drpdistcode').value=="0")
         {
         distcodeexe="";
         }
         else
         {
         distcodeexe= document.getElementById('drpdistcode').value;
         }
        
//        distcodeexe = "'"+document.getElementById('drpdistcode').value+"'";
//        var casedistcodeexe=distcodeexe.toUpperCase();
        
       talcodeexe = document.getElementById('txttaluka_code').value;
        var casetalcodeexe=talcodeexe.toUpperCase();
        
//        var distcodeexe = "'"+document.getElementById('drpdistcode').value+"'";
//        var casedistcode=distcode.toUpperCase();
        
        
        talnameexe = document.getElementById('txttaluka_name').value;
        var casetalnameexe=talnameexe.toUpperCase();
        
        
        talaliasexe = document.getElementById('txt_talukaalias').value;
        var casetalaliasexe=talaliasexe.toUpperCase();
        
        talonameexe = document.getElementById('txt_talukaoname').value;
       // var casetalonameexe=talonameexe.toUpperCase();
        var casetalonameexe=talonameexe;
//        if ($('drpfrzflag').value=="0")
//         {
//         frzexe="''";
//         }
//         else
//         {
//         frzexe= "'"+document.getElementById('drpfrzflag').value+"'";
//         }
        
        var colname="";
         colname=str.replace("$~$"+action,"")
         var ficolname=colname.replace("$~$"+tablename,"")
         ficolname=ficolname
        
         var fi=$('executefields').value.replace("$~$"+tablename,"");
         fi=fi.replace("$~$"+action,"");
         fi=fi+"$~$";
       
        var finalval=compcode+"$~$"+distcodeexe+"$~$"+casetalcodeexe+"$~$"+casetalnameexe+"$~$"+casetalaliasexe+"$~$"+casetalonameexe+"$~$"+frzexe+"$~$";
        var talexe=taluka_mast.tal_execute(compcode,distcodeexe,talcodeexe,talnameexe,talaliasexe,talonameexe)
        
        updateStatus();
        	document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
		if(document.getElementById('btnModify').disabled==false)					
		   document.getElementById('btnModify').focus();
        callback_exec(talexe);
        return false;
    

}

  // var stcd="";

	function callback_exec(res)
	{
	
	record_show=5
    record_show1=1
	next=0;
    dsexe=res.value;
   //if 
   
   if(dsexe==null)
	{
	    alert(response.error.description);
	    return false;
	}    
    if(dsexe.Tables[0].Rows.length==1)
    
    {       
    if(dsexe.Tables[0].Rows[next].DIST_CODE==null)
	{
	$('drpdistcode').value="";
    }
	else
	{
	$('drpdistcode').value=dsexe.Tables[0].Rows[next].DIST_CODE
    }


	if(dsexe.Tables[0].Rows[next].TALU_CODE==null)
	{
	$('txttaluka_code').value="";
    }
	else
	{
	$('txttaluka_code').value=dsexe.Tables[0].Rows[next].TALU_CODE
    }
    
    
	if(dsexe.Tables[0].Rows[next].TALU_NAME==null)
	{
	$('txttaluka_name').value="";
    }
	else
	{
	$('txttaluka_name').value=dsexe.Tables[0].Rows[next].TALU_NAME
    }
   

	if(dsexe.Tables[0].Rows[next].TALU_ALIAS==null)
	{	
	$('txt_talukaalias').value="";  
    }
	else
	{
	$('txt_talukaalias').value=dsexe.Tables[0].Rows[next].TALU_ALIAS   
    }
    
//    if(dsexe.Tables[0].Rows[next].FREEZE_FLAG==null)
//	{	
//	$('drpfrzflag').value="";  
//    }
//	else
//	{
//	$('drpfrzflag').value=dsexe.Tables[0].Rows[next].FREEZE_FLAG   
//    }
    
    if(dsexe.Tables[0].Rows[next].TALU_ONAME==null)
	{	
	$('txt_talukaoname').value="";  
    }
	else
	{
	$('txt_talukaoname').value=dsexe.Tables[0].Rows[next].TALU_ONAME   
    }
    
   
    
    
    
   $('btnfirst').disabled = true;
	$('btnlast').disabled = true;
	$('btnprevious').disabled = true;
	$('btnnext').disabled = true;
	//$('next1').displayed=true;
    
    }
   //else if  
    else if(dsexe.Tables[0].Rows.length>0)
    {       
    if(dsexe.Tables[0].Rows[next].DIST_CODE==null)
	{
	$('drpdistcode').value="";
    }
	else
	{
	$('drpdistcode').value=dsexe.Tables[0].Rows[next].DIST_CODE
    }



	if(dsexe.Tables[0].Rows[next].TALU_CODE==null)
	{
	$('txttaluka_code').value="";
    }
	else
	{
	$('txttaluka_code').value=dsexe.Tables[0].Rows[next].TALU_CODE
    }
    
    
    if(dsexe.Tables[0].Rows[next].TALU_NAME==null)
	{
	$('txttaluka_name').value="";
    }
	else
	{
	$('txttaluka_name').value=dsexe.Tables[0].Rows[next].TALU_NAME
    }

	if(dsexe.Tables[0].Rows[next].TALU_ALIAS==null)
	{	
	$('txt_talukaalias').value="";  
    }
	else
	{
	$('txt_talukaalias').value=dsexe.Tables[0].Rows[next].TALU_ALIAS   
    }
    
//    if(dsexe.Tables[0].Rows[next].FREEZE_FLAG==null)
//	{	
//	$('drpfrzflag').value="";  
//    }
//	else
//	{
//	$('drpfrzflag').value=dsexe.Tables[0].Rows[next].FREEZE_FLAG   
//    }
    
    if(dsexe.Tables[0].Rows[next].TALU_ONAME==null)
	{	
	$('txt_talukaoname').value="";  
    }
	else
	{
	$('txt_talukaoname').value=dsexe.Tables[0].Rows[next].TALU_ONAME   
    }
    
   
    setButtonImages();
    return false;
	
	}
	 

        
	else
	{
    alert(alrtnodata);
	alert('no data according to search criteria');
//	$('btnfirst').disabled = true;
//	$('btnlast').disabled = true;
//	$('btnprevious').disabled = true;
//	$('btnnext').disabled = true;
//	$('next1').disabled=true;
	ClearAll();
	return false;
	}
	setButtonImages();
} 	


function trim(stringToTrim) 
 {
    //return this.replace(/^\s+|\s+$/g, "");

	return stringToTrim.replace(/^\s+|\s+$/g,"");
 }

function replacecomma(str)
{
    if(str!="" && str!="undefined")
    {
        if(str.indexOf("'")>="0")
        {
            while(str.indexOf("'")>="0")
            {
                str=str.replace("'","''");
                return str;
            }
         }
         else
        {
         return str;
        }
    }
    else
    {
         return str;
    }
        
}





function Find_NextRecord()
{
var msg=checkSession();
    if(msg==false)
    return false;
record_show=5
    record_show1=1
   next++;
   var record= dsexe.Tables[0].Rows.length;
     
     if(next<=record && next>=0)
     {
           if(dsexe.Tables[0].Rows.length != next && next !=-1)
			{
			
			
			   
			      document.getElementById('drpdistcode').value = dsexe.Tables[0].Rows[next].DIST_CODE;
                  document.getElementById('txttaluka_code').value= dsexe.Tables[0].Rows[next].TALU_CODE;
                 
                
                if(dsexe.Tables[0].Rows[next].TALU_ONAME==null)
	            {
	            $('txt_talukaoname').value="";
                }
	            else
	            {
	            $('txt_talukaoname').value=dsexe.Tables[0].Rows[next].TALU_ONAME
                }
                  
                 document.getElementById('txttaluka_name').value= dsexe.Tables[0].Rows[next].TALU_NAME;
                  document.getElementById('txt_talukaalias').value= dsexe.Tables[0].Rows[next].TALU_ALIAS;
                  //document.getElementById('drpfrzflag').value= dsexe.Tables[0].Rows[next].FREEZE_FLAG;
                 // document.getElementById('txt_talukaoname').value= dsexe.Tables[0].Rows[next].TALU_ONAME;
                 updateStatus();
			    document.getElementById('btnnext').disabled=false;
			    document.getElementById('btnlast').disabled=false;
			    document.getElementById('btnfirst').disabled=false;
			    document.getElementById('btnprevious').disabled=false;
           

               //document.getElementById('txt_compcode').value=document.getElementById('hiddencompcode').value;
                //document.getElementById('txt_compname').value=document.getElementById('hiddencompcode').value;
                document.getElementById('drpdistcode').disabled = true;
                document.getElementById('txttaluka_code').disabled = true;
                document.getElementById('txttaluka_name').disabled = true;
                document.getElementById('txt_talukaalias').disabled = true;
                //document.getElementById('drpfrzflag').disabled = true;
                document.getElementById('txt_talukaoname').disabled = true;
       
        
        //document.getElementById('Button4').disabled= false;
        
            
            $('Td14').style.display = 'none';
           $('view19').style.display = 'none';
           $('prepage').style.display = 'none';
           $('nextpage').style.display = 'none';
           $('next1').style.display='none';
                  
			}
	    else
	    {
			    document.getElementById('btnnext').disabled=true;
			    document.getElementById('btnlast').disabled=true;
			    document.getElementById('btnfirst').disabled=false;
			    document.getElementById('btnprevious').disabled=false;
			    return false
	    }
     }
     else
	{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
			return false;
	}
     if(next==record-1 )
     {


        	document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
               

         document.getElementById('drpdistcode').disabled = true;
        document.getElementById('txttaluka_code').disabled = true;
        document.getElementById('txttaluka_name').disabled = true;
        document.getElementById('txt_talukaalias').disabled = true;
        //document.getElementById('drpfrzflag').disabled = true;
        document.getElementById('txt_talukaoname').disabled = true;
          $('btnprevious').focus();
                  
     }
     setButtonImages();
   return false;
   
}

function Find_PreRecord()
{
var msg=checkSession();
    if(msg==false)
    return false;
record_show=5
    record_show1=1
   next--;
   
    var record= dsexe.Tables[0].Rows.length;
     if(next>record)
		{
					document.getElementById('btnfirst').disabled=false;				
						document.getElementById('btnnext').disabled=true;					
						document.getElementById('btnprevious').disabled=false;			
						document.getElementById('btnlast').disabled=true;
						return false;
				
				$('Td14').style.display = 'none';
                $('view19').style.display = 'none';
                $('prepage').style.display = 'none';
               $('nextpage').style.display = 'none';
               $('next1').style.display='none';
				
				return false;
				
		}
     
     
     if(next!=-1 && next>=0)
     
		{
		if(dsexe.Tables[0].Rows.length != next)
		{
		
		
			     //document.getElementById('txt_compcode').value=document.getElementById('hiddencompcode').value;
                 //document.getElementById('txt_compname').value=document.getElementById('hiddencompcode').value;
			     document.getElementById('drpdistcode').value = dsexe.Tables[0].Rows[next].DIST_CODE;
                 document.getElementById('txttaluka_name').value= dsexe.Tables[0].Rows[next].TALU_NAME;
                  
                  
                if(dsexe.Tables[0].Rows[next].TALU_ONAME==null)
	            {
	            $('txt_talukaoname').value="";
                }
	            else
	            {
	            $('txt_talukaoname').value=dsexe.Tables[0].Rows[next].TALU_ONAME
                }
                 document.getElementById('txttaluka_code').value= dsexe.Tables[0].Rows[next].TALU_CODE;
                  document.getElementById('txt_talukaalias').value= dsexe.Tables[0].Rows[next].TALU_ALIAS;
                  //document.getElementById('drpfrzflag').value= dsexe.Tables[0].Rows[next].FREEZE_FLAG;
                 updateStatus();
				document.getElementById('btnfirst').disabled=false;				
		        document.getElementById('btnnext').disabled=false;				
		        document.getElementById('btnprevious').disabled=false;				
		        document.getElementById('btnlast').disabled=false;			
		        document.getElementById('btnExit').disabled=false;
                  
                  	                  
			}
			else
			{
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=false;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=false;
				return false;
			}
     }
     else
		{
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
				return false;
		}
     if (next<=0)
     {
            document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;
			return false;
           
     }
     
      setButtonImages();
   return false;
   
}


function Find_Firstrecord()
{
var msg=checkSession();
    if(msg==false)
    return false;
record_show=5
record_show1=1
next=0;
                                              
                                    
                                              
          
          //document.getElementById('txt_compcode').value=document.getElementById('hiddencompcode').value;
          //document.getElementById('txt_compname').value=document.getElementById('hiddencompcode').value;
          document.getElementById('drpdistcode').value = dsexe.Tables[0].Rows[next].DIST_CODE;
          
                if(dsexe.Tables[0].Rows[next].TALU_ONAME==null)
	            {
	            $('txt_talukaoname').value="";
                }
	            else
	            {
	            $('txt_talukaoname').value=dsexe.Tables[0].Rows[next].TALU_ONAME
                }
                
                  document.getElementById('txttaluka_name').value= dsexe.Tables[0].Rows[next].TALU_NAME;
                  document.getElementById('txttaluka_code').value= dsexe.Tables[0].Rows[next].TALU_CODE;
                  document.getElementById('txt_talukaalias').value= dsexe.Tables[0].Rows[next].TALU_ALIAS;
                  //document.getElementById('drpfrzflag').value= dsexe.Tables[0].Rows[next].FREEZE_FLAG;
          	updateStatus();
          document.getElementById('btnnext').disabled = false;
          document.getElementById('btnfirst').disabled = true;
          document.getElementById('btnprevious').disabled = true;
          document.getElementById('btnlast').disabled=false;
          //document.getElementById('Button4').disabled= false;
          
          $('Td14').style.display = 'none';
          $('view19').style.display = 'none';
          $('prepage').style.display = 'none';
       $('nextpage').style.display = 'none';
       $('next1').style.display='none';
         $('btnnext').focus();
          setButtonImages();
          
          return false;
}


function Find_Lastrecord()
{
var msg=checkSession();
    if(msg==false)
    return false;
record_show=5
    record_show1=1
    var record=dsexe.Tables[0].Rows.length;
		 next=record-1;
		 record=record-1;
          //document.getElementById('txt_compcode').value=document.getElementById('hiddencompcode').value;
          //document.getElementById('txt_compname').value=document.getElementById('hiddencompcode').value;
          document.getElementById('drpdistcode').value = dsexe.Tables[0].Rows[next].DIST_CODE;
          
          
          if(dsexe.Tables[0].Rows[next].TALU_ONAME==null)
	            {
	            $('txt_talukaoname').value="";
                }
	            else
	            {
	            $('txt_talukaoname').value=dsexe.Tables[0].Rows[next].TALU_ONAME
                }
                
                
                  document.getElementById('txttaluka_name').value= dsexe.Tables[0].Rows[next].TALU_NAME;
                  document.getElementById('txttaluka_code').value= dsexe.Tables[0].Rows[next].TALU_CODE;
                  document.getElementById('txt_talukaalias').value= dsexe.Tables[0].Rows[next].TALU_ALIAS;
                  //document.getElementById('drpfrzflag').value= dsexe.Tables[0].Rows[next].FREEZE_FLAG;

         updateStatus();
		document.getElementById('btnnext').disabled=true;
		document.getElementById('btnlast').disabled=true;
		document.getElementById('btnfirst').disabled=false;
		document.getElementById('btnprevious').disabled=false;
        //document.getElementById('Button4').disabled= false;
        
        
        $('Td14').style.display = 'none';
        $('view19').style.display = 'none';
        $('prepage').style.display = 'none';
       $('nextpage').style.display = 'none';
       $('next1').style.display='none';
         $('btnprevious').focus();
setButtonImages();
   return false;

}


var modifyduplicacydesc;
var modifyduplicacyalias;

function Modify_Records()
{
   modiflag=1;
hiddentext="modify";
    
//        $('btnNew').disabled = true;
//        $('btnQuery').disabled = true;
//        $('btnCancel').disabled = false;
//        $('btnExit').disabled = false;
        $('btnSave').disabled = false;
//        $('btnExecute').disabled = true;
        $('btnfirst').disabled = true;
        $('btnlast').disabled = true;
        $('btnModify').disabled = true;
        $('btnprevious').disabled = true;
        $('btnnext').disabled = true;
        $('btnDelete').disabled = true;
        $('prepage').style.display ='none';
        $('nextpage').style.display ='none';
        $('next1').style.display ='none';
        $('Td14').style.display = 'none';
        $('view19').style.display = 'none';
        //$('button4').disabled=true;
        
        chknamemod=document.getElementById('txttaluka_name').value;	                                 
        
        //document.getElementById('txt_compcode').value=document.getElementById('hiddencompcode').value;
        //document.getElementById('txt_compname').value=document.getElementById('hiddencompcode').value;
        document.getElementById('drpdistcode').disabled = false;
        document.getElementById('txttaluka_code').disabled = true;
        document.getElementById('txttaluka_name').disabled = false;
        document.getElementById('txt_talukaalias').disabled = false;
        //document.getElementById('drpfrzflag').disabled = false;
        document.getElementById('txt_talukaoname').disabled = false;
        
        
         modifyduplicacydesc=$('txttaluka_name').value;
        modifyduplicacyalias=$('txt_talukaalias').value;
       setButtonImages();
        $('btnSave').focus();
        
         
   return false;
}




/////////////////////////////////////////////modify class///////////////////////////////////////////////////////

function ModifyClass()
{
modiflag=1;
var str = $('tblfields').value;
var str1=str.split("$~$");
var tablename = str1[str1.length-2];
var action = str1[str1.length-1];
var finalaction = action.split("#");
var insert = finalaction[0];
var update = finalaction[1];
var del = finalaction[2];
var select = finalaction[3];


var str2 = $('deltblfields').value;
var str3=str2.split("$~$");
var modcolname="";
var modtblname=str3[str3.length-1];
modcolname=str2.replace("$~$"+modtblname,"")
modcolname=str2+"$~$";


 if($('drpdistcode').value=="0")
        {
        //alert('enter district')
        alert(alrtdist)
        $('drpdistcode').focus();
        return false;
        }
        
     else if($('txttaluka_name').value=="")
     {
     //alert('enter taluka name')
     alert(alrttalname)
     $('txttaluka_name').value="";
     $('txttaluka_name').focus();
     return false;
     }
     
     else if($('txt_talukaalias').value=="")
     {
     //alert('enter taluka alias')
     alert(alrttalalias)
     $('txt_talukaalias').value="";
     $('txt_talukaalias').focus();
     return false;
     }


                            var nma=trim($('txttaluka_name').value);
                                     nma=chksplchar ($('txttaluka_name').id,nma.substring(0,1))
                                                  if(nma==false)
                                                    {
                                                    
                                                    return false;
                                                    }
                                                    
                            
//                            var nma=trim($('txt_talukaoname').value);
//                                    nma=chksplchar ($('txt_talukaoname').id,nma.substring(0,1))
//                                                  if(nma==false)
//                                                    {
//                                                    
//                                                    return false;
//                                                    }
                                                    
                            var nma=trim($('txt_talukaalias').value);
                                    nma=chksplchar ($('txt_talukaalias').id,nma.substring(0,1))
                                                  if(nma==false)
                                                    {
                                                    
                                                    return false;
                                                    }
                                                    
                                                    
                                                                                
    $('txttaluka_name').value=trim($('txttaluka_name').value);
    $('txt_talukaoname').value=trim($('txt_talukaoname').value);
    $('txt_talukaalias').value=trim($('txt_talukaalias').value);
     


                                  
 
 var compcode = "'"+trim($('hiddencompcode').value)+"'";
 var uid="'"+trim($('hdnuserid').value)+"'";

//     if ($('drpfrzflag').value=="0")
//     {
//     var frz="'N'";
//     }
//     else
//     {
//     var frz= "'"+document.getElementById('drpfrzflag').value+"'";
//     }
     
     
     
     
     var talcode = "'"+trim($('txttaluka_code').value)+"'";
     var casetalcode=talcode.toUpperCase();
     
     var talname= "'"+trim($('txttaluka_name').value)+"'";
     var casetalname=talname.toUpperCase();
     
     
     var talalias = "'"+trim($('txt_talukaalias').value)+"'";
     var casetalalias=talalias.toUpperCase();
     
     var taloname = "'"+trim($('txt_talukaoname').value)+"'";
     //var casetaloname=taloname.toUpperCase();
     var casetaloname=taloname;
     
     var distcode = "'"+trim($('drpdistcode').value)+"'";
     
     
    
     var finalval = compcode+"$~$"+distcode+"$~$"+casetalcode+"$~$"+casetalname+"$~$"+casetalalias+"$~$"+casetaloname+"$~$"+uid+"$~$"+frz+"$~$"; 
    
    var fi=$('tblfields').value.replace("$~$"+tablename,"")
        fi=fi.replace("$~$"+action,"");
        fi = fi+"$~$";

    var wherecondition=talcode+"$~$"+compcode;


   
    
    
   
   //taluka_mast.tal_modify(fi, finalval,tablename,update,modcolname,"","","")
         //alert('modified')
         alert(alrtmodi)
         modiflag="";
         
//         if ($('drpfrzflag').value=="0")
//         {
//         document.getElementById('drpfrzflag').value="N";
//        }
         
         
       
        $('btnModify').disabled = false;
        $('btnQuery').disabled = false;
        $('btnCancel').disabled = false;
        $('btnExit').disabled = false;
        $('btnDelete').disabled = false;
        $('btnSave').disabled = true;
        if(document.getElementById('btnModify').value==false) 
        $('btnModify').focus();
        
         
       //document.getElementById('txt_compcode').disabled=true;    
        //document.getElementById('txt_compname').disabled=true;    
        
        document.getElementById('drpdistcode').disabled=true;    
        document.getElementById('txttaluka_code').disabled=true;    
        document.getElementById('txttaluka_name').disabled=true;    
        document.getElementById('txt_talukaalias').disabled=true;    
        document.getElementById('txt_talukaoname').disabled=true;    
        //document.getElementById('drpfrzflag').disabled=true;    
        
        //document.getElementById('txt_compcode').value=document.getElementById('hiddencompcode').value;
        //document.getElementById('txt_compname').value=document.getElementById('hiddencompcode').value;
        
       
 blankfields();
    
        
}


 function Delete_Record()
{
var msg=checkSession();
    if(msg==false)
    return false;
$('Td14').style.display = 'none';
       $('view19').style.display = 'none';
       $('prepage').style.display = 'none';
       $('nextpage').style.display = 'none';
       $('next1').style.display='none';
       //document.getElementById('Button4').disabled= true;
//document.getElementById('txt_compcode').value=document.getElementById('hiddencompcode').value;
//document.getElementById('txt_compname').value=document.getElementById('hiddencompcode').value;
var str = $('tblfields').value;
var str1=str.split("$~$");
//var tablename = str1[str1.length-2];
var action = str1[str1.length-1];
var finalaction = action.split("#");
var insert = finalaction[0];
var update = finalaction[1];
var del = finalaction[2];
var select = finalaction[3];


var str2 = $('deltblfields').value;
var str3=str2.split("$~$");
var delcolname="";
var deltblname=str3[str3.length-1];
    
delcolname=str2.replace("$~$"+deltblname,"")
delcolname=delcolname+"$~$";
       
       
        
        var compcode = document.getElementById('hiddencompcode').value;
        var uid = document.getElementById('hdnuserid').value;
                                                                    
                                                            
        
        
       var distcode = trim($('drpdistcode').value);
       var talcode = trim($('txttaluka_code').value);
       var talname = trim($('txttaluka_name').value);
       var talalias = trim($('txt_talukaalias').value);
      // var frz = "'"+trim($('drpfrzflag').value)+"'";
       var taloname = trim($('txt_talukaoname').value);
                                               
                                               
                                               
       
        
        var fi=$('tblfields').value.replace("$~$"+tablename,"")
        fi=fi.replace("$~$"+action,"");
        fi=fi+"$~$";
        
      
        
        var finalval = compcode+"$~$"+distcode+"$~$"+talcode+"$~$"+talname+"$~$"+talalias+"$~$"+taloname+"$~$"+uid+"$~$"+frz+"$~$"; 
        
        
        var delcolvalue=talcode+"$~$"+uid+"$~$"+compcode+"$~$";
        
        //boolReturn = confirm('want to delete??');
        boolReturn = confirm(alrtconfdel);
   
       if (boolReturn==1)
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
taluka_mast.tal_delete(talcode);
       
       //alert('deleted')
       alert(alrtdel)
       
       

 
 
         var str = $('executefields').value;
        var str1=str.split("$~$");
        var tablename = str1[str1.length-2];
       
        var action = str1[str1.length-1];
        var finalaction = action.split("#");
        var insert = finalaction[0];
        var update = finalaction[1];
        var del = finalaction[2];
        var select = finalaction[3];
        


        
        var compcode = document.getElementById('hiddencompcode').value;
        var uid = document.getElementById('hdnuserid').value;
        
        var taloname = talonameexe;
        var casetaloname=taloname.toUpperCase();
        
        var talcode = talcodeexe;
        var casetalcode=talcode.toUpperCase();
        
        var talname = talnameexe;
        var casetalname=talname.toUpperCase();
        
        
        
        var talalias = talaliasexe;
        var casetalalias=talalias.toUpperCase();
        
        var frz = frzexe;
       
       var distcode=distcodeexe;
       
        
        var colname="";
        colname=str.replace("$~$"+action,"")
        var ficolname=colname.replace("$~$"+tablename,"")
        ficolname=ficolname
        
        var fi=$('executefields').value.replace("$~$"+tablename,"")
        fi=fi.replace("$~$"+action,"");
        fi=fi+"$~$";
        
        var finalval=compcode+"$~$"+distcode+"$~$"+casetalcode+"$~$"+casetalname+"$~$"+casetalalias+"$~$"+casetaloname+"$~$"+frz+"$~$";
        
        
        
        taluka_mast.tal_execute(compcode,distcodeexe,talcodeexe,talnameexe,talaliasexe,talonameexe,callback_delete)
        
        return false;
	
		}
		else
		{
		if(document.getElementById('btnModify').value==false) 
		   $('btnModify').focus();
		}
    
 

   
   return false;
}



/////////////////////////////////////callback delete work/////////////////////////////////////////////////////////

function callback_delete(response)
{
next;
  dsexe = response.value;
  var length_del = dsexe.Tables[0].Rows.length;
  var a=length_del-1;
  
   
  if(length_del<=0)
      {
      //alert('no data to delete');
      alert(alrtnodeldata);
         ClearAll();
         return false;
        
      }
      

      
   else if(next==-1 || next>= length_del)
      {
          //document.getElementById('txt_compcode').value=document.getElementById('hiddencompcode').value;
          //document.getElementById('txt_compname').value=document.getElementById('hiddencompcode').value;
          document.getElementById('drpdistcode').value = dsexe.Tables[0].Rows[0].DIST_CODE;
          document.getElementById('txttaluka_code').value= dsexe.Tables[0].Rows[0].TALU_CODE;
          document.getElementById('txttaluka_name').value= dsexe.Tables[0].Rows[0].TALU_NAME;
          document.getElementById('txt_talukaalias').value= dsexe.Tables[0].Rows[0].TALU_ALIAS;
          //document.getElementById('drpfrzflag').value= dsexe.Tables[0].Rows[0].FREEZE_FLAG;
          document.getElementById('txt_talukaoname').value= dsexe.Tables[0].Rows[0].TALU_ONAME;
          if(document.getElementById('btnModify').value==false) 
         $('btnModify').focus();
      
      
          
          
          
                    
          
          if(next==length_del)
          {
                     document.getElementById('btnnext').disabled = false;
                     document.getElementById('btnlast').disabled = false;
                     document.getElementById('btnfirst').disabled=true;
                     document.getElementById('btnprevious').disabled=true;
                     next=0;
                //     $('btnModify').focus();
          return false;
          }
          
           next=0;
                    
          return false;
       }
          
          
  else if ( next==length_del-1)
  {
          //document.getElementById('txt_compcode').value=document.getElementById('hiddencompcode').value;
          //document.getElementById('txt_compname').value=document.getElementById('hiddencompcode').value;
          document.getElementById('drpdistcode').value = dsexe.Tables[0].Rows[next].DIST_CODE;
          document.getElementById('txttaluka_code').value= dsexe.Tables[0].Rows[next].TALU_CODE;
          document.getElementById('txttaluka_name').value= dsexe.Tables[0].Rows[next].TALU_NAME;
          document.getElementById('txt_talukaalias').value= dsexe.Tables[0].Rows[next].TALU_ALIAS;
          //document.getElementById('drpfrzflag').value= dsexe.Tables[0].Rows[next].FREEZE_FLAG;
          document.getElementById('txt_talukaoname').value= dsexe.Tables[0].Rows[next].TALU_ONAME;
      if(document.getElementById('btnModify').value==false)    
  $('btnModify').focus();
  
         
                     document.getElementById('btnnext').disabled = true;
                     document.getElementById('btnlast').disabled = true;
                     document.getElementById('btnfirst').disabled=false;
                     document.getElementById('btnprevious').disabled=false;
          
  }
  else
  {
        //document.getElementById('txt_compcode').value=document.getElementById('hiddencompcode').value;
          //document.getElementById('txt_compname').value=document.getElementById('hiddencompcode').value;
          document.getElementById('drpdistcode').value = dsexe.Tables[0].Rows[next].DIST_CODE;
          document.getElementById('txttaluka_code').value= dsexe.Tables[0].Rows[next].TALU_CODE;
          document.getElementById('txttaluka_name').value= dsexe.Tables[0].Rows[next].TALU_NAME;
          document.getElementById('txt_talukaalias').value= dsexe.Tables[0].Rows[next].TALU_ALIAS;
          //document.getElementById('drpfrzflag').value= dsexe.Tables[0].Rows[next].FREEZE_FLAG;
          document.getElementById('txt_talukaoname').value= dsexe.Tables[0].Rows[next].TALU_ONAME;
          if(document.getElementById('btnModify').value==false)
          $('btnModify').focus();
  }
      
 return false;
     

}



var record_show_j=1
var record_show_i=0
////////////////////////////////////////////paging///////////////////////////////////////////////////////////////

//function fetchview()
//{
//     
//     $('Td14').style.display ='block';
//     $('view19').style.display ='block';
//       $('prepage').style.display ='block';
//     $('nextpage').style.display ='block';
//      $('next1').style.display ='block';
//      
//      
//taluka_mast.taluka_allview($('hiddencompcode').value,"","","",callback_allview)
////document.getElementById('Button4').disabled= true;

//}

////////////////////////////////////////callback view///////////////////////////////////////////////////////////////////



var srt_count=1
var record_show1=1
var record_show=5	
var record_show1_other1=4;
var record_show_other=4;
var extra_record_other=0;
var divres=""; 
var check =true;


function callback_allview(res)
{
if(check==true)
{
var srt_count=0
var record_show1=1
var record_show=3

    if(res.value!=undefined)
    {
    ds18=res.value;
    }
    else
    {
    ds18=res;
    }
check =false;

}
else
{
var srt_count=0
var record_show1=1
var record_show=3	
ds18="";

    if(res.value!=undefined)
    {
    ds18=res.value;
    }
    else
    {
    ds18=res;
    }
}

row_count=ds18.Tables[0].Rows.length;
var valnextval=2
pagenext(valnextval);


//ds18=res.value;
var hdsview="";
var j=1
var i=0

                            


    if(ds18!=null && ds18.Tables[0].Rows.length > 0)
    {    
                     
                for( srt_count;srt_count<=record_show;srt_count++)
                {
                     hdsview+="<table Width='755px' style='border:1px solid #7DAAE3;margin-top:1px;margin-bottom:1px;margin-left:4px;' cellpadding='0' cellspacing='0'>"
                     hdsview+="<tr>"
                     hdsview+="<td width='40px' style='border:1px solid #7DAAE3;'>"
                     hdsview+="<font style='font-size:10px;font-weight:bold;vertical-align:middle;padding-top:4px;padding-right:5px;padding-left:6px;padding-bottom:2px;' >"+j;"</font>"
                     hdsview+="</td>"
                     
                     var ds_view_name=ds18.Tables[0].Rows[srt_count].DIST_CODE
			         if(ds_view_name!="null")
		             {
                     hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                     hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt_count].DIST_CODE+"</font>"
                     hdsview+="</td>"
                     }
                     
			         var ds_view_name=ds18.Tables[0].Rows[srt_count].TALU_CODE
			         if(ds_view_name!="null")
		             {
                     hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                     hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt_count].TALU_CODE+"</font>"
                     hdsview+="</td>"
                     }
                     
                     var ds_view_str=ds18.Tables[0].Rows[srt_count].TALU_NAME
			         if(ds_view_str!="null")
		             {
                     hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                     hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt_count].TALU_NAME+"</font>"
                     hdsview+="</td>"
                     }
                     
                      var ds_views_str=ds18.Tables[0].Rows[srt_count].TALU_ALIAS
			         if(ds_views_str!="null")
		             {
                     hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                     hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt_count].TALU_ALIAS+"</font>"
                     hdsview+="</td>"
                     }
                     
                    var ds_views_str=ds18.Tables[0].Rows[srt_count].TALU_ONAME
                     
                     if(ds_views_str!="null")
		             {
                     
                         if(ds18.Tables[0].Rows[srt_count].TALU_ONAME==null)
                         {
                         hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                         hdsview+="<font class='gridview'>"+""+"</font>"
                         hdsview+="</td>"
                         }
                         else
                         {
                         hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                         hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt_count].TALU_ONAME+"</font>"
                         hdsview+="</td>"
                         }
                     }
                    
                     
                     
                     
                     hdsview+="</tr>"
                     hdsview+="</table>"
                     //document.getElementById('tstank').value=hdsview
        			
        			 $('view19').innerHTML=hdsview;  
			         j++
			         
			         //return false;
                 }
        } 
		else
         {
			
			 hdsview+="<table width='755px;'>"
             hdsview+="<tr>"
             hdsview+="<td width='700px'>"
             hdsview+="<font Style='font-family:arial;font-weight:bold;font-size:18px;'>You have no detail </font></strong>"
             hdsview+="</td>"
    		 hdsview+="</tr>"
             hdsview+="</table>"
             hdsview =hdsview+ "<BR>"
			 $('view19').innerHTML=hdsview;
			    
			 return false;
        }  
}

////////////////////////////////////////////////order by///////////////////////////////////////////////////////////

var flag = true;
var viewcolname="";
var valueType




function click_trcode(hd)
{
 valueType=hd;

 //valueType =hd.value;

if(valueType=="view11")
{
  viewcolname="DIST_CODE";
}
else if(valueType=="view12")
{
viewcolname  ="TALU_CODE";
}

else if(valueType=="view13")
{
  viewcolname="TALU_NAME";
}

else if(valueType=="view14")
{
  viewcolname="TALU_ALIAS";
}

else if(valueType=="view15")
{
  viewcolname="TALU_ONAME";
}


else
{
viewcolname  ="TALU_CODE";
}


var orderby 
if(flag==true)
{
$('downid').style.display='block';
$('upid').style.display='none';
orderby="ASC";
flag=false
}
else
{
$('downid').style.display='none';
$('upid').style.display='block';
orderby="DESC";
flag=true
}
//record_show=5
//    record_show1=1
    
// var dateformat = $('dateformat').value;
taluka_mast.taluka_allviews_ds("COMP_CODE",$('hiddencompcode').value,"","","TALUKA_MAST",viewcolname,orderby,"","","",callback_allviews_ds)

}


function callback_allviews_ds(res)
{
    var valnextval=2
    pagenext(valnextval);
    ds_18=res.value;
    record_show=5
    record_show1=1
    callback_allview(ds_18)
    return false;
}



////////////////////////////////////////////OK////////////////////////////////////////////////////////////////////
var srt_count=1
var record_show1=1
//var record_show=3	
var record_show1_other1=4;
var record_show_other=4;
var extra_record_other=0;
var divres=""; 


var srt_count_0ther=1;
function pagenext(valnext)
{
  var nextPageNumberColor=true
 divres=row_count/4;
    if(divres.valueOf(".")>="0")
    {
    divres=divres+1;
    }
    else
    {
    divres;
    }
  
var hdspage;

var aa="";
if((parseInt(record_show1)*4)-4>=row_count)
{
   // alert("End Of record")
    return false;
}
else
{
$('next1').innerHTML="";
for(srt_count=record_show1;srt_count<record_show;srt_count++)
{
    if(srt_count<divres)
    {
  
   if(srt_count==1 || nextPageNumberColor==true)
   {
    $('next1').innerHTML+="<span onclick=pagenumber("+srt_count+",this.id) class='paggingColorChange'  id=nextnumber_"+srt_count+" runat='server'>"+srt_count+"</span>"
   nextPageNumberColor=false;
   pagenumber(srt_count,this.id)
   }
   else
   {
    $('next1').innerHTML+="<span onclick=pagenumber("+srt_count+",this.id) class='paggingColor'  id=nextnumber_"+srt_count+" runat='server'>"+srt_count+"</span>"
  
   } 
     aa="aa";
    }
    else
    {
    
    aa="";
    
    //return false;
    }

}
if(aa!="")
{


record_show1=record_show; 
preval=record_show1-4
record_show=record_show1+4;
nextPageNumberColor=true;
}
else
{
record_show1=record_show; 
preval=record_show1-4
record_show=record_show1+4;
//return false;
}
}
}

//var pagenumberfirst=true;

			
function pageprev(valpre)
{
var bb="";
var hdspage;
var dfg="0"
var End_pnt="0"


if(preval<=4)
{
dfg=1

End_pnt=5
}
else
{
dfg=preval-4;
End_pnt=dfg+4;

}

if(preval<=4)
{
return false;
}
else
{
$('next1').innerHTML="";
for(srt_count=dfg;srt_count<End_pnt;srt_count++)
{
    if(srt_count!=0 )
    {
        if(srt_count!=End_pnt-1)
        {
        $('next1').innerHTML+="<span onclick=pagenumber("+srt_count+",this.id) class='paggingColor' id=nextnumber_"+srt_count+" runat='server'>"+srt_count+"</span>";
       bb="bb";
      
        }
        else
        {
        $('next1').innerHTML+="<span onclick=pagenumber("+srt_count+",this.id) class='paggingColorChange' id=nextnumber_"+srt_count+" runat='server'>"+srt_count+"</span>";
        bb="bb";
        pagenumber(srt_count,this.id)
        }
     
    }
    else
    {
    bb="";
    break;
    }
}
    if(bb!="")
    {
    record_show=record_show1
    record_show1=record_show-4
    }
    preval=preval-4
}
}





function pagenumber(valnextvalue,hdsg)
{
hdsharma=hdsg

if(hdsg!=undefined)
{
while(document.getElementById('next1').innerHTML.indexOf('paggingColorChange')>0)
{
document.getElementById('next1').innerHTML=document.getElementById('next1').innerHTML.replace('paggingColorChange','paggingColor');
}
document.getElementById(hdsg).className='paggingColorChange';
}

var flag="IN";

	            var flags="pre";
	             forlen_other=valnextvalue;
	             
	             extra_record_other = row_count%4;
	             var finalval=(forlen_other*record_show_other)-extra_record_other;
	             hdsview="";
	                
	                if(finalval!=row_count && extra_record_other!=0 && extra_record_other!=1)
	                {
	                    for(srt_count_0ther=(forlen_other*record_show_other)-record_show_other;srt_count_0ther<(forlen_other*record_show_other);srt_count_0ther++)
	                    {
	                        if(row_count!=srt_count_0ther)
	                        {
                     hdsview+="<table Width='755px' style='border:1px solid #7DAAE3;margin-top:1px;margin-bottom:1px;margin-left:4px;' cellpadding='0' cellspacing='0'>"
                     hdsview+="<tr>"
                    
                     var srt_count_0ther_sr= parseInt(srt_count_0ther)+1      
                             
                             
                     hdsview+="<td width='40px' style='border:1px solid #7DAAE3;'>"
                     hdsview+="<font class='gridview'>"+srt_count_0ther_sr+"</font>"
                     hdsview+="</td>"
                     
                        
                     var ds_view_code=ds18.Tables[0].Rows[srt_count_0ther].DIST_CODE
                      if(ds_view_code!="null")
                      {
                             hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                             hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt_count_0ther].DIST_CODE+"</font>"
                             hdsview+="</td>"
                      }              
                      
                      var ds_view_SRcode=ds18.Tables[0].Rows[srt_count_0ther].TALU_CODE
                      if(ds_view_SRcode!="null")
                       {
                                 hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                                 hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt_count_0ther].TALU_CODE+"</font>"
                                 hdsview+="</td>"
                       } 
                     
                     var ds_view_SSRcode=ds18.Tables[0].Rows[srt_count_0ther].TALU_NAME
                      if(ds_view_SSRcode!="null")
                       {
                                 hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                                 hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt_count_0ther].TALU_NAME+"</font>"
                                 hdsview+="</td>"
                       }  
                       
                        var ds_view_SSRcode=ds18.Tables[0].Rows[srt_count_0ther].TALU_ALIAS
                      if(ds_view_SSRcode!="null")
                       {
                                 hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                                 hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt_count_0ther].TALU_ALIAS+"</font>"
                                 hdsview+="</td>"
                       }  
                       
                                    var ds_view_SSRcode=ds18.Tables[0].Rows[srt_count_0ther].TALU_ONAME
                                  if(ds_view_SSRcode!="null")
                                   {
                                   
                                           if(ds18.Tables[0].Rows[srt_count_0ther].TALU_ONAME==null)
                                             {
                                             hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                                             hdsview+="<font class='gridview'>"+""+"</font>"
                                             hdsview+="</td>"
                                             }
                                         else
                                            {
                                                 hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                                                 hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt_count_0ther].TALU_ONAME+"</font>"
                                                 hdsview+="</td>"
                                           }  
                                   }
                       
                       
                      
                      
                      
                    hdsview+="</table>"
                    hdsview+="</tr>"
                    $('view19').innerHTML=hdsview;
                    srt_count_0ther_sr++
                    }  
    	                }
    	                 
    	            }
    	            else if(finalval == row_count)
	                {
	                    for(srt=(forlen_other*record_show_other)-record_show_other;srt<row_count;srt++)
                        {
	                       
	                    var srt_count_0ther_sr= parseInt(srt)+1      
                     
                         hdsview+="<table Width='755px' style='border:1px solid #7DAAE3;margin-top:1px;margin-bottom:1px;margin-left:4px;' cellpadding='0' cellspacing='0'>"
                         hdsview+="<tr>"
                
                             hdsview+="<td width='40px' style='border:1px solid #7DAAE3;'>"
                             hdsview+="<font style='font-size:10px;font-weight:bold;vertical-align:middle;'>"+srt_count_0ther_sr+"</font>"
                             hdsview+="</td>"
                
                     var ds_view_code=ds18.Tables[0].Rows[srt].DIST_CODE
                         if(ds_view_code!="null")
                         {
                             hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                             hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt].DIST_CODE+"</font>"
                             hdsview+="</td>"
                          }              
                      
                      var ds_view_SRcode=ds18.Tables[0].Rows[srt].TALU_CODE
                      if(ds_view_SRcode!="null")
                       {
                                 hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                                 hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt].TALU_CODE+"</font>"
                                 hdsview+="</td>"
                       } 
                      
                      var ds_view_SSRcode=ds18.Tables[0].Rows[srt].TALU_NAME
                      if(ds_view_SSRcode!="null")
                       {
                                 hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                                 hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt].TALU_NAME+"</font>"
                                 hdsview+="</td>"
                       } 
                       
                       var ds_view_SSRcode=ds18.Tables[0].Rows[srt].TALU_ALIAS
                      if(ds_view_SSRcode!="null")
                       {
                                 hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                                 hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt].TALU_ALIAS+"</font>"
                                 hdsview+="</td>"
                       } 
                       
                       var ds_view_SSRcode=ds18.Tables[0].Rows[srt].TALU_ONAME
                      if(ds_view_SSRcode!="null")
                       {
                       
                                             if(ds18.Tables[0].Rows[srt].TALU_ONAME==null)
                                             {
                                             hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                                             hdsview+="<font class='gridview'>"+""+"</font>"
                                             hdsview+="</td>"
                                             }
                                             
                                             else
                                             {
                                             hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                                             hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt].TALU_ONAME+"</font>"
                                             hdsview+="</td>"
                                             }
                       }
                        
                       
                      
                               
                     
                            hdsview+="</table>"
                            hdsview+="</tr>"
    	                    $('view19').innerHTML=hdsview;
                            srt_count_0ther_sr++
                        }
                    
                    }
                    else
                    {
                    //((forlen_other*record_show_other)*record_show_other)
                   var finalval_other=finalval-extra_record_other;
                        if(flag=="IN")
                        {
                        for(srt=(forlen_other*record_show_other)-record_show_other;srt<(forlen_other*record_show_other);srt++)
                        {
                        if(srt!=row_count)
                        {
                        if(srt>row_count)
                        {
                        return false;
                        }
                         hdsview+="<table Width='755px' style='border:1px solid #7DAAE3;margin-top:1px;margin-bottom:1px;margin-left:4px;' cellpadding='0' cellspacing='0'>"
                         hdsview+="<tr>"
                             
                             var srt_count_0ther_sr= parseInt(srt)+1       
                            
                             hdsview+="<td width='40px' style='border:1px solid #7DAAE3;'>"
                             hdsview+="<font style='font-size:10px;font-weight:bold;vertical-align:middle;'>"+srt_count_0ther_sr+"</font>"
                             hdsview+="</td>"
                            
                     var ds_view_code=ds18.Tables[0].Rows[srt].DIST_CODE
                     if(ds_view_code!="null")
                     {
                         hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                         hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt].DIST_CODE+"</font>"
                         hdsview+="</td>"
                      } 
                              
                      var ds_view_SRcode=ds18.Tables[0].Rows[srt].TALU_CODE
                      if(ds_view_SRcode!="null")
                       {
                                 hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                                 hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt].TALU_CODE+"</font>"
                                 hdsview+="</td>"
                       } 
                      
                      var ds_view_SSRcode=ds18.Tables[0].Rows[srt].TALU_NAME
                      if(ds_view_SSRcode!="null")
                       {
                                 hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                                 hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt].TALU_NAME+"</font>"
                                 hdsview+="</td>"
                       } 
                       
                       var ds_view_SSRcode=ds18.Tables[0].Rows[srt].TALU_ALIAS
                      if(ds_view_SSRcode!="null")
                       {
                                 hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                                 hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt].TALU_ALIAS+"</font>"
                                 hdsview+="</td>"
                       } 
                       
                       var ds_view_SSRcode=ds18.Tables[0].Rows[srt].TALU_ONAME
                      if(ds_view_SSRcode!="null")
                       {
                                             if(ds18.Tables[0].Rows[srt].TALU_ONAME==null)
                                             {
                                             hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                                             hdsview+="<font class='gridview'>"+""+"</font>"
                                             hdsview+="</td>"
                                             }
                                             
                                             else
                                             {
                                             hdsview+="<td width='90px' style='border:1px solid #7DAAE3;'>"
                                             hdsview+="<font class='gridview'>"+ds18.Tables[0].Rows[srt].TALU_ONAME+"</font>"
                                             hdsview+="</td>"
                                              }
                       } 
                       
                       
                        
                        
                        
                        
                        
                    
                          
                              
                          hdsview+="</table>"
                          hdsview+="</tr>"
    	                  $('view19').innerHTML=hdsview;
                          srt_count_0ther_sr++  
    	                } 
    	                 }
                        }
                        flag="OUT";
                    }
}			

   
   


function chkfld(a)
{

if(a.keyCode==120)
        {
           var formname=document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/")+1,document.URLUnencoded.lastIndexOf("."));
           window.open("Help.aspx?formname="+formname);
          
        }
if( a.keyCode=="13")
{
  
      if(document.activeElement.id=="btnNew")
          {
                if( a.keyCode=="13")
                  {
                  EnableOnNew();
                  return false;
                  } 
       
     }
     
    
   else if(document.activeElement.id=="btnQuery")
      
       {
       
                   if( a.keyCode=="13")
                       {
                       EnabledOnQuery();
                       return false;
                       } 
            
   
       }      
              
       
 else if((a.keyCode=="13" || a.keycode=="9") && document.activeElement.id=="drpdistcode"  && document.getElementById('btnExecute').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
    {
                   if($('drpdistcode').value=="" || $('drpdistcode').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                         //bind_state();
                                          $('txttaluka_code').focus();
                                          return false;
                                         }
                   }
     }                                
     
     
 else if((a.keyCode=="13" || a.keyCode=="9") && document.activeElement.id=="drpdistcode"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
    {
                   if($('drpdistcode').value=="0")
                   {
                   
                   alert(alrtdist)
                   return false;
                   }
                   else
                   {
                   //bind_state();
                   $('txttaluka_name').focus();
                   return false;
                   }
                                      
                   
     }
     
               
               
                
else if(a.keyCode=="13" && document.activeElement.id=="txttaluka_name"  && document.getElementById('btnExecute').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
    {
                   if(trim($('txttaluka_name').value)=="" || trim($('txttaluka_name').value)!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          $('txt_talukaalias').focus();
                                          return false;
                                         }
                   }
     }            
     

else if((a.keyCode=="13"||a.keyCode=="9") && document.activeElement.id=="txttaluka_name"  && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
    {
                   //if(trim($('txttaluka_name').value)=="")
                   if($('txttaluka_name').value=="")
                   {
                   alert(alrttalname)
                   return false;
                   }
                   else
                   {
                   $('txt_talukaalias').focus();
                   return false;
                   }
                                      
    }
   
  

               
                
else if(a.keyCode=="13" && document.activeElement.id=="txttaluka_code" && document.getElementById('btnExecute').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false)
     {
                   if($('txttaluka_code').value=="" || $('txttaluka_code').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          $('txttaluka_name').focus();
                                          return false;
                                         }
                     }
    }
    
    
else if(a.keyCode=="13" && document.activeElement.id=="txt_talukaalias" && document.getElementById('btnExecute').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false)
                {
                    if(trim($('txt_talukaalias').value)=="")
                    {
                        if( a.keyCode=="13")
                         {
                          $('txt_talukaoname').focus();
                          return false;
                         }
                    }
              } 
              
    
     
    
     
     
else if((a.keyCode=="13"||a.keyCode=="9") && document.activeElement.id=="txt_talukaalias" && document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false)
                {
                    //if(trim($('txt_talukaalias').value)=="")
                    if($('txt_talukaalias').value=="")
                    {
                        alert(alrttalalias)
                       
                        
                        return false;
                    }
                    else
                    {
//                        if($('txt_talukaoname').disabled==false)
//                        {
//                             $('txt_talukaoname').focus();
//                             return false;
//                        }
                          return false;
                    }
              } 
             
               
              
else if(a.keyCode=="13" && document.activeElement.id=="txt_talukaoname")
    {
                   if($('txt_talukaoname').value=="" || $('txt_talukaoname').value!="")
                   {
                                      if( a.keyCode=="13")
                                         {
                                          //$('drpfrzflag').focus();
                                          //return false;
                                         }
                   }
     }
     

     
     
else if((a.keyCode=="13"|a.keyCode=="9") &&  document.getElementById('btnSave').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
    {
//                   if($('drpfrzflag').value!="")
//                   {
//                                      if( a.keyCode=="13")
//                                         {
//                                          $('btnSave').focus();
//                                          return false;
//                                         }
//                   }
     }
     
else if(a.keyCode=="13"   && document.getElementById('btnExecute').disabled ==false && document.getElementById('btnCancel').disabled == false && document.getElementById('btnExit').disabled == false )
    {
//                   if($('drpfrzflag').value=="" || $('drpfrzflag').value!="")
//                   {
//                                      if( a.keyCode=="13")
//                                         {
                                          $('btnExecute').focus();
                                          return false;
//                                         }
//                   }
     }     
              
   
else if (document.activeElement.id=="btnSave")
                    {
                    chkduplicacy();
                    return false;
                    }                
   


     
    
else if(a.keyCode=="13" && document.activeElement.id=="btnExecute")
                                {
                                EnableExecute();
                                return false;
                                }

     
          }
          
}

 var hiddenauto="";
function autogen()
 {
 
// if(modiflag!=1)
// {


            if((document.getElementById('hiddenauto').value=="1"))
   
              {
                    changeoccured();
                    return false;
              }
                else
                {
                    userdefine();
                    return false;
                 }
    
     
//}

//return ;
}
function changeoccured()
{

   document.getElementById('txttaluka_name').value=document.getElementById('txttaluka_name').value.toUpperCase();
  //if((document.getElementById('hiddenauto').value=="1"))
  if(hiddentext=="new" )
			{
	
           uppercase3();
           
           }
            else
            {
            document.getElementById('txttaluka_name').value=document.getElementById('txttaluka_name').value;
            return ;
            }
return ;
}  

function uppercase3()
		{
		document.getElementById('txttaluka_name').value=document.getElementById('txttaluka_name').value.toUpperCase();
		  
		 // document.getElementById('txtalias').value=document.getElementById('txtprodesc').value;
		  lstr=document.getElementById('txttaluka_name').value;
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
		    if(document.getElementById('txttaluka_name').value!="")
                {
               
        
		document.getElementById('txttaluka_name').value=document.getElementById('txttaluka_name').value.toUpperCase();
	    document.getElementById('txt_talukaalias').value=document.getElementById('txttaluka_name').value.toUpperCase();
		// str=document.getElementById('txtprodesc').value;
		// cod=document.getElementById('txtadvcatcode').value;
		str=mstr;
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
taluka_mast.chkcode(/*cod,*/str,fillcall);
		return false;
                }
		       
               
 return false;
		
} 


function fillcall(res)
		{
		        var ds=res.value;
        		
		        var newstr;

		  
		    if(ds.Tables[1].Rows.length==0)
                    {
                    newstr=null;
                    }
                else
                    {
                     newstr=ds.Tables[1].Rows[0].talu_code;
                    }
                if(newstr !=null )
                    {
                   // var code=newstr.substr(2,4);
                    var code=newstr;
		            str=str.toUpperCase();
                    code++;
                    document.getElementById('txttaluka_code').value=str.substr(0,2)+ code;
                     }
                else
                     {
                      document.getElementById('txttaluka_code').value=str.substr(0,2)+ "0";
                      document.getElementById('txttaluka_code').value=document.getElementById('txttaluka_code').value.toUpperCase();
                      document.getElementById('txt_talukaalias').focus();
                      }
          //  }
	return false;
}
		
function userdefine()
    {
        document.getElementById('txttaluka_name').value=document.getElementById('txttaluka_name').value.toUpperCase();
        if(hiddentext=="new")
        {
        
        document.getElementById('txttaluka_code').disabled=false;
         document.getElementById('txttaluka_code').value=document.getElementById('txttaluka_code').value.toUpperCase();
        document.getElementById('txttaluka_name').value=document.getElementById('txttaluka_name').value.toUpperCase();
        document.getElementById('txt_talukaalias').value=document.getElementById('txttaluka_name').value.toUpperCase();
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

return false;


}

/*-----For---Upper Case-------------*/
function uppercase1()
{
document.getElementById('txttaluka_code').value=document.getElementById('txttaluka_code').value.toUpperCase();
return ;
}
		
function uppercase2()
{
document.getElementById('txt_talukaalias').value=document.getElementById('txt_talukaalias').value.toUpperCase();
return ;
}

//function uppercase3()
//{
//document.getElementById('txttaluka_name').value=document.getElementById('txttaluka_name').value.toUpperCase();
//document.getElementById('txt_talukaalias').value=document.getElementById('txttaluka_name').value.toUpperCase();
//return ;
//}
//                                       

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
