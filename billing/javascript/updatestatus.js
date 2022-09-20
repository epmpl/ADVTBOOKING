// JScript File


function visible_false()
{
document.getElementById("btnsubmit").style.display="none";
}



function SelectHi(grdid,obj,objlist)
			{ 		
			
			
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
				return false;
				}
				
			}   
			
			
			
			
			
			
			
			
			
			
			
			//////////////
			
			
			
				function  checkboxidold()
{


var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var invoiceno="";
				var j;
				
				
				var str1="DataGrid1_ctl02_Checkbox1";
				if(document.getElementById("DataGrid1")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}

else
{
                 for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)				
				 {                
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				if(ciobookid=="")
				{
				ciobookid=document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
				 insertion= 	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
				 edition=  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
				}
				else
				{
				ciobookid= ciobookid+","+	document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
				 insertion= insertion+","+	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
				 edition=edition+","+  document.getElementById("DataGrid1").rows[j].cells[4].innerHTML;
				}					
		
			j1=2;	
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid1_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 
				  
				   

				 
				
				


}

var browser=navigator.appName;
///

function  checkboxid() {


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

   

var hiddenserverip=document.getElementById('hiddenserverip').value

var userid=document.getElementById('hiddenuser_id').value



                 for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)				
				 {

				   
				
				if(document.getElementById(str1).checked==true)
				{
				
				if (browser == "Microsoft Internet Explorer") {

				    var ciobookid = document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
				    var insertion = document.getElementById("DataGrid1").rows[j].cells[6].innerHTML;
				    var edition = document.getElementById("DataGrid1").rows[j].cells[7].outerText;
				}
				else {
				  
				    var ciobookid = document.getElementById("DataGrid1").rows[j].cells[3].textContent;
				    var insertion = document.getElementById("DataGrid1").rows[j].cells[6].textContent;

				    var edition = document.getElementById("DataGrid1").rows[j].cells[7].textContent;
				 
				}
			edition=trim(edition);
			j1 = 2;
			
			
	
			updatestatus.updatestatusnew(ciobookid,insertion,edition,hiddenserverip,userid);
			
			
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
				 alert('Booking has been Successfully publish');
				 }
				 
				 if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for Audit');
				 }
				 
				 }


}
	
	
	
	
	////////////////
	
	
	
	
	function	 chekvalidaton()
{
	
	  if(document.getElementById('dpdadtype').value=="0")
             {
            
                alert('Please Enter  Ad Type');
                document.getElementById('dpdadtype').focus();
                return false;
            
              }
              
              
	
	
	  
             if(document.getElementById('txtfrmdate').value=="")
             {
            
                alert('Please Enter  From Date');
                document.getElementById('txtfrmdate').focus();
                return false;
            
              }
               if(document.getElementById('txttodate1').value=="")
             {
            
                alert('Please Enter  Dateto');
                document.getElementById('txttodate1').focus();
                return false;
            
              }
              
              
        
        
             if(document.getElementById('drpstatus').value=="0")
             {
            
                alert('Please Enter  Status Type');
      document.getElementById('drpstatus').focus();

      
                return false;
            
              }
                   
              
              
              
              
              
              
	    //--------vishal kumar-------//        
             var edition = "0";
             for (var ed = 0; ed < document.getElementById('dpedition').options.length; ed++) {
                 if (document.getElementById('dpedition').options[ed].selected == true) {
                     if (document.getElementById('dpedition').options[ed].value != "0") {
                         edition = document.getElementById('dpedition').options[ed].value;
                         if (document.getElementById('hiddenedition').value == "0")
                             document.getElementById('hiddenedition').value = edition;
                         else
                             document.getElementById('hiddenedition').value = document.getElementById('hiddenedition').value + "," + edition
                     }
                 }
             }

	    //------vishal kumar------//     
	    //var edition=document.getElementById('dpedition').value; 

	    //document.getElementById('hiddenedition').value=edition;
 
 
 
  var supplement=document.getElementById('dpsupplement').value; 
 
 document.getElementById('hiddensupplement').value=supplement;
 
 
         var  pcomp_code=document.getElementById('hiddencompcode').value;
        var  puserid= document.getElementById('hiddenuser_id').value;
        var  pformname= "Publish_Audit";     
        var  pdateformat= document.getElementById('hiddendateformat').value;        
        var pextra1="";
        var pextra2=""; 
 


/* 
var res;
var  ds;
        if(document.getElementById('txtfrmdate')!="")
        {
        var  pentry_date= document.getElementById('txtfrmdate').value;
        
         res=updatestatus.fetch_date_data(pcomp_code,  pformname,  puserid,  pentry_date,  pdateformat,  pextra1,  pextra2);
          ds=res.value;
          
           if(ds.Tables[0].Rows[0].CHKDATE=="N")
        {
        alert('please choose the correct Date in From Date ');
        document.getElementById('txtfrmdate').value="";
        document.getElementById('txtfrmdate').focus();
        return false;
        }
        }
 
 */
 
 
 
 
 
            }
            
            
            
            
            	
	function checklenthbill()
{

document.getElementById("btnsubmit").style.display="none";
document.getElementById('divgrid1').style.display="none";
alert('Seaching criteria does not produce any result');


return false;



}
		
		
		
		
		
		
		           	
	function checkvisible()
{
document.getElementById("btnsubmit").style.display="block";
document.getElementById('divgrid1').style.display="block";
return false;
}
	
		
		
		
		
		
		function incorrectfromdate(input)
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

	if (!validformat.test(input.value) && (document.getElementById('hiddenolddate').value=="") )
	{
	
		if(input.value=="")
		{
		//input.focus();
		return true;
		}
		
		alert(" Please Fill The Date In "+dateformat+" Format");
		document.getElementById('txtfrmdate').value="";
		document.getElementById('txtfrmdate').focus();
		
		
		//document.activeElement.id="";
		

    
		return false;
	
		
	}
	
	
}

