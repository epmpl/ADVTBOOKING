// JScript File
var counter=0;
var ht_Ratio;
var wd_Ratio;
var nPages=0;
var tTop=5;
var lLeft=10;
var SP_W=83;
var SP_H=130;
var gl_pubcode="";
var gl_centercode="";
var gl_editioncode="";
var gl_suppcode="";
var gl_date="";
var iRowid="";
var ciobookid="";
var img_left = 0;
var img_Top = 0;
function getImagePosition()
{    
    this.targetobj=window.event? event.srcElement : e.target
    var imgId=this.targetobj.id;
    if(imgId.indexOf("Image")==0)
    {
         img_left=this.targetobj.style.left; //document.getElementById(imgId).style.left;
         img_Top=this.targetobj.style.top; //document.getElementById(imgId).style.top;
    }
 }
function draw_LoadControls()
{
    document.getElementById('Panel1').innerHTML = '<DIV id=Divn1 style=\"BORDER-RIGHT: thin groove; BORDER-TOP: thin groove; FONT-SIZE: 6pt; VISIBILITY: hidden; BORDER-LEFT: thin groove; WIDTH: 60px; BORDER-BOTTOM: thin groove; POSITION: absolute; HEIGHT: 80px\"><IMG class=drag id=Image1 style=\"BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; VISIBILITY: hidden; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid\" src=\"\"> </DIV><DIV id=Divpg1 style=\"BORDER-RIGHT: thin groove; BORDER-TOP: thin groove; FONT-SIZE: 8pt; LEFT: 14px; VISIBILITY: hidden; BORDER-LEFT: thin groove; WIDTH: 20px; BORDER-BOTTOM: thin groove; POSITION: absolute; TOP: 46px; HEIGHT: 10px\"></DIV>';
     document.getElementById('drpedition').style.visibility="visible"; 
   //  var btn_left=document.getElementById('EdiButton1').clientLeft;
   //  var btn_top=document.getElementById('EdiButton1').clientTop;
     var objpack=document.getElementById('drppackagecopy');
     var objedition=document.getElementById('drpedition');
     objedition.options.length = 0; 
     objedition.options[0]=new Option("-Select-","0");
     for(var i=0;i<objpack.options.length;i++)
     {
        objedition.options[objedition.options.length] = new Option(objpack[i].text,objpack[i].text);
        
        objedition.options.length;
     }
     
     var objinsert=document.getElementById('drpinsertion');
     objinsert.options.length = 0; 
     objinsert.options[0]=new Option("-Select-","0");
     for(var i=1;i<=gridItemCount;i++)
     {
        objinsert.options[objinsert.options.length] = new Option(i,i);
        
        objinsert.options.length;
     }
    return false;
}




function CreateAllPage(edition,date)
{   
      counter=0;
      document.getElementById('Panel1').innerHTML='<DIV id=Divn1 style=\"BORDER-RIGHT: thin groove; BORDER-TOP: thin groove; FONT-SIZE: 6pt; VISIBILITY: hidden; BORDER-LEFT: thin groove; WIDTH: 60px; BORDER-BOTTOM: thin groove; POSITION: absolute; HEIGHT: 80px\"><IMG class=drag id=Image1 style=\"BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; VISIBILITY: hidden; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid\" src=\"\"> </DIV><DIV id=Divpg1 style=\"BORDER-RIGHT: thin groove; BORDER-TOP: thin groove; FONT-SIZE: 8pt; LEFT: 14px; VISIBILITY: hidden; BORDER-LEFT: thin groove; WIDTH: 20px; BORDER-BOTTOM: thin groove; POSITION: absolute; TOP: 46px; HEIGHT: 10px\"></DIV>';
      
      Booking_master.getbookingdetail(edition,date,callback_getbookingdetail); 
      
      var pdate=document.getElementById('hidpubdate').value;
      var ppub=document.getElementById('hidpub').value;
      var pbkfor=document.getElementById('hidpubcent').value;
      var pedition=document.getElementById('hidedition').value;
      var psecpub=document.getElementById('hidsuppliment').value;

     // Booking_master.getIssuePages(pdate,ppub,pbkfor,pedition,psecpub,callbackInsertPage); 
      return false;
}


function callback_getbookingdetail(res)
{

    var ds=res.value;
    if(ds.Tables!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            document.getElementById('hidpubdate').value=ds.Tables[0].Rows[0].insert_date;
            document.getElementById('hidpub').value=ds.Tables[0].Rows[0].publication_code;
            document.getElementById('hidpubcent').value=ds.Tables[0].Rows[0].pub_cent_code;
            document.getElementById('hidedition').value=ds.Tables[0].Rows[0].edition_code;
            document.getElementById('hidsuppliment').value=ds.Tables[0].Rows[0].supp_code;    
         }  
    }
  
      var pdate=document.getElementById('hidpubdate').value;
      var ppub=document.getElementById('hidpub').value;
      var pbkfor=document.getElementById('hidpubcent').value;
      var pedition=document.getElementById('hidedition').value;
      var psecpub=document.getElementById('hidsuppliment').value; 
      var compcode=document.getElementById('hiddencompcode').value;
      var dateformat=document.getElementById('hiddendateformat').value;
      Booking_master.getIssuePages(compcode,pdate,ppub,pbkfor,pedition,psecpub, dateformat, callbackInsertPage); 
    //  Booking_master.getSubmitPages(compcode,pdate,ppub,pbkfor,pedition,psecpub,dateformat,callbackInsertPage);
        
      return false;
}





