﻿// JScript File

// JScript File
var show="0";
var z=0;
var hiddentext;
// this variable is used foe storing value of autogenerated for session
var auto="";
var retdatafords;

function exitclick()
{
    if(confirm("Do You Want To Skip This Page"))
    {
    
	/*	if(popUpWin && !popUpWin.closed)
		{
		  popUpWin.close();
		}
		if(popUpWin1 && !popUpWin1.closed)
		{
		   popUpWin1.close();
		}
		
		if(popUpWin2 && !popUpWin2.closed)
		{
		   popUpWin2.close();
		}
		if(popUpWin3 && !popUpWin3.closed)
		{
		   popUpWin3.close();
		}
		if(popUpWin4 && !popUpWin4.closed)
		{
		   popUpWin4.close();
		}
		if(popUpWinbank && !popUpWinbank.closed)
		{
		   popUpWinbank.close();
		}*/

    //window.location.href='EnterPage.aspx';
        window.close();

       return false;
    }
    return false;
}


function queryclick()
{
    show="0";
    
   // if(document.getElementById('hiddenpermission').value=="zero")
   // {
  //  alert("You Are Noe Authorised To See This Form");
  //  return false;
  //  }

    hiddentext="query";
    z=0;
    
    document.getElementById('hiddenstatuslabel').value="show";
            document.getElementById('ddlPublication').disabled=false;
            document.getElementById('ddlCenter').disabled=false;
            document.getElementById('ddlEdition').disabled=false;
            document.getElementById('ddlSupplement').disabled=false;
    
            document.getElementById('ddlPublication').value="0";
			
			document.getElementById('ddlCenter').value="0";
			
			document.getElementById('ddlEdition').value="0";			
			
	        document.getElementById('ddlSupplement').value="0";				
			
			document.getElementById('drlpage').value="";			
			
			document.getElementById('btnQuery').disabled=true;						
			
			document.getElementById('btnExit').disabled=false;
			
			return false;
}


   


    function passAdvolume()
    {
        var compcode=document.getElementById('hiddencompcode').value;
        var userid=document.getElementById('hiddenuserid').value;
        var pubdate=document.getElementById('PubDate').value;
        var pubcode=document.getElementById('ddlPublication').value;
        var centercode=document.getElementById('ddlCenter').value;
        var editioncode=document.getElementById('ddlEdition').value;
        var suppcode=document.getElementById('ddlSupplement').value;        
        IssuePages.bkvolume(compcode,pubdate,pubcode,centercode,editioncode,suppcode,fillAdVolume); 
        IssuePages.bkIssuePages(compcode,pubcode,centercode,editioncode,suppcode,fillPages);       
        return false; 
    }
    
    function fillAdVolume(response)
    {
        var retdatafords=response.value;
        if(retdatafords==null)
            return 0;
        if(retdatafords.Tables[2].Rows.length ==0)
        {
            alert("No Booking...");
            cancelclick();
            return false;
        }
        if(retdatafords.Tables[0].Rows.length !=0)
            document.getElementById('txtColorAdVolume').value=retdatafords.Tables[0].Rows[0].ColorAdVolume;
        else
            document.getElementById('txtColorAdVolume').value=0;
            
        if(retdatafords.Tables[1].Rows.length !=0)    
            document.getElementById('txtBWAdVolume').value=retdatafords.Tables[1].Rows[0].BWAdVolume;
        else
            document.getElementById('txtBWAdVolume').value=0;
        
        document.getElementById('txtAdVolume').value=retdatafords.Tables[2].Rows[0].tAdVolume;
        return false;
    }
    
    function fillPages(response)
    {
        
        retdatafords=response.value;
        if(retdatafords.Tables[0].Rows.length ==0)
        {
            alert("Issue pages is not configured.");
            //cancelclick();
            return false;
        }
        if(retdatafords.Tables[0].Rows.length !=0)
        {
            var selectdrlPage=document.getElementById('drlPage');
            selectdrlPage.options[0]=null;
            for(var i=0;i<retdatafords.Tables[0].Rows.length;i++)
            {
                selectdrlPage.options[selectdrlPage.options.length]=new Option(retdatafords.Tables[0].Rows[i].no_of_pages,i);
                selectdrlPage.options[i].value=retdatafords.Tables[0].Rows[i].no_of_pages;
////                if(document.getElementByid('txtAdVolume').value<retdatafords.Tables[0].Rows[i].booked_volume)
////                    selectdrlPage.options[i].value=retdatafords.Tables[0].Rows[i].no_of_pages;
            }
            
                
        }
        
    }
    
 
 //Click Issue Volume   
