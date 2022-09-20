var modi;
 var z;
 var hiddentext;
 var auto;
 var dsget;
 var code;
 var name;
 var browser=navigator.appName;
var cityvar;
var xmlDoc=null;
var xmlObj=null;
var distcode;
var statecode;
var req=null;
var modchk;
var chkmand = "";
var citycd;
function loadXML(xmlFile) 
{
    var  httpRequest =null;
    
    if(browser!="Microsoft Internet Explorer")
    { 
        
        req = new XMLHttpRequest();
        //alert(req);
        req.onreadystatechange = getMessage;
        req.open("GET",xmlFile, true);
        req.send('');
        
    }
    else
    {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async="false"; 
        xmlDoc.onreadystatechange=verify; 
        xmlDoc.load(xmlFile); 
        xmlObj=xmlDoc.documentElement; 
        // alert(xmlObj.childNodes(0).childNodes(0).text);
    }

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

function verify() 
{ 
 // 0 Object is not initialized 
 // 1 Loading object is loading data 
 // 2 Loaded object has loaded data 
 // 3 Data from object can be worked with 
 // 4 Object completely initialized 
 if (xmlDoc.readyState != 4) 
 { 
   return false; 
 } 
}

 
 
   function docnew()
   {
	modi=0;
	         if(document.getElementById('hiddenauto').value==1)
		       {
		      document.getElementById('txtrepcode').disabled=true;
    	        }
		     else
		       {
		       document.getElementById('txtrepcode').disabled=false;
    	       }
	//document.getElementById('txtrepcode').disabled=false;
	document.getElementById('txtrepname').disabled=false;
	if(document.getElementById('hiddenauto').value==1)
		       {
		      document.getElementById('txtrepname').focus();
    	        }
		     else
		       {
		       document.getElementById('txtrepcode').focus();
    	       }
	
	document.getElementById('txtcountry').disabled=false;
	document.getElementById('txtcity').disabled=false;
	document.getElementById('txtdist').disabled=true;
	document.getElementById('txtstate').disabled=true;
	document.getElementById('txttaluka').disabled=false;
	document.getElementById('txtrepstatus').disabled=false;
	
	
	chkstatus(FlagStatus);	
	hiddentext="new";		
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;
	statecode="";
	distcode="";
	setButtonImages();
	return false;
   }
   
   
   function canceldoc(formname)
	{
			
		  document.getElementById('txtrepcode').disabled=true;
		  document.getElementById('txtrepname').disabled=true;
		  document.getElementById('txtcountry').disabled=true;
	      document.getElementById('txtcity').disabled=true;
	      document.getElementById('txtstate').disabled=true;
	      document.getElementById('txtdist').disabled=true;
	      document.getElementById('txttaluka').disabled=true;
	      document.getElementById('txtrepstatus').disabled=true;
		  
		  document.getElementById('txtrepcode').value="";
		  document.getElementById('txtrepname').value="";
		  document.getElementById('txtcountry').value="0";
		  document.getElementById('txtcity').value="0";
		  document.getElementById('txtstate').value="";
		  document.getElementById('txtdist').value="";
		  document.getElementById('txttaluka').value="0";
		  document.getElementById('txtrepstatus').value	="Active";
		  //document.getElementById('btnNew').disabled=true;
			
			chkstatus(FlagStatus);
			
			givebuttonpermission(formname);
			
			/*document.getElementById('btnNew').disabled=false;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnExit').disabled=false;*/
			
			//getPermission('RepMast');
			setButtonImages();
			if(FlagStatus!=2 && FlagStatus!=4 && FlagStatus!=6)
			document.getElementById('btnNew').focus();
			return false;
		}


function docsave()
	{
	//debugger;
	document.getElementById('txtrepname').value=trim(document.getElementById('txtrepname').value);
	document.getElementById('txtrepcode').value=trim(document.getElementById('txtrepcode').value);

			if((document.getElementById('txtrepcode').value=="") && (document.getElementById('hiddenauto').value!=1))
			{
			alert("Please Enter Representative Code");
			document.getElementById('txtrepcode').focus();
			return false;
			}
			if(document.getElementById('txtrepname').value=="")
			{
			alert("Please Enter Representative Name");
			document.getElementById('txtrepname').focus();
			return false;
			}
			if(document.getElementById('txtcity').value=="" ||  document.getElementById('txtcity').value=="0")
			{
			alert("Please Enter City");
			document.getElementById('txtcity').focus();
			return false;
			}
			if(document.getElementById('txtstate').value=="")
			{
			alert("Please Enter State");
			document.getElementById('txtstate').focus();
			return false;
			}
			if(document.getElementById('txtdist').value=="")
			{
			alert("Please Enter District");
			document.getElementById('txtdist').focus();
			return false;

            }
            if (browser != "Microsoft Internet Explorer") {
                chkmand = document.getElementById('taluka').textContent;
            }
            else {
                chkmand = document.getElementById('taluka').innerText;
            }
            if (chkmand.indexOf('*') >= 0) {
                if (document.getElementById('txttaluka').value == "" || document.getElementById('txttaluka').value == "0") {
                    alert("Please Enter Taluka");
                    document.getElementById('txttaluka').focus();
                    return false;
                }
            }
			var state;
			var dist;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var repcode=document.getElementById('txtrepcode').value;
			var repname=document.getElementById('txtrepname').value;
			var country=document.getElementById('txtcountry').value;
			var city=document.getElementById('txtcity').value;
            if(statecode=="undefined")
			    state="";//document.getElementById('txtstate').value;
			else
			    state=statecode;
			
			if(dist=="undefined")
			    dist="";//document.getElementById('txtstate').value;
			else
			    dist=distcode;
			
			var taluka1=document.getElementById('txttaluka').value;
			var repstatus=document.getElementById('txtrepstatus').value;
		if(modi==0)
		{	
			RepMast.docchk(compcode,userid,repcode,repname,dist,taluka1,callchk)
			return false;
		}
		else
		{
		    if(document.getElementById('txtrepname').value != modchk)
		    {
		        var res1=RepMast.docchk(compcode,userid,repcode,repname,dist,taluka1)
		        var ds= res1.value;
		             if(ds.Tables[1].Rows.length >0)
		                {
		                 alert("This Representative Name already Exist   Please Try Another Name");
			             document.getElementById('txtrepname').value="";
			             document.getElementById('txtrepname').focus();
		                    return false;
		                    }
		                    else
		                    {
		                    RepMast.modify(compcode,userid,repcode,repname,country, city, state, dist, taluka1, repstatus);
		                    
		                    }
			    //return false;
		    }
		    else
			RepMast.modify(compcode,userid,repcode,repname,country, city, state, dist, taluka1, repstatus);
		//	alert("Data Modified");
		if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[3].childNodes[0].nodeValue);
                }
                else
                {
                    alert(xmlObj.childNodes(0).childNodes(1).text);
                }
			updateStatus();
			document.getElementById('txtrepcode').disabled=true;
			document.getElementById('txtrepname').disabled=true;
			document.getElementById('txtcountry').disabled=true;
			document.getElementById('txtcity').disabled=true;
			document.getElementById('txtdist').disabled=true;
			document.getElementById('txtstate').disabled=true;
			document.getElementById('txttaluka').disabled=true;
			document.getElementById('txtrepstatus').disabled=true;
			
			dsget.Tables[0].Rows[z].Rep_code=document.getElementById('txtrepcode').value
			dsget.Tables[0].Rows[z].Rep_Name=document.getElementById('txtrepname').value
			dsget.Tables[0].Rows[z].Country_Code=document.getElementById('txtcountry').value
			dsget.Tables[0].Rows[z].City_Code=document.getElementById('txtcity').value
			dsget.Tables[0].Rows[z].State_Code=document.getElementById('txtdist').value
			dsget.Tables[0].Rows[z].Dist_Code=document.getElementById('txtstate').value
			dsget.Tables[0].Rows[z].Taluka=document.getElementById('txttaluka').value
			dsget.Tables[0].Rows[z].Rep_Status=document.getElementById('txtrepstatus').value
			
			if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==(dsget.Tables[0].Rows.length-1))
              {
                document.getElementById('btnNext').disabled=true;
	            document.getElementById('btnLast').disabled=true;
              } 
			
			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnExecute').disabled=true;
			document.getElementById('btnCancel').disabled=false;*/		
								
			/*document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=false;*/
			setButtonImages();
		return false;
		}
		setButtonImages();
			return false;
	}
		

