// JScript File
var browser=navigator.appName;
var test="1";
var xmlDoc=null;
var xmlObj=null;
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
//        xmlDoc.onreadystatechange=verify; 
        xmlDoc.load(xmlFile); 
        xmlObj=xmlDoc.documentElement; 
        // alert(xmlObj.childNodes(0).childNodes(0).text);
    }

}
var myurl=document.URLUnencoded.split("/");
	            myurl=myurl[0]+"/"+myurl[1]+"/"+myurl[2]+"/"+myurl[3]+"/"+"billing"+"/"
	          
               //win=window.open(myurl+''+formname+'.aspx','','width='+screen.availWidth+',height='+screen.availHeight+',resizable=1,left=0,top=0,scrollbars=yes');
               
               
               
  
  function catexitclick()
{
			if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
			return false;
}             
               
               
               

function ttttt()
{





 if(event.keyCode==8)  
        {

       if(document.activeElement.id=="txtagency")
             {             
         
             document.getElementById('txtagency').value = "";
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
                    myurl+ revised_bill.bindclientname(document.getElementById('hiddencompcode').value,document.getElementById('txtclient').value,bindclientname_callback);
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
                    revised_bill.bindagencyname(compcode,txtagency1,bindagencyname_callback);
                 
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
       
       
 
  revised_bill.fillF2_Creditretainer(compcode,extra1,bindretainer_callback);
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
             
                    
 
       
       
        revised_bill.fillF2_Creditexecutive(compcode,extra1,bindexecutive_callback);
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
                                document.getElementById("drpbillstatus").focus();
                                return false;
                                   
                    }
         
        }
        
        if(event.keyCode==13)
        {
        
          if(document.activeElement.id=="ListBox1")
                    {
                                
                                insertagency( document.getElementById('ListBox1').value);
                                $("drpbillstatus").focus();
                                return false;
                                   
                    }
        
        }
}







function bindexecutive_callback(res)
{
     var ds_AccName=res.value;     
         document.getElementById("lstexecutive").innerHTML = "";
      
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0)
        {
            var pkgitem = document.getElementById("lstexecutive");
            pkgitem.options.length = 0;
            pkgitem.options[0]=new Option("-Select Executive Name-","0");
            pkgitem.options.length = 1;
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(trim(ds_AccName.Tables[0].Rows[i].Exec_name)+"("+ds_AccName.Tables[0].Rows[i].Exe_no+")",ds_AccName.Tables[0].Rows[i].Exe_no);        
                pkgitem.options.length;
            }
        }
//        document.getElementById("lstexecutive").value="0";
//        document.getElementById("div3").value="";
//   
  
        return false;

}






 function trim(stringToTrim) 
 {
	return stringToTrim.replace(/^\s+|\s+$/g,"");
 }
 
function repalcesinglequote(val)
{
    if(val.indexOf("'")>=0)
    {
        while(val.indexOf("'")>=0)
        {
            val=val.replace("'","^");
        }
    }
    return val;
}






function bindretainer_callback(res)
{   
    
        
        ds =res.value;
     document.getElementById("lstretainer").innerHTML = "";
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        var pkgitem = document.getElementById("lstretainer");
        pkgitem.options.length = 0; 
        pkgitem.options[0]=new Option("-Select Reatiner Name-","0");
        pkgitem.options.length = 1; 
        
        for (var i = 0  ;  i < ds.Tables[0].Rows.length;  ++i)
        {
       pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Retain_Name+"("+ds.Tables[0].Rows[i].Retain_Code+")",ds.Tables[0].Rows[i].Retain_Code);        
                pkgitem.options.length;
        }
    }
    
        
        
        return false;

        
        
        
        
        

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
        pkgitem.options[0]=new Option("-Select Agency Name-","0");
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




function bindclientname_callback(response)
{
         
    ds=response.value;
    var pkgitem = document.getElementById("lstclient");
     pkgitem.options.length = 0; 
    pkgitem.options[0]=new Option("-Select Client-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);

   
    //alert(pkgitem.options.length);
    pkgitem.options.length = 1; 
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Cust_Name,ds.Tables[0].Rows[i].Cust_Code);
        
       pkgitem.options.length;
       
    }
    
    }
    document.getElementById('txtclient').value="";
    document.getElementById("lstclient").value="0";
   document.getElementById("lstclient").focus();
    
     return false;
}







