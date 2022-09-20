// JScript File
var browser = navigator.appName;
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



function F2fillagencycr(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 113)
{
    if(document.activeElement.id=="txt_agency")
        {       
         
            var compcode =document.getElementById('hiddencompcode').value;
            var agn =document.getElementById('txt_agency').value.toUpperCase();
            document.getElementById("div1").style.display="block";
            document.getElementById('div1').style.top=325+ "px" ;//314//290
            document.getElementById('div1').style.left=455+ "px";//395//1004
            document.getElementById('lstagency').focus();
            Offline_Mode_Report.fillF2_CreditAgency(compcode,agn,bindAgency_callback);
      }
 }

}

function bindAgency_callback(res)
{
     var ds_AccName=res.value;
       
        if(ds_AccName!= null && typeof(ds_AccName) == "object" && ds_AccName.Tables[0].Rows.length > 0) 
        {
            var pkgitem = document.getElementById("lstagency");
            pkgitem.options.length = 0; 
            pkgitem.options[0]=new Option("-Select Agency Name-","0");
            pkgitem.options.length = 1; 
            for (var i = 0  ;  i < ds_AccName.Tables[0].Rows.length;  ++i)
            {
                pkgitem.options[pkgitem.options.length] = new Option(ds_AccName.Tables[0].Rows[i].Agency_Name,ds_AccName.Tables[0].Rows[i].Agency_Code);         
                pkgitem.options.length;
            }
        }
        document.getElementById("lstagency").value="0";
        document.getElementById("div1").value="";
        document.getElementById('lstagency').focus();
   
        return false;

}


function ClickAgaency(event) {
    var key = event.keyCode ? event.keyCode : event.which;
    if (key == 13 || event.type == "click")
    {
        if(document.activeElement.id=="lstagency")
        {
        if(document.getElementById('lstagency').value=="0")
            {
                 alert("Please select Agency Name");
                 return false;
            }
            
            var page = document.getElementById('lstagency').value;
            agencycode = page;
            for(var k=0;k<=document.getElementById('lstagency').length-1;k++)
            {   
                if(document.getElementById('lstagency').options[k].value==page) {
                    if (browser != "Microsoft Internet Explorer") {
                        var abc = document.getElementById('lstagency').options[k].textContent;
                    }
                    else {
                        var abc = document.getElementById('lstagency').options[k].innerText;
                    }
                    document.getElementById('txt_agency').value = abc;
                    document.getElementById('hdnagencycode').value =page;
                    
                    document.getElementById("div1").style.display="none";
                    document.getElementById('txt_agency').focus();
                     return false; 
                    
                }
            }
        }
      }
      else if (key == 27)
         {
         
        document.getElementById("div1").style.display="none";
        document.getElementById('txt_agency').focus();
         }
  }
  
  
  

function excel_report1()
{
if(document.getElementById('dpd_destination').value=="4")
{
if(document.getElementById('fg').style.display = 'none')
{
document.getElementById('exe').disabled = false
document.getElementById('fg').style.display = 'block'
document.getElementById('csv').disabled = false
}

}
else

{
document.getElementById('exe').disabled = true
document.getElementById('csv').disabled = true
document.getElementById('fg').style.display = 'none'
}
return false;
}

function enable_exe1()
{
if(document.getElementById('exe').checked == false)
{
document.getElementById('exe').checked =true
}
if(document.getElementById('csv').checked == true)
{
document.getElementById('csv').checked =false
}
}

function enable_csv1()
{
if(document.getElementById('exe').checked == true)
{
document.getElementById('exe').checked =false
}
if(document.getElementById('csv').checked == false)
{
document.getElementById('csv').checked =true
}
}


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
//if(event.keyCode==113) 
//    event.keyCode= 81;
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



function open_file(file_name)
{


window.open('matterpreview.aspx?file_name='+file_name);
/*var winid="";
	    for ( var index = 0; index < 200; index++ ) 
               { 
               
              winid=window.open('matterpreview.aspx?file_name='+file_name,'Prachi','resizable=0,toolbar=0,top=140,left=210,width=425px,height=470px');
           
               winid.focus();
                 return false;
	           }
	           
	           
*/	           
//Offline_Mode_Report_View.open_file(file_name);
//return false;
}

function run_report()
{

// document.getElementById('txt_agency').value = abc;
//document.getElementById('hdnagencycode').value =page;

   
   if(document.getElementById('hdnagencycode').value== "" && document.getElementById('txt_agency').value != "")
        {
         alert('Please enter Agency by Pressing F2 Key');
        document.getElementById('txt_agency').focus();
        return false;

    }
        
    }

    function clearoffline() {
        document.getElementById('txt_agency').value = "";

        document.getElementById('txtfrmdate').value = "";
        document.getElementById('txttodate1').value = "";
        document.getElementById('dpd_status').value = "1";
        document.getElementById('dpd_destination').value = "0";
        document.getElementById('txtfrmdate').focus();
   

    }