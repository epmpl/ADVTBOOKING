function tabvalue1(event)
{
var browser=navigator.appName;
 if(event.keyCode==113)  
    {
        if(document.activeElement.id=="txtclient1")
        {
            if(document.getElementById('txtclient1').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('txtclient1').value="";
            return false;
            }
            document.getElementById("divclient").style.display="block";
               aTag = eval( document.getElementById("txtclient1"))
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
			             document.getElementById('divclient').style.top=document.getElementById("txtclient1").offsetTop + toppos + "px";
			             document.getElementById('divclient').style.left=document.getElementById("txtclient1").offsetLeft + leftpos+"px";
           
            fmg_transaction.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtclient1').value.toUpperCase(),bindclientname_callback);
        }
    }
    else if(event.keyCode==27)
    {
    if(document.getElementById("divclient").style.display=="block")
        {
            document.getElementById("divclient").style.display="none"
            document.getElementById('txtclient1').focus();
        }
    }
    else if(event.keyCode==13)
    {
    if(document.activeElement.id=="lstclient")
        {
            if(document.getElementById('lstclient').value=="0")
            {
                alert("Please select the client");
                return false;
            }
            document.getElementById("divclient").style.display="none";
            var datetime="";
                /*@@ this is the page which is designed to get the name as well as the add ress of client if 0 than client name and 
                    address and if 0 than agency name and address @@@@@@@@@@@@@@@@@@@*/
     
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
                //alert(httpRequest.readyState);
                if (httpRequest.readyState == 4) 
                {
                    //alert(httpRequest.status);
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
            document.getElementById('txtclient1').value=namecode;
            
           /* if(document.getElementById('hiddensavemod').value=="0")
            {
                document.getElementById('txtclient1add').value=add;
                document.getElementById('txtclient1add').focus();
            }
            bind_agen_bill();*/
            if(document.getElementById('txtexecname')!=null)
            document.getElementById('txtexecname').focus();
            return false;
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
            //alert(pkgitem.options.length);
        pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name,ds.Tables[0].Rows[i].Cust_Code);
        
            pkgitem.options.length;       
        }    
    }
    document.getElementById('txtclient1').value="";
    document.getElementById("lstclient").value="0";
    document.getElementById("lstclient").focus();  //uncomment
    
     return false;
}

function collectdata()
{
//alert("bhanu")
var j1=1;
var i;
                var j;
               
              var ciobookid="";
               var insertid="";
                var str1="chk";
                var cionew="";
                var fininsertid = "";
                var finsize = "";
                var fincolor = "";
                var rono = "";
                for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)               
                 {
                 
                   if(document.getElementById(str1+(j-1))!="null" && document.getElementById(str1+(j-1))!=null)
                    {
                         if(document.getElementById(str1+(j-1)).checked==true )
                             {
                                if(browser!="Microsoft Internet Explorer")
                                {
                                
                                      ciobookid=document.getElementById("DataGrid1").rows[j].cells[1].textContent;
                                      if(cionew!="" && cionew!=ciobookid)
                                      { 
                                        alert("You can select Insertions from single Booking.");
                                        return false;
                                      }
                                      else
                                      cionew=document.getElementById("DataGrid1").rows[j].cells[1].textContent;
                                      
                                      if(fininsertid=="")
                                       fininsertid=document.getElementById("DataGrid1").rows[j].cells[3].textContent;
                                       else
                                           fininsertid = fininsertid + "$" + document.getElementById("DataGrid1").rows[j].cells[3].textContent;

                                       if (finsize == "")
                                           finsize = document.getElementById("DataGrid1").rows[j].cells[7].textContent;
//                                       else
//                                           finsize = finsize + "~" + document.getElementById("DataGrid1").rows[j].cells[7].innerText;

                                       if (fincolor == "")
                                           fincolor = document.getElementById("DataGrid1").rows[j].cells[4].textContent;
//                                       else
//                                           fincolor = fincolor + "~" + document.getElementById("DataGrid1").rows[j].cells[4].innerText;
                                       //rono = document.getElementById("DataGrid1").rows[j].cells[11].innerText;
                                       rono = document.getElementById("DataGrid1").rows[j].cells[11].textContent;
                                
                                }
                                else
                                {
                                       ciobookid=document.getElementById("DataGrid1").rows[j].cells[1].innerText;
                                      if(cionew!="" && cionew!=ciobookid)
                                      { 
                                        alert("You can select Insertions from single Booking.");
                                        return false;
                                      }
                                      else
                                      cionew=document.getElementById("DataGrid1").rows[j].cells[1].innerText;
                                      
                                      if(fininsertid=="")
                                       fininsertid=document.getElementById("DataGrid1").rows[j].cells[3].innerText;
                                       else
                                           fininsertid = fininsertid + "$" + document.getElementById("DataGrid1").rows[j].cells[3].innerText;

                                       if (finsize == "")
                                           finsize = document.getElementById("DataGrid1").rows[j].cells[7].innerText;
//                                       else
//                                           finsize = finsize + "~" + document.getElementById("DataGrid1").rows[j].cells[7].innerText;

                                       if (fincolor == "")
                                           fincolor = document.getElementById("DataGrid1").rows[j].cells[4].innerText;
//                                       else
//                                           fincolor = fincolor + "~" + document.getElementById("DataGrid1").rows[j].cells[4].innerText;
                               
                                       rono = document.getElementById("DataGrid1").rows[j].cells[11].innerText;
                                  }
                             }
                             
                    }
                }
                window.opener.document.getElementById("txtrono").value="FMG-"+rono;
                 window.opener.fmgInsert = fininsertid;
                 window.opener.fmgsize = finsize;
                 window.opener.fmgcolor = fincolor;
                 window.opener.fmgreasons = document.getElementById("drpfmgresones").value;
                 window.close();