function callbackInsertPage(response)
{
    var ds_nPages=response;
    var pubdate=document.getElementById('hidpubdate').value;
    var pubcode=document.getElementById('hidpub').value;
    var centercode=document.getElementById('hidpubcent').value;
    var editioncode=document.getElementById('hidedition').value;
    var suppcode=document.getElementById('hidsuppliment').value; 
    var compcode=document.getElementById('hiddencompcode').value;
    var dateformat=document.getElementById('hiddendateformat').value;
    if(ds_nPages.value.Tables[0].Rows.length==0 || ds_nPages.value.Tables[0].Rows[0].pages==null)
    {
        Booking_master.SubmitIssuePages(compcode,gl_date,gl_pubcode,gl_centercode,gl_editioncode,gl_suppcode,dateformat); 
        var ds_nPages=Booking_master.getIssuePages(compcode,gl_date,gl_pubcode,gl_centercode,gl_editioncode,gl_suppcode,dateformat);
    }
 /*	    
    if(ds_nPages==null)
    {
        alert('Pages are not configured.');
        document.getElementById('Panel1').innerHTML='<DIV id=Divn1 style=\"BORDER-RIGHT: thin groove; BORDER-TOP: thin groove; FONT-SIZE: 6pt; VISIBILITY: hidden; BORDER-LEFT: thin groove; WIDTH: 60px; BORDER-BOTTOM: thin groove; POSITION: absolute; HEIGHT: 80px\"><IMG class=drag id=Image1 style=\"BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; VISIBILITY: hidden; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid\" src=\"\"> </DIV><DIV id=Divpg1 style=\"BORDER-RIGHT: thin groove; BORDER-TOP: thin groove; FONT-SIZE: 8pt; LEFT: 14px; VISIBILITY: hidden; BORDER-LEFT: thin groove; WIDTH: 20px; BORDER-BOTTOM: thin groove; POSITION: absolute; TOP: 46px; HEIGHT: 10px\"></DIV>';
        return 0;
    }
    
    
    if(ds_nPages.Tables[0].Rows.length==0)
    {
        alert('Pages are not configured.');
        document.getElementById('Panel1').innerHTML='<DIV id=Divn1 style=\"BORDER-RIGHT: thin groove; BORDER-TOP: thin groove; FONT-SIZE: 6pt; VISIBILITY: hidden; BORDER-LEFT: thin groove; WIDTH: 60px; BORDER-BOTTOM: thin groove; POSITION: absolute; HEIGHT: 80px\"><IMG class=drag id=Image1 style=\"BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; VISIBILITY: hidden; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid\" src=\"\"> </DIV><DIV id=Divpg1 style=\"BORDER-RIGHT: thin groove; BORDER-TOP: thin groove; FONT-SIZE: 8pt; LEFT: 14px; VISIBILITY: hidden; BORDER-LEFT: thin groove; WIDTH: 20px; BORDER-BOTTOM: thin groove; POSITION: absolute; TOP: 46px; HEIGHT: 10px\"></DIV>';
        return 0;
     }*/
    if(ds_nPages.value.Tables[0].Rows.length!=0)
        nPages=     ds_nPages.value.Tables[0].Rows[0].number_of_pages;  //number_of_pages;  //pages
          
    var i=0;
    var j;
    var SP_T=0;
    var SP_L;
  
//////    var tTop=25;
//////    var lLeft=16;    
//////    var SP_W=99;
//////    var SP_H=156;
    var leftchk=10;
    for(var i=0;i<nPages;i++)
    {       
        if(i==0)
        {
            document.getElementById('Divn1').style.left=lLeft+"px";
            document.getElementById('Divn1').style.top=tTop;
            document.getElementById('Divn1').style.height=SP_H+"px";
            document.getElementById('Divn1').style.width=SP_W+"px";        
            document.getElementById('Divn1').style.visibility="visible";
            
            document.getElementById('Divpg1').style.left=lLeft+"px";
            if(browser!="Microsoft Internet Explorer")
                    {
            document.getElementById('Divpg1').style.top=(130+5)+"px";
            }
            else
            document.getElementById('Divpg1').style.top=(parseInt(document.getElementById('Divn1').style.top)+parseInt(document.getElementById('Divn1').style.height)+5)+"px";
            
            document.getElementById('Divpg1').style.height=10+"px";
            document.getElementById('Divpg1').style.width=SP_W-10+"px";
          // document.getElementById('Divpg1').innerText=i+1;        
            document.getElementById('Divpg1').style.border=0;        
            document.getElementById('Divpg1').style.visibility="visible";
        }
        else 
        {
           // if(i%3==0)
           // {
           //     SP_L=document.getElementById('Div1').style.left;
            //    SP_T=parseInt(document.getElementById("Div"+i).style.top)+parseInt(document.getElementById("Div"+i).style.posHeight)+tTop;
           // }
           // else
            {
                SP_L=parseInt(document.getElementById("Divn"+i).style.left)+parseInt(document.getElementById("Divn"+i).style.posWidth)+lLeft+"px"; //25*i; 
                SP_T=parseInt(document.getElementById("Divn"+i).style.posTop);
                    
            }
       
        leftchk=leftchk+93;
        SP_L=leftchk;
       
//        document.getElementById('Panel1').innerHTML="";
            var idd="Divn"+(i+1);
            var newDiv=document.createElement("Div");            
         //   newDiv.setAttribute("ID",idd);
            newDiv.id=idd;
            newDiv.className="skin2";
          //  var id_prev="Div"+i;
            
            newDiv.style.left=SP_L+"px";   //parseInt(document.getElementById(id_prev).style.left)+parseInt(document.getElementById(id_prev).style.posWidth)+lLeft; //25*i; 
            newDiv.style.top=SP_T+"px";   //parseInt(document.getElementById(id_prev).style.posTop);  //15*i;          
            newDiv.style.height=SP_H+"px";
            newDiv.style.width=SP_W+"px";            
            //newDiv.style.visibility="visible";
            document.getElementById('Panel1').appendChild(newDiv);
                
            
            var pg_idd="Divpg"+(i+1);
            var pgDiv=document.createElement("Div"); 
            pgDiv.id=pg_idd;
            pgDiv.className="skin2"; 
            pgDiv.style.fontSize=10+"px";
           SP_T=3;
            
            var toppag=parseInt(newDiv.style.height)+5;
            toppag=toppag+parseInt(SP_T);
            
            pgDiv.style.left=SP_L+"px";
            pgDiv.style.top=(SP_T+parseInt(newDiv.style.height)+5)+"px";
            pgDiv.style.width=SP_W-10+"px";
            pgDiv.style.height=10+"px";
            pgDiv.style.border=0+"px";           
          //  pgDiv.style.visibility="visible";
            document.getElementById('Panel1').appendChild(pgDiv); 
           
              //pgDiv.style.visibility="visible";
                       
        }       
    }
              
  
      Booking_master.pageHeading(gl_date,gl_pubcode,gl_centercode,gl_editioncode,gl_suppcode,dateformat, callbackpageHeading);
      
      
////      for(var i=1;i<=nPages;i++)
////      {       
////        Booking_master.ShowPages(pdate,ppub,pbkfor,pedition,psecpub,i,callbackShowAds);
////      }
   
}

function callbackpageHeading(response)
{

    var ds_pgHeading=response.value;
    var dateformat=document.getElementById('hiddendateformat').value;
    if(ds_pgHeading==null)
    {
        alert('Pages are not configured');
        return 0;
    }
    if(ds_pgHeading.Tables[0].Rows.length==0)
    {
        alert('Pages are not configured');
        return 0;
    }
     if(ds_pgHeading.Tables[0].Rows.length!=0)
    {
        pageHeight=ds_pgHeading.Tables[0].Rows[0].max_row;
        pageWidth=ds_pgHeading.Tables[0].Rows[0].max_col;
        for(var i=0; i<ds_pgHeading.Tables[0].Rows.length;i++)
        {
            if(ds_pgHeading.Tables[0].Rows[i].page_colour=='C')
               document.getElementById("Divpg"+(i+1)).style.color="Red";
            else
               document.getElementById("Divpg"+(i+1)).style.color="Blue";  
                if(browser!="Microsoft Internet Explorer")
                    {
                    document.getElementById("Divpg"+(i+1)).innerHTML="Page - " +(i+1)+ "  " +ds_pgHeading.Tables[0].Rows[i].page_heading;
                    }
                    else
            document.getElementById("Divpg"+(i+1)).innerText="Page - " +(i+1)+ "  " +ds_pgHeading.Tables[0].Rows[i].page_heading;
        }
    }
      ht_Ratio=Math.round(SP_H/pageHeight*100)/100;    
      wd_Ratio=Math.round(SP_W/pageWidth*100)/100; 
      
    //  var pdate="02/25/2009";   //document.getElementById('PubDate').value;
//      var ppub="HI0"; //document.getElementById('ddlPublication').value;
//      var pbkfor="HI0"; //document.getElementById('ddlCenter').value;
//      var pedition="MA0"; //document.getElementById('ddlEdition').value;
//      var psecpub="MN"; //document.getElementById('ddlSupplement').value;
//      var pdate=document.getElementById('hidpubdate').value;
//      var ppub=document.getElementById('hidpub').value;
//      var pbkfor=document.getElementById('hidpubcent').value;
//      var pedition=document.getElementById('hidedition').value;
//      var psecpub=document.getElementById('hidsuppliment').value;


      for(var i=1;i<=nPages;i++)
      {       
            Booking_master.ShowPages(gl_date,gl_pubcode,gl_centercode,gl_editioncode,gl_suppcode,i,dateformat,callbackShowAds);
      }   
    
    return 0;
       
}

