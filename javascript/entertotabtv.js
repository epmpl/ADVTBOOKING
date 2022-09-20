var agnf2="";
var agencycodeglo;
function tabvalue(event)
{
   if(event.keyCode==113)  
    {
      if(document.activeElement.id=="txtclient")
        {
            if(document.getElementById('txtclient').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtclient').value="";
            return false;
            }
            document.getElementById("divclient").style.display="block";
              aTag = eval( document.getElementById("txtclient"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			             document.getElementById('divclient').style.top=document.getElementById("txtclient").offsetTop + toppos + "px";
			             document.getElementById('divclient').style.left=document.getElementById("txtclient").offsetLeft + leftpos+"px";
            tv_booking_transaction.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtclient').value,"N",bindclientname_callback);
        }
        else if(document.activeElement.id=="txtagency")
        {
            if(document.getElementById('txtagency').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtagency').value="";
            return false;
            }
            document.getElementById("div1").style.display="block";
            aTag = eval( document.getElementById("txtagency"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			             document.getElementById('div1').style.top=document.getElementById("txtagency").offsetTop + toppos + "px";
			             document.getElementById('div1').style.left=document.getElementById("txtagency").offsetLeft + leftpos+"px";
           tv_booking_transaction.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txtagency').value,"N",bindagencyname_callback);
        
        }
        else if(document.activeElement.id=="txtdeal")
        {
            if(document.getElementById('txtagency').value=="" && document.getElementById('txtclient').value=="")
            {
                alert("Please select atleast one Client or Agency and Both");
                document.getElementById('txtdeal').value="";
                return false;
            }
            var client_code="";
            var agency_code="";
             if(document.getElementById('txtclient').value!="")
                {
                    var client_name=document.getElementById('txtclient').value.split('(');
                    var client_code=client_name[1].replace(')','');
                }
              if(document.getElementById('txtagency').value!="")
                {
                    var agency_name=document.getElementById('txtagency').value.split('(');
                    agency_code=agency_name[1].replace(')','');
                }
             document.getElementById("divdeal").style.display="block";
            aTag = eval( document.getElementById("txtdeal"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			             document.getElementById('divdeal').style.top=document.getElementById("txtdeal").offsetTop + toppos + "px";
			             document.getElementById('divdeal').style.left=document.getElementById("txtdeal").offsetLeft + leftpos+"px";
           tv_booking_transaction.binddeal(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txtdeal').value,client_code,agency_code,"N",binddeal_callback);
        }
        else if(document.activeElement.id=="txtexecname")
        {
           if(document.getElementById('txtexecname').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtexecname').value="";
            return false;
            }
            document.getElementById("divexec").style.display="block";
              aTag = eval( document.getElementById("txtexecname"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			             document.getElementById('divexec').style.top=document.getElementById("txtexecname").offsetTop + toppos + "px";
			             document.getElementById('divexec').style.left=document.getElementById("txtexecname").offsetLeft + leftpos+"px";
           tv_booking_transaction.bindExec(document.getElementById('hiddencompcode').value,document.getElementById('txtexecname').value,"N",bindexecname_callback);
        }
        else if(document.activeElement.id=="txtbartertype")
        {
           
              aTag = eval( document.getElementById("txtbartertype"))
			var btag;
			var leftpos=0;
			var toppos=0;        
			do
			{
				aTag = eval(aTag.offsetParent);
				leftpos	+= aTag.offsetLeft;
				toppos += aTag.offsetTop;
				btag=eval(aTag)
			} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			
            document.getElementById("divbarter").style.left=document.getElementById("txtbartertype").offsetLeft + leftpos+"px";
            document.getElementById("divbarter").style.top= document.getElementById("txtbartertype").offsetTop + toppos + "px";//"510px";
            document.getElementById("divbarter").style.display="block";
            var res;
            var agencycode="";
            if(document.getElementById('txtagency').value!="")
            {
             agencycode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(')+1,document.getElementById('txtagency').value.length  + document.getElementById('txtagency').value.lastIndexOf('('));
             agencycode = agencycode.replace(")", "");
            } 
             var clientcode = document.getElementById('txtclient').value;
               if (clientcode.indexOf("(".toString()) > 0)
             {
                var myarray1 = clientcode.split('(');
                client = myarray1[1];
                client = client.replace(")", '');
            }
            res=tv_booking_transaction.getBarter(document.getElementById('hiddencompcode').value,document.getElementById('hiddencenter').value,document.getElementById('txtbranch').value,agencycode,client,"N");
            if(res.value!=null && res.value.Tables.length>0)
            {
                var ds=res.value;
            var objciragency=document.getElementById("lstbarter");
            objciragency.options.length = 0; 
            objciragency.options[0]=new Option("-Select-","0");            
            objciragency.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                var name=ds.Tables[0].Rows[i].BARTE_DESC;
                var value=ds.Tables[0].Rows[i].BARTER_CODE+"û"+ds.Tables[0].Rows[i].BARTER_AMOUNT+"û"+ds.Tables[0].Rows[i].STOPBOOKING;
                objciragency.options[objciragency.options.length] = new Option(name,value);            
                objciragency.options.length;       
            }
            objciragency.focus();
            }
        }
        else if(document.activeElement.id=="txtproduct")
        {
            if(document.getElementById('txtproduct').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtproduct').value="";
            return false;
            }
            document.getElementById("divproduct").style.display="block";
              aTag = eval( document.getElementById("txtproduct"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
                document.getElementById('divproduct').style.top=document.getElementById("txtproduct").offsetTop + toppos + "px";
                document.getElementById('divproduct').style.left=document.getElementById("txtproduct").offsetLeft + leftpos+"px";
            tv_booking_transaction.bindProduct(document.getElementById('hiddencompcode').value,document.getElementById('txtproduct').value,"N",bindproductname_callback);
        }
        else if(document.activeElement.id=="drpretainer")
        {
        if(retexeboth!="both")
        {
                if(document.getElementById('txtexecname').value!="")
                {
                      var b="Retainer";
                    if(browser!="Microsoft Internet Explorer")
                    {
                       b=document.getElementById('lblretainer').textContent.replace("*[F2]","");
                    }
                    else
                    {        
                      b=document.getElementById('lblretainer').innerText.replace("*[F2]","");
                    }
                   if(confirm('Are you sure you want to Take '+b))
                    {
                    if(document.getElementById('drpretainer').value.length <=2)
                        {
                            alert("Please Enter Minimum 3 Character For Searching.");
                            document.getElementById('drpretainer').value="";
                            return false;
                        }
                       document.getElementById('txtexecname').value="";
                       document.getElementById('txtexeczone').value="";
                       document.getElementById("divretainer").style.display="block";
                          aTag = eval( document.getElementById("drpretainer"))
			                var btag;
			                var leftpos=0;
			                var toppos=0;        
			                do
			                {
				                aTag = eval(aTag.offsetParent);
				                leftpos	+= aTag.offsetLeft;
				                toppos += aTag.offsetTop;
				                btag=eval(aTag)
			                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			                 document.getElementById('divretainer').style.top=document.getElementById("drpretainer").offsetTop + toppos + "px";
			                 document.getElementById('divretainer').style.left=document.getElementById("drpretainer").offsetLeft + leftpos+"px";
                    var agcode="";
                    if(document.getElementById('txtagency').value!="" && document.getElementById('txtagency').value.indexOf("(")>=0 && document.getElementById('txtagency').value.indexOf(")")>=0)
                      agcode=document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(')+1,document.getElementById('txtagency').value.lastIndexOf(')'));
                        tv_booking_transaction.bindRetainer(document.getElementById('hiddencompcode').value,document.getElementById('drpretainer').value,agcode,"N",bindretainer_callback);                       
                    }
                    else{
                     document.getElementById('drpretainer').value="";
                     document.getElementById("divretainer").style.display="none";
                 }  
            }
            else
             {
                if(document.getElementById('drpretainer').value.length <=2)
                    {
                        alert("Please Enter Minimum 3 Character For Searching.");
                        document.getElementById('drpretainer').value="";
                        return false;
                    }
                  document.getElementById("divretainer").style.display="block";
                     aTag = eval( document.getElementById("drpretainer"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			             document.getElementById('divretainer').style.top=document.getElementById("drpretainer").offsetTop + toppos + "px";
			             document.getElementById('divretainer').style.left=document.getElementById("drpretainer").offsetLeft + leftpos+"px";
                    var agcode="";
                    if(document.getElementById('txtagency').value!="" && document.getElementById('txtagency').value.indexOf("(")>=0 && document.getElementById('txtagency').value.indexOf(")")>=0)
                      agcode=document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(')+1,document.getElementById('txtagency').value.lastIndexOf(')'));
                    tv_booking_transaction.bindRetainer(document.getElementById('hiddencompcode').value,document.getElementById('drpretainer').value,agcode,"N",bindretainer_callback);
             }
           }
            else
             {
                if(document.getElementById('drpretainer').value.length <=2)
                    {
                        alert("Please Enter Minimum 3 Character For Searching.");
                        document.getElementById('drpretainer').value="";
                        return false;
                    }
                  document.getElementById("divretainer").style.display="block";
                     aTag = eval( document.getElementById("drpretainer"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			             document.getElementById('divretainer').style.top=document.getElementById("drpretainer").offsetTop + toppos + "px";
			             document.getElementById('divretainer').style.left=document.getElementById("drpretainer").offsetLeft + leftpos+"px";
                var agcode="";
                    if(document.getElementById('txtagency').value!="" && document.getElementById('txtagency').value.indexOf("(")>=0 && document.getElementById('txtagency').value.indexOf(")")>=0)
                      agcode=document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(')+1,document.getElementById('txtagency').value.lastIndexOf(')'));
                    tv_booking_transaction.bindRetainer(document.getElementById('hiddencompcode').value,document.getElementById('drpretainer').value,agcode,"N",bindretainer_callback);
             }
        }
    }
    else if(event.keyCode==27)
       {
          if(document.getElementById("divclient").style.display=="block")
            {
                document.getElementById("divclient").style.display="none"
                document.getElementById('txtclient').focus();
            } 
          else if(document.getElementById("div1").style.display=="block")
            {
                document.getElementById("div1").style.display="none"
                document.getElementById('txtagency').focus();
            }
          else if(document.getElementById("divdeal").style.display=="block")
            {
                document.getElementById("divdeal").style.display="none"
                document.getElementById('txtdeal').focus();
            }
          else if(document.getElementById("divexec").style.display=="block")
            {
                document.getElementById("divexec").style.display="none"
                document.getElementById('txtexecname').focus();
            } 
          else if(document.getElementById("divbarter").style.display=="block")
            {
                document.getElementById("divbarter").style.display="none"
                document.getElementById('lstbarter').options.length=0;
                document.getElementById('txtbartertype').focus();
            }
          else if(document.getElementById("divretainer").style.display=="block")
            {
                document.getElementById("divretainer").style.display="none"
                document.getElementById('drpretainer').focus();
            }
          else if(document.getElementById("divproduct").style.display=="block")
            {
                document.getElementById("divproduct").style.display="none"
                if(document.getElementById('txtproduct').value=="")
                {
                    document.getElementById('drpbrand').options.length=0;
                    document.getElementById('drpvarient').options.length=0;
                }    
                document.getElementById('txtproduct').focus();
            }
            return false;
       }
    else if(event.keyCode==13 || event.keyCode==9 && event.shiftKey==false)
    {
      if(document.activeElement.id=="lstclient")
        {
            if(document.getElementById('lstclient').value=="0")
            {
                alert("Please select the client");
                return false;
            }
            document.getElementById("divclient").style.display="none";
            var datetime=document.getElementById('txtdatetime').value;
            var page=document.getElementById('lstclient').value;       
            var id="";
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) 
                {
                    httpRequest.overrideMimeType('text/xml'); 
                }            
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
                httpRequest.send('');
                if (httpRequest.readyState == 4) 
                {
                    if (httpRequest.status == 200) 
                    {
                        id=httpRequest.responseText;
                    }
                    else 
                    {
                        alert('There was a problem with the request.');
                    }
                }
            }
            else
            {
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=1", false );
                xml.Send();
                id=xml.responseText;
            }
            var split=id.split("+");
            var namecode=split[0];
            var add=split[1];        
            document.getElementById('txtclient').value=namecode;
            
//            if(document.getElementById('hiddensavemod').value=="0")
//            {
                document.getElementById('txtclientadd').value=add;
                document.getElementById('txtdeal').focus();
            //}
            if(agencycodeglo!="undefined" && agencycodeglo!=undefined)
               {
                    var resbill=tv_booking_transaction.bindbillto_ag(agencycodeglo,document.getElementById('hiddencompcode').value);
                    dsbill=resbill.value;
                  var pkgitem = document.getElementById("drpbillto");
              
                 if(dsbill!= null && typeof(dsbill) == "object" && dsbill.Tables[0].Rows.length > 0) 
                 {
                      pkgitem.options.length = 0; 
                       var client_val=document.getElementById('txtclient').value;
                       var client_name=document.getElementById('txtclient').value;
                        if (document.getElementById('txtclient').value.indexOf("(".toString()) > 0)
                    {
                        client_val =document.getElementById('txtclient').value.substring(document.getElementById('txtclient').value.lastIndexOf("(")+1,document.getElementById('txtclient').value.length-1); //document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
                        client_name=document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
                        alertfun();
                     }   
                        pkgitem.options[0]=new Option(client_name,client_val);
                      for (var i = 0  ; i < dsbill.Tables[0].Rows.length; ++i)
                      {
                      if(dsbill.Tables[0].Rows[i].bill_to=="")
                        pkgitem.options[pkgitem.options.length] = new Option(dsbill.Tables[0].Rows[i].agency_name,dsbill.Tables[1].Rows[0].sub_agency_code);      
                      else
                        pkgitem.options[pkgitem.options.length] = new Option(dsbill.Tables[0].Rows[i].agency_name,dsbill.Tables[0].Rows[i].bill_to);        
                        pkgitem.options.length;               
                      }                        
                  }
                  if(dsbill.Tables[1].Rows.length>0)
                  {
                    document.getElementById("drpbillto").value=dsbill.Tables[1].Rows[0].sub_agency_code
                    document.getElementById('hiddenbillto').value=dsbill.Tables[1].Rows[0].sub_agency_code
                  }
                }
          return false;
        }
        else if(document.activeElement.id=="lstagency")
        {
            if(document.getElementById('lstagency').value=="0" )
            {
                alert("Please select the agency sub code");
                return false;
            }
            document.getElementById("div1").style.display="none";
            var datetime=document.getElementById('txtdatetime').value;
            var page=document.getElementById('lstagency').value;
            document.getElementById('hiddenagency').value=page;
            agencycodeglo=page;
            var id="";
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml'); 
                }
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
                httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=0", false );
                httpRequest.send('');
                if (httpRequest.readyState == 4) 
                {
                   if (httpRequest.status == 200) 
                    {
                        id=httpRequest.responseText;
                    }
                    else 
                    {
                        alert('There was a problem with the request.');
                    }
                }
            }
            else
            {
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=0", false );
                xml.Send();
                id=xml.responseText;
            }
            var split=id.split("+");
            var nameagen=split[0];
            var agenadd=split[1];
            document.getElementById('txtagency').value=nameagen;
//            if(document.getElementById('hiddensavemod').value=="0" || document.getElementById('hiddensavemod').value=="01")
//            {
                document.getElementById('txtagencyaddress').value=agenadd;                
                document.getElementById('txtclient').focus();
                var resag=tv_booking_transaction.bindagencusub(page,document.getElementById('hiddencompcode').value);//,call_bindagsub);
                ds=resag.value;
                document.getElementById('txtagencytype').value="";
                document.getElementById('txtagencystatus').value="";
                document.getElementById('txtcreditperiod').value="";
                document.getElementById('txtagencypaymode').value="";
                document.getElementById('txttradedisc').value="";
                 document.getElementById('hiddenagcommflag').value="";
                document.getElementById('txtgrossamt').value="";
                if(document.getElementById('txtaddagencycommrate')!=null)
                document.getElementById('txtaddagencycommrate').value="";
                
                document.getElementById('hiddentradedisc').value="";
                document.getElementById('lstagency').options.length=0;
                var pkgitem = document.getElementById("drpagscode");
              //pkgitem.options.length=0;
               // pkgitem.options[0] = new Option("-Select-","0");
                
                if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
                {
                    pkgitem.options.length = 0; 
                    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                    {
                        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name,ds.Tables[0].Rows[i].Agency_Code);        
                        pkgitem.options.length;       
                    }
                }
    
                getpayandstatus1();
//            }
            return false;
        }
        else if(document.activeElement.id=="lstdeal")
        {
            if(document.getElementById('lstdeal').value=="0" )
            {
                alert("Please select the Deal");
                return false;
            }
            document.getElementById("divdeal").style.display="none";
            document.getElementById('txtdeal').value=document.getElementById('lstdeal').options[document.getElementById('lstdeal').selectedIndex].text +"("+document.getElementById('lstdeal').value+")";
            if(document.getElementById('lstdeal').value!="0")
            {
                if(document.getElementById('txtagency').value=="" || document.getElementById('txtagency').value=="0")
                {
                    var resforagency=tv_booking_transaction.getagencyfromdeal(document.getElementById('hiddencompcode').value,document.getElementById('lstdeal').value);
                    var dsforagency=resforagency.value;
                    if(dsforagency==null)
                    {
                        alert(resforagency.error.description);
                        return false;
                    }
                   if(dsforagency.Tables[0].Rows.length>0)
                    {
                        document.getElementById('txtagencyaddress').value=dsforagency.Tables[0].Rows[0].address;
                        document.getElementById('txtagency').value=dsforagency.Tables[0].Rows[0].agency_name;
                        document.getElementById('hiddenagency').value=dsforagency.Tables[0].Rows[0].Agency_code;
                    }
                    var agency_code="";
                    if(document.getElementById('txtagency').value!="")
                    {
                        var agency_name=document.getElementById('txtagency').value.split('(');
                        agency_code=agency_name[1].replace(')','');
                    }
                    agencycodeglo=agency_code;
                    var resforpay=tv_booking_transaction.bindagencusub(agency_code,document.getElementById('hiddencompcode').value);
                        dsforpay=resforpay.value;
                        document.getElementById('txtagencytype').value="";
                        document.getElementById('txtagencystatus').value="";
                        document.getElementById('txtcreditperiod').value="";
                        document.getElementById('txtagencypaymode').value="";
                        document.getElementById('txttradedisc').value="";
                         document.getElementById('hiddenagcommflag').value="";
                        document.getElementById('txtgrossamt').value="";
                        if(document.getElementById('txtaddagencycommrate')!=null)
                        document.getElementById('txtaddagencycommrate').value="";
                        document.getElementById('hiddentradedisc').value="";
                        document.getElementById('lstagency').options.length=0;
                        var pkgitem = document.getElementById("drpagscode");
                        if(dsforpay!= null && typeof(dsforpay) == "object" && dsforpay.Tables[0].Rows.length > 0) 
                        {
                            pkgitem.options.length = 0; 
                            for (var i = 0  ; i < dsforpay.Tables[0].Rows.length; ++i)
                            {
                                pkgitem.options[pkgitem.options.length] = new Option(dsforpay.Tables[0].Rows[i].agency_name,dsforpay.Tables[0].Rows[i].Agency_Code);        
                                pkgitem.options.length;       
                            }
                        }
                        
                        getpayandstatus(dsforagency.Tables[0].Rows[0].PAYMENTTYPE ,dsforagency.Tables[0].Rows[0].PAYTYPENAME);
                }
                else if(document.getElementById('txtclient').value=="" || document.getElementById('txtclient').value=="0")
                {
                    var resforclient=tv_booking_transaction.getclientfromdeal(document.getElementById('hiddencompcode').value,document.getElementById('lstdeal').value);
                    var dsforclient=resforclient.value;
                    if(dsforclient==null)
                    {
                        alert(resforclient.error.description);
                        return false;
                    }
                   if(dsforclient.Tables[0].Rows.length>0)
                    {
                        document.getElementById('txtclientadd').value=dsforclient.Tables[0].Rows[0].address;
                        document.getElementById('txtclient').value=dsforclient.Tables[0].Rows[0].client_name;
                    }
                    var agency_code="";
                    if(document.getElementById('txtagency').value!="")
                    {
                        var agency_name=document.getElementById('txtagency').value.split('(');
                        agency_code=agency_name[1].replace(')','');
                    }
                    var resforpay=tv_booking_transaction.bindagencusub(agency_code,document.getElementById('hiddencompcode').value);
                        dsforpay=resforpay.value;
                        document.getElementById('txtagencytype').value="";
                        document.getElementById('txtagencystatus').value="";
                        document.getElementById('txtcreditperiod').value="";
                        document.getElementById('txtagencypaymode').value="";
                        document.getElementById('txttradedisc').value="";
                         document.getElementById('hiddenagcommflag').value="";
                        document.getElementById('txtgrossamt').value="";
                        if(document.getElementById('txtaddagencycommrate')!=null)
                        document.getElementById('txtaddagencycommrate').value="";
                        document.getElementById('hiddentradedisc').value="";
                        document.getElementById('lstagency').options.length=0;
                        var pkgitem = document.getElementById("drpagscode");
                        if(dsforpay!= null && typeof(dsforpay) == "object" && dsforpay.Tables[0].Rows.length > 0) 
                        {
                            pkgitem.options.length = 0; 
                            for (var i = 0  ; i < dsforpay.Tables[0].Rows.length; ++i)
                            {
                                pkgitem.options[pkgitem.options.length] = new Option(dsforpay.Tables[0].Rows[i].agency_name,dsforpay.Tables[0].Rows[i].Agency_Code);        
                                pkgitem.options.length;       
                            }
                        }
                    getpayandstatus(dsforclient.Tables[0].Rows[0].PAYMENTTYPE ,dsforclient.Tables[0].Rows[0].PAYTYPENAME);
                }
                else
                {
                    var resforclient=tv_booking_transaction.getclientfromdeal(document.getElementById('hiddencompcode').value,document.getElementById('lstdeal').value);
                    var dsforclient=resforclient.value;
                    if(dsforclient==null)
                    {
                        alert(resforclient.error.description);
                        return false;
                    }
                    var agency_code="";
                    if(document.getElementById('txtagency').value!="")
                    {
                        var agency_name=document.getElementById('txtagency').value.split('(');
                        agency_code=agency_name[1].replace(')','');
                    }
                    var resforpay=tv_booking_transaction.bindagencusub(agency_code,document.getElementById('hiddencompcode').value);
                        dsforpay=resforpay.value;
                        document.getElementById('txtagencytype').value="";
                        document.getElementById('txtagencystatus').value="";
                        document.getElementById('txtcreditperiod').value="";
                        document.getElementById('txtagencypaymode').value="";
                        document.getElementById('txttradedisc').value="";
                         document.getElementById('hiddenagcommflag').value="";
                        document.getElementById('txtgrossamt').value="";
                        if(document.getElementById('txtaddagencycommrate')!=null)
                        document.getElementById('txtaddagencycommrate').value="";
                        document.getElementById('hiddentradedisc').value="";
                        document.getElementById('lstagency').options.length=0;
                        var pkgitem = document.getElementById("drpagscode");
                        if(dsforpay!= null && typeof(dsforpay) == "object" && dsforpay.Tables[0].Rows.length > 0) 
                        {
                            pkgitem.options.length = 0; 
                            for (var i = 0  ; i < dsforpay.Tables[0].Rows.length; ++i)
                            {
                                pkgitem.options[pkgitem.options.length] = new Option(dsforpay.Tables[0].Rows[i].agency_name,dsforpay.Tables[0].Rows[i].Agency_Code);        
                                pkgitem.options.length;       
                            }
                        }
                    getpayandstatus(dsforclient.Tables[0].Rows[0].PAYMENTTYPE ,dsforclient.Tables[0].Rows[0].PAYTYPENAME);
                }
                var allinfo=tv_booking_transaction.bindallinfo(document.getElementById('hiddencompcode').value,document.getElementById('lstdeal').value)
                var dsforallinfo=allinfo.value;
                if(dsforallinfo==null)
                    {
                        alert(allinfo.error.description);
                        return false;
                    }
                if(dsforallinfo.Tables[0].Rows.length>0)
                {
                    document.getElementById('txtexecname').value=dsforallinfo.Tables[0].Rows[0].execname;
                    document.getElementById('drpretainer').value=dsforallinfo.Tables[0].Rows[0].RETAINER1;
                    document.getElementById('txtexeczone').value=dsforallinfo.Tables[0].Rows[0].zone;
                }                    
            }
            document.getElementById("btschedule").focus();
            return false;
        }
        else if(document.activeElement.id=="lstexec")
        {
            if(document.getElementById('lstexec').value=="0")
            {
                      var a="Executive name";
            if(browser!="Microsoft Internet Explorer")
            {
                a=document.getElementById('lbececname').textContent.replace("*[F2]","");
            }
            else
            {        
                a=document.getElementById('lbececname').innerText.replace("*[F2]","");
            }
                alert("Please select the "+a);
                return false;
            }
      
            document.getElementById("divexec").style.display="none";
            var datetime=document.getElementById('txtdatetime').value;
        
            var page=document.getElementById('lstexec').value;
               
            var id="";
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml'); 
                }
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=3", false );
                httpRequest.send('');
                if (httpRequest.readyState == 4) 
                {
                    if (httpRequest.status == 200) 
                    {
                        id=httpRequest.responseText;
                    }
                    else 
                    {
                        alert('There was a problem with the request.');
                    }
                }
            }
            else
            {
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=3", false );
                xml.Send();
                id=xml.responseText;
            }
        
            document.getElementById('txtexecname').value=id;
            tv_booking_transaction.getexeczone(page,document.getElementById('hiddencompcode').value,call_bindexeczone);
            if(document.getElementById('txtagencyoutstand').disabled==false)
            {
                document.getElementById('txtagencyoutstand').focus();
            }
            else
            {
                //changediv();
                  document.getElementById('txtrono').focus();
            }
            return false;
        }
        else  if(document.activeElement.id=="lstbarter")
        {
             if(document.getElementById('lstbarter').value=="0")
            {
                alert("Please Select Barter Type");
                document.getElementById('txtbartertype').value="";
                document.getElementById('hiddenbarteramt').value="";
                document.getElementById('hiddenstopbarterbooking').value="";
                return false;
            }
            document.getElementById("divbarter").style.display="none";
            var bartervalue=document.getElementById('lstbarter').value;
              if(bartervalue!="")
            {
            document.getElementById('hiddenbarteramt').value=bartervalue.split('û')[1];
            document.getElementById('hiddenstopbarterbooking').value=bartervalue.split('û')[2];
            var bame=document.getElementById('lstbarter').options[document.getElementById('lstbarter').selectedIndex].text + '(' + bartervalue.split('û')[0] + ')';
            document.getElementById('txtbartertype').value=bame;
            }
            
        }
        else if(document.activeElement.id=="lstproduct")
        {
            if(document.getElementById('lstproduct').value=="0")
            {
                alert("Please select the product");
                return false;
            }
            document.getElementById("divproduct").style.display="none";
            var datetime=document.getElementById('txtdatetime').value;
               
            var page=document.getElementById('lstproduct').value;
            var id="";
            if(browser!="Microsoft Internet Explorer")
            {
                var  httpRequest =null;;
                httpRequest= new XMLHttpRequest();
                if (httpRequest.overrideMimeType) {
                    httpRequest.overrideMimeType('text/xml'); 
                }
            
                httpRequest.onreadystatechange = function() {alertContents(httpRequest) };

                httpRequest.open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=2", false );
                httpRequest.send('');
                if (httpRequest.readyState == 4) 
                {
                    if (httpRequest.status == 200) 
                    {
                        id=httpRequest.responseText;
                    }
                    else 
                    {
                        alert('There was a problem with the request.');
                    }
                }
            }
            else
            {
                var xml = new ActiveXObject("Microsoft.XMLHTTP");
                xml.Open( "GET","clientName.aspx?page="+page+"&datetime="+datetime+"&value=2", false );
                xml.Send();
                id=xml.responseText;
            }
            document.getElementById('txtproduct').value=id;
            document.getElementById('drpbrand').disabled==false;
            document.getElementById('drpbrand').focus();
            tv_booking_transaction.getbrand(page,document.getElementById('hiddencompcode').value,call_bindproduct);
            return false;
        }
        else if(document.activeElement.id=="lstretainer")
        {
            if(document.getElementById('lstretainer').value=="0" )
            {
                var b="Retainer";
                if(browser!="Microsoft Internet Explorer")
                {
                  b=document.getElementById('lblretainer').textContent.replace("*[F2]","");
                }
                else
                {        
                  b=document.getElementById('lblretainer').innerText.replace("*[F2]","");
                }
                alert("Please select the "+b);            
                return false;
            }        
            document.getElementById('drpretainer').value=document.getElementById('lstretainer').options[document.getElementById('lstretainer').selectedIndex].text +"("+document.getElementById('lstretainer').value+")";
            document.getElementById("divretainer").style.display="none";
            document.getElementById('txtaddagencycommrateamt').value="";
            if(document.getElementById('txtaddagencycommrate')!=null)
            document.getElementById('txtaddagencycommrate').value="";
              if(document.getElementById('drpretainer').value!="" && document.getElementById('drpretainer').value!="0")
                {
                    document.getElementById('txtRetainercomm').value="";
                    var retain_name=document.getElementById('drpretainer').value.split('(');
                    var retain_code=retain_name[1].replace(')','');
                    var ds_ret=tv_booking_transaction.getRetainerComm(retain_code,document.getElementById('hiddencompcode').value);                    
                    if(ds_ret.value==null)
                        return false;                       
                   if(ds_ret.value.Tables[0].Rows.length>0)
                    {
                        document.getElementById('retcommtype').value=ds_ret.value.Tables[0].Rows[0].Discount;
                        document.getElementById('txtRetainercomm').value=ds_ret.value.Tables[0].Rows[0].retainercomm;
                        document.getElementById('retcomm').value=ds_ret.value.Tables[0].Rows[0].retainercomm;
                        if(document.getElementById('retcommtype').value=="Gross" && document.getElementById('txtgrossamt').value!="" && document.getElementById('txtRetainercomm').value!="" && document.getElementById('txtRetainercomm').value!=null)
                        {
                            document.getElementById('txtRetainercommamt').value=(parseFloat(document.getElementById('txtgrossamt').value) * parseFloat(document.getElementById('txtRetainercomm').value) /100).toFixed(2);
                        }
                        else  if(document.getElementById('retcommtype').value=="Net" && document.getElementById('txtbillamt').value!="" && document.getElementById('txtRetainercomm').value!="" && document.getElementById('txtRetainercomm').value!=null)
                        {
                            document.getElementById('txtRetainercommamt').value=(parseFloat(document.getElementById('txtbillamt').value) * parseFloat(document.getElementById('txtRetainercomm').value) /100).toFixed(2);
                        }
                    }                      
                }
            //changediv();  
        }
        else if(document.activeElement.id=="txtagency")
        { 
            var agency1 = document.getElementById('txtagency').value;
               if (agency1.indexOf("(".toString()) > 0)
                 {
                    var myarray1 = agency1.split('(');
                    agency1 = myarray1[1];
                    agency1 = agency1.replace(")", '');
                 }
            
                var ds_ag=tv_booking_transaction.chkvalidateintable("agency_mast","Agency_Code",agency1);
                
                if(ds_ag.value.Tables[0].Rows[0].RESULT==0)
                {                
                    alert("Please Enter Right Agency");
                    document.getElementById('txtagency').focus();
                    return false;
                }     
        }       
        else if(document.activeElement.type=="button" || document.activeElement.type=="submit" || document.activeElement.type=="image")
        {
            event.keyCode=13;
            return event.keyCode;
        }
        else
        {
            var idcursor;
            if(event.shiftKey==false)
            {
                event.keyCode=9;                     
                return event.keyCode;
            }    
        }
      }
      
    
}
function bindclientname_callback(response)
{
         
    ds=response.value;
    var pkgitem = document.getElementById("lstclient");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Client-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    { 
        pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name,ds.Tables[0].Rows[i].Cust_Code);
            pkgitem.options.length;       
        }    
    }
    if(agnf2!="Y")
    {
        document.getElementById('txtclient').value="";
        document.getElementById("lstclient").focus();  //uncomment
    }
    document.getElementById("lstclient").value="0";
     return false;
}
function bindagencyname_callback(response)
{       
    ds=response.value;
    document.getElementById('drpretainer').value="";
    var pkgitem = document.getElementById("lstagency");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Agency-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name +'+'+ds.Tables[0].Rows[i].CITYNAME,ds.Tables[0].Rows[i].code_subcode);        
            pkgitem.options.length;       
        }
    }
    if(agnf2!="Y")
 {
    document.getElementById('txtagency').value="";
    document.getElementById("lstagency").focus();
  }
   document.getElementById("lstagency").value="0";
    return false;
}
function binddeal_callback(response)
{
         
    ds=response.value;
    var pkgitem = document.getElementById("lstdeal");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Deal-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    { 
        pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].deal_name,ds.Tables[0].Rows[i].Deal_No);
            pkgitem.options.length;       
        }    
    }
    if(agnf2!="Y")
    {
        document.getElementById('txtdeal').value="";
        document.getElementById("lstdeal").focus();  //uncomment
    }
    document.getElementById("lstdeal").value="0";
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0 && document.getElementById('txtdeal').value=="") 
    {    
        document.getElementById("lstdeal").focus();  //uncomment
    }    
   return false;
}
function bindexecname_callback(response)
{
     ds=response.value;
     var pkgitem = document.getElementById("lstexec");
     pkgitem.options.length = 0; 
     pkgitem.options[0]=new Option("-Select-","0");
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
     {
        pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].exec_name,ds.Tables[0].Rows[i].exe_no);                
           pkgitem.options.length;               
        }
     }
     if(document.getElementById("lstexec").style.visibility=="hidden")
         document.getElementById("lstexec").style.visibility="visible";
     if(agnf2!="Y")
      {
         document.getElementById('txtexecname').value="";
         document.getElementById("lstexec").focus();
       }
       document.getElementById("lstexec").value="0";
     return false;

}
function bindproductname_callback(response)
{
     ds=response.value;
     var pkgitem = document.getElementById("lstproduct");
     pkgitem.options.length = 0; 
     pkgitem.options[0]=new Option("-Select Product-","0");
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
     {
        pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].prod_desc,ds.Tables[0].Rows[i].prod_cat_code);                
            pkgitem.options.length;               
        }
        
    }
    if(agnf2!="Y")
      {
        document.getElementById('txtproduct').value="";
        if(document.getElementById("lstproduct").style.visibility=="hidden")
            document.getElementById("lstproduct").style.visibility="visible";
        document.getElementById("lstproduct").focus();
      }
      document.getElementById("lstproduct").value="0";      
    return false;

}
function bindretainer_callback(res)
{
    var ds=res.value;
    var pkgitem = document.getElementById("lstretainer");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select-","0");
    
        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
        {
            pkgitem.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Retain_Name,ds.Tables[0].Rows[i].Retain_Code);                
                pkgitem.options.length;               
            }
            
        }
        //document.getElementById("divretainer").style.display="block";
   if(agnf2!="Y")
      {
        document.getElementById('drpretainer').value="";
        document.getElementById("lstretainer").focus();
      }          
      document.getElementById("lstretainer").value="0";
        return false;    
}
function call_bindexeczone(res)
{
    var ds=res.value;
    if(document.getElementById('drpretainer').value!='0' && document.getElementById('drpretainer').value!='' && retexeboth!="both")
    {
            var a="Executive name";
            if(browser!="Microsoft Internet Explorer")
            {
                a=document.getElementById('lbececname').textContent.replace("*[F2]","");
            }
            else
            {        
                a=document.getElementById('lbececname').innerText.replace("*[F2]","");
            }
       if(confirm('Are you sure you want to Take '+a))
        {
            document.getElementById('drpretainer').value="";    
            document.getElementById('txtRetainercomm').value="";  
             document.getElementById('txtRetainercommamt').value=""     
        }
        else
        {
            document.getElementById('txtexeczone').value="";
            document.getElementById('txtexecname').value="";
            return false;
        }
     }
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            document.getElementById('txtexeczone').value=ds.Tables[0].Rows[0].zone_name
            document.getElementById('hiddenzone').value=document.getElementById('txtexeczone').value;
        }
    }
}
function call_bindproduct(response)
{
     ds=response.value;
     var pkgitem = document.getElementById("drpbrand");
     pkgitem.options.length=0;
     pkgitem.options[0] = new Option("-Select-","0");
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
     {
        pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].brand_name,ds.Tables[0].Rows[i].brand_code);                
            pkgitem.options.length;               
        }
     }
     return false;
}
function f2query(event)
 {
 if(agnf2=="Y" && event.keyCode!=113)
 {
 if(document.activeElement.id=="txtclient")
        {
        if(document.getElementById('txtclient').value=="")
        {
           if(document.getElementById("divclient").style.display=="block")
                {
                    document.getElementById("divclient").style.display="none"
                    document.getElementById('txtclient').focus();
                    return false;
                }
                return false;
        }
        if(event.keyCode==40)
        {
            document.getElementById("lstclient").focus();
            return false;
        }
        else if(event.keyCode==27)
       {
          if(document.getElementById("divclient").style.display=="block")
            {
                document.getElementById("divclient").style.display="none"
                document.getElementById('txtclient').value="";
                document.getElementById('txtclient').focus();
            }
            return false;
        }
           
            document.getElementById("divclient").style.display="block";
              aTag = eval( document.getElementById("txtclient"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			             document.getElementById('divclient').style.top=document.getElementById("txtclient").offsetTop + (toppos+15) + "px";
			             document.getElementById('divclient').style.left=document.getElementById("txtclient").offsetLeft + leftpos+"px";
            tv_booking_transaction.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtclient').value,"Y",bindclientname_callback);
        }
        else if(document.activeElement.id=="txtagency")
            {
            if(document.getElementById('txtagency').value=="")
                {
               if(document.getElementById("div1").style.display=="block")
                {
                    document.getElementById("div1").style.display="none"
                    document.getElementById('txtagency').focus();
                    return false;
                }
                    return false;
                }
            if(event.keyCode==40)
             {
                document.getElementById("lstagency").focus();
                return false;
             }
             else if(event.keyCode==27)
                {
                  if(document.getElementById("div1").style.display=="block")
                    {
                        document.getElementById("div1").style.display="none"
                        document.getElementById('txtagency').value="";
                        document.getElementById('txtagency').focus();
                    }
                    return false;
                 }
            if(document.getElementById("div1").style.display=="none")
              {
                document.getElementById("div1").style.display="block";
                aTag = eval( document.getElementById("txtagency"))
                var btag;
                var leftpos=0;
                var toppos=0;        
             do
              {
                aTag = eval(aTag.offsetParent);
                leftpos	+= aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag=eval(aTag)
              } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
                    document.getElementById('div1').style.top=document.getElementById("txtagency").offsetTop + (toppos+15) + "px";
                    document.getElementById('div1').style.left=document.getElementById("txtagency").offsetLeft + leftpos+"px";
            }
            tv_booking_transaction.bindagencyname(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txtagency').value,"Y",bindagencyname_callback);
        }
        else if(document.activeElement.id=="txtdeal")
            {
            if(document.getElementById('txtdeal').value=="")
                {
               if(document.getElementById("divdeal").style.display=="block")
                {
                    document.getElementById("divdeal").style.display="none"
                    document.getElementById('txtdeal').focus();
                    return false;
                }
                    return false;
                }
            if(event.keyCode==40)
             {
                document.getElementById("lstdeal").focus();
                return false;
             }
             else if(event.keyCode==27)
               {
                 if(document.getElementById("divdeal").style.display=="block")
                    {
                        document.getElementById("divdeal").style.display="none"
                        document.getElementById('txtdeal').value="";
                        document.getElementById('txtdeal').focus();
                    }
                    return false;
                }     
             if(document.getElementById('txtagency').value=="" && document.getElementById('txtclient').value=="")
            {
            alert("Please select atleast one Client or Agency and Both");
            document.getElementById('txtdeal').value="";
            return false;
            }
             var client_code="";
             var agency_code="";
             if(document.getElementById('txtclient').value!="")
                {
                    var client_name=document.getElementById('txtclient').value.split('(');
                    var client_code=client_name[1].replace(')','');
                }
              if(document.getElementById('txtagency').value!="")
                {
                    var agency_name=document.getElementById('txtagency').value.split('(');
                    agency_code=agency_name[1].replace(')','');
                }
            if(document.getElementById("divdeal").style.display=="none")
              {
                document.getElementById("divdeal").style.display="block";
                aTag = eval( document.getElementById("txtdeal"))
                var btag;
                var leftpos=0;
                var toppos=0;        
             do
              {
                aTag = eval(aTag.offsetParent);
                leftpos	+= aTag.offsetLeft;
                toppos += aTag.offsetTop;
                btag=eval(aTag)
              } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
                    document.getElementById('divdeal').style.top=document.getElementById("txtdeal").offsetTop + (toppos+15) + "px";
                    document.getElementById('divdeal').style.left=document.getElementById("txtdeal").offsetLeft + leftpos+"px";
            }			             

            tv_booking_transaction.binddeal(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value,document.getElementById('txtdeal').value,client_code,agency_code,"Y",binddeal_callback);

            }
            else if(document.activeElement.id=="txtbartertype")
            {
            if(document.getElementById('txtbartertype').value=="")
                {
               if(document.getElementById("divbarter").style.display=="block")
                {
                    document.getElementById("divbarter").style.display="none"
                    document.getElementById('txtbartertype').focus();
                    return false;
                }
                    return false;
                }
            if(event.keyCode==40)
             {
                document.getElementById("lstbarter").focus();
                return false;
             }
             else if(event.keyCode==27)
               {
                 if(document.getElementById("divbarter").style.display=="block")
                    {
                        document.getElementById("divbarter").style.display="none"
                        document.getElementById('lstbarter').options.length=0;
                        document.getElementById('txtbartertype').value="";
                        document.getElementById('txtbartertype').focus();
                    }
                    return false;
                }
            if(document.getElementById("divbarter").style.display=="none")
              {
                aTag = eval( document.getElementById("txtbartertype"))
			    var btag;
			    var leftpos=0;
			    var toppos=0;        
			    do
			    {
				    aTag = eval(aTag.offsetParent);
				    leftpos	+= aTag.offsetLeft;
				    toppos += aTag.offsetTop;
				    btag=eval(aTag)
			    } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");    			
                    document.getElementById("divbarter").style.left=document.getElementById("txtbartertype").offsetLeft + leftpos+"px";
                    document.getElementById("divbarter").style.top= document.getElementById("txtbartertype").offsetTop + (toppos+15) + "px";//"510px";
                    document.getElementById("divbarter").style.display="block";
                var res;
                var agencycode="";
                  if(document.getElementById('txtagency').value!="")
                    {
                         agencycode = document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(')+1,document.getElementById('txtagency').value.length  + document.getElementById('txtagency').value.lastIndexOf('('));
                         agencycode = agencycode.replace(")", "");
                    } 
                 var clientcode = document.getElementById('txtclient').value;
                  if (clientcode.indexOf("(".toString()) > 0)
                     {
                        var myarray1 = clientcode.split('(');
                        client = myarray1[1];
                        client = client.replace(")", '');
                      }
                res=tv_booking_transaction.getBarter(document.getElementById('hiddencompcode').value,document.getElementById('hiddencenter').value,document.getElementById('txtbranch').value,agencycode,client,"Y");
                if(res.value!=null && res.value.Tables.length>0)
                {
                    var ds=res.value;
                    var objciragency=document.getElementById("lstbarter");
                    objciragency.options.length = 0; 
                    objciragency.options[0]=new Option("-Select-","0");            
                    objciragency.options.length = 1; 
                    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                    {
                        var name=ds.Tables[0].Rows[i].BARTE_DESC;
                        var value=ds.Tables[0].Rows[i].BARTER_CODE+"û"+ds.Tables[0].Rows[i].BARTER_AMOUNT+"û"+ds.Tables[0].Rows[i].STOPBOOKING;
                        objciragency.options[objciragency.options.length] = new Option(name,value);            
                        objciragency.options.length;       
                    }
                objciragency.focus();
                }
            }
       }
       else if(document.activeElement.id=="txtexecname")
            {
            if(document.getElementById('txtexecname').value=="")
                {
               if(document.getElementById("divexec").style.display=="block")
                {
                    document.getElementById("divexec").style.display="none"
                    document.getElementById('txtexecname').focus();
                    return false;
                }
                    return false;
                }
            if(event.keyCode==40)
             {
                document.getElementById("lstexec").focus();
                return false;
             }
             else if(event.keyCode==27)
               {
                 if(document.getElementById("divexec").style.display=="block")
                    {
                        document.getElementById("divexec").style.display="none"
                        document.getElementById('txtexecname').value="";
                        document.getElementById('txtexecname').focus();
                    }
                    return false;
                } 
            if(document.getElementById("divexec").style.display=="none")
              {
               aTag = eval( document.getElementById("txtexecname"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
	             document.getElementById('divexec').style.top=document.getElementById("txtexecname").offsetTop + (toppos+15) + "px";
	             document.getElementById('divexec').style.left=document.getElementById("txtexecname").offsetLeft + leftpos+"px";
	             document.getElementById("divexec").style.display="block";           
            }
            tv_booking_transaction.bindExec(document.getElementById('hiddencompcode').value,document.getElementById('txtexecname').value,"Y",bindexecname_callback);
        }
        else if(document.activeElement.id=="drpretainer")
            {
            if(document.getElementById('drpretainer').value=="")
                {
               if(document.getElementById("divretainer").style.display=="block")
                {
                    document.getElementById("divretainer").style.display="none"
                    document.getElementById('drpretainer').focus();
                    return false;
                }
                    return false;
                }
            if(event.keyCode==40)
             {
                document.getElementById("lstretainer").focus();
                return false;
             }
             else if(event.keyCode==27)
               {
                 if(document.getElementById("divretainer").style.display=="block")
                    {
                        document.getElementById("divretainer").style.display="none"
                        document.getElementById('drpretainer').focus();
                    }
                    return false;
                }
            if(document.getElementById("divretainer").style.display=="none")
              {
               aTag = eval( document.getElementById("drpretainer"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
	             document.getElementById('divretainer').style.top=document.getElementById("drpretainer").offsetTop + (toppos+15) + "px";
	             document.getElementById('divretainer').style.left=document.getElementById("drpretainer").offsetLeft + leftpos+"px";
	             document.getElementById("divretainer").style.display="block";           
            }
            var agcode="";
            if(document.getElementById('txtagency').value!="" && document.getElementById('txtagency').value.indexOf("(")>=0 && document.getElementById('txtagency').value.indexOf(")")>=0)
              agcode=document.getElementById('txtagency').value.substring(document.getElementById('txtagency').value.lastIndexOf('(')+1,document.getElementById('txtagency').value.lastIndexOf(')'));
             tv_booking_transaction.bindRetainer(document.getElementById('hiddencompcode').value,document.getElementById('drpretainer').value,agcode,"Y",bindretainer_callback);
        }
        else if(document.activeElement.id=="txtproduct")
            {
            if(document.getElementById('txtproduct').value=="")
                {
               if(document.getElementById("divproduct").style.display=="block")
                {
                    document.getElementById("divproduct").style.display="none"
                    document.getElementById('txtproduct').focus();
                    return false;
                }
                    return false;
                }
            if(event.keyCode==40)
             {
                document.getElementById("lstproduct").focus();
                return false;
             }
            if(document.getElementById("divproduct").style.display=="none")
              {
               aTag = eval( document.getElementById("txtproduct"))
			            var btag;
			            var leftpos=0;
			            var toppos=0;        
			            do
			            {
				            aTag = eval(aTag.offsetParent);
				            leftpos	+= aTag.offsetLeft;
				            toppos += aTag.offsetTop;
				            btag=eval(aTag)
			            } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
	             document.getElementById('divproduct').style.top=document.getElementById("txtproduct").offsetTop + (toppos+15) + "px";
	             document.getElementById('divproduct').style.left=document.getElementById("txtproduct").offsetLeft + leftpos+"px";
	             document.getElementById("divproduct").style.display="block";           
            }
            tv_booking_transaction.bindProduct(document.getElementById('hiddencompcode').value,document.getElementById('txtproduct').value,"Y",bindproductname_callback);
        } 
   }
        
 }
 function getpayandstatus(paymentmod,payname)
{
    document.getElementById('hiddensubcode').value=document.getElementById('drpagscode').value
    var subagency=document.getElementById("drpagscode").value;
    var datetime=document.getElementById('txtdatetime').value;
    var agencycode=document.getElementById('txtagency').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var dateformat=document.getElementById('hiddendateformat').value;
    if(subagency=="0") 
    {
        alert("Please select sub agency");
        return false;
    }
    var res=tv_booking_transaction.getpayandstatus(agencycodeglo,subagency,compcode,datetime, dateformat);
    var ds=res.value;
	   document.getElementById('txtgrossamt').value="";
	     document.getElementById('txtbillamt').value="";
            if(ds.Tables[1].Rows.length>0)
            {
                if(ds.Tables[1].Rows[0].status_name=="INACTIVE" || ds.Tables[1].Rows[0].status_name=="BANNED")
                {
                    alert("You Can't Book Ad with InActive/Banned Agency");
                    document.getElementById("drpagscode").options.length=0;
                    document.getElementById("txtagency").value="";
                    document.getElementById('txtagency').title="";
                    document.getElementById('txtagencytype').value="";
                    document.getElementById('txtagencystatus').value="";
                    document.getElementById('txtcreditperiod').value="";
                    document.getElementById('txtagencypaymode').value="";
                    document.getElementById('txttradedisc').value="";
                     document.getElementById('hiddenagcommflag').value="";
                    document.getElementById('txtgrossamt').value="";
                    if(document.getElementById('txtaddagencycommrate')!=null)
                        document.getElementById('txtaddagencycommrate').value="";
                    document.getElementById('hiddentradedisc').value="";
                    document.getElementById('txtagencyaddress').value="";
                    document.getElementById('txtagencyaddress').title="";
                    document.getElementById("txtagency").focus();
                    return false;
                }
            }    
            if(ds!=null)
            {
            if(ds.Tables[2].Rows[0].CREDIT_LIMIT!="" && ds.Tables[2].Rows[0].CREDIT_LIMIT!=null)
		        {
            if(parseFloat(ds.Tables[7].Rows[0].outstand)>parseFloat(ds.Tables[2].Rows[0].CREDIT_LIMIT))
            {
              if(!confirm('Outstanding amount of this agency exceeding the Credit Limit. Do you still want to book an Advertisement?'))
                {
                    document.getElementById("drpagscode").options.length=0;
                    document.getElementById("txtagency").value="";
                    document.getElementById('txtagency').title="";
                    document.getElementById('txtagencytype').value="";
                    document.getElementById('txtagencystatus').value="";
                    document.getElementById('txtcreditperiod').value="";
                    document.getElementById('txtagencypaymode').value="";
                    document.getElementById('txttradedisc').value="";
                     document.getElementById('hiddenagcommflag').value="";
                    document.getElementById('txtgrossamt').value="";
                    if(document.getElementById('txtaddagencycommrate')!=null)
                     document.getElementById('txtaddagencycommrate').value="";
                    document.getElementById('hiddentradedisc').value="";
                    document.getElementById('txtagencyaddress').value="";
                    document.getElementById('txtagencyaddress').title="";
                    document.getElementById("txtagency").focus();
                    return false;     
                }
            }
		        }
            if(ds.Tables[2].Rows.length>0)
            {
                 if(ds.Tables[2].Rows[0].BOOKING_TYPE!=null && ds.Tables[2].Rows[0].BOOKING_TYPE!="")
                 {
                    var btype=ds.Tables[2].Rows[0].BOOKING_TYPE;
                    var obj=document.getElementById('drpbooktype');
                    var len=obj.options.length;
                         for(var j=1;j<len;j++)
                        {
                            if(btype.indexOf(obj[j].value)<0)
                            {
                                 obj.options.remove(j);
                                 len=len-1;
                                 j=1;
                            }
                        }
                  }
                
            }
             document.getElementById('txtagency').title=document.getElementById('txtagency').value;
             document.getElementById('txtagencyaddress').title=document.getElementById('txtagencyaddress').value;
                if(ds.Tables[0].Rows.length>0)
                    document.getElementById('txtagencytype').value=ds.Tables[0].Rows[0].agency_type_name
                if(ds.Tables[1].Rows.length>0)
                {
                    document.getElementById('txtagencystatus').value=ds.Tables[1].Rows[0].status_name;
                    document.getElementById('hiddenstatus').value=ds.Tables[1].Rows[0].status_name;                    
                }
                if(ds.Tables[2].Rows.length>0)
                {
                    document.getElementById('txtcreditperiod').value=ds.Tables[2].Rows[0].Credit_Days;
                    if(ds.Tables[2].Rows[0].ALERT!=null && ds.Tables[2].Rows[0].ALERT!="")
                    {
                        alert(ds.Tables[2].Rows[0].ALERT);
                    }
                }  
                if(ds.Tables.length>7)
                {
                    if(ds.Tables[7].Rows.length>0)
                    {
                        document.getElementById('txtagencyoutstand').value=ds.Tables[7].Rows[0].outstand;
                    }  
                }    
                if(ds.Tables[4].Rows.length>0)
                {
                    if(ds.Tables[4].Rows[0].CASH_DISCOUNT1!=null)
                        document.getElementById('txtcashdiscount').value=ds.Tables[4].Rows[0].CASH_DISCOUNT1;
                    if(ds.Tables[4].Rows[0].CASH_DISCOUNT!=null)
                        document.getElementById('txtcashdiscount').value=ds.Tables[4].Rows[0].CASH_DISCOUNT;
                    if(ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE1!=null)    
                        document.getElementById('hiddencashrecieved').value=ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE1;
                    if(ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE!=null)    
                        document.getElementById('hiddencashrecieved').value=ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE;
                    document.getElementById('txttradedisc').value=ds.Tables[4].Rows[0].comm_rate;
                    document.getElementById('hiddenagcommflag').value=ds.Tables[4].Rows[0].FLAG;
                    document.getElementById('txtgrossamt').value="";
                    if(ds.Tables[4].Rows[0].Addl_Comm_Rate!=null && document.getElementById('txtaddagencycommrate')!=null)
                    document.getElementById('txtaddagencycommrate').value=ds.Tables[4].Rows[0].Addl_Comm_Rate;
                    document.getElementById('hiddentradedisc').value=document.getElementById('txttradedisc').value;
                    gbtradedisc=ds.Tables[4].Rows[0].comm_rate;
                }
                else
                {
                    alert("Please update the "+document.getElementById('txtagency').value+" Commission detail");
                    document.getElementById("txtagency").value="";
                    document.getElementById('txtagencytype').value="";
                    document.getElementById('txtagencystatus').value="";
                    document.getElementById('txtcreditperiod').value="";
                    document.getElementById('txtagencypaymode').value="";
                    document.getElementById('txttradedisc').value="";
                    document.getElementById('hiddenagcommflag').value="";
                    document.getElementById('txtgrossamt').value="";
                    if(document.getElementById('txtaddagencycommrate')!=null)
                    document.getElementById('txtaddagencycommrate').value="";
                    document.getElementById('hiddentradedisc').value="";
                    document.getElementById('txtagencyaddress').value="";
                    document.getElementById("txtagency").focus();
                    return false;
                }
                if(ds.Tables[5].Rows.length>0)
                {            
                    ///this is to bind the payment drop down and bill to drop down
                     var pkgitem=document.getElementById('txtagencypaymode');
                     var billobj=document.getElementById('drppaymenttype');
                     pkgitem.options.length = 0; 
                     billobj.options.length = 0; 
                     billobj.options[0]=new Option("Select","0");
                     billobj.options.length;
                     if(paymentmod!="" && payname!="")
                     {
                        for (var i = 0  ; i < ds.Tables[5].Rows.length; ++i)
                        {
                            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[5].Rows[i].payment_mode_name,ds.Tables[5].Rows[i].pay_mode_code);
                            billobj.options[billobj.options.length] = new Option(ds.Tables[5].Rows[i].payment_mode_name,ds.Tables[5].Rows[i].pay_mode_code);
                            billobj.options.length;
                            pkgitem.options.length;                           
                        }
                        document.getElementById('txtagencypaymode').value=ds.Tables[5].Rows[0].pay_mode_code;
                        document.getElementById('drppaymenttype').value=ds.Tables[5].Rows[0].pay_mode_code;
                        document.getElementById('hiddenpay').value=ds.Tables[5].Rows[0].pay_mode_code;
                        document.getElementById('hiddenbillpay').value=ds.Tables[5].Rows[0].pay_mode_code;
                    }
                    else
                    {
                        var arr=paymentmod.value.split(",");
                        var arr1=payname.value.split(",");
                          for(var i=0;i<arr.length;i++)
                            {
                                 pkgitem.options[pkgitem.options.length] = new Option(arr1[i].toString(),arr[i].toString());
                                 billobj.options[billobj.options.length]=new Option(arr1[i].toString(),arr[i].toString());                                 
                            }
                        document.getElementById('txtagencypaymode').value=arr[0].toString();
                        document.getElementById('drppaymenttype').value=arr[0].toString();
                        document.getElementById('hiddenpay').value=arr[0].toString();
                        document.getElementById('hiddenbillpay').value=arr[0].toString();
                    }
                     var ag=tv_booking_transaction.GETCASH_PAY(document.getElementById('hiddencompcode').value,document.getElementById('drppaymenttype').value);
                        var ds_n=ag.value;
                        var cashdiscount='N';
                        if(ds_n!=null && ds_n.Tables[0].Rows.length>0)
                        {
                            cashdiscount=ds_n.Tables[0].Rows[0].CASHDISCOUNT;
                        }
                    ///if pay mode is credit card than open the card name,its type and no div
                     if(document.getElementById('drppaymenttype').value=="CA0")  //CR0 is Credit Card code
                    {       
                        document.getElementById('cashrecvd').style.display="";
                        document.getElementById('drpcashrecieved').disabled =false;  
                          document.getElementById('txtcashdiscount').disabled =false;  
                           document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
                    }
                    else if(document.getElementById('drppaymenttype').value=="CR0")  //CR0 is Credit Card code
                {          
                    document.getElementById('tdcarname').style.display="";
                    document.getElementById('tdtxtcarname').style.display="";
                    document.getElementById('tdtype').style.display="";
                    document.getElementById('tddrptyp').style.display="";
                    document.getElementById('tdexdat').style.display="";
                    document.getElementById('tdtxtexdat').style.display="";
                    document.getElementById('tdcardno').style.display="";
                    document.getElementById('tdtxtcarno').style.display="";
                    document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
                    document.getElementById('tdrec').style.display="none";
                    document.getElementById('receipt').style.display="none";
                    document.getElementById('print').style.display="none";   
                    document.getElementById('tdchqno').style.display="none";
                    document.getElementById('tdchqdate').style.display="none";
                    document.getElementById('tdchqamt').style.display="none";
                    document.getElementById('tdbankname').style.display="none";
                    document.getElementById('tdtextchqno').style.display="none";            
                    document.getElementById('tdtextchqdate').style.display="none";
                    document.getElementById('tdtextchqamt').style.display="none";
                    document.getElementById('tdtextbankname').style.display="none";             
                       document.getElementById('cashrecvd').style.display="none";         
                    document.getElementById("txtreceipt").value=""; 
                }
                else if(document.getElementById('drppaymenttype').value=="CH0" || document.getElementById('drppaymenttype').value=="DD0" || document.getElementById('drppaymenttype').value=='PO0')  //CR0 is Credit Card code and DD0 is demand draft
                {          
        //           
                    document.getElementById('tdchqno').style.display="";
                    document.getElementById('tdchqdate').style.display="";
                    document.getElementById('tdchqamt').style.display="";
                    document.getElementById('tdbankname').style.display="";
                    document.getElementById('tdtextchqno').style.display="";            
                    document.getElementById('tdtextchqdate').style.display="";
                    document.getElementById('tdtextchqamt').style.display="";
                    document.getElementById('tdtextbankname').style.display="";
                    document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
                    document.getElementById('tdrec').style.display="none";
                    document.getElementById('receipt').style.display="none";
                    document.getElementById('print').style.display="none";   
                    document.getElementById('tdcarname').style.display="none";
                    document.getElementById('tdtxtcarname').style.display="none";
                    document.getElementById('tdtype').style.display="none";
                    document.getElementById('tddrptyp').style.display="none";
                    document.getElementById('tdexdat').style.display="none";
                    document.getElementById('tdtxtexdat').style.display="none";
                    document.getElementById('tdcardno').style.display="none";
                    document.getElementById('tdtxtcarno').style.display="none";
                    document.getElementById('cashrecvd').style.display="none";         
                    document.getElementById("txtreceipt").value=""; 
                }
                else
                {
                    document.getElementById('tdcarname').style.display="none";
                    document.getElementById('tdtxtcarname').style.display="none";
                    document.getElementById('tdtype').style.display="none";
                    document.getElementById('tddrptyp').style.display="none";
                    document.getElementById('tdexdat').style.display="none";
                    document.getElementById('tdtxtexdat').style.display="none";
                    document.getElementById('tdcardno').style.display="none";
                    document.getElementById('tdtxtcarno').style.display="none";
                    document.getElementById('txtcardname').value="";
                    document.getElementById('drptype').value="0";
                    document.getElementById('drpmonth').value="0";
                    document.getElementById('drpyear').value="0";
                    document.getElementById('txtcardno').value="";
                    document.getElementById("txtreceipt").value="";
                    document.getElementById('tdchqno').style.display="none";
                    document.getElementById('tdchqdate').style.display="none";
                    document.getElementById('tdchqamt').style.display="none";
                    document.getElementById('tdbankname').style.display="none";
                    document.getElementById('tdtextchqno').style.display="none";            
                    document.getElementById('tdtextchqdate').style.display="none";
                    document.getElementById('tdtextchqamt').style.display="none";
                    document.getElementById('tdtextbankname').style.display="none";
                    document.getElementById('ttextchqno').value="";            
                    document.getElementById('ttextchqdate').value="";   
                    document.getElementById('ttextchqamt').value="";   
                    document.getElementById('ttextbankname').value="";   
                    document.getElementById('cashrecvd').style.display="none";         
                    document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
                }
                if(cashdiscount=='Y')
                {
                      document.getElementById('cashrecvd').style.display="";
                        document.getElementById('drpcashrecieved').disabled =false;  
                          document.getElementById('txtcashdiscount').disabled =false;  
                           document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
                }
                else{
                    document.getElementById('cashrecvd').style.display="none";
                }
                }
                if(document.getElementById('txtagencystatus').value=="Banned")
                {
                    alert("You Cannot book the ad with this agency");
                    return false;        
                }
               if(agencycodeglo!="undefined" && agencycodeglo!=undefined)
               {
                    var resbill=tv_booking_transaction.bindbillto_ag(agencycodeglo,compcode);
                    dsbill=resbill.value;
                  var pkgitem = document.getElementById("drpbillto");
              
                 if(dsbill!= null && typeof(dsbill) == "object" && dsbill.Tables[0].Rows.length > 0) 
                 {
                      pkgitem.options.length = 0; 
                       var client_val=document.getElementById('txtclient').value;
                       var client_name=document.getElementById('txtclient').value;
                        if (document.getElementById('txtclient').value.indexOf("(".toString()) > 0)
                    {
                        client_val =document.getElementById('txtclient').value.substring(document.getElementById('txtclient').value.lastIndexOf("(")+1,document.getElementById('txtclient').value.length-1); //document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
                        client_name=document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
                        //alertfun();
                     }   
                        pkgitem.options[0]=new Option(client_name,client_val);
                      for (var i = 0  ; i < dsbill.Tables[0].Rows.length; ++i)
                      {
                      if(dsbill.Tables[0].Rows[i].bill_to=="")
                        pkgitem.options[pkgitem.options.length] = new Option(dsbill.Tables[0].Rows[i].agency_name,dsbill.Tables[1].Rows[0].sub_agency_code);      
                      else
                        pkgitem.options[pkgitem.options.length] = new Option(dsbill.Tables[0].Rows[i].agency_name,dsbill.Tables[0].Rows[i].bill_to);        
                        pkgitem.options.length;               
                      }                        
                  }
                  if(dsbill.Tables[1].Rows.length>0)
                  {
                    document.getElementById("drpbillto").value=dsbill.Tables[1].Rows[0].sub_agency_code
                    document.getElementById('hiddenbillto').value=dsbill.Tables[1].Rows[0].sub_agency_code
                  }
                }
            }
    return false;
}
 function alertfun()
  {
     var clientcode=document.getElementById('txtclient').value;
    if(clientcode.indexOf("(")>0)
    {
        var clientsplit=clientcode.split("(");
        var compcode=document.getElementById('hiddencompcode').value;
        clientsplit=clientsplit[1];
        clientsplit=clientsplit.replace(")","");
        var re=tv_booking_transaction.chkcasualclient(clientsplit,compcode);
        var ds=re.value;
        if(ds!==null && ds.Tables[0]!=null && ds.Tables[0]!=undefined)
        {
            if(ds.Tables[0].Rows.length>0)
            {
               if(ds.Tables[0].Rows[0].Remarks!=null && ds.Tables[0].Rows[0].Remarks!="")
                {
                    alert(ds.Tables[0].Rows[0].Remarks);
                }
        
            }
        }
        return false;
    }
  }
  function getpayandstatus1()
    {
        document.getElementById('hiddensubcode').value=document.getElementById('drpagscode').value
        var subagency=document.getElementById("drpagscode").value;
        var datetime=document.getElementById('txtdatetime').value;
        var agencycode=document.getElementById('txtagency').value;
        var compcode=document.getElementById('hiddencompcode').value;
        var dateformat=document.getElementById('hiddendateformat').value;

        if(subagency=="0") 
        {
            alert("Please select sub agency");
            return false;
        }

        var res=tv_booking_transaction.getpayandstatus(agencycodeglo,subagency,compcode,datetime, dateformat);
        
        
    var ds=res.value;
	   document.getElementById('txtgrossamt').value="";
	         document.getElementById('txtbillamt').value="";
    if(ds.Tables[1].Rows.length>0)
    {
        if(ds.Tables[1].Rows[0].status_name=="INACTIVE" || ds.Tables[1].Rows[0].status_name=="BANNED")
        {
            alert("You Can't Book Ad with InActive/Banned Agency");
            document.getElementById("drpagscode").options.length=0;
            document.getElementById("txtagency").value="";
            document.getElementById('txtagency').title="";
            document.getElementById('txtagencytype').value="";
            document.getElementById('txtagencystatus').value="";
            document.getElementById('txtcreditperiod').value="";
            document.getElementById('txtagencypaymode').value="";
            document.getElementById('txttradedisc').value="";
             document.getElementById('hiddenagcommflag').value="";
            document.getElementById('txtgrossamt').value="";
            if(document.getElementById('txtaddagencycommrate')!=null)
             document.getElementById('txtaddagencycommrate').value="";
            
            document.getElementById('hiddentradedisc').value="";
            //
            document.getElementById('txtagencyaddress').value="";
            document.getElementById('txtagencyaddress').title="";
            document.getElementById("txtagency").focus();
            return false;
        }
    }    
    if(ds!=null)
    {
    if(ds.Tables[2].Rows[0].CREDIT_LIMIT!="" && ds.Tables[2].Rows[0].CREDIT_LIMIT!=null)
		{
    if(parseFloat(ds.Tables[7].Rows[0].outstand)>parseFloat(ds.Tables[2].Rows[0].CREDIT_LIMIT))
    {
      if(!confirm('Outstanding amount of this agency exceeding the Credit Limit. Do you still want to book an Advertisement?'))
        {
            document.getElementById("drpagscode").options.length=0;
            document.getElementById("txtagency").value="";
            document.getElementById('txtagency').title="";
            document.getElementById('txtagencytype').value="";
            document.getElementById('txtagencystatus').value="";
            document.getElementById('txtcreditperiod').value="";
            document.getElementById('txtagencypaymode').value="";
            document.getElementById('txttradedisc').value="";
             document.getElementById('hiddenagcommflag').value="";
            document.getElementById('txtgrossamt').value="";
            if(document.getElementById('txtaddagencycommrate')!=null)
             document.getElementById('txtaddagencycommrate').value="";
            
            document.getElementById('hiddentradedisc').value="";
            //
            document.getElementById('txtagencyaddress').value="";
            document.getElementById('txtagencyaddress').title="";
            document.getElementById("txtagency").focus();
            return false;     
        }
    }
		}
    if(ds.Tables[2].Rows.length>0)
    {
         if(ds.Tables[2].Rows[0].BOOKING_TYPE!=null && ds.Tables[2].Rows[0].BOOKING_TYPE!="")
         {
            var btype=ds.Tables[2].Rows[0].BOOKING_TYPE;
            var obj=document.getElementById('drpbooktype');
            var len=obj.options.length;
                 for(var j=1;j<len;j++)
                {
                    if(btype.indexOf(obj[j].value)<0)
                    {
                         obj.options.remove(j);
                         len=len-1;
                         j=1;
                    }
                }
          }
        
    }
     document.getElementById('txtagency').title=document.getElementById('txtagency').value;
     document.getElementById('txtagencyaddress').title=document.getElementById('txtagencyaddress').value;
        if(ds.Tables[0].Rows.length>0)
            document.getElementById('txtagencytype').value=ds.Tables[0].Rows[0].agency_type_name
        if(ds.Tables[1].Rows.length>0)
        {
            document.getElementById('txtagencystatus').value=ds.Tables[1].Rows[0].status_name;
            document.getElementById('hiddenstatus').value=ds.Tables[1].Rows[0].status_name;
            
        }
        if(ds.Tables[2].Rows.length>0)
        {
            document.getElementById('txtcreditperiod').value=ds.Tables[2].Rows[0].Credit_Days;
            if(ds.Tables[2].Rows[0].ALERT!=null && ds.Tables[2].Rows[0].ALERT!="")
            {
                alert(ds.Tables[2].Rows[0].ALERT);
            }
        }  
        if(ds.Tables.length>7)
        {
            if(ds.Tables[7].Rows.length>0)
            {
                document.getElementById('txtagencyoutstand').value=ds.Tables[7].Rows[0].outstand;
            }  
        }    
        if(ds.Tables[4].Rows.length>0)
        {
            if(ds.Tables[4].Rows[0].CASH_DISCOUNT1!=null)
                document.getElementById('txtcashdiscount').value=ds.Tables[4].Rows[0].CASH_DISCOUNT1;
            if(ds.Tables[4].Rows[0].CASH_DISCOUNT!=null)
                document.getElementById('txtcashdiscount').value=ds.Tables[4].Rows[0].CASH_DISCOUNT;
            if(ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE1!=null)    
                document.getElementById('hiddencashrecieved').value=ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE1;
            if(ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE!=null)    
                document.getElementById('hiddencashrecieved').value=ds.Tables[4].Rows[0].CASH_DISCOUNTTYPE;
            document.getElementById('txttradedisc').value=ds.Tables[4].Rows[0].comm_rate;
            document.getElementById('hiddenagcommflag').value=ds.Tables[4].Rows[0].FLAG;
            document.getElementById('txtgrossamt').value="";
            if(ds.Tables[4].Rows[0].Addl_Comm_Rate!=null && document.getElementById('txtaddagencycommrate')!=null)
            document.getElementById('txtaddagencycommrate').value=ds.Tables[4].Rows[0].Addl_Comm_Rate;
            document.getElementById('hiddentradedisc').value=document.getElementById('txttradedisc').value;
            gbtradedisc=ds.Tables[4].Rows[0].comm_rate;
            //document.getElementById('hiddencattype').value=ds.Tables[4].Rows[0].agencytypecode;
////            if(document.getElementById('txtgrossamt').value!="")
////            {
////                getagrredamou();
////            }
        }
        else
        {
            alert("Please update the "+document.getElementById('txtagency').value+" Commission detail");
            document.getElementById("txtagency").value="";
            document.getElementById('txtagencytype').value="";
            document.getElementById('txtagencystatus').value="";
            document.getElementById('txtcreditperiod').value="";
            document.getElementById('txtagencypaymode').value="";
            document.getElementById('txttradedisc').value="";
            document.getElementById('hiddenagcommflag').value="";
            document.getElementById('txtgrossamt').value="";
            if(document.getElementById('txtaddagencycommrate')!=null)
            document.getElementById('txtaddagencycommrate').value="";
            document.getElementById('hiddentradedisc').value="";
            //
            document.getElementById('txtagencyaddress').value="";
            document.getElementById("txtagency").focus();
            return false;
        }
        if(ds.Tables[5].Rows.length>0)
        {            
            ///this is to bind the payment drop down and bill to drop down
             var pkgitem=document.getElementById('txtagencypaymode');
             var billobj=document.getElementById('drppaymenttype');
             pkgitem.options.length = 0; 
             billobj.options.length = 0; 
             billobj.options[0]=new Option("Select","0");
             billobj.options.length;
            //pkgitem.options[0]=new Option("--Select City--","0");
            //alert(pkgitem.options.length);
            for (var i = 0  ; i < ds.Tables[5].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[5].Rows[i].payment_mode_name,ds.Tables[5].Rows[i].pay_mode_code);
                billobj.options[billobj.options.length] = new Option(ds.Tables[5].Rows[i].payment_mode_name,ds.Tables[5].Rows[i].pay_mode_code);
                
                billobj.options.length;
                pkgitem.options.length;
               
            }
            document.getElementById('txtagencypaymode').value=ds.Tables[5].Rows[0].pay_mode_code;
            document.getElementById('drppaymenttype').value=ds.Tables[5].Rows[0].pay_mode_code;
            document.getElementById('hiddenpay').value=ds.Tables[5].Rows[0].pay_mode_code;
            document.getElementById('hiddenbillpay').value=ds.Tables[5].Rows[0].pay_mode_code;
             var ag=tv_booking_transaction.GETCASH_PAY(document.getElementById('hiddencompcode').value,document.getElementById('drppaymenttype').value);
                var ds_n=ag.value;
                var cashdiscount='N';
                if(ds_n!=null && ds_n.Tables[0].Rows.length>0)
                {
                    cashdiscount=ds_n.Tables[0].Rows[0].CASHDISCOUNT;
                }
            ///if pay mode is credit card than open the card name,its type and no div
             if(document.getElementById('drppaymenttype').value=="CA0")  //CR0 is Credit Card code
            {       
                document.getElementById('cashrecvd').style.display="";
                // document.getElementById('tdcashrecvd').style.display="";
                // document.getElementById('drpcashrecieved').value=executequery.Tables[0].Rows[0].CASH_RECIEVED;
                  document.getElementById('drpcashrecieved').disabled =false;  
                  document.getElementById('txtcashdiscount').disabled =false;  
                   document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
            }
            else if(document.getElementById('drppaymenttype').value=="CR0")  //CR0 is Credit Card code
        {          
            document.getElementById('tdcarname').style.display="";
            document.getElementById('tdtxtcarname').style.display="";
            document.getElementById('tdtype').style.display="";
            document.getElementById('tddrptyp').style.display="";
            document.getElementById('tdexdat').style.display="";
            
            document.getElementById('tdtxtexdat').style.display="";
            document.getElementById('tdcardno').style.display="";
            document.getElementById('tdtxtcarno').style.display="";
            document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
            
//             document.getElementById('txtcardname').disabled=false;
//            document.getElementById('drptype').disabled=false;
//            document.getElementById('drpmonth').disabled=false;
//            document.getElementById('drpyear').disabled=false;
//            document.getElementById('txtcardno').disabled=false;
            
            document.getElementById('tdrec').style.display="none";
            document.getElementById('receipt').style.display="none";
            document.getElementById('print').style.display="none";   
            
            document.getElementById('tdchqno').style.display="none";
            document.getElementById('tdchqdate').style.display="none";
            document.getElementById('tdchqamt').style.display="none";
            document.getElementById('tdbankname').style.display="none";
            
            document.getElementById('tdtextchqno').style.display="none";            
            document.getElementById('tdtextchqdate').style.display="none";
            document.getElementById('tdtextchqamt').style.display="none";
            document.getElementById('tdtextbankname').style.display="none";             
               document.getElementById('cashrecvd').style.display="none";         
            document.getElementById("txtreceipt").value=""; 
        }
        else if(document.getElementById('drppaymenttype').value=="CH0" || document.getElementById('drppaymenttype').value=="DD0" || document.getElementById('drppaymenttype').value=='PO0')  //CR0 is Credit Card code and DD0 is demand draft
        {          
//            document.getElementById('ttextchqno').disabled = false;
//            document.getElementById('ttextchqdate').disabled = false;
//            document.getElementById('ttextchqamt').disabled = false;
//            document.getElementById('ttextbankname').disabled = false;
            document.getElementById('tdchqno').style.display="";
            document.getElementById('tdchqdate').style.display="";
            document.getElementById('tdchqamt').style.display="";
            document.getElementById('tdbankname').style.display="";
            
            document.getElementById('tdtextchqno').style.display="";            
            document.getElementById('tdtextchqdate').style.display="";
            document.getElementById('tdtextchqamt').style.display="";
            document.getElementById('tdtextbankname').style.display="";
            document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
            
            document.getElementById('tdrec').style.display="none";
            document.getElementById('receipt').style.display="none";
            document.getElementById('print').style.display="none";   
            document.getElementById('tdcarname').style.display="none";
            document.getElementById('tdtxtcarname').style.display="none";
            document.getElementById('tdtype').style.display="none";
            document.getElementById('tddrptyp').style.display="none";
            document.getElementById('tdexdat').style.display="none";
            
            document.getElementById('tdtxtexdat').style.display="none";
            document.getElementById('tdcardno').style.display="none";
            document.getElementById('tdtxtcarno').style.display="none";
               document.getElementById('cashrecvd').style.display="none";         
             document.getElementById("txtreceipt").value=""; 
        }
        else
        {
            document.getElementById('tdcarname').style.display="none";
            document.getElementById('tdtxtcarname').style.display="none";
            document.getElementById('tdtype').style.display="none";
            document.getElementById('tddrptyp').style.display="none";
            document.getElementById('tdexdat').style.display="none";
            
            document.getElementById('tdtxtexdat').style.display="none";
            document.getElementById('tdcardno').style.display="none";
            document.getElementById('tdtxtcarno').style.display="none";
            
            document.getElementById('txtcardname').value="";
            document.getElementById('drptype').value="0";
            document.getElementById('drpmonth').value="0";
            document.getElementById('drpyear').value="0";
            document.getElementById('txtcardno').value="";
            document.getElementById("txtreceipt").value="";
            
            document.getElementById('tdchqno').style.display="none";
            document.getElementById('tdchqdate').style.display="none";
            document.getElementById('tdchqamt').style.display="none";
            document.getElementById('tdbankname').style.display="none";
            
            document.getElementById('tdtextchqno').style.display="none";            
            document.getElementById('tdtextchqdate').style.display="none";
            document.getElementById('tdtextchqamt').style.display="none";
            document.getElementById('tdtextbankname').style.display="none";
            
            document.getElementById('ttextchqno').value="";            
            document.getElementById('ttextchqdate').value="";   
            document.getElementById('ttextchqamt').value="";   
            document.getElementById('ttextbankname').value="";   
              document.getElementById('cashrecvd').style.display="none";         
            document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
        }
        if(cashdiscount=='Y')
        {
              document.getElementById('cashrecvd').style.display="";
                // document.getElementById('tdcashrecvd').style.display="";
                // document.getElementById('drpcashrecieved').value=executequery.Tables[0].Rows[0].CASH_RECIEVED;
                  document.getElementById('drpcashrecieved').disabled =false;  
                  document.getElementById('txtcashdiscount').disabled =false;  
                   document.getElementById('hiddenbillpay').value=document.getElementById('drppaymenttype').value;
        }
        else{
            document.getElementById('cashrecvd').style.display="none";
        }
           
        }
        if(document.getElementById('txtagencystatus').value=="Banned")
        {
            alert("You Cannot book the ad with this agency");
            return false;        
        }
        if(agencycodeglo!="undefined" && agencycodeglo!=undefined)
               {
                    var resbill=tv_booking_transaction.bindbillto_ag(agencycodeglo,compcode);
                    dsbill=resbill.value;
                  var pkgitem = document.getElementById("drpbillto");
              
                 if(dsbill!= null && typeof(dsbill) == "object" && dsbill.Tables[0].Rows.length > 0) 
                 {
                      pkgitem.options.length = 0; 
                       var client_val=document.getElementById('txtclient').value;
                       var client_name=document.getElementById('txtclient').value;
                        if (document.getElementById('txtclient').value.indexOf("(".toString()) > 0)
                    {
                        client_val =document.getElementById('txtclient').value.substring(document.getElementById('txtclient').value.lastIndexOf("(")+1,document.getElementById('txtclient').value.length-1); //document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
                        client_name=document.getElementById('txtclient').value.substring(0,document.getElementById('txtclient').value.lastIndexOf("("));
                        //alertfun();
                     }   
                        pkgitem.options[0]=new Option(client_name,client_val);
                      for (var i = 0  ; i < dsbill.Tables[0].Rows.length; ++i)
                      {
                      if(dsbill.Tables[0].Rows[i].bill_to=="")
                        pkgitem.options[pkgitem.options.length] = new Option(dsbill.Tables[0].Rows[i].agency_name,dsbill.Tables[1].Rows[0].sub_agency_code);      
                      else
                        pkgitem.options[pkgitem.options.length] = new Option(dsbill.Tables[0].Rows[i].agency_name,dsbill.Tables[0].Rows[i].bill_to);        
                        pkgitem.options.length;               
                      }                        
                  }
                  if(dsbill.Tables[1].Rows.length>0)
                  {
                    document.getElementById("drpbillto").value=dsbill.Tables[1].Rows[0].sub_agency_code
                    document.getElementById('hiddenbillto').value=dsbill.Tables[1].Rows[0].sub_agency_code
                  }
                }
       
     }
         

        return false;
    }