return false;
}

function checkvalidation()
{
var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
    {
   chmandat=document.getElementById('lblvfrm').textContent;
      
      
       
        if(chmandat.indexOf('*')>= 0)
        {
           
        

if(document.getElementById('txtvalidityfrom').value=="")
              {
              alert("Please Enter From Date");
              document.getElementById('txtvalidityfrom').focus();
              return false;
              }
              
              if(document.getElementById('txttilldate').value=="")
              {
              alert("Please Enter To Date");
              document.getElementById('txttilldate').focus();
              return false;
              }
              }
              else
              {
              
              if((document.getElementById('txtvalidityfrom').value==""||document.getElementById('txttilldate').value=="")&& document.getElementById('txtbookingid').value=="")
              {
                 alert("Please Enter  Date OR Booking ID");
                  document.getElementById('txtbookingid').focus();
                    return false;
              }

              
              }
              
              }
              else
              {
              
              chmandat=document.getElementById('lblvfrm').innerText;
      
      
       
        if(chmandat.indexOf('*')>= 0)
        {
           
        

if(document.getElementById('txtvalidityfrom').value=="")
              {
              alert("Please Enter From Date");
              document.getElementById('txtvalidityfrom').focus();
              return false;
              }
              
              if(document.getElementById('txttilldate').value=="")
              {
              alert("Please Enter To Date");
              document.getElementById('txttilldate').focus();
              return false;
              }
              }
              else
              {
              
              if((document.getElementById('txtvalidityfrom').value==""||document.getElementById('txttilldate').value=="")&& document.getElementById('txtbookingid').value=="")
              {
                 alert("Please Enter  Date OR Booking ID");
                  document.getElementById('txtbookingid').focus();
                    return false;
              }

              
              }
              
              }
}

function exit1()
{
    window.close();
}
function insertagency()
{
var browser=navigator.appName;
    if(document.activeElement.id=="lstclient")
    {
       if(document.getElementById('lstclient').value=="0")
        {
            alert("Please select the client");
            return false;
        }
        document.getElementById("divclient").style.display="none";
        var datetime="";
        
     
        var page=document.getElementById('lstclient').value;
       
        
        var id="";
        if(browser!="Microsoft Internet Explorer")
        {
            var  httpRequest =null;;
            httpRequest= new XMLHttpRequest();
            if (httpRequest.overrideMimeType) {
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
         if(id=="yes")
         {
             alert('Session TimeOut. Unable To Process Your Request. Please Login Again.');
             return false;
         }
         var split=id.split("+");
         var namecode=split[0];
         var add=split[1];

        
        document.getElementById('txtclient1').value=namecode;
      return false;
    }
}


function enable() {
    var str1 = "chk";

    var flag = "Y";
    var cionew = "";
    var fininsertid = "";
    var finsize = "";
    var fincolor = "";
    for (j = 1; j < document.getElementById("DataGrid1").rows.length; j++) {

        if (document.getElementById(str1 + (j - 1)) != "null" && document.getElementById(str1 + (j - 1)) != null) {
            if (document.getElementById(str1 + (j - 1)).checked == true) {

                document.getElementById("drpfmgresones").disabled = false;
                flag = "N";

            }


        }


    }
    if (flag == "Y") {
        document.getElementById("drpfmgresones").disabled = true;
    }




}