function callbackShowAds(response)
{
    var ds_ads=response.value;
    counter=0;
    if(ds_ads==null)
        return 0;
    if(ds_ads.Tables[0].Rows.length==0)
        return 0;
    if(ds_ads.Tables[0].Rows.length!=0)
    {
        var ppage=ds_ads.Tables[0].Rows[0].pagenum;
        for(var i=1;i<=ds_ads.Tables[0].Rows.length;i++)
        {
        
               counter=counter+1;
////           if(counter==1)
////            {
////               document.getElementById("Image"+counter).style.left=parseInt(document.getElementById("Div"+ppage).style.left)+ds_ads.Tables[0].Rows[i-1].stcol*wd_Ratio;
////               document.getElementById("Image"+counter).style.top=parseInt(document.getElementById("Div"+ppage).style.top)+ds_ads.Tables[0].Rows[i-1].strow*ht_Ratio;
////               document.getElementById("Image"+counter).style.height=ds_ads.Tables[0].Rows[i-1].siz*ht_Ratio;
////               document.getElementById("Image"+counter).style.width=ds_ads.Tables[0].Rows[i-1].col*wd_Ratio; 
////               document.getElementById("Image"+counter).style.visibility="visible"; 
////               document.getElementById("Image"+counter).style.position="absolute"; 
////               document.getElementById("Image"+counter).src="\Images\\nophoto_colr.JPG"; 
////            }
////            else
////            {
                var iidnum=ds_ads.Tables[0].Rows[i-1].idnum;
                var pgid=ds_ads.Tables[0].Rows[i-1].insnum;
                var wd=ds_ads.Tables[0].Rows[i-1].col;
                var ht=ds_ads.Tables[0].Rows[i-1].siz;
                var client=ds_ads.Tables[0].Rows[i-1].clientname;
                if(client==null)
                {
                  client="";
                }
                var filename=ds_ads.Tables[0].Rows[i-1].file_name;
                if(filename==null)
                {
                 filename="";
                }
                var agname=ds_ads.Tables[0].Rows[i-1].agencyname;
                if(agname==null)
                {
                  agname="";
                }
                var ad_type=ds_ads.Tables[0].Rows[i-1].priadctg;
                var adPremium=ds_ads.Tables[0].Rows[i-1].splpage;
                var adPageno=ds_ads.Tables[0].Rows[i-1].pagenum;
                var adColour=ds_ads.Tables[0].Rows[i-1].colour;
                var idd="Image"+counter;
                var newImage=document.createElement("Img");
                newImage.id=idd;
                newImage.className="drag";
                var left_p = document.getElementById("Divn" + ppage).style.left;
                if (left_p == "" || left_p == "null" || left_p==null)
                    left_p = 0;
                var top_p = document.getElementById("Divn" + ppage).style.top;
                if (top_p == "" || top_p == "null" || top_p == null)
                    top_p = 0;
                newImage.style.left=parseInt(left_p)+ds_ads.Tables[0].Rows[i-1].stcol*wd_Ratio-1+"px";
                newImage.style.top=parseInt(top_p)+ds_ads.Tables[0].Rows[i-1].strow*ht_Ratio+2+"px";
                   
                newImage.style.width=ds_ads.Tables[0].Rows[i-1].col*wd_Ratio+"px";
                newImage.style.height=ds_ads.Tables[0].Rows[i-1].siz*ht_Ratio+"px";                
                newImage.style.visibility="visible";
               // var fso = new ActiveXObject("Scripting.FileSystemObject");
               //var ppath=document.getElementById('hiddenappserverpath').value.split("\\");
                 var ppath=document.getElementById('hiddenappserverpath').value;
				// alert(ppath);
//               var npath=ppath[ppath.length-1];
//               if(npath=="")
//                    npath=ppath[ppath.length-2];
//               var image_chk=ppath+"jpgPreview\\"+filename+".JPG";
//               var image_chk=ppath+"\\jpgPreview\\"+filename+".JPG";
                 var image_chk=ppath+filename+".JPG";
                 //alert(image_chk);
                var strtext="";
                strtext=ds_ads.Tables[0].Rows[i-1].FLAG;
              //********************************************************
                if(browser!="Microsoft Internet Explorer")
                {
                    var  httpRequest =null;
                    httpRequest= new XMLHttpRequest();
                    if (httpRequest.overrideMimeType) 
                    {
                        httpRequest.overrideMimeType('text/xml'); 
                    }
                
                    httpRequest.onreadystatechange = function() {alertContents(httpRequest) };         
                    httpRequest.open( "GET","chktheimage.aspx?image_chk="+image_chk, false );
                    httpRequest.send('');
                    
                    if (httpRequest.readyState == 4) 
                    {                        
                        if (httpRequest.status == 200) 
                        {
                            strtext=httpRequest.responseText;
                        }
                        else 
                        {
                            alert('There was a problem with the request.');
                        }
                    }
                }
                else
                { 
                    var xml = new ActiveXObject("Microsoft.XMLHTTP");                
                    xml.Open( "GET","chktheimage.aspx?image_chk="+image_chk, false );
                    xml.Send();
                    strtext=xml.responseText;
                }
                //***********************************************************************
                
              //  var filexiststatus=fso.FileExists(ppath+"jpgPreview\\"+filename+".JPG");
               // if(filexiststatus)
               if(browser=="Microsoft Internet Explorer")
               {
                if(strtext=="y")
                    newImage.src="image.aspx?path="+image_chk;      //ppath+filename+".JPG";
                   // newImage.src="temppdf\\" + filename+".JPG";
                else if(document.getElementById('txtciobookid').value==iidnum)
                   newImage.src="\Images\\nophoto_curr.JPG"; 
                else if(adColour=="C")
                    newImage.src="\Images\\nophoto_colr.JPG";
                else
                    newImage.src="\Images\\nophoto.JPG";
                }
                  else
                    {
                    
                    if(strtext=="y")
                    newImage.src="image.aspx?path="+image_chk;                 //ppath+filename+".JPG";
                    //newImage.src="temppdf/" + filename+".JPG";
                else if(document.getElementById('txtciobookid').value==iidnum)
                   newImage.src="Images/nophoto_curr.JPG"; 
                else if(adColour=="C")
                    newImage.src="Images/nophoto_colr.JPG";
                else
                    newImage.src="Images/nophoto.JPG";
                    
                    }
               // newImage.src="\Images\\nophoto_colr.JPG";
                newImage.ToolTip=iidnum+";"+pgid+";"+ht+";"+wd+";"+client+";"+filename+";"+adColour+";"+adPremium+";"+adPageno;
                newImage.alt="ID:"+iidnum+"; Height:"+ht+"; Width:"+wd+"; Client:"+client+"; Agency:"+agname+"; AdType:"+ad_type+"; Colour:"+adColour+"; Filename:"+filename;           
                document.getElementById('Panel1').appendChild(newImage);                
               
           // }
        }        
    }    
}

function Paginate()
{
   
   if(document.getElementById('drpedition').value == '0' || document.getElementById('drpedition').value =='' || document.getElementById('drpinsertion').value == '0' || document.getElementById('drpinsertion').value == '')
   {
        //draw_LoadControls();
        return false;
   }
   var dateformat =document.getElementById('hiddendateformat').value;
   for(var i=1;i<=nPages;i++)
   {
        Booking_master.Pagination(gl_date,gl_centercode,gl_pubcode,gl_suppcode,gl_editioncode,i,dateformat);
        //Booking_master.Pagination('02/25/2009','HI0','HI0','MN','MA0',i);
       // Booking_master.BestFit('04/23/2008','BH','DB','MN','CT',i);
   }
   alert('Pagination completed');
   // CreateAllPage();
   getButtonId();
    return false;
}

