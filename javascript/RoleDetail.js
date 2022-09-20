// JScript File

function openform()
{


if(document.getElementById('drprole').value=="0")
{
alert("Please Select The Role Name ");
document.getElementById('drprole').focus();
return false;

}

var popUpWin=null;
for ( var index = 0; index < 200; index++ ) 
  { 
    var userid=document.getElementById('hiddenuserid').value;
    var modulename=document.getElementById('hiddenmodulename').value;
    var Roleid=document.getElementById('drprole').value;
    var division=document.getElementById('hiddendivision').value;
    popUpWin  = window.open('Role_Permission.aspx?userid='+userid+'&RoleId='+Roleid+' &modulename='+modulename+'&division='+division,'Ankur4', 'status=0,toolbar=0,resizable=1,top=290,left=202,scrollbars=yes,width=788px,height=402px'); 
    popUpWin.focus();
     return false;
  }

}

//----------------------------------for Update /Insert Permission -----------------------------------------------------------------//


function formnamechk()
{

        var loop=1;
        var j;
        var moduleno="1";
       
        var i=document.getElementById("DataGrid1").rows.length-1;
        var compcode=document.getElementById('hiddencompcode').value;
        var Roleid=trim(document.getElementById('hiddenRoleId').value);
      
        for (j=0;j<document.getElementById("DataGrid1").rows.length-1;j++)
        {

                var str="CheckBox7" + j;
                var str1="CheckBox1" + j;
                var str2="CheckBox2" + j;
                var str3="CheckBox3" + j;
                //var str4="CheckBox4" + j;

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
                //if(document.getElementById(str4).checked==true)
                //{
                // prev4=8;

                //}
                //else
                //{
                //prev4=0;
                //}

              //  var userid1=document.getElementById('hiddenuser').value;
                var moduleno="1";


                var formname=document.getElementById("DataGrid1").rows[loop].cells[1].innerHTML;
                loop=loop+1;
                var prev=  (prev1 + prev2 + prev3 );

                Role_Permission.insertgrid(prev,formname,Roleid,compcode);

                prev="";
                prev1="";
                prev2="";
                prev3="";
                //prev4="";
                name="";

        }


        alert("Your Value Update");
        document.getElementById('btnshow').disabled=false;

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
		//var str4="CheckBox4" + j;
		
		if(document.getElementById(str).checked==true)
		{
		    document.getElementById(str1).checked=true;
		    document.getElementById(str2).checked=true;
		    document.getElementById(str3).checked=true;
		    //document.getElementById(str4).checked=true;
		
		}
		
	    if(document.getElementById(str).checked==false )
		{
		    document.getElementById(str1).checked=false;
		    document.getElementById(str2).checked=false;
		    document.getElementById(str3).checked=false;
		    //document.getElementById(str4).checked=false;
		
		}
					
					
}
function tabvalue(event,id)
{
var browser=navigator.appName;
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

