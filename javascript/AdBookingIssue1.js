
var adb;

var global_ds;
var z="0";
var modify="0";
//global varibles 
var globladpub;
var globladcenter;
var globladedition;
var globladsup;
var globadbook;
var globladpages;
//***************This function is used when New Button is clicked to enable all disable fields...***************//
function newadbooking()
{
    
       
        document.getElementById('drppublication').disabled=false;
        document.getElementById('drppubcenter').disabled=false;
        document.getElementById('drpedition').disabled=false;
        document.getElementById('drpsuplement').disabled=false;
        document.getElementById('txtbookvolume').disabled=false;
        document.getElementById('txtnopages').disabled=false;
        
       document.getElementById('drppublication').value="0";
       document.getElementById('drppubcenter').value="0";
       document.getElementById('drpedition').value="0";
       document.getElementById('drpsuplement').value="0";
       document.getElementById('txtbookvolume').value="";
       document.getElementById('txtnopages').value="";
      document.getElementById('hiddenid').value="";
       
        global_ds=null;		
 
       
       
		chkstatus(FlagStatus);
		hiddentext="new";	
		show="1";
		document.getElementById('btnSave').disabled = false;	
		document.getElementById('btnNew').disabled = true;	
		document.getElementById('btnQuery').disabled=true;
		
		
		
	   document.getElementById('drppublication').focus();
	   var compcode=document.getElementById('hiddencompcode').value;
	   
	   AdBookingIssue1. bindpublication(compcode,call_bind);
	   AdBookingIssue1.bindpubcenter(bind_pubcenter);
	    bindedition();
	   bindsuppliment();
	   return false;
}
	                        //this code is used for bind the publication   
function call_bind(response)
{
    ds=response.value;
    pubname = document.getElementById("drppublication");
    pubname.options.length = 1; 
    pubname.options[0]=new Option("--Select Publication--","0");
    
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pubname.options[pubname.options.length] = new Option(ds.Tables[0].Rows[i].Pub_Name,ds.Tables[0].Rows[i].Pub_Code);
            pubname.options.length;
        }
    }   
}
                         //this code is  used for bind the publication center

function bind_pubcenter(response)
  { 
     ds=response.value;
    pubcenter = document.getElementById("drppubcenter");
    pubcenter.options.length = 1; 
    pubcenter.options[0]=new Option("--Select Publication Center--","0");
        if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            pubcenter.options[pubcenter.options.length] = new Option(ds.Tables[0].Rows[i].Pub_Cent_name,ds.Tables[0].Rows[i].Pub_cent_Code);
            pubcenter.options.length;
        }
    }
    
  } 
  
//*********************************************************************************************************
                  //This code is used for bind the edition according to publication and publication center 

function bindedition()
{
    var pubname=document.getElementById('drppublication').value;
    var pubcenter=document.getElementById('drppubcenter').value;
    
    if(pubcenter=="0")
    {   
 
        var edit=document.getElementById("drpedition");
        edit.options.length=0;
        edit.options[0]=new Option("--Select Edition--","0");
        return false;   
    }
    else
    {
        AdBookingIssue1.bindedition(pubname,pubcenter,bind_editior);
    }
}
 
 function bind_editior(response)
{
    ds=response.value;
    edit = document.getElementById("drpedition");
    edit.options.length = 1; 
    edit.options[0]=new Option("--Select Edition--","0");
    
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            edit.options[edit.options.length] = new Option(ds.Tables[0].Rows[i].Edition_Name,ds.Tables[0].Rows[i].Edition_code);
            edit.options.length;
        }
        
    }
       if(modify=="1") 
        {
        supp = document.getElementById("drpedition");
         document.getElementById('drpedition').value="0";
         document.getElementById('drpsuplement').value="0";
         //global_ds=null;
        }
    else if(global_ds!=null && global_ds!="" && global_ds!=undefined)
    {
        document.getElementById('drpedition').value=global_ds.Tables[0].Rows[z].edition;
        bindsuppliment();
    }
}

//*********************************************************************************************************
    //This code is used for bind the Sippliment according to publication and publication center 

   