function getImageId(e) {

    this.targetobj=window.event? event.srcElement : e.target
    var iid=this.targetobj.id;
    
      //Check Rights for moving ads ************************************
    var chkEdiRights=Booking_master.CheckEditionRights(document.getElementById('hiddencompcode').value,document.getElementById('drpedition').value,document.getElementById('hiddenuserid').value);
    if(chkEdiRights.value.Tables[0].Rows.length==0)
    {
        if(iid.indexOf("Image")<0)
        {
            alert('You have no rights to move ads.');
            document.getElementById(iid).style.left = img_left;
            document.getElementById(iid).style.top = img_Top;
            return false;
        }     
    }
    var iFlag=0;  
    for(var i=1;i<=nPages;i++)
    {   
        var dateformat =document.getElementById('hiddendateformat').value;
        var Div_Left=document.getElementById("Divn"+i).style.left;
        var Div_Top=document.getElementById("Divn"+i).style.top;
        //if((parseInt(Div_Left)<=parseInt(this.targetobj.style.left) && (parseInt(Div_Left)+99)>parseInt(this.targetobj.style.left)) && (parseInt(Div_Top)<parseInt(this.targetobj.style.top) && (parseInt(Div_Top)+131)>parseInt(this.targetobj.style.top)) && (parseInt(Div_Top)+131)>(parseInt(this.targetobj.style.top)+parseInt(this.targetobj.style.height)))
        if((parseInt(Div_Left)<=parseInt(this.targetobj.style.left) && (parseInt(Div_Left)+85)>(parseInt(this.targetobj.style.left)+parseInt(this.targetobj.style.width))) && (parseInt(Div_Top)<parseInt(this.targetobj.style.top) && (parseInt(Div_Top)+132)>parseInt(this.targetobj.style.top)) && (parseInt(Div_Top)+132)>(parseInt(this.targetobj.style.top)+parseInt(this.targetobj.style.height)))
        {
           // alert("Div"+i);
            var xstcol=Math.round((parseInt(this.targetobj.style.left)-parseInt(Div_Left))/wd_Ratio*100)/100;
            var ystrow=Math.round((parseInt(this.targetobj.style.top)-parseInt(Div_Top))/ht_Ratio*100)/100;
            var bkdetails=this.targetobj.ToolTip;
            
            if(bkdetails==undefined)
                return false;
            var bkdetailspart=bkdetails.split(";");
           
            var ds_pos=Booking_master.IssuePageDetails(gl_date,gl_pubcode,gl_centercode,gl_editioncode,gl_suppcode,i,dateformat);
            if(ds_pos.value==null)
            {
                alert(ds_pos.error.description);
                return false;
            }
            if(bkdetailspart[8]!=i)
            {
                if(bkdetailspart[7]=="FP" || bkdetailspart[7]=="BP" || bkdetailspart[7]=="PG3")
                {
                    alert('Placed ad is premium. Can not shift.');
                    this.targetobj.style.left=img_left;
                    this.targetobj.style.top=img_Top;
                    return false;
                }
              
                if(bkdetailspart[6] !="B" && ds_pos.value.Tables[0].Rows[0].page_colour=="B")
                {
                    alert('Colour ad can not placed on B&W page');
                    this.targetobj.style.left=img_left;
                    this.targetobj.style.top=img_Top;
                    return false;
                } 
             
                if(ds_pos.value.Tables[0].Rows[0].page_heading=="FP" || ds_pos.value.Tables[0].Rows[0].page_heading=="BP" || ds_pos.value.Tables[0].Rows[0].page_heading=="PG3")
                {
                    if (bkdetailspart[7] != "FP" || bkdetailspart[7] != "BP" || bkdetailspart[7] != "PG3" || bkdetailspart[7] != " " || bkdetailspart[7] != "null")
                    {
                        alert('Non-premium can not placed on premium page.');
                        this.targetobj.style.left=img_left;
                        this.targetobj.style.top=img_Top;
                        return false; 
                    }
                }
            }
           
            Booking_master.UpdateAd(gl_date,gl_pubcode,gl_centercode,gl_editioncode,gl_suppcode,i,xstcol,ystrow,bkdetailspart[0],bkdetailspart[1],dateformat,callbackUpdate);
            Booking_master.UpdatePage_Booking(bkdetailspart[0],bkdetailspart[1],i);
            iFlag=1;
           
        }
    }
    if(iFlag==0)
    {
        if(iid.indexOf("Image")>=0)
        {
           this.targetobj.style.left=img_left;
           this.targetobj.style.top=img_Top;
        }
    }
    return false;
}

function callbackUpdate()
{
    alert('Ad updated successfully');
    showgridexecute();
    return false;
}


function callbackSpaceAvailability(response)
{
    var ds_sp=response.value;
    if(ds_sp==null)
    {
        alert('Pages are not configured');
        return 0;
    }
    if(ds_sp.Tables[0].Rows.length==0)
    {
        alert('Pages are not configured');
        return 0;
    }
    if(ds_sp.Tables[0].Rows.length!=0)
    {
        document.getElementById("divspace").style.display="block";
        document.getElementById('grd_SpaceCheck').datasource=ds_sp;
        document.getElementById('grd_SpaceCheck').bind; 
    }
    return false;
 }
 
 
