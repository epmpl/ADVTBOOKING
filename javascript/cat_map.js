////////////object for cat2
var objadscat;
///////////object for cat3
var objcat3;
////////////object for cat4
var objcat4;
//////////////////
var objcat5;//////
/////////////to know whether we r saving or modyfying the data
var hiddentext="";
////////////this is to store the primary ket at the time os exe,f,p,n,l
var primary;
////////////this is  variable is used in f,p,n,l
var z;
/////////////this is the global dataset used in f,p,n,l
var ds_exe;
//////////this is the global variable
var gb_sourceregion,gb_sourcevariable,gb_sourcecat1,gb_sourcecat2,gb_sourcecat3,gb_sourcecat4,gb_sourcecat5,gb_destedit,gb_destreg,gb_destvar
var gb_destcat1,gb_destcat2,gb_destcat3,gb_destcat4,gb_destcat5

function fillcat2(id)
{
     var compcode=document.getElementById('hiddencompcode').value;
     var adcategory=document.getElementById(id).value;
     
     
     if(id=="drpsoucat1")
     {
        objadscat=document.getElementById('drpsoucat2');
         document.getElementById('drpsoucat2').options.length=0;   
         document.getElementById('drpsoucat3').options.length=0;
         document.getElementById('drpsoucat4').options.length=0;
         document.getElementById('drpsoucat5').options.length=0;
     }
     else if(id=="drpdescat1")
     {
         objadscat=document.getElementById('drpdescat2');   
         document.getElementById('drpdescat2').options.length=0;   
         document.getElementById('drpdescat3').options.length=0;
         document.getElementById('drpdescat4').options.length=0;
         document.getElementById('drpdescat5').options.length=0;
     
     
     }   
     
     
         
     
     if(adcategory!="0")
     {
        cat_mapping.getadsubcat(compcode,adcategory,call_filladscat);
     }
     
     return false;
         
        
}     


function fillcat22(id)
{
     var compcode=document.getElementById('hiddencompcode').value;
     var adcategory=document.getElementById(id).value;
     
     
     if(id=="drpsoucat1")
     {
        objadscat=document.getElementById('drpsoucat2');
         document.getElementById('drpsoucat2').options.length=0;   
         document.getElementById('drpsoucat3').options.length=0;
         document.getElementById('drpsoucat4').options.length=0;
         document.getElementById('drpsoucat5').options.length=0;
     }
     else if(id=="drpdescat1")
     {
         objadscat=document.getElementById('drpdescat2');   
         document.getElementById('drpdescat2').options.length=0;   
         document.getElementById('drpdescat3').options.length=0;
         document.getElementById('drpdescat4').options.length=0;
         document.getElementById('drpdescat5').options.length=0;
     
     
     }   
     
     
         
     
     if(adcategory!="0")
     {
        cat_mapping.getadsubcat(compcode,adcategory,call_filladscat1);
     }
     
     return false;
         
        
}     



function call_filladscat1(res)
{
    
    
    var ds=res.value;
    objadscat=document.getElementById('drpsoucat2');   
    objadscat.options.length = 0; 
    objadscat.options[0]=new Option("-Select-","0");
//    
    objadscat.options.length = 1; 
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        objadscat.options[objadscat.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Subcat_Name,ds.Tables[0].Rows[i].Adv_Subcat_Code);
        
       objadscat.options.length;
       
    }
    
    if(hiddentext=="")
    {
        if(objadscat.id=="drpsoucat2")
        {
            document.getElementById('drpsoucat2').value=ds_exe.Tables[0].Rows[z].source_cat2
        }
        else if(objadscat.id=="drpdescat2")
        {
            document.getElementById('drpdescat2').value=ds_exe.Tables[0].Rows[z].destination_cat2
        }
    }
  

}

function call_filladscat1desc(res)
{
    
    
    var ds=res.value;
    objadscat=document.getElementById('drpdescat2');   
    objadscat.options.length = 0; 
    objadscat.options[0]=new Option("-Select-","0");
//    
    objadscat.options.length = 1; 
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        objadscat.options[objadscat.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Subcat_Name,ds.Tables[0].Rows[i].Adv_Subcat_Code);
        
       objadscat.options.length;
       
    }
    
    if(hiddentext=="")
    {
        if(objadscat.id=="drpsoucat2")
        {
            document.getElementById('drpsoucat2').value=ds_exe.Tables[0].Rows[z].source_cat2
        }
        else if(objadscat.id=="drpdescat2")
        {
            document.getElementById('drpdescat2').value=ds_exe.Tables[0].Rows[z].destination_cat2
        }
    }
  

}


function call_filladscat(res)
{
    
    
    var ds=res.value;
    objadscat.options.length = 0; 
    objadscat.options[0]=new Option("-Select-","0");
//    
    objadscat.options.length = 1; 
    for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
    {
        objadscat.options[objadscat.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Subcat_Name,ds.Tables[0].Rows[i].Adv_Subcat_Code);
        
       objadscat.options.length;
       
    }
    
    if(hiddentext=="")
    {
        if(objadscat.id=="drpsoucat2")
        {
            document.getElementById('drpsoucat2').value=ds_exe.Tables[0].Rows[z].source_cat2
        }
        else if(objadscat.id=="drpdescat2")
        {
            document.getElementById('drpdescat2').value=ds_exe.Tables[0].Rows[z].destination_cat2
        }
    }
  

}
         //objcat3
function fillcat3(id)
{

    var adscat=document.getElementById(id).value;
    var compcode=document.getElementById('hiddencompcode').value;
    

    if(id=="drpsoucat2")
     {
        objcat3 = document.getElementById("drpsoucat3");
           
         document.getElementById('drpsoucat3').options.length=0;
         document.getElementById('drpsoucat4').options.length=0;
         document.getElementById('drpsoucat5').options.length=0;
     }
     else if(id=="drpdescat2")
     {
         objcat3 = document.getElementById("drpdescat3");
          
         document.getElementById('drpdescat3').options.length=0;
         document.getElementById('drpdescat4').options.length=0;
         document.getElementById('drpdescat5').options.length=0;
     
     
     }   

    ///if 0 than it is to bind ad cat3 drp down
    if(adscat!="0")
    {
        cat_mapping.bindadcat3(adscat,compcode,"0",call_bindadcat31);
    }
    return false;

}

function fillcat33(id)
{

    var adscat=document.getElementById(id).value;
    var compcode=document.getElementById('hiddencompcode').value;
    

    if(id=="drpsoucat2")
     {
        objcat3 = document.getElementById("drpsoucat3");
           
         document.getElementById('drpsoucat3').options.length=0;
         document.getElementById('drpsoucat4').options.length=0;
         document.getElementById('drpsoucat5').options.length=0;
     }
     else if(id=="drpdescat2")
     {
         objcat3 = document.getElementById("drpdescat3");
          
         document.getElementById('drpdescat3').options.length=0;
         document.getElementById('drpdescat4').options.length=0;
         document.getElementById('drpdescat5').options.length=0;
     
     
     }   

    ///if 0 than it is to bind ad cat3 drp down
    if(adscat!="0")
    {
        cat_mapping.bindadcat3(adscat,compcode,"0",call_bindadcat31);
    }
    return false;

}


function call_bindadcat31(res)
{
    var ds=res.value;
    
     objcat3.options.length = 0; 
    objcat3.options[0]=new Option("-Select ad s cat-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {

            objcat3.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                objcat3.options[objcat3.options.length] = new Option(ds.Tables[0].Rows[i].catname,ds.Tables[0].Rows[i].catcode);
                
               objcat3.options.length;
               
            }
            
            if(hiddentext=="")
            {
                if(objcat3.id=="drpsoucat3")
                {
                    document.getElementById('drpsoucat3').value=ds_exe.Tables[0].Rows[0].source_cat3;;
                }
                else if(objcat3.id=="drpdescat3")
                {
                    document.getElementById('drpdescat3').value=ds_exe.Tables[0].Rows[0].destination_cat3;;
                
                }
                
            
            }
    
    }

}