function callchk(res)
	{
	  //debugger;  
		var ds= res.value;
		if(ds.Tables[0].Rows.length > 0)
		{
		    alert("This Representative Code already Exist   Please Try Another Code");
		    document.getElementById('txtrepcode').disabled=false;
			document.getElementById('txtrepname').disabled=false;
		    return false;
		}
		else if(ds.Tables[1].Rows.length >0)
		{
		    alert("This Representative Name already Exist   Please Try Another Name");
		    document.getElementById('txtrepcode').disabled=false;
			document.getElementById('txtrepname').disabled=false;
		    return false;
		}
	   else 
		{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var repcode=document.getElementById('txtrepcode').value;
			var repname=document.getElementById('txtrepname').value;
			var country=document.getElementById('txtcountry').value;
			var city=document.getElementById('txtcity').value;
			var state=statecode;//document.getElementById('txtstate').value;
			var dist=distcode;//document.getElementById('txtdist').value;
			var taluka1=document.getElementById('txttaluka').value;
			var repstatus=document.getElementById('txtrepstatus').value;
			
			RepMast.save(compcode,userid,repcode,repname,country, city, state, dist, taluka1, repstatus);
			
			document.getElementById('txtrepcode').disabled=true;
			document.getElementById('txtrepname').disabled=true;
			document.getElementById('txtcountry').disabled=true;
			document.getElementById('txtcity').disabled=true;
			document.getElementById('txtstate').disabled=true;
			document.getElementById('txtdist').disabled=true;
			document.getElementById('txttaluka').disabled=true;
			document.getElementById('txtrepstatus').disabled=true;
		
			//alert("Data Saved");
			if(browser!="Microsoft Internet Explorer")
                {
                    alert(xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue);
                }
                else
                {
                    alert(xmlObj.childNodes(0).childNodes(0).text);
                }
			document.getElementById('txtrepcode').value="";
			document.getElementById('txtrepname').value="";
			document.getElementById('txtcountry').value="";
			document.getElementById('txtcity').value="";
			document.getElementById('txtstate').value="";
			document.getElementById('txtdist').value="";
			document.getElementById('txttaluka').value="";
			document.getElementById('txtrepstatus').value="";
			
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
			canceldoc('RepMast');
			return false;
		}
		
		
		
		
		
		
	}
	
	
	function docmodify()
		{
			modi= "2";
			//document.getElementById('btnQuery').disabled = true;
				chkstatus(FlagStatus);

				document.getElementById('btnSave').disabled = false;
				document.getElementById('btnQuery').disabled = true;
				document.getElementById('btnExecute').disabled=true;
				hiddentext="modify";
			/*	document.getElementById('btnNew').disabled=true;
				document.getElementById('btnSave').disabled=false;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnDelete').disabled=true;
				document.getElementById('btnQuery').disabled=true;
				document.getElementById('btnExecute').disabled=true;
				document.getElementById('btnCancel').disabled=false;		
				document.getElementById('btnfirst').disabled=true;				
				document.getElementById('btnnext').disabled=true;					
				document.getElementById('btnprevious').disabled=true;			
				document.getElementById('btnlast').disabled=true;			
				document.getElementById('btnExit').disabled=false;*/
				modchk=document.getElementById('txtrepname').value;
				document.getElementById('txtrepcode').disabled=true;
			    document.getElementById('txtrepname').disabled=false;
				document.getElementById('txtcountry').disabled=true;
			    document.getElementById('txtcity').disabled=false;
			    document.getElementById('txtstate').disabled=true;
			    document.getElementById('txtdist').disabled=true;
			    document.getElementById('txttaluka').disabled=false;
			    document.getElementById('txtrepstatus').disabled=false;
				setButtonImages();
		return false;		
		}
		
		
		
function docquery(formname)
{	
		  hiddentext="query";
		  document.getElementById('txtrepcode').disabled=false;
		  document.getElementById('txtrepname').disabled=false;
		  document.getElementById('txtcountry').disabled=true;
		  document.getElementById('txtcity').disabled=true;
		  document.getElementById('txtstate').disabled=true;
		  document.getElementById('txtdist').disabled=true;
		  document.getElementById('txttaluka').disabled=true;
		  document.getElementById('txtrepstatus').disabled=true;
			
		  document.getElementById('txtrepcode').value="";
		  document.getElementById('txtrepname').value="";
		  document.getElementById('txtcountry').value="0";
		  document.getElementById('txtcity').value="0";
		  document.getElementById('txtstate').value="";
		  document.getElementById('txtdist').value="";
		  document.getElementById('txttaluka').value="0";
		  document.getElementById('txtrepstatus').value	="Active";
		  chkstatus(FlagStatus);
				
	      document.getElementById('btnQuery').disabled=true;
	      document.getElementById('btnExecute').disabled=false;
	      document.getElementById('btnSave').disabled=true;
			/*document.getElementById('btnNew').disabled=true;
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnprevious').disabled=true;
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnlast').disabled=true;			
			document.getElementById('btnExit').disabled=false;*/
		    z=0;
		    statecode="";
		    distcode="";
		    setButtonImages();
			document.getElementById('btnExecute').focus();
				return false;
		}
		
		
		
		
		function docexe()
		{
		    z=0;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			var repcode=document.getElementById('txtrepcode').value;
			var repname=document.getElementById('txtrepname').value;
			
			code=repcode;
			name=repname;
			
			RepMast.exe(compcode,userid,repcode,repname,callexe)
			
			updateStatus();
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=false;	
		if(document.getElementById('btnModify').disabled==false)					
		   document.getElementById('btnModify').focus();	
			
		return false;
		}
		
