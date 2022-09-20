// JScript File
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

function exitclick()
{
if(confirm("Do You Want To Skip This Page"))
{
    window.close();
    return false;
 }  
 return false;
}

var hiddenauto="";


function autoornot()
 {
    if(document.getElementById('hiddenauto').value=="1")
    {
    
    changeoccured();
    return false;
    }
else
    {
    document.getElementById('txtcode').focus();
    userdefine();

    return false;
    }
return false;
}







function changeoccured()
{
  if(document.getElementById('hiddenauto').value=="1" )
    {
      
      ColorRateGroupMast.autogeneratecode(fillcall);
    }

}

function fillcall(res)
		{
		var ds=res.value;
		
		var newstr;
		
   
		
		      if(ds.Tables[0].Rows.length==0)
		                     {
		                      newstr=null;
		                       }
		                    else
		                        {
		                         newstr=ds.Tables[0].Rows[0].Color_Code;
		                        }
		                    if(newstr !=null )
		                        {
		                        var code= newstr;
		                       // var code=newstr.substr(2,4);
		                        code++;
		                        document.getElementById('txtcode').value="CR"+ code;
		                         }
		                    else
		                         {
		                          document.getElementById('txtcode').value="CR"+ "0";
		                          }
		    // }
	//return false;
		}
		
function userdefine()
    {
        if(document.getElementById('hiddenauto').value!="1")
        {
        
        document.getElementById('txtcode').disabled=false;
        document.getElementById('txtcode').focus();
        auto=trim(document.getElementById('hiddenauto').value);
         return false;
//         return false;
        }

return false;


}

function chkpercent()
{
   
        if(document.getElementById('txtover').value!="")
        {
                var limit=document.getElementById('txtover').value;
                var i=parseFloat(limit)
                //alert(i);
                
               	if(limit.indexOf("..")>=0)
	{
	 alert("Input Error");
	 document.getElementById('txtover').value="";
	 return false;
	}
                
                if(i>=0 && i<=100)
                {
                return true
                }
                else
                {
                alert("Percentage Premium Cannot Exeed 100% ");
                document.getElementById('txtover').value="";
                document.getElementById('txtover').focus();
                return false;
                }
        }
        
  }





function saveclick()
{
   

    if(trim(document.getElementById("txtcode").value)=="")  
    {

            alert("Please Enter Color Code");
            document.getElementById('txtcode').focus();
            return false;
       
    }
    if(document.getElementById("drpcolor").value=="0")  
    {

            alert("Please Select Color Rate");
            document.getElementById('drpcolor').focus();
            return false;
        
    }
    
  if(document.getElementById("drpadtyp").value=="0")  
    {

            alert("Please Select Ad Type");
            document.getElementById('drpadtyp').focus();
            return false;
       
    }
    
    if(document.getElementById("txtpackagecode").value=="0")  
    {

            alert("Please Select Package Code");
            document.getElementById('txtpackagecode').focus();
            return false;
       
    }
//    if(document.getElementById("drprategroupcode").value=="0")  
//    {

//            alert("Please Select Rate Group Code");
//            document.getElementById('drprategroupcode').focus();
//            return false;
//       
//    }
  
    
   if(document.getElementById("drpcolorname").value=="0")  
    {

            alert("Please Select Color Name");
            if(document.getElementById('drpcolorname').disable == false)
            document.getElementById('drpcolorname').focus();
            return false;
       
    }
    
    if(document.getElementById("txtover").value=="")  
    {

            alert("Please Enter the Package Premium");
            document.getElementById('txtover').focus();
            return false;
       
    }
    if(document.getElementById("txtfromdate").value=="")  
    {

            alert("Please Enter Form Date");
            document.getElementById('txtfromdate').focus();
            return false;
       
    }

 if(document.getElementById("txttilldate").value=="")  
    {

            alert("Please Enter To Date");
            document.getElementById('txttilldate').focus();
            return false;
       
    }
    
    
    if(document.getElementById("txtfromdate").value!=""|| document.getElementById("txttilldate").value!="")
			{
			
			var fromdate=document.getElementById("txtfromdate").value;
		    var todate=document.getElementById("txttilldate").value;
		    var dateformat=document.getElementById("hiddendateformat").value;
		    //===convert date.==============
		   if(dateformat=="mm/dd/yyyy")
		    {
		    var txtefffrom=document.getElementById('txtfromdate').value;
	        var txtefftill=document.getElementById('txttilldate').value;
		    }
		
		    if(dateformat=="dd/mm/yyyy")
		    {
			    var txtfrom=fromdate.split("/");
			    var ddfrom=txtfrom[0];
			    var mmfrom=txtfrom[1];
			    var yyfrom=txtfrom[2];
			    txtefffrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
    			
			    var txttill=todate.split("/");
			    var ddtill=txttill[0];
			    var mmtill=txttill[1];
			    var yytill=txttill[2];
			    txtefftill=mmtill+'/'+ddtill+'/'+yytill;
		    }
		    if(dateformat=="yyyy/mm/dd")
		    {
			    var txtfrom=fromdate.split("/");
			    var yyfrom=txtfrom[0];
			    var mmfrom=txtfrom[1];
			    var ddfrom=txtfrom[2];
			    txtefffrom=mmfrom+'/'+ddfrom+'/'+yyfrom;
    			
			    var txttill=todate.split("/");
			    var yytill=txttill[0];
			    var mmtill=txttill[1];
			    var ddtill=txttill[2];
			    txtefftill=mmtill+'/'+ddtill+'/'+yytill;
		    }
		    var fdate=new Date(txtefffrom);
		    var tdate=new Date(txtefftill);
		      if(fdate > tdate)
		     {
		         alert("From Date Should be Less than To Date");
		         document.getElementById("txtfromdate").focus();
		         return false;
		     }

         }

}

