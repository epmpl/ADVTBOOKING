// JScript File
var hiddentext;
var mod="0";
//var z=0;

var hiddentext1="";
var glaobaldescription;
var glaobalvatcode;
var glaobalvatrate;
var glaobalfromdate;
var glaobaltodate;
var glaobalgrosstype;
var glaobalorderno;

var mod="0";

    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
		var xmlObj;
        function loadXML(xmlFile) 
         { 
            xmlDoc.async="false"; 
            xmlDoc.onreadystatechange=verify; 
            xmlDoc.load(xmlFile); 
            xmlObj=xmlDoc.documentElement; 
           // alert(xmlObj.childNodes(0).childNodes(0).text);  
            
          }
function addedition()
{
    var pubname=document.getElementById('drpPubName').value;
    var resedit=Vatmaster.addedition(pubname);
    var pkgitem=document.getElementById('drEditonName');
    pkgitem.options[0]=new Option("------Select Edititon------","0");
    for (var i = 0  ; i < resedit.value.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(resedit.value.Tables[0].Rows[i].Edition_Alias,resedit.value.Tables[0].Rows[i].Edition_Code);
            
           pkgitem.options.length;
           
        }
        return false;
}

function newclick()
{

         document.getElementById('drpgross').value="0";
         document.getElementById('txtvatrate').value="";
         document.getElementById('drpdescription').value="0";
         document.getElementById('txtorder').value="";
         document.getElementById('txtfromdate').value="";
         document.getElementById('txttodate').value="";
         document.getElementById('drEditonName').value="0";
         document.getElementById('drpPubName').value="0";
         
         document.getElementById('drEditonName').disabled=false;
         document.getElementById('drpPubName').disabled=false;
         document.getElementById('drpgross').disabled=false;
         document.getElementById('txtvatrate').disabled=false;
         document.getElementById('drpdescription').disabled=false;
         document.getElementById('txtorder').disabled=false;
         document.getElementById('txtfromdate').disabled=false;
         document.getElementById('txttodate').disabled=false;
         //document.getElementById('txtcode').disabled=false;
        document.getElementById('drpPubName').focus();
        hiddentext="new";
         chkstatus(FlagStatus);
    			
	    document.getElementById('btnSave').disabled = false;	
	    document.getElementById('btnNew').disabled = true;	
	    document.getElementById('btnQuery').disabled=true;
    		setButtonImages();
	    return false;
}
function saveclick()
{
var fromdate="";
var todate="";
    if(document.getElementById('txtfromdate').value=="" ||document.getElementById('txttodate').value=="")
        {
         alert("Please Fill Date")
         document.getElementById('txtfromdate').focus();
         return false;
         }
//         if(todate != "" || todate != null || todate != "undefined")
//		{
//			tdate = new Date(todate);
//			fdate= new Date(fromdate);
//		 if(tdate<fdate)
//			{
//			alert("Valid To date must be greater than  From date");
//			document.getElementById('txttodate').disabled=false;
//			document.getElementById('txttodate').focus();
//			return false;
//			}
         //}
       //}
        if(document.getElementById('txtfromdate').value=="")
        {
            alert("Please Fill From Date")
            document.getElementById('txtfromdate').focus();
            return false;
        }
        else if(document.getElementById('txttodate')=="")
        {
            alert("Please Fill To Date")
            document.getElementById('txttodate').focus();
            return false;
        }
        else     
        {
            var dateformat = document.getElementById('hiddendateformat').value;
			if(dateformat=="dd/mm/yyyy")
		    {
                txtfrom=document.getElementById('txtfromdate').value;
                txtto=document.getElementById('txttodate').value;

                var txt1=txtfrom.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
                var txtto1=txtto.split("/");
                var dd1=txtto1[0];
                var mm1=txtto1[1];
                var yy1=txtto1[2];
                todate=mm1+'/'+dd1+'/'+yy1;

            }
			else if(dateformat=="mm/dd/yyyy")
			{
				fromdate=document.getElementById('txtfromdate').value;
				todate=document.getElementById('txttodate').value;
			}
								
		    else if(dateformat=="yyyy/mm/dd")
		    {
			    var txt=document.getElementById('txtfromdate').value;
			    var txt1=txt.split("/");
			    var yy=txt1[0];
			    var mm=txt1[1];
			    var dd=txt1[2];
			    fromdate=mm+'/'+dd+'/'+yy;
			    var txtto=document.getElementById('txttodate').value;
			    var txtto1=txtto.split("/");
			    var yy1=txtto1[0];
			    var mm1=txtto1[1];
			    var dd1=txtto1[2];
			    todate=mm1+'/'+dd1+'/'+yy1;
		    }
			if(dateformat==null || dateformat=="" || dateformat=="undefined")
			{
				alert("dateformat is either null or undefined");
				fromdate=document.getElementById('txtfromdate').value;
				todate=document.getElementById('txttodate').value;
			}
						
		    
			tdate = new Date(todate);
			fdate= new Date(fromdate);
			if(tdate<fdate)
			{
			    alert("Valid To date must be greater than  From date");
			    document.getElementById('txttodate').disabled=false;
			    document.getElementById('txttodate').focus();
			    return false;
			} 
     }
        if(document.getElementById('drpdescription').value=="0")
        {
            alert("Please Select the Description");
            document.getElementById('drpdescription').focus();
            return false;
        }
      // else if(document.getElementById('txtcode').value=="")
               //{
                //  alert("Please Enter the Code");
                //  document.getElementById('txtcode').focus();
                 // return false;
               //}
        document.getElementById('txtvatrate').value=trim(document.getElementById('txtvatrate').value);
        if(document.getElementById('txtvatrate').value=="")
        {
            alert("Please Enter the Vat rate");
            document.getElementById('txtvatrate').focus();
            return false;
        }
        if(document.getElementById('drpgross').value==0)
        {
            alert("Please Enter the Type");
            document.getElementById('drpgross').focus();
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
        var description=document.getElementById('drpdescription').value;  
		var compcode=document.getElementById('hiddencomcode').value;
		//var vatcode=document.getElementById('txtcode').value;
		var vatrate=document.getElementById('txtvatrate').value;
	    //var fromdate=document.getElementById('txtfromdate').value;
	    //var todate=document.getElementById('txttodate').value;
	    
		var grosstype=document.getElementById('drpgross').value;
		
		var orderno=document.getElementById('txtorder').value;
		var userid=document.getElementById('hiddenuserid').value;
		var publicat=document.getElementById('drpPubName').value;
		var edit=document.getElementById('drEditonName').value;
			
		if(mod !="1" && mod !=null)	
		{
		var res= Vatmaster.chkdate(description, fromdate, todate,publicat,edit);
		var ds1=res.value;
         if(ds1.Tables[0].Rows.length > 0)
            {
            alert("This date has been already assigned")
                return false;      
             }
             call_saveclick();
         //Vatmaster.vatchk(description,call_saveclick);
			
        }
        else
        {
			call_modify();
	        // Vatmaster.chkdate(description, fromdate, todate,publicat,edit,call_modify);
		     /*Vatmaster.vatmodify(compcode, userid, description, vatrate, fromdate, todate, grosstype, orderno);
		     
             dsvatexecute.Tables[0].Rows[z].vat_description=document.getElementById('drpdescription').value;
			//dsvatexecute.Tables[0].Rows[z].vat_code=document.getElementById('txtcode').value;
			dsvatexecute.Tables[0].Rows[z].vat_rate=document.getElementById('txtvatrate').value;
		    dsvatexecute.Tables[0].Rows[z].vat_from_date=document.getElementById('txtfromdate').value;
		    dsvatexecute.Tables[0].Rows[z].vat_to_date=document.getElementById('txttodate').value;
			dsvatexecute.Tables[0].Rows[z].vat_gross_type=document.getElementById('drpgross').value;
			dsvatexecute.Tables[0].Rows[z].vat_order_no=document.getElementById('txtorder').value;

			alert("Data Updated Successfully");
			updateStatus();
			if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==(dsvatexecute.Tables[0].Rows.length-1))
              {
                document.getElementById('btnNext').disabled=true;
	            document.getElementById('btnLast').disabled=true;
              }       

			 document.getElementById('drpgross').disabled=true;
             document.getElementById('txtvatrate').disabled=true;
             document.getElementById('drpdescription').disabled=true;
             document.getElementById('txtorder').disabled=true;
             document.getElementById('txtfromdate').disabled=true;
            // document.getElementById('txttodate').disabled=true;
             document.getElementById('txtcode').disabled=true;
			
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
		    
			
			mod="0";
		
			}*/
			}
return false;
}

function call_modify()
{
// var ds=response.value;
// if(ds.Tables[0].Rows.length > 0)
//    {
//    alert("This date has been already assigned")
//        return false;      
//     }
//   else
//      {
          var description=document.getElementById('drpdescription').value;  
			var compcode=document.getElementById('hiddencomcode').value;
			//var vatcode=document.getElementById('txtcode').value;
			var vatrate=document.getElementById('txtvatrate').value;
		    var dateformat = document.getElementById('hiddendateformat').value;
			if(dateformat=="dd/mm/yyyy")
		    {
                txtfrom=document.getElementById('txtfromdate').value;
                txtto=document.getElementById('txttodate').value;

                var txt1=txtfrom.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
                var txtto1=txtto.split("/");
                var dd1=txtto1[0];
                var mm1=txtto1[1];
                var yy1=txtto1[2];
                todate=mm1+'/'+dd1+'/'+yy1;

            }
			else if(dateformat=="mm/dd/yyyy")
			{
				fromdate=document.getElementById('txtfromdate').value;
				todate=document.getElementById('txttodate').value;
			}
								
		    else if(dateformat=="yyyy/mm/dd")
		    {
			    var txt=document.getElementById('txtfromdate').value;
			    var txt1=txt.split("/");
			    var yy=txt1[0];
			    var mm=txt1[1];
			    var dd=txt1[2];
			    fromdate=mm+'/'+dd+'/'+yy;
			    var txtto=document.getElementById('txttodate').value;
			    var txtto1=txtto.split("/");
			    var yy1=txtto1[0];
			    var mm1=txtto1[1];
			    var dd1=txtto1[2];
			    todate=mm1+'/'+dd1+'/'+yy1;
		    }
		    
		    //var fromdate=document.getElementById('txtfromdate').value;
		    //var todate=document.getElementById('txttodate').value;
		    
			var grosstype=document.getElementById('drpgross').value;
			
			var orderno=document.getElementById('txtorder').value;
			var userid=document.getElementById('hiddenuserid').value;
			var publicat=document.getElementById('drpPubName').value;
			var edit=document.getElementById('drEditonName').value;
			
			 Vatmaster.vatmodify(compcode, userid, description, vatrate, fromdate, todate, grosstype, orderno,publicat,edit);
//		     
//             dsvatexecute.Tables[0].Rows[z].vat_description=document.getElementById('drpdescription').value;
//			
//			dsvatexecute.Tables[0].Rows[z].vat_rate=document.getElementById('txtvatrate').value;
//		    dsvatexecute.Tables[0].Rows[z].vat_from_date=document.getElementById('txtfromdate').value;
//		    dsvatexecute.Tables[0].Rows[z].vat_to_date=document.getElementById('txttodate').value;
//			dsvatexecute.Tables[0].Rows[z].vat_gross_type=document.getElementById('drpgross').value;
//			dsvatexecute.Tables[0].Rows[z].vat_order_no=document.getElementById('txtorder').value;

			alert("Data Updated Successfully");
			updateStatus();
			if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==(dsvatexecute.Tables[0].Rows.length-1))
              {
                document.getElementById('btnNext').disabled=true;
	            document.getElementById('btnLast').disabled=true;
              }       

			 document.getElementById('drpgross').disabled=true;
             document.getElementById('txtvatrate').disabled=true;
             document.getElementById('drpdescription').disabled=true;
             document.getElementById('txtorder').disabled=true;
             document.getElementById('txtfromdate').disabled=true;
             document.getElementById('txttodate').disabled=true;
             document.getElementById('drpPubName').disabled=true;
             document.getElementById('drEditonName').disabled=true;
			
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
		    
			
			mod="0";
			
           
//      }  
      setButtonImages();
 return false;

}