function callexe(res)
		{
		//	var ds=res.value;
		    dsget=res.value;
				if(dsget.Tables[0].Rows.length==0)
				{
					alert("Your Search Can Not Produce Any Result");
					canceldoc('RepMast');
					setButtonImages();
					return false;
				}
				else
				{
					document.getElementById('txtrepcode').value=dsget.Tables[0].Rows[0].Rep_code;
					document.getElementById('txtrepname').value=dsget.Tables[0].Rows[0].Rep_Name;
					if(dsget.Tables[0].Rows[0].Country_Code == null)
					    document.getElementById('txtcountry').value="0";
					else
					    document.getElementById('txtcountry').value=dsget.Tables[0].Rows[0].Country_Code;
				
				    if(dsget.Tables[0].Rows[0].City_Code == null)
				        cityvar="";
				    else
					    cityvar=dsget.Tables[0].Rows[0].City_Code;
					//addcount(document.getElementById('txtcountry').value);
					var country=document.getElementById('txtcountry').value;
					// fro binding city in retainer
					 if(country!="0")
                    {
                        document.getElementById('txtdist').value="";
                        document.getElementById('txtstate').value="";
                        document.getElementById('txttaluka').value="0";
                         var res= RepMast.getfromc(country);
                         var ds=res.value;
                        var pkgitem = document.getElementById("txtcity");
                        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
                        {
                        pkgitem.options.length = 1; 
                        pkgitem.options[0]=new Option("--Select City--","0");
                        for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
                        {
                            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
                            pkgitem.options.length;
                        }
                       
                         if(cityvar == undefined || cityvar=="")
                         {
                           document.getElementById('txtcity').value="0";
                         }
                         else
                         {
                           document.getElementById('txtcity').value=cityvar;
                           document.getElementById('hdncity').value=document.getElementById('txtcity').value;
           citycd=document.getElementById('hdncity').value;
                           cityvar="";
                         } 
                     
                    }
                    else
                    {
                        if(document.getElementById('txtcity').disabled==false)
                        {
                          alert("There is No Matching value Found");
                        }
                        pkgitem.options.length = 1; 
                        pkgitem.options[0]=new Option("--Select City--","0");
                    }

                    }
                    else
                    {
                        document.getElementById("txtcity").options.length = 1;
                        document.getElementById('txtdist').value="";
                        document.getElementById('txtstate').value="";
                        document.getElementById('txttaluka').value="0";
                        statecode="";
                        distcode="";
                    }
					//----------------------
					var city1=document.getElementById('txtcity').value;
					//adddiststate(cityvar); //cityvar
					// for binding state
					  if(city1!="0")		
	                        {
	                        //RepMast.addcitydist(city1,FillDropDownList_CallBackMaindoc);
	                        var compcode=document.getElementById('hiddencompcode').value;
                               var response=RepMast.addcitydist(city1,compcode);
                                     var ds = response.value;
	                                var cou="INDIA";	
	                                var taluka=document.getElementById('txttaluka');
                                	
                                   if(document.getElementById('txtcity').value!="0" && document.getElementById('txtcity').value!="")
                                   {
	                                if(ds!= null && typeof(ds) == "object" && ds.Tables!= null) 
                                    {	
                                                
				                                document.getElementById("txttaluka").options[0]=new Option("------Select Taluka------","0");
                                				
				                                document.getElementById("txttaluka").options.length=0;		
				                                document.getElementById("txttaluka").options.length=ds.Tables[7].Rows.length;
                                				
			                                    if(ds.Tables[0].Rows.length>0)
				                                {
					                                document.getElementById('txtstate').value=ds.Tables[0].Rows[0].state_name;
					                                statecode=ds.Tables[0].Rows[0].state_code;
				                                }
				                                else
				                                {
				                                    document.getElementById('txtstate').value="";
				                                }
                                					
				                                if(ds.Tables[1].Rows.length>0)
				                                {
				                                    document.getElementById('txtdist').value=ds.Tables[1].Rows[0].dist_name;
				                                    distcode=ds.Tables[1].Rows[0].dist_code;
				                                }
				                                else
			                                    {
			                                        if(document.getElementById('txtcity').disabled==false)
                                                    {
			                                            //alert("There is no matching value for district");//change due to no region in city master
			                                        }
			                                        document.getElementById('txtdist').value="";
			                                    }
                                					
				                                if(ds.Tables[7].Rows.length>0)
		                                        {	
    				                                for(var i=0;i<ds.Tables[7].Rows.length;++i) 
	    			                                {
    					                                document.getElementById("txttaluka").options[i]=new Option(ds.Tables[7].Rows[i].talu_name,ds.Tables[7].Rows[i].talu_code);
	    			                                }
	    			                                if(dsget!=null)	
	    			                                  document.getElementById('txttaluka').value=dsget.Tables[0].Rows[z].Taluka ;
	    			                                else
	    			                                  document.getElementById('txttaluka').value=ds.Tables[7].Rows[0].talu_code;//dsget.Tables[0].Rows[0].Taluka 
	    		                                 }
        	                                    else
                                                {
                                                  taluka.options.length=0;
                                                }
                                				
		                                }
	                                }	
                            }
                            else
                            {
                                document.getElementById('txtdist').value="";
                                document.getElementById('txtstate').value="";
                                document.getElementById('txttaluka').value="0";
                            }
					// end---------
		          //  document.getElementById('txtcity').value=dsget.Tables[0].Rows[0].City_Code;
		        /*  
		           if(dsget.Tables[0].Rows[0].State_Code ==null)
		                 document.getElementById('txtstate').value="";
                   else		                 
		                document.getElementById('txtstate').value=dsget.Tables[0].Rows[0].State_Code;
		           
		           if(dsget.Tables[0].Rows[0].Dist_Code==null)  
		                dsget.Tables[0].Rows[0].Dist_Code="";
		           else
		                document.getElementById('txtdist').value=dsget.Tables[0].Rows[0].Dist_Code;*/
		         //    document.getElementById('txttaluka').value=dsget.Tables[0].Rows[0].Taluka;
		            document.getElementById('txtrepstatus').value=dsget.Tables[0].Rows[0].Rep_Status;
		            
		            document.getElementById('txtrepcode').disabled=true;
		            document.getElementById('txtrepname').disabled=true;
		            document.getElementById('txtcountry').disabled=true;
		            document.getElementById('txtcity').disabled=true;
		            document.getElementById('txtstate').disabled=true;
		            document.getElementById('txtdist').disabled=true;
		            document.getElementById('txttaluka').disabled=true;
		            document.getElementById('txtrepstatus').disabled=true;
		           
							
				}
				
				if(dsget.Tables[0].Rows.length==1)
				{
				    document.getElementById('btnfirst').disabled=true;				
			        document.getElementById('btnprevious').disabled=true;			
			        document.getElementById('btnnext').disabled=true;					
			        document.getElementById('btnlast').disabled=true;
				
				
				}
				setButtonImages();
			return false;
		}
		
		
		
		
		