function call_bindadcat31(res)
{
    var ds=res.value;
    objcat3 = document.getElementById("drpsoucat3");
     objcat3.options.length = 0; 
    objcat3.options[0]=new Option("-Select ad s cat-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {

            objcat3.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                objcat3.options[objcat3.options.length] = new Option(ds.Tables[0].Rows[i].catname,ds.Tables[0].Rows[i].catcode);
                
               objcat3.options.length;
               
            }
            
            if(hiddentext=="")
            {
                if(objcat3.id=="drpsoucat3")
                {
                    document.getElementById('drpsoucat3').value=ds_exe.Tables[0].Rows[0].source_cat3;;
                }
                else if(objcat3.id=="drpdescat3")
                {
                    document.getElementById('drpdescat3').value=ds_exe.Tables[0].Rows[0].destination_cat3;;
                
                }
                
            
            }
    
    }
    return false;

}

function call_bindadcat3desc(res)
{
    var ds=res.value;
    objcat3 = document.getElementById("drpdescat3");
     objcat3.options.length = 0; 
    objcat3.options[0]=new Option("-Select ad s cat-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {

            objcat3.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                objcat3.options[objcat3.options.length] = new Option(ds.Tables[0].Rows[i].catname,ds.Tables[0].Rows[i].catcode);
                
               objcat3.options.length;
               
            }
            
            if(hiddentext=="")
            {
                if(objcat3.id=="drpsoucat3")
                {
                    document.getElementById('drpsoucat3').value=ds_exe.Tables[0].Rows[0].source_cat3;;
                }
                else if(objcat3.id=="drpdescat3")
                {
                    document.getElementById('drpdescat3').value=ds_exe.Tables[0].Rows[0].destination_cat3;;
                
                }
                
            
            }
    
    }
    return false;

}


function fillcat4(id)
{
    var adscat4=document.getElementById(id).value;
    var compcode=document.getElementById('hiddencompcode').value;
    

    if(id=="drpsoucat3")
     {
        objcat4 = document.getElementById("drpsoucat4");
           
         
         document.getElementById('drpsoucat4').options.length=0;
         document.getElementById('drpsoucat5').options.length=0;
     }
     else if(id=="drpdescat3")
     {
         objcat4 = document.getElementById("drpdescat4");
          
         
         document.getElementById('drpdescat4').options.length=0;
         document.getElementById('drpdescat5').options.length=0;
     
     
     }   
     
     if(adscat4!="0")
     {
     ///if 1 than it is to bind ad cat4 drp down
        cat_mapping.bindadcat3(adscat4,compcode,"1",call_bindadcat41);
     }
    return false;

}

function fillcat44(id)
{
    var adscat4=document.getElementById(id).value;
    var compcode=document.getElementById('hiddencompcode').value;
    

    if(id=="drpsoucat3")
     {
        objcat4 = document.getElementById("drpsoucat4");
           
         
         document.getElementById('drpsoucat4').options.length=0;
         document.getElementById('drpsoucat5').options.length=0;
     }
     else if(id=="drpdescat3")
     {
         objcat4 = document.getElementById("drpdescat4");
          
         
         document.getElementById('drpdescat4').options.length=0;
         document.getElementById('drpdescat5').options.length=0;
     
     
     }   
     
     if(adscat4!="0")
     {
     ///if 1 than it is to bind ad cat4 drp down
        cat_mapping.bindadcat3(adscat4,compcode,"1",call_bindadcat41);
     }
    return false;

}

function call_bindadcat41(res)
{
    var ds=res.value;
    var ds=res.value;
     
     objcat4.options.length = 0; 
    objcat4.options[0]=new Option("-Select-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {

            objcat4.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                objcat4.options[objcat4.options.length] = new Option(ds.Tables[0].Rows[i].Cat_Name,ds.Tables[0].Rows[i].Cat_Code);
                
               objcat4.options.length;
               
            }
            
            if(hiddentext=="")
            {   
                if(objcat4.id=="drpsoucat4")
                {
                    document.getElementById('drpsoucat4').value=ds_exe.Tables[0].Rows[0].source_cat4;;
                }
                else if(objcat4.id=="drpdescat4")
                {
                    document.getElementById('drpdescat4').value=ds_exe.Tables[0].Rows[0].destination_cat4;;
                }
            }
    
    }

}

function call_bindadcat41(res)
{
    var ds=res.value;
    var ds=res.value;
     objcat4 = document.getElementById("drpsoucat4");
     objcat4.options.length = 0; 
    objcat4.options[0]=new Option("-Select-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {

            objcat4.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                objcat4.options[objcat4.options.length] = new Option(ds.Tables[0].Rows[i].Cat_Name,ds.Tables[0].Rows[i].Cat_Code);
                
               objcat4.options.length;
               
            }
            
            if(hiddentext=="")
            {   
                if(objcat4.id=="drpsoucat4")
                {
                    document.getElementById('drpsoucat4').value=ds_exe.Tables[0].Rows[0].source_cat4;;
                }
                else if(objcat4.id=="drpdescat4")
                {
                    document.getElementById('drpdescat4').value=ds_exe.Tables[0].Rows[0].destination_cat4;;
                }
            }
    
    }

}


function call_bindadcat4desc(res)
{
    var ds=res.value;
    var ds=res.value;
     objcat4 = document.getElementById("drpdescat4");
     objcat4.options.length = 0; 
    objcat4.options[0]=new Option("-Select-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {

            objcat4.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                objcat4.options[objcat4.options.length] = new Option(ds.Tables[0].Rows[i].Cat_Name,ds.Tables[0].Rows[i].Cat_Code);
                
               objcat4.options.length;
               
            }
            
            if(hiddentext=="")
            {   
                if(objcat4.id=="drpsoucat4")
                {
                    document.getElementById('drpsoucat4').value=ds_exe.Tables[0].Rows[0].source_cat4;;
                }
                else if(objcat4.id=="drpdescat4")
                {
                    document.getElementById('drpdescat4').value=ds_exe.Tables[0].Rows[0].destination_cat4;;
                }
            }
    
    }

}


//
function fillcat5(id)
{
    var adscat4=document.getElementById(id).value;
    var compcode=document.getElementById('hiddencompcode').value;
    

    if(id=="drpsoucat4")
     {
        objcat5 = document.getElementById("drpsoucat5");
           
         
         
         document.getElementById('drpsoucat5').options.length=0;
     }
     else if(id=="drpdescat4")
     {
         objcat5 = document.getElementById("drpdescat5");
          
         
         
         document.getElementById('drpdescat5').options.length=0;
     
     
     }   
     
     ///if 2 than it is to bind ad cat5 drp down 
     if(adscat4!="0")
     {
        cat_mapping.bindadcat3(adscat4,compcode,"2",call_bindadcat51);
     }   
    return false;
     
     

}

function fillcat55(id)
{
    var adscat4=document.getElementById(id).value;
    var compcode=document.getElementById('hiddencompcode').value;
    

    if(id=="drpsoucat4")
     {
        objcat5 = document.getElementById("drpsoucat5");
           
         
         
         document.getElementById('drpsoucat5').options.length=0;
     }
     else if(id=="drpdescat4")
     {
         objcat5 = document.getElementById("drpdescat5");
          
         
         
         document.getElementById('drpdescat5').options.length=0;
     
     
     }   
     
     ///if 2 than it is to bind ad cat5 drp down 
     if(adscat4!="0")
     {
        cat_mapping.bindadcat3(adscat4,compcode,"2",call_bindadcat51);
     }   
    return false;
     
     

}