function call_saveclick()
{
//              var ds=response.value;
//			if(ds.Tables[0].Rows.length > 0)
//			{
//			alert(" This Description Is Already Exist!!!!");
//			  document.getElementById('drpdescription').value="0"
//			    document.getElementById('drpgross').value="0"
//            document.getElementById('drpdescription').focus();
//			
//			return false;
//			} 
//			else
//			  {
			 var compcode=document.getElementById('hiddencomcode').value;
			var description=document.getElementById('drpdescription').value;  
			//var vatcode=document.getElementById('txtcode').value;
			var vatrate=document.getElementById('txtvatrate').value;
		    //var fromdate=document.getElementById('txtfromdate').value;
		    //var todate=document.getElementById('txttodate').value;
		    var dateformat = document.getElementById('hiddendateformat').value;
			if(dateformat=="dd/mm/yyyy")
		    {
                var txtfrom=document.getElementById('txtfromdate').value;
                var txtto=document.getElementById('txttodate').value;

                var txt1=txtfrom.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
                var txtto1=txtto.split("/");
                var dd1=txtto1[0];
                var mm1=txtto1[1];
                var yy1=txtto1[2];
                todate=mm1+'/'+dd1+'/'+yy1;

            }
			else if(dateformat=="mm/dd/yyyy")
			{
				fromdate=document.getElementById('txtfromdate').value;
				todate=document.getElementById('txttodate').value;
			}
								
		    else if(dateformat=="yyyy/mm/dd")
		    {
			    var txt=document.getElementById('txtfromdate').value;
			    var txt1=txt.split("/");
			    var yy=txt1[0];
			    var mm=txt1[1];
			    var dd=txt1[2];
			    fromdate=mm+'/'+dd+'/'+yy;
			    var txtto=document.getElementById('txttodate').value;
			    var txtto1=txtto.split("/");
			    var yy1=txtto1[0];
			    var mm1=txtto1[1];
			    var dd1=txtto1[2];
			    todate=mm1+'/'+dd1+'/'+yy1;
		    }
			var grosstype=document.getElementById('drpgross').value;
			var orderno=document.getElementById('txtorder').value;
			var userid=document.getElementById('hiddenuserid').value;
			var publicat=document.getElementById('drpPubName').value;
			var edit=document.getElementById('drEditonName').value;
			
			Vatmaster.vatsave(compcode,userid,description,vatrate,fromdate,todate,grosstype,orderno,publicat,edit);
			alert("Data Saved Successfully");
			       document.getElementById('drpgross').value=0;
                   document.getElementById('txtvatrate').value="";
                   document.getElementById('drpdescription').value="";
                   document.getElementById('txtorder').value="";
                   document.getElementById('txtfromdate').value="";
                   document.getElementById('txttodate').value="";
                   document.getElementById('drpPubName').value="0";
                   document.getElementById('drEditonName').value="0";
             
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
				    
                  
//			  }
			cancelclick('Vatmaster');
			return false;
}

