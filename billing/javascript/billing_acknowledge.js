        // JScript File
        var browser=navigator.appName;

        function bind_edition11()
        {
        //     var comp_code=document.getElementById('hiddencompcode').value;
        //     var publication=document.getElementById('dppub1').value;
        var comp_code=document.getElementById('hiddencompcode').value;
        var pub_cent=document.getElementById('dppubcent').value;
        var publication=document.getElementById('dppub1').value;

        billing_acknowledge.edition_bind(publication,pub_cent,comp_code,call_bind_edition);
        //availablepremium.edition_bind(publication,call_bind_edition1);
        }



        function call_bind_edition(response)
        {
        ds= response.value;
        var edition=document.getElementById('dpedition');
        edition.options.length=0;
        edition.options[0]=new Option("--Select Edition Name--");
        document.getElementById("dpedition").options.length = 1;
        if(ds!=null && ds.Tables.length>0)
        {
        for(var i=0; i<ds.Tables[0].Rows.length; i++)
        {
        edition.options[edition.options.length] = new Option(ds.Tables[0].Rows[i].Edition_alias,ds.Tables[0].Rows[i].edition_code);
        edition.options.length;    
        }

        }
        return false
        }  





function run_report()
{	
{
    var    newstr = "";
    var    newstr1 = "";
    var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
    loadXML('xml/disschreg.xml');
    
    var abc= document.getElementById('txttodate1').value
      var abc1= document.getElementById('txtfrmdate').value
      var abc2= document.getElementById('txt_confirm').value
      
    var alrt;
    
    alrt=document.getElementById('lbDateFrom').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txtfrmdate').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter fromdate'+ abc1);
            document.getElementById('txtfrmdate').focus();
            return false;
        }
    } 
   
   alrt=document.getElementById('lbToDate').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txttodate1').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('txttodate1').focus();
            return false;
      
        }
        }


