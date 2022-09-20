// JScript File
var browser=navigator.appName;

function ref_fileclick()
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
         document.getElementById('ddlPublication').focus();
         return false;
      }
      if(document.getElementById('ddlCenter').value=="0")
      {
         alert("Please Select Center ");
         document.getElementById('ddlCenter').focus();
         return false;
      }
      if(document.getElementById('ddlEdition').value=="0")
      {
         alert("Please Select Edition ");
         document.getElementById('ddlEdition').focus();
         return false;
      }
      if(document.getElementById('ddlSupplement').value=="0")
      {
         alert("Please Select Supplement ");
         document.getElementById('ddlSupplement').focus();
         return false;
      }
      
      if(document.getElementById('txtFilepath').value=="0")
      {
         alert("Please Enter Path ");
         document.getElementById('txtFilepath').focus();
         return false;
      }
        
        var compcode=document.getElementById('hiddencompcode').value;
       // var userid=document.getElementById('hiddenuserid').value;
        var pubdate=document.getElementById('PubDate').value;       
        var pubcode=document.getElementById('ddlPublication').value;
	    var centercode=document.getElementById('ddlCenter').value;
	    var editioncode=document.getElementById('ddlEdition').value;
	    var edi="";
	    for(var i=0;i<document.getElementById('ddlEdition').options.length;i++)
	    {
	        if(document.getElementById('ddlEdition').options[i].selected==true)
	        {
	            if(edi=="")
	                edi=document.getElementById('ddlEdition').options[i].value;
	            else
	                edi=edi + "," + document.getElementById('ddlEdition').options[i].value;    
	        }
	    }
	    var suppcode=document.getElementById('ddlSupplement').value;
	     var dateformat=document.getElementById('hiddendateformat').value;
	    genReference.ReferenceFileDict(compcode,pubdate,pubcode,centercode,edi,suppcode,dateformat,callbackReferenceFile);
	    return false;    
}