function call_bindadcat51(res)
{
    var ds=res.value;
     
     objcat5.options.length = 0; 
    objcat5.options[0]=new Option("-Select-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {

            objcat5.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                objcat5.options[objcat5.options.length] = new Option(ds.Tables[0].Rows[i].Cat_Name,ds.Tables[0].Rows[i].Cat_Code);
                
               objcat5.options.length;
               
            }
            
            if(hiddentext=="")
            {
                if(objcat5.id=="drpsoucat5")
                {
                    document.getElementById('drpsoucat5').value=ds_exe.Tables[0].Rows[0].source_cat5;
                }
                else if(objcat5.id=="drpdescat5")
                {
                
                    document.getElementById('drpsoucat5').value=ds_exe.Tables[0].Rows[0].destination_cat5;
                }
            }        
    
    }

}


function call_bindadcat51(res)
{
    var ds=res.value;
     objcat5 = document.getElementById("drpsoucat5");
     objcat5.options.length = 0; 
    objcat5.options[0]=new Option("-Select-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {

            objcat5.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                objcat5.options[objcat5.options.length] = new Option(ds.Tables[0].Rows[i].Cat_Name,ds.Tables[0].Rows[i].Cat_Code);
                
               objcat5.options.length;
               
            }
            
            if(hiddentext=="")
            {
                if(objcat5.id=="drpsoucat5")
                {
                    document.getElementById('drpsoucat5').value=ds_exe.Tables[0].Rows[0].source_cat5;
                }
                else if(objcat5.id=="drpdescat5")
                {
                
                    document.getElementById('drpsoucat5').value=ds_exe.Tables[0].Rows[0].destination_cat5;
                }
            }        
    
    }

}


function call_bindadcat5desc(res)
{
    var ds=res.value;
     objcat5 = document.getElementById("drpdescat5");
     objcat5.options.length = 0; 
    objcat5.options[0]=new Option("-Select-","0");
    if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
    {

            objcat5.options.length = 1; 
            for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                objcat5.options[objcat5.options.length] = new Option(ds.Tables[0].Rows[i].Cat_Name,ds.Tables[0].Rows[i].Cat_Code);
                
               objcat5.options.length;
               
            }
            
            if(hiddentext=="")
            {
                if(objcat5.id=="drpsoucat5")
                {
                    document.getElementById('drpsoucat5').value=ds_exe.Tables[0].Rows[0].source_cat5;
                }
                else if(objcat5.id=="drpdescat5")
                {
                
                    document.getElementById('drpdescat5').value=ds_exe.Tables[0].Rows[0].destination_cat5;
                }
            }        
    
    }

}


//*******************************************************************************//
//*********************This For The Do The laters in capital laters**************//
//*******************************************************************************//	
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
if(event.keyCode==113) 
    event.keyCode= 81;
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

///////////////this is for new click

function newcatmap()
{

    document.getElementById('drpsouregion').disabled=false;
    document.getElementById('drpsouvariable').disabled=false;
    document.getElementById('drpsoucat1').disabled=false;
    document.getElementById('drpsoucat2').disabled=false;
    document.getElementById('drpsoucat3').disabled=false;
    document.getElementById('drpsoucat4').disabled=false;
    document.getElementById('drpsoucat5').disabled=false;
    document.getElementById('drpdesedition').disabled=false;
    document.getElementById('drpdesregion').disabled=false;
    document.getElementById('drpdesvariable').disabled=false;
    document.getElementById('drpdescat1').disabled=false;
    document.getElementById('drpdescat2').disabled=false;
    document.getElementById('drpdescat3').disabled=false;
    document.getElementById('drpdescat4').disabled=false;
    document.getElementById('drpdescat5').disabled=false;
    
    hiddentext="new";
    
    chkstatus(FlagStatus);
			
	document.getElementById('btnSave').disabled = false;	
	document.getElementById('btnNew').disabled = true;	
	document.getElementById('btnQuery').disabled=true;


}
function savecatmap()
{
    var comp_code=document.getElementById('hiddencompcode').value;
    var sourceregion=document.getElementById('drpsouregion').value;
    var sourcevariable=document.getElementById('drpsouvariable').value;
    var sourcecat1=document.getElementById('drpsoucat1').value;
    var sourcecat2=document.getElementById('drpsoucat2').value;
    var sourcecat3=document.getElementById('drpsoucat3').value;
    var sourcecat4=document.getElementById('drpsoucat4').value;
    var sourcecat5=document.getElementById('drpsoucat5').value;
    var destedit=document.getElementById('drpdesedition').value;
    var destreg=document.getElementById('drpdesregion').value;
    var destvar=document.getElementById('drpdesvariable').value;
    var destcat1=document.getElementById('drpdescat1').value;
    var destcat2=document.getElementById('drpdescat2').value;
    var destcat3=document.getElementById('drpdescat3').value;
    var destcat4=document.getElementById('drpdescat4').value;
    var destcat5=document.getElementById('drpdescat5').value;
    
    if(hiddentext=="new")
    {
        cat_mapping.chkcombination(comp_code,sourceregion,sourcevariable,sourcecat1,sourcecat2,sourcecat3,sourcecat4,sourcecat5,destedit,destreg,destvar,destcat1,destcat2,destcat3,destcat4,destcat5,call_chkcombination);
    }
    else if(hiddentext=="mod")
    {
    //primary
        cat_mapping.chkmapmodify(comp_code,sourceregion,sourcevariable,sourcecat1,sourcecat2,sourcecat3,sourcecat4,sourcecat5,destedit,destreg,destvar,destcat1,destcat2,destcat3,destcat4,destcat5,primary,call_chkmapmodify);
    
    }

    return false;

}

function call_chkcombination(res)
{
    var ds=res.value;
    if(ds.Tables[0].Rows.length>0)
    {
        alert("This mapping has already been there try another");
        return false;
    
    }    
    else
    {
        var comp_code=document.getElementById('hiddencompcode').value;
        var sourceregion=document.getElementById('drpsouregion').value;
        var sourcevariable=document.getElementById('drpsouvariable').value;
        var sourcecat1=document.getElementById('drpsoucat1').value;
        var sourcecat2=document.getElementById('drpsoucat2').value;
        var sourcecat3=document.getElementById('drpsoucat3').value;
        var sourcecat4=document.getElementById('drpsoucat4').value;
        var sourcecat5=document.getElementById('drpsoucat5').value;
        var destedit=document.getElementById('drpdesedition').value;
        var destreg=document.getElementById('drpdesregion').value;
        var destvar=document.getElementById('drpdesvariable').value;
        var destcat1=document.getElementById('drpdescat1').value;
        var destcat2=document.getElementById('drpdescat2').value;
        var destcat3=document.getElementById('drpdescat3').value;
        var destcat4=document.getElementById('drpdescat4').value;
        var destcat5=document.getElementById('drpdescat5').value;
        
        cat_mapping.savemapping(comp_code,sourceregion,sourcevariable,sourcecat1,sourcecat2,sourcecat3,sourcecat4,sourcecat5,destedit,destreg,destvar,destcat1,destcat2,destcat3,destcat4,destcat5);    
        alert("Mapping saved");
        cancelcatmap('cat_mapping');
        
        
   
        
    
    }

    return false;

}
function cancelcatmap(formname)
{
         document.getElementById('drpsouregion').value="0";
        document.getElementById('drpsouvariable').value="0";
        document.getElementById('drpsoucat1').value="0";
        document.getElementById('drpsoucat2').options.length=0;
        document.getElementById('drpsoucat3').options.length=0;;
        document.getElementById('drpsoucat4').options.length=0;;
        document.getElementById('drpsoucat5').options.length=0;;
        document.getElementById('drpdesedition').value="0";
        document.getElementById('drpdesregion').value="0";
        document.getElementById('drpdesvariable').value="0";
        document.getElementById('drpdescat1').value="0";
        document.getElementById('drpdescat2').options.length=0;;
        document.getElementById('drpdescat3').options.length=0;;
        document.getElementById('drpdescat4').options.length=0;;
        document.getElementById('drpdescat5').options.length=0;;
        
        document.getElementById('drpsouregion').disabled=true;
        document.getElementById('drpsouvariable').disabled=true;
        document.getElementById('drpsoucat1').disabled=true;
        document.getElementById('drpsoucat2').disabled=true;
        document.getElementById('drpsoucat3').disabled=true;
        document.getElementById('drpsoucat4').disabled=true;
        document.getElementById('drpsoucat5').disabled=true;
        document.getElementById('drpdesedition').disabled=true;
        document.getElementById('drpdesregion').disabled=true;
        document.getElementById('drpdesvariable').disabled=true;
        document.getElementById('drpdescat1').disabled=true;
        document.getElementById('drpdescat2').disabled=true;
        document.getElementById('drpdescat3').disabled=true;
        document.getElementById('drpdescat4').disabled=true;
        document.getElementById('drpdescat5').disabled=true;
        
        chkstatus(FlagStatus);
		if(document.getElementById('btnNew').disabled==false)
		{
					   
				document.getElementById('btnNew').focus();
		}
						
		else
		{
		    document.getElementById('btnNew').disabled=false;
		    document.getElementById('btnNew').focus();
						
	    }						
					
			hiddentext="";		
	    	givebuttonpermission(formname);
				return false;				
        
        

}

