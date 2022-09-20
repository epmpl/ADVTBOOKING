// JScript File
var modifybrand_code= "";
var modifyexec_code = "";
var modifyproduct_code = "";


var code10="";

//*********************submit client product****************************

function clientprodsave()
{

		    var	client_code=document.getElementById('hiddenclientcode').value;
            var client_name=document.getElementById('dclient').value;
            var brand_code=document.getElementById('drpbrand').value;
         	var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
		//	var execcode1 = document.getElementById('drpproductexec').value;
		    var exec_code = document.getElementById('drpexec').value;
		    var product_code = document.getElementById('drpproduct').value;
			clientbrandmast.saveclient(client_code,client_name,exec_code,compcode,userid,product_code ,brand_code);
			window.location=window.location;
			modifybrand_code= "";
            modifyexec_code = "";
            modifyproduct_code = "";
			return false;
			}

//**********************delete client product******************************
function deleteclientprod()
{

var	client_code=document.getElementById('hiddenclientcode').value;
var compcode=document.getElementById('hiddencompcode').value; 
var client_name=document.getElementById('dclient').value;
 var brand_name=document.getElementById('drpbrand').value;
           
var userid=document.getElementById('hiddenuserid').value; 
var datagrid=document.getElementById('DataGrid1');
//var exec_name = document.getElementById('drpproductexec').value; 

var j;
var k=0;
var i=document.getElementById("DataGrid1").rows.length -1;

   for(j=0;j<i;j++)
	{
	var str="DataGrid1__ctl_CheckBox1"+j;
	if(document.getElementById(str).checked==true)
	   {
	   k=k+1;
	    var code10=document.getElementById(str).value;
	
	   }
	}
	if(k==1)
	{
	    var gridrowlen=document.getElementById('DataGrid1').rows.length-1;
	    if(gridrowlen==1)
	    {
	        alert('One record should be present here');
	        return false;
	    }
	  clientbrandmast.deleteclient(client_code,client_name,brand_name,compcode,userid,code10);
	  window.location=window.location;
	  return false;
	}
	
	else
	{
	  alert("You Can Select One Row At A Time");
	  return false;
	}
	
	
	return false;

}




		

function uppercase1()
{
				document.getElementById('codetext').value=document.getElementById('codetext').value.toUpperCase();
return ;
}
		
function uppercase2()
{
				document.getElementById('prodtext').value=document.getElementById('prodtext').value.toUpperCase();
return ;
}
function charval()
{
			if((event.keyCode>=48 && event.keyCode<=57)||
			(event.keyCode==127)||(event.keyCode==37)||
			(event.keyCode>=97 && event.keyCode<=122)||
			(event.keyCode>=65 && event.keyCode<=90)||
			(event.keyCode==9))
			{
			return true;
			}
			else
			{
			return false;
			}
}

	

function charval1()
{
			if((event.keyCode>=97 && event.keyCode<=122)||(event.keyCode>=48 && event.keyCode<=57)||
			(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode==37)||(event.keyCode==32))
			{
			return true;
			}
			else
			{
			return false;
			}
}

function clearclick17()
{
            code10=""
            modifybrand_code= "";
            modifyexec_code = "";
            modifyproduct_code = "";
			document.getElementById('drpbrand').value="0";
			document.getElementById('drpproduct').value="0";
			document.getElementById('drpexec').value="0";
		//	document.getElementById('drpproductexec').value="0";
			
			if(document.getElementById('hiddenchk').value!="1")
			{
			var j;
			var k=0;
			//var DataGrid1__ctl_CheckBox1= new Array();
			var i=document.getElementById("DataGrid1").rows.length -1;

			for(j=0;j<i;j++)
				{
						var str="DataGrid1__ctl_CheckBox1"+j;         
						document.getElementById(str).checked=false;
				}
        }
        document.getElementById('btndelete').disabled=true;
        return false;
}
		
//****************************selected value***************************