////////////////this function is called when we open the list box of agency than on mouse click it get the agency
/*change*/
function insertclient()
{


    if(document.activeElement.id=="lstclient")
    {
    if(document.getElementById('lstclient').value=="0")
        {
        alert("Please select the client");
        return false;
        }
        document.getElementById("divclient").style.display="none";
        
 
           
        var page=document.getElementById('lstclient').value;
        agencycodeglo=page;
         var xml = new ActiveXObject("Microsoft.XMLHTTP");
         xml.Open( "GET","agencylist2.aspx?page="+page+"&value=1", false );
         xml.Send();
         var id=xml.responseText;
         
         var split=id.split("+");
         var nameagen=split[0];
         var agenadd1=split[1];
         var agenadd2=split[2];
         var agenadd3=split[3];
        
         
        
        document.getElementById('txtclient').value=nameagen;

         document.getElementById('dpbill').focus();
        
        document.getElementById("divclient").style.display='none';
        
        return false;
    }
    
    


}	


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
	
	
	function checklenthbill()
{
//document.getElementById('divgrid1').style.display="none";
alert('Seaching criteria does not produce any result');

return false;



}
	
	
	function  checkboxid()
{

var checkradio="";



if (document.getElementById("billprev").checked == true)
            {
                checkradio="1";
            }
            else
                if (document.getElementById("billgen").checked ==true)
                {
                    checkradio="2";
                }
                 else
                    if (document.getElementById("billreprint").checked ==true)
                    {
                        checkradio ="3";
                    }
                else
                {
                    checkradio ="4";
                }

if(checkradio=="4")
{
alert('please select altest once Billing type');
return false;
}

if(document.getElementById("hiddencheck").value!='CL0')
{

var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
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
				 
				 
				 //window.open('invoice_package.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 if(checkradio==3)
				 {
				 
				 window.open(myurl+'testnewsambad.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 }
				 else
				 {
window.open(myurl+'invoice_package.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);

				 }
				  
				   
		}
		else
		
		{
		
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";


				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				
				
				if(agencycode=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
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
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 window.open(myurl+'invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client);
				  
				   
				 
				 
				 

				 
				
				
		}
				 
				 
				 

				 
				
				


}
	

 function  checklenthbill1()
				 {
				 alert ('this bill can not be printed');
				  return false;
				 
				 }
				 
				 


/*				 
				 
function	 chekvalidaton()
{



//garima
var check=1;






	
	    if(document.getElementById('dpdadtype').value=="0")
             {
            
                alert('Please Enter  Adtype');
                document.getElementById('dpdadtype').focus();
               return false;
            
              }
	
	
	
				 
      if(document.getElementById('drpbillstatus').value=="0")
             {
            
                alert('Please Enter  Bill Type');
                document.getElementById('drpbillstatus').focus();
                return false;
            
              }
              
              
             
           
              
              
//                  if(document.getElementById('drpbooking').value=="0")
//             {
//            
//                alert('Please Enter  Publication Center');
//               return false;
//            
//              }
//              
              
           
           
           
               if(document.getElementById('dpdadtype').value=='CL0')
         {  
         
         
               if((document.getElementById('hiddenclsbill').value=='insertionwise')||(document.getElementById('hiddenclsbill').value=='orderwisefirstins'))
           {
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
            
           
           }
           
           
           //////////////
           
           
              if(document.getElementById('hiddenclsbill').value=='orderwiselastins')
           {            
            
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
            
                if((document.getElementById('txtfrmdate').value!="")||(document.getElementById('txttodate1').value!=""))
             {           
            
            var dateformat=document.getElementById('hiddendateformat').value;
              if(dateformat=="mm/dd/yyyy")
              {
                var strfromdate=document.getElementById('txtfrmdate').value;
                var strdateto=document.getElementById('txttodate1').value;
                 var strfromdate1mon=strfromdate.split('/')[0]
                var strdateto1mon=strdateto.split('/')[0]
                var strfromdate1year=strfromdate.split('/')[2]
                var strdateto1year=strdateto.split('/')[2]
              }
            else
            if(dateformat=="dd/mm/yyyy")
            {
            
                 var strfromdate=document.getElementById('txtfrmdate').value;
                var strdateto=document.getElementById('txttodate1').value;
                var strfromdate1mon=strfromdate.split('/')[1]
                var strdateto1mon=strdateto.split('/')[1]
                var strfromdate1year=strfromdate.split('/')[2]
                var strdateto1year=strdateto.split('/')[2]
            }
            else         
            
            {
                 var strfromdate=document.getElementById('txtfrmdate').value;
                var strdateto=document.getElementById('txttodate1').value;
                var strfromdate1mon=strfromdate.split('/')[1]
                var strdateto1mon=strdateto.split('/')[1]
                 var strfromdate1year=strfromdate.split('/')[0]
                var strdateto1year=strdateto.split('/')[0]
            }
            
              if(strfromdate1mon==strdateto1mon && strfromdate1year==strdateto1year)
              {
              }
              else
             {
              alert('selected from date  and Date to  must be of same year and month');
              document.getElementById('txtfrmdate').value="";
               document.getElementById('txttodate1').value="";
              document.getElementById('txttodate1').focus();
              return false;
              }
            
         }
         
         
         }
          
         
         
         }
            
            
            
            
            

        
         
         if(document.getElementById('dpdadtype').value=='DI0')
         {   
         
         
         
           if((document.getElementById('hiddendisplaybill').value=='insertionwise')||(document.getElementById('hiddendisplaybill').value=='orderwisefirstins'))
           {
           if(document.getElementById('txtfrmdate').value=="")
               {
            
                alert('Please Enter  From Date');
                return false;
            
                }
               if(document.getElementById('txttodate1').value=="")
               {            
                alert('Please Enter  Dateto');
                return false;            
               }           
            
           
           }
         
         
         
         
             
                 
        
          
           if(document.getElementById('hiddendisplaybill').value=='orderwiselastins')
           {            
            
               if(document.getElementById('txtfrmdate').value=="")
               {
            
                alert('Please Enter  From Date');
                return false;
            
                }
               if(document.getElementById('txttodate1').value=="")
               {            
                alert('Please Enter  Dateto');
                return false;            
               }           
            
                if((document.getElementById('txtfrmdate').value!="")||(document.getElementById('txttodate1').value!=""))
             {           
            
            var dateformat=document.getElementById('hiddendateformat').value;
              if(dateformat=="mm/dd/yyyy")
              {
                var strfromdate=document.getElementById('txtfrmdate').value;
                var strdateto=document.getElementById('txttodate1').value;
                 var strfromdate1mon=strfromdate.split('/')[0]
                var strdateto1mon=strdateto.split('/')[0]
                var strfromdate1year=strfromdate.split('/')[2]
                var strdateto1year=strdateto.split('/')[2]
              }
            else
            if(dateformat=="dd/mm/yyyy")
            {
            
                 var strfromdate=document.getElementById('txtfrmdate').value;
                var strdateto=document.getElementById('txttodate1').value;
                var strfromdate1mon=strfromdate.split('/')[1]
                var strdateto1mon=strdateto.split('/')[1]
                var strfromdate1year=strfromdate.split('/')[2]
                var strdateto1year=strdateto.split('/')[2]
            }
            else         
            
            {
                 var strfromdate=document.getElementById('txtfrmdate').value;
                var strdateto=document.getElementById('txttodate1').value;
                var strfromdate1mon=strfromdate.split('/')[1]
                var strdateto1mon=strdateto.split('/')[1]
                 var strfromdate1year=strfromdate.split('/')[0]
                var strdateto1year=strdateto.split('/')[0]
            }
            
              if(strfromdate1mon==strdateto1mon && strfromdate1year==strdateto1year)
              {
              }
              else
             {
              alert('selected from date  and Date to  must be of same year and month');
              return false;
              }
            
         }
         
         
         }
         
      }
              
				 
				 
}

*/



function chekvalidaton()
{
    var check=1;	
    if(document.getElementById('dpdadtype').value=="0")
    {            
        alert('Please Enter  Adtype');
        document.getElementById('dpdadtype').focus();
        return false;            
    }				 
    if(document.getElementById('drpbillstatus').value=="0")
    {            
        alert('Please Enter  Bill Type');
        document.getElementById('drpbillstatus').focus();
        return false;            
    }    
       if(document.getElementById('hiddendisp_billcri').value=="R")
     {
        document.getElementById('hiddendisplaybill').value="insertionwise";
//        if(document.getElementById('dpbill').value=="1")
//        {
//          document.getElementById('hiddendisplaybill').value="insertionwise";
//        }
//        else if(document.getElementById('dpbill').value=="2" || document.getElementById('dpbill').value=="3" || document.getElementById('dpbill').value=="4")
//        {
//          document.getElementById('hiddendisplaybill').value="monthly";
//        }
//        else if(document.getElementById('dpbill').value=="5")
//        {
//          document.getElementById('hiddendisplaybill').value="orderwiselastins";
//        }
     } 
     
     if(document.getElementById('hiddenclass_billcri').value=="R")
     {
        document.getElementById('hiddendisplaybill').value="insertionwise";
//        if(document.getElementById('dpbill').value=="1")
//        {
//          document.getElementById('hiddenclsbill').value="insertionwise";
//        }
//        else if(document.getElementById('dpbill').value=="2" || document.getElementById('dpbill').value=="3" || document.getElementById('dpbill').value=="4")
//        {
//          document.getElementById('hiddenclsbill').value="monthly";
//        }
//        else if(document.getElementById('dpbill').value=="5")
//        {
//          document.getElementById('hiddenclsbill').value="orderwiselastins";
//        }
     }      
    if(document.getElementById('dpdadtype').value=='CL0')
    {
        if((document.getElementById('hiddenclsbill').value=='insertionwise')||(document.getElementById('hiddenclsbill').value=='orderwisefirstins'))
        {
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
        }
        if(document.getElementById('hiddenclsbill').value=='orderwiselastins')
        { 
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
            if((document.getElementById('txtfrmdate').value!="")||(document.getElementById('txttodate1').value!=""))
            { 
                var dateformat=document.getElementById('hiddendateformat').value;
                if(dateformat=="mm/dd/yyyy")
                {
                    var strfromdate=document.getElementById('txtfrmdate').value;
                    var strdateto=document.getElementById('txttodate1').value;
                    var strfromdate1mon=strfromdate.split('/')[0]
                    var strdateto1mon=strdateto.split('/')[0]
                    var strfromdate1year=strfromdate.split('/')[2]
                    var strdateto1year=strdateto.split('/')[2]
                }
                else
                if(dateformat=="dd/mm/yyyy")
                {        
                    var strfromdate=document.getElementById('txtfrmdate').value;
                    var strdateto=document.getElementById('txttodate1').value;
                    var strfromdate1mon=strfromdate.split('/')[1]
                    var strdateto1mon=strdateto.split('/')[1]
                    var strfromdate1year=strfromdate.split('/')[2]
                    var strdateto1year=strdateto.split('/')[2]
                }
                else 
                {
                    var strfromdate=document.getElementById('txtfrmdate').value;
                    var strdateto=document.getElementById('txttodate1').value;
                    var strfromdate1mon=strfromdate.split('/')[1]
                    var strdateto1mon=strdateto.split('/')[1]
                    var strfromdate1year=strfromdate.split('/')[0]
                    var strdateto1year=strdateto.split('/')[0]
                }            
                if(strfromdate1mon==strdateto1mon && strfromdate1year==strdateto1year)
                {
                }
                else
                {
                    alert('selected from date  and Date to  must be of same year and month');
                    document.getElementById('txtfrmdate').value="";
                    document.getElementById('txttodate1').value="";
                    document.getElementById('txttodate1').focus();
                    return false;
                }
            }
        } 
    }  
        
    if(document.getElementById('dpdadtype').value=='DI0')
    {
        if((document.getElementById('hiddendisplaybill').value=='insertionwise')||(document.getElementById('hiddendisplaybill').value=='orderwisefirstins'))
        {
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
         }          
        if(document.getElementById('hiddendisplaybill').value=='orderwiselastins')
        {
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
            if((document.getElementById('txtfrmdate').value!="")||(document.getElementById('txttodate1').value!=""))
            {  
                var dateformat=document.getElementById('hiddendateformat').value;
                if(dateformat=="mm/dd/yyyy")
                {
                    var strfromdate=document.getElementById('txtfrmdate').value;
                    var strdateto=document.getElementById('txttodate1').value;
                    var strfromdate1mon=strfromdate.split('/')[0]
                    var strdateto1mon=strdateto.split('/')[0]
                    var strfromdate1year=strfromdate.split('/')[2]
                    var strdateto1year=strdateto.split('/')[2]
                }
                else
                if(dateformat=="dd/mm/yyyy")
                {
                    var strfromdate=document.getElementById('txtfrmdate').value;
                    var strdateto=document.getElementById('txttodate1').value;
                    var strfromdate1mon=strfromdate.split('/')[1]
                    var strdateto1mon=strdateto.split('/')[1]
                    var strfromdate1year=strfromdate.split('/')[2]
                    var strdateto1year=strdateto.split('/')[2]
                }
                else 
                {
                    var strfromdate=document.getElementById('txtfrmdate').value;
                    var strdateto=document.getElementById('txttodate1').value;
                    var strfromdate1mon=strfromdate.split('/')[1]
                    var strdateto1mon=strdateto.split('/')[1]
                    var strfromdate1year=strfromdate.split('/')[0]
                    var strdateto1year=strdateto.split('/')[0]
                }
                if(strfromdate1mon==strdateto1mon && strfromdate1year==strdateto1year)
                {
                }
                else
                {
                    alert('selected from date  and Date to  must be of same year and month');
                    return false;
                }
            }
        }         
    }
    if(document.getElementById('hiddenclsbill').value=='monthly' || document.getElementById('hiddendisplaybill').value=='monthly')
    {
    /*
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
       */
         
        if(document.getElementById('dpbill').value=="WEEK")
        {
                var difference_days=days_between(document.getElementById('txtfrmdate').value, document.getElementById('txttodate1').value,document.getElementById('hiddendateformat').value)

            if(difference_days > 7)
            {
                alert("Selected period should be a week only!")
                document.getElementById('text_todate').value=""
                document.getElementById('text_todate').focus();
                return false;
            }
        }
        else
        if(document.getElementById('dpbill').value=="MONTH")
        {  
            if((document.getElementById('txtfrmdate').value!="")||(document.getElementById('txttodate1').value!=""))
            {  
                var dateformat=document.getElementById('hiddendateformat').value;
                if(dateformat=="mm/dd/yyyy")
                {
                    var strfromdate=document.getElementById('txtfrmdate').value;
                    var strdateto=document.getElementById('txttodate1').value;
                    var strfromdate1mon=strfromdate.split('/')[0]
                    var strdateto1mon=strdateto.split('/')[0]
                    var strfromdate1year=strfromdate.split('/')[2]
                    var strdateto1year=strdateto.split('/')[2]
                }
                else
                if(dateformat=="dd/mm/yyyy")
                {
                    var strfromdate=document.getElementById('txtfrmdate').value;
                    var strdateto=document.getElementById('txttodate1').value;
                    var strfromdate1mon=strfromdate.split('/')[1]
                    var strdateto1mon=strdateto.split('/')[1]
                    var strfromdate1year=strfromdate.split('/')[2]
                    var strdateto1year=strdateto.split('/')[2]
                }
                else 
                {
                    var strfromdate=document.getElementById('txtfrmdate').value;
                    var strdateto=document.getElementById('txttodate1').value;
                    var strfromdate1mon=strfromdate.split('/')[1]
                    var strdateto1mon=strdateto.split('/')[1]
                    var strfromdate1year=strfromdate.split('/')[0]
                    var strdateto1year=strdateto.split('/')[0]
                }
                if(strfromdate1mon==strdateto1mon && strfromdate1year==strdateto1year)
                {
                }
                else
                {
                    alert('selected from date  and Date to  must be of same year and month');
                    document.getElementById('text_todate').value=""
                    document.getElementById('text_todate').focus();
                    return false;
                   
                }
            }        	   
        }
            
    }    		 
}

function  checkvisible()
{
//document.getElementById('div1').style.display="none";
document.getElementById('divgrid1').style.display="block";


}

function checkvisiblecla()
{
//document.getElementById('divgrid1').style.display="none";
document.getElementById('div1').style.display="block";


}

function  checkvisibleold()
{/*
if(document.getElementById('drpbillstatus').value=='3')
{
document.getElementById('btngenrate').disabled=false;
}
else
{
document.getElementById("btnprv").disabled=false;
document.getElementById("btnprint").disabled=false;
}





var checkst=1;


  var str1="DataGrid1_ctl02_Checkbox1";
  
//  if(document.getElementById("DataGrid2")!=null)
//{
//}
              if (document.getElementById("billgen").checked ==true && document.getElementById("drpbillstatus").value=="2" )
                {
                

                if(document.getElementById("DataGrid1")!=null)
                {
                
                for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				document.getElementById(str1). disabled=true;
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
                document.getElementById('btnnext').disabled= true;
                
                }
                    
                }
                
                ////////////////ALL///////////////////////
                else
                if (document.getElementById("billgen").checked ==true&&document.getElementById("drpbillstatus").value=="1")
                {
                
                if(document.getElementById("DataGrid1")!=null)
                {
                for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				if(document.getElementById("DataGrid1").rows[j].cells[9].innerHTML=="billed")
				
				{
				document.getElementById(str1). disabled=true;
				}
				else
				
				{
				checkst=2;
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
                
                if(checkst==2)
                {
                document.getElementById('btnnext').disabled= false;
                
                }
                else
                
                {
                document.getElementById('btnnext').disabled= true;
                }
                
                
                }
                    
                }
                
                ///all with preview
                
                 else
                if ((document.getElementById("billprev").checked ==true&&document.getElementById("drpbillstatus").value=="1")||(document.getElementById("billreprint").checked ==true&&document.getElementById("drpbillstatus").value=="1"))
                {
                
                if(document.getElementById("DataGrid1")!=null)
                {
                
                for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				if((document.getElementById("DataGrid1").rows[j].cells[9].innerHTML=="publish")||(document.getElementById("DataGrid1").rows[j].cells[9].innerHTML=="audit by rate"))
				
				{
				document.getElementById(str1). disabled=true;
				}
				else
				
				{
				checkst=2;
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
                
                if(checkst==2)
                {
                document.getElementById('btnnext').disabled= false;
                
                }
                else
                
                {
                document.getElementById('btnnext').disabled= true;
                }
                
                }
                
                    
                }
                
                
                /////////
                
                 else
                if ((document.getElementById("billprev").checked ==true&&document.getElementById("drpbillstatus").value=="3")||(document.getElementById("billreprint").checked ==true&&document.getElementById("drpbillstatus").value=="3"))
                {
                
                if(document.getElementById("DataGrid1")!=null)
                {
                for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				if((document.getElementById("DataGrid1").rows[j].cells[9].innerHTML=="publish")||(document.getElementById("DataGrid1").rows[j].cells[9].innerHTML=="audit by rate"))				
				{
				document.getElementById(str1). disabled=true;
				}
				else
				
				{
				checkst=2;
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
                
                
                
                
                if(checkst==2)
                {
                document.getElementById('btnnext').disabled= false;
                
                }
                
                
                
                else
                
                {
                document.getElementById('btnnext').disabled= true;
                }
                
                
                }
                    
                }
                
                
                
                
                
                
                
                
                
                
                
 */               
}




  /*function SelectHi(grdid,obj,objlist)
			{ 		
			
			 onclick="SelectHi('DataGrid1',this,'Checkbox1');"
				
				
				var j1;
				var j;
				var str1="DataGrid1_ctl02_Checkbox1";
				for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				   // document.getElementById("DataGrid1").rows[j].cells[7].childNodes[0].checked=true;
				if(objlist=="Checkbox1")
				{		 
				
				
			document.getElementById(str1).checked=false;
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
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				
				
				
				}
				return false;
			
				
			}  */
			
			
			
			
			
			



function  checkboxidnew()
{

var checkradio="";


//if(document.getElementById("billgen").checked ==true &&  document.getElementById("DataGrid1").rows[j].cells[0].innerHTML==)

if (document.getElementById("billprev").checked == true)
            {
                checkradio="1";
            }
            else
                if (document.getElementById("billgen").checked ==true)
                {
                    checkradio="2";
                }
                 else
                    if (document.getElementById("billreprint").checked ==true)
                    {
                        checkradio ="3";
                    }
                else
                {
                    checkradio ="4";
                }

//var checkradio=document.getElementById("hiddenradio").value;
if(checkradio=="4")
{
alert('please select altest once Billing type');
return false;
}
var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
agencycode="";


				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				
				
				if(agencycode=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[7].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[7].innerHTML;
				
			}
				
				
				
				
			// ciobookid= ciobookid+","+	document.getElementById("DataGrid1").rows[j].cells[0].innerHTML;
			//var insertion= 	document.getElementById("DataGrid1").rows[j].cells[2].innerHTML;
			//var edition=  document.getElementById("DataGrid1").rows[j].cells[3].innerHTML;
			j1=2;
			//bookaudit.updatestatus(ciobookid,insertion,edition);
			
			
				}
					 
				
				
			
				var  str2=str1.split('_')[1]
				
				
				var str3=str2.split('l')[1]
				var str4=str2.split('l')[0]
				str3=str3
				str3=Number(str3)+1;
				if(str3>=10)
				{
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 window.open(myurl+'invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt);
				  
				   
				 
				 
				 

				 
				
				


}



/////


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
        var response=revised_bill.bindbillcycl();
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
        var response=revised_bill.bindbillcycl();
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
function  blankgrid1()
{
document.getElementById('hiddenbillcycle').value=document.getElementById('dpbill').value;
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

bindadcat1();
bindpackage();


}

///////////


function SelectHi(grdid,obj,objlist)
			{ 		
			
			
				if(document.getElementById("DataGrid1_ctl01_Checkbox4").checked==true)
				{ 
				var j1;
				var j;
				var str1="DataGrid1_ctl02_Checkbox1";
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
				str1="DataGrid1_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				//return false;
				
				
				}
				//return false;
				}
				else
				{ 
				var j1;
				var j;
				var str1="DataGrid1_ctl02_Checkbox1";
				for(j=1;j<document.getElementById("DataGrid1").rows.length;j++)
				
				{
				
				
				   // document.getElementById("DataGrid1").rows[j].cells[7].childNodes[0].checked=true;
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
				str1="DataGrid1_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid1_ctl0"+str3+"_Checkbox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				
				
				
				}
				return false;
				}
				
			}   
			
			
			
			
			
			/////for classified
			
			
			
			function SelectHiclass(grdid,obj,objlist)
			{ 		
			
			
				if(document.getElementById("DataGrid2_ctl01_Checkbox4").checked==true)
				{ 
				var j1;
				var j;
				var str1="DataGrid2_ctl02_Checkbox1";
				for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)
				
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
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				//return false;
				
				
				}
				//return false;
				}
				else
				{ 
				var j1;
				var j;
				var str1="DataGrid2_ctl02_Checkbox1";
				for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)
				
				{
				
				
				   // document.getElementById("DataGrid1").rows[j].cells[7].childNodes[0].checked=true;
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
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 
				
				//document.getElementById(str1).checked=true;
				
				}
				
				
				
				
				
				
				
				}
				return false;
				}
				
			}   
			
			
			
			
			
			
			





	function checklenthbillcla()
{

//document.getElementById('div1').style.display="none";


alert('Seaching criteria does not produce any result');

return false;



}



//////////////////new
	
	function  checkboxidbillgen()
{

var checkradio="2";


/////////////////////


var hiddenbillstatus="";
if(document.getElementById('dpdadtype').value=='CL0')
{
hiddenbillstatus=document.getElementById('hiddenclsbill').value;

}
if(document.getElementById('dpdadtype').value=='DI0')
{
hiddenbillstatus=document.getElementById('hiddendisplaybill').value;


}



//////////

if(hiddenbillstatus=='insertionwise')
{

var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
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
				 
				 
				 //window.open('invoice_package.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
//				 if(checkradio==3)
//				 {
//				 
//				 window.open('testnew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
//				 }
//				 else
//				 {
var bill="Bill"
window.open(myurl+'invoice_package.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition+'&bill='+bill);

//				 }
				  
				   
		}
		
		//////////////////////////////////////////////////////////////////////////////////////
		else
		if(hiddenbillstatus=='orderwisefirstins')
		
		{
		
		
		checkradio="firstsave";
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";


				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				
				
				if(ciobookid=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
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
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				var bill="Bill"
				 
				 window.open(myurl+'invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&bill='+bill);				  
				
				
		}
		
		/////////////////
		else
		if(document.getElementById("hiddenbillstatus").value=='monthly')
		{
		
		
		checkradio="2";
			
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";


				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				
				
				if(agencycode=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
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
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				var bill="Bill"
				 
				 window.open(myurl+'invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&bill='+bill);				  
				
		}
		
		////////////////////////
		
		
			else
		if(hiddenbillstatus=='orderwiselastins')
		{
		
		checkradio="2";
		var edition;
		////////
				
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";



				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				  var  adtype=document.getElementById('dpdadtype').value;
				  
				
				
				if(ciobookid=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
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
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 var bill="Bill"
				 window.open(myurl+'invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&adtype='+adtype+'&bill='+bill);
				  
				   
				 
				 
				 
		
		///////
		
		
		
		
		} 
		
		////////
				 
	

}
///////////bill print

	function  checkboxidbillpreview()
{



var checkradio="1";

var hiddenbillstatus="";
if(document.getElementById('hiddenadtype').value=='CL0')
{
hiddenbillstatus=document.getElementById('hiddenclsbill').value;

}
if(document.getElementById('hiddenadtype').value=='DI0')
{
hiddenbillstatus=document.getElementById('hiddendisplaybill').value;


}



////////////////////////////

//if(document.getElementById("hiddencheck").value!='CL0')
if(hiddenbillstatus=='insertionwise')
{

var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
				var j;
				
				
				var str1="DataGrid1_ctl02_Checkbox1";
				if(document.getElementById("DataGrid1")==null)
				{
				alert('please check atleast one id from grid' );
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
				 
				 
				 //window.open('invoice_package.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
//				 if(checkradio==3)
//				 {
//				 
//				 window.open('testnew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
//				 }
//				 else
//				 {
window.open(myurl+'invoice_package.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);

//				 }
				  
				   
		}
		////////////////////////////////
		else
		if(hiddenbillstatus=='orderwisefirstins')
		
		{
		
		
		checkradio= "first";
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";


				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				
				
				if(ciobookid=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
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
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 window.open(myurl+'invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client);
				  
				   
				 
				 
				 

				 
				
				
		}
				 
		/////////////////////////////		
		else
		if(hiddenbillstatus=='monthly')
		{
		
		checkradio="4";
		
		////////
				
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";



				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				  var  adtype=document.getElementById('dpdadtype').value;
				  
				
				
				if(agencycode=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
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
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 window.open(myurl+'invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&adtype='+adtype);
				  
				   
				 
				 
				 
		
		///////
		
		
		
		
		} 
		
		/////////////////////////////
		
			else
		if(hiddenbillstatus=='orderwiselastins')
		{
		
		checkradio="1";
		var edition;
		////////
				
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";



				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				  var  adtype=document.getElementById('dpdadtype').value;
				  
				
				
				if(ciobookid=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
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
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 window.open(myurl+'invoice_classified.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&adtype='+adtype);
				  
				   
				 
				 
				 
		
		///////
		
		
		
		
		} 
		
		
		
		
		
		///
				 

				 
				
				


}

///////////billreprint

	function  checkboxidbillreprint()
{

var checkradio="3";


/////////////

var hiddenbillstatus="";
if(document.getElementById('dpdadtype').value=='CL0')
{
hiddenbillstatus=document.getElementById('hiddenclsbill').value;

}
if(document.getElementById('dpdadtype').value=='DI0')
{
hiddenbillstatus=document.getElementById('hiddendisplaybill').value;


}

//////////////////////////////////////////////////////////////////////////////////////////////////////////


if(hiddenbillstatus=='insertionwise')
{

var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
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
				 
				 

				 window.open(myurl+'testnewsambad.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);


//				 }
				  
				   
		}
		
		///////////////////////////////////////////////////////////////////
		else
		if(hiddenbillstatus=='orderwisefirstins')
		
		{
		
		checkradio="first";
		
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";


				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				
				
				if(agencycode=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
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
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 window.open(myurl+'classifiednew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client);
				  
				   
				 
				 
				 

				 
				
				
		}
		///////////////////////////////////////////////////////////////////
		
		
		
			else
		if(hiddenbillstatus=='orderwiselastins')
		{
		
		checkradio="4";
		var edition;
		////////
				
		var j1=1;
var i;
var ciobookid="";
var insertion="";
var edition="";
var frmdt="";
var dateto="";
var client="";
agencycode="";



				var j;
				
				
				var str1="DataGrid2_ctl02_Checkbox1";
				if(document.getElementById("DataGrid2")==null)
				{
				alert('please check atleast  id from grid' );
				return false;
				}


else
{
                 for(j=1;j<document.getElementById("DataGrid2").rows.length;j++)				
				 {                  
				 
				
				
				if(document.getElementById(str1).checked==true)
				{
				  
				  frmdt  =document.getElementById('hiddenfromdate').value;
				  dateto  =document.getElementById('hiddendateto').value;
				  client=document.getElementById('hiddenclient').value;
				  var  adtype=document.getElementById('dpdadtype').value;
				  
				
				
				if(ciobookid=="")
				{
				agencycode=document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
				}
				else
				{
				agencycode= agencycode+","+	document.getElementById("DataGrid2").rows[j].cells[10].innerHTML;
				ciobookid=ciobookid+","+document.getElementById("DataGrid2").rows[j].cells[0].innerHTML;
				
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
				str1="DataGrid2_ctl"+str3+"_Checkbox1";
				}
				else
				{
				 str1="DataGrid2_ctl0"+str3+"_Checkbox1";
				 } 				                 
				
				 }
				 
				  if(j1==1)
				 {
				 alert('Please Select atlest one CheckBox for bill');
				 return false;
				 }
				 
				 
				 }
				 
				 ////////////
				// window.open('invoice_grid.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);
				 
				 window.open(myurl+'classifiednew.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&agencycode='+agencycode+'&dateto='+dateto+'&frmdt='+frmdt+'&client='+client+'&adtype='+adtype);
				  
				   
				 
				 
				 
		
		///////
		
		
		
		
		} 
		
		
		//////////////
				 
				 
				 

				 
				
				


}




function bindadcat1()
{
var compcode=document.getElementById('hiddencompcode').value;
var adtype1=document.getElementById('dpdadtype').value;
revised_bill.adcatbnd(adtype1,compcode,call_adcatbind1);
//billwisexls.adcatbnd(adtype1,compcode,call_adcatbind);
}
function call_adcatbind1(response)
{
ds= response.value;
    var brand=document.getElementById('dpadcatgory');
    brand.options.length=0;
    brand.options[0]=new Option("--Select Ad Cat--");
    document.getElementById("dpadcatgory").options.length = 1;
   

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 brand.options[brand.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);
                brand.options.length;   
             }
 }        
 
       return false;
}
///////////////
function bindpackage()
{
var compcode=document.getElementById('hiddencompcode').value;
var adtype1=document.getElementById('dpdadtype').value;
revised_bill.bindpackagenew(adtype1,compcode,call_bindpackage);
//billwisexls.adcatbnd(adtype1,compcode,call_adcatbind);
}
function call_bindpackage(response)
{
ds= response.value;
    var brand=document.getElementById('drppackage');
    brand.options.length=0;
    brand.options[0]=new Option("--Select Package--");
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
















/////////////


function bind_taluka()
{
var compcode=document.getElementById('hiddencompcode').value;
var district=document.getElementById('dpdistrict').value;
revised_bill.bindtaluka(compcode,district,call_bind_taluka);

}

function call_bind_taluka(response)
{

ds= response.value;
    var city=document.getElementById('dptaluka');
    city.options.length=0;
    city.options[0]=new Option("Select Taluka");
    document.getElementById("dptaluka").options.length = 1;
   

if(ds.Tables[0].Rows.length>0)
{
             for(var i=0; i<ds.Tables[0].Rows.length; i++)
             {
                 city.options[city.options.length] = new Option(ds.Tables[0].Rows[i].taluname,ds.Tables[0].Rows[i].talucode);
                city.options.length;   
             }
 }        
 
       return false;
}





///////////////
function fetch_categary()
{
 document.getElementById("hiddencategory").value=document.getElementById("dpadcatgory").value;
}



function fetch_PACKAGE()
{
 document.getElementById("hiddenPACKAGE").value=document.getElementById("drppackage").value;
}


////////////////

function fillmaingrp(mycityval)
{
   


    if(document.activeElement.id=="lstretainer")
        {
            if(document.getElementById('lstretainer').value=="0")
            {
            alert("Please select Retainer Name");
            return false;
            }
                   
            var page=document.getElementById('lstretainer').value;
            agencycodeglo=page;
            if(browser!="Microsoft Internet Explorer")
            {
                for(var k=0;k <= document.getElementById("lstretainer").length-1;k++)
                {
                    var abc=document.getElementById('lstretainer').options[k].innerHTML;
                    if(document.getElementById('lstretainer').options[k].value==page)
                    {
                    document.getElementById('lstretainer').value=abc;
                    break;
                    }
                }
            }
            else
            {
                for(var k=0;k <= document.getElementById("lstretainer").length-1;k++)
                {

                //var abc=doĂument.getElementById('lstretainer').options[k].innerText;
                    if(document.getElementById('lstretainer').options[k].value==page)
                    {
                    var abc=document.getElementById('lstretainer').options[k].innerText;
                    var allvalues=document.getElementById('lstretainer').options[k].value;
                  //  
//                     stateval  = fival[2];
//                     countryval = fival[3];
//                        
//                    cityname  =  fndnull(fival[4]);
//                    distname  =  fndnull(fival[5]);
//                    statename  = fndnull(fival[6]);
//                    countryname = fndnull(fival[7]);
                        
                        
                        
                       
                        
                    document.getElementById('dpretainer').value=abc;
                    
                    
                    var splitvalue= abc;
                  var fival = abc.split("(");
                    cityval  =  fival[0];
                   distval  =  fival[1];
                   
                  var getvalue=distval.substring(0,distval.length-1)
                   
                   
                 document.getElementById('hiddenretainer').value=getvalue;
                     
                 //   savemaingrcode = allvalues;
                  //  savemaingrname = fival[0]; 
                    
                    
                    
//                    document.getElementById('ddstats').value=statename;
//                    document.getElementById('ddcountry').value=countryname;
                   
                //    var splitpub = abc;                   
                //    document.getElementById('txtmaingrcode').value=splitpub;
                   
                    //document.getElementById('txtpublicationname').value=pubspace;
           
                    }
                }
            }
            document.getElementById("div5").style.display='none';
         //   document.getElementById("txtP_Subgrpdes").focus();
            return false;
            }
     

    
}



function fillexecutivegrp(mycityval)
{
   


    if(document.activeElement.id=="lstexecutive")
        {
            if(document.getElementById('lstexecutive').value=="0")
            {
            alert("Please select Executive Name");
            return false;
            }
                   
            var page=document.getElementById('lstexecutive').value;
            agencycodeglo=page;
            if(browser!="Microsoft Internet Explorer")
            {
                for(var k=0;k <= document.getElementById("lstexecutive").length-1;k++)
                {
                    var abc=document.getElementById('lstexecutive').options[k].innerHTML;
                    if(document.getElementById('lstexecutive').options[k].value==page)
                    {
                    document.getElementById('lstexecutive').value=abc;
                    break;
                    }
                }
            }
            else
            {
                for(var k=0;k <= document.getElementById("lstexecutive").length-1;k++)
                {

          
                    if(document.getElementById('lstexecutive').options[k].value==page)
                    {
                    var abc=document.getElementById('lstexecutive').options[k].innerText;
                    var allvalues=document.getElementById('lstexecutive').options[k].value;

                        
                        
                        
                       
                        
                    document.getElementById('dpexecutive').value=abc;
                   var splitvalue= abc;
                  var fival = abc.split("(");
                    cityval  =  fival[0];
                   distval  =  fival[1];
                   
                   
                   
                  var getvalue=distval.substring(0,distval.length-1)                 
                   
                 document.getElementById('hdnexecutivetxt').value=getvalue;
                
                    

           
                    }
                }
            }
            document.getElementById("div4").style.display='none';
         //   document.getElementById("txtP_Subgrpdes").focus();
            return false;
            }
     

    
}


function call_xml()
{
 aTag = eval( document.getElementById("tddiv"))
				var btag;
				var leftpos=0;
				var toppos=0;   
				var   toppos1=0;   
				do {
					aTag = eval(aTag.offsetParent);
					leftpos	+= aTag.offsetLeft;
					toppos += aTag.offsetTop;
					btag=eval(aTag)
				} while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
			// var tot=document.getElementById('bookdiv').scrollLeft;
		  //  var scrolltop=document.getElementById('bookdiv').scrollTop;
			 	
			 	toppos1=toppos-10;
             document.getElementById("divnew").style.left=document.getElementById("tddiv").offsetLeft	+ leftpos+"px";
             document.getElementById("divnew").style.top= document.getElementById("tddiv").offsetTop + toppos1 + "px";//"510px";
             
             
              document.getElementById("divmonth").style.left=document.getElementById("tddiv").offsetLeft	+ leftpos+"px";
             document.getElementById("divmonth").style.top= document.getElementById("tddiv").offsetTop + toppos + "px";//"510px";


document.getElementById("dpdadtype").focus();
}



// add for monthly weekly billing 8/3/2011
function disablefrdt_todt(id)
{
    if (document.getElementById(id).value!="0")
    {
        document.getElementById('txtfrmdate').disabled=true;
        document.getElementById('txttodate1').disabled=true
        document.getElementById('Text_fromdate').disabled=false;
        document.getElementById('text_todate').disabled=false
        document.getElementById('txtfrmdate').value="";
        document.getElementById('txttodate1').value=""
        
//        document.getElementById('hiddenclsbill').value="monthly";
//        document.getElementById('hiddendisplaybill').value="monthly"
        blankgrid1();
    }
    else
    {
        document.getElementById('txtfrmdate').disabled=false;
        document.getElementById('txttodate1').disabled=false
        document.getElementById('Text_fromdate').disabled=true;
        document.getElementById('text_todate').disabled=true
        document.getElementById('Text_fromdate').value="";
        document.getElementById('text_todate').value=""
        
        document.getElementById('hiddenclsbill').value="monthly";
        document.getElementById('hiddendisplaybill').value="insertionwise"
         blankgrid();
    }
}

function valuecopy(id)
{
        if(document.getElementById(id).value!="")
        {
                if(id=="Text_fromdate")
                {
                    document.getElementById('txtfrmdate').value=document.getElementById('Text_fromdate').value
                }
                else if(id=="text_todate")
                {
                    document.getElementById('txttodate1').value=document.getElementById('text_todate').value
                }
                else
                {
                       if(document.getElementById('dpdadtype')=="CL0")
                       {
                            document.getElementById('hiddenclsbill').value="monthly";
                            document.getElementById('txttodate1').disabled=true;
                            document.getElementById('txttodate1').value=document.getElementById('txtfrmdate').value

                        }
                        else
                        if((document.getElementById('dpdadtype')=="DI0") && (document.getElementById('hiddendisplaybill').value=="daily"))
                        {            
                        document.getElementById('hiddendisplaybill').value="monthly";
                        
                        }
                }
        }
}

function days_between(date1, date2,dateformat) 
{
    if(dateformat=="mm/dd/yyyy")
    {
        var strfromdate=date1.split('/');
        var strdateto=date2.split('/');        
    }
    else
    if(dateformat=="dd/mm/yyyy")
    {
        var strfromdate=date1.split('/');
        var strdateto=date2.split('/');
        date1=strfromdate[1]+"/"+strfromdate[0]+"/"+strfromdate[2]
        date2=strdateto[1]+"/"+strdateto[0]+"/"+strdateto[2]
    }
    else 
    {
        var strfromdate=date1.split('/');
        var strdateto=date2.split('/');
        date1=strfromdate[1]+"/"+strfromdate[2]+"/"+strfromdate[0]
        date2=strdateto[1]+"/"+strdateto[2]+"/"+strdateto[0]
    }
    // The number of milliseconds in one day
    var ONE_DAY = 1000 * 60 * 60 * 24
    // Convert both dates to milliseconds
    var dt1=new Date(date1)
    var dt2= new Date(date2)
    var date1_ms = dt1.getTime()
    var date2_ms = dt2.getTime()
    // Calculate the difference in milliseconds
    var difference_ms = Math.abs(date1_ms - date2_ms)
    // Convert back to days and return
    return Math.round(difference_ms/ONE_DAY)
}

// end for monthly weekly billing 8/3/2011