function bindsuppliment()
{
    var pubsup=document.getElementById('drppublication');
    var pubedsup=document.getElementById('drpedition').value;
    
    if(pubedsup=="0")
    {
        supp=document.getElementById("drpsuplement");
        supp.options.length=0;
        supp.options[0]=new Option("--Select Suppliment--","0");
        return false;
    }
    else
    {
        var compcodesupp=document.getElementById('hiddencompcode').value;
    
       AdBookingIssue1.pubsuply(compcodesupp,pubedsup,bind_suppliment);
    }
   
}

function bind_suppliment(response)
{
    ds=response.value;
    supp = document.getElementById("drpsuplement");
    supp.options.length = 1; 
    supp.options[0]=new Option("--Select Suppliment--","0");
    
    
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {
        for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
        {
            supp.options[supp.options.length] = new Option(ds.Tables[0].Rows[i].Supp_Name,ds.Tables[0].Rows[i].Supp_Code);
            supp.options.length;
            
        }
       
        
    }
        supp.options[supp.options.length]=new Option("MN","MN");
        if(modify=="1") 
        {
        supp = document.getElementById("drpsuplement");
         document.getElementById('drpsuplement').value="0";
         //global_ds=null;
        }
       else if(global_ds!=null && global_ds!="" && global_ds!=undefined)
        {
        document.getElementById('drpsuplement').value=global_ds.Tables[0].Rows[z].sub_pub;
        }
}
//*********************************************************************************************************
             //This cod is used for close the window
 function closeadbooking()
{
	if(confirm("Do You Want To Skip This Page"))
	{
	window.close();
	return false;
	}
	return false;
}
//***********************************************************************************************************
                ///This code is used for clear the all field and enable all fields
                
 
 		function cancelclick()
		{
		   document.getElementById('drppublication').value="0";
		   document.getElementById('drppubcenter').value="0";
		   document.getElementById('drpedition').value="0";
		   document.getElementById('drpsuplement').value="0";
		   
		   document.getElementById('txtbookvolume').value="";
		   document.getElementById('txtnopages').value="";
		   
		   
		       document.getElementById('drppublication').disabled=true;
		       document.getElementById('drppubcenter').disabled=true;
		       document.getElementById('drpedition').disabled=true;
		       document.getElementById('drpsuplement').disabled=true;
		       
		       document.getElementById('txtbookvolume').disabled=true;
		       document.getElementById('txtnopages').disabled=true;
		  
				

				document.getElementById('btnNew').disabled=false;
				document.getElementById('btnQuery').disabled=false;
				document.getElementById('btnExit').disabled=false;
				document.getElementById('btnDelete').disabled=true;
				
				document.getElementById('btnSave').disabled=true;
				document.getElementById('btnModify').disabled=true;
				document.getElementById('btnfirst').disabled=true;
				document.getElementById('btnprevious').disabled=true;
				
				document.getElementById('btnnext').disabled=true;
				document.getElementById('btnlast').disabled=true;
				document.getElementById('btnNew').disabled=false;
				document.getElementById('btnExecute').disabled=true;
				
				document.getElementById('btnDelete').disabled=true;
				
				modify="0";
				document.getElementById('btnNew').focus();
				
				return false;

		}
//******************************************************************************************************		

