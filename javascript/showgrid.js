
var browser=navigator.appName;
var valueformname;


function insertformname()
{

var userid=document.getElementById('hiddenuser').value;
//var modulename=document.getElementById('hiddenmodulename').value;
var moduleno=document.getElementById('hiddenmoduleno').value;


MasterPrevil.insform(moduleno,insertsavelink);
return false;
}


function insertsavelink(response)
{
var dm=response.value;
if(dm!=null)
{
//alert(document.getElementById("DataGrid1").rows.length);

var i=document.getElementById("DataGrid1").rows.length-1;
var j;

var compcode=document.getElementById('hiddencompcode').value;
//var userid=document.getElementById('hiddenuserid').value;
var userid=document.getElementById('hiddenuser').value;

//var userid=document.getElementById('hiddenuser').value;
//var modulename=document.getElementById('hiddenmodulename').value;
var modulename=dm.Tables[1].Rows[0].Module_Name;

var moduleno=document.getElementById('hiddenmoduleno').value;
var division=document.getElementById('hiddendivision').value;


for (j=0;j<document.getElementById("DataGrid1").rows.length-1;j++)
{

//var str="DataGrid1__ctl_CheckBox7"+j;
var str="CheckBox7" + j;
var str1="CheckBox1" + j;
var str2="CheckBox2" + j;
var str3="CheckBox3" + j;
var str4="CheckBox4" + j;
//var prev1;
//var prev2;
//var prev3;
//var prev4;
//var name;



    var formid=dm.Tables[0].Rows[j].form_id;
   
    var value=dm.Tables[0].Rows[j].Form_Name;
   
    if(document.getElementById(str1).checked==true)
    {
     prev1=1;

    }
    else
    {
    prev1=0;
    }
    if(document.getElementById(str2).checked==true)
    {
     prev2=2;

    }
    else
    {
    prev2=0;
    }
    if(document.getElementById(str3).checked==true)
    {
     prev3=4;

    }
    else
    {
    prev3=0;
    }
if(document.getElementById(str4).checked==true)
{
 prev4=8;

}
else
{
prev4=0;
}



var formname=dm.Tables[0].Rows[j].Form_Name;
var prev=  (prev1 + prev2 + prev3 + prev4);

   //  var value=dm.Tables[0].Rows[j].Form_Name;

    name="1";
    
    MasterPrevil.insertgrid(name,prev,value,modulename,userid,compcode,division,moduleno,formid);
    prev="";
    prev1="";
    prev2="";
    prev3="";
    prev4="";

  
    

}
var ip2=document.getElementById('ip1').value;
MasterPrevil.loginsert(userid,ip2);
alert("Permission Inserted");
document.getElementById('btninsert').disabled=true;
//document.getElementById('btnshow').disabled=false;
}
return false;


}
    

//**********************************update permission***********************************
function formnamechk()
{

var userid=document.getElementById('hiddenuser').value;

var moduleno=trim(document.getElementById('hiddenmoduleno').value);

MasterPrevil.form1(userid,moduleno,savelink);
return false;
}


