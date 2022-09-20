// JScript File
/*change ankur*/
var browser=navigator.appName;
var prevcode="";
var bShow = false;
loadXML('xml/stylesheet.xml');
function getCaretPositions(ctrl,e)
   {
    var CaretPosS = -1, CaretPosE = 0;

     // Mozilla way:
     if(ctrl.selectionStart || (ctrl.selectionStart == '0'))
     {
       CaretPosS = ctrl.selectionStart;
       CaretPosE = ctrl.selectionEnd;
       //debugger ;
       insertionS = CaretPosS == -1 ? CaretPosE : CaretPosS;
       insertionE = CaretPosE;
       var val,val1;
       val=ctrl.value.substring(insertionS-1,insertionS);
       val1=ctrl.value.substring(insertionS,insertionS +1);//ctrl.innerText.substring(start-2,ctrl.innerText.length-(start+1))
       
        if((val.charCodeAt() == 32) && (e.charCode == 32)) 
         {
           return false;  
         }
        else if((e.charCode == 32) && (val1.charCodeAt() == 32))
         {
           return false;  
         }
       
     }
     // IE way:
     else if(document.selection && ctrl.createTextRange)
     {
       var start = end = 0;
       try
       {
         start = Math.abs(document.selection.createRange().moveStart("character", -10000000)); // start

         if (start > 0)
         {
           try
           {
             var endReal = Math.abs(ctrl.createTextRange().moveEnd("character", -10000000));

             var r = document.body.createTextRange();
             r.moveToElementText(ctrl);
             var sTest = Math.abs(r.moveStart("character", -10000000));
             var eTest = Math.abs(r.moveEnd("character", -10000000));
             if ((ctrl.tagName.toLowerCase() != 'input') && (eTest - endReal == sTest))
               start -= sTest;
           }
           catch(err) {}
         }
       }
       catch (e) {}

       try
       {
         end = Math.abs(document.selection.createRange().moveEnd("character", -10000000)); // end
         if(end > 0)
         {
           try
           {
             var endReal = Math.abs(ctrl.createTextRange().moveEnd("character", -10000000));

             var r = document.body.createTextRange();
             r.moveToElementText(ctrl);
             var sTest = Math.abs(r.moveStart("character", -10000000));
             var eTest = Math.abs(r.moveEnd("character", -10000000));

             if ((ctrl.tagName.toLowerCase() != 'input') && (eTest - endReal == sTest))
              end -= sTest;
           }
           catch(err) {}
         }
       }
       catch (e) {}

       insertionS = start;
       insertionE = end
       if (start > 0)
       {
       var val,val1,vald,count=0,chk;
       var d11=new Array();;
       d11[0]="\n";
       vald=ctrl.innerText;
       chk=vald.indexOf(d11[0]);
       for(i=0;i<=d11.length-1;i++)
       { 
         //chk=vald.indexOf(d11[i]);
         while(!(vald.indexOf(d11[i])<0))
         {
            vald=vald.replace(d11[i],'');
            count=count+1;
         }
       }
         
       if(start>chk)
         start=start+count;
    
       val=ctrl.innerText.substring(start-1,start)
       val1=ctrl.innerText.substring(start,start+1)//ctrl.innerText.substring(start-2,ctrl.innerText.length-(start+1))
       if((val.charCodeAt() == 32) && (e.keyCode == 32)) 
         {
           e.keyCode=0;
           return false;  
         }
        else if((e.keyCode == 32) && (val1.charCodeAt() == 32))
         {
           e.keyCode=0;
           return false;  
         }
       }
       
     }
     
   }
   
   function insertAtCaret(ctrl, val)
   {
   //debugger;
   var userstr = navigator.userAgent.toLowerCase();
   var safari = (userstr.indexOf('applewebkit') != -1);
   var gecko  = (userstr.indexOf('gecko') != -1) && !safari;
   var standr = gecko || window.opera || safari;
   
     if(insertionS != insertionE) deleteSelection(ctrl);

     if(gecko && document.createEvent && !window.opera)
     {
       var e = document.createEvent("KeyboardEvent");

       if(e.initKeyEvent && ctrl.dispatchEvent)
       {
         e.initKeyEvent("keypress",        // in DOMString typeArg,
                        false,             // in boolean canBubbleArg,
                        true,              // in boolean cancelableArg,
                        null,              // in nsIDOMAbstractView viewArg, specifies UIEvent.view. This value may be null;
                        false,             // in boolean ctrlKeyArg,
                        false,             // in boolean altKeyArg,
                        false,             // in boolean shiftKeyArg,
                        false,             // in boolean metaKeyArg,
                        null,              // key code;
                        val.charCodeAt(0));// char code.

         ctrl.dispatchEvent(e);
       }
     }
     else
     {
       //var tmp = (document.selection && !window.opera) ? ctrl.value.replace(/\r/g,"") : ctrl.value;
       var tmp = (document.selection && !window.opera) ? ctrl.innerText.replace(/\r/g,"") : ctrl.innerText;
       
       if(tmp.length<insertionS)
       {    
            if((insertionS-tmp.length)==8)
                ctrl.innerText = tmp.substring(0, insertionS) + '\n\n\n\n\n\n\n\n' + val;
            else if((insertionS-tmp.length)==7)
                ctrl.innerText = tmp.substring(0, insertionS) + '\n\n\n\n\n\n\n' + val;
            else if((insertionS-tmp.length)==6)
                ctrl.innerText = tmp.substring(0, insertionS) + '\n\n\n\n\n\n' + val;
            else if((insertionS-tmp.length)==5)
                ctrl.innerText = tmp.substring(0, insertionS) + '\n\n\n\n\n' + val;
            else if((insertionS-tmp.length)==4)
                ctrl.innerText = tmp.substring(0, insertionS) + '\n\n\n\n' + val;
            else if((insertionS-tmp.length)==3)
                ctrl.innerText = tmp.substring(0, insertionS) + '\n\n\n' + val;
            else if((insertionS-tmp.length)==2)
                ctrl.innerText = tmp.substring(0, insertionS) + '\n\n' + val;
            else if(ctrl.innerHTML=="<P>&nbsp;</P>")
              ctrl.innerHTML=tmp.substring(0, insertionS) +val;
            else if(ctrl.innerHTML.search("<BR>")>=1)
              ctrl.innerText=tmp.substring(0, insertionS) + '\n' +val;
            else if((insertionS-tmp.length)==1)
              //  ctrl.innerText = tmp.substring(0, insertionS) + '\n' + val;
               ctrl.innerText = tmp.substring(0, insertionS) + val;
       }
       else
       {
        ctrl.innerText = tmp.substring(0, insertionS) + val + tmp.substring(insertionS, tmp.length);
       }
     }
     setRange(ctrl, insertionS + val.length, insertionS + val.length);
   }