function call_chkmapmodify(res)
{
    var ds=res.value;
    if(ds.Tables[0].Rows.length>0)
    {
        alert("This mapping has already been there try another");
        return false;
    }
    else
    {
        var comp_code=document.getElementById('hiddencompcode').value;
        var sourceregion=document.getElementById('drpsouregion').value;
        var sourcevariable=document.getElementById('drpsouvariable').value;
        var sourcecat1=document.getElementById('drpsoucat1').value;
        var sourcecat2=document.getElementById('drpsoucat2').value;
        var sourcecat3=document.getElementById('drpsoucat3').value;
        var sourcecat4=document.getElementById('drpsoucat4').value;
        var sourcecat5=document.getElementById('drpsoucat5').value;
        var destedit=document.getElementById('drpdesedition').value;
        var destreg=document.getElementById('drpdesregion').value;
        var destvar=document.getElementById('drpdesvariable').value;
        var destcat1=document.getElementById('drpdescat1').value;
        var destcat2=document.getElementById('drpdescat2').value;
        var destcat3=document.getElementById('drpdescat3').value;
        var destcat4=document.getElementById('drpdescat4').value;
        var destcat5=document.getElementById('drpdescat5').value;
        
        cat_mapping.modifymapping(comp_code,sourceregion,sourcevariable,sourcecat1,sourcecat2,sourcecat3,sourcecat4,sourcecat5,destedit,destreg,destvar,destcat1,destcat2,destcat3,destcat4,destcat5,primary);    
        cat_mapping.executemapping(comp_code,gb_sourceregion,gb_sourcevariable,gb_sourcecat1,gb_sourcecat2,gb_sourcecat3,gb_sourcecat4,gb_sourcecat5,gb_destedit,gb_destreg,gb_destvar,gb_destcat1,gb_destcat2,gb_destcat3,gb_destcat4,gb_destcat5,call_executeaftermodify);    
        alert("Mapping updated");        
    
    }
        document.getElementById('drpsouregion').disabled=true;
        document.getElementById('drpsouvariable').disabled=true;
        document.getElementById('drpsoucat1').disabled=true;
        document.getElementById('drpsoucat2').disabled=true;
        document.getElementById('drpsoucat3').disabled=true;
        document.getElementById('drpsoucat4').disabled=true;
        document.getElementById('drpsoucat5').disabled=true;
        document.getElementById('drpdesedition').disabled=true;
        document.getElementById('drpdesregion').disabled=true;
        document.getElementById('drpdesvariable').disabled=true;
        document.getElementById('drpdescat1').disabled=true;
        document.getElementById('drpdescat2').disabled=true;
        document.getElementById('drpdescat3').disabled=true;
        document.getElementById('drpdescat4').disabled=true;
        document.getElementById('drpdescat5').disabled=true;  
            updateStatus();
			hiddentext="";		
			if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==(ds_exe.Tables[0].Rows.length-1))
              {
                document.getElementById('btnNext').disabled=true;
	            document.getElementById('btnLast').disabled=true;
              } 
              document.getElementById('btnModify').disabled=true;  
    
    return false;
}

function call_executeaftermodify(res)
{
    ds_exe=res.value;

     var compcode=document.getElementById('hiddencompcode').value
        document.getElementById('drpsouregion').value=ds_exe.Tables[0].Rows[z].source_region;
        document.getElementById('drpsouvariable').value=ds_exe.Tables[0].Rows[z].source_variable;;
        document.getElementById('drpsoucat1').value=ds_exe.Tables[0].Rows[z].source_cat1;;
        //////////this is to fill cat2 drpdown
        //fillcat22('drpsoucat1');
        cat_mapping.getadsubcat(compcode,document.getElementById('drpsoucat1').value,call_filladscat1);
        document.getElementById('drpsoucat2').value=ds_exe.Tables[0].Rows[z].source_cat2;
        /////////this is to fill cat3 drpdown
        //fillcat33('drpsoucat2')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat2,compcode,"0",call_bindadcat31);
        //document.getElementById('drpsoucat3').value=ds_exe.Tables[0].Rows[z].source_cat3;;
        ///////this is to fill cat4 drpdown
        //fillcat44('drpsoucat3')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat3,compcode,"2",call_bindadcat51);
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat4,compcode,"1",call_bindadcat41);
        document.getElementById('drpsoucat4').value=ds_exe.Tables[0].Rows[z].source_cat4;;
        /////////this is to fill cat5 drpdown
       // fillcat55('drpsoucat4')
        document.getElementById('drpsoucat5').value=ds_exe.Tables[0].Rows[z].source_cat5;
        
        document.getElementById('drpdesedition').value=ds_exe.Tables[0].Rows[z].destination_edition;;
        document.getElementById('drpdesregion').value=ds_exe.Tables[0].Rows[z].destination_region;;
        document.getElementById('drpdesvariable').value=ds_exe.Tables[0].Rows[z].destination_variable;;
        
        document.getElementById('drpdescat1').value=ds_exe.Tables[0].Rows[z].destination_cat1;;
        ////////////this is to fill destination cat2 drpdown
        //fillcat2('drpdescat1');
        cat_mapping.getadsubcat(compcode,document.getElementById('drpdescat1').value,call_filladscat1desc);
        document.getElementById('drpdescat2').value=ds_exe.Tables[0].Rows[z].destination_cat2;;
        //////////this is to fill destination cat3 drpdow
        //fillcat3('drpdescat2')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat2,compcode,"0",call_bindadcat3desc);
        //document.getElementById('drpdescat3').value=ds_exe.Tables[0].Rows[0].destination_cat3;;
        /////////this is to fill destination cat4 drpdow
         //fillcat4('drpdescat3')
         cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat3,compcode,"2",call_bindadcat5desc);
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat4,compcode,"1",call_bindadcat4desc);
        document.getElementById('drpdescat4').value=ds_exe.Tables[0].Rows[z].destination_cat4;;
        ////////////this is to fill destination cat5 drpdown
         //fillcat5('drpdescat4')
        document.getElementById('drpdescat5').value=ds_exe.Tables[0].Rows[z].destination_cat5;;
        primary=ds_exe.Tables[0].Rows[z].code_id


}

function modifycatmap()
{
     
        
        document.getElementById('drpsouregion').disabled=false;
        document.getElementById('drpsouvariable').disabled=false;
        document.getElementById('drpsoucat1').disabled=false;
        document.getElementById('drpsoucat2').disabled=false;
        document.getElementById('drpsoucat3').disabled=false;
        document.getElementById('drpsoucat4').disabled=false;
        document.getElementById('drpsoucat5').disabled=false;
        document.getElementById('drpdesedition').disabled=false;
        document.getElementById('drpdesregion').disabled=false;
        document.getElementById('drpdesvariable').disabled=false;
        document.getElementById('drpdescat1').disabled=false;
        document.getElementById('drpdescat2').disabled=false;
        document.getElementById('drpdescat3').disabled=false;
        document.getElementById('drpdescat4').disabled=false;
        document.getElementById('drpdescat5').disabled=false;   
        
        hiddentext="mod"
        
        chkstatus(FlagStatus);

		document.getElementById('btnSave').disabled = false;
		document.getElementById('btnQuery').disabled = true;
		document.getElementById('btnExecute').disabled=true;
		document.getElementById('btnModify').disabled=true;
		
		return false;
				
			
				   

}

