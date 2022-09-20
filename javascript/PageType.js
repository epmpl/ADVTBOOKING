// JScript File


var hiddenauto="";
var hiddentext="";
var hiddenqueryval="";
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


function savepagetypecode()
{

	document.getElementById('txtpagename').value=trim(document.getElementById('txtpagename').value);
 
 if(document.getElementById("drppublication").value=="0")  
    {
      if(document.getElementById("hiddendrppublication").value=="1")
      {
            alert("Please Select Publication");
            document.getElementById('drppublication').focus();
            return false;
       }
    }
  
 
 if(document.getElementById('hiddenauto').value!="1")
 {
 if(document.getElementById("txtpagetypecode").value=="")
    {
        alert("Please Enter Page Name");
        document.getElementById('txtpagename').focus();
        return false;
   
    
    }
 // return ;
  }
//    else
//     {
//        alert("Please Enter Product Code");
//        document.getElementById('txtprosubcode').focus();
//        return false;
//          
//     } 
//     return false;
// }
   
    
  if(document.getElementById("txtpagename").value=="")  
    {
       if(document.getElementById("hiddenpagename").value=="1")
        {
        alert("Please Enter Page Name");
        document.getElementById('txtpagename').focus();
        return false;
        }
    }
    
   if(document.getElementById('hiddenheight').value!="1")
   {
        if(document.getElementById("txtheight").value=="")
        {
        alert("Please Enter Height");
        document.getElementById('txtpageheight').focus();
        return false;
        }
   }
   
   if(document.getElementById('hiddenwidth').value!="1")
   {
        if(document.getElementById("txtwidth").value=="")
        {
        alert("Please Enter Width");
        document.getElementById('txtpagewidth').focus();
        return false;
        }
   }
    
   if(document.getElementById('hiddencolumns').value!="1")
   {
        if(document.getElementById("txtcolumns").value=="")
        {
        alert("Please Enter No. of Columns");
        document.getElementById('txtcolumns').focus();
        return false;
        }
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
  /*if(document.getElementById("txtalias").value=="")  
    {
        if(document.getElementById("txtalias").value=="1")
           {
            alert("Please Enter Product Alias");
            document.getElementById('txtalias').focus();
            return false;
            }
    
    }*/
    
    return ;
    
}

function exitclick()
{
  if(confirm("Do You Want To Exit This Page"))
			{
				window.close();
				return false;
			}
			return false;

   

}

function autoornot()
 {
 if(hiddentext=="new")
  {
  if(document.getElementById("drppublication").value=="0")  
    {
            alert("Please Select Publication");
            document.getElementById("txtpagename").value="";
            document.getElementById('drppublication').focus();
            return false;
    }
  }
  document.getElementById('txtpagename').value=document.getElementById('txtpagename').value.toUpperCase();
    if(document.getElementById('hiddenauto').value=="1")
    {
    changeoccured();
    //return false ;
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


        if(document.getElementById('hiddenauto').value=="1" )
        {
            if(hiddentext=="new" || hiddentext=="modify" )
            {
            document.getElementById('txtpagename').value=trim(document.getElementById('txtpagename').value);
            lstr=document.getElementById('txtpagename').value;
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

            if(document.getElementById('txtpagename').value!="")
            {
            document.getElementById('txtpagename').value=document.getElementById('txtpagename').value.toUpperCase();
            str=mstr;
            PageType.adchkadvcode(/*cod,*/str,document.getElementById("drppublication").value,fillcall);
            return false;
            }
            }
            }
        else
            {
            document.getElementById('txtpagename').value=document.getElementById('txtpagename').value.toUpperCase();
            }
  return false;     
}


function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
		    if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Page Name has already assigned !! ");
		    document.getElementById("txtpagename").value="";
		    //document.getElementById("txtalias").value="";
		    
		    document.getElementById('txtpagename').focus();
    		
		    return false;
		    }
		
		        else
		        {
		        if(hiddentext=="new")
	              {
		            if(document.getElementById('pnew').value=="1")
		            {

		                    if(ds.Tables[1].Rows.length==0)
		                        {
		                        newstr=null;
		                        }
		                    else
		                        {
		                         newstr=ds.Tables[1].Rows[0].PageTypeCode;
		                        }
		                    if(newstr !=null )
		                        {
		                        //var code=newstr.substr(2,4);
		                        var code=newstr;
		                        code++;
		                        document.getElementById('txtpagetypecode').value=str.substr(0,2)+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtpagetypecode').value=str.substr(0,2)+ "0";
		                          }
		            }
		            }              
		     }
	return false;
		}
		
