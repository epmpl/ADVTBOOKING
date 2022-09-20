
function loadfirst()
{

}



function SelectHi(grdid,obj,objlist)
			{ 		
			//alert(grdid+"gud"+obj+"ok"+objlist)
			
				if(document.getElementById("DataGrid1_ctl01_Checkbox4").checked==true)
				{ 
				var j1;
				var j;
				var str1="DataGrid1_ctl02_CheckBox1";
				for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				
				
				
				   
				if(objlist=="Checkbox4")
				{		 
				
				
				if(document.getElementById(str1).disabled==false)
				{
			document.getElementById(str1).checked=true;
			}
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				 if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_CheckBox1";
				 } 
				
				
				}
				
				
				
				
				//return false;
				
				
				}
				//return false;
				}
				else
				{ 
				var j1;
				var j;
				var str1="DataGrid1_ctl02_CheckBox1";
				for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				
				
				if(objlist=="Checkbox4")
				{		 
				
				
			document.getElementById(str1).checked=false;
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_CheckBox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_CheckBox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				
				
				
				}
				//return false;
				}
				
			}
			
   
   function  checkboxid()
{
var j1=1;
var i;
var j;
				
				
    var str1="DataGrid1_ctl02_CheckBox1";
    if(document.getElementById("DataGrid1")==null)
    {
        alert('please check atleast  id from grid' );
        return false;
    }

    else
    {
      //  var hiddenserverip=document.getElementById('hiddenserverip').value
      //  var userid=document.getElementById('hiddenuser_id').value
        for (j = 1; j < document.getElementById("DataGrid1").rows.length; j++) 
        { 
		    if(document.getElementById(str1).checked==true)
			{
			    if (browser != "Microsoft Internet Explorer") {
			        var ciobookid = document.getElementById("DataGrid1").rows[j].cells[1].textContent;
			        var agency = document.getElementById("DataGrid1").rows[j].cells[2].textContent;
			        var client = document.getElementById("DataGrid1").rows[j].cells[3].textContent;
			    }
			    else {
			        var ciobookid = document.getElementById("DataGrid1").rows[j].cells[1].innerHTML;
			        var agency = document.getElementById("DataGrid1").rows[j].cells[2].innerHTML;
			        var client = document.getElementById("DataGrid1").rows[j].cells[3].outerText;
			    }
//			     if(browser!="Microsoft Internet Explorer")
//			{
//			var pageno=(document.getElementById("DataGrid1").rows[j].cells[10].innerHTML).replace("<input class=\"proptextsmall\" value=","").replace(" type=\"text\" width=\"30px\">","");
//			}
//			else
//			var pageno=(document.getElementById("DataGrid1").rows[j].cells[10].innerHTML).replace("<INPUT class=proptextsmall value=","").replace(" width=30 type=text>","");
//		
			    
			    var clientcod=document.getElementById("hdnagncycod").value;
			   var comp_code=document.getElementById("hiddencompcode").value;
			    j1=2;
			    Modbukclient.updatestatusnew(ciobookid, clientcod, comp_code);
			}
			var  str2=str1.split('_')[1]
			var str3=str2.split('l')[1]
			var str4=str2.split('l')[0]
			str3=str3
			str3=Number(str3)+1;
			if(str3>=10)
			{
			str1="DataGrid1_ctl"+str3+"_CheckBox1";
			}
			else
			{
			 str1="DataGrid1_ctl0"+str3+"_CheckBox1";
			 } 				                 
			
		}
	     if(j1==2)
	     {
	     alert('Client has been successfully updated ');
	     }
    	 
	     if(j1==1)
	     {
	     alert('Please Select atlest one CheckBox for grid');
	     }
    	 
	     }


}

function formclose()
{
if(confirm("Do You Want To Skip This Page"))
		{
		
		
		window.close();
		//window.location.href='enterpage.aspx';
		return false;
		}
}