function querycatmap()
{
        document.getElementById('drpsouregion').disabled=false;
        document.getElementById('drpsouvariable').disabled=false;
        document.getElementById('drpsoucat1').disabled=false;
        document.getElementById('drpsoucat2').disabled=false;
        document.getElementById('drpsoucat3').disabled=false;
        document.getElementById('drpsoucat4').disabled=false;
        document.getElementById('drpsoucat5').disabled=false;
        document.getElementById('drpdesedition').disabled=false;
        document.getElementById('drpdesregion').disabled=false;
        document.getElementById('drpdesvariable').disabled=false;
        document.getElementById('drpdescat1').disabled=false;
        document.getElementById('drpdescat2').disabled=false;
        document.getElementById('drpdescat3').disabled=false;
        document.getElementById('drpdescat4').disabled=false;
        document.getElementById('drpdescat5').disabled=false;  
        
        document.getElementById('drpsouregion').value="0";
        document.getElementById('drpsouvariable').value="0";
        document.getElementById('drpsoucat1').value="0";
        document.getElementById('drpsoucat2').options.length=0;
        document.getElementById('drpsoucat3').options.length=0;;
        document.getElementById('drpsoucat4').options.length=0;;
        document.getElementById('drpsoucat5').options.length=0;;
        document.getElementById('drpdesedition').value="0";
        document.getElementById('drpdesregion').value="0";
        document.getElementById('drpdesvariable').value="0";
        document.getElementById('drpdescat1').value="0"
        document.getElementById('drpdescat2').options.length=0;;
        document.getElementById('drpdescat3').options.length=0;;
        document.getElementById('drpdescat4').options.length=0;;
        document.getElementById('drpdescat5').options.length=0;;
        
        hiddentext==""
        
        z=0;
        chkstatus(FlagStatus);
	    document.getElementById('btnNew').disabled=true;				
	    document.getElementById('btnQuery').disabled=true;
	    document.getElementById('btnExecute').disabled=false;
	    document.getElementById('btnSave').disabled=true;
	    
	    return false;

}

function executecatmap()
{
        var comp_code=document.getElementById('hiddencompcode').value;
        var sourceregion=document.getElementById('drpsouregion').value;
        gb_sourceregion=sourceregion
        var sourcevariable=document.getElementById('drpsouvariable').value;
        gb_sourcevariable=sourcevariable
        var sourcecat1=document.getElementById('drpsoucat1').value;
        gb_sourcecat1=sourcecat1
        var sourcecat2=document.getElementById('drpsoucat2').value;
        gb_sourcecat2=sourcecat2
        var sourcecat3=document.getElementById('drpsoucat3').value;
        gb_sourcecat3=sourcecat3
        var sourcecat4=document.getElementById('drpsoucat4').value;
        gb_sourcecat4=sourcecat4
        var sourcecat5=document.getElementById('drpsoucat5').value;
        gb_sourcecat5=sourcecat5
        var destedit=document.getElementById('drpdesedition').value;
        gb_destedit=destedit
        var destreg=document.getElementById('drpdesregion').value;
        gb_destreg=destreg
        var destvar=document.getElementById('drpdesvariable').value;
        gb_destvar=destvar
        var destcat1=document.getElementById('drpdescat1').value;
        gb_destcat1=destcat1
        var destcat2=document.getElementById('drpdescat2').value;
        gb_destcat2=destcat2
        var destcat3=document.getElementById('drpdescat3').value;
        gb_destcat3=destcat3
        var destcat4=document.getElementById('drpdescat4').value;
        gb_destcat4=destcat4
        var destcat5=document.getElementById('drpdescat5').value;
        gb_destcat5=destcat5
        z=0;
        hiddentext=="";
        
        cat_mapping.executemapping(comp_code,sourceregion,sourcevariable,sourcecat1,sourcecat2,sourcecat3,sourcecat4,sourcecat5,destedit,destreg,destvar,destcat1,destcat2,destcat3,destcat4,destcat5,call_executeresult);    
        
        document.getElementById('drpsouregion').disabled=true;
        document.getElementById('drpsouvariable').disabled=true;
        document.getElementById('drpsoucat1').disabled=true;
        document.getElementById('drpsoucat2').disabled=true;
        document.getElementById('drpsoucat3').disabled=true;
        document.getElementById('drpsoucat4').disabled=true;
        document.getElementById('drpsoucat5').disabled=true;
        document.getElementById('drpdesedition').disabled=true;
        document.getElementById('drpdesregion').disabled=true;
        document.getElementById('drpdesvariable').disabled=true;
        document.getElementById('drpdescat1').disabled=true;
        document.getElementById('drpdescat2').disabled=true;
        document.getElementById('drpdescat3').disabled=true;
        document.getElementById('drpdescat4').disabled=true;
        document.getElementById('drpdescat5').disabled=true;  
        
        updateStatus();
        document.getElementById('btnfirst').disabled=true;				
		document.getElementById('btnnext').disabled=false;					
		document.getElementById('btnprevious').disabled=true;			
		document.getElementById('btnlast').disabled=false;
//		document.getElementById('btnModify').disabled=false;
//						
//		document.getElementById('btnNew').disabled=true;
//		document.getElementById('btnExecute').disabled=true;
//						
						
//		document.getElementById('btnDelete').disabled=false;
        
        return false;
    


}

function call_executeresult(res)
{
        ds_exe=res.value;
        if(ds_exe.Tables[0].Rows.length<=0)
        {
            alert("Search produce no result");
            cancelcatmap('cat_mapping');
            return false;
        }
        z=0;
        var compcode=document.getElementById('hiddencompcode').value
        document.getElementById('drpsouregion').value=ds_exe.Tables[0].Rows[0].source_region;
        document.getElementById('drpsouvariable').value=ds_exe.Tables[0].Rows[0].source_variable;;
        document.getElementById('drpsoucat1').value=ds_exe.Tables[0].Rows[0].source_cat1;;
        //////////this is to fill cat2 drpdown
        //fillcat22('drpsoucat1');
        cat_mapping.getadsubcat(compcode,document.getElementById('drpsoucat1').value,call_filladscat1);
        document.getElementById('drpsoucat2').value=ds_exe.Tables[0].Rows[0].source_cat2;
        /////////this is to fill cat3 drpdown
        //fillcat33('drpsoucat2')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[0].source_cat2,compcode,"0",call_bindadcat31);
        //document.getElementById('drpsoucat3').value=ds_exe.Tables[0].Rows[0].source_cat3;;
        ///////this is to fill cat4 drpdown
        //fillcat44('drpsoucat3')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[0].source_cat3,compcode,"2",call_bindadcat51);
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[0].source_cat4,compcode,"1",call_bindadcat41);
        document.getElementById('drpsoucat4').value=ds_exe.Tables[0].Rows[0].source_cat4;;
        /////////this is to fill cat5 drpdown
       // fillcat55('drpsoucat4')
        document.getElementById('drpsoucat5').value=ds_exe.Tables[0].Rows[0].source_cat5;
        
        document.getElementById('drpdesedition').value=ds_exe.Tables[0].Rows[0].destination_edition;;
        document.getElementById('drpdesregion').value=ds_exe.Tables[0].Rows[0].destination_region;;
        document.getElementById('drpdesvariable').value=ds_exe.Tables[0].Rows[0].destination_variable;;
        
        document.getElementById('drpdescat1').value=ds_exe.Tables[0].Rows[0].destination_cat1;;
        ////////////this is to fill destination cat2 drpdown
        //fillcat2('drpdescat1');
        cat_mapping.getadsubcat(compcode,document.getElementById('drpdescat1').value,call_filladscat1desc);
        document.getElementById('drpdescat2').value=ds_exe.Tables[0].Rows[0].destination_cat2;;
        //////////this is to fill destination cat3 drpdow
        //fillcat3('drpdescat2')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[0].destination_cat2,compcode,"0",call_bindadcat3desc);
        //document.getElementById('drpdescat3').value=ds_exe.Tables[0].Rows[0].destination_cat3;;
        /////////this is to fill destination cat4 drpdow
         //fillcat4('drpdescat3')
         cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[0].destination_cat3,compcode,"2",call_bindadcat5desc);
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[0].destination_cat4,compcode,"1",call_bindadcat4desc);
        document.getElementById('drpdescat4').value=ds_exe.Tables[0].Rows[0].destination_cat4;;
        ////////////this is to fill destination cat5 drpdown
         //fillcat5('drpdescat4')
        document.getElementById('drpdescat5').value=ds_exe.Tables[0].Rows[0].destination_cat5;;
        primary=ds_exe.Tables[0].Rows[0].code_id
        
        if(ds_exe.Tables[0].Rows.length ==1)
			{
			  document.getElementById('btnfirst').disabled=true;				
			  document.getElementById('btnnext').disabled=true;					
			  document.getElementById('btnprevious').disabled=true;			
			  document.getElementById('btnlast').disabled=true;
			}
        
        



}