var updatestatus="";
function callbackReferenceFile(response)
{
    var ds_ref=response.value;
     var fso = new ActiveXObject("Scripting.FileSystemObject");// COMMENTED BY SAURABH 
    
    if(ds_ref==null)
    {
        alert(response.error.description);
        return false;
     }   
    if(ds_ref.Tables[0].Rows.length!=0)
    {
        var xtg_filename="";
        var pubdate=document.getElementById('PubDate').value;
        //Main server Path....
        var eps_path=document.getElementById('txtFilepath').value+"Category\\";
        
        var ref_path=document.getElementById('txtFilepath').value+"xtg\\";
        ref_path=document.getElementById('txtFilepath').value+"xtg\\"; // for mapping path
        if(fso.FolderExists(document.getElementById('txtFilepath').value+ "Reffile")){
	        a="";
	    }
        else
            var newfolder=fso.CreateFolder(document.getElementById('txtFilepath').value + "Reffile");
         
              if(fso.FolderExists(document.getElementById('txtFilepath').value+ "xtg")){
	            a="";
	        }
            else
                var newfolder=fso.CreateFolder(ref_path);    
        /* Ref path for CD*/
          var ref_path_CD=document.getElementById('txtFilepath').value+"eps\\";
        
          if(fso.FolderExists(document.getElementById('txtFilepath').value+"eps")){
	        a="";
	    }
        else
            var newfolder=fso.CreateFolder(document.getElementById('txtFilepath').value+"eps");    
        /* for getting month name..    */
       
         var dt=pubdate.split("/");
        if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
        {
               
                pubdate=dt[1]+ "/" + dt[0] + "/" + dt[2];
        }
        else if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
        {
                pubdate=dt[1]+ "/" + dt[2] + "/" + dt[0];
        }
        var my_month=new Date(pubdate);

        
        var month_name=new Array(12);
            month_name[0]="JAN"
            month_name[1]="FEB"
            month_name[2]="MAR"
            month_name[3]="APR"
            month_name[4]="MAY"
            month_name[5]="JUN"
            month_name[6]="JUL"
            month_name[7]="AUG"
            month_name[8]="SEP"
            month_name[9]="OCT"
            month_name[10]="NOV"
            month_name[11]="DEC"

            var mon=month_name[my_month.getMonth()]
        
        
        var dt=pubdate.split("/");
        
         var dd="";
         if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
        {
          dd=dt[1]+"-"+mon+"-"+dt[2];
        }
        else  if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
        {
          dd=dt[2]+"-"+mon+"-"+dt[0];
        }
         else  if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
        {
          dd=dt[1]+"-"+mon+"-"+dt[2];
        }
        //var dd=dt[1]+"-"+dt[0]+"-"+dt[2];
        
        var f_hd="Ü"+dd+"Ü";
        var xtg_filename="";
        
        
        
        
        
        
       
        
        
        //generate xtg file *********************************************************
        for(var i=0;i<ds_ref.Tables[0].Rows.length;i++)
        {       
        
            xtg_matter=ds_ref.Tables[0].Rows[i].xtgformat;          
            
            
            //getting Ad_no & insertion number....
            var adno=ds_ref.Tables[0].Rows[i].cio_booking_id.substring(0,3);
             adno=adno+"-"+ds_ref.Tables[0].Rows[i].cio_booking_id.substring(8);
            var insertion_no=ds_ref.Tables[0].Rows[i].no_insert;
            
            
            if(xtg_matter!=null)
            xtg_matter=xtg_matter//+"<$z6>["+adno+"-"+insertion_no+"]<$>";
            
               var localxtgpath=document.getElementById('hiddenxtgfilepath_local').value;
            localxtgpath="z:";
            if(xtg_matter!=null && xtg_matter!="0")
            {
                xtg_filename=ref_path+ds_ref.Tables[0].Rows[i].file_name;
                if(fso.FileExists(xtg_filename))
                    var b = fso.OpenTextFile(xtg_filename, 2); 
                else
                
                   var b=fso.CreateTextFile(xtg_filename,2);
                b.WriteLine(xtg_matter);
                b.Close();
            } 
//            
            /////////////////UPDATED BY SAURABH
            
//             if(xtg_matter!=null)
//            {
//                xtg_filename=ref_path+ds_ref.Tables[0].Rows[i].file_name;
//                
//                
//                                 if(browser!="Microsoft Internet Explorer")
//                                {
//                                    var  httpRequest =null;
//                                    httpRequest= new XMLHttpRequest();
//                                    if (httpRequest.overrideMimeType) {
//                                    httpRequest.overrideMimeType('text/xml'); 
//                                    }
//                                    
//                                    httpRequest.onreadystatechange = function() {alertContents(httpRequest) };
//                         
//                                    httpRequest.open( "GET","savereff_file.aspx?xtg_filename="+xtg_filename+"&compcode="+compcode+"&value="+value+"&pkgname="+pkgname+"&dateday="+dateday, false );
//                                    httpRequest.send('');
//                                    //alert(httpRequest.readyState);
//                                    if (httpRequest.readyState == 4) 
//                                    {
//                                        //alert(httpRequest.status);
//                                        if (httpRequest.status == 200) 
//                                        {
//                                            strtext=httpRequest.responseText;
//                                        }
//                                        else 
//                                        {
//                                            alert('There was a problem with the request.');
//                                        }
//                                    }
//                                }
//                           else
//                           { 
//                                var xml = new ActiveXObject("Microsoft.XMLHTTP");
//                                xml.Open( "GET","savereff_file.aspx?pkgid="+pkgid+"&compcode="+compcode+"&value="+value+"&pkgname="+pkgname+"&dateday="+dateday, false );
//                                    xml.Send();
//                                 strtext=xml.responseText;
//                           }
//                
//            
//            
//            }
            

            
            
            
             //copying xtg into  local file path...
            
         
//            if(ref_path!=localxtgpath)      
//            if(xtg_filename!="")      
//            fso.CopyFile(xtg_filename,localxtgpath);
            
            
            
        }
        //*************************************************************************
        //generate reference file
        
        
        
        var catname="";
        var subcatename="";
        var cat3="";
        var edi="";
          for(var i=0;i<document.getElementById('ddlEdition').options.length;i++)
	    {
	        if(document.getElementById('ddlEdition').options[i].selected==true)
	        {
	            if(edi=="")
	                edi=document.getElementById('ddlEdition').options[i].value;
	            else
	                edi=edi + "+" + document.getElementById('ddlEdition').options[i].value;    
	        }
	    }
	    if(fso.FolderExists(document.getElementById('txtFilepath').value+ "Reffile")){
	        a="";
	    }
        else
            var newfolder=fso.CreateFolder(document.getElementById('txtFilepath').value+ "Reffile");
	    
        var ref_filename=document.getElementById('txtFilepath').value+ "Reffile" + "\\" + edi + "-" + dd+".txt";
        var mat_ref_filename=document.getElementById('txtFilepath').value+ "Reffile" + "\\" + edi + "-" + dd+"-missing.txt";
        if(fso.FileExists(ref_filename))
           var b = fso.OpenTextFile(ref_filename, 2);
        else
           var b=fso.CreateTextFile(ref_filename,2);
           
        b.WriteLine(f_hd);
        // for material missing CIOID
         if(fso.FileExists(mat_ref_filename))
           var miss = fso.OpenTextFile(mat_ref_filename, 2);
        else
           var miss=fso.CreateTextFile(mat_ref_filename,2);
           
       // b.WriteBlankLines(1);   
        for(var i=0;i<ds_ref.Tables[0].Rows.length;i++)
        {
        if(ds_ref.Tables[0].Rows[i].file_name==null)
            miss.WriteLine(ds_ref.Tables[0].Rows[i].cio_booking_id);   
           // if(ds_ref.Tables[0].Rows[i].file_name!=null)
            //{
            if(ds_ref.Tables[0].Rows[i].file_name==null)
            {
               if(ds_ref.Tables[0].Rows[i].IP==null || ds_ref.Tables[0].Rows[i].IP=="")
                 xtg_filename=localxtgpath + "\\" +ds_ref.Tables[0].Rows[i].cio_booking_id + ".txt"; 
               else
               {
                 xtg_filename=ds_ref.Tables[0].Rows[i].IP +"\\xtg\\" +ds_ref.Tables[0].Rows[i].cio_booking_id + ".txt";   
               }  
             }   
            else
            {
                 if(ds_ref.Tables[0].Rows[i].IP==null || ds_ref.Tables[0].Rows[i].IP=="")
                    xtg_filename=localxtgpath + "\\" +ds_ref.Tables[0].Rows[i].file_name; 
                 else
                 {
                    xtg_filename=ds_ref.Tables[0].Rows[i].IP +"\\xtg\\" + ds_ref.Tables[0].Rows[i].file_name;    
                 }   
             }   
            if(catname!=ds_ref.Tables[0].Rows[i].category)
            {
               
                if(ds_ref.Tables[0].Rows[i].catfilename!=null)
                {               
                //b.WriteLine("¶"+eps_path+ds_ref.Tables[0].Rows[i].catfilename+",0.6*1,"+"¶");           
                 b.WriteLine("ù"+ds_ref.Tables[0].Rows[i].catfilename+"ù");      
              
                }
                else
                {
                     b.WriteLine("ù"+ds_ref.Tables[0].Rows[i].category+"ù");      
                }
                catname=ds_ref.Tables[0].Rows[i].category;
                
            }
            if(ds_ref.Tables[0].Rows[i].Subcategory!=null)
            {
                if(subcatename!=ds_ref.Tables[0].Rows[i].Subcategory)
                {
                     if(ds_ref.Tables[0].Rows[i].CAT2!=null)
                    {                    
                            b.WriteLine("¶"+ds_ref.Tables[0].Rows[i].CAT2+"¶");  
                    }
                    else if(ds_ref.Tables[0].Rows[i].scatfilename!=null)
                    {                    
                            b.WriteLine("¶"+ds_ref.Tables[0].Rows[i].scatfilename+"¶");  
                    }
                    else
                    {
                         b.WriteLine("¶"+ds_ref.Tables[0].Rows[i].Subcategory+"¶");  
                    }
                  //  b.WriteBlankLines(1);
                    subcatename=ds_ref.Tables[0].Rows[i].Subcategory;
                }
            }
            if(ds_ref.Tables[0].Rows[i].category3!=null)
            {
              if(cat3!=ds_ref.Tables[0].Rows[i].category3)
            {
               
                if(ds_ref.Tables[0].Rows[i].CAT3!=null)
                {               
                //b.WriteLine("¶"+eps_path+ds_ref.Tables[0].Rows[i].catfilename+",0.6*1,"+"¶");           
                 b.WriteLine("ÿ"+ds_ref.Tables[0].Rows[i].CAT3+"ÿ");      
                b.WriteBlankLines(1);
                }
                else
                {
                      b.WriteLine("ÿ"+ds_ref.Tables[0].Rows[i].category3+"ÿ");      
                }
                cat3=ds_ref.Tables[0].Rows[i].category3;
                
            }
            }
            
            //Apply classified booking
            
            //getting Ad no & insertion number
            var adno=ds_ref.Tables[0].Rows[i].cio_booking_id.substring(0,3);
             adno=adno+"-"+ds_ref.Tables[0].Rows[i].cio_booking_id.substring(8);
            var insertion_no=ds_ref.Tables[0].Rows[i].no_insert;
            
            
//            if(ds_ref.Tables[0].Rows[i].rate_code=="CLASS")
//            {
        if(ds_ref.Tables[0].Rows[i].uom_desc!="CD")
            {
                //Bold + BGColor + Eye Catcher
                    //put condition here
                    
                //BGColor + Eye Catcher
//////                if(ds_ref.Tables[0].Rows[i].bullet_code=="YE0" && ds_ref.Tables[0].Rows[i].bullet_code=="HA")
//////                    b.WriteLine("æL,"+xtg_filename+".xtg,K,"+adno+","+insertion_no+","+"æ");
//////                 
//////                //Eye Catcher
//////                 else if(ds_ref.Tables[0].Rows[i].bullet_code=="HA")
//////                        b.WriteLine("æL,"+xtg_filename+",D,"+adno+","+insertion_no+","+"æ");
//////               //Drop Char
//////                 else if(ds_ref.Tables[0].Rows[i].bullet_code=="DR")
//////                       b.WriteLine("æL,"+xtg_filename+",C,"+adno+","+insertion_no+","+"æ"); 
                xtg_filename=xtg_filename.replace(".xtg",".txt");
                 if(ds_ref.Tables[0].Rows[i].Logo_name!=null && ds_ref.Tables[0].Rows[i].Logo_name!="")    
                 {
                 var p=document.getElementById('txtFilepath').value + "Orignal\\" + ds_ref.Tables[0].Rows[i].Logo_name;
                  b.WriteLine("æS,"+xtg_filename+"~"+p+ "," + ds_ref.Tables[0].Rows[i].Logo_H+"*" +ds_ref.Tables[0].Rows[i].Logo_W+ ",P,æ");
                 }
                 else
                 {           
                    b.WriteLine("æL,"+xtg_filename+",P,"+"æ");
                }
              /*  if(ds_ref.Tables[0].Rows[i].bg_color=="YE0")
                {
                    if(ds_ref.Tables[0].Rows[i].bullet_code=="BO2")
                       b.WriteLine("æL,"+xtg_filename+",R,"+adno+","+insertion_no+",B,"+"æ"); 
                    else  if(ds_ref.Tables[0].Rows[i].bullet_code=="BO3")
                       b.WriteLine("æL,"+xtg_filename+",R,"+adno+","+insertion_no+",D,"+"æ");
                    else
                        b.WriteLine("æL,"+xtg_filename+",R,"+adno+","+insertion_no+",P,"+"æ");              
                }       
                else                     
                {
                    if(ds_ref.Tables[0].Rows[i].bullet_code=="BO2")
                        b.WriteLine("æL,"+xtg_filename+",P,"+adno+","+insertion_no+",B,"+"æ");  
                     else  if(ds_ref.Tables[0].Rows[i].bullet_code=="BO3")   
                        b.WriteLine("æL,"+xtg_filename+",P,"+adno+","+insertion_no+",D,"+"æ");    
                     else
                         b.WriteLine("æL,"+xtg_filename+",P,"+adno+","+insertion_no+",P,"+"æ");                        
                }   */ 
             }
                else if(ds_ref.Tables[0].Rows[i].uom_desc=="CD")
                     {
                       var ref_path_CD_1="";
                       if(ds_ref.Tables[0].Rows[i].file_name==null)
                       {
                        if(ds_ref.Tables[0].Rows[i].IP==null || ds_ref.Tables[0].Rows[i].IP=="")
                        ref_path_CD_1=ref_path_CD +ds_ref.Tables[0].Rows[i].cio_booking_id+".jpg";
                        else
                        {
                        ref_path_CD_1=ds_ref.Tables[0].Rows[i].IP +"\\eps\\"+ds_ref.Tables[0].Rows[i].cio_booking_id+".jpg";
                        }
                        }
                       else
                       {
                         if(ds_ref.Tables[0].Rows[i].IP==null || ds_ref.Tables[0].Rows[i].IP=="")
                        ref_path_CD_1=ref_path_CD+ds_ref.Tables[0].Rows[i].file_name;
                        else
                        {
                        ref_path_CD_1=ds_ref.Tables[0].Rows[i].IP+"\\eps\\"+ds_ref.Tables[0].Rows[i].file_name;
                        }
                       }
                       b.WriteLine("æD,"+ref_path_CD_1+","+ds_ref.Tables[0].Rows[i].height+"*"+ds_ref.Tables[0].Rows[i].width+","+adno+","+insertion_no+ "," + ds_ref.Tables[0].Rows[i].cio_booking_id + ",P,"+"æ");            
                       
                      }
               
               
               updatestatus=updatestatus+ds_ref.Tables[0].Rows[i].cio_booking_id+","+ds_ref.Tables[0].Rows[i].no_insert;
               updatestatus=updatestatus+";";
               
//}                    
        }  //end of for 
        
        //update status "PUBLISH" for booking for which reference file is generated... genReference      
        //¶nm[hOoV¶
              b.WriteLine("\r\n");
        
        b.Close();
        miss.Close();
         
         alert('Flow file generated successfully.');
    // uodatebookingstatus();     // for updation insert status publish in booking insert table
        //alert('Flow file generated successfully.');
    } //end of if
     else
     {
        alert("No Data Found");
     }
    return false;
    
}