function saveadbooking()
{
       
    document.getElementById('txtbookvolume').value=trim(document.getElementById('txtbookvolume').value);
    document.getElementById('txtnopages').value=trim(document.getElementById('txtnopages').value);
    
    if(document.getElementById('drppublication').value=="0")
    {
        alert("Plaese Select Publication");
        document.getElementById('drppublication').focus();
        return false;
    }
    else if(document.getElementById('drppubcenter').value=="0")
    {
        alert("Please Select Publication Center");
        document.getElementById('drppubcenter').focus();
        return false;
    }   
    else if(document.getElementById('drpedition').value=="0")
    {
        alert("Please Select Edition ");
        document.getElementById('drpedition').focus();
        return false;
    }
    else if(document.getElementById('drpsuplement')=="0")
    {
        alert("Please Select Suppliment");
        document.getElementById('drpsuplement').focus();
        return false;
    }
    else if(document.getElementById('txtbookvolume').value=="")
    {
        alert("Please Select Booked volume");
        document.getElementById('txtbookvolume').focus();
        return false;
    }
    else if(document.getElementById('txtnopages').value=="")
    {
        alert("Please Select No Of Pages");
        document.getElementById('txtnopages').focus();
        return false;
    }
              
                var adpub=document.getElementById('drppublication').value;
                var adcenter=document.getElementById('drppubcenter').value;
                var adedition=document.getElementById('drpedition').value;
                var adsuplement=document.getElementById('drpsuplement').value;
                
                var adbook=document.getElementById('txtbookvolume').value;
                var adpages=document.getElementById('txtnopages').value;
                var compcode=document.getElementById('hiddencompcode').value;
                var userid=document.getElementById('hiddenid').value;
           
    
       AdBookingIssue1.chkduplicate(adpub,adcenter,adedition,adsuplement,compcode,userid,call_duplicate);
   
   return false;   
}
//*******************************************************************
function call_duplicate(response)
{
    var ds=response.value;
    if(ds.Tables[0].Rows.length>0)
    {
     alert("This Records has already been assigned");
     return false;
    }
    else
    {
     if(modify!=1)
    {
         
            var adpub=document.getElementById('drppublication').value;
            var adcenter=document.getElementById('drppubcenter').value;
            var adedition=document.getElementById('drpedition').value;
            var adsuplement=document.getElementById('drpsuplement').value;
            
            var adbook=document.getElementById('txtbookvolume').value;
            var adpages=document.getElementById('txtnopages').value;
            var compcode=document.getElementById('hiddencompcode').value;
    
  
    
      AdBookingIssue1.savebooking(adpub,adcenter,adedition,adsuplement,adbook,adpages,compcode);
      alert("Data Saved Successfully");
     
      
      document.getElementById('drppublication').value="0";
      document.getElementById('drppubcenter').value="0";
      document.getElementById('drpedition').value="0";
      document.getElementById('drpsuplement').value="0";
      
      document.getElementById('txtbookvolume').value="";
      document.getElementById('txtnopages').value="";
     
      
      		document.getElementById('drppublication').disabled=true;
			document.getElementById('drppubcenter').disabled=true;
			document.getElementById('drpedition').disabled=true;
			document.getElementById('drpsuplement').disabled=true;
			document.getElementById('txtbookvolume').disabled=true;
		    document.getElementById('txtnopages').disabled=true;
                        
			document.getElementById('btnNew').disabled=false;
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnCancel').disabled=false;		
			document.getElementById('btnExit').disabled=false;	
			
			document.getElementById('btnSave').disabled=true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnExecute').disabled=true;
			
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;		 			
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
			
			 document.getElementById('btnNew').focus();
      }
      else
      {
        //modify code
        var pubname=document.getElementById('drppublication').value;
        var pubcenter=document.getElementById('drppubcenter').value;
        var pubedition=document.getElementById('drpedition').value;
        var pubsup=document.getElementById('drpsuplement').value;
            
        var pubbook=document.getElementById('txtbookvolume').value;
        var pubpages=document.getElementById('txtnopages').value;
         
        var compcode=document.getElementById('hiddencompcode').value;
        
        var userid=document.getElementById('hiddenid').value;
    
        
        AdBookingIssue1.update(pubname,pubcenter,pubedition,pubsup,pubbook,pubpages,compcode,userid);
        
         
          
          global_ds.Tables[0].Rows[z].pri_pub=document.getElementById('drppublication').value;
          global_ds.Tables[0].Rows[z].bkfor=document.getElementById('drppubcenter').value;
          global_ds.Tables[0].Rows[z].edition=document.getElementById('drpedition').value;
          
          global_ds.Tables[0].Rows[z].sub_pub=document.getElementById('drpsuplement').value;
          
          global_ds.Tables[0].Rows[z].booked_volume=document.getElementById('txtbookvolume').value;
          global_ds.Tables[0].Rows[z].no_of_pages=document.getElementById('txtnopages').value;
          
           global_ds.Tables[0].Rows[z].comp_code=document.getElementById('hiddencompcode').value;
           global_ds.Tables[0].Rows[z].hid=document.getElementById('hiddenid').value;
           
           
          
        alert("Data Updated Successfully");
        modify="0";
            document.getElementById('drppublication').disabled=true;
            document.getElementById('drppubcenter').disabled=true;
            document.getElementById('drpedition').disabled=true;
            document.getElementById('drpsuplement').disabled=true;
            document.getElementById('txtbookvolume').disabled=true;
            document.getElementById('txtnopages').disabled=true;
			
			document.getElementById('btnSave').disabled=true;
			//document.getElementById('btnSave').focus();
			
			    
			updateStatus();
			mod="0";
			document.getElementById('btnQuery').disabled=false;
			document.getElementById('btnCancel').disabled=false;
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnDelete').disabled=false;
			document.getElementById('btnExit').disabled=false;
			
			
			if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }
                
             if(z==(global_ds.Tables[0].Rows.length-1))
              {
                document.getElementById('btnNext').disabled=true;
	            document.getElementById('btnLast').disabled=true;
              } 
              document.getElementById('btnModify').disabled=true;      
	     }
			return false;
      
    }
    return false;
}
//****************************************************************************************************
function modifyadbooking()
{
			
			document.getElementById('drppublication').disabled=false;
			document.getElementById('drppubcenter').disabled=false;
			document.getElementById('drpedition').disabled=false;
			document.getElementById('drpsuplement').disabled=false;
			
			document.getElementById('txtbookvolume').disabled=false;
			document.getElementById('txtnopages').disabled=false;
			
			
			chkstatus(FlagStatus);
			
			document.getElementById('btnSave').disabled = false;
			document.getElementById('btnQuery').disabled = true;
			document.getElementById('btnModify').disabled=true;
			document.getElementById('btnCancel').disabled=false;
			
			
			modify="1";
			 hiddentext="modify";
			document.getElementById('btnfirst').disabled=true;				
			document.getElementById('btnnext').disabled=true;					
			document.getElementById('btnprevious').disabled=true;			
			document.getElementById('btnlast').disabled=true;
			
		
			
			document.getElementById('btnDelete').disabled=true;
			document.getElementById('btnExit').disabled=false;	
			
			
			document.getElementById('drppublication').focus();
			document.getElementById('btnModify').disabled=true;	
							
			flag=1;
			return false;
}