function firstcatmap()
{
    z=0;
    
        var compcode=document.getElementById('hiddencompcode').value
        document.getElementById('drpsouregion').value=ds_exe.Tables[0].Rows[0].source_region;
        document.getElementById('drpsouvariable').value=ds_exe.Tables[0].Rows[0].source_variable;;
        document.getElementById('drpsoucat1').value=ds_exe.Tables[0].Rows[0].source_cat1;;
        //////////this is to fill cat2 drpdown
        //fillcat22('drpsoucat1');
        cat_mapping.getadsubcat(compcode,document.getElementById('drpsoucat1').value,call_filladscat1);
        document.getElementById('drpsoucat2').value=ds_exe.Tables[0].Rows[0].source_cat2;
        /////////this is to fill cat3 drpdown
        //fillcat33('drpsoucat2')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[0].source_cat2,compcode,"0",call_bindadcat31);
        //document.getElementById('drpsoucat3').value=ds_exe.Tables[0].Rows[0].source_cat3;;
        ///////this is to fill cat4 drpdown
        //fillcat44('drpsoucat3')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[0].source_cat3,compcode,"2",call_bindadcat51);
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[0].source_cat4,compcode,"1",call_bindadcat41);
        document.getElementById('drpsoucat4').value=ds_exe.Tables[0].Rows[0].source_cat4;;
        /////////this is to fill cat5 drpdown
       // fillcat55('drpsoucat4')
        document.getElementById('drpsoucat5').value=ds_exe.Tables[0].Rows[0].source_cat5;
        
        document.getElementById('drpdesedition').value=ds_exe.Tables[0].Rows[0].destination_edition;;
        document.getElementById('drpdesregion').value=ds_exe.Tables[0].Rows[0].destination_region;;
        document.getElementById('drpdesvariable').value=ds_exe.Tables[0].Rows[0].destination_variable;;
        
        document.getElementById('drpdescat1').value=ds_exe.Tables[0].Rows[0].destination_cat1;;
        ////////////this is to fill destination cat2 drpdown
        //fillcat2('drpdescat1');
        cat_mapping.getadsubcat(compcode,document.getElementById('drpdescat1').value,call_filladscat1desc);
        document.getElementById('drpdescat2').value=ds_exe.Tables[0].Rows[0].destination_cat2;;
        //////////this is to fill destination cat3 drpdow
        //fillcat3('drpdescat2')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[0].destination_cat2,compcode,"0",call_bindadcat3desc);
        //document.getElementById('drpdescat3').value=ds_exe.Tables[0].Rows[0].destination_cat3;;
        /////////this is to fill destination cat4 drpdow
         //fillcat4('drpdescat3')
         cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[0].destination_cat3,compcode,"2",call_bindadcat5desc);
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[0].destination_cat4,compcode,"1",call_bindadcat4desc);
        document.getElementById('drpdescat4').value=ds_exe.Tables[0].Rows[0].destination_cat4;;
        ////////////this is to fill destination cat5 drpdown
         //fillcat5('drpdescat4')
        document.getElementById('drpdescat5').value=ds_exe.Tables[0].Rows[0].destination_cat5;;
        primary=ds_exe.Tables[0].Rows[z].code_id
    
    
    updateStatus();

    document.getElementById('btnfirst').disabled=true;				
	document.getElementById('btnprevious').disabled=true;
	return false;

}
function lastcatmap()
{
    z=ds_exe.Tables[0].Rows.length-1;
    
        var compcode=document.getElementById('hiddencompcode').value
        document.getElementById('drpsouregion').value=ds_exe.Tables[0].Rows[z].source_region;
        document.getElementById('drpsouvariable').value=ds_exe.Tables[0].Rows[z].source_variable;;
        document.getElementById('drpsoucat1').value=ds_exe.Tables[0].Rows[z].source_cat1;;
        //////////this is to fill cat2 drpdown
        //fillcat22('drpsoucat1');
        cat_mapping.getadsubcat(compcode,document.getElementById('drpsoucat1').value,call_filladscat1);
        document.getElementById('drpsoucat2').value=ds_exe.Tables[0].Rows[z].source_cat2;
        /////////this is to fill cat3 drpdown
        //fillcat33('drpsoucat2')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat2,compcode,"0",call_bindadcat31);
        //document.getElementById('drpsoucat3').value=ds_exe.Tables[0].Rows[z].source_cat3;;
        ///////this is to fill cat4 drpdown
        //fillcat44('drpsoucat3')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat3,compcode,"2",call_bindadcat51);
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat4,compcode,"1",call_bindadcat41);
        document.getElementById('drpsoucat4').value=ds_exe.Tables[0].Rows[z].source_cat4;;
        /////////this is to fill cat5 drpdown
       // fillcat55('drpsoucat4')
        document.getElementById('drpsoucat5').value=ds_exe.Tables[0].Rows[z].source_cat5;
        
        document.getElementById('drpdesedition').value=ds_exe.Tables[0].Rows[z].destination_edition;;
        document.getElementById('drpdesregion').value=ds_exe.Tables[0].Rows[z].destination_region;;
        document.getElementById('drpdesvariable').value=ds_exe.Tables[0].Rows[z].destination_variable;;
        
        document.getElementById('drpdescat1').value=ds_exe.Tables[0].Rows[z].destination_cat1;;
        ////////////this is to fill destination cat2 drpdown
        //fillcat2('drpdescat1');
        cat_mapping.getadsubcat(compcode,document.getElementById('drpdescat1').value,call_filladscat1desc);
        document.getElementById('drpdescat2').value=ds_exe.Tables[0].Rows[z].destination_cat2;;
        //////////this is to fill destination cat3 drpdow
        //fillcat3('drpdescat2')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat2,compcode,"0",call_bindadcat3desc);
        //document.getElementById('drpdescat3').value=ds_exe.Tables[0].Rows[0].destination_cat3;;
        /////////this is to fill destination cat4 drpdow
         //fillcat4('drpdescat3')
         cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat3,compcode,"2",call_bindadcat5desc);
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat4,compcode,"1",call_bindadcat4desc);
        document.getElementById('drpdescat4').value=ds_exe.Tables[0].Rows[z].destination_cat4;;
        ////////////this is to fill destination cat5 drpdown
         //fillcat5('drpdescat4')
        document.getElementById('drpdescat5').value=ds_exe.Tables[0].Rows[z].destination_cat5;;
        primary=ds_exe.Tables[0].Rows[z].code_id
    
        fordisabled();
        
        updateStatus();
			
		        document.getElementById('btnnext').disabled=true;
		        document.getElementById('btnlast').disabled=true;
		        document.getElementById('btnfirst').disabled=false;
		        document.getElementById('btnprevious').disabled=false;



}