function docfirst()
{
z=0;
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
			RepMast.fnpl(compcode,userid,claafirst);
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


function claafirst(response)
		{
		//alert("first");

			//var	ds=response.value;
			   // dsget=response.value;
			
					document.getElementById('txtrepcode').value=dsget.Tables[0].Rows[0].Rep_code;
					document.getElementById('txtrepname').value=dsget.Tables[0].Rows[0].Rep_Name;
					if(dsget.Tables[0].Rows[0].Country_Code ==null)
					    document.getElementById('txtcountry').value="0";
					else
				    	document.getElementById('txtcountry').value=dsget.Tables[0].Rows[0].Country_Code;
				    	
		             if(dsget.Tables[0].Rows[0].City_Code == null)
				        cityvar="";
				    else
					    cityvar=dsget.Tables[0].Rows[0].City_Code;
					//addcount(document.getElementById('txtcountry').value);
					//adddiststate(dsget.Tables[0].Rows[0].City_Code); //cityvar
						var country=document.getElementById('txtcountry').value;
					// fro binding city in retainer
					 if(country!="0")
                    {
                        document.getElementById('txtdist').value="";
                        document.getElementById('txtstate').value="";
                        document.getElementById('txttaluka').value="0";
                         var res= RepMast.getfromc(country);
                         var ds=res.value;
                        var pkgitem = document.getElementById("txtcity");
                        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
                        {
                        pkgitem.options.length = 1; 
                        pkgitem.options[0]=new Option("--Select City--","0");
                        for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
                        {
                            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
                            pkgitem.options.length;
                        }
                       
                         if(cityvar == undefined || cityvar=="")
                         {
                           document.getElementById('txtcity').value="0";
                         }
                         else
                         {
                           document.getElementById('txtcity').value=cityvar;
                           document.getElementById('hdncity').value=document.getElementById('txtcity').value;
           citycd=document.getElementById('hdncity').value;
                           cityvar="";
                         } 
                     
                    }
                    else
                    {
                        if(document.getElementById('txtcity').disabled==false)
                        {
                          alert("There is No Matching value Found");
                        }
                        pkgitem.options.length = 1; 
                        pkgitem.options[0]=new Option("--Select City--","0");
                    }

                    }
                    else
                    {
                        document.getElementById("txtcity").options.length = 1;
                        document.getElementById('txtdist').value="";
                        document.getElementById('txtstate').value="";
                        document.getElementById('txttaluka').value="0";
                        statecode="";
                        distcode="";
                    }
					//----------------------
					var city1=document.getElementById('txtcity').value;
					//adddiststate(cityvar); //cityvar
					// for binding state
					  if(city1!="0")		
	                        {
	                        //RepMast.addcitydist(city1,FillDropDownList_CallBackMaindoc);
	                         var compcode=document.getElementById('hiddencompcode').value;
                               var response=RepMast.addcitydist(city1,compcode);
                               //var response=RepMast.addcitydist(city1);
                                     var ds = response.value;
	                                var cou="INDIA";	
	                                var taluka=document.getElementById('txttaluka');
                                	
                                   if(document.getElementById('txtcity').value!="0" && document.getElementById('txtcity').value!="")
                                   {
	                                if(ds!= null && typeof(ds) == "object" && ds.Tables!= null) 
                                    {	
                                                
				                                document.getElementById("txttaluka").options[0]=new Option("------Select Taluka------","0");
                                				
				                                document.getElementById("txttaluka").options.length=0;		
				                                document.getElementById("txttaluka").options.length=ds.Tables[7].Rows.length;
                                				
			                                    if(ds.Tables[0].Rows.length>0)
				                                {
					                                document.getElementById('txtstate').value=ds.Tables[0].Rows[0].state_name;
					                                statecode=ds.Tables[0].Rows[0].state_code;
				                                }
				                                else
				                                {
				                                    document.getElementById('txtstate').value="";
				                                }
                                					
				                                if(ds.Tables[1].Rows.length>0)
				                                {
				                                    document.getElementById('txtdist').value=ds.Tables[1].Rows[0].dist_name;
				                                    distcode=ds.Tables[1].Rows[0].dist_code;
				                                }
				                                else
			                                    {
			                                        if(document.getElementById('txtcity').disabled==false)
                                                    {
			                                            //alert("There is no matching value for district");//change due to no region in city master
			                                        }
			                                        document.getElementById('txtdist').value="";
			                                    }
                                					
				                                if(ds.Tables[7].Rows.length>0)
		                                        {	
    				                                for(var i=0;i<ds.Tables[7].Rows.length;++i) 
	    			                                {
    					                                document.getElementById("txttaluka").options[i]=new Option(ds.Tables[7].Rows[i].talu_name,ds.Tables[7].Rows[i].talu_code);
	    			                                }
	    			                                if(dsget!=null)	
	    			                                  document.getElementById('txttaluka').value=dsget.Tables[0].Rows[z].Taluka ;
	    			                                else
	    			                                  document.getElementById('txttaluka').value=ds.Tables[7].Rows[0].talu_code;//dsget.Tables[0].Rows[0].Taluka 
	    		                                 }
        	                                    else
                                                {
                                                  taluka.options.length=0;
                                                }
                                				
		                                }
	                                }	
                            }
                            else
                            {
                                document.getElementById('txtdist').value="";
                                document.getElementById('txtstate').value="";
                                document.getElementById('txttaluka').value="0";
                            }
					// end---------
		            //document.getElementById('txtcity').value=dsget.Tables[0].Rows[0].City_Code;
		          /*  if(dsget.Tables[0].Rows[0].State_Code ==null)
		                 document.getElementById('txtstate').value="";
                     else
		                document.getElementById('txtstate').value=dsget.Tables[0].Rows[0].State_Code;
		              
		             if(dsget.Tables[0].Rows[0].Dist_Code==null)  
		                dsget.Tables[0].Rows[0].Dist_Code="";
		             else    
		            document.getElementById('txtdist').value=dsget.Tables[0].Rows[0].Dist_Code;*/
		            
		            document.getElementById('txttaluka').value=dsget.Tables[0].Rows[0].Taluka;
		            document.getElementById('txtrepstatus').value=dsget.Tables[0].Rows[0].Rep_Status;
					updateStatus();

                    document.getElementById('btnfirst').disabled=true;				
	                document.getElementById('btnprevious').disabled=true;
	                document.getElementById('btnnext').disabled=false;					
			        document.getElementById('btnlast').disabled=false;	
					setButtonImages();
					return false;
		}

function docpre()
	{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
			RepMast.fnpl(compcode,userid,precall);
			return false;
	}

function precall(response)
	{
	//alert("pre");

		z--;
		//var ds=response.value;
		 //dsget=response.value;
	    var x=dsget.Tables[0].Rows.length;
		
		
			if(z>x)
			{
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=true;
			return false;
			}
		if(z!=-1 && z>=0)
		{
			if(dsget.Tables[0].Rows.length != z)
			{
					document.getElementById('txtrepcode').value=dsget.Tables[0].Rows[z].Rep_code;
					document.getElementById('txtrepname').value=dsget.Tables[0].Rows[z].Rep_Name;
					
					if(dsget.Tables[0].Rows[z].Country_Code ==null)
				       document.getElementById('txtcountry').value="0";
				    else 
				       document.getElementById('txtcountry').value=dsget.Tables[0].Rows[z].Country_Code;
                   
                    if(dsget.Tables[0].Rows[z].City_Code ==null)	
                     	cityvar="";
                     else	       
					    cityvar=dsget.Tables[0].Rows[z].City_Code;
					     
					//addcount(document.getElementById('txtcountry').value);
					//adddiststate(cityvar); //cityvar
						var country=document.getElementById('txtcountry').value;
					// fro binding city in retainer
					 if(country!="0")
                    {
                        document.getElementById('txtdist').value="";
                        document.getElementById('txtstate').value="";
                        document.getElementById('txttaluka').value="0";
                         var res= RepMast.getfromc(country);
                         var ds=res.value;
                        var pkgitem = document.getElementById("txtcity");
                        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
                        {
                        pkgitem.options.length = 1; 
                        pkgitem.options[0]=new Option("--Select City--","0");
                        for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
                        {
                            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
                            pkgitem.options.length;
                        }
                       
                         if(cityvar == undefined || cityvar=="")
                         {
                           document.getElementById('txtcity').value="0";
                         }
                         else
                         {
                           document.getElementById('txtcity').value=cityvar;
                           document.getElementById('hdncity').value=document.getElementById('txtcity').value;
           citycd=document.getElementById('hdncity').value;
                           cityvar="";
                         } 
                     
                    }
                    else
                    {
                        if(document.getElementById('txtcity').disabled==false)
                        {
                          alert("There is No Matching value Found");
                        }
                        pkgitem.options.length = 1; 
                        pkgitem.options[0]=new Option("--Select City--","0");
                    }

                    }
                    else
                    {
                        document.getElementById("txtcity").options.length = 1;
                        document.getElementById('txtdist').value="";
                        document.getElementById('txtstate').value="";
                        document.getElementById('txttaluka').value="0";
                        statecode="";
                        distcode="";
                    }
					//----------------------
					var city1=document.getElementById('txtcity').value;
					//adddiststate(cityvar); //cityvar
					// for binding state
					  if(city1!="0")		
	                        {
	                            //RepMast.addcitydist(city1,FillDropDownList_CallBackMaindoc);
	                            var compcode = document.getElementById('hiddencompcode').value;
	                            var response = RepMast.addcitydist(city1, compcode);
                                     var ds = response.value;
	                                var cou="INDIA";	
	                                var taluka=document.getElementById('txttaluka');
                                	
                                   if(document.getElementById('txtcity').value!="0" && document.getElementById('txtcity').value!="")
                                   {
	                                if(ds!= null && typeof(ds) == "object" && ds.Tables!= null) 
                                    {	
                                                
				                                document.getElementById("txttaluka").options[0]=new Option("------Select Taluka------","0");
                                				
				                                document.getElementById("txttaluka").options.length=0;		
				                                document.getElementById("txttaluka").options.length=ds.Tables[8].Rows.length;
                                				
			                                    if(ds.Tables[0].Rows.length>0)
				                                {
					                                document.getElementById('txtstate').value=ds.Tables[0].Rows[0].state_name;
					                                statecode=ds.Tables[0].Rows[0].state_code;
				                                }
				                                else
				                                {
				                                    document.getElementById('txtstate').value="";
				                                }
                                					
				                                if(ds.Tables[1].Rows.length>0)
				                                {
				                                    document.getElementById('txtdist').value=ds.Tables[1].Rows[0].dist_name;
				                                    distcode=ds.Tables[1].Rows[0].dist_code;
				                                }
				                                else
			                                    {
			                                        if(document.getElementById('txtcity').disabled==false)
                                                    {
			                                            //alert("There is no matching value for district");//change due to no region in city master
			                                        }
			                                        document.getElementById('txtdist').value="";
			                                    }
                                					
				                                if(ds.Tables[8].Rows.length>0)
		                                        {	
    				                                for(var i=0;i<ds.Tables[8].Rows.length;++i) 
	    			                                {
    					                                document.getElementById("txttaluka").options[i]=new Option(ds.Tables[8].Rows[i].talu_name,ds.Tables[8].Rows[i].talu_code);
	    			                                }
	    			                                if(dsget!=null)	
	    			                                  document.getElementById('txttaluka').value=dsget.Tables[0].Rows[z].Taluka ;
	    			                                else
	    			                                  document.getElementById('txttaluka').value=ds.Tables[8].Rows[0].talu_code;//dsget.Tables[0].Rows[0].Taluka 
	    		                                 }
        	                                    else
                                                {
                                                  taluka.options.length=0;
                                                }
                                				
		                                }
	                                }	
                            }
                            else
                            {
                                document.getElementById('txtdist').value="";
                                document.getElementById('txtstate').value="";
                                document.getElementById('txttaluka').value="0";
                            }
					// end---------
					
		         //   document.getElementById('txtcity').value=dsget.Tables[0].Rows[z].City_Code;
		           /* if(dsget.Tables[0].Rows[z].State_Code== null)
	                   document.getElementById('txtstate').value="";
		            else 
		               document.getElementById('txtstate').value=dsget.Tables[0].Rows[z].State_Code;
		            
		            if(dsget.Tables[0].Rows[z].Dist_Code== null)
	                    document.getElementById('txtdist').value="";
		             else
		               document.getElementById('txtdist').value=dsget.Tables[0].Rows[z].Dist_Code;*/
		               
		            document.getElementById('txttaluka').value=dsget.Tables[0].Rows[z].Taluka;
		            document.getElementById('txtrepstatus').value=dsget.Tables[0].Rows[z].Rep_Status;
					updateStatus();
		
			        document.getElementById('btnfirst').disabled=false;				
			        document.getElementById('btnnext').disabled=false;					
			        document.getElementById('btnprevious').disabled=false;			
			        document.getElementById('btnlast').disabled=false;
			
			}
		else
		{
		    document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}
	}	
	else
		{
		document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=true;
			document.getElementById('btnprevious').disabled=true;
		}
	if (z<=0)
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

function docnext()
	{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			
			RepMast.fnpl(compcode,userid,nextcall)
			return false;
}

function nextcall(response)
{
//alert("next");
z++;
	//var ds=response.value;
	// dsget=response.value;
	var x=dsget.Tables[0].Rows.length;
	if(z <= x && z >= 0)
	{
		if(dsget.Tables[0].Rows.length != z && z !=-1)
		{
				document.getElementById('txtrepcode').value=dsget.Tables[0].Rows[z].Rep_code;
				document.getElementById('txtrepname').value=dsget.Tables[0].Rows[z].Rep_Name;
				if(dsget.Tables[0].Rows[z].Country_Code ==null)
				    document.getElementById('txtcountry').value="0";
				else 
				    document.getElementById('txtcountry').value=dsget.Tables[0].Rows[z].Country_Code;
				
				if(dsget.Tables[0].Rows[z].City_Code == null)
				   cityvar="";
			     else
				   cityvar=dsget.Tables[0].Rows[z].City_Code;
				   
				//addcount(document.getElementById('txtcountry').value);
				//adddiststate(cityvar); //cityvar
						var country=document.getElementById('txtcountry').value;
					// fro binding city in retainer
					 if(country!="0")
                    {
                        document.getElementById('txtdist').value="";
                        document.getElementById('txtstate').value="";
                        document.getElementById('txttaluka').value="0";
                         var res= RepMast.getfromc(country);
                         var ds=res.value;
                        var pkgitem = document.getElementById("txtcity");
                        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
                        {
                        pkgitem.options.length = 1; 
                        pkgitem.options[0]=new Option("--Select City--","0");
                        for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
                        {
                            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
                            pkgitem.options.length;
                        }
                       
                         if(cityvar == undefined || cityvar=="")
                         {
                           document.getElementById('txtcity').value="0";
                         }
                         else
                         {
                           document.getElementById('txtcity').value=cityvar;
                           document.getElementById('hdncity').value=document.getElementById('txtcity').value;
           citycd=document.getElementById('hdncity').value;
                           cityvar="";
                         } 
                     
                    }
                    else
                    {
                        if(document.getElementById('txtcity').disabled==false)
                        {
                          alert("There is No Matching value Found");
                        }
                        pkgitem.options.length = 1; 
                        pkgitem.options[0]=new Option("--Select City--","0");
                    }

                    }
                    else
                    {
                        document.getElementById("txtcity").options.length = 1;
                        document.getElementById('txtdist').value="";
                        document.getElementById('txtstate').value="";
                        document.getElementById('txttaluka').value="0";
                        statecode="";
                        distcode="";
                    }
					//----------------------
					var city1=document.getElementById('txtcity').value;
					//adddiststate(cityvar); //cityvar
					// for binding state
					  if(city1!="0")		
	                        {
	                        //RepMast.addcitydist(city1,FillDropDownList_CallBackMaindoc);
	                         var compcode=document.getElementById('hiddencompcode').value;
                               var response=RepMast.addcitydist(city1,compcode);
                               //var response=RepMast.addcitydist(city1);
                                     var ds = response.value;
	                                var cou="INDIA";	
	                                var taluka=document.getElementById('txttaluka');
                                	
                                   if(document.getElementById('txtcity').value!="0" && document.getElementById('txtcity').value!="")
                                   {
	                                if(ds!= null && typeof(ds) == "object" && ds.Tables!= null) 
                                    {	
                                                
				                                document.getElementById("txttaluka").options[0]=new Option("------Select Taluka------","0");
                                				
				                                document.getElementById("txttaluka").options.length=0;		
				                                document.getElementById("txttaluka").options.length=ds.Tables[7].Rows.length;
                                				
			                                    if(ds.Tables[0].Rows.length>0)
				                                {
					                                document.getElementById('txtstate').value=ds.Tables[0].Rows[0].state_name;
					                                statecode=ds.Tables[0].Rows[0].state_code;
				                                }
				                                else
				                                {
				                                    document.getElementById('txtstate').value="";
				                                }
                                					
				                                if(ds.Tables[1].Rows.length>0)
				                                {
				                                    document.getElementById('txtdist').value=ds.Tables[1].Rows[0].dist_name;
				                                    distcode=ds.Tables[1].Rows[0].dist_code;
				                                }
				                                else
			                                    {
			                                        if(document.getElementById('txtcity').disabled==false)
                                                    {
			                                            //alert("There is no matching value for district");//change due to no region in city master
			                                        }
			                                        document.getElementById('txtdist').value="";
			                                    }
                                					
				                                if(ds.Tables[7].Rows.length>0)
		                                        {	
    				                                for(var i=0;i<ds.Tables[7].Rows.length;++i) 
	    			                                {
    					                                document.getElementById("txttaluka").options[i]=new Option(ds.Tables[7].Rows[i].talu_name,ds.Tables[7].Rows[i].talu_code);
	    			                                }
	    			                                if(dsget!=null)	
	    			                                  document.getElementById('txttaluka').value=dsget.Tables[0].Rows[z].Taluka ;
	    			                                else
	    			                                  document.getElementById('txttaluka').value=ds.Tables[7].Rows[0].talu_code;//dsget.Tables[0].Rows[0].Taluka 
	    		                                 }
        	                                    else
                                                {
                                                  taluka.options.length=0;
                                                }
                                				
		                                }
	                                }	
                            }
                            else
                            {
                                document.getElementById('txtdist').value="";
                                document.getElementById('txtstate').value="";
                                document.getElementById('txttaluka').value="0";
                            }
					// end---------
	          //  document.getElementById('txtcity').value=dsget.Tables[0].Rows[z].City_Code;
	         /* if(dsget.Tables[0].Rows[z].State_Code== null)
	               document.getElementById('txtstate').value="";
	           else
	               document.getElementById('txtstate').value=dsget.Tables[0].Rows[z].State_Code;
	           if(dsget.Tables[0].Rows[z].Dist_Code== null)
	                document.getElementById('txtdist').value="";
	           else
	               document.getElementById('txtdist').value=dsget.Tables[0].Rows[z].Dist_Code;*/
	            document.getElementById('txttaluka').value=dsget.Tables[0].Rows[z].Taluka;
	            document.getElementById('txtrepstatus').value=dsget.Tables[0].Rows[z].Rep_Status;
				updateStatus();
	
			document.getElementById('btnfirst').disabled=false;				
			document.getElementById('btnnext').disabled=false;					
			document.getElementById('btnprevious').disabled=false;			
			document.getElementById('btnlast').disabled=false;
			
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
		if(z==x-1)
		{
		document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
		}
		setButtonImages();
		return false;
}

function doclast()
		{
			var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
		
			RepMast.fnpl(compcode,userid,lastcall)
			return false;
		}


function lastcall(response)
	{
			// dsget= response.value;
			var x=dsget.Tables[0].Rows.length;
			z=x-1;
			x=x-1;
					document.getElementById('txtrepcode').value=dsget.Tables[0].Rows[x].Rep_code;
					document.getElementById('txtrepname').value=dsget.Tables[0].Rows[x].Rep_Name;
				    
				    if(dsget.Tables[0].Rows[x].Country_Code ==null)
				       document.getElementById('txtcountry').value="0";
				    else 
				       document.getElementById('txtcountry').value=dsget.Tables[0].Rows[x].Country_Code;
				
				    if(dsget.Tables[0].Rows[x].City_Code == null)
				       cityvar="";
			         else
				       cityvar=dsget.Tables[0].Rows[x].City_Code;
				   // addcount(document.getElementById('txtcountry').value);
				  // adddiststate(cityvar); //cityvar
				    	var country=document.getElementById('txtcountry').value;
					// fro binding city in retainer
					 if(country!="0")
                    {
                        document.getElementById('txtdist').value="";
                        document.getElementById('txtstate').value="";
                        document.getElementById('txttaluka').value="0";
                         var res= RepMast.getfromc(country);
                         var ds=res.value;
                        var pkgitem = document.getElementById("txtcity");
                        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
                        {
                        pkgitem.options.length = 1; 
                        pkgitem.options[0]=new Option("--Select City--","0");
                        for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
                        {
                            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
                            pkgitem.options.length;
                        }
                       
                         if(cityvar == undefined || cityvar=="")
                         {
                           document.getElementById('txtcity').value="0";
                         }
                         else
                         {
                           document.getElementById('txtcity').value=cityvar;
                           document.getElementById('hdncity').value=document.getElementById('txtcity').value;
           citycd=document.getElementById('hdncity').value;
                           cityvar="";
                         } 
                     
                    }
                    else
                    {
                        if(document.getElementById('txtcity').disabled==false)
                        {
                          alert("There is No Matching value Found");
                        }
                        pkgitem.options.length = 1; 
                        pkgitem.options[0]=new Option("--Select City--","0");
                    }

                    }
                    else
                    {
                        document.getElementById("txtcity").options.length = 1;
                        document.getElementById('txtdist').value="";
                        document.getElementById('txtstate').value="";
                        document.getElementById('txttaluka').value="0";
                        statecode="";
                        distcode="";
                    }
					//----------------------
					var city1=document.getElementById('txtcity').value;
					//adddiststate(cityvar); //cityvar
					// for binding state
					  if(city1!="0")		
	                        {
	                        //RepMast.addcitydist(city1,FillDropDownList_CallBackMaindoc);
	                         var compcode=document.getElementById('hiddencompcode').value;
                               var response=RepMast.addcitydist(city1,compcode);
                              // var response=RepMast.addcitydist(city1);
                                     var ds = response.value;
	                                var cou="INDIA";	
	                                var taluka=document.getElementById('txttaluka');
                                	
                                   if(document.getElementById('txtcity').value!="0" && document.getElementById('txtcity').value!="")
                                   {
	                                if(ds!= null && typeof(ds) == "object" && ds.Tables!= null) 
                                    {	
                                                
				                                document.getElementById("txttaluka").options[0]=new Option("------Select Taluka------","0");
                                				
				                                document.getElementById("txttaluka").options.length=0;		
				                                document.getElementById("txttaluka").options.length=ds.Tables[7].Rows.length;
                                				
			                                    if(ds.Tables[0].Rows.length>0)
				                                {
					                                document.getElementById('txtstate').value=ds.Tables[0].Rows[0].state_name;
					                                statecode=ds.Tables[0].Rows[0].state_code;
				                                }
				                                else
				                                {
				                                    document.getElementById('txtstate').value="";
				                                }
                                					
				                                if(ds.Tables[1].Rows.length>0)
				                                {
				                                    document.getElementById('txtdist').value=ds.Tables[1].Rows[0].dist_name;
				                                    distcode=ds.Tables[1].Rows[0].dist_code;
				                                }
				                                else
			                                    {
			                                        if(document.getElementById('txtcity').disabled==false)
                                                    {
			                                            //alert("There is no matching value for district");//change due to no region in city master
			                                        }
			                                        document.getElementById('txtdist').value="";
			                                    }
                                					
				                                if(ds.Tables[7].Rows.length>0)
		                                        {	
    				                                for(var i=0;i<ds.Tables[7].Rows.length;++i) 
	    			                                {
    					                                document.getElementById("txttaluka").options[i]=new Option(ds.Tables[7].Rows[i].talu_name,ds.Tables[7].Rows[i].talu_code);
	    			                                }
	    			                                if(dsget!=null)	
	    			                                  document.getElementById('txttaluka').value=dsget.Tables[0].Rows[z].Taluka ;
	    			                                else
	    			                                  document.getElementById('txttaluka').value=ds.Tables[7].Rows[0].talu_code;//dsget.Tables[0].Rows[0].Taluka 
	    		                                 }
        	                                    else
                                                {
                                                  taluka.options.length=0;
                                                }
                                				
		                                }
	                                }	
                            }
                            else
                            {
                                document.getElementById('txtdist').value="";
                                document.getElementById('txtstate').value="";
                                document.getElementById('txttaluka').value="0";
                            }
					// end---------
		         //   document.getElementById('txtcity').value=dsget.Tables[0].Rows[x].City_Code;
		           /*  if(dsget.Tables[0].Rows[x].State_Code== null)
	                    document.getElementById('txtstate').value="";
	                 else
		                document.getElementById('txtstate').value=dsget.Tables[0].Rows[x].State_Code;
		             
		             if(dsget.Tables[0].Rows[x].Dist_Code== null)
	                    document.getElementById('txtdist').value="";
	                 else   
		                document.getElementById('txtdist').value=dsget.Tables[0].Rows[x].Dist_Code;*/
		            document.getElementById('txttaluka').value=dsget.Tables[0].Rows[x].Taluka;
		            document.getElementById('txtrepstatus').value=dsget.Tables[0].Rows[x].Rep_Status;
					updateStatus();
		
			document.getElementById('btnprevious').disabled=false;	
			document.getElementById('btnlast').disabled=true;	
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnnext').disabled=true;
			setButtonImages();
	}
	
function deletedoc()
	{
		var compcode=document.getElementById('hiddencompcode').value;
		var userid=document.getElementById('hiddenuserid').value;
		var repcode=document.getElementById('txtrepcode').value;
		boolReturn = confirm("Are you sure you wish to delete this?");
	if(boolReturn==1)
	{
	    RepMast.del(compcode,userid,repcode);
		RepMast.exe(compcode,userid,code,name,delcall);
	
	}     
	else
	{
	return false;
	}	
	return false;
	}
	
	function delcall(res)
	{
	//var ds= res.value;
				 dsget= res.value;
	
	len=dsget.Tables[0].Rows.length;
	
	if(dsget.Tables[0].Rows.length==0)
		{
		alert("No More Data is here to be deleted");
	document.getElementById('txtrepcode').value="";
			document.getElementById('txtrepname').value="";
		canceldoc('RepMast');
		return false;
	
	}
	else if(z==-1 ||z>=len)
	{
		document.getElementById('txtrepcode').value=dsget.Tables[0].Rows[0].Rep_code;
		document.getElementById('txtrepname').value=dsget.Tables[0].Rows[0].Rep_Name;
		
	    if(dsget.Tables[0].Rows[0].Country_Code ==null)
		    document.getElementById('txtcountry').value="0";
		else 
		    document.getElementById('txtcountry').value=dsget.Tables[0].Rows[0].Country_Code;
				
		if(dsget.Tables[0].Rows[0].City_Code == null)
		   cityvar="";
	     else
		   cityvar=dsget.Tables[0].Rows[0].City_Code;
		    addcount(document.getElementById('txtcountry').value);
		    adddiststate(cityvar); //cityvar
		    
		//document.getElementById('txtcity').value=dsget.Tables[0].Rows[0].City_Code;
		 if(dsget.Tables[0].Rows[0].State_Code== null)
               document.getElementById('txtstate').value="";
         else
               document.getElementById('txtstate').value=dsget.Tables[0].Rows[0].State_Code;
        
        if(dsget.Tables[0].Rows[0].Dist_Code== null)
                document.getElementById('txtdist').value="";
        else
               document.getElementById('txtdist').value=dsget.Tables[0].Rows[0].Dist_Code;

		document.getElementById('txttaluka').value=dsget.Tables[0].Rows[0].Taluka;
		document.getElementById('txtrepstatus').value=dsget.Tables[0].Rows[0].Rep_Status;
	}
	
	else
	{
		document.getElementById('txtrepcode').value=dsget.Tables[0].Rows[z].Rep_code;
		document.getElementById('txtrepname').value=dsget.Tables[0].Rows[z].Rep_Name;
		 if(dsget.Tables[0].Rows[z].Country_Code ==null)
		    document.getElementById('txtcountry').value="0";
		else 
		   document.getElementById('txtcountry').value=dsget.Tables[0].Rows[z].Country_Code;
		
		if(dsget.Tables[0].Rows[z].City_Code == null)
		   cityvar="";
	     else
		   cityvar=dsget.Tables[0].Rows[z].City_Code;
		    addcount(document.getElementById('txtcountry').value);
		    adddiststate(cityvar); //cityvar
		
		if(dsget.Tables[0].Rows[z].State_Code== null)
               document.getElementById('txtstate').value="";
         else
		document.getElementById('txtstate').value=dsget.Tables[0].Rows[z].State_Code;
		
		 if(dsget.Tables[0].Rows[z].Dist_Code== null)
                document.getElementById('txtdist').value="";
        else
		  document.getElementById('txtdist').value=dsget.Tables[0].Rows[z].Dist_Code;
		document.getElementById('txttaluka').value=dsget.Tables[0].Rows[z].Taluka;
		document.getElementById('txtrepstatus').value=dsget.Tables[0].Rows[z].Rep_Status;
	}
	//alert ("Data Deleted");	
	if(browser!="Microsoft Internet Explorer")
        {
            alert(xmlObj.childNodes[1].childNodes[5].childNodes[0].nodeValue);
        }
        else
        {
            alert(xmlObj.childNodes(0).childNodes(2).text);
        }
				
	setButtonImages();
	return false;
	}
	
	
function docexit()
{
if(confirm("Do You Want To Skip This Page"))
	{
	//window.location.href='EnterPage.aspx';
	window.close();
	return false;
	}
	
	return false;
}







////////////////////////////////////////


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

    //return false;
    }
return false;
}


// Auto generated
// This Function is for check that whether this is case for new or modify

function changeoccured()
{

if(hiddentext=="new" )
			{
	
           
		document.getElementById('txtrepname').value=document.getElementById('txtrepname').value.toUpperCase();
		document.getElementById('txtrepname').value=trim(document.getElementById('txtrepname').value);
		 lstr=document.getElementById('txtrepname').value;
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
		    if(document.getElementById('txtrepname').value!="")
                {
                 document.getElementById('txtrepname').value=document.getElementById('txtrepname').value.toUpperCase();
	            // str=document.getElementById('txtrepname').value;
	            str=mstr;
		         RepMast.chkrpcode(str,fillcall);
		        return false;
                }
		     return false;
           
           }
            else
            {
            document.getElementById('txtrepname').value=document.getElementById('txtrepname').value.toUpperCase();
            }
return false;
}


//auto generated
//this is used for increment in code

/*function uppercase3()
		{
		
		document.getElementById('txtrepname').value=document.getElementById('txtrepname').value.toUpperCase();
		document.getElementById('txtrepname').value=trim(document.getElementById('txtrepname').value);
		 lstr=document.getElementById('txtrepname').value;
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
		    if(document.getElementById('txtrepname').value!="")
                {
                 document.getElementById('txtrepname').value=document.getElementById('txtrepname').value.toUpperCase();
	            // str=document.getElementById('txtrepname').value;
	            str=mstr;
		         RepMast.chkrpcode(str,fillcall);
		        return false;
                }
		     return false;
		
}*/

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Representative Name  has already assigned !! ");
		    document.getElementById('txtrepname').value="";
		    document.getElementById('txtrepname').focus();
    		
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
		                         newstr=ds.Tables[1].Rows[0].Rep_code;
		                        }
		                    if(newstr !=null )
		                        {
		                      //  var code=newstr.substr(2,4);
		                      var code=newstr;
		                        code++;
		                        document.getElementById('txtrepcode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtrepcode').value=str.substr(0,2)+ "0";
		                          }
		     }
	return false;
		}
		