function setRange(ctrl, start, end)
   {
     if(ctrl.setSelectionRange) // Standard way (Mozilla, Opera, Safari ...)
     {
       ctrl.setSelectionRange(start, end);
     }
     else // MS IE
     {
       var range;
       try
       {
         range = ctrl.createTextRange();
       }
       catch(e)
       {
         try
         {
           range = document.body.createTextRange();
           range.moveToElementText(ctrl);
         }
         catch(e)
         {
           range = null;
         }
       }
       if(!range) return;

       range.collapse(true);
       range.moveStart("character", start);
       range.moveEnd("character", end - start);
       range.select();
     }

     insertionS = start;
     insertionE = end;
   }
   
   function getCaretPositionsA(ctrl)
   {
    var CaretPosS = -1, CaretPosE = 0;

     // Mozilla way:
     if(ctrl.selectionStart || (ctrl.selectionStart == '0'))
     {
       CaretPosS = ctrl.selectionStart;
       CaretPosE = ctrl.selectionEnd;
       //debugger ;
       insertionS = CaretPosS == -1 ? CaretPosE : CaretPosS;
       insertionE = CaretPosE;
     }
     // IE way:
     else if(document.selection && ctrl.createTextRange)
     {
       var start = end = 0;
       try
       {
         start = Math.abs(document.selection.createRange().moveStart("character", -10000000)); // start

         if (start > 0)
         {
           try
           {
             var endReal = Math.abs(ctrl.createTextRange().moveEnd("character", -10000000));

             var r = document.body.createTextRange();
             r.moveToElementText(ctrl);
             var sTest = Math.abs(r.moveStart("character", -10000000));
             var eTest = Math.abs(r.moveEnd("character", -10000000));
             if ((ctrl.tagName.toLowerCase() != 'input') && (eTest - endReal == sTest))
               start -= sTest;
           }
           catch(err) {}
         }
       }
       catch (e) {}

       try
       {
         end = Math.abs(document.selection.createRange().moveEnd("character", -10000000)); // end
         if(end > 0)
         {
           try
           {
             var endReal = Math.abs(ctrl.createTextRange().moveEnd("character", -10000000));

             var r = document.body.createTextRange();
             r.moveToElementText(ctrl);
             var sTest = Math.abs(r.moveStart("character", -10000000));
             var eTest = Math.abs(r.moveEnd("character", -10000000));

             if ((ctrl.tagName.toLowerCase() != 'input') && (eTest - endReal == sTest))
              end -= sTest;
           }
           catch(err) {}
         }
       }
       catch (e) {}
       insertionS = start;
       insertionE = end
     }
     
   }


   
   