function nextcatmap()
{
    var a=ds_exe.Tables[0].Rows.length;
    z++;
	if(z !=-1 && z >= 0)
	{
		if(z <= a-1)
		{
		
		
		    var compcode=document.getElementById('hiddencompcode').value
        document.getElementById('drpsouregion').value=ds_exe.Tables[0].Rows[z].source_region;
        document.getElementById('drpsouvariable').value=ds_exe.Tables[0].Rows[z].source_variable;;
        document.getElementById('drpsoucat1').value=ds_exe.Tables[0].Rows[z].source_cat1;;
        //////////this is to fill cat2 drpdown
        //fillcat22('drpsoucat1');
        cat_mapping.getadsubcat(compcode,document.getElementById('drpsoucat1').value,call_filladscat1);
        document.getElementById('drpsoucat2').value=ds_exe.Tables[0].Rows[z].source_cat2;
        /////////this is to fill cat3 drpdown
        //fillcat33('drpsoucat2')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat2,compcode,"0",call_bindadcat31);
        //document.getElementById('drpsoucat3').value=ds_exe.Tables[0].Rows[z].source_cat3;;
        ///////this is to fill cat4 drpdown
        //fillcat44('drpsoucat3')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat3,compcode,"2",call_bindadcat51);
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat4,compcode,"1",call_bindadcat41);
        document.getElementById('drpsoucat4').value=ds_exe.Tables[0].Rows[z].source_cat4;;
        /////////this is to fill cat5 drpdown
       // fillcat55('drpsoucat4')
        document.getElementById('drpsoucat5').value=ds_exe.Tables[0].Rows[z].source_cat5;
        
        document.getElementById('drpdesedition').value=ds_exe.Tables[0].Rows[z].destination_edition;;
        document.getElementById('drpdesregion').value=ds_exe.Tables[0].Rows[z].destination_region;;
        document.getElementById('drpdesvariable').value=ds_exe.Tables[0].Rows[z].destination_variable;;
        
        document.getElementById('drpdescat1').value=ds_exe.Tables[0].Rows[z].destination_cat1;;
        ////////////this is to fill destination cat2 drpdown
        //fillcat2('drpdescat1');
        cat_mapping.getadsubcat(compcode,document.getElementById('drpdescat1').value,call_filladscat1desc);
        document.getElementById('drpdescat2').value=ds_exe.Tables[0].Rows[z].destination_cat2;;
        //////////this is to fill destination cat3 drpdow
        //fillcat3('drpdescat2')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat2,compcode,"0",call_bindadcat3desc);
        //document.getElementById('drpdescat3').value=ds_exe.Tables[0].Rows[0].destination_cat3;;
        /////////this is to fill destination cat4 drpdow
         //fillcat4('drpdescat3')
         cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat3,compcode,"2",call_bindadcat5desc);
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat4,compcode,"1",call_bindadcat4desc);
        document.getElementById('drpdescat4').value=ds_exe.Tables[0].Rows[z].destination_cat4;;
        ////////////this is to fill destination cat5 drpdown
         //fillcat5('drpdescat4')
        document.getElementById('drpdescat5').value=ds_exe.Tables[0].Rows[z].destination_cat5;;
            primary=ds_exe.Tables[0].Rows[z].code_id
        
            fordisabled();  
		    updateStatus();
		    
			document.getElementById('btnnext').disabled=false;
			document.getElementById('btnlast').disabled=false;
			document.getElementById('btnfirst').disabled=false;
			document.getElementById('btnprevious').disabled=false;
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
	}
	return false;
}