//******************************************************************************************************
function queryadbooking()
{            z=0;
    		document.getElementById('drppublication').value="0";
			document.getElementById('drppubcenter').value="0";
			document.getElementById('drpedition').value="0";
			
			document.getElementById('drpsuplement').value="0";
			document.getElementById('txtbookvolume').value="";
			document.getElementById('txtnopages').value="";
			
			
			document.getElementById('drppublication').disabled=false;
			document.getElementById('drppubcenter').disabled=false;
			document.getElementById('drpedition').disabled=false;
			document.getElementById('drpsuplement').disabled=false;
			
			document.getElementById('txtbookvolume').disabled=false;
			document.getElementById('txtnopages').disabled=false;
			
			chkstatus(FlagStatus);
			
//*********************************************************************************************************			
	//This Code is used for bind the drop down list in case of query		
//*********************************************************************************************************
	 var compcode=document.getElementById('hiddencompcode').value;	   
       AdBookingIssue1. bindpublication(compcode,call_bind);
	 AdBookingIssue1.bindpubcenter(bind_pubcenter);
	     bindedition();
	   bindsuppliment();
	            
	z=0;
			
			hiddentext="query";
			chkstatus(FlagStatus);
			
			global_ds=null;
		

            document.getElementById('btnNew').disabled=true;
			document.getElementById('btnQuery').disabled=true;
			
			
			
			
		
			
			document.getElementById('btnExecute').disabled=false;
			document.getElementById('btnSave').disabled=true;
			 //document.getElementById('drppublication').focus();
			 document.getElementById('btnExecute').focus();
			
			return false;
}
//**********************************************************************************************************
                   //This code is used for execute button
                   