function userdefine()
    {
        if(hiddentext=="new")
        {
        
        document.getElementById('txtrepcode').disabled=false;
        document.getElementById('txtrepcode').value=trim(document.getElementById('txtrepcode').value);
        document.getElementById('txtrepname').value=document.getElementById('txtrepname').value.toUpperCase();
        auto=document.getElementById('hiddenauto').value;
         return false;
        }

return false;
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

//-----------------  ad by rinki---------------------------//
//city bind on select country..

function addcount(cou)
{
    if(typeof(cou)=="object")
    {
    var country=cou.value;
    }
    else
    {
    var country=cou;
    }

    if(country!="0")
    {
        document.getElementById('txtdist').value="";
        document.getElementById('txtstate').value="";
        document.getElementById('txttaluka').value="0";
         var res= RepMast.getfromc(country);
         var ds=res.value;
            var pkgitem = document.getElementById("txtcity");
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
                pkgitem.options.length = 1; 
                pkgitem.options[0]=new Option("--Select City--","0");
                for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
                    pkgitem.options.length;
                }
               
                 if(cityvar == undefined || cityvar=="")
                 {
                   document.getElementById('txtcity').value="0";
                 }
                 else
                 {
                   document.getElementById('txtcity').value=cityvar;
                   document.getElementById('hdncity').value=document.getElementById('txtcity').value;
           citycd=document.getElementById('hdncity').value;
                   cityvar="";
                 } 
             
            }
            else
            {
                if(document.getElementById('txtcity').disabled==false)
                {
                  alert("There is No Matching value Found");
                }
                pkgitem.options.length = 1; 
                pkgitem.options[0]=new Option("--Select City--","0");
            }

            }
            else
            {
                document.getElementById("txtcity").options.length = 1;
                document.getElementById('txtdist').value="";
                document.getElementById('txtstate').value="";
                document.getElementById('txttaluka').value="0";
                statecode="";
                distcode="";
            }
