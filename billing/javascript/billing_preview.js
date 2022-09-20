


var browser=navigator.appName;
var test="1";
var myurl=document.URLUnencoded.split("/");
	            myurl=myurl[0]+"/"+myurl[1]+"/"+myurl[2]+"/"+myurl[3]+"/"+"billing"+"/"
	          


function  billpreview()
{



var checkradio="1";


var cio= document.getElementById('txtbookingid').value;
				 
window.open(myurl+'bill_preview_print.aspx?ciobookid='+cio);
			 

//window.open(myurl+'bill_preview_print.aspx.aspx?ciobookid='+ciobookid+'&checkradio='+checkradio+'&insertion='+insertion+'&edition='+edition);


				  
				   
		
		
		}