function executeadbooking()
{
     z=0;
       
     var adpub=document.getElementById('drppublication').value;
     globladpub=adpub;
     var adcenter=document.getElementById('drppubcenter').value;
     globladcenter=adcenter;
     var adedition=document.getElementById('drpedition').value;
     globladedition=adedition;
     var adsup=document.getElementById('drpsuplement').value;
     globladsup=adsup;
     
     var adbook=document.getElementById('txtbookvolume').value;
     globladbook=adbook;
     var adpages=document.getElementById('txtnopages').value;
     globladpages=adpages;
     var compcode=document.getElementById('hiddencompcode').value;
     var userid=document.getElementById('hiddenid').value;
     globuserid=userid;
     
     AdBookingIssue1.adexecute(adpub,adcenter,adedition,adsup,compcode,userid,call_execute);
    
     
      document.getElementById('drppublication').disabled=true;
     document.getElementById('drppubcenter').disabled=true;
     document.getElementById('drpedition').disabled=true;
     document.getElementById('drpsuplement').disabled=true;
     document.getElementById('txtbookvolume').disabled=true;
     document.getElementById('txtnopages').disabled=true;
     
                        document.getElementById('btnfirst').disabled=true;				
						document.getElementById('btnnext').disabled=false;	
										
						document.getElementById('btnprevious').disabled=true;			
						document.getElementById('btnlast').disabled=false;
						
						document.getElementById('btnModify').disabled=false;
						 document.getElementById('btnNew').disabled=true;
						 
				        document.getElementById('btnExecute').disabled=true;
				          document.getElementById('btnQuery').disabled=false;
						document.getElementById('btnDelete').disabled=false;
						
						document.getElementById('btnModify').focus();
						
						return false;
     
}
function call_execute(response)
{
  global_ds=response.value;
  
    if(global_ds.Tables[0].Rows.length>0)
    {
        document.getElementById('drppublication').value=global_ds.Tables[0].Rows[0].pri_pub;
         document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[0].bkfor;
         bindedition();
  
           
           if(global_ds.Tables[0].Rows[0].booked_volume!=null)
           {         
           document.getElementById('txtbookvolume').value=global_ds.Tables[0].Rows[0].booked_volume;
           }
           else
           {
            document.getElementById('txtbookvolume').value="";
           }
           if(global_ds.Tables[0].Rows[0].no_of_pages!=null)
           {
           document.getElementById('txtnopages').value=global_ds.Tables[0].Rows[0].no_of_pages;
           }
           else
           {
              document.getElementById('txtnopages').value="";
           }
           document.getElementById('hiddenid').value=global_ds.Tables[0].Rows[0].hid;
           
           document.getElementById('drppublication').disabled=true;
           document.getElementById('drppubcenter').disabled=true;           
           document.getElementById('drpedition').disabled=true;
            document.getElementById('drpsuplement').disabled=true;
             document.getElementById('txtbookvolume').disabled=true;
              document.getElementById('txtnopages').disabled=true;                          
    }
    else
    {
        alert("Your Search Produce No Result!!");
        cancelclick('AdBookingIssue1');
        return false;
        
    }
        if(global_ds.Tables[0].Rows.length ==1)
			{
			    document.getElementById('btnfirst').disabled=true;				
			    document.getElementById('btnnext').disabled=true;					
			    document.getElementById('btnprevious').disabled=true;			
			   document.getElementById('btnlast').disabled=true;
			}
    return false;
}
//**********************************************************************************************************
function firstbooking()
{
  z=0;
   
    document.getElementById('drppublication').value=global_ds.Tables[0].Rows[z].pri_pub;
    document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[z].bkfor;
   
       bindedition();
//        document.getElementById('drpedition').value=global_ds.Tables[0].Rows[z].edition;		
//		         document.getElementById('drpsuplement').value=global_ds.Tables[0].Rows[z].sub_pub;
  
           
           if(global_ds.Tables[0].Rows[z].booked_volume!=null)
           {         
           document.getElementById('txtbookvolume').value=global_ds.Tables[0].Rows[z].booked_volume;
           }
           else
           {
            document.getElementById('txtbookvolume').value="";
           }
           if(global_ds.Tables[0].Rows[z].no_of_pages!=null)
           {
           document.getElementById('txtnopages').value=global_ds.Tables[0].Rows[z].no_of_pages;
           }
           else
           {
              document.getElementById('txtnopages').value="";
           }
           document.getElementById('hiddenid').value=global_ds.Tables[0].Rows[z].hid;
  
    updateStatus();
    
    
    	document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnprevious').disabled=true;
		document.getElementById('btnnext').disabled=false;
		document.getElementById('btnlast').disabled=false;
		
		return false;
}
//********************************************************************************************************