function savelink(response)
{
var loop=1;
var dm=response.value;
//alert(document.getElementById("DataGrid1").rows.length);

var i=document.getElementById("DataGrid1").rows.length-1;
var j;

var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

//var userid=document.getElementById('hiddenuser').value;
//var modulename=document.getElementById('hiddenmodulename').value;
//var modulename=dm.Tables[1].Rows[0].Module_Name;

var moduleno="1";
var division=document.getElementById('hiddendivision').value;

for (j=0;j<document.getElementById("DataGrid1").rows.length-1;j++)
{

//var str="DataGrid1__ctl_CheckBox7"+j;
var str="CheckBox7" + j;
var str1="CheckBox1" + j;
var str2="CheckBox2" + j;
var str3="CheckBox3" + j;
var str4="CheckBox4" + j;
var str5="txtid" + j;

if(document.getElementById(str1).checked==true)
{
 prev1=1;
}
else
{
prev1=0;
}
if(document.getElementById(str2).checked==true)
{
 prev2=2;
}
else
{
prev2=0;
}
if(document.getElementById(str3).checked==true)
{
 prev3=4;

}
else
{
prev3=0;
}
if(document.getElementById(str4).checked==true)
{
 prev4=8;

}
else
{
prev4=0;
}
var rostatusval=document.getElementById(str5).value;
var userid1=document.getElementById('hiddenuser').value;
var moduleno="1";//trim(document.getElementById('hiddenmoduleno').value);


var formname=document.getElementById("DataGrid1").rows[loop].cells[1].innerHTML;
var modelcode=document.getElementById("DataGrid1").rows[loop].cells[9].innerHTML;
loop=loop+1;
var prev=  (prev1 + prev2 + prev3 + prev4);
//MasterPrevil.updateform("1",prev,formname,'',userid1,compcode,"1",moduleno,'');
//var ip2=document.getElementById('ip1').value;
MasterPrevil.insertgrid("1",prev,formname,'',userid1,compcode,"1",moduleno,'',rostatusval,modelcode);
//MasterPrevil.insertgrid(name,prev,value,modulename,userid,compcode,division,moduleno,formid);
prev="";
prev1="";
prev2="";
prev3="";
prev4="";
name="";

}

var ip2=document.getElementById('ip1').value;
MasterPrevil.loginsert(userid,ip2);
alert("Your Value Update");
document.getElementById('btnshow').disabled=false;

return false;


}


function call_save(response)
{
var ds=response.value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

var i=document.getElementById("DataGrid1").rows.length-1;
var j;


for (j=0;j<document.getElementById("DataGrid1").rows.length-1;j++)
{
var str="CheckBox7" + j;
var str1="CheckBox1" + j;
var str2="CheckBox2" + j;
var str3="CheckBox3" + j;
var str4="CheckBox4" + j;
var prev1;
var prev2;
var prev3;
var prev4;
var name



if(document.getElementById(str1).checked==true)
{
 prev1=1;

}
else
{
prev1=0;
}
if(document.getElementById(str2).checked==true)
{
 prev2=2;

}
else
{
prev2=0;
}
if(document.getElementById(str3).checked==true)
{
 prev3=4;

}
else
{
prev3=0;
}
if(document.getElementById(str4).checked==true)
{
 prev4=8;

}
else
{
prev4=0;
}

var userid1=document.getElementById('hiddenuser').value;
//var modulename=document.getElementById('hiddenmodulename').value;


var formname=ds.Tables[0].Rows[j].Form_Name;
var prev=  (prev1 + prev2 + prev3 + prev4);
MasterPrevil.updateform(prev,formname,modulename,userid1);
prev="";
prev1="";
prev2="";
prev3="";
prev4="";
name="";








}

return false;
}
function ankur(hi,hello)
{
var i=document.getElementById("DataGrid1").rows.length-1;
var j;




//alert(document.getElementById(hi).value);

if(document.getElementById(hi).checked==true)
{
return true;
}
else
{
alert("No Authorisation For this Form");
document.getElementById(hello).checked=false;

return false;
}








}