function uodatebookingstatus()
{
   // genReference.ReferenceFile(compcode,pubdate,pubcode,centercode,editioncode,suppcode,callbackReferenceFile);
     //genReference.updateClassified1(updatestatus,call_updateClassified12);        
     
   genReference.bookingstatusupdate(updatestatus,call_bookingstatusupdate);        
     return false;



}

function call_bookingstatusupdate(response)
{
 if(response.value=="success")
   alert('Flow file generated successfully.');
}



function exitclick()
{
    if(confirm("Do You Want To Skip This Page"))
    {
        window.close();
        return false;
    }
    return false;
}

//function bindEdition()
//{
//    if(document.getElementById('ddlPublication').value=="0")
//    {
//        alert("Please select Publication");
//        return false;
//    }
//    else
//    {
//        var res=genReference.bindEdition(document.getElementById('ddlPublication').value);
//        if(res.value!=null)
//        {
//            var ds=res.value;
//              var pkgitem = document.getElementById("ddlCenter");
//                pkgitem.options.length = 0; 
//                  pkgitem.options[pkgitem.options.length] = new Option('Select','0');
//                   pkgitem.options.length;
//            for(var i=0;i<ds.Tables[0].Rows.length>;i++)
//            {
//                           pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME,ds.Tables[0].Rows[i].CODE);
//                            pkgitem.options.length;
//            }
//        }
//    }
//}
function bindEdition()
{
  var compcode=document.getElementById('hiddencompcode').value;
       var userid=document.getElementById('hiddenuserid').value;
	    var centercode=document.getElementById('ddlCenter').value;
	    var pub=document.getElementById('ddlPublication').value;
var res=genReference.getCenterWiseEdition(compcode,userid,centercode,pub);
if(res.value!=null)
{
    var ds=res.value;
     document.getElementById('ddlEdition').options.length=0;
    document.getElementById('ddlEdition').options.length;
    if(ds.Tables[0].Rows.length>0)
    {
        for(var i=0;i<ds.Tables[0].Rows.length;i++)
        {
         document.getElementById('ddlEdition').options[document.getElementById('ddlEdition').options.length] = new Option(ds.Tables[0].Rows[i].edition_name,ds.Tables[0].Rows[i].edition_code);
         document.getElementById('ddlEdition').options.length;
         }
    }
}
}// JScript File