function userdefine()
    {
        document.getElementById('txtpagename').value=document.getElementById('txtpagename').value.toUpperCase();
          if(hiddentext=="new" || hiddentext=="modify" )
        {
        
        document.getElementById('txtpagetypecode').disabled=false;
        if(hiddentext=="new" )
        auto=document.getElementById('hiddenauto').value;
        document.getElementById('txtpagename').value=document.getElementById('txtpagename').value.toUpperCase();
        document.getElementById('txtheight').focus();
        PageType.adchkadvcode(document.getElementById('txtpagename').value,document.getElementById("drppublication").value,fillcall1);
         return false;
        }

//return false;


}

function fillcall1(res)
{
var ds=res.value;
		
		  if(ds.Tables[0].Rows.length!=0)
		    {
		    alert("This Page Type has already assigned !! ");
		   
		document.getElementById('txtpagename').value="";
		if(document.getElementById('txtpagename').disabled==false)
		   document.getElementById('txtpagename').focus();
         
		    return false;
		    }
}

function chkquery()
{

     document.getElementById('pnew').value="0";
     hiddentext="query";
     //document.getElementById('btnExecute').focus();
     return ;

}

function focus()
{
    document.getElementById('drppublication').disabled=false;
    document.getElementById('drppublication').focus();


}

function checkdecht()
{
var num=document.getElementById('txtheight').value;
document.getElementById('txtheight').value=parseFloat(num);
var num1=document.getElementById('txtheight').value;
var z=parseFloat(document.getElementById('txtheight').value);
var tomatch=/^\d*(\.\d{1,2})?$/;
//PageType.saurabh(num);
if(z==0)
{
    alert("Height Cannot be Zero");
    //document.getElementById('txtheight').focus();
    document.getElementById('txtheight').disabled=false;
    document.getElementById('txtheight').focus();
    document.getElementById('txtheight').value="";
    return false;
}


if (tomatch.test(num1))
{
return;
}
else
{
alert("Input error");
document.getElementById('txtheight').focus();
document.getElementById('txtheight').value="";
return false; 
}
}

function checkdecwt()
{
var num=document.getElementById('txtwidth').value;

document.getElementById('txtwidth').value=parseFloat(num);
var num1=document.getElementById('txtwidth').value;
var z=parseFloat(document.getElementById('txtwidth').value);

var tomatch=/^\d*(\.\d{1,2})?$/;

if(z==0)
{
    alert("Width Cannot be Zero");
    
    document.getElementById('txtwidth').disabled=false;
    document.getElementById('txtwidth').focus();
    document.getElementById('txtwidth').value="";
    return false;
}

if (tomatch.test(num1))
{
return true;
}
else
{
alert("Input error");
document.getElementById('txtwidth').focus();
document.getElementById('txtwidth').value="";
return false; 
}
}

//function notchar2()
//{
//if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
//{
//return true;
//}
//return true;
//}

function newvalue()
{
    hiddentext="new";
}

function cancel()
{
 hiddentext="";
}

function clearpagetype() {
    document.getElementById('drppublication').value = "0";
    document.getElementById('txtpagetypecode').value = "";
    document.getElementById('txtpagename').value = "";
    document.getElementById('txtheight').value = "";
    document.getElementById('txtwidth').value = "";
    document.getElementById('txtcolumns').value = "";
    givebuttonpermission('PageType');
}



/*----------------------*/
function ischarKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && charCode > 32 && (charCode < 97 || charCode > 122) && (charCode < 65 || charCode > 90))
        return false;

    return true;
}