alrt=document.getElementById('lblconfirm').innerText;
    if(alrt.indexOf('*')>=0)
    {
        if(document.getElementById('txt_confirm').value=="")
        {
            var abc=alrt.replace("*","");
            alert('Please Enter '+ abc);
            document.getElementById('txt_confirm').focus();
            return false;
      
        }
        }


}
}

        function keySort(dropdownlist,caseSensitive) 
        {
        // check the keypressBuffer attribute is defined on the dropdownlist
        var undefined;
        if (dropdownlist.keypressBuffer == undefined)
        {
        dropdownlist.keypressBuffer = '';
        }
        // get the key that was pressed
        var key = String.fromCharCode(window.event.keyCode);
        dropdownlist.keypressBuffer += key;
        if (!caseSensitive)
        {
        // convert buffer to lowercase
        dropdownlist.keypressBuffer = dropdownlist.keypressBuffer.toLowerCase();
        }
        // find if it is the start of any of the options
        var optionsLength = dropdownlist.options.length;
        for (var n=0; n<optionsLength; n++) 
        {
        var optionText = dropdownlist.options[n].text;
        if (!caseSensitive)
        {
        optionText = optionText.toLowerCase();
        }
        if (optionText.indexOf(dropdownlist.keypressBuffer,0) == 0)
        {
        dropdownlist.selectedIndex = n;
        return false; 
        // cancel the default behavior since
        // we have selected our own value
        }
        }
        // reset initial key to be inline with default behavior
        dropdownlist.keypressBuffer = key;
        return true; // give default behavior
        }



        function suppbind()
        {

        var compcode=document.getElementById('hdncompcode').value;
        var edition=document.getElementById('dpedition').value;
        billwisexls.bindsupp(compcode,edition,call_suppbind);
        }
        function call_suppbind(response)
        {
        ds= response.value;
        var edition=document.getElementById('dpsuppliment');
        edition.options.length=0;
        edition.options[0]=new Option("Select Supplement");
        document.getElementById("dpsuppliment").options.length = 1;


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






function  blankgrid()
{
document.getElementById("dpbill").options.length = 0;
document.getElementById('billrow').style.display='block';
if(document.getElementById('dpdadtype').value=='CL0')
{
var Classified=document.getElementById('hiddenclsbill').value;
if(Classified=='monthly' && document.getElementById('dpbill').value=="MONTH")
{
document.getElementById("divmonth").style.display="block";
document.getElementById("divnew").style.display="none";
}
else
{
document.getElementById("divmonth").style.display="none";
document.getElementById("divnew").style.display="block";

}
    if(document.getElementById('hiddenclass_billcri').value=="A")
    {
        var response=billing.bindbillcycl();
        var ds=response.value;
        var pkgitem = document.getElementById("dpbill");
//        pkgitem.options.length = 1; 
//        pkgitem.options[0]=new Option("--Select Bill Cycle--","0");
        
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].DESCRIPTION,ds.Tables[0].Rows[i].CODE);
            
           pkgitem.options.length;   
        }
 
    }
    else  if(document.getElementById('hiddenclass_billcri').value=="R")
    {
        loadXML('xml/billcycle.xml');
        var pkgitem = document.getElementById("dpbill");
//        pkgitem.options.length = 1; 
//        pkgitem.options[0]=new Option("--Select Bill Cycle--","0");
        
        for (var i = 0  ; i < xmlObj.childNodes(1).childNodes.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(xmlObj.childNodes(1).childNodes(i).text,xmlObj.childNodes(1).childNodes(i+1).text);
            i=i+1;
           pkgitem.options.length;   
        }
    }
    else  if(document.getElementById('hiddenclass_billcri').value=="P")
    {
        document.getElementById('billrow').style.display='none';
    }
}
if(document.getElementById('dpdadtype').value=='DI0')
{
var display=document.getElementById('hiddendisplaybill').value;

if(display=='monthly'  && document.getElementById('dpbill').value=="MONTH")
{
document.getElementById("divmonth").style.display="block";
document.getElementById("divnew").style.display="none";
}
else
{
document.getElementById("divmonth").style.display="none";
document.getElementById("divnew").style.display="block";
}
      if(document.getElementById('hiddendisp_billcri').value=="A")
    {
        var response=billing.bindbillcycl();
        var ds=response.value;
        var pkgitem = document.getElementById("dpbill");
//        pkgitem.options.length = 1; 
//        pkgitem.options[0]=new Option("--Select Bill Cycle--","0");
        
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].DESCRIPTION,ds.Tables[0].Rows[i].CODE);
            
           pkgitem.options.length;   
        }
 
    }
    else  if(document.getElementById('hiddendisp_billcri').value=="R")
    {
        loadXML('xml/billcycle.xml');
        var pkgitem = document.getElementById("dpbill");
//        pkgitem.options.length = 1; 
//        pkgitem.options[0]=new Option("--Select Bill Cycle--","0");
        
        for (var i = 0  ; i < xmlObj.childNodes(1).childNodes.length; ++i)
        {
            pkgitem.options[pkgitem.options.length] = new Option(xmlObj.childNodes(1).childNodes(i).text,xmlObj.childNodes(1).childNodes(i+1).text);
            i=i+1;
           pkgitem.options.length;   
        }
    }
    else  if(document.getElementById('hiddendisp_billcri').value=="P")
    {
        document.getElementById('billrow').style.display='none';
    }
}
if(document.getElementById("DataGrid1")!=null)
{

document.getElementById("DataGrid1").outerText='';
return false;
}

if(document.getElementById("DataGrid2")!=null)
{

document.getElementById("DataGrid2").outerText='';
return false;
}

//if(document.getElementById('hiddenclass_billcri').value=="R")
// {
//    if(document.getElementById('dpbill').value=="2" || document.getElementById('dpbill').value=="3" || document.getElementById('dpbill').value=="4")
//    {
//    document.getElementById("divmonth").style.display="block";
//    document.getElementById("divnew").style.display="none";
//    }
//    else
//    {
//    document.getElementById("divmonth").style.display="none";
//    document.getElementById("divnew").style.display="block";
//    }
// }
 