function Issuevolumeclick()
{
    if(document.getElementById('PubDate').value=="")
     {
        alert("Please Select Date: ");
        document.getElementById('PubDate').focus();
        return false;
     }
    if(document.getElementById('ddlPublication').value=="0")
      {
         alert("Please Select Publication ");
         if(document.getElementById('ddlPublication').disabled==false)
            document.getElementById('ddlPublication').focus();
         return false;
      }
      if(document.getElementById('ddlCenter').value=="0")
      {
         alert("Please Select Center ");
         if(document.getElementById('ddlCenter').disabled==false)
            document.getElementById('ddlCenter').focus();
         return false;
      }
      if(document.getElementById('ddlEdition').value=="0")
      {
         alert("Please Select Edition ");
         if(document.getElementById('ddlEdition').disabled==false)
            document.getElementById('ddlEdition').focus();
         return false;
      }
      if(document.getElementById('ddlSupplement').value=="0")
      {
         alert("Please Select Supplement ");
         if(document.getElementById('ddlSupplement').disabled==false)
            document.getElementById('ddlSupplement').focus();
         return false;
      }
      
////        var ddlpubdate=document.getElementById('PubDate').value;       
////        var ddlpubcode=document.getElementById('ddlPublication').value;
////	    var ddlcentercode=document.getElementById('ddlCenter').value;
////		var ddleditioncode=document.getElementById('ddlEdition').value;
////		var ddlsuppcode=document.getElementById('ddlSupplement').value;
		
		if(hiddentext=="query")
		{
		    passAdvolume();
		}
		return false;
}

function IssuePagesSubmitclick()
{
    if(document.getElementById('PubDate').value=="0")
     {
        alert("Please Select Date: ");
        document.getElementById('PubDate').focus();
        return false;
     }
    if(document.getElementById('ddlPublication').value=="0")
      {
         alert("Please Select Publication ");
         if(document.getElementById('ddlPublication').disabled==false)
            document.getElementById('ddlPublication').focus();
         return false;
      }
      if(document.getElementById('ddlCenter').value=="0")
      {
         alert("Please Select Center ");
         if(document.getElementById('ddlCenter').disabled==false)
            document.getElementById('ddlCenter').focus();
         return false;
      }
      if(document.getElementById('ddlEdition').value=="0")
      {
         alert("Please Select Edition ");
         if(document.getElementById('ddlEdition').disabled==false)
            document.getElementById('ddlEdition').focus();
         return false;
      }
      if(document.getElementById('ddlSupplement').value=="0")
      {
         alert("Please Select Supplement ");
         if(document.getElementById('ddlSupplement').disabled==false)
            document.getElementById('ddlSupplement').focus();
         return false;
      }
      if(document.getElementById('drlPage').value=="0")
      {
         alert("Please Select Pages ");
         if(document.getElementById('drlPage').disabled==false)
            document.getElementById('drlPage').focus();
         return false;
      }
      
////        var ddlpubdate=document.getElementById('PubDate').value;       
////        var ddlpubcode=document.getElementById('ddlPublication').value;
////	    var ddlcentercode=document.getElementById('ddlCenter').value;
////		var ddleditioncode=document.getElementById('ddlEdition').value;
////		var ddlsuppcode=document.getElementById('ddlSupplement').value;
////		var drlIssuePages=document.getElementById('drlPages').value;
////		
		if(hiddentext=="query")
		{
		    passIssuePages();
		}
		return false;
    
}

function passIssuePages()
{
    var compcode=document.getElementById('hiddencompcode').value;
    var userid=document.getElementById('hiddenuserid').value;
    var pubdate=document.getElementById('PubDate').value;       
    var pubcode=document.getElementById('ddlPublication').value;
	var centercode=document.getElementById('ddlCenter').value;
	var editioncode=document.getElementById('ddlEdition').value;
	var suppcode=document.getElementById('ddlSupplement').value;
	var drlIssuePages=document.getElementById('drlPage').value;
	IssuePages.configIssuePages(compcode,userid,pubdate,pubcode,centercode,editioncode,suppcode,drlIssuePages,cconfigpages); 
	return false;
		
}

function cconfigpages()
{
     alert('Edition Pages configure successfully');
     return false;   
}