function SelectHi(grdid,obj,objlist)
			{ 
			
			
			
				if(document.getElementById(objlist).checked==true)
				{ 
				var j;
				for(j=0;j<document.getElementById("DataGrid1").rows.length-1;j++)
				
				{
				
				if(objlist=="Checkbox4")
				{
				var str1="CheckBox1" + j;
				document.getElementById(str1).checked=true;
				}
				if(objlist=="Checkbox5")
				{
				var str2="CheckBox2" + j;
				document.getElementById(str2).checked=true;
				}
				if(objlist=="Checkbox6")
				{
				var str3="CheckBox3" + j;
				document.getElementById(str3).checked=true;
				}
				if(objlist=="Checkbox8")
				{
				var str4="CheckBox4" + j;
				document.getElementById(str4).checked=true;
				}
				
				
				
				
				}
				return false;
				}
				else
				{ 
				var j;
				for(j=0;j<document.getElementById("DataGrid1").rows.length-1;j++)
				{
				if(objlist=="Checkbox4")
				{
				var str1="CheckBox1" + j;
				document.getElementById(str1).checked=false;
				}
				if(objlist=="Checkbox5")
				{
				var str2="CheckBox2" + j;
				document.getElementById(str2).checked=false;
				}
				if(objlist=="Checkbox6")
				{
				var str3="CheckBox3" + j;
				document.getElementById(str3).checked=false;
				}
				if(objlist=="Checkbox8")
				{
				var str4="CheckBox4" + j;
				document.getElementById(str4).checked=false;
				}
				
				
				
				
				
				
				}
				return false;
				}
				
			}
			 
		
					
					
					function chechedcolumn(str,j)
					{
					var j;
					
				var str="CheckBox7" + j;
				var str1="CheckBox1" + j;
				var str2="CheckBox2" + j;
				var str3="CheckBox3" + j;
				var str4="CheckBox4" + j;
				
				if(document.getElementById(str).checked==true)
				{
				document.getElementById(str1).checked=true;
				document.getElementById(str2).checked=true;
				
				document.getElementById(str3).checked=true;
				document.getElementById(str4).checked=true;
				
				}
				
			 if(document.getElementById(str).checked==false )
				{
				document.getElementById(str1).checked=false;
				document.getElementById(str2).checked=false;
				
				document.getElementById(str3).checked=false;
				document.getElementById(str4).checked=false;
				
				}
					
					
					}

function adduser(resid)
{
document.getElementById('hiddenuserid').value=resid;
module_detail.getuserinfo(resid,call_userinfo);
return false;
}
function call_userinfo(res)
{
    var ds=res.value;
    var comp_="";
    var admin_="";
    if(ds.Tables[0].Rows.length > 0)
    {
            var username = ds.Tables[0].Rows[0].username;
	        var compuser=ds.Tables[0].Rows[0].company_user;
	        var admin=ds.Tables[0].Rows[0].admin;
	        if(compuser=="Agency" && admin=="yes")
	        {
	            comp_=ds.Tables[0].Rows[0].agencyname;
	            admin_="Admin";
	        }
	        else if(admin=="yes" && compuser!="Agency")
	        {
	            comp_=ds.Tables[0].Rows[0].comp_name;
	            admin_="Admin";
	        }
	        else if(compuser=="Agency" && admin!="yes")
	        {
	            comp_=ds.Tables[0].Rows[0].agencyname;
	            admin_="User";
        	
	        }
	        else if(compuser!="Agency" && admin!="yes")
	        {
	            comp_=ds.Tables[0].Rows[0].comp_name;
	            admin_="User";
        	
	        }
	        var str="@";
	        var tot_=username+" "+str+" "+comp_+" "+"( "+admin_+" )" ;   
	        document.getElementById("user_info").innerHTML=tot_;
	}        

}


function addmodule()
{
document.getElementById('hiddenmodulename').value=document.getElementById('drpmodulename').Text;
document.getElementById('hiddenmoduleno').value=document.getElementById('drpmodulename').value;

return false;
}

function division()
{
document.getElementById('hiddendivision').value=document.getElementById('drpdivision').value;
return false;
}

function openform()
{


if(document.getElementById('drpuserid').value=="" || document.getElementById('drpuserid').value.lastIndexOf('+')<0)
{
alert("Please Select The User Name by Pressing F2");
document.getElementById('drpuserid').focus();
return false;

}
//else if(document.getElementById('drpmodulename').value=="0")
//{
//alert("Please Select The Module Name");
//document.getElementById('drpmodulename').focus();
//return false;
//}
//else if(document.getElementById('drpdivision').value=="0")
//{
//alert("Please Select Division");
//document.getElementById('drpdivision').focus();
//return false;
//}


var popUpWin=null;
for ( var index = 0; index < 200; index++ ) 
  { 
 var userid=document.getElementById('hiddenuserid').value;
var modulename=document.getElementById('hiddenmodulename').value;
var moduleno=document.getElementById('hiddenmoduleno').value;

var division=document.getElementById('hiddendivision').value;
    popUpWin 
     = window.open('MasterPrevil.aspx?userid='+userid+'&moduleno='+moduleno+' &modulename='+modulename+'&division='+division,'Ankur4', 'status=0,toolbar=0,resizable=1,top=290,left=202,scrollbars=yes,width=788px,height=550px'); 
  popUpWin.focus();
     return false;
  }

}