document.getElementById('hiddenbillcycle').value=document.getElementById('dpbill').value;
bindadcat1();
bindpackage();


}










function bindpackage()
{
var compcode=document.getElementById('hiddencompcode').value;
var adtype1=document.getElementById('dpdadtype').value;
billing_acknowledge.bindpackagenew(adtype1,compcode,call_bindpackage);
//billwisexls.adcatbnd(adtype1,compcode,call_adcatbind);
}
function call_bindpackage(response)
{
ds= response.value;
    var brand=document.getElementById('drppackage');
    brand.options.length=0;
    brand.options[0]=new Option("--Select Edition--");
    document.getElementById("drppackage").options.length = 1;
   
if(ds.Tables[0].Rows.length!=null)
{

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].Package_Name,ds.Tables[0].Rows[i].Combin_Code);
                brand.options.length;   
             }
 }        
 }
       return false;
}


function fetch_PACKAGE()
{
 document.getElementById("hiddenPACKAGE").value=document.getElementById("drppackage").value;
}
//=============================Agency=====================


function ttttt()
    {





    if(event.keyCode==8)  
    {

    if(document.activeElement.id=="txtagency")
    {             

    document.getElementById('txtagency').value = "";
    document.getElementById('hidden_agency').value = "";
   
    return false;
    }



    if(document.activeElement.id=="txtclient")
    {             

    document.getElementById('txtclient').value = "";
    return false;
    }




    if(document.activeElement.id=="dpretainer")
    {             

    document.getElementById('dpretainer').value = "";
    return false;
    }


    if(document.activeElement.id=="dpexecutive")
    {             

    document.getElementById('dpexecutive').value = "";
    return false;
    }



    }




    if(event.keyCode==27)  
    {
    document.getElementById("divclient").style.display="none";
    document.getElementById("div1").style.display="none";
    document.getElementById("div4").style.display="none";
    document.getElementById("div5").style.display="none";
    }

    if(event.keyCode==113)  
    {

    if(document.activeElement.id=="txtclient")
    {
    document.getElementById("divclient").style.display="block";
    document.getElementById('divclient').style.top=190;
    document.getElementById('divclient').style.left=570;    
    myurl+ billing.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtclient').value,bindclientname_callback);
    }



    if(document.activeElement.id=="txtagency")
    {




    document.getElementById('div1').value="";
    var compcode = document.getElementById('hiddencompcode').value;
    document.getElementById("div1").style.display="block";
    document.getElementById('div1').style.top=140+ "px" ;
    document.getElementById('div1').style.left=550+ "px";
    var dateformat = "'dd/mm/yyyy'";
    document.getElementById('div1').focus();      
    var txtagency1=(document.getElementById('txtagency').value).toUpperCase();   
    billing_acknowledge.bindagencyname(compcode,txtagency1,bindagencyname_callback);

    }







    if(document.activeElement.id=="dpretainer")
    {



       var extra1=(document.getElementById('dpretainer').value).toUpperCase();
    var extra2="";

    document.getElementById('lstretainer').value="";
    var compcode = document.getElementById('hiddencompcode').value;
    document.getElementById("div5").style.display="block";
    document.getElementById('div5').style.top=140+ "px" ;
    document.getElementById('div5').style.left=10+ "px";
    var dateformat = "'dd/mm/yyyy'";

    document.getElementById('lstretainer').focus();      



    billing.fillF2_Creditretainer(compcode,extra1,bindretainer_callback);
    }



    if(document.activeElement.id=="dpexecutive")
    {



    var extra1=(document.getElementById('dpexecutive').value).toUpperCase();     

    document.getElementById('lstexecutive').value="";
    var compcode = document.getElementById('hiddencompcode').value;
    document.getElementById("div4").style.display="block";
    document.getElementById('div4').style.top=140+ "px" ;
    document.getElementById('div4').style.left=50+ "px";
    var dateformat = "'dd/mm/yyyy'";
    document.getElementById('lstexecutive').focus();    





    billing.fillF2_Creditexecutive(compcode,extra1,bindexecutive_callback);
    }




    }








    ////////


    if(event.keyCode==9)  
    {





    if(document.activeElement.id=="lstclient")
    {

    insertclient();
    document.getElementById("dpbill").focus();
    return false;
    }


    if(document.activeElement.id=="lstexecutive")
    {

    fillexecutivegrp();
    }



    if(document.activeElement.id=="lstretainer")
    {

    fillmaingrp();
    }



    if(document.activeElement.id=="ListBox1")
    {
                
                insertagency( document.getElementById('ListBox1').value);
                document.getElementById("drpuserid").focus();
                return false;
                   
    }

    }

    if(event.keyCode==13)
    {

    if(document.activeElement.id=="ListBox1")
    {
                
                insertagency( document.getElementById('ListBox1').value);
                //$("drpuserid").focus();
                return false;
                   
    }

    }
    }