function replacekey(event)
{

//   
if(document.getElementById('fnt_fntname').value=="0")
{//debugger;
    var browser=navigator.appName;
    if(browser!="Microsoft Internet Explorer")
    {
        //loadXML('xml/stylesheet.xml');
        //alert("Delay");
        document.getElementById('fnt_fntname').value=xmlObj.childNodes[1].childNodes[1].childNodes[0].nodeValue;
    }
    else
    {
        var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 

        loadXML('xml/stylesheet.xml');
    
        document.getElementById('fnt_fntname').value=xmlObj.childNodes(0).childNodes(0).text;
    }
}
     //editordiv.document.execCommand("fontname",bShow,document.getElementById('fnt_fntname').value);
  // }
  

  
  
  
  
} 
 function removewhitespace(ctrl,e)
   {
   //alert("HI");
   //debugger;
     var CaretPosS = -1, CaretPosE = 0; 
     // Mozilla way:
     //ctrl=document.getElementById('editordiv');
     //alert(ctrl.selectionStart);
     //alert(Math.abs(ctrl.createTextRange().moveStart("character", -10000000)));

if(browser!="Microsoft Internet Explorer")
{
var pos;
    //firefox
    sel1=window.getSelection();
    pos=sel1.anchorOffset;
    if (pos > 0)
         {
           try
           {
           var val,val1;
           val=ctrl.value.substring(pos-1,pos)  
           val1=ctrl.value.substring(pos,pos+1)//ctrl.innerText.substring(start-2,ctrl.innerText.length-(start+1))
            if((val.charCodeAt() == 32) && (e.charCode == 32)) 
             {
               return false;  
             }
            else if((e.charCode == 32) && (val1.charCodeAt() == 32))
             {
               return false;  
             }
            else if((val.charCodeAt() == 160) && (e.charCode == 32) && (val1 == '\n'))
             {
               return false;  
             }
           }
           catch(err) {}
         }     
}
else
{
// Mozilla way:
//     if(ctrl.selectionStart || (ctrl.selectionStart == '0'))
//     {
//       CaretPosS = ctrl.selectionStart;
//       CaretPosE = ctrl.selectionEnd;

//       insertionS = CaretPosS == -1 ? CaretPosE : CaretPosS;
//       insertionE = CaretPosE;
//     }
     // IE way:
      if(document.selection && document.selection.createRange)
     {
       var start = end = 0;
       try
       {
        start = Math.abs(document.selection.createRange().moveStart("character", -10000000)); // start
         //start = Math.abs(((document.selection.createRange().htmlText).replace("<P>","").replace("</P>","<Br>")).moveStart("character", -10000000));
         if (start > 0)
         {
         start=start-18;
           try
           {
           var val,val1;
           val=ctrl.innerText.substring(start-2,start-1) 
           val1=ctrl.innerText.substring(start-1,start)//ctrl.innerText.substring(start-2,ctrl.innerText.length-(start+1))
           
            if((val.charCodeAt() == 32) && (e.keyCode == 32)) 
             {
               //alert('a');
               e.keyCode=0;
               return false;  
             }
            else if((e.keyCode == 32) && (val1.charCodeAt() == 32))
             {
               //alert('a');
               e.keyCode=0;
               return false;  
             }
           }
           catch(err) {}
         }
       }
       catch (e) {}
     }
 }
   }
 
//function removewhitespace(evt)
//{

////alert("fnt1");
//          /*change ankur*/
//  /////if the uom is only and only rol than no 2 white spaces are not allowed 
//  /*new change ankur sharma*/
//  var charCode = (evt.which) ? evt.which : event.keyCode
//  //alert(charCode);
//  if(document.getElementById('hiddenuom_desc').value=="ROL" )
//  {
//  var matter_text="";
//  var matter_text1="";
//         if(browser!="Microsoft Internet Explorer")
//        {
//             matter_text=document.getElementById('editordiv').textContent;
//             matter_text==matter_text.replace('   ',' ');
//             matter_text==matter_text.replace('  ',' ');
//        }
//        else
//        {
//             matter_text=document.getElementById('editordiv').outerText;
//              matter_text==matter_text.replace('   ',' ');
//             matter_text==matter_text.replace('  ',' ');
//        }
//    /*   if(charCode==32 && charCode==prevcode)
//        return false;
//    */
//  
//  prevcode=charCode;
//  }



//}
/*change ankur*/
function keyban(event)
{

    if(document.getElementById('hiddenuom').value=="RO0")
      {
        var matter_text="";
             if(browser!="Microsoft Internet Explorer")
            {
                 matter_text=document.getElementById('editordiv').value;
            }
            else
            {
                 matter_text=document.getElementById('editordiv').outerText;
            }
            matter_text=matter_text.split("");
            if(matter_text[matter_text.length-1]==" ")
            {
                if(event.keyCode==32)
                {
                    return false;
                }
            
            }
      
      
      }
      
}