return false;
}


function callcount(res)
{
    var ds=res.value;
    var pkgitem = document.getElementById("txtcity");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        pkgitem.options.length = 1; 
        pkgitem.options[0]=new Option("--Select City--","0");
        for (var i = 0  ; i < res.value.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(res.value.Tables[0].Rows[i].City_Name,res.value.Tables[0].Rows[i].City_Code);
            pkgitem.options.length;
        }
       
         if(cityvar == undefined || cityvar=="")
         {
           document.getElementById('txtcity').value="0";
         }
         else
         {
           document.getElementById('txtcity').value=cityvar;
           document.getElementById('hdncity').value=document.getElementById('txtcity').value;
           citycd=document.getElementById('hdncity').value;
           cityvar="";
         } 
     
    }
    else
    {
        if(document.getElementById('txtcity').disabled==false)
        {
          alert("There is No Matching value Found");
        }
        pkgitem.options.length = 1; 
        pkgitem.options[0]=new Option("--Select City--","0");
    }
    return false;
}


//state and district and taluka  on selection of city name...
  function adddiststate(citycd)
  {
        if(typeof(citycd)=="object" )
        {
          var city1=citycd.value;
        }
        else
        {
          var city1=citycd;
        }
       
        if(city1!="0")		
	    {
	    //RepMast.addcitydist(city1,FillDropDownList_CallBackMaindoc);
	    var compcode=document.getElementById('hiddencompcode').value;
           var response=RepMast.addcitydist(city1,compcode);
                 var ds = response.value;
	            var cou="INDIA";	
	            var taluka=document.getElementById('txttaluka');
            	
               if(document.getElementById('txtcity').value!="0" && document.getElementById('txtcity').value!="")
               {
	            if(ds!= null && typeof(ds) == "object" && ds.Tables!= null) 
                {	
                            
				            document.getElementById("txttaluka").options[0]=new Option("------Select Taluka------","0");
            				
				            document.getElementById("txttaluka").options.length=0;		
				            document.getElementById("txttaluka").options.length=ds.Tables[7].Rows.length;
            				
			                if(ds.Tables[0].Rows.length>0)
				            {
					            document.getElementById('txtstate').value=ds.Tables[0].Rows[0].state_name;
					            statecode=ds.Tables[0].Rows[0].state_code;
				            }
				            else
				            {
				                document.getElementById('txtstate').value="";
				            }
            					
				            if(ds.Tables[1].Rows.length>0)
				            {
				                document.getElementById('txtdist').value=ds.Tables[1].Rows[0].dist_name;
				                distcode=ds.Tables[1].Rows[0].dist_code;
				            }
				            else
			                {
			                    if(document.getElementById('txtcity').disabled==false)
                                {
			                        //alert("There is no matching value for district");//change due to no region in city master
			                    }
			                    document.getElementById('txtdist').value="";
			                }
            					
				            if(ds.Tables[7].Rows.length>0)
		                    {	
    				            for(var i=0;i<ds.Tables[7].Rows.length;++i) 
	    			            {
    					            document.getElementById("txttaluka").options[i]=new Option(ds.Tables[7].Rows[i].talu_name,ds.Tables[7].Rows[i].talu_code);
	    			            }
//	    			            if(dsget!=null)	
//	    			              document.getElementById('txttaluka').value=dsget.Tables[0].Rows[z].Taluka ;
//	    			            else
//	    			              document.getElementById('txttaluka').value=ds.Tables[8].Rows[0].talu_code;//dsget.Tables[0].Rows[0].Taluka 
	    		             }
        	                else
                            {
                              taluka.options.length=0;
                            }
            				
		            }
	            }	
        }
        else
        {
            document.getElementById('txtdist').value="";
            document.getElementById('txtstate').value="";
            document.getElementById('txttaluka').value="0";
        }
	    return false;

    }

			