function autoorder()
{
if(hiddentext=="new")
     {
    document.getElementById('drpdescription').value=trim(document.getElementById('drpdescription').value);
		lstr=document.getElementById('drpdescription').value;
	   str=lstr;

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
Vatmaster.vatdauto(str,fillcall);
    }
   // return false;

}
function fillcall(res)
{
    var ds=res.value;
	var newstr;
	if(ds.Tables[0].Rows.length>0)
		{
		     document.getElementById('txtorder').value=ds.Tables[0].Rows[0].vat_order_no;
		     var name=document.getElementById('drpgross');
		       name.options[0]=new Option("----Select Type----","0");
		        name.options.length=1;
		        
		     if(ds.Tables[0].Rows[0].vat_order_no != "1")
		     {
		        var i=1;
		        for(i=1;i<parseInt(ds.Tables[0].Rows[0].vat_order_no);i++)
		        {
		             name.options[name.options.length]=new Option(+i,i);
		        }
		      }
		      name.options[name.options.length]=new Option("Gross Amount","GA");
              name.options.length;
		}          
		       
	//return false;
}

function cancelclick(formname)
{
      document.getElementById('drpgross').value=0;
      document.getElementById('txtvatrate').value="";
      document.getElementById('drpdescription').value="0";
      document.getElementById('txtorder').value="";
      document.getElementById('txtfromdate').value="";
      document.getElementById('txttodate').value="";
     // document.getElementById('txtcode').value="";
     document.getElementById('drEditonName').options.length=1;
     //document.getElementById('drEditonName').options[0]=new Option("------Select Edititon------","0");
     document.getElementById('drpPubName').value="0";
     //addedition();
     document.getElementById('drEditonName').value="0";
     
     document.getElementById('drEditonName').disabled=true;
     document.getElementById('drpPubName').disabled=true;
      document.getElementById('drpgross').disabled=true;
      document.getElementById('txtvatrate').disabled=true;
      document.getElementById('drpdescription').disabled=true;
      document.getElementById('txtorder').disabled=true;
      document.getElementById('txtfromdate').disabled=true;
      document.getElementById('txttodate').disabled=true;
      //document.getElementById('txtcode').disabled=true;
     
                    mod="0";
				
					chkstatus(FlagStatus);
							givebuttonpermission(formname);
					if(FlagStatus!=2 && FlagStatus!=4 && FlagStatus!=6)
					if(document.getElementById('btnNew').disabled==false)
					{
					   
						    document.getElementById('btnNew').focus();
					}
						
					else
					{
						    document.getElementById('btnNew').disabled=false;
						    document.getElementById('btnNew').focus();
						
					}
				
			
			setButtonImages();
				return false;

}
function modifyclick()
{

	             document.getElementById('drpgross').disabled=false;
                 document.getElementById('txtvatrate').disabled=false;
                 document.getElementById('drpdescription').disabled=true;
                 document.getElementById('txtorder').disabled=true;
                 document.getElementById('txtfromdate').disabled=true;
                 document.getElementById('txttodate').disabled=true;
                 //document.getElementById('txtcode').disabled=true;
                  document.getElementById('drEditonName').disabled=true;
                 document.getElementById('drpPubName').disabled=true;
					
				
				chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnModify').disabled=false;
				
			
				   mod="1";
				 hiddentext="mod";	
				setButtonImages();
				return false;

}
function queryclick()
{
                   document.getElementById('drpgross').value="0";
                   document.getElementById('txtvatrate').value="";
                   document.getElementById('drpdescription').value="0";
                   document.getElementById('txtorder').value="";
                   document.getElementById('txtfromdate').value="";
                   document.getElementById('txttodate').value="";
                    document.getElementById('drEditonName').options.length=1;
                   document.getElementById('drEditonName').value="0";
                   document.getElementById('drpPubName').value="0";
				   z=0;
				   document.getElementById('drpgross').disabled=false;
                   document.getElementById('txtvatrate').disabled=false;
                   document.getElementById('drpdescription').disabled=false;
                   document.getElementById('txtorder').disabled=false;
                   document.getElementById('txtfromdate').disabled=false;
                   document.getElementById('txttodate').disabled=false;
                   //document.getElementById('txtcode').disabled=false;
                    document.getElementById('drEditonName').disabled=true;
                    document.getElementById('drpPubName').disabled=true;
					
				    chkstatus(FlagStatus);
            					
                    document.getElementById('btnQuery').disabled=true;
                    document.getElementById('btnExecute').disabled=false;
                    document.getElementById('btnSave').disabled=true;
                    document.getElementById('btnExecute').focus();	
				            hiddentext="query";
					
				setButtonImages();
				return false;

}
function executeclick()
{

             z=0;
			var compcode=document.getElementById('hiddencomcode').value;
			var description=document.getElementById('drpdescription').value;  
			glaobaldescription=description;
			//var vatcode=document.getElementById('txtcode').value;
			//glaobalvatcode=vatcode;
			var vatrate=document.getElementById('txtvatrate').value;
			glaobalvatrate=vatrate;
		    var fromdate=document.getElementById('txtfromdate').value;
		    glaobalfromdate=fromdate;
		    var todate=document.getElementById('txttodate').value;
		    glaobaltodate=todate;
			var grosstype=document.getElementById('drpgross').value;
			glaobalgrosstype=grosstype;
			var orderno=document.getElementById('txtorder').value;
			glaobalorderno=orderno;
			var userid=document.getElementById('hiddenuserid').value;
			
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
Vatmaster.vatexecute(compcode, userid, description, vatrate, fromdate, todate, grosstype,orderno, checkcall);		
			updateStatus();
			   document.getElementById('drpgross').disabled=true;
               document.getElementById('txtvatrate').disabled=true;
               document.getElementById('drpdescription').disabled=true;
               document.getElementById('txtorder').disabled=true;
               document.getElementById('txtfromdate').disabled=true;
               document.getElementById('txttodate').disabled=true;
               document.getElementById('drpPubName').disabled=true;
               document.getElementById('drEditonName').disabled=true;
			
			mod="0";
			            document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
		if(document.getElementById('btnModify').disabled==false)					
		   document.getElementById('btnModify').focus();
							
			
			return false;
}
function checkcall(response)
{
         var ds=response.value;
			dsvatexecute=response.value;
			if(dsvatexecute.Tables[0].Rows.length > 0)
			{
			if(dsvatexecute.Tables[0].Rows[0].PUBLICATION =="" || dsvatexecute.Tables[0].Rows[0].PUBLICATION==null)
			{
			    document.getElementById('drpPubName').value="0";
			    document.getElementById('drEditonName').value="0";
			}
			else
			{
			document.getElementById('drpPubName').value=dsvatexecute.Tables[0].Rows[0].PUBLICATION;
			addedition();
			document.getElementById('drEditonName').value=dsvatexecute.Tables[0].Rows[0].EDITION;
			}
			document.getElementById('drpdescription').value=dsvatexecute.Tables[0].Rows[0].vat_description;
			//document.getElementById('txtcode').value=dsvatexecute.Tables[0].Rows[0].vat_code;
			document.getElementById('txtvatrate').value=dsvatexecute.Tables[0].Rows[0].vat_rate;
		    
		    var dateformat = document.getElementById('hiddendateformat').value;
		    var fromdate="";
		    var todate="";
			if(dateformat=="dd/mm/yyyy")
		    {
                var txtfrom=dsvatexecute.Tables[0].Rows[0].vat_from_date;
                var txtto=dsvatexecute.Tables[0].Rows[0].vat_to_date;

                var txt1=txtfrom.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
                var txtto1=txtto.split("/");
                var dd1=txtto1[0];
                var mm1=txtto1[1];
                var yy1=txtto1[2];
                todate=mm1+'/'+dd1+'/'+yy1;

            }
			else if(dateformat=="mm/dd/yyyy")
			{
				fromdate=dsvatexecute.Tables[0].Rows[0].vat_from_date;
				todate=dsvatexecute.Tables[0].Rows[0].vat_to_date;
			}
								
		    else if(dateformat=="yyyy/mm/dd")
		    {
			    var txt=dsvatexecute.Tables[0].Rows[0].vat_from_date;
			    var txt1=txt.split("/");
			    var yy=txt1[2];
			    var mm=txt1[0];
			    var dd=txt1[1];
			    fromdate=yy+'/'+mm+'/'+dd;
			    var txtto=dsvatexecute.Tables[0].Rows[0].vat_to_date;
			    var txtto1=txtto.split("/");
			    var yy1=txtto1[2];
			    var mm1=txtto1[0];
			    var dd1=txtto1[1];
			    todate=yy1+'/'+mm1+'/'+dd1;
		    }
		    
		    
		    document.getElementById('txtfromdate').value=fromdate;//dsvatexecute.Tables[0].Rows[0].vat_from_date;
		    document.getElementById('txttodate').value=todate;//dsvatexecute.Tables[0].Rows[0].vat_to_date;
			document.getElementById('drpgross').value=dsvatexecute.Tables[0].Rows[0].vat_gross_type;
			document.getElementById('txtorder').value=dsvatexecute.Tables[0].Rows[0].vat_order_no;
			
			//document.getElementById('btnModify').focus();
			   document.getElementById('drpgross').disabled=true;
               document.getElementById('txtvatrate').disabled=true;
               document.getElementById('drpdescription').disabled=true;
               document.getElementById('txtorder').disabled=true;
               document.getElementById('txtfromdate').disabled=true;
               document.getElementById('txttodate').disabled=true;
               //document.getElementById('txtcode').disabled=true;
						
			}
			
			else
			{
				alert("Your Search Produce No Result!!!!");
			cancelclick('Vatmaster');
			}

            if(dsvatexecute.Tables[0].Rows.length ==1)
			{
			    document.getElementById('btnfirst').disabled=true;				
			    document.getElementById('btnnext').disabled=true;					
			    document.getElementById('btnprevious').disabled=true;			
			    document.getElementById('btnlast').disabled=true;
			    
			}
			setButtonImages();
			return false;
}
function nextclick()
{
 var a=dsvatexecute.Tables[0].Rows.length;
 z++;
 if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
		    	if(dsvatexecute.Tables[0].Rows[z].PUBLICATION =="" || dsvatexecute.Tables[0].Rows[z].PUBLICATION==null)
			    {
			        document.getElementById('drpPubName').value="0";
			        document.getElementById('drEditonName').value="0";
			    }
			    else
			    {
			    document.getElementById('drpPubName').value=dsvatexecute.Tables[0].Rows[z].PUBLICATION;
			    addedition();
			    document.getElementById('drEditonName').value=dsvatexecute.Tables[0].Rows[z].EDITION;
			    }
			 document.getElementById('drpdescription').value=dsvatexecute.Tables[0].Rows[z].vat_description;
			 //document.getElementById('txtcode').value=dsvatexecute.Tables[0].Rows[z].vat_code;
			 document.getElementById('txtvatrate').value=dsvatexecute.Tables[0].Rows[z].vat_rate;
			 
			 var dateformat = document.getElementById('hiddendateformat').value;
		    var fromdate="";
		    var todate="";
			if(dateformat=="dd/mm/yyyy")
		    {
                var txtfrom=dsvatexecute.Tables[0].Rows[z].vat_from_date;
                var txtto=dsvatexecute.Tables[0].Rows[z].vat_to_date;

                var txt1=txtfrom.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
                var txtto1=txtto.split("/");
                var dd1=txtto1[0];
                var mm1=txtto1[1];
                var yy1=txtto1[2];
                todate=mm1+'/'+dd1+'/'+yy1;

            }
			else if(dateformat=="mm/dd/yyyy")
			{
				fromdate=dsvatexecute.Tables[0].Rows[z].vat_from_date;
				todate=dsvatexecute.Tables[0].Rows[z].vat_to_date;
			}
								
		    else if(dateformat=="yyyy/mm/dd")
		    {
			    var txt=dsvatexecute.Tables[0].Rows[z].vat_from_date;
			    var txt1=txt.split("/");
			    var yy=txt1[2];
			    var mm=txt1[0];
			    var dd=txt1[1];
			    fromdate=yy+'/'+mm+'/'+dd;
			    var txtto=dsvatexecute.Tables[0].Rows[z].vat_to_date;
			    var txtto1=txtto.split("/");
			    var yy1=txtto1[2];
			    var mm1=txtto1[0];
			    var dd1=txtto1[1];
			    todate=yy1+'/'+mm1+'/'+dd1;
		    }
		     document.getElementById('txtfromdate').value=fromdate;//dsvatexecute.Tables[0].Rows[z].vat_from_date;
		     document.getElementById('txttodate').value=todate;//dsvatexecute.Tables[0].Rows[z].vat_to_date;
			 document.getElementById('drpgross').value=dsvatexecute.Tables[0].Rows[z].vat_gross_type;
			 document.getElementById('txtorder').value=dsvatexecute.Tables[0].Rows[z].vat_order_no;
			
		    updateStatus();
		     //document.getElementById('btnModify').focus();
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
function firstclick()
{
            document.getElementById('drpdescription').value=dsvatexecute.Tables[0].Rows[0].vat_description;
			//document.getElementById('txtcode').value=dsvatexecute.Tables[0].Rows[0].vat_code;
			document.getElementById('txtvatrate').value=dsvatexecute.Tables[0].Rows[0].vat_rate;
			
			var dateformat = document.getElementById('hiddendateformat').value;
		    var fromdate="";
		    var todate="";
			if(dateformat=="dd/mm/yyyy")
		    {
                var txtfrom=dsvatexecute.Tables[0].Rows[0].vat_from_date;
                var txtto=dsvatexecute.Tables[0].Rows[0].vat_to_date;

                var txt1=txtfrom.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
                var txtto1=txtto.split("/");
                var dd1=txtto1[0];
                var mm1=txtto1[1];
                var yy1=txtto1[2];
                todate=mm1+'/'+dd1+'/'+yy1;

            }
			else if(dateformat=="mm/dd/yyyy")
			{
				fromdate=dsvatexecute.Tables[0].Rows[0].vat_from_date;
				todate=dsvatexecute.Tables[0].Rows[0].vat_to_date;
			}
								
		    else if(dateformat=="yyyy/mm/dd")
		    {
			    var txt=dsvatexecute.Tables[0].Rows[0].vat_from_date;
			    var txt1=txt.split("/");
			    var yy=txt1[2];
			    var mm=txt1[0];
			    var dd=txt1[1];
			    fromdate=yy+'/'+mm+'/'+dd;
			    var txtto=dsvatexecute.Tables[0].Rows[0].vat_to_date;
			    var txtto1=txtto.split("/");
			    var yy1=txtto1[2];
			    var mm1=txtto1[0];
			    var dd1=txtto1[1];
			    todate=yy1+'/'+mm1+'/'+dd1;
		    }
		    	if(dsvatexecute.Tables[0].Rows[0].PUBLICATION =="" || dsvatexecute.Tables[0].Rows[0].PUBLICATION==null)
			    {
			        document.getElementById('drpPubName').value="0";
			        document.getElementById('drEditonName').value="0";
			    }
			    else
			    {
			    document.getElementById('drpPubName').value=dsvatexecute.Tables[0].Rows[0].PUBLICATION;
			    addedition();
			    document.getElementById('drEditonName').value=dsvatexecute.Tables[0].Rows[0].EDITION;
			    }
		    document.getElementById('txtfromdate').value=fromdate;//dsvatexecute.Tables[0].Rows[0].vat_from_date;
		    document.getElementById('txttodate').value=todate;//dsvatexecute.Tables[0].Rows[0].vat_to_date;
			document.getElementById('drpgross').value=dsvatexecute.Tables[0].Rows[0].vat_gross_type;
			document.getElementById('txtorder').value=dsvatexecute.Tables[0].Rows[0].vat_order_no;
			z=0;
			updateStatus();
              //document.getElementById('btnModify').focus();
		    document.getElementById('btnfirst').disabled=true;				
		    document.getElementById('btnprevious').disabled=true;
		    document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
		    setButtonImages();
			return false;
}
function lastclick()
{
 var y=dsvatexecute.Tables[0].Rows.length;
 var a=y-1;
 z=a;
            document.getElementById('drpdescription').value=dsvatexecute.Tables[0].Rows[z].vat_description;
			//document.getElementById('txtcode').value=dsvatexecute.Tables[0].Rows[z].vat_code;
			document.getElementById('txtvatrate').value=dsvatexecute.Tables[0].Rows[z].vat_rate;
			
			var dateformat = document.getElementById('hiddendateformat').value;
		    var fromdate="";
		    var todate="";
			if(dateformat=="dd/mm/yyyy")
		    {
                var txtfrom=dsvatexecute.Tables[0].Rows[z].vat_from_date;
                var txtto=dsvatexecute.Tables[0].Rows[z].vat_to_date;

                var txt1=txtfrom.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
                var txtto1=txtto.split("/");
                var dd1=txtto1[0];
                var mm1=txtto1[1];
                var yy1=txtto1[2];
                todate=mm1+'/'+dd1+'/'+yy1;

            }
			else if(dateformat=="mm/dd/yyyy")
			{
				fromdate=dsvatexecute.Tables[0].Rows[z].vat_from_date;
				todate=dsvatexecute.Tables[0].Rows[z].vat_to_date;
			}
								
		    else if(dateformat=="yyyy/mm/dd")
		    {
			    var txt=dsvatexecute.Tables[0].Rows[z].vat_from_date;
			    var txt1=txt.split("/");
			    var yy=txt1[2];
			    var mm=txt1[0];
			    var dd=txt1[1];
			    fromdate=yy+'/'+mm+'/'+dd;
			    var txtto=dsvatexecute.Tables[0].Rows[z].vat_to_date;
			    var txtto1=txtto.split("/");
			    var yy1=txtto1[2];
			    var mm1=txtto1[0];
			    var dd1=txtto1[1];
			    todate=yy1+'/'+mm1+'/'+dd1;
		    }
		    	if(dsvatexecute.Tables[0].Rows[z].PUBLICATION =="" || dsvatexecute.Tables[0].Rows[z].PUBLICATION==null)
			    {
			        document.getElementById('drpPubName').value="0";
			        document.getElementById('drEditonName').value="0";
			    }
			    else
			    {
			    document.getElementById('drpPubName').value=dsvatexecute.Tables[0].Rows[z].PUBLICATION;
			    addedition();
			    document.getElementById('drEditonName').value=dsvatexecute.Tables[0].Rows[z].EDITION;
			    }
		    document.getElementById('txtfromdate').value=fromdate;//dsvatexecute.Tables[0].Rows[z].vat_from_date;
		    document.getElementById('txttodate').value=todate;//dsvatexecute.Tables[0].Rows[z].vat_to_date;
			document.getElementById('drpgross').value=dsvatexecute.Tables[0].Rows[z].vat_gross_type;
			document.getElementById('txtorder').value=dsvatexecute.Tables[0].Rows[z].vat_order_no;
updateStatus();
			  //document.getElementById('btnModify').focus();
		        document.getElementById('btnnext').disabled=true;
		        document.getElementById('btnlast').disabled=true;
		        document.getElementById('btnfirst').disabled=false;
		        document.getElementById('btnprevious').disabled=false;
		        setButtonImages();
			return false;
}
function previousclick()
{
   var a=dsvatexecute.Tables[0].Rows.length;
   z--;
   if(z != -1)
		{
			if(z >= 0 && z <= a-1)
			{
		    document.getElementById('drpdescription').value=dsvatexecute.Tables[0].Rows[z].vat_description;
			//document.getElementById('txtcode').value=dsvatexecute.Tables[0].Rows[z].vat_code;
			document.getElementById('txtvatrate').value=dsvatexecute.Tables[0].Rows[z].vat_rate;
			
			var dateformat = document.getElementById('hiddendateformat').value;
		    var fromdate="";
		    var todate="";
			if(dateformat=="dd/mm/yyyy")
		    {
                var txtfrom=dsvatexecute.Tables[0].Rows[z].vat_from_date;
                var txtto=dsvatexecute.Tables[0].Rows[z].vat_to_date;

                var txt1=txtfrom.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
                var txtto1=txtto.split("/");
                var dd1=txtto1[0];
                var mm1=txtto1[1];
                var yy1=txtto1[2];
                todate=mm1+'/'+dd1+'/'+yy1;

            }
			else if(dateformat=="mm/dd/yyyy")
			{
				fromdate=dsvatexecute.Tables[0].Rows[z].vat_from_date;
				todate=dsvatexecute.Tables[0].Rows[z].vat_to_date;
			}
								
		    else if(dateformat=="yyyy/mm/dd")
		    {
			    var txt=dsvatexecute.Tables[0].Rows[z].vat_from_date;
			    var txt1=txt.split("/");
			    var yy=txt1[2];
			    var mm=txt1[0];
			    var dd=txt1[1];
			    fromdate=yy+'/'+mm+'/'+dd;
			    var txtto=dsvatexecute.Tables[0].Rows[z].vat_to_date;
			    var txtto1=txtto.split("/");
			    var yy1=txtto1[2];
			    var mm1=txtto1[0];
			    var dd1=txtto1[1];
			    todate=yy1+'/'+mm1+'/'+dd1;
		    }
		    	if(dsvatexecute.Tables[0].Rows[z].PUBLICATION =="" || dsvatexecute.Tables[0].Rows[z].PUBLICATION==null)
			    {
			        document.getElementById('drpPubName').value="0";
			        document.getElementById('drEditonName').value="0";
			    }
			    else
			    {
			    document.getElementById('drpPubName').value=dsvatexecute.Tables[0].Rows[z].PUBLICATION;
			    addedition();
			    document.getElementById('drEditonName').value=dsvatexecute.Tables[0].Rows[z].EDITION;
			    }
		    document.getElementById('txtfromdate').value=fromdate;//dsvatexecute.Tables[0].Rows[z].vat_from_date;
		    document.getElementById('txttodate').value=todate;//dsvatexecute.Tables[0].Rows[z].vat_to_date;
			document.getElementById('drpgross').value=dsvatexecute.Tables[0].Rows[z].vat_gross_type;
			document.getElementById('txtorder').value=dsvatexecute.Tables[0].Rows[z].vat_order_no;
			updateStatus();
			  //document.getElementById('btnModify').focus();
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
		setButtonImages();
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
function deleteclick()
{
updateStatus();
             var compcode=document.getElementById('hiddencomcode').value;
			 var description=document.getElementById('drpdescription').value;  
			 //var vatcode=document.getElementById('txtcode').value;
			 var vatrate=document.getElementById('txtvatrate').value;
		     var fromdate=document.getElementById('txtfromdate').value;
		     var todate=document.getElementById('txttodate').value;
			 var grosstype=document.getElementById('drpgross').value;
			 var orderno=document.getElementById('txtorder').value;
			 var userid=document.getElementById('hiddenuserid').value;
			 var publicat=document.getElementById('drpPubName').value;
		     var edit=document.getElementById('drEditonName').value;
			boolReturn = confirm("Are you sure you wish to delete this?");
			var dateformat = document.getElementById('hiddendateformat').value;
		    if(dateformat=="dd/mm/yyyy")
		    {
               
                var txt1=fromdate.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
                var txtto1=todate.split("/");
                var dd1=txtto1[0];
                var mm1=txtto1[1];
                var yy1=txtto1[2];
                todate=mm1+'/'+dd1+'/'+yy1;

            }
			else if(dateformat=="mm/dd/yyyy")
			{
//				fromdate=dsvatexecute.Tables[0].Rows[0].vat_from_date;
//				todate=dsvatexecute.Tables[0].Rows[0].vat_to_date;
			}
								
		    else if(dateformat=="yyyy/mm/dd")
		    {
			    var txt1=fromdate.split("/");
			    var yy=txt1[0];
			    var mm=txt1[1];
			    var dd=txt1[2];
			    fromdate=mm+'/'+dd+'/'+yy; 
			    var txtto1=todate.split("/");
			    var yy1=txtto1[0];
			    var mm1=txtto1[1];
			    var dd1=txtto1[2];
			    todate=mm1+'/'+dd1+'/'+yy1;
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
		if(boolReturn==1)
		{
		alert ("Data Deleted Successfully");
                   document.getElementById('drpgross').value=0;
                   document.getElementById('txtvatrate').value="";
                   document.getElementById('drpdescription').value="0";
                   document.getElementById('txtorder').value="";
                   document.getElementById('txtfromdate').value="";
                   document.getElementById('txttodate').value="";
                  // document.getElementById('txtcode').value="";
             
           Vatmaster.vatdelete(compcode, description,fromdate,todate,publicat,edit);
           Vatmaster.vatexecute(compcode,userid,glaobaldescription,glaobalvatrate,glaobalfromdate,glaobaltodate,glaobalgrosstype,glaobalorderno,delcall);
        }
           return false;
                   
}
function delcall(res)
{
    dsvatexecute=res.value;
    len=dsvatexecute.Tables[0].Rows.length;
    if(dsvatexecute.Tables[0].Rows.length==0)
{
   alert("No More Data is here to be deleted");
        document.getElementById('drpgross').value=0;
        document.getElementById('txtvatrate').value="";
        document.getElementById('drpdescription').value="0";
        document.getElementById('txtorder').value="";
        document.getElementById('txtfromdate').value="";
        document.getElementById('txttodate').value="";
        //document.getElementById('txtcode').value="";
        cancelclick('Vatmaster');
       return false;
 }
 else if(z>=len || z==-1)
	{
	
	
	
	//////////////
	
	
	var dateformat = document.getElementById('hiddendateformat').value;
		    var fromdate="";
		    var todate="";
			if(dateformat=="dd/mm/yyyy")
		    {
                var txtfrom=dsvatexecute.Tables[0].Rows[0].vat_from_date;
                var txtto=dsvatexecute.Tables[0].Rows[0].vat_to_date;

                var txt1=txtfrom.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
                var txtto1=txtto.split("/");
                var dd1=txtto1[0];
                var mm1=txtto1[1];
                var yy1=txtto1[2];
                todate=mm1+'/'+dd1+'/'+yy1;

            }
			else if(dateformat=="mm/dd/yyyy")
			{
				fromdate=dsvatexecute.Tables[0].Rows[0].vat_from_date;
				todate=dsvatexecute.Tables[0].Rows[0].vat_to_date;
			}
								
		    else if(dateformat=="yyyy/mm/dd")
		    {
			    var txt=dsvatexecute.Tables[0].Rows[0].vat_from_date;
			    var txt1=txt.split("/");
			    var yy=txt1[0];
			    var mm=txt1[1];
			    var dd=txt1[2];
			    fromdate=mm+'/'+dd+'/'+yy;
			    var txtto=dsvatexecute.Tables[0].Rows[0].vat_to_date;
			    var txtto1=txtto.split("/");
			    var yy1=txtto1[0];
			    var mm1=txtto1[1];
			    var dd1=txtto1[2];
			    todate=mm1+'/'+dd1+'/'+yy1;
		    }
		    
	
	
	
	
	
	//////////////
	        	if(dsvatexecute.Tables[0].Rows[0].PUBLICATION =="" || dsvatexecute.Tables[0].Rows[0].PUBLICATION==null)
			    {
			        document.getElementById('drpPubName').value="0";
			        document.getElementById('drEditonName').value="0";
			    }
			    else
			    {
			    document.getElementById('drpPubName').value=dsvatexecute.Tables[0].Rows[0].PUBLICATION;
			    addedition();
			    document.getElementById('drEditonName').value=dsvatexecute.Tables[0].Rows[0].EDITION;
			    }
		    document.getElementById('drpdescription').value=dsvatexecute.Tables[0].Rows[0].vat_description;
			//document.getElementById('txtcode').value=dsvatexecute.Tables[0].Rows[0].vat_code;
			document.getElementById('txtvatrate').value=dsvatexecute.Tables[0].Rows[0].vat_rate;
		    document.getElementById('txtfromdate').value=fromdate;
		    document.getElementById('txttodate').value=todate;
			document.getElementById('drpgross').value=dsvatexecute.Tables[0].Rows[0].vat_gross_type;
			document.getElementById('txtorder').value=dsvatexecute.Tables[0].Rows[0].vat_order_no;
			
	}
	else
	{
	
	//////
	
	var dateformat = document.getElementById('hiddendateformat').value;
		    var fromdate="";
		    var todate="";
			if(dateformat=="dd/mm/yyyy")
		    {
                var txtfrom=dsvatexecute.Tables[0].Rows[0].vat_from_date;
                var txtto=dsvatexecute.Tables[0].Rows[0].vat_to_date;

                var txt1=txtfrom.split("/");
                var dd=txt1[0];
                var mm=txt1[1];
                var yy=txt1[2];
                fromdate=mm+'/'+dd+'/'+yy;
                var txtto1=txtto.split("/");
                var dd1=txtto1[0];
                var mm1=txtto1[1];
                var yy1=txtto1[2];
                todate=mm1+'/'+dd1+'/'+yy1;

            }
			else if(dateformat=="mm/dd/yyyy")
			{
				fromdate=dsvatexecute.Tables[0].Rows[0].vat_from_date;
				todate=dsvatexecute.Tables[0].Rows[0].vat_to_date;
			}
								
		    else if(dateformat=="yyyy/mm/dd")
		    {
			    var txt=dsvatexecute.Tables[0].Rows[0].vat_from_date;
			    var txt1=txt.split("/");
			    var yy=txt1[0];
			    var mm=txt1[1];
			    var dd=txt1[2];
			    fromdate=mm+'/'+dd+'/'+yy;
			    var txtto=dsvatexecute.Tables[0].Rows[0].vat_to_date;
			    var txtto1=txtto.split("/");
			    var yy1=txtto1[0];
			    var mm1=txtto1[1];
			    var dd1=txtto1[2];
			    todate=mm1+'/'+dd1+'/'+yy1;
		    }
		    
	
	
	///
		    document.getElementById('drpdescription').value=dsvatexecute.Tables[0].Rows[z].vat_description;
			//document.getElementById('txtcode').value=dsvatexecute.Tables[0].Rows[z].vat_code;
			document.getElementById('txtvatrate').value=dsvatexecute.Tables[0].Rows[z].vat_rate;
		    document.getElementById('txtfromdate').value=fromdate;
		    document.getElementById('txttodate').value=todate;
			document.getElementById('drpgross').value=dsvatexecute.Tables[0].Rows[z].vat_gross_type;
			document.getElementById('txtorder').value=dsvatexecute.Tables[0].Rows[z].vat_order_no;
			
	}
	
		      if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==dsvatexecute.Tables[0].Rows.length)
              {
                document.getElementById('btnNext').disabled=true;
	            document.getElementById('btnLast').disabled=true;
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
function limet()

{
          
//          if(parseFloat(document.getElementById('txtvatrate').value)>100)
//          {
//              alert ("Rate should be less 100");
//             document.getElementById('txtvatrate').value="";
//             document.getElementById('txtvatrate').focus();
//          }
//        
         
		  //return false;  
		  

var sau=parseFloat(document.getElementById('txtvatrate').value);
//document.getElementById('txtsharing').value=sau;

if(sau>100)
{
    alert("Tax Rate (%) should not be greater than 100");
    document.getElementById('txtvatrate').value="";
    document.getElementById('txtvatrate').focus();
    return false;
}

var num=document.getElementById('txtvatrate').value;
var tomatch=/^\d*(\.\d{1,2})?$/;
if (tomatch.test(num))
{
return true;
}
else
{
alert("Input error");
document.getElementById('txtvatrate').value="";
document.getElementById('txtvatrate').focus();

return false; 

}
}
function vatdate()
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
Vatmaster.chkdate(description, fromdate, todate,call_date)
}
function call_date(response)
{
var ds=response.value;
 if(ds.Tables[0].Rows.length > 0)
    {
    alert("This date has been already assigned")
        return false;      
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

function clearvatmaster() {
    cancelclick('Vatmaster');
    document.getElementById('btnNew').focus();
    givebuttonpermission('Vatmaster');
 

}

function entertovatmaster(event)
{
 var key = event.keyCode ? event.keyCode : event.which;

if(key==13)
{
if(document.activeElement.id=="drpPubName")
{
document.getElementById("drEditonName").focus();
return false;

}
if(document.activeElement.id=="drEditonName")
{
document.getElementById("txtfromdate").focus();
return false;

}
if(document.activeElement.id=="txtfromdate")
{
document.getElementById("txttodate").focus();
return false;

}
if(document.activeElement.id=="txttodate")
{
document.getElementById("drpdescription").focus();
return false;

}
if(document.activeElement.id=="drpdescription")
{
document.getElementById("txtorder").focus();
return false;

}
if(document.activeElement.id=="txtorder")
{
document.getElementById("txtvatrate").focus();
return false;

}
if(document.activeElement.id=="txtvatrate")
{
document.getElementById("drpgross").focus();
return false;

}

if(document.activeElement.id=="drpgross")
{
document.getElementById("btnSave").focus();
return false;

}
}
}


function checkfield(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (event.keyCode == "13" || event.keyCode == "9") 
    {
      
       
            if (document.activeElement.id == "drpPubName") {
                if (key == 13 || key == 9) {
                    document.getElementById('drEditonName').focus();
                    return false;
                }
            }
            if (document.activeElement.id == "drEditonName") {
                if (key == 13 || key == 9) {
                    document.getElementById('txtfromdate').focus();
                    return false;
                }
            }
            if (document.activeElement.id == "txtfromdate") {
                if (key == 13 || key == 9) {
                    document.getElementById('txttodate').focus();
                    return false;
                }
            }
            if (document.activeElement.id == "txttodate") {
                if (key == 13 || key == 9) {
                    document.getElementById('drpdescription').focus();
                    return false;
                }
            }
            if (document.activeElement.id == "drpdescription") {
                if (key == 13 || key == 9) {
                    document.getElementById('txtorder').focus();
                    return false;
                }
            }
            if (document.activeElement.id == "txtorder") {
                if (key == 13 || key == 9) {
                    document.getElementById('txtvatrate').focus();
                    return false;
                }
            }
            if (document.activeElement.id == "txtvatrate") {
                if (key == 13 || key == 9) {
                    document.getElementById('drpgross').focus();
                    return false;
                }
            }

            if (document.activeElement.id == "drpgross") {
                if (key == 13 || key == 9) {
                    document.getElementById('btnSave').focus();
                    return false;
                }
            }
        
        
    
    }


}