//        function ttttt()
//        {
//        if(event.keyCode==8)  
//        {

//        if(document.activeElement.id=="txtagency")
//        {             

//        document.getElementById('txtagency').value = "";
//        return false;
//        }



//        if(document.activeElement.id=="txtclient")
//        {             

//        document.getElementById('txtclient').value = "";
//        return false;
//        }




//        if(document.activeElement.id=="dpretainer")
//        {             

//        document.getElementById('dpretainer').value = "";
//        return false;
//        }


//        if(document.activeElement.id=="dpexecutive")
//        {             

//        document.getElementById('dpexecutive').value = "";
//        return false;
//        }



//        }




//        if(event.keyCode==27)  
//        {
//        document.getElementById("divclient").style.display="none";
//        document.getElementById("div1").style.display="none";
//        document.getElementById("div4").style.display="none";
//        document.getElementById("div5").style.display="none";
//        }

//        if(event.keyCode==113)  
//        {





//        if(document.activeElement.id=="txtagency")
//        {




//        document.getElementById('div1').value="";
//        var compcode = document.getElementById('hiddencompcode').value;
//        document.getElementById("div1").style.display="block";
//        document.getElementById('div1').style.top=140+ "px" ;
//        document.getElementById('div1').style.left=550+ "px";
//        var dateformat = "'dd/mm/yyyy'";
//        document.getElementById('div1').focus();      
//        var txtagency1=(document.getElementById('txtagency').value).toUpperCase();   
//        billing_acknowledge.bindagencyname(compcode,txtagency1,bindagencyname_callback);

//        }            
//        }
//   }







//        ////////



// if(event.keyCode==9)  
//        {
//    

//        if(document.activeElement.id=="ListBox1")
//        {

//        insertagency( document.getElementById('ListBox1').value);
//        document.getElementById("drpuserid").focus();
//        return false;

//        }



//        if(event.keyCode==13)
//        {

//        if(document.activeElement.id=="ListBox1")
//        {

//        insertagency( document.getElementById('ListBox1').value);
//        $("drpuserid").focus();
//        return false;

//        }

//        }
//        }


//    if(event.keyCode==9)  
//    {




//    if(document.activeElement.id=="ListBox1")
//    {

//    insertagency( document.getElementById('ListBox1').value);
//    document.getElementById("drpuserid").focus();
//    return false;

//    }

//    }

//    if(event.keyCode==13)
//    {

//    if(document.activeElement.id=="ListBox1")
//    {

//    insertagency( document.getElementById('ListBox1').value);
//    $("drpuserid").focus();
//    //$("drpuserid").focus();
//    return false;

//    }