function getButtonId()
{
    if(document.getElementById('drpedition').value == '0' || document.getElementById('drpedition').value =='' || document.getElementById('drpinsertion').value == '0' || document.getElementById('drpinsertion').value == '')
        return false;
      
    document.getElementById('Panel1').innerHTML='<DIV id=Divn1 style=\"BORDER-RIGHT: thin groove; BORDER-TOP: thin groove; FONT-SIZE: 6pt; VISIBILITY: hidden; BORDER-LEFT: thin groove; WIDTH: 60px; BORDER-BOTTOM: thin groove; POSITION: absolute; HEIGHT: 80px\"><IMG class=drag id=Image1 style=\"BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; VISIBILITY: hidden; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid\" src=\"\"> </DIV><DIV id=Divpg1 style=\"BORDER-RIGHT: thin groove; BORDER-TOP: thin groove; FONT-SIZE: 8pt; LEFT: 14px; VISIBILITY: hidden; BORDER-LEFT: thin groove; WIDTH: 20px; BORDER-BOTTOM: thin groove; POSITION: absolute; TOP: 46px; HEIGHT: 10px\"></DIV>';     

    var i=document.getElementById('drpinsertion').value;
    i=i-1;
    gl_date=document.getElementById('Text'+i).value;
    if(gl_date == "")
        return false;
        
    //update booking
    edition_Text=document.getElementById('edit'+i).value;
    if(document.getElementById('sho'+i)!=null)
    {
        iRowid=document.getElementById('sho'+i).value;         
    }
   //comment by anuj var insert = document.getElementById('ins'+i).innerText;
   
   var insert="";

    if(browser!="Microsoft Internet Explorer")
    {
      insert =document.getElementById('ins'+i).textContent
    }else
    {
      insert =document.getElementById('ins'+i).innerText
    }
    if(document.getElementById('txtciobookid').value=='')
        document.getElementById('txtciobookid').value=document.getElementById('hiddencioid').value;
    ciobookid=document.getElementById('txtciobookid').value; 
      
    document.getElementById('Panel1').innerHTML='<DIV id=Divn1 style=\"BORDER-RIGHT: thin groove; BORDER-TOP: thin groove; FONT-SIZE: 6pt; VISIBILITY: hidden; BORDER-LEFT: thin groove; WIDTH: 60px; BORDER-BOTTOM: thin groove; POSITION: absolute; HEIGHT: 80px\"><IMG class=drag id=Image1 style=\"BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; VISIBILITY: hidden; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid\" src=\"\"> </DIV><DIV id=Divpg1 style=\"BORDER-RIGHT: thin groove; BORDER-TOP: thin groove; FONT-SIZE: 8pt; LEFT: 14px; VISIBILITY: hidden; BORDER-LEFT: thin groove; WIDTH: 20px; BORDER-BOTTOM: thin groove; POSITION: absolute; TOP: 46px; HEIGHT: 10px\"></DIV>';     
   
   //check if changes in booking
    if(document.getElementById('sho'+i)!=null)
    {
        var ds_booking=Booking_master.getCurrentBooking(ciobookid,iRowid,insert);
        if(ds_booking.value!=null  && ds_booking.value.Tables[0].Rows.length !=0)
        {  
            var pdate= ds_booking.value.Tables[0].Rows[0].insdate.format('yyyy/MM/dd');
            var ppub=ds_booking.value.Tables[0].Rows[0].pripub;
            var pbkfor=ds_booking.value.Tables[0].Rows[0].bkfor;
            var pedition=ds_booking.value.Tables[0].Rows[0].edition;
            var psecpub=ds_booking.value.Tables[0].Rows[0].secpub;
            if(psecpub==null)
            {
                psecpub="";
            }
            var pcolour=ds_booking.value.Tables[0].Rows[0].colour;
            if(ds_booking.value.Tables[0].Rows[0].splpage==null)
                psplpage="0";
            else
                var psplpage=ds_booking.value.Tables[0].Rows[0].splpage;
            var padtype=ds_booking.value.Tables[0].Rows[0].priadctg;
            var ppageno=ds_booking.value.Tables[0].Rows[0].page_no;  
            var adstatus=ds_booking.value.Tables[0].Rows[0].canmiss;
            var adfilename=ds_booking.value.Tables[0].Rows[0].file_name;
            if(adfilename==null)
            {
                adfilename="";
            } 
            var adheight= ds_booking.value.Tables[0].Rows[0].sz1;
            var adwidth=ds_booking.value.Tables[0].Rows[0].col1;   
            Booking_master.UpdateBooking_AdDummy(ciobookid,iRowid,insert,pdate,ppub,pbkfor,pedition,psecpub,pcolour,psplpage,padtype,ppageno,adstatus,adfilename,adheight,adwidth);
        }
    } 
      
    //******************************    
    var dateformat =document.getElementById('hiddendateformat').value;
    var compcode=document.getElementById('hiddencompcode').value;
    var id_buttonText=document.getElementById('drpedition').value;//document.getElementById(iid).value;
      
    if(id_buttonText.split("-").length==5)
    {
        var getEdiName=Booking_master.getSupplementName(compcode,id_buttonText);
        if(getEdiName.value==null)
            return false;
        var getCitycode=Booking_master.GetCityCode(compcode,getEdiName.value.Tables[0].Rows[0].edition_code);
    }   
    else
        var getEdiName=Booking_master.getEditionName(compcode,id_buttonText,"","");
         
    if(getEdiName.value.Tables[0].Rows.letngh!=0)
    {
          // var pdate="02/25/2009"; //document.getElementById(' ').value;
          gl_pubcode=getEdiName.value.Tables[0].Rows[0].pub_code;           
          gl_editioncode=getEdiName.value.Tables[0].Rows[0].edition_code;
          if(id_buttonText.split("-").length==5)
          {
              gl_centercode=getCitycode.value.Tables[0].Rows[0].city_code;
              gl_suppcode= getEdiName.value.Tables[0].Rows[0].supp_code;
          }
          else
          {
              gl_centercode=getEdiName.value.Tables[0].Rows[0].city_code;
              gl_suppcode="MN";
          }
          Booking_master.getIssuePages(compcode,gl_date,gl_pubcode,gl_centercode,gl_editioncode,gl_suppcode,dateformat, callbackInsertPage); 
    }
    return false;
     
}

function afterSave_Pagination()
{
    document.getElementById('Panel1').innerHTML='';
    document.getElementById('drpedition').options.length=0;
    document.getElementById('drpinsertion').options.length=0;
}

//call pageset FOR PAGE PLANNING
 function getButtonIdGrid(e)
 { 
      this.targetobj=window.event? event.srcElement : e.target
    
      var iid=this.targetobj.id;
      var no=iid.split("_")[2];
      edition_Text=document.getElementById('edit'+no).value;
      date = document.getElementById('Text'+no).value;
      if(document.getElementById('sho'+no)!=null)
      {
         iRowid=document.getElementById('sho'+no).value;
      }
      if(document.getElementById('txtciobookid').value=='')
      {
         document.getElementById('txtciobookid').value=document.getElementById('hiddencioid').value;
      }
   
      ciobookid=document.getElementById('txtciobookid').value;
      if (browser != "Microsoft Internet Explorer")
         var insert = document.getElementById('ins' + no).innerHTML;
         else
      var insert = document.getElementById('ins'+no).innerText;
      var dateformat=document.getElementById('hiddendateformat').value;
      document.getElementById('drpedition').value=edition_Text;
      document.getElementById('drpinsertion').value=insert;

      if(date=="")
      {
        return false;
      }
      document.getElementById('Panel1').innerHTML='<DIV id=Divn1 style=\"BORDER-RIGHT: thin groove; BORDER-TOP: thin groove; FONT-SIZE: 6pt; VISIBILITY: hidden; BORDER-LEFT: thin groove; WIDTH: 60px; BORDER-BOTTOM: thin groove; POSITION: absolute; HEIGHT: 80px\"><IMG class=drag id=Image1 style=\"BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; VISIBILITY: hidden; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid\" src=\"\"> </DIV><DIV id=Divpg1 style=\"BORDER-RIGHT: thin groove; BORDER-TOP: thin groove; FONT-SIZE: 8pt; LEFT: 14px; VISIBILITY: hidden; BORDER-LEFT: thin groove; WIDTH: 20px; BORDER-BOTTOM: thin groove; POSITION: absolute; TOP: 46px; HEIGHT: 10px\"></DIV>';     
   
   //check if changes in booking
        if(document.getElementById('sho'+no)!=null)
        {
   
            var ds_booking=Booking_master.getCurrentBooking(ciobookid,iRowid,insert);
            if(ds_booking.value!=null && ds_booking.value.Tables[0].Rows.length>0)
            {  
                //var pdate= ds_booking.value.Tables[0].Rows[0].insdate.format('MM/dd/yyyy');
                var pdate = ds_booking.value.Tables[0].Rows[0].insdate.format('yyyy/MM/dd');
                var ppub=ds_booking.value.Tables[0].Rows[0].pripub;
                var pbkfor=ds_booking.value.Tables[0].Rows[0].bkfor;
                var pedition=ds_booking.value.Tables[0].Rows[0].edition;
                var psecpub=ds_booking.value.Tables[0].Rows[0].secpub;
                if(psecpub==null)
                {
                    psecpub="";
                }
                var pcolour=ds_booking.value.Tables[0].Rows[0].colour;
                if(ds_booking.value.Tables[0].Rows[0].splpage==null)
                    psplpage="0";
                else
                    var psplpage=ds_booking.value.Tables[0].Rows[0].splpage;
                
                var padtype=ds_booking.value.Tables[0].Rows[0].priadctg;
                var ppageno=ds_booking.value.Tables[0].Rows[0].page_no;  
                var adstatus=ds_booking.value.Tables[0].Rows[0].canmiss;
                var adfilename=ds_booking.value.Tables[0].Rows[0].file_name;
                if(adfilename==null) 
                {
                    adfilename="";
                }
                var adheight= ds_booking.value.Tables[0].Rows[0].sz1;
                var adwidth=ds_booking.value.Tables[0].Rows[0].col1;      
                Booking_master.UpdateBooking_AdDummy(ciobookid,iRowid,insert,pdate,ppub,pbkfor,pedition,psecpub,pcolour,psplpage,padtype,ppageno,adstatus,adfilename,adheight,adwidth);
            }
      } 
   //******************************
           
    if(iid.indexOf("btn_Pg")==0)
    {  
        var compcode=document.getElementById('hiddencompcode').value;
        var id_buttonText=document.getElementById(iid).value;
        
        if(edition_Text.split("-").length==5)
        {
            var getEdiName=Booking_master.getSupplementName(compcode,edition_Text);
            if(getEdiName.value==null)
                return false;
            var getCitycode = "";
            if (getEdiName.value.Tables[0].Rows.length > 0) {
                getCitycode = Booking_master.GetCityCode(compcode, getEdiName.value.Tables[0].Rows[0].edition_code);
            }
         }   
        else
            var getEdiName=Booking_master.getEditionName(compcode,edition_Text,"","");
        if(getEdiName.value.Tables[0].Rows.length!=0)
        {
           gl_date=date;//"02/25/2009"; //document.getElementById(' ').value;
           gl_pubcode=getEdiName.value.Tables[0].Rows[0].pub_code;           
           gl_editioncode=getEdiName.value.Tables[0].Rows[0].edition_code;
           if(edition_Text.split("-").length==5)
           {
                gl_centercode=getCitycode.value.Tables[0].Rows[0].city_code;
                gl_suppcode=getEdiName.value.Tables[0].Rows[0].supp_code;  
           }
           else
           {
                gl_centercode=getEdiName.value.Tables[0].Rows[0].city_code;
                gl_suppcode="MN";
           }    
           
           Booking_master.getIssuePages(compcode,gl_date,gl_pubcode,gl_centercode,gl_editioncode,gl_suppcode, dateformat, callbackInsertPage); 
           // Booking_master.getSubmitPages(compcode,gl_date,gl_pubcode,gl_centercode,gl_editioncode,gl_suppcode,dateformat,callbackInsertPage);
        }
        return false;
    }
    //return true;
 }
 