/*function openform()
{
var userid=document.getElementById('hiddenuserid').value;
var modulename=document.getElementById('hiddenmodulename').value;


window.open('MasterPrevil.aspx?userid='+userid+'&modulename='+modulename,'Ankur4', 'status=0,toolbar=0,resizable=1,top=244,left=210,scrollbars=yes,width=780px,height=415px'); 


}*/



function call_savechk(response)
{
var ds=response.value;
var compcode=document.getElementById('hiddencompcode').value;
var userid=document.getElementById('hiddenuserid').value;

var i=document.getElementById("DataGrid1").rows.length-1;
var j;


for (j=0;j<document.getElementById("DataGrid1").rows.length-1;j++)
{
var str="CheckBox7" + j;
var str1="CheckBox1" + j;
var str2="CheckBox2" + j;
var str3="CheckBox3" + j;
var str4="CheckBox4" + j;
var prev1;
var prev2;
var prev3;
var prev4;



if(document.getElementById(str1).checked==true)
{
 prev1=1;

}
else
{
prev1=0;
}
if(document.getElementById(str2).checked==true)
{
 prev2=2;

}
else
{
prev2=0;
}
if(document.getElementById(str3).checked==true)
{
 prev3=4;

}
else
{
prev3=0;
}
if(document.getElementById(str4).checked==true)
{
 prev4=8;

}
else
{
prev4=0;
}

var userid1=document.getElementById('hiddenuser').value;
var modulename=document.getElementById('hiddenmodulename').value;

var prev=  (prev1 + prev2 + prev3 + prev4);
var formname=ds.Tables[0].Rows[j].Form_Name;

MasterPrevil.updateform(prev,formname,modulename,userid1);
prev="";
prev1="";
prev2="";
prev3="";
prev4="";
name="";








}

return false;
}



///*******************This function is used to close current window**********************///
function masterpermexit()
{
		if(confirm("Do You Want To Skip This Page"))
		{
			//window.location.href='EnterPage.aspx';
			window.close();
			return false;
		}
		return false;
}

function LTrim( value ) {
	
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
function selectuser(event)
{
var key = event.keyCode ? event.keyCode : event.which;
      if(key==113 || (event.shiftKey==true && key==50))
    {
          if(document.getElementById('drpuserid').value.length <=2)
            {
            alert("Please Enter Minimum 3 Character For Searching.");
            document.getElementById('drpuserid').value="";
            return false;
            }
            document.getElementById("div2").style.display="block";
            if(browser != "Microsoft Internet Explorer")
            {
                  document.getElementById('div2').style.top= 70 +"px";
                  document.getElementById('div2').style.left= 210 +"px";
            }
            else
            {
                 document.getElementById('div2').style.top= 70+"px";
                  document.getElementById('div2').style.left= 10+"px";
            }
            module_detail.Binduser(document.getElementById('drpuserid').value.toUpperCase(),binduser_callback1);
        
        }
        
}
function binduser_callback1(response)
{       
    ds=response.value;
    var pkgitem = document.getElementById("lstuser");
    pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("---------Select user---------","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
//        pkgitem.options.length = 1; 
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            if (document.getElementById('hiddensessionuser').value == "yes")
                {                    
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].username+"+"+ds.Tables[0].Rows[i].userid,ds.Tables[0].Rows[i].userid);        
                     pkgitem.options.length; 
                }
                else
                {
                    if (ds.Tables[0].Rows[i].Admin == "" && ds.Tables[0].Rows[i].Company_user == "Agency")
                    { }
                    else
                    {
                        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].username+"+"+ds.Tables[0].Rows[i].userid,ds.Tables[0].Rows[i].userid);        
                     pkgitem.options.length; 
                    }
                }