function incorrectodate(input)
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

	if (!validformat.test(input.value) && (document.getElementById('hiddenolddate').value=="") )
	{
	
		if(input.value=="")
		{
		//input.focus();
		return true;
		}
		
		alert(" Please Fill The Date In "+dateformat+" Format");
		
		
		document.getElementById('txttodate1').value="";
		document.getElementById('txttodate1').focus();
		
		//document.activeElement.id="";
		

    
		return false;
	
		
	}
	
	
}		 
   
          
            
            
			




function filledition()
{


updatestatus.fillEdition2(document.getElementById('dppub1').value,document.getElementById('dppubcent').value,document.getElementById('hiddencompcode').value,fillCat2_callback);
    
}
function fillCat2_callback(response)
{
    var ds=response.value;
    var pkgitem = document.getElementById("dpedition");
    pkgitem.options.length = 1; 
    pkgitem.options[0]=new Option("--Select Edition--","0");
    
   // document.getElementById("drpadvcatcode").options.length = 1; 
    //document.getElementById("drpadvcatcode").options[0]=new Option("--Select Ad Category3--","0");
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Edition_alias,ds.Tables[0].Rows[i].edition_code);
        
       pkgitem.options.length;
       
    }
   // document.getElementById("drpadsubcategory").value=glo_cat2;
  //  fillAdCat3();
    return false;
}



function suppbind()
{

var compcode=document.getElementById('hiddencompcode').value;
var edition=document.getElementById('dpedition').value;
updatestatus.bindsupp(compcode,edition,call_suppbind);
}
function call_suppbind(response)
{
ds= response.value;
    var edition=document.getElementById('dpsupplement');
    edition.options.length=0;
    edition.options[0]=new Option("--Select Supplement--");
    document.getElementById("dpsupplement").options.length = 1;
    

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Supp_Name,ds.Tables[0].Rows[i].Supp_Code);
                edition.options.length;    
             }
 }         
 
       return false;

}



function bindcategory()
{
 var comp_code=document.getElementById('hiddencompcode').value;
updatestatus.getcategory(comp_code,document.getElementById('dpdadtype').value,bindcategory_NEW);

}
function bindcategory_NEW(response)
{
    //alert(response.value);
    var ds=response.value;
    agcatby = document.getElementById("drprate");
 agcatby.options.length = 1; 
    agcatby.options[0]=new Option("--Select Category--","0");
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);
    var j=1;
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        agcatby.options[j] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code,ds.Tables[0].Rows[i].Adv_Cat_Code);   
                             //new Option(ds_AccName.Tables[0].Rows[i].Exec_name+"("+ds_AccName.Tables[0].Rows[i].Exe_no+")",ds_AccName.Tables[0].Rows[i].Exe_no);        
        
       j++;
       
    }
    }
}



function fetch_categary()
{
 document.getElementById("hdnexecutivetxt").value=document.getElementById("drprate").value;
}


	function trim(stringToTrim) 
 {

	return stringToTrim.replace(/^\s+|\s+$/g,"");
 }