function getSpaceAvailability()
{
    
    if(document.getElementById("grd_SpaceCheck")!=null) 
    {
        if(document.getElementById("divspace2").style.display=="block")
        {
            document.getElementById("divspace2").style.display="none";
            // return false;
        }   
        if(document.getElementById("divspace").style.display=="block")
        {
            document.getElementById("divspace").style.display="none";
             return false;
        }   
        else
        {
            document.getElementById("divspace").style.display="block";
            if(document.getElementById('tblrate').style.display=="none" && document.getElementById('tblbill').style.display=="none" && document.getElementById('addetails').style.display=="none" && document.getElementById('pagedetail').style.display=="none" && document.getElementById('tblpackage').style.display=="none" && document.getElementById('tbbox').style.display=="none" && document.getElementById('tbvts').style.display=="none")
            {
                document.getElementById('addetails').style.display="block";
            }                
        }
    }
    else
       return false;
    if(document.getElementById('drpedition').value == '0' || document.getElementById('drpedition').value =='' || document.getElementById('drpinsertion').value == '0' || document.getElementById('drpinsertion').value == '')
    {
        //draw_LoadControls();
        return false;
    }
    var compcode=document.getElementById('hiddencompcode').value;
    var i=document.getElementById('drpinsertion').value;
    var dateformat=document.getElementById('hiddendateformat').value;
    i=i-1;
    gl_date=document.getElementById('Text'+i).value;
    if(gl_date == "")
         return false;
      var pkgName=document.getElementById('drpedition').value;
      var getEdiName=Booking_master.getEditionName(compcode,pkgName,"","");
      if(getEdiName.value==null)
            return false;
      if(getEdiName.value.Tables[0].Rows.length!=0)
      {
        var pubcode=getEdiName.value.Tables[0].Rows[0].pub_code;
        var centercode=getEdiName.value.Tables[0].Rows[0].city_code;
        var editioncode=getEdiName.value.Tables[0].Rows[0].edition_code;
        var suppcode="MN";
      }
      var ds_sp=Booking_master.SpaceAvailability(compcode,gl_date,pubcode,centercode,editioncode,suppcode,dateformat); //,callbackSpaceAvailability);   
      if(ds_sp.value.Tables[0].Rows.length==0)
      {
        alert('Pages are not configured');
        return false;
      }        
      if(ds_sp.value.Tables[0].Rows.length!=0)
      {
       
 //********************************************************************           
//            document.getElementById('grd_SpaceCheck').datasource=ds_sp;
//            document.getElementById('grd_SpaceCheck').bind;  
//*************************************************************************

         var Parent = document.getElementById("grd_SpaceCheck");
         var gridlength=document.getElementById("grd_SpaceCheck").rows.length;
          while(parseInt(gridlength) >2)
          {
             Parent.deleteRow(gridlength-1);
             gridlength=parseInt(gridlength)-1;
          }
        var spl_page=""; 
        for(var i=1;i<=ds_sp.value.Tables[0].Rows.length;i++)
        {
            if(i>=2 && (document.getElementById("grd_SpaceCheck").rows.length<2 || document.getElementById("grd_SpaceCheck").rows.length<=ds_sp.value.Tables[0].Rows.length+1))
            {
                 var GridViewNewRow=document.getElementById("grd_SpaceCheck").insertRow(i);
                 //var GridViewNewRow=grd_SpaceCheck.insertRow(i);
                 var cell1=GridViewNewRow.insertCell(0);
                 var cell2=GridViewNewRow.insertCell(1); 
                 var cell3=GridViewNewRow.insertCell(2);
                 var cell4=GridViewNewRow.insertCell(3);
                 var cell5=GridViewNewRow.insertCell(4);
                 var cell6=GridViewNewRow.insertCell(5);
                 cell1.appendChild(document.createElement('grd_SpaceCheck'));
                 cell2.appendChild(document.createElement('grd_SpaceCheck'));
                 cell3.appendChild(document.createElement('grd_SpaceCheck'));
                 cell4.appendChild(document.createElement('grd_SpaceCheck'));
                 cell5.appendChild(document.createElement('grd_SpaceCheck'));
                 cell6.appendChild(document.createElement('grd_SpaceCheck')); 
                    
                /* cell1.appendChild(grd_SpaceCheck);
                 cell2.appendChild(grd_SpaceCheck);
                 cell3.appendChild(grd_SpaceCheck);
                 cell4.appendChild(grd_SpaceCheck);
                 cell5.appendChild(grd_SpaceCheck);
                 cell6.appendChild(grd_SpaceCheck);*/
                 
                 
                 
            }
            document.getElementById("grd_SpaceCheck").rows[i].cells[0].textContent=ds_sp.value.Tables[0].Rows[i-1].page_no;
            document.getElementById("grd_SpaceCheck").rows[i].cells[1].textContent = ds_sp.value.Tables[0].Rows[i - 1].page_colour;
            document.getElementById("grd_SpaceCheck").rows[i].cells[2].textContent = ds_sp.value.Tables[0].Rows[i - 1].ad_volume;
            if(i==1)
                spl_page="FP";
            else if(i==3)
                spl_page="PG3";
            else if(i==ds_sp.value.Tables[0].Rows.length)
                spl_page="BP"
            else
                spl_page="";
            
            var ds_advol=Booking_master.getPagesBookedVol(compcode,gl_date,pubcode,centercode,editioncode,suppcode,i,spl_page,dateformat);
            if(ds_advol.value.Tables[0].Rows.length!=0)
            {
                document.getElementById("grd_SpaceCheck").rows[i].cells[3].textContent = ds_advol.value.Tables[0].Rows[0].no_of_ads;
                document.getElementById("grd_SpaceCheck").rows[i].cells[4].textContent = ds_advol.value.Tables[0].Rows[0].p_advol;
                document.getElementById("grd_SpaceCheck").rows[i].cells[5].textContent = parseInt(ds_sp.value.Tables[0].Rows[i - 1].ad_volume) - parseInt(ds_advol.value.Tables[0].Rows[0].p_advol);    
            }          
            
        }
    }
      return false;   
}


//====================== show paginated Volume=======================//