//            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].agency_name +'+'+ds.Tables[0].Rows[i].CITYNAME,ds.Tables[0].Rows[i].code_subcode);        
//            pkgitem.options.length;       
        }
    }
    document.getElementById('drpuserid').value="";
    document.getElementById("lstuser").value="0";
    document.getElementById("lstuser").focus();
    return false;
}
//to fill user in text box
function insertuser()
{
    if(document.activeElement.id=="lstuser")
    {
    if(document.getElementById('lstuser').value=="0")
        {
        alert("Please select the user");
        return false;
        }
        document.getElementById("div2").style.display="none";
        
        var page=document.getElementById('lstuser').value;
        for(var k=0;k <= document.getElementById("lstuser").length-1;k++)
        {
               if(document.getElementById('lstuser').options[k].value==page)
               {
               if(browser!="Microsoft Internet Explorer")
                {
                    var abc=document.getElementById('lstuser').options[k].textContent;
                }
                else
                {        
                    var abc=document.getElementById('lstuser').options[k].innerText;
                }
                           //var abc=document.getElementById('lstuser').options[k].innerText;            
//                           var splitpub = abc;
//                           var str = splitpub.split("--");
//                           var username = str[0];
//                           var user = str[1];
                            document.getElementById('drpuserid').value=abc;
               
                }
          }
                 
//        document.getElementById('drpuserid').value=page;
        document.getElementById('drpuserid').focus();
        adduser(page);
        return false;
    }
}
function insertuserbyenter(event)
{
 var key = event.keyCode ? event.keyCode : event.which;   
    if(key==13)
    {
    if(document.getElementById('lstuser').value=="0")
        {
        alert("Please select the user");
        return false;
        }
        document.getElementById("div2").style.display="none";
        
        var page=document.getElementById('lstuser').value;
        for(var k=0;k <= document.getElementById("lstuser").length-1;k++)
        {
               if(document.getElementById('lstuser').options[k].value==page)
               {
                    if(browser!="Microsoft Internet Explorer")
                    {
                        var abc=document.getElementById('lstuser').options[k].textContent;
                    }
                    else
                    {        
                        var abc=document.getElementById('lstuser').options[k].innerText;
                    }
                                    
//                           var splitpub = abc;
//                           var str = splitpub.split("--");
//                           var username = str[0];
//                           var user = str[1];
                    document.getElementById('drpuserid').value=abc;
               
                }
          }
                 
//        document.getElementById('drpuserid').value=page;
        document.getElementById('drpuserid').focus();
        adduser(page);
        return false;
    }
}
function tabvalue(event,id)
{
     if(event.keyCode==27)
    {
    if(document.getElementById("div2").style.display=="block")
        {
            document.getElementById("div2").style.display="none"
            document.getElementById('drpuserid').focus();
        }
        }
if(browser!="Microsoft Internet Explorer")
 {
        if(event.which==13)
        {
        if(document.activeElement.id==id)
        {
            if(document.getElementById('btnshow').disabled==false)
            {
        document.getElementById('btnshow').focus();
            }
        return;

        }
//        else
//        {
//        //alert(event.keyCode);
//        event.which=9;
//        //alert(event.keyCode);
//        return event.which;
//        }
        }
 }       
else
{
     if(event.keyCode==13)
        {
            if(document.activeElement.id==id)
            {
                if(document.getElementById('btnshow').disabled==false)
                {
            document.getElementById('btnshow').focus();
                }
            return;

            }
//            else
//            {
//            //alert(event.keyCode);
//            event.keyCode=9;
//            //alert(event.keyCode);
//            return event.keyCode;
//            }
        }
        
        if(event.keyCode==120)
        {
           var formname=document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/")+1,document.URLUnencoded.lastIndexOf("."));
           window.open("Help.aspx?formname="+formname);
          
        }
}

}