//    }
//    }





        function insertagency(mycityval)
        {




        ////////////

        if(document.activeElement.id=="ListBox1")
        {
        if(document.getElementById('ListBox1').value=="0")
        {
        alert("Please select Agency Name");
        return false;
        }

        var page=document.getElementById('ListBox1').value;
        agencycodeglo=page;
        if(browser!="Microsoft Internet Explorer")
        {
        for(var k=0;k <= document.getElementById("ListBox1").length-1;k++)
        {
        var abc=document.getElementById('ListBox1').options[k].innerHTML;
        if(document.getElementById('ListBox1').options[k].value==page)
        {
        document.getElementById('ListBox1').value=abc;
        break;
        }
        }
        }
        else
        {
        for(var k=0;k <= document.getElementById("ListBox1").length-1;k++)
        {


        if(document.getElementById('ListBox1').options[k].value==page)
        {
        var abc=document.getElementById('ListBox1').options[k].innerText;
        var allvalues=document.getElementById('ListBox1').options[k].value;






        document.getElementById('txtagency').value=abc;
        var splitvalue= abc;
        var fival = abc.split("(");
        cityval  =  fival[0];
        distval  =  fival[1];



        var getvalue=distval.substring(0,distval.length-1)                 

        document.getElementById('hidden_agency').value=getvalue;




        }
        }
        }
        document.getElementById("div1").style.display='none';

        return false;
        }



        ///////







        }



        var agencycodeglo;






        function bindagencyname_callback(res)
        {   


        ds =res.value;
        document.getElementById("ListBox1").innerHTML = "";
        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
        {
        var pkgitem = document.getElementById("ListBox1");
        pkgitem.options.length = 0; 
        pkgitem.options[0]=new Option("-Select Agency -","0");
        pkgitem.options.length = 1; 

        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Agency_Name+"("+ds.Tables[0].Rows[i].code_subcode+")",ds.Tables[0].Rows[i].code_subcode);        
        pkgitem.options.length;
        }
        }

        document.getElementById("ListBox1").focus();

        return false;







        }



function  checkboxid()
{
var j1=1;
var i;
var j;

var str1="DataGrid1_ctl02_CheckBox1";
if(document.getElementById("DataGrid1")==null)
{
alert('please check atleast id from grid' );
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

var bill_number =	document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;

var delivery_man_name =	document.getElementById("DataGrid1").rows[j].cells[6].childNodes[0].value;
var delivery_date  = 	document.getElementById("DataGrid1").rows[j].cells[7].childNodes[0].value;
var acknowledge_date=  document.getElementById("DataGrid1").rows[j].cells[8].childNodes[0].value;
var remarks =  document.getElementById("DataGrid1").rows[j].cells[9].childNodes[0].value;
var date_format=document.getElementById('hiddendateformat').value;
j1=2;
billing_acknowledge.updatestatusnew(bill_number,delivery_man_name,delivery_date,acknowledge_date,remarks,date_format);


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
alert('Booking has been Successfully Confirm');
}

if(j1==1)
{
alert('Please Select atlest one CheckBox for COnfirmation');
return false;
}

}


}



	function checkvisible()
{
//`document.getElementById('divgrid1').style.display="block";
return false;
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
			
			
			
			
			function checkvalidations()
			{
			
			if(document.getElementById('txtfrmdate').value=="")
			{
			alert("Please Fill the from date");
			document.getElementById('txtfrmdate').focus();
			return false;
			
			}
			
				if(document.getElementById('txttodate1').value=="")
			{
			alert("Please Fill the date To");
			document.getElementById('txttodate1').focus();
			return false;
			
			}
			
			
					if(document.getElementById('dpselect').value=="0")
			{
			alert("Please Select Acknwledge/Non Acknowledge");
			document.getElementById('dpselect').value="0";
			document.getElementById('dpselect').focus();
			return false;
			
			}
			
			
			
			
			
					if(document.getElementById('txt_confirm').value=="")
			{
			alert("Please Fill the Confirmation Date");
			document.getElementById('txt_confirm').focus();
			return false;
			
			}
			
			
			
			
			
			
			
			}