function selected(ab)
{
var id=ab;
var client_code=document.getElementById('hiddenclientcode').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 
var datagrid=document.getElementById('DataGrid1');
			 if(document.getElementById(id).checked==false)
             {
            //flag="0";
            clearclick17();
            //document.getElementById(ab).checked=false;
            return;// false;
       
            }
var j;
var t=1;
var k=0;
var i=document.getElementById("DataGrid1").rows.length -1;

for(j=0;j<i;j++)
	{
	var str="DataGrid1__ctl_CheckBox1" + j;
		document.getElementById(str).checked=false;
                        document.getElementById(id).checked=true;
	if(document.getElementById(str).checked==true)
	{
	   k=k+1;
	   code10=document.getElementById(str).value;
	}
	}
	if(k==1)
	{
			if(document.getElementById('hiddenchk').value!="2")
                {
					document.getElementById('btndelete').disabled=false;
					}
					else
					{
					    document.getElementById('btndelete').disabled=true;
					}
	clientbrandmast.bandcontact12(client_code,compcode,userid,code10,call_select12);
	return;
	
	}
	else
	{
	alert("You Can Select One Row At A Time");
	return;
	}
	return false;
	

}
function call_select12(response)
{

var ds=response.value;
document.getElementById('dclient').value=ds.Tables[0].Rows[0].CLIENT_NAME;	
document.getElementById('drpproduct').value=ds.Tables[0].Rows[0].PRODUCT_CODE;
//document.getElementById('drpbrand').value=ds.Tables[0].Rows[0].BRAND_CODE;

brandvar= ds.Tables[0].Rows[0].BRAND_CODE;
brand_func(ds.Tables[0].Rows[0].PRODUCT_CODE)

//document.getElementById('drpproductexec').value=ds.Tables[0].Rows[0].exec_code;	
document.getElementById('drpexec').value=ds.Tables[0].Rows[0].EXEC_CODE;

            if(ds.Tables[0].Rows[0].BRAND_CODE != null)
            {
                 modifybrand_code= ds.Tables[0].Rows[0].BRAND_CODE;
            }
            if(ds.Tables[0].Rows[0].PRODUCT_CODE != null)
            {
                 modifyproduct_code = ds.Tables[0].Rows[0].PRODUCT_CODE;
            }
            if(ds.Tables[0].Rows[0].EXEC_CODE != null)
            {
                 modifyexec_code = ds.Tables[0].Rows[0].EXEC_CODE;
            }
return false;

}
///to chk whether product is upadted or inserted
function xyz()
{
           if(document.getElementById('drpbrand').value=="0")
			{
				alert("Please Select Brand");
				document.getElementById('drpbrand').focus();
				return false;
			}	
var client_code=document.getElementById('hiddenclientcode').value;
var brand_code=document.getElementById('drpbrand').value;
var product_code = document.getElementById('drpproduct').value;
var exec_code = document.getElementById('drpexec').value;
var compcode=document.getElementById('hiddencompcode').value; 
var userid=document.getElementById('hiddenuserid').value; 

//var modifychk11 = document.getElementById('hiddenchk').value; 

//var modifybrand_code= "";
//var modifyexec_code = "";
//var modifyproduct_code = "";

if((modifybrand_code == brand_code)&&(modifyexec_code == exec_code)&&(modifyproduct_code == product_code))
{
       clearclick17();
       return false;  
}

                if(document.getElementById('hiddenchk').value=="1")
                {
				//window.location=window.location;
				      if((modifybrand_code == brand_code)&&(modifyproduct_code == product_code))
                      {
                              if(code10=="")
                              {
                               clientprodsave();
                               return false;
                               }
                               else
                              {
                              document.getElementById('hiddenclientbrand').value=code10;
                              clientprodupdate();
                              return false;
                              }
                      }
                      else
                      {
				          clientbrandmast.chk(client_code,exec_code,compcode,userid,product_code,brand_code,call_xyz);
				      }	
				  //    return;
			    }
			    else
			    {
			          if((modifybrand_code == brand_code)&&(modifyproduct_code == product_code))
                      {
                              if(code10=="")
                              {
                               clientprodsave();
                               return false;
                               }
                               else
                              {
                              document.getElementById('hiddenclientbrand').value=code10;
                              clientprodupdate();
                              return false;
                              }
                      }
                      else
                      {
                           clientbrandmast.chk(client_code,exec_code,compcode,userid,product_code,brand_code,call_xyz);
                      }
                 }

return false;
}