function lastbooking()
{

		
		var y=global_ds.Tables[0].Rows.length;
		var a=y-1;
		z=a;

		document.getElementById('drppublication').value=global_ds.Tables[0].Rows[a].pri_pub;
		
		document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[a].bkfor;
		
    bindedition();
//        document.getElementById('drpedition').value=global_ds.Tables[0].Rows[z].edition;		
//		         document.getElementById('drpsuplement').value=global_ds.Tables[0].Rows[z].sub_pub;
//  
           
           if(global_ds.Tables[0].Rows[a].booked_volume!=null)
           {         
           document.getElementById('txtbookvolume').value=global_ds.Tables[0].Rows[a].booked_volume;
           }
           else
           {
            document.getElementById('txtbookvolume').value="";
           }
           if(global_ds.Tables[0].Rows[a].no_of_pages!=null)
           {
           document.getElementById('txtnopages').value=global_ds.Tables[0].Rows[a].no_of_pages;
           }
           else
           {
              document.getElementById('txtnopages').value="";
           }
		
	   document.getElementById('hiddenid').value=global_ds.Tables[0].Rows[a].hid;
			updateStatus();
			
		        document.getElementById('btnnext').disabled=true;
		        document.getElementById('btnlast').disabled=true;
		        document.getElementById('btnfirst').disabled=false;
		        document.getElementById('btnprevious').disabled=false;

		return false;
}
//**********************************************************************************************************
function nextadbooking()
{

	var a=global_ds.Tables[0].Rows.length;
	z++;
	
	if(z !=-1 && z >= 0)
	{
		    if(z <= a-1)
		    {
			     document.getElementById('drppublication').value=global_ds.Tables[0].Rows[z].pri_pub;    		
		         document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[z].bkfor; 
		         bindedition();
     	    		   
//		         document.getElementById('drpedition').value=global_ds.Tables[0].Rows[z].edition;		
//		         document.getElementById('drpsuplement').value=global_ds.Tables[0].Rows[z].sub_pub;


		         document.getElementById('txtbookvolume').value=global_ds.Tables[0].Rows[z].booked_volume;	
		         document.getElementById('txtnopages').value=global_ds.Tables[0].Rows[z].no_of_pages;
		         document.getElementById('hiddenid').value=global_ds.Tables[0].Rows[z].hid;
    			
		        updateStatus();
    		    
			    document.getElementById('btnnext').disabled=false;
			    document.getElementById('btnlast').disabled=false;
			    document.getElementById('btnfirst').disabled=false;
			    document.getElementById('btnprevious').disabled=false;
		    }
		    else
	        {
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
	        }
	}
	else
	{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
	}
	if(z==a-1)
	{
			document.getElementById('btnnext').disabled=true;
			document.getElementById('btnlast').disabled=true;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
	}
	return false;

}
//**********************************************************************************************************
function previousadbooking()
{
	        var a=global_ds.Tables[0].Rows.length;
		    z--;
		    if(z != -1)
		    {
		        if(z >= 0 && z <= a-1)
			        {
			        document.getElementById('drppublication').value=global_ds.Tables[0].Rows[z].pri_pub;    		
		            document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[z].bkfor; 
		              bindedition();
		               	    		   
//		            document.getElementById('drpedition').value=global_ds.Tables[0].Rows[z].edition;		
//		            document.getElementById('drpsuplement').value=global_ds.Tables[0].Rows[z].sub_pub;
		            document.getElementById('txtbookvolume').value=global_ds.Tables[0].Rows[z].booked_volume;	
		            document.getElementById('txtnopages').value=global_ds.Tables[0].Rows[z].no_of_pages;
        			document.getElementById('hiddenid').value=global_ds.Tables[0].Rows[z].hid;	
			            updateStatus();
				        document.getElementById('btnnext').disabled=false;
				        document.getElementById('btnlast').disabled=false;
			        }
			      else
			         {
				        document.getElementById('btnnext').disabled=false;
				        document.getElementById('btnlast').disabled=false;
				        document.getElementById('btnfirst').disabled=true;
				        document.getElementById('btnprevious').disabled=true;
				        return false;
			         }
			 }
			  else
			     {
			        document.getElementById('btnnext').disabled=false;
				    document.getElementById('btnlast').disabled=false;
				    document.getElementById('btnfirst').disabled=true;
				    document.getElementById('btnprevious').disabled=true;
				    return false;
			     }
		    if(z==0)
		        {
			        document.getElementById('btnfirst').disabled=true;
			        document.getElementById('btnprevious').disabled=true;
		        }
		    return false;
		
}
//*********************************************************************************************************