function newclick()
{
document.getElementById('txtpackagecode').disabled=false;
  document.getElementById('txtpackagecode').focus();
  return;


}

function a1()

{
document.getElementById('txtcode').disabled=false;
document.getElementById('txtcode').focus();
  return;

}

function a2()

{
document.getElementById('drpcolorname').disabled=false;
//document.getElementById('').disabled=false;
document.getElementById('drpcolorname').focus();
  return;

}

function checkdate1(input)
 {
    var dateformat=document.getElementById('hiddendateformat').value;
    if(dateformat=="mm/dd/yyyy")

    {
        var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity

    }
    if(dateformat=="yyyy/mm/dd")

    {
        var validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
    }
    if(dateformat=="dd/mm/yyyy")
    {
        var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
    }

    if (!validformat.test(input.value))
    {
        if(input.value=="")
        {
            return true;
        }
        else
        {
           
            alert(" Please Fill The Date In "+dateformat+" Format");
             document.getElementById(input.id).focus();
            input.value="";
            return false;
        }
    }
}


function packname()
{
if(document.getElementById('txtpackagecode').value!="0")
{
var packcode=document.getElementById('txtpackagecode').value;

ColorRateGroupMast.addcou(packcode,call_packname);
}
}

function call_packname(res)
{
var ds=res.value;
var packname = document.getElementById("txtpackagename");

}

function clearcolorrate() {
    document.getElementById('txtpackagecode').value = "0";
    document.getElementById('txtpackagename').value = "";
    document.getElementById('drppublication').value = "0";
//    document.getElementById('drpedition').value = "0";
//    document.getElementById('drpsupplement').value = "0";
    document.getElementById('drpcolor').value = "0";
    document.getElementById('drpcolorname').value = "0";
    document.getElementById('txtover').value = "";
    document.getElementById('txttilldate').value = "";
    document.getElementById('txtfromdate').value = "";
    document.getElementById('txtcode').value = "";
    document.getElementById('drpadtyp').value = "0";
    document.getElementById('drprategroupcode').value = "0";
    givebuttonpermission('ColorRateGroupMast');
}



function ischarKey(evt)
 {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if ((charCode == 31 || charCode == 47) || (charCode == 8) || (charCode >= 48 && charCode <= 57))
        return true;
    else
        return false;
}