/*new change */
function insertintomatter()
{
    source=document.getElementById("editordiv");
    if(document.getElementById('lbpickchar').value!="" && document.getElementById('lbpickchar').value!=null && document.getElementById('lbpickchar').value!=undefined)
    {
    var split_char=document.getElementById('lbpickchar').value.split("(");
        if(browser!="Microsoft Internet Explorer")
        {
            if(document.getElementById('editordiv').value=="")
            {
               
                insertAtCaret(source, split_char[0]);
                // document.getElementById('editordiv').value=split_char[0];
            }
            else
            {
                insertAtCaret(source, split_char[0]);
               // document.getElementById('editordiv').value=document.getElementById('editordiv').value+split_char[0];
            }
        }
        else
        {
             //matter_text=document.getElementById('editordiv').outerText=document.getElementById('insertintomatter').value;
             if(document.getElementById('editordiv').innerText=="")
            {
                insertAtCaret(source, split_char[0]);
                // document.getElementById('editordiv').innerText=split_char[0];
            }
            else
            {
               insertAtCaret(source, split_char[0]);
               // document.getElementById('editordiv').innerText=document.getElementById('editordiv').innerText+split_char[0];
            }
        }
    
    }    
    
    return false;
    

}
function insertintomatter1()
{
    source=document.getElementById("editordiv");
    var f_symbol="";
    if(document.getElementById('lbpickchar').value!="" && document.getElementById('lbpickchar').value!=null && document.getElementById('lbpickchar').value!=undefined)
    {
        var split_char=document.getElementById('lbpickchar').value.split("[");
        if(document.getElementById('lbpickchar').value.indexOf("[")<0)
        {
        var symbol1=split_char[0];
        f_symbol=symbol1.split("(")[0];
//            var ds_symbol=matter.getSpecialCharacter(document.getElementById('lbpickchar').value);
//            if(ds_symbol.value==null)
//            {
//                alert(ds_symbol.error.description);
//                return false;
//            }
//            else
//            {
//                f_symbol=ds_symbol.value.Tables[0].Rows[0].FONTNAME.split(":")[1]+ds_symbol.value.Tables[0].Rows[0].CHARACTER1;
//            }
        }
//        else
//            f_symbol=split_char[0];
       
       
      /*  if(browser!="Microsoft Internet Explorer")
        {
            if(document.getElementById('editordiv').value=="")
            {              
                insertAtCaret(source, split_char[0]);
                // document.getElementById('editordiv').value=split_char[0];
            }
            else
            {
           
               insertAtCaret(source, split_char[0]);
              
               // document.getElementById('editordiv').value=document.getElementById('editordiv').value+split_char[0];
            }
        }
        else
        {
            if(document.getElementById('editordiv').innerText=="")
            {
                insertAtCaret(source, split_char[0]);              
            }
            else
            {
               insertAtCaret(source, split_char[0]);             
            }  */
          
           
             if (document.all)  //for ie
             {                
                document.getElementById('editordiv').focus();
                oTextRange = document.selection.createRange();             
               
                oTextRange.text=oTextRange.text + f_symbol;
                //oTextRange.moveStart("character", split_char[0].length);
                oTextRange.moveStart("textedit", f_symbol.length);
              }
              else
              {                 
             //***  document.getElementById("editordiv").value +=split_char[0];
                 if (document.getElementById("editordiv").value.length==rng)
                  {
                     document.getElementById("editordiv").value=document.getElementById("editordiv").value + f_symbol;                  
                  }
                  else
                  {
                       document.getElementById("editordiv").value=document.getElementById("editordiv").value.substring(0,rng) + f_symbol + document.getElementById("editordiv").value.substring(rng,document.getElementById("editordiv").value.length);
                       setcur(document.getElementById("editordiv"),rng+f_symbol.length);
                  }                                
              } 
        }
   
  //  }
    //*********************
    document.getElementById("editordiv").value=document.getElementById("editordiv").value + " ";
   // document.getElementById('editordiv').focus();
    return false;
}
function setcur(ctl,pos)
{
   try
   {
       ctl.setSelectionRange;
       ctl.setSelectionRange(pos,pos);
   }
   catch (e)
   {
       
   }
}

/*new function */
//function chklogosession()
//{
//    if(document.getElementById('hiddensessionlogo').value=="" || document.getElementById('hiddensessionlogo').value==null)
//    {
//        alert("Please upload the logo");
//        //window.close();
//        return false;
//    
//    }
//    
//}