function getPaginatedVol()
{
    
    if(document.getElementById("GridView1")!=null) 
    {
        if(document.getElementById("divspace").style.display=="block")
        {
            document.getElementById("divspace").style.display="none";
            // return false;
        }   
        if(document.getElementById("divspace2").style.display=="block")
        {
            document.getElementById("divspace2").style.display="none";
             return false;
        }   
        else
        {
            document.getElementById("divspace2").style.display="block";
            if(document.getElementById('tblrate').style.display=="none" && document.getElementById('tblbill').style.display=="none" && document.getElementById('addetails').style.display=="none" && document.getElementById('pagedetail').style.display=="none" && document.getElementById('tblpackage').style.display=="none" && document.getElementById('tbbox').style.display=="none" && document.getElementById('tbvts').style.display=="none")
            {
                document.getElementById('addetails').style.display="block";
            }                
        }
   } 
    else
       return false;
    if(document.getElementById('drpedition').value == '0' || document.getElementById('drpedition').value =='' || document.getElementById('drpinsertion').value == '0' || document.getElementById('drpinsertion').value == '')
    {
        //draw_LoadControls();
        return false;
    }
    var compcode=document.getElementById('hiddencompcode').value;
    var i=document.getElementById('drpinsertion').value;
    var dateformat=document.getElementById('hiddendateformat').value;
    i=i-1;
    gl_date=document.getElementById('Text'+i).value;
    if(gl_date == "")
         return false;
      var pkgName=document.getElementById('drpedition').value;
      var getEdiName=Booking_master.getEditionName(compcode,pkgName,"","");
      if(getEdiName.value==null)
            return false;
      if(getEdiName.value.Tables[0].Rows.length!=0)
      {
        var pubcode=getEdiName.value.Tables[0].Rows[0].pub_code;
        var centercode=getEdiName.value.Tables[0].Rows[0].city_code;
        var editioncode=getEdiName.value.Tables[0].Rows[0].edition_code;
        var suppcode="MN";
      }
       var ds_Grid_res=Booking_master.FillGrid(gl_date,pubcode,centercode,editioncode,suppcode,dateformat);//,callbackFillGrid);
       
       var browser=navigator.appName;
       var  httpRequest =null;
       var ds_Grid=ds_Grid_res.value;
    if(ds_Grid==null)
        return false;
        
    if(ds_Grid.Tables[0].Rows.length==0)
       return false;
    if(ds_Grid.Tables[0].Rows.length!=0)
    {
       // document.getElementById("hiddenTotalEditionPages").value=ds_Grid.Tables[0].Rows.length;
          var Parent = document.getElementById("GridView1");
          var gridlength=document.getElementById("GridView1").rows.length;
           while(parseInt(gridlength) >2)
           {
              Parent.deleteRow(gridlength-1);
              gridlength=parseInt(gridlength)-1;
           }
  
          
        for(var i=1;i<=ds_Grid.Tables[0].Rows.length;i++)
        {
            if(i>=2 && (document.getElementById("GridView1").rows.length<2 || document.getElementById("GridView1").rows.length<=ds_Grid.Tables[0].Rows.length))
            {
                 var GridViewNewRow=document.getElementById("GridView1").insertRow(i);
                 var cell1=GridViewNewRow.insertCell(0);
                 var cell2=GridViewNewRow.insertCell(1); 
                 var cell3=GridViewNewRow.insertCell(2);
                 var cell4=GridViewNewRow.insertCell(3);
                 var cell5=GridViewNewRow.insertCell(4);
                 var cell6=GridViewNewRow.insertCell(5);
                
                 if(browser!="Microsoft Internet Explorer")
                 {
                     cell1.appendChild(document.createElement('GridView1'));
                     cell2.appendChild(document.createElement('GridView1'));
                     cell3.appendChild(document.createElement('GridView1'));
                     cell4.appendChild(document.createElement('GridView1'));
                     cell5.appendChild(document.createElement('GridView1'));
                     cell6.appendChild(document.createElement('GridView1'));
                 }
                 else
                 {
                     cell1.appendChild(document.getElementById("GridView1"));
                     cell2.appendChild(document.getElementById("GridView1"));
                     cell3.appendChild(document.getElementById("GridView1"));
                     cell4.appendChild(document.getElementById("GridView1"));
                     cell5.appendChild(document.getElementById("GridView1"));
                     cell6.appendChild(document.getElementById("GridView1"));
                 }
            }
            
            document.getElementById("GridView1").rows[i].cells[0].innerText=ds_Grid.Tables[0].Rows[i-1].page_no;
            document.getElementById("GridView1").rows[i].cells[1].innerText=ds_Grid.Tables[0].Rows[i-1].page_colour;
            document.getElementById("GridView1").rows[i].cells[3].innerText=ds_Grid.Tables[0].Rows[i-1].ad_volume;
        } 
        j_page=0;
        for(var i=1;i<=ds_Grid.Tables[0].Rows.length;i++)
        {          
            //fill up grid line with ad volume of a page
            var x_advolume=Booking_master.FillGridAdVolume(gl_date,gl_pubcode,gl_centercode,gl_editioncode,gl_suppcode,i,document.getElementById('hiddendateformat').value); //  ,callbackFillGridAdVolume);
            var x_pageads=Booking_master.FillGridPageAds(gl_date,gl_pubcode,gl_centercode,gl_editioncode,gl_suppcode,i,document.getElementById('hiddendateformat').value); 
            document.getElementById("GridView1").rows[i].cells[4].innerText=x_advolume.value.Tables[0].Rows[0].sqvolume;
            document.getElementById("GridView1").rows[i].cells[5].innerText=parseInt(document.getElementById("GridView1").rows[i].cells[3].innerText)-parseInt(document.getElementById("GridView1").rows[i].cells[4].innerText);
            document.getElementById("GridView1").rows[i].cells[2].innerText=x_pageads.value.Tables[0].Rows[0].totalPlacedAds;
        }                 
    } 
    return false;
}

function callbackFillGrid(response)
{
   var browser=navigator.appName;
   var  httpRequest =null;
    var ds_Grid=response.value;
    if(ds_Grid==null)
        return false;
        
    if(ds_Grid.Tables[0].Rows.length==0)
       return false;
    if(ds_Grid.Tables[0].Rows.length!=0)
    {
       // document.getElementById("hiddenTotalEditionPages").value=ds_Grid.Tables[0].Rows.length;
          var Parent = document.getElementById("GridView1");
          var gridlength=document.getElementById("GridView1").rows.length;
           while(parseInt(gridlength) >2)
           {
              Parent.deleteRow(gridlength-1);
              gridlength=parseInt(gridlength)-1;
           }
  
          
        for(var i=1;i<=ds_Grid.Tables[0].Rows.length;i++)
        {
            if(i>=2 && (document.getElementById("GridView1").rows.length<2 || document.getElementById("GridView1").rows.length<=ds_Grid.Tables[0].Rows.length))
            {
                 var GridViewNewRow=document.getElementById("GridView1").insertRow(i);
                 var cell1=GridViewNewRow.insertCell(0);
                 var cell2=GridViewNewRow.insertCell(1); 
                 var cell3=GridViewNewRow.insertCell(2);
                 var cell4=GridViewNewRow.insertCell(3);
                 var cell5=GridViewNewRow.insertCell(4);
                 var cell6=GridViewNewRow.insertCell(5);
                
                 if(browser!="Microsoft Internet Explorer")
                 {
                     cell1.appendChild(document.createElement('GridView1'));
                     cell2.appendChild(document.createElement('GridView1'));
                     cell3.appendChild(document.createElement('GridView1'));
                     cell4.appendChild(document.createElement('GridView1'));
                     cell5.appendChild(document.createElement('GridView1'));
                     cell6.appendChild(document.createElement('GridView1'));
                 }
                 else
                 {
                     cell1.appendChild(document.getElementById("GridView1"));
                     cell2.appendChild(document.getElementById("GridView1"));
                     cell3.appendChild(document.getElementById("GridView1"));
                     cell4.appendChild(document.getElementById("GridView1"));
                     cell5.appendChild(document.getElementById("GridView1"));
                     cell6.appendChild(document.getElementById("GridView1"));
                 }
            }
            
            document.getElementById("GridView1").rows[i].cells[0].innerText=ds_Grid.Tables[0].Rows[i-1].page_no;
            document.getElementById("GridView1").rows[i].cells[1].innerText=ds_Grid.Tables[0].Rows[i-1].page_colour;
            document.getElementById("GridView1").rows[i].cells[3].innerText=ds_Grid.Tables[0].Rows[i-1].ad_volume;
        } 
        j_page=0;
        for(var i=1;i<=ds_Grid.Tables[0].Rows.length;i++)
        {          
            //fill up grid line with ad volume of a page
            var x_advolume=Booking_master.FillGridAdVolume(gl_date,gl_pubcode,gl_centercode,gl_editioncode,gl_suppcode,i,document.getElementById('hiddendateformat').value); //  ,callbackFillGridAdVolume);
            var x_pageads=Booking_master.FillGridPageAds(gl_date,gl_pubcode,gl_centercode,gl_editioncode,gl_suppcode,i,document.getElementById('hiddendateformat').value); 
            document.getElementById("GridView1").rows[i].cells[4].innerText=x_advolume.value.Tables[0].Rows[0].sqvolume;
            document.getElementById("GridView1").rows[i].cells[5].innerText=parseInt(document.getElementById("GridView1").rows[i].cells[3].innerText)-parseInt(document.getElementById("GridView1").rows[i].cells[4].innerText);
            document.getElementById("GridView1").rows[i].cells[2].innerText=x_pageads.value.Tables[0].Rows[0].totalPlacedAds;
        }                 
    } 
    return false;
}