function call_xyz(res)
{
var ds11 = "";

ds11=res.value;
if(ds11.Tables[0].Rows.length==0)
  {
      if(code10=="")
      {
       clientprodsave();
       return false;
       }
       else
      {
      document.getElementById('hiddenclientbrand').value=code10;
      clientprodupdate();
      return false;
      }
  }
 else
  {
  alert('This brand has been already alloted to client');
  }
  return false;
 }
   
  



function clientprodupdate()
{

			var client_prod_code=document.getElementById('hiddenclientbrand').value;
		    var	client_code=document.getElementById('hiddenclientcode').value;
            var client_name=document.getElementById('dclient').value;
            var brand_code=document.getElementById('drpbrand').value;
            var exec_code=document.getElementById('drpexec').value;
            var product_code=document.getElementById('drpproduct').value;
         	var compcode=document.getElementById('hiddencompcode').value;
			var userid=document.getElementById('hiddenuserid').value;
			//var exec_code=document.getElementById('drpproductexec').value;
			
			clientbrandmast.updateclient(client_code,client_name,brand_code,compcode,userid,client_prod_code,product_code,exec_code);
			window.location=window.location;
			modifybrand_code= "";
            modifyexec_code = "";
            modifyproduct_code = "";
			return false;
	}


function closewindow()
{
    window.close();
}


function tabvalue (id)
{



    if(event.keyCode==13)
    {
        if(document.activeElement.id==id)
        {
            if(document.getElementById('btnsubmit').disabled==false)
            {
                document.getElementById('btnsubmit').focus();
            }
            return;

        }
        else if(document.activeElement.type=="button" || document.activeElement.type=="submit")
        {
            event.keyCode=13;
            return event.keyCode;
        }
        else
        {
            //alert(event.keyCode);
            event.keyCode=9;
            //alert(event.keyCode);
            return event.keyCode;
        }
    }
}



/*************************************************************************************************************/


function BrandBind()
{
  var compcode =  document.getElementById('hiddencompcode').value;
  //var userid = document.getElementById('hiddenuserid').value;
  
  var productcode = document.getElementById('drpproduct').value;
   clientbrandmast.getbrand(compcode,productcode,callback_BrandBind);
}

function callback_BrandBind(response)
{
                          ds=response.value;
                          var pkgitem = document.getElementById("drpbrand");
                          pkgitem.options.length=0;
            pkgitem.options[0] = new Option("--Select Brand--","0");
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

var brandvar = "";
function brand_func(product1)
{
        if(typeof(product1)=="object")
        {
        var product=product1.value;
        }
        else
        {
        var product=product1;
        }
        //var country=document.getElementById('txtcountry').value;
        if(product!="0")
        {
        var compcode= document.getElementById('hiddencompcode').value;
        //var userid = document.getElementById('hiddenuserid').value;
        clientbrandmast.getbrand(compcode,product,call_brand1);
        }
        else
        {
        document.getElementById("drpbrand").options.length = 1;
        }
        return false;
         
}


function call_brand1(response)
{
        var ds=response.value;
        var pkgitem = document.getElementById("drpbrand");
        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
        {
//             if(document.getElementById('hiddenflag').value=="1")
//                {
//                document.getElementById('drpbrand').disabled=false;
//                }

        //alert(pkgitem);
            pkgitem.options.length = 1; 
            pkgitem.options[0]=new Option("--Select varient--","0");
            //alert(pkgitem.options.length);
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].brand_name,ds.Tables[0].Rows[i].brand_code);
                
               pkgitem.options.length;
               
            }
            //alert(cityvar);
         if(brandvar == undefined || brandvar=="")
         {
          document.getElementById('drpbrand').value="0";
         
         }
         else
         {
          document.getElementById('drpbrand').value=brandvar;
          brandvar="";
          } 
        }
        else
        {


        pkgitem.options[0]=new Option("--Select Brand--","0");

        if(document.getElementById('Drpbrand').disabled==false)
        {
//        alert("There is no matching value(s) found");
        }
        pkgitem.options.length=1;
        pkgitem.options[0]=new Option("--Select Brand--","0");
        //addregcity();
        document.getElementById('drpbrand').value="0";
        //document.getElementById('drpregion').value="0";
        //document.getElementById('drpzone').value="0";
        //document.getElementById('txtdistrict').value="";
        //document.getElementById('Statecode12').value="";
        //document.getElementById('txtstate').value="";
        return false;

        }

        return false;
}



