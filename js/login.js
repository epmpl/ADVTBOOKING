// JScript File
function bindUser()
{
    login.fillUser(document.getElementById('drpqbc').value,bindUser_callback);
}
function bindUser_callback(response)
{
     var ds=response.value;
    agcatby = document.getElementById("drpusername");
 agcatby.options.length = 1; 
    agcatby.options[0]=new Option("--Select User Name--","0");
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);
    
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        agcatby.options[agcatby.options.length] = new Option(ds.Tables[0].Rows[i].username,ds.Tables[0].Rows[i].username);
        
       agcatby.options.length;
       
    }
    }
}
function bindQBC()
{
login.fillQBC(document.getElementById('drpcenter').value,bindQBC_callback);
}
function bindQBC_callback(response)
{
    //alert(response.value);
    var ds=response.value;
    agcatby = document.getElementById("drpqbc");
 agcatby.options.length = 1; 
    agcatby.options[0]=new Option("--Select QBC--","0");
if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
{


//alert(pkgitem);
    
    //alert(pkgitem.options.length);
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        agcatby.options[agcatby.options.length] = new Option(ds.Tables[0].Rows[i].retain_name,ds.Tables[0].Rows[i].retain_code);
        
       agcatby.options.length;
       
    }
    }
}

function login1()
{
//alert();
        if(document.getElementById('userid').value=="" && document.getElementById('txtpwd').value=="")
        {
            alert("Username and Password should not be blank" );
            document.getElementById('userid').focus();
            return false;
        }
        else if(document.getElementById('userid').value=="")
        {
            alert("Username field should not be blank" );
            document.getElementById('userid').focus();
            return false;
        }
        else if(document.getElementById('txtpwd').value=="")
        {
            alert("Password field should not be blank" );
            document.getElementById('txtpwd').focus();
            return false;
        }
        
        //else
       // {
        
            //var username=document.getElementById('userid').value;
            //var password=document.getElementById('txtpwd').value;
            //var qbc=document.getElementById('drpqbc').value;
            //var page;
            
            //var flag=
                
            
		 //           var xml = new ActiveXObject("Microsoft.XMLHTTP");
		   //         xml.Open( "GET","loginxml.aspx?username="+username+"&password="+password+"&qbc="+qbc, false );
		     ///       xml.Send();
		        //    var flag=xml.responseText;
		          //          if(flag=="0")
		            //        {
		              //      alert("Invalid User Name or Password" );
                        //    return false;
		                  //  }
		                    //else
		 //                   {
		   //                 window.location.href="Default.aspx";
		     //             //  window.location.href="newcomb.aspx";
		       //             }
    //}
    //return false;
}

//function keySort(dropdownlist,caseSensitive) {
  // check the keypressBuffer attribute is defined on the dropdownlist 
 // var undefined; 
 // if (dropdownlist.keypressBuffer == undefined) { 
 //   dropdownlist.keypressBuffer = ''; 
 // } 
  // get the key that was pressed 
 // var key = String.fromCharCode(window.event.keyCode); 
 // dropdownlist.keypressBuffer += key;
 // if (!caseSensitive) {
    // convert buffer to lowercase
  //  dropdownlist.keypressBuffer = dropdownlist.keypressBuffer.toLowerCase();
 // }
  // find if it is the start of any of the options 
 // var optionsLength = dropdownlist.options.length; 
 // for (var n=0; n<optionsLength; n++) { 
 //   var optionText = dropdownlist.options[n].text; 
 //   if (!caseSensitive) {
 //     optionText = optionText.toLowerCase();
 //   }
 //   if (optionText.indexOf(dropdownlist.keypressBuffer,0) == 0) { 
  //    dropdownlist.selectedIndex = n; 
  //    return false; // cancel the default behavior since 
                    // we have selected our own value 
  //  } 
 // } 
  // reset initial key to be inline with default behavior 
 // dropdownlist.keypressBuffer = key; 
 // return true; // give default behavior 
//} 