function FillDropDownList_CallBackMaindoc(response) 
{
			
	var ds = response.value;
	var cou="INDIA";	
	var taluka=document.getElementById('txttaluka');
	
   if(document.getElementById('txtcity').value!="0" && document.getElementById('txtcity').value!="")
   {
	if(ds!= null && typeof(ds) == "object" && ds.Tables!= null) 
    {	
                
				document.getElementById("txttaluka").options[0]=new Option("------Select Taluka------","0");
				
				document.getElementById("txttaluka").options.length=0;		
				document.getElementById("txttaluka").options.length=ds.Tables[8].Rows.length;
				
			    if(ds.Tables[0].Rows.length>0)
				{
					document.getElementById('txtstate').value=ds.Tables[0].Rows[0].state_name;
					statecode=ds.Tables[0].Rows[0].state_code;
				}
				else
				{
				    document.getElementById('txtstate').value="";
				}
					
				if(ds.Tables[1].Rows.length>0)
				{
				    document.getElementById('txtdist').value=ds.Tables[1].Rows[0].dist_name;
				    distcode=ds.Tables[1].Rows[0].dist_code;
				}
				else
			    {
			        if(document.getElementById('txtcity').disabled==false)
                    {
			            //alert("There is no matching value for district");//change due to no region in city master
			        }
			        document.getElementById('txtdist').value="";
			    }
					
				if(ds.Tables[8].Rows.length>0)
		        {	
    				for(var i=0;i<ds.Tables[8].Rows.length;++i) 
	    			{
    					document.getElementById("txttaluka").options[i]=new Option(ds.Tables[8].Rows[i].talu_name,ds.Tables[8].Rows[i].talu_code);
	    			}
	    			if(dsget!=null)	
	    			  document.getElementById('txttaluka').value=dsget.Tables[0].Rows[z].Taluka ;
	    			else
	    			  document.getElementById('txttaluka').value=ds.Tables[8].Rows[0].talu_code;//dsget.Tables[0].Rows[0].Taluka 
	    		 }
        	    else
                {
                  taluka.options.length=0;
                }
				
		}
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

function clearrepmast()		
{
canceldoc('RepMast');
document.getElementById('btnNew').focus();

loadXML('xml/errorMessage.xml');
givebuttonpermission('RepMast');
}	
			
//			
//function autoornot()
// {
//  if(document.getElementById('hiddenauto').value==1)
//    {
//    changeoccured();
//   
//    }
//else
//    {
//    userdefine();

//    
//    }
//}

//function changeoccured()
//{
//if(hiddentext=="new" )

//  
//	{
//	
//           
//          document.getElementById('txtrepname').value=trim(document.getElementById('txtrepname').value);
//		lstr=document.getElementById('txtrepname').value;
//		  cstr=lstr.substring(0,1);
//            var mstr="";
//            			   if(lstr.indexOf(" ")==1)
//			            {
//			            var leng=lstr.length;
//			           mstr= cstr + lstr.substring(2,leng);
//			            }
//			            else
//			            {
//			             var leng=lstr.length;
//			            mstr=cstr + lstr.substring(1,leng);
//			            }
//		
//		    if(document.getElementById('txtrepname').value!="")
//                {

//		document.getElementById('txtrepname').value=document.getElementById('txtrepname').value.toUpperCase();
//	    document.getElementById('txtalias').value=document.getElementById('txtrepname').value;
//	    var subcatname=document.getElementById('drpadvcatcode').value;

//		str=mstr;
//		RepMast.catdauto(str,subcatname,fillcall);
//	
//                }
//     
//        }
//      else
//            {
//            document.getElementById('txtrepname').value=document.getElementById('txtrepname').value.toUpperCase();
//            }
//              return false;

//}



//function fillcall(res)
//		{
//		var ds=res.value;
//		
//		var newstr;
//		
//		    if(ds.Tables[0].Rows.length !=0)
//		    {
//		    alert("This Category3 Name has already been assigned !! ");
//		    
//		         document.getElementById('txtrepname').value="";
//				document.getElementById('txtrepname').value="";	
//				document.getElementById('txtalias').value="";
//			document.getElementById('txtrepname').focus();
//		  
//    		
//		    }
//		
//		        else
//		        {

//		                    if(ds.Tables[1].Rows.length==0)
//		                        {
//		                        newstr=null;
//		                        }
//		                    else
//		                        {
//		                         newstr=ds.Tables[1].Rows[0].catcode;
//		                        }
//		                        if(newstr==0)
//		                        {
//		                            str=str.toUpperCase();
//		                            document.getElementById('txtrepname').value=str.substr(0,2)+ "1";
//		                        }
//		                        else if(newstr>=1)
//		                        {
//		                           var Autoincrement=parseInt(ds.Tables[1].Rows[0].catcode)+1;
//		                            str=str.toUpperCase();
//		                            document.getElementById('txtrepname').value=str.substr(0,2)+ Autoincrement;
//		                        }
//		                        
//		                    else if(newstr !=null )
//		                        {
//		                        document.getElementById('txtrepname').value=trim(document.getElementById('txtrepname').value);
//		                        var code=newstr.substr(2,4);
//		                       var code=newstr;
//		                       str=str.toUpperCase();
//		                        code++;
//		                        document.getElementById('txtrepname').value=str.substr(0,2)+ code;
//		                        return false;
//		                     
//		                         }
//		                         
//		                    else
//		                         {
//		                           str=str.toUpperCase();
//		                          document.getElementById('txtrepname').value=str.substr(0,2)+ "0";
//		                         
//		                          }
//		                      
//		     }

//		}
//		
		
		function insertsubcatname(event) {

    var key =event.keyCode?event.keyCode:event.which;

    if (key == 13 || event.type == "click") {

        if (document.activeElement.id == "lstsubcatname") {

            document.getElementById("divsubcatname").style.display = "none";

            var page = document.getElementById('lstsubcatname').value;
            AZS=page;

            for (var k = 0; k <= document.getElementById("lstsubcatname").length - 1; k++) {

//                if (browser != "Microsoft Internet Explorer") {

//                    var abc = document.getElementById('lstsubcatname').options[k].textContent;

//                }

//                else {

//                    var abc = document.getElementById('lstsubcatname').options[k].innerText;

//                }

                if (document.getElementById('lstsubcatname').options[k].value == page) 
                {
                
 var abc = document.getElementById('lstsubcatname').options[k].innerText;
                    document.getElementById('hdncatname').value = abc;
                    var abc1 = abc.split('(');
                    var abc2 = trim(abc1[0]);
                    document.getElementById('txtrepname').value = abc2;


                    document.getElementById('hdnsubcat').value = page;

                    document.getElementById('txtrepname').focus()
  
                    return false;

                }

            }


        }

    }

    else if (event.keyCode == 27) {

        document.getElementById("divsubcatname").style.display = "none";

        document.getElementById('txtrepname').focus();

        return false;







    }



}




function pressf2(event) {

    var keycode = event.keyCode ? event.keyCode : event.which;

    if (keycode != 13) {

        if (document.activeElement.id == "txtrepname") {

            document.getElementById('hdnsubcat').value = "";




        }

    }




    if (keycode == 113) {


       // if (flag_new == "1" || flag_new=="0") 
        {


            if (document.activeElement.id == 'txtrepname') {

                var aTag = eval(document.getElementById('txtrepname'))

                var btag;

                var leftpos = 0;

                var toppos = 0;

                do {

                    aTag = eval(aTag.offsetParent);

                    leftpos += aTag.offsetLeft;

                    toppos += aTag.offsetTop;

                    btag = eval(aTag)

                }

                while (aTag.tagName != "BODY" && aTag.tagName != "HTML");

                var tot = document.getElementById('divsubcatname').scrollLeft;

                var scrolltop = document.getElementById('divsubcatname').scrollTop;

                document.getElementById('divsubcatname').style.display = "block";

                document.getElementById('divsubcatname').style.left = document.getElementById('txtrepname').offsetLeft + leftpos - tot + "px";

                document.getElementById('divsubcatname').style.top = document.getElementById('txtrepname').offsetTop + toppos - scrolltop + "px";

                document.getElementById('lstsubcatname').focus();

                var compcode = document.getElementById('hiddencompcode').value;

             
              //var exename=  document.getElementById('drpadvcatcode').options[document.getElementById('drpadvcatcode').selectedIndex].text
              
            //  var exename = document.getElementById('drpadvcatcode').value;
              
              var ASD=document.getElementById('txtrepname').value;
              

                RepMast.fill_subcat(compcode,ASD,bind_executive_callback);

                return false;

            }
        }



    }




    if (keycode == 8) {

        if (document.activeElement.id == "txtrepname") {

            document.getElementById('txtrepname').value = "";

            return true;

        }




    }

}



function bind_executive_callback(res) {

    ds = res.value;

    if (ds == null) {

        pkgitem.style.width = "254px"

        pkgitem.options.length = 0;

    }

    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {




        var pkgitem = document.getElementById("lstsubcatname");

        pkgitem.style.width = "484px"

        pkgitem.options.length = 0;

        pkgitem.options[0] = new Option("-Select Name-", "0");

        pkgitem.options.length = 1;




        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {

           // pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].catname + "(" + ds.Tables[0].Rows[i].subcatname + ds.Tables[0].Rows[i].catcode + ")",ds.Tables[0].Rows[i].catcode);
              pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Rep_Name + "(" +  ds.Tables[0].Rows[i].Rep_code+ ")",ds.Tables[0].Rows[i].Rep_code);;
            pkgitem.options.length;




        }




    }




    return false;

}