function prevcatmap()
{
     var a=ds_exe.Tables[0].Rows.length;
    z--;
  if(z != -1)
	{
			if(z >= 0 && z <= a-1)
			{
		        var compcode=document.getElementById('hiddencompcode').value
        document.getElementById('drpsouregion').value=ds_exe.Tables[0].Rows[z].source_region;
        document.getElementById('drpsouvariable').value=ds_exe.Tables[0].Rows[z].source_variable;;
        document.getElementById('drpsoucat1').value=ds_exe.Tables[0].Rows[z].source_cat1;;
        //////////this is to fill cat2 drpdown
        //fillcat22('drpsoucat1');
        cat_mapping.getadsubcat(compcode,document.getElementById('drpsoucat1').value,call_filladscat1);
        document.getElementById('drpsoucat2').value=ds_exe.Tables[0].Rows[z].source_cat2;
        /////////this is to fill cat3 drpdown
        //fillcat33('drpsoucat2')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat2,compcode,"0",call_bindadcat31);
        //document.getElementById('drpsoucat3').value=ds_exe.Tables[0].Rows[z].source_cat3;;
        ///////this is to fill cat4 drpdown
        //fillcat44('drpsoucat3')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat3,compcode,"2",call_bindadcat51);
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat4,compcode,"1",call_bindadcat41);
        document.getElementById('drpsoucat4').value=ds_exe.Tables[0].Rows[z].source_cat4;;
        /////////this is to fill cat5 drpdown
       // fillcat55('drpsoucat4')
        document.getElementById('drpsoucat5').value=ds_exe.Tables[0].Rows[z].source_cat5;
        
        document.getElementById('drpdesedition').value=ds_exe.Tables[0].Rows[z].destination_edition;;
        document.getElementById('drpdesregion').value=ds_exe.Tables[0].Rows[z].destination_region;;
        document.getElementById('drpdesvariable').value=ds_exe.Tables[0].Rows[z].destination_variable;;
        
        document.getElementById('drpdescat1').value=ds_exe.Tables[0].Rows[z].destination_cat1;;
        ////////////this is to fill destination cat2 drpdown
        //fillcat2('drpdescat1');
        cat_mapping.getadsubcat(compcode,document.getElementById('drpdescat1').value,call_filladscat1desc);
        document.getElementById('drpdescat2').value=ds_exe.Tables[0].Rows[z].destination_cat2;;
        //////////this is to fill destination cat3 drpdow
        //fillcat3('drpdescat2')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat2,compcode,"0",call_bindadcat3desc);
        //document.getElementById('drpdescat3').value=ds_exe.Tables[0].Rows[0].destination_cat3;;
        /////////this is to fill destination cat4 drpdow
         //fillcat4('drpdescat3')
         cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat3,compcode,"2",call_bindadcat5desc);
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat4,compcode,"1",call_bindadcat4desc);
        document.getElementById('drpdescat4').value=ds_exe.Tables[0].Rows[z].destination_cat4;;
        ////////////this is to fill destination cat5 drpdown
         //fillcat5('drpdescat4')
        document.getElementById('drpdescat5').value=ds_exe.Tables[0].Rows[z].destination_cat5;;
                primary=ds_exe.Tables[0].Rows[z].code_id
            
                fordisabled(); 
		    
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
	{		    document.getElementById('btnnext').disabled=false;
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


function deletecatmap()
{
            updateStatus();
		   
			var compcode=document.getElementById('hiddencompcode').value;		
		    var boolReturn = confirm("Are you sure you wish to delete this?");
		    if(boolReturn==1)
		    {
		        alert("Data deleted");
		        cat_mapping.deletecatmap(primary,compcode);
		        cat_mapping.executemapping(compcode,gb_sourceregion,gb_sourcevariable,gb_sourcecat1,gb_sourcecat2,gb_sourcecat3,gb_sourcecat4,gb_sourcecat5,gb_destedit,gb_destreg,gb_destvar,gb_destcat1,gb_destcat2,gb_destcat3,gb_destcat4,gb_destcat5,call_executeafterdelete);    
		    
		    }

            return false;
}

function call_executeafterdelete(res)
{
    ds_exe=res.value;
    var len=ds_exe.Tables[0].Rows.length-1
    if(ds_exe.Tables[0].Rows.length<=0)
    {
        alert("No more data to be deleted");
        cancelcatmap('cat_mapping');
        return false;
    
    }
    else if(z>=len || z==-1)
	{
	z=0;
	    var compcode=document.getElementById('hiddencompcode').value
        document.getElementById('drpsouregion').value=ds_exe.Tables[0].Rows[z].source_region;
        document.getElementById('drpsouvariable').value=ds_exe.Tables[0].Rows[z].source_variable;;
        document.getElementById('drpsoucat1').value=ds_exe.Tables[0].Rows[z].source_cat1;;
        //////////this is to fill cat2 drpdown
        //fillcat22('drpsoucat1');
        cat_mapping.getadsubcat(compcode,document.getElementById('drpsoucat1').value,call_filladscat1);
        document.getElementById('drpsoucat2').value=ds_exe.Tables[0].Rows[z].source_cat2;
        /////////this is to fill cat3 drpdown
        //fillcat33('drpsoucat2')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat2,compcode,"0",call_bindadcat31);
        //document.getElementById('drpsoucat3').value=ds_exe.Tables[0].Rows[z].source_cat3;;
        ///////this is to fill cat4 drpdown
        //fillcat44('drpsoucat3')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat3,compcode,"2",call_bindadcat51);
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat4,compcode,"1",call_bindadcat41);
        document.getElementById('drpsoucat4').value=ds_exe.Tables[0].Rows[z].source_cat4;;
        /////////this is to fill cat5 drpdown
       // fillcat55('drpsoucat4')
        document.getElementById('drpsoucat5').value=ds_exe.Tables[0].Rows[z].source_cat5;
        
        document.getElementById('drpdesedition').value=ds_exe.Tables[0].Rows[z].destination_edition;;
        document.getElementById('drpdesregion').value=ds_exe.Tables[0].Rows[z].destination_region;;
        document.getElementById('drpdesvariable').value=ds_exe.Tables[0].Rows[z].destination_variable;;
        
        document.getElementById('drpdescat1').value=ds_exe.Tables[0].Rows[z].destination_cat1;;
        ////////////this is to fill destination cat2 drpdown
        //fillcat2('drpdescat1');
        cat_mapping.getadsubcat(compcode,document.getElementById('drpdescat1').value,call_filladscat1desc);
        document.getElementById('drpdescat2').value=ds_exe.Tables[0].Rows[z].destination_cat2;;
        //////////this is to fill destination cat3 drpdow
        //fillcat3('drpdescat2')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat2,compcode,"0",call_bindadcat3desc);
        //document.getElementById('drpdescat3').value=ds_exe.Tables[0].Rows[0].destination_cat3;;
        /////////this is to fill destination cat4 drpdow
         //fillcat4('drpdescat3')
         cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat3,compcode,"2",call_bindadcat5desc);
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat4,compcode,"1",call_bindadcat4desc);
        document.getElementById('drpdescat4').value=ds_exe.Tables[0].Rows[z].destination_cat4;;
        ////////////this is to fill destination cat5 drpdown
         //fillcat5('drpdescat4')
        document.getElementById('drpdescat5').value=ds_exe.Tables[0].Rows[z].destination_cat5;;
        primary=ds_exe.Tables[0].Rows[z].code_id
	
	}
	else
	{
	            var compcode=document.getElementById('hiddencompcode').value
        document.getElementById('drpsouregion').value=ds_exe.Tables[0].Rows[z].source_region;
        document.getElementById('drpsouvariable').value=ds_exe.Tables[0].Rows[z].source_variable;;
        document.getElementById('drpsoucat1').value=ds_exe.Tables[0].Rows[z].source_cat1;;
        //////////this is to fill cat2 drpdown
        //fillcat22('drpsoucat1');
        cat_mapping.getadsubcat(compcode,document.getElementById('drpsoucat1').value,call_filladscat1);
        document.getElementById('drpsoucat2').value=ds_exe.Tables[0].Rows[z].source_cat2;
        /////////this is to fill cat3 drpdown
        //fillcat33('drpsoucat2')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat2,compcode,"0",call_bindadcat31);
        //document.getElementById('drpsoucat3').value=ds_exe.Tables[0].Rows[z].source_cat3;;
        ///////this is to fill cat4 drpdown
        //fillcat44('drpsoucat3')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat3,compcode,"2",call_bindadcat51);
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].source_cat4,compcode,"1",call_bindadcat41);
        document.getElementById('drpsoucat4').value=ds_exe.Tables[0].Rows[z].source_cat4;;
        /////////this is to fill cat5 drpdown
       // fillcat55('drpsoucat4')
        document.getElementById('drpsoucat5').value=ds_exe.Tables[0].Rows[z].source_cat5;
        
        document.getElementById('drpdesedition').value=ds_exe.Tables[0].Rows[z].destination_edition;;
        document.getElementById('drpdesregion').value=ds_exe.Tables[0].Rows[z].destination_region;;
        document.getElementById('drpdesvariable').value=ds_exe.Tables[0].Rows[z].destination_variable;;
        
        document.getElementById('drpdescat1').value=ds_exe.Tables[0].Rows[z].destination_cat1;;
        ////////////this is to fill destination cat2 drpdown
        //fillcat2('drpdescat1');
        cat_mapping.getadsubcat(compcode,document.getElementById('drpdescat1').value,call_filladscat1desc);
        document.getElementById('drpdescat2').value=ds_exe.Tables[0].Rows[z].destination_cat2;;
        //////////this is to fill destination cat3 drpdow
        //fillcat3('drpdescat2')
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat2,compcode,"0",call_bindadcat3desc);
        //document.getElementById('drpdescat3').value=ds_exe.Tables[0].Rows[0].destination_cat3;;
        /////////this is to fill destination cat4 drpdow
         //fillcat4('drpdescat3')
         cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat3,compcode,"2",call_bindadcat5desc);
        cat_mapping.bindadcat3(ds_exe.Tables[0].Rows[z].destination_cat4,compcode,"1",call_bindadcat4desc);
        document.getElementById('drpdescat4').value=ds_exe.Tables[0].Rows[z].destination_cat4;;
        ////////////this is to fill destination cat5 drpdown
         //fillcat5('drpdescat4')
        document.getElementById('drpdescat5').value=ds_exe.Tables[0].Rows[z].destination_cat5;;
                primary=ds_exe.Tables[0].Rows[z].code_id
	
	}
	            if (z==0)
               {
                document.getElementById('btnfirst').disabled=true;
                document.getElementById('btnprevious').disabled=true;
                }

             if(z==ds_exe.Tables[0].Rows.length)
              {
                document.getElementById('btnnext').disabled=true;
	            document.getElementById('btnlast').disabled=true;
              }       
              return false;

}

function exitcatmap()
{
            if(confirm("Do You Want To Skip This Page"))
			{
				window.close();
				return false;
			}
			return false;
}


function fordisabled()
{
         document.getElementById('drpsouregion').disabled=true;
        document.getElementById('drpsouvariable').disabled=true;
        document.getElementById('drpsoucat1').disabled=true;
        document.getElementById('drpsoucat2').disabled=true;
        document.getElementById('drpsoucat3').disabled=true;
        document.getElementById('drpsoucat4').disabled=true;
        document.getElementById('drpsoucat5').disabled=true;
        document.getElementById('drpdesedition').disabled=true;
        document.getElementById('drpdesregion').disabled=true;
        document.getElementById('drpdesvariable').disabled=true;
        document.getElementById('drpdescat1').disabled=true;
        document.getElementById('drpdescat2').disabled=true;
        document.getElementById('drpdescat3').disabled=true;
        document.getElementById('drpdescat4').disabled=true;
        document.getElementById('drpdescat5').disabled=true;  

}