function deleteadbooking()
{
    var adpub=document.getElementById('drppublication').value;
    var adcenter=document.getElementById('drppubcenter').value;
    var adedition=document.getElementById('drpedition').value;
    var adsup=document.getElementById('drpsuplement').value;
    var adbook=document.getElementById('txtbookvolume').value;
    var adpages=document.getElementById('txtnopages').value;
    var compcode=document.getElementById('hiddencompcode').value;
    
    var compcode=document.getElementById('hiddencompcode').value;
    var userid=document.getElementById('hiddenid').value;
    
    if(confirm("Are You Sure Want To Delete The Data?"))
    {    
    AdBookingIssue1.deletead(adpub, adcenter, adedition, adsup, compcode,userid);
    
    alert("Data Deleted Successfully"); 
    AdBookingIssue1.adexecute(globladpub,globladcenter,globladedition,globladsup,compcode,globuserid,call_delete);
    }
    return false;
    
}
//************************************************************

function call_delete(response)
{
	global_ds= response.value;
    var len=global_ds.Tables[0].Rows.length;
	
	if(global_ds.Tables[0].Rows.length==0)
	{
		alert("No More Data is here to be deleted");
		
		    document.getElementById('drppublication').value="0";
		    document.getElementById('drppubcenter').value="0";
		    document.getElementById('drpedition').value="0";
		    document.getElementById('drpsuplement').value="0";
		    
		    document.getElementById('txtbookvolume').value="";
		    document.getElementById('txtnopages').value="";
		  
    
		
		return false;
	}
	else if(z>=len || z==-1)
	{
		            document.getElementById('drppublication').value=global_ds.Tables[0].Rows[0].pri_pub;    		
		            document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[0].bkfor; 
		            
		                 // bindedition();	    		   
		            document.getElementById('drpedition').value=global_ds.Tables[0].Rows[0].edition;		
		            document.getElementById('drpsuplement').value=global_ds.Tables[0].Rows[0].sub_pub;

		            document.getElementById('txtbookvolume').value=global_ds.Tables[0].Rows[0].booked_volume;	
		            document.getElementById('txtnopages').value=global_ds.Tables[0].Rows[0].no_of_pages;
		            
		            document.getElementById('hiddenid').value=global_ds.Tables[0].Rows[0].hid;
		            
			
	}
	else
	{
		            document.getElementById('drppublication').value=global_ds.Tables[0].Rows[z].pri_pub;    		
		            document.getElementById('drppubcenter').value=global_ds.Tables[0].Rows[z].bkfor;
		           // bindedition();	    		   
		            document.getElementById('drpedition').value=global_ds.Tables[0].Rows[z].edition;		
		            document.getElementById('drpsuplement').value=global_ds.Tables[0].Rows[z].sub_pub;

		            document.getElementById('txtbookvolume').value=global_ds.Tables[0].Rows[z].booked_volume;	
		            document.getElementById('txtnopages').value=global_ds.Tables[0].Rows[z].no_of_pages;
		            
		             document.getElementById('hiddenid').value=global_ds.Tables[0].Rows[z].hid;
			
	}
	
		       if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

              if(z==global_ds.Tables[0].Rows.length)
              {
                document.getElementById('btnNext').disabled=true;
	              document.getElementById('btnLast').disabled=true;
              }       

	
return false;
}
//*********************************************************************************************************