//==============================================================================//
//check booking
function chkBookingInfo()
{
if(document.getElementById('bookdiv')==null && document.getElementById('bookdiv').getElementsByTagName('table')[0].rows.length<=1)
    return false;
    var flag=0;
    //get booking value from grid
    var compcode=document.getElementById('hiddencompcode').value;
    var edition_Text=document.getElementById('edit0').value; // "HT-DEL"; 
    var currdate = document.getElementById('Text0').value;  //04/23/2009
    var arrdate=currdate.split("/");
     if (document.getElementById("hiddendateformat").value == "yyyy/mm/dd")
     {
        currdate=arrdate[1]+"/" + arrdate[2]+"/"+arrdate[0];
     }
     else  if (document.getElementById("hiddendateformat").value == "dd/mm/yyyy")
     {
        currdate=arrdate[1]+"/" + arrdate[0]+"/"+arrdate[2];
     }
    var adPremium=document.getElementById('prem0').value;
    if(document.getElementById('pagno0').value==null || document.getElementById('pagno0').value=="")
        var adpage=0;
    else
        var adpage=document.getElementById('pagno0').value;
        
     var adheight=document.getElementById('hei0').value;
     var adwidth=document.getElementById('wid0').value;
     var adsize=document.getElementById('siz0').value;
    //***************************************************************
    
    //get Edition code of package
    var ds_code=Booking_master.BookingEditionCode(compcode,edition_Text);
    if(ds_code.value==null)
        return false;
    else
    {
        var pubcode=ds_code.value.Tables[0].Rows[0].publication_code;
        var centercode=ds_code.value.Tables[0].Rows[0].pub_cent_code;
        var editioncode=ds_code.value.Tables[0].Rows[0].edition_code;
        var suppcode=ds_code.value.Tables[0].Rows[0].supp_code;
    }
    //***********************************************************  
      
    //get Page_heading and code for solus, semi-solus
    if(adPremium!=0 && adPremium!='')
    {
        var ds_premium=Booking_master.PremiumCode(compcode,pubcode,editioncode,adPremium);
        if(ds_premium.value==null || ds_premium.value.Tables[0].Rows[0]==undefined)
        {
            alert('Premium is not defined in master.');
            return false;
        }
        else
        {
            var premium=ds_premium.value.Tables[0].Rows[0].pageheading;
            var adsolus=ds_premium.value.Tables[0].Rows[0].spositionradio;
        }
        //*************************************************************************
        
        //if booking is for solus, check booked ad for this page
        if(adsolus=="0")
        {
            var ds_booking=Booking_master.ExistingBookingVolume(compcode,currdate,edition_Text,premium,adpage); 
            if(ds_booking.value!=null)
            {
                flag=1;
                if(!confirm("Some ad is already booked on this page. Are you sure to book solus ad."))            
                   return false;
            }
        }
        
        ////if booking is for semi-solus, check booked ad for this page
        if(adsolus=="1")
        {
            var ds_booking=Booking_master.ExistingBookingVolume(compcode,currdate,edition_Text,premium,adpage); 
            if(ds_booking.value!=null)
                if(parseInt(ds_booking.value.Tables[0].Rows.length)>1)
                {
                    flag=1;
                    if(!confirm("More than one ad is already booked. Are you sure to book semi-solus ad."))
                       return false;
                }
            
        }
        //if booking is for normal, check booked ad for this page
        if(adsolus==null || adsolus=="")
        {
            var ds_booking=Booking_master.ExistingBookingVolume(compcode,currdate,edition_Text,premium,adpage); 
            if(ds_booking.value!=null)        {
                
                for(var k=0;k<ds_booking.value.Tables[0].Rows.length;k++)
                {
                    ds_premium=Booking_master.PremiumCode(compcode,pubcode,editioncode,ds_booking.value.Tables[0].Rows[k].premium1);
                    if(ds_premium.value!=null)
                    {
                        if(ds_premium.value.Tables[0].Rows[0].spositionradio=="0")
                         {
                            var a=confirm('Solus ad already booked. Are you sure to book ad.');
                            if(a==0)
                              return false;
                            else
                                flag=1;
                         }
                         if(ds_premium.value.Tables[0].Rows[0].spositionradio=="1" && parseInt(ds_booking.value.Tables[0].Rows.length)>1)
                         {
                            var b=confirm('Semi-solus ad booked. Are you sure to book ad.');
                            if(b==0)
                              return false;
                            else
                                flag=1;
                         }
                     }
                  } //end of for
               } //end of outer if 
          }
       }   
      if(flag==0)
      {
      if(premium==undefined)
            premium="";
        var ds_1=Booking_master.ExistingBookingSize(compcode,currdate,pubcode,centercode,editioncode,suppcode,premium,adpage);
        if(ds_1.value==null)
        {
        alert(ds_1.error.description)
        return false;
        }
        if(ds_1.value.Tables[0].Rows[0].bksize==null)
        {
            if(adsize>ds_1.value.Tables[1].Rows[0].ad_volume)            
                if(!confirm("Booking size exceeds allowed page volume. Booking continue."))
                    return false;
        }
        else
        {
            if((parseInt(adsize)+parseInt(ds_1.value.Tables[0].Rows[0].bksize))>ds_1.value.Tables[1].Rows[0].ad_volume)
            {
                if(!confirm("Booking size exceeds allowed page volume. Booking continue."))
                    return false;
            }
            else  //check booking ad fitted to page 
            {
                if(ds_1.value.Tables[2].Rows[0].sz1!=null || ds_1.value.Tables[2].Rows[0].col1!=null)
                {
                   for(var j=0;j<ds_1.value.Tables[2].Rows.length;j++)
                   {
                        if((parseInt(adwidth)+parseInt(ds_1.value.Tables[2].Rows[j].col1))>ds_1.value.Tables[1].Rows[0].max_col && (parseInt(adheight)+parseInt(ds_1.value.Tables[2].Rows[j].sz1))>ds_1.value.Tables[1].Rows[0].max_row)
                        {
                           alert('Booking ad does not fit into this page')
                           return false;
                        }
                   }
                }
                
            }
        }
      }
      
    
 
 return false;   
}