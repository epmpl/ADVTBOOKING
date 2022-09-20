E
// JScript File
var updaterecord=""
var myresult="False";
var badcount=0;
var ank="";
var ankur;
var flag=0;
var flagstn=1;
var flagfnt=1;
var flagtools=1;
var flagtxt=0;
var flagpic=0;
var flagnew=0;
var flagsts=0;
var flagline=0;
var idt=0;
var popuptxt=null;
var popuppic=null;
var ad_template=null;
var openlayouts=null;
var saveme1=null;
var saveas=null;
var currentid=null;
var trnsfr;
var editorhtml=null;
var topT=40;
var leftT=40;
var ctr=1;
var tempxml=null;
var enable=0;
var unit;
var exceedmatter=""
var x = new Array();
var objid1="";
var word1=""
var flagsaveedit=0;


/**************************************/
function contenttrue()
  {
  if(document.all)
   {
      document.getElementById('editordiv').contentEditable="true";
   }
else
  {
    document.getElementById('editordiv').contentEditable="false";
  }
}
/**************************************/
function disabled()
 {
   //alert('vast');
   var browser=navigator.appName;
   if(browser=="Microsoft Internet Explorer")
   // if(document.all)
     {
        editordiv.disabled=true;
        //document.getElementById('editordiv').isTextEdit=false;
        closeT.disabled=true;
        savesT.disabled=true;
        savesasT.disabled=true;
        printT.disabled=true;
        previewT.disabled=true;
        printT.disabled=true;
        cutT.disabled=true;
        copyT.disabled=true;
        pasteT.disabled=true;
        clearT.disabled=true;
        deleteT.disabled=true;
        //selectallT.disabled=true;
        rotateT.disabled=true;
        //stretchT.disabled=true;
        textboxT.disabled=true;
        picboxT.disabled=true;
        tagsT.disabled=true;
        txtproT.disabled=true;
        picproT.disabled=true;
        settingmnu.disabled=true;
        //createAd.disabled=true;
        saveAd.disabled=true;
        saveAdas.disabled=true;
        checkAds.disabled=true;
        previewAd.disabled=true;
        document.getElementById('saveedittemplate').disabled=true;
        printAd.disabled=true;
        //exitAd.disabled=true;
        exitAd.disabled=false;
        checktemplate.disabled=true;
       
        /*stndrd toolbar*/
        document.getElementById('savehidden').value="";
        document.getElementById('save').disabled=true;
        document.getElementById('save').src="icons/save_d.jpg"; 
        document.getElementById('cut').disabled=true;
        document.getElementById('cut').src="icons/cut_d.jpg"; 
//      document.getElementById('undo').disabled=true;
//      document.getElementById('undo').src="icons/undo_d.jpg"; 
//      document.getElementById('redo').disabled=true;
//      document.getElementById('redo').src="icons/redo_d.jpg"; 
        document.getElementById('copy').disabled=true;
        document.getElementById('copy').src="icons/copy_d.jpg"; 
        document.getElementById('paste').disabled=true;
        document.getElementById('paste').src="icons/paste_d.jpg"; 
        document.getElementById('deletes').disabled=true;
        document.getElementById('deletes').src="icons/delete_d.jpg"; 
        document.getElementById('checkad').disabled=true;
        document.getElementById('checkad').src="icons/Check-ad_d.jpg"; 
        document.getElementById('insertP').disabled=true;
        document.getElementById('insertP').src="icons/insertimage_d.jpg"; 
        document.getElementById('printer').disabled=true;
        document.getElementById('printer').src="icons/print_d.jpg"; 
        document.getElementById('text').disabled=true;
        document.getElementById('text').src="icons/textbox_d.jpg"; 
        document.getElementById('image').disabled=true;
        document.getElementById('image').src="icons/image boxT_d.jpg"; 
        /* the status bar*/
        document.getElementById('rightpaste').disabled=true;
        document.getElementById('deletea').disabled=true;
//        document.getElementById('getimg').disabled=true;
        document.getElementById('sr1').style.visibility='hidden';
        document.getElementById('sr2').style.visibility='hidden';
        document.getElementById('sr3').style.visibility='hidden';
           document.getElementById('Label7').style.visibility='hidden';
        document.getElementById('selected_name').style.visibility='hidden';
        /*document.getElementById('sr4').style.visibility='hidden';
        /*document.getElementById('sr5').style.visibility='hidden';*/
        document.getElementById('sr6').style.visibility='hidden';
        /*tools */
        document.getElementById('pointer').disabled=true;
        document.getElementById('pointer').src="icons/pointer_d.jpg"; 
        document.getElementById('line').disabled=true;
        document.getElementById('line').src="icons/line_d.jpg"; 
        document.getElementById('cropme').disabled=true;
        document.getElementById('cropme').src="icons/crop_d.jpg"; 
        document.getElementById('texttool').disabled=true;
        document.getElementById('texttool').src="icons/textbox_d.jpg"; 
        document.getElementById('imagetool').disabled=true;
        document.getElementById('imagetool').src="icons/image boxT_d.jpg"; 
        document.getElementById('tagtool').disabled=true;
        document.getElementById('tagtool').src="icons/tags_d.jpg"; 
        //document.getElementById('clrpckrtool').disabled=true;
        //document.getElementById('clrpckrtool').src="icons/color-picker_d.jpg"; 
        document.getElementById('fliptool').disabled=true;
        document.getElementById('fliptool').src="icons/flip_d.jpg"; 
        document.getElementById('hand').disabled=true;
        document.getElementById('hand').src="icons/hand.jpg"; 
        document.getElementById('rotatetool').disabled=true;
        document.getElementById('rotatetool').src="icons/rotate_d.jpg"; 
        //document.getElementById('radius').style.visibility='hidden';
        document.getElementById('toolsbox_fcolor').disabled=true;
        document.getElementById('toolsbox_fcolor').style.borderColor='gray';
        document.getElementById('toolsbox_bgcolor').disabled=true;
        document.getElementById('toolsbox_bgcolor').style.borderColor='gray';
        
        //settingmnu.disabled=true;       
        /****font toolbar********/
        document.getElementById('underline').disabled=true; 
        document.getElementById('underline').src="icons/underline_d.jpg"; 
        document.getElementById('number').disabled=true;
        document.getElementById('number').src="icons/numbering_d.jpg"; 
        document.getElementById('bullets').disabled=true;
        document.getElementById('bullets').src="icons/bullets_d.jpg"; 
        document.getElementById('italic').disabled=true;
        document.getElementById('italic').src="icons/italic_d.jpg"; 
        document.getElementById('bold').disabled=true;
        document.getElementById('bold').src="icons/bold_d.jpg"; 
        document.getElementById('fonttoolbar_fntname').disabled=true;
        document.getElementById('fonttoolbar_fntsize').disabled=true;
        document.getElementById('fonttoolbar_fntname').disabled=true;
        document.getElementById('fonttoolbar_alignment').disabled=true;
      }
    
 else if(browser!="Microsoft Internet Explorer")
    //else
      {
        enable=0;
       // alert("hello");
       document.getElementById('savehidden').value="";
        document.getElementById('editordiv').disabled=true;
        //document.getElementById('editordiv').isTextEdit=false;
       //document.getElementById('closeT').className="disabled1";
        document.getElementById('closeT').onclick=ignoreClick;
        document.getElementById('closeT').style.cursor="text";
        document.getElementById('saveedittemplate').onclick=ignoreClick;
         document.getElementById('saveedittemplate').style.cursor="text";
        //document.getElementById('savesT').className="disabled1";
        document.getElementById('savesT').onclick=ignoreClick;
         document.getElementById('savesT').style.cursor="text";
        document.getElementById('savesasT').onclick=ignoreClick;
        document.getElementById('savesasT').style.cursor="text";
        document.getElementById('printT').onclick=ignoreClick;
         document.getElementById('printT').style.cursor="text";
        document.getElementById('previewT').onclick=ignoreClick;
        document.getElementById('previewT').style.cursor="text";
        document.getElementById('printT').onclick=ignoreClick;
        document.getElementById('printT').style.cursor="text";
        document.getElementById('cutT').onclick=ignoreClick;
        document.getElementById('cutT').style.cursor="text";
        document.getElementById('copyT').onclick=ignoreClick;
        document.getElementById('copyT').style.cursor="text";
        document.getElementById('pasteT').onclick=ignoreClick;
        document.getElementById('pasteT').style.cursor="text";
        document.getElementById('pasteT').onclick=ignoreClick;
        document.getElementById('pasteT').style.cursor="text";
        document.getElementById('checktemplate').onclick=ignoreClick;
        document.getElementById('checktemplate').style.cursor="text";
        //document.getElementById('deleteT').onclick=ignoreClick;
        //document.getElementById('selectallT').disabled=true;
        document.getElementById('rotateT').onclick=ignoreClick;
        document.getElementById('rotateT').style.cursor="text";
        //stretchT.disabled=true;
        document.getElementById('textboxT').onclick=ignoreClick;
        document.getElementById('textboxT').style.cursor="text";
        document.getElementById('picboxT').onclick=ignoreClick;
        document.getElementById('picboxT').style.cursor="text";
        document.getElementById('tagsT').onclick=ignoreClick;
        document.getElementById('tagsT').style.cursor="text";
        document.getElementById('txtproT').onclick=ignoreClick;
        document.getElementById('txtproT').style.cursor="text";
        document.getElementById('picproT').onclick=ignoreClick;
        document.getElementById('picproT').style.cursor="text";
        document.getElementById('settingmnu').disabled=true;
        
        //createAd.disabled=true;
        /******************/
        document.getElementById('abt').onclick=ignoreClick;
        document.getElementById('abt').style.cursor="text";
        document.getElementById('index').onclick=ignoreClick;
        document.getElementById('index').style.cursor="text";
        /*****************/
        document.getElementById('saveAd').onclick=ignoreClick;
        document.getElementById('saveAd').style.cursor="text";
        document.getElementById('saveAdas').onclick=ignoreClick;
        document.getElementById('saveAdas').style.cursor="text";
        document.getElementById('checkAds').onclick=ignoreClick;
        document.getElementById('checkAds').style.cursor="text";
        document.getElementById('previewAd').onclick=ignoreClick;
        document.getElementById('previewAd').style.cursor="text";
        document.getElementById('printAd').onclick=ignoreClick;
        document.getElementById('printAd').style.cursor="text";
        //exitAd.disabled=true;
        document.getElementById('exitAd').onclick=ignoreClick;
        document.getElementById('exitAd').style.cursor="text";
        /*stndrd toolbar*/
        document.getElementById('save').disabled=true;
        document.getElementById('save').src="icons/save_d.jpg"; 
        document.getElementById('cut').disabled=true;
        document.getElementById('cut').src="icons/cut_d.jpg"; 
        //document.getElementById('undo').disabled=true;
        //document.getElementById('undo').src="icons/undo_d.jpg"; 
        //document.getElementById('redo').disabled=true;
        //document.getElementById('redo').src="icons/redo_d.jpg"; 
        document.getElementById('copy').disabled=true;
        document.getElementById('copy').src="icons/copy_d.jpg"; 
        document.getElementById('paste').disabled=true;
        document.getElementById('paste').src="icons/paste_d.jpg"; 
        document.getElementById('deletes').disabled=true;
        document.getElementById('deletes').src="icons/delete_d.jpg"; 
        document.getElementById('checkad').disabled=true;
        document.getElementById('checkad').src="icons/Check-ad_d.jpg"; 
        document.getElementById('insertP').disabled=true;
        document.getElementById('insertP').src="icons/insertimage_d.jpg"; 
        document.getElementById('printer').disabled=true;
        document.getElementById('printer').src="icons/print_d.jpg"; 
        document.getElementById('text').disabled=true;
        document.getElementById('text').src="icons/textbox_d.jpg"; 
        document.getElementById('image').disabled=true;
        document.getElementById('image').src="icons/image boxT_d.jpg"; 
        /* the status bar*/
        document.getElementById('rightpaste').disabled=true;
        document.getElementById('deletea').disabled=true;
        //document.getElementById('getimg').disabled=true;
        document.getElementById('sr1').style.visibility='hidden';
        document.getElementById('sr2').style.visibility='hidden';
        document.getElementById('sr3').style.visibility='hidden';
           document.getElementById('Label7').style.visibility='hidden';
        document.getElementById('selected_name').style.visibility='hidden';
        /*document.getElementById('sr4').style.visibility='hidden';
        /*document.getElementById('sr5').style.visibility='hidden';*/
        document.getElementById('sr6').style.visibility='hidden';
        /*tools */
        document.getElementById('pointer').disabled=true;
        document.getElementById('pointer').src="icons/pointer_d.jpg"; 
        document.getElementById('line').disabled=true;
        document.getElementById('line').src="icons/line_d.jpg"; 
        document.getElementById('cropme').disabled=true;
        document.getElementById('cropme').src="icons/crop_d.jpg"; 
        document.getElementById('texttool').disabled=true;
        document.getElementById('texttool').src="icons/textbox_d.jpg"; 
        document.getElementById('imagetool').disabled=true;
        document.getElementById('imagetool').src="icons/image boxT_d.jpg"; 
        document.getElementById('tagtool').disabled=true;
        document.getElementById('tagtool').src="icons/tags_d.jpg"; 
        //document.getElementById('clrpckrtool').disabled=true;
        //document.getElementById('clrpckrtool').src="icons/color-picker_d.jpg"; 
        document.getElementById('fliptool').disabled=true;
        document.getElementById('fliptool').src="icons/flip_d.jpg"; 
        document.getElementById('hand').disabled=true;
        document.getElementById('hand').src="icons/hand.jpg"; 
        document.getElementById('rotatetool').disabled=true;
        document.getElementById('rotatetool').src="icons/rotate_d.jpg"; 
        //document.getElementById('radius').style.visibility='hidden';
        document.getElementById('toolsbox_fcolor').disabled=true;
        document.getElementById('toolsbox_fcolor').style.borderColor='gray';
        document.getElementById('toolsbox_bgcolor').disabled=true;
        document.getElementById('toolsbox_bgcolor').style.borderColor='gray';
        
        
        
        fonttoolbardisabled();
        //settingmnu.disabled=true;       
        /****font toolbar********/
//        document.getElementById('underline').disabled=true; 
//        document.getElementById('underline').src="icons/underline_d.jpg"; 
//        document.getElementById('number').disabled=true;
//        document.getElementById('number').src="icons/numbering_d.jpg"; 
//        document.getElementById('bullets').disabled=true;
//        document.getElementById('bullets').src="icons/bullets_d.jpg"; 
//        document.getElementById('italic').disabled=true;
//        document.getElementById('italic').src="icons/italic_d.jpg"; 
//        document.getElementById('bold').disabled=true;
//        document.getElementById('bold').src="icons/bold_d.jpg"; 
//        document.getElementById('fonttoolbar_fntname').disabled=true;
//        document.getElementById('fonttoolbar_fntsize').disabled=true;
//        document.getElementById('fonttoolbar_fntname').disabled=true;
//        document.getElementById('fonttoolbar_alignment').disabled=true; 
//        document.getElementById('prevalue').value="";
      }
   }
 
/*********************************/
function ignoreClick()
{
return false;
}
      
/***********************this is code for enabled all icons**********************/      
 function enabled()
  {
      var browser=navigator.appName;
     if(browser!="Microsoft Internet Explorer")
      {
        //enable=1;
        document.getElementById('prevalue').value="";
        document.getElementById('savehtml').value="";
        document.getElementById('editordiv').disabled=false;
         //editordiv.disabled=true;
         ////alert('abbn');
        /*opener.*/document.getElementById('closeT').onclick=null;
        document.getElementById('closeT').style.cursor="pointer";
        
        if(flagsaveedit==1)
        {
        /*opener.*/document.getElementById('savesT').onclick=ignoreClick;
        document.getElementById('savesT').style.cursor="text";
        }
        else
        {
        /*opener.*/document.getElementById('savesT').onclick=null;
        document.getElementById('savesT').style.cursor="pointer";
        }
        /*opener.*/document.getElementById('savesasT').onclick=null;
        document.getElementById('savesasT').style.cursor="pointer";
        /*opener.*/document.getElementById('printT').onclick=null;
        document.getElementById('printT').style.cursor="pointer";
        /*opener.*/document.getElementById('previewT').onclick=null;
        document.getElementById('previewT').style.cursor="pointer";
        /*opener.*/document.getElementById('printT').onclick=null;
        document.getElementById('checktemplate').onclick=null;
        document.getElementById('checktemplate').style.cursor="pointer";
        /*opener.*/document.getElementById('cutT').onclick=null;
        document.getElementById('cutT').style.cursor="pointer";
        /*opener.*/document.getElementById('copyT').onclick=null;
         document.getElementById('copyT').style.cursor="pointer";
       //document.getElementById('undo').disabled=false;
       //document.getElementById('redo').disabled=false;
         document.getElementById('clearT').onclick=null;
         document.getElementById('clearT').style.cursor="pointer";
         //document.getElementById('deleteT').onclick=null;
         //document.getElementById('selectallT').disabled=false;
         
        /*opener.*/document.getElementById('rotateT').onclick=null;
        document.getElementById('rotateT').style.cursor="pointer";
        ///*opener.*/document.getElementById('stretchT').disabled=false;
        /*opener.*/document.getElementById('textboxT').onclick=null;
        document.getElementById('textboxT').style.cursor="pointer";
        /*opener.*/document.getElementById('picboxT').onclick=null;
        document.getElementById('picboxT').style.cursor="pointer";
        /*opener.*/document.getElementById('tagsT').onclick=null;
        document.getElementById('tagsT').style.cursor="pointer";
         document.getElementById('txtproT').onclick=null;
         document.getElementById('txtproT').style.cursor="pointer";
         document.getElementById('picproT').onclick=null;
       document.getElementById('picproT').style.cursor="pointer";
        /*opener.*/document.getElementById('createAd').onclick=null;
        document.getElementById('createAd').style.cursor="pointer";
//        document.getElementById('saveAd').onclick=null;
//        document.getElementById('saveAd').style.cursor="pointer";
//       document.getElementById('saveAdas').onclick=null;
//       document.getElementById('saveAdas').style.cursor="pointer";
//        document.getElementById('previewAd').onclick=null;
//        document.getElementById('previewAd').style.cursor="pointer";
//         document.getElementById('printAd').onclick=null;
//         document.getElementById('printAd').style.cursor="pointer";
//          document.getElementById('exitAd').onclick=null;
//           document.getElementById('exitAd').style.cursor="pointer";
     // checkAds.disabled=false;
     //previewAd.disabled=false;
    //printAd.disabled=false;
   //exitAd.disabled=false;
        
        /* the stndard toolbar*/
        /*opener.*/document.getElementById('save').disabled=false;
        /*opener.*/document.getElementById('save').src="icons/save.jpg"; 
        /*opener.*/document.getElementById('cut').disabled=false;
        /*opener.*/document.getElementById('cut').src="icons/cut.jpg"; 
        /*opener.*/document.getElementById('copy').disabled=false;
        /*opener.*/document.getElementById('copy').src="icons/copy.jpg"; 
        //opener.*/document.getElementById('paste').disabled=false;
        //opener.*/document.getElementById('paste').src="icons/paste.jpg"; 
        /*opener.*/document.getElementById('deletes').disabled=false;
        /*opener.*/document.getElementById('deletes').src="icons/delete.jpg"; 
          document.getElementById('insertP').disabled=false;
          document.getElementById('insertP').src="icons/Picture-box.jpg"; 
        /*opener.*/document.getElementById('checkad').disabled=false;
        /*opener.*/document.getElementById('checkad').src="icons/Check-ad.jpg"; 
        /*opener.*/document.getElementById('printer').disabled=false;
        /*opener.*/document.getElementById('printer').src="icons/print.jpg"; 
        /*opener.*/document.getElementById('text').disabled=false;
        /*opener.*/document.getElementById('text').src="icons/textbox.jpg"; 
        /*opener.*/document.getElementById('image').disabled=false;
        /*opener.*/document.getElementById('image').src="icons/image boxT.jpg";    
        /* the status bar*/
        document.getElementById('sr1').style.visibility='visible';
        document.getElementById('sr2').style.visibility='visible';
        /*opener.*/document.getElementById('sr3').style.visibility='visible';
           document.getElementById('Label7').style.visibility='visible';
        document.getElementById('selected_name').style.visibility='visible';
        /*opener.document.getElementById('sr4').style.visibility='visible';*/
        /*opener.document.getElementById('sr5').style.visibility='visible';*/
        /*opener.*/document.getElementById('sr6').style.visibility='visible';
        //opener.*/document.getElementById('radius').style.visibility='visible';
        /***********tools **********/
        document.getElementById('pointer').disabled=false;
        document.getElementById('pointer').src="icons/pointer.jpg"; 
        document.getElementById('line').disabled=false;
        document.getElementById('line').src="icons/line.jpg"; 
        document.getElementById('cropme').disabled=false;
        document.getElementById('cropme').src="icons/crop.jpg"; 
        document.getElementById('texttool').disabled=false;
        document.getElementById('texttool').src="icons/textbox.jpg"; 
        document.getElementById('imagetool').disabled=false;
        document.getElementById('imagetool').src="icons/image boxT.jpg"; 
        document.getElementById('tagtool').disabled=false;
        document.getElementById('tagtool').src="icons/tags.jpg"; 
        //document.getElementById('clrpckrtool').disabled=false;
        //document.getElementById('clrpckrtool').src="icons/color picker.jpg"; 
        document.getElementById('fliptool').disabled=false;
        document.getElementById('fliptool').src="icons/flipT.jpg"; 
        document.getElementById('hand').disabled=false;
        document.getElementById('hand').src="icons/hand.jpg"; 
        document.getElementById('rotatetool').disabled=false;
        document.getElementById('rotatetool').src="icons/rotateT.jpg"; 
        document.getElementById('toolsbox_fcolor').disabled=false;
        document.getElementById('toolsbox_fcolor').style.borderColor='Black';
        document.getElementById('toolsbox_bgcolor').disabled=false;
        document.getElementById('toolsbox_bgcolor').style.borderColor='Black';
        /*********font toolbar***********/
//        document.getElementById('underline').disabled=false; 
//        document.getElementById('underline').src="icons/underline.jpg"; 
//        document.getElementById('number').disabled=false;
//        document.getElementById('number').src="icons/numbering.jpg"; 
//        document.getElementById('bullets').disabled=false;
//        document.getElementById('bullets').src="icons/bullets.jpg"; 
//        document.getElementById('italic').disabled=false;
//        document.getElementById('italic').src="icons/italic.jpg"; 
//        document.getElementById('bold').disabled=false;
//        document.getElementById('bold').src="icons/bold.jpg"; 
//        document.getElementById('fonttoolbar_alignment').disabled=false;
//        document.getElementById('fonttoolbar_fntsize').disabled=false;
//        document.getElementById('fonttoolbar_fntname').disabled=false;
       
      }
    else if(browser=="Microsoft Internet Explorer")
        {
         editordiv.disabled=false;
         /*opener.*/document.getElementById('closeT').disabled=false;
         /*opener.*/document.getElementById('savesT').disabled=false;
         /*opener.*/document.getElementById('savesasT').disabled=false;
         /*opener.*/document.getElementById('printT').disabled=false;
         /*opener.*/document.getElementById('previewT').disabled=false;
         /*opener.*/document.getElementById('printT').disabled=false;
         /*opener.*/document.getElementById('cutT').disabled=false;
         /*opener.*/document.getElementById('copyT').disabled=false;
         document.getElementById('checktemplate').disabled=false;
         document.getElementById('saveedittemplate').disabled=false;
        // checktemplate.disabled=true;
      //  saveedittemplate.disabled=true;
         //document.getElementById('undo').disabled=false;
         //document.getElementById('redo').disabled=false;
          clearT.disabled=false;
          deleteT.disabled=true;
         //selectallT.disabled=false;
        /*opener.*/document.getElementById('rotateT').disabled=false;
        ///*opener.*/document.getElementById('stretchT').disabled=false;
        /*opener.*/document.getElementById('textboxT').disabled=false;
        /*opener.*/document.getElementById('picboxT').disabled=false;
        /*opener.*/document.getElementById('tagsT').disabled=false;
        document.getElementById('txtproT').disabled=false;
        document.getElementById('picproT').disabled=false;
        
        ///*opener.*/document.getElementById('createAd').disabled=false;
//        saveAd.disabled=false;
//        saveAdas.disabled=false;
//        checkAds.disabled=false;
//        previewAd.disabled=false;
//        printAd.disabled=false;
//        exitAd.disabled=false;
        
        /* the stndard toolbar*/
        /*opener.*/document.getElementById('save').disabled=false;
        /*opener.*/document.getElementById('save').src="icons/save.jpg"; 
        /*opener.*/document.getElementById('cut').disabled=false;
        /*opener.*/document.getElementById('cut').src="icons/cut.jpg"; 
        /*opener.*/document.getElementById('copy').disabled=false;
        /*opener.*/document.getElementById('copy').src="icons/copy.jpg"; 
        //opener.*/document.getElementById('paste').disabled=false;
        //opener.*/document.getElementById('paste').src="icons/paste.jpg"; 
        /*opener.*/document.getElementById('deleteT').disabled=false;
         document.getElementById('deletea').disabled=false;
         document.getElementById('deletes').src="icons/delete.jpg"; 
                   document.getElementById('insertP').disabled=false;
                   document.getElementById('insertP').src="icons/Picture-box.jpg"; 
        /*opener.*/document.getElementById('checkad').disabled=false;
        /*opener.*/document.getElementById('checkad').src="icons/Check-ad.jpg"; 
        /*opener.*/document.getElementById('printer').disabled=false;
        /*opener.*/document.getElementById('printer').src="icons/print.jpg"; 
        /*opener.*/document.getElementById('text').disabled=false;
        /*opener.*/document.getElementById('text').src="icons/textbox.jpg"; 
        /*opener.*/document.getElementById('image').disabled=false;
        /*opener.*/document.getElementById('image').src="icons/image boxT.jpg";    
        /* the status bar*/
        document.getElementById('sr1').style.visibility='visible';
        document.getElementById('sr2').style.visibility='visible';
        /*opener.*/document.getElementById('sr3').style.visibility='visible';
        document.getElementById('Label7').style.visibility='visible';
        document.getElementById('selected_name').style.visibility='visible';
        /*opener.document.getElementById('sr4').style.visibility='visible';*/
        /*opener.document.getElementById('sr5').style.visibility='visible';*/
        /*opener.*/document.getElementById('sr6').style.visibility='visible';
        //opener.*/document.getElementById('radius').style.visibility='visible';
        /***********tools **********/
        document.getElementById('pointer').disabled=false;
        document.getElementById('pointer').src="icons/pointer.jpg"; 
        document.getElementById('line').disabled=false;
        document.getElementById('line').src="icons/line.jpg"; 

        document.getElementById('cropme').disabled=false;
        document.getElementById('cropme').src="icons/crop.jpg"; 
        document.getElementById('texttool').disabled=false;
        document.getElementById('texttool').src="icons/textbox.jpg"; 
        document.getElementById('imagetool').disabled=false;
        document.getElementById('imagetool').src="icons/image boxT.jpg"; 
        document.getElementById('tagtool').disabled=false;
        document.getElementById('tagtool').src="icons/tags.jpg"; 
        //document.getElementById('clrpckrtool').disabled=false;
        //document.getElementById('clrpckrtool').src="icons/color picker.jpg"; 
        document.getElementById('fliptool').disabled=false;
        document.getElementById('fliptool').src="icons/flipT.jpg"; 
        document.getElementById('hand').disabled=false;
        document.getElementById('hand').src="icons/hand.jpg"; 
        document.getElementById('rotatetool').disabled=false;
        document.getElementById('rotatetool').src="icons/rotateT.jpg"; 
        document.getElementById('toolsbox_fcolor').disabled=false;
        document.getElementById('toolsbox_fcolor').style.borderColor='Black';
        document.getElementById('toolsbox_bgcolor').disabled=false;
        document.getElementById('toolsbox_bgcolor').style.borderColor='Black';
        /*********font toolbar***********/
//        document.getElementById('underline').disabled=false; 
//        document.getElementById('underline').src="icons/underline.jpg"; 
//        document.getElementById('number').disabled=false;
//        document.getElementById('number').src="icons/numbering.jpg"; 
//        document.getElementById('bullets').disabled=false;
//        document.getElementById('bullets').src="icons/bullets.jpg"; 
//        document.getElementById('italic').disabled=false;
//        document.getElementById('italic').src="icons/italic.jpg"; 
//        document.getElementById('bold').disabled=false;
//        document.getElementById('bold').src="icons/bold.jpg"; 
//        document.getElementById('fonttoolbar_alignment').disabled=false;
//        document.getElementById('fonttoolbar_fntsize').disabled=false;
//        document.getElementById('fonttoolbar_fntname').disabled=false;
        
        }
     }
     
/**************************************************************************/     
             
    function saveenabled()
       {
          document.getElementById('saveT').disabled=false;
          //document.getElementById('saveT').focus();
          return false;
        }
        
        
 function template_ads()
  {
      //alert('ajay');
      var browser=navigator.appName;
      if(browser=="Microsoft Internet Explorer")
      {
     if(ad_template==1)
      {
            //temp
            document.getElementById('closeT').disabled=true;
            document.getElementById('savesT').disabled=true;
            document.getElementById('savesasT').disabled=true;
            document.getElementById('printT').disabled=true;
            document.getElementById('previewT').disabled=true;
            document.getElementById('printT').disabled=true;
            //ads
            document.getElementById('saveAd').disabled=false;
            document.getElementById('saveAdas').disabled=false;
            document.getElementById('checkAds').disabled=false;
            document.getElementById('previewAd').disabled=false;
            document.getElementById('printAd').disabled=false;
            document.getElementById('exitAd').disabled=false;
       }
      else if(ad_template==0)
      {
      // ads
      
      
      
        document.getElementById('saveAd').disabled=true;
        document.getElementById('saveAdas').disabled=true;
        document.getElementById('checkAds').disabled=true;
        document.getElementById('previewAd').disabled=true;
        document.getElementById('printAd').disabled=true;
        document.getElementById('exitAd').disabled=true;
        // template
        document.getElementById('closeT').disabled=false;
        document.getElementById('savesT').disabled=false;
        document.getElementById('savesasT').disabled=false;
        document.getElementById('printT').disabled=false;
        document.getElementById('previewT').disabled=false;
        document.getElementById('printT').disabled=false;
            
      }
    }
   else if(browser!="Microsoft Internet Explorer")
   {
   
     if(ad_template==1)
      {
            //temp
            document.getElementById('closeT').onclick=ignoreClick;
            document.getElementById('closeT').style.cursor="text";
             document.getElementById('savesT').onclick=ignoreClick;
         document.getElementById('savesT').style.cursor="text";
        document.getElementById('savesasT').onclick=ignoreClick;
        document.getElementById('savesasT').style.cursor="text";
        document.getElementById('printT').onclick=ignoreClick;
         document.getElementById('printT').style.cursor="text";
        document.getElementById('checktemplate').onclick=ignoreClick;
         document.getElementById('checktemplate').style.cursor="text";
         
        document.getElementById('previewT').onclick=ignoreClick;
        document.getElementById('previewT').style.cursor="text";
        document.getElementById('printT').onclick=ignoreClick;
        document.getElementById('printT').style.cursor="text";
//            document.getElementById('closeT').disabled=true;
//            document.getElementById('savesT').disabled=true;
//            document.getElementById('savesasT').disabled=true;
//            document.getElementById('printT').disabled=true;
//            document.getElementById('previewT').disabled=true;
//            document.getElementById('printT').disabled=true;
            //ads
            document.getElementById('saveAd').onclick=null;
        document.getElementById('saveAd').style.cursor="pointer";
       document.getElementById('saveAdas').onclick=null;
       document.getElementById('saveAdas').style.cursor="pointer";
       document.getElementById('checkAds').onclick=null;
       document.getElementById('checkAds').style.cursor="pointer";
        document.getElementById('previewAd').onclick=null;
        document.getElementById('previewAd').style.cursor="pointer";
         document.getElementById('printAd').onclick=null;
         document.getElementById('printAd').style.cursor="pointer";
          document.getElementById('exitAd').onclick=null;
           document.getElementById('exitAd').style.cursor="pointer";
            document.getElementById('checkad').onclick=CheckAd;
            document.getElementById('save').onclick=saveaddialog;
//            document.getElementById('saveAd').disabled=false;
//            document.getElementById('saveAdas').disabled=false;
//            document.getElementById('checkAds').disabled=false;
//            document.getElementById('previewAd').disabled=false;
//            document.getElementById('printAd').disabled=false;
//            document.getElementById('exitAd').disabled=false;
       }
      else if(ad_template==0)
      {
        //alert('ajay');
        // ads
         document.getElementById('saveAd').onclick=ignoreClick;
        document.getElementById('saveAd').style.cursor="text";
        document.getElementById('saveAdas').onclick=ignoreClick;
        document.getElementById('saveAdas').style.cursor="text";
        document.getElementById('checkAds').onclick=ignoreClick;
        document.getElementById('checkAds').style.cursor="text";
        document.getElementById('previewAd').onclick=ignoreClick;
        document.getElementById('previewAd').style.cursor="text";
        document.getElementById('printAd').onclick=ignoreClick;
        document.getElementById('printAd').style.cursor="text";
        //exitAd.disabled=true;
        document.getElementById('exitAd').onclick=ignoreClick;
        document.getElementById('exitAd').style.cursor="text";
         document.getElementById('checkad').onclick=ignoreClick;
         document.getElementById('save').onclick=savedialog;
//        document.getElementById('saveAd').disabled=true;
//        document.getElementById('saveAdas').disabled=true;
//        document.getElementById('checkAds').disabled=true;
//        document.getElementById('previewAd').disabled=true;
//        document.getElementById('printAd').disabled=true;
//        document.getElementById('exitAd').disabled=true;
        // template
        /*opener.*/document.getElementById('savesT').onclick=null;
        document.getElementById('savesT').style.cursor="pointer";
        /*opener.*/document.getElementById('savesasT').onclick=null;
        document.getElementById('savesasT').style.cursor="pointer";
        /*opener.*/document.getElementById('printT').onclick=null;
        document.getElementById('printT').style.cursor="pointer";
        /*opener.*/document.getElementById('previewT').onclick=null;
        document.getElementById('previewT').style.cursor="pointer";
        /*opener.*/document.getElementById('printT').onclick=null;
         document.getElementById('checktemplate').onclick=null;
         document.getElementById('checktemplate').style.cursor="pointer";
//        document.getElementById('closeT').disabled=false;
//        document.getElementById('savesT').disabled=false;
//        document.getElementById('savesasT').disabled=false;
//        document.getElementById('printT').disabled=false;
//        document.getElementById('previewT').disabled=false;
//        document.getElementById('printT').disabled=false;
       }
   
   }
 }
 
       
 function fonttoolbardisabled()
      {
        document.getElementById('underline').disabled=true; 
        document.getElementById('underline').src="icons/underline_d.jpg"; 
        document.getElementById('number').disabled=true;
        document.getElementById('number').src="icons/numbering_d.jpg"; 
        document.getElementById('bullets').disabled=true;
        document.getElementById('bullets').src="icons/bullets_d.jpg"; 
        document.getElementById('italic').disabled=true;
        document.getElementById('italic').src="icons/italic_d.jpg"; 
        document.getElementById('bold').disabled=true;
        document.getElementById('bold').src="icons/bold_d.jpg"; 
        document.getElementById('fonttoolbar_fntname').disabled=true;
        document.getElementById('fonttoolbar_fntsize').disabled=true;
        document.getElementById('fonttoolbar_fntname').disabled=true;
        document.getElementById('fonttoolbar_alignment').disabled=true;
      
      }
     
function fonttoolbarenabled()
      {
              /*********font toolbar***********/
        document.getElementById('underline').disabled=false; 
       document.getElementById('underline').src="icons/underline.jpg"; 
       document.getElementById('number').disabled=false;
       document.getElementById('number').src="icons/numbering.jpg"; 
       document.getElementById('bullets').disabled=false;
       document.getElementById('bullets').src="icons/bullets.jpg"; 
       document.getElementById('italic').disabled=false;
       document.getElementById('italic').src="icons/italic.jpg"; 
       document.getElementById('bold').disabled=false;
       document.getElementById('bold').src="icons/bold.jpg"; 
        document.getElementById('fonttoolbar_alignment').disabled=false;
        document.getElementById('fonttoolbar_fntsize').disabled=false;
        document.getElementById('fonttoolbar_fntname').disabled=false;
     
      }      
            
       
       
function onlynos(ab){
    //if(event.keyCode>=46 && event.keyCode<=57)
    //{
   var fld=ab.value;
        if(fld!="")
           {
               //var expression= ^-{0,1}\d*\.{0,1}\d+$;
               ////////////(/^\d+(\.\d{1,2})?$/i)
              if(fld.match(/\d+(\.\d{1,2})?$/i))
               //if(fld.match(\.
                 {
                    return true;
                 }
               else
                 {
                    alert("Input error")
                    //document.getElementById(ab).focus();
                    ab.focus();
                    ab.value="";
                    return false;
                  }
                       
             }
       }


function chkvalue(e)
{
    var flag="";
    //return allamount121(e);
    e=document.getElementById(e);//.value;
    //alert(e);
    //alert(e.value);
    //var fld=e.value;
    var fld=e.value;
	if(fld!="")
	{
	    if(fld<=999)
	    {
	        //var found=fld.match(".")
            //if(found){e.maxLength=4;}else{e.maxLength =3;}
		    //var expression= ^-{0,1}\d*\.{0,1}\d+$;
		    //if(fld.match(/^\d+(\.\d{1,2})?$/i))
		    if(fld.match(/^\d+(\.\d{1,2})?$/i))
		    {
    		    flag="t";
		        return flag;
		    }else{
		        alert("Input Error")
		        var str=e.id;
		        e.value="";
		        flag="f";
		        return flag;
		    }
		}else alert('Range too long');e.focus();
	}
}



/************************ getid function******************/
function getid(obj)
 {
  if(document.all)
   {
   if(obj.id=="outer")
        {
            fonttoolbardisabled();
            document.getElementById('linedialog').style.display="none";
            document.getElementById('textdialog').style.display="none";
            document.getElementById('openaddialog').style.display="none";
            document.getElementById('picdialog').style.display='none';
            document.getElementById('tagsdiv').style.display='none';
            //document.getElementById('toolsbox_fcolor').disabled=true;
            document.getElementById('spltg').style.display='none';
            document.getElementById('spltg').style.visibility;
            document.getElementById('opendialog1').style.display='none';
            document.getElementById('opendialog').style.display='none';
            document.getElementById('rotatediv').style.display='none';
            document.getElementById('newdialog').style.display='none';
             document.getElementById('spltg').style.display='none';
             document.getElementById('colorcodeT_F').style.display='none';
         }
     else
       {
          var splitevalu=obj.id.split("~")
          // alert("3");
          // alert(splitevalu[1]);
           if(splitevalu[1]=="text")
            {
                    fonttoolbarenabled();
                   document.getElementById('linedialog').style.display='none';
                   document.getElementById('picdialog').style.display='none';
                   //document.getElementById('tmpcat').style.display="none";
                   document.getElementById('tagsdiv').style.display='none';
                   document.getElementById('textdialog').style.display='Block';
                   document.getElementById('myhdnval').value=obj.id;
                   document.getElementById('opendialog1').style.display='none';
                   document.getElementById('opendialog').style.display='none';
                   //document.getElementById('opendialog').style.display='none';
                   document.getElementById('rotatediv').style.display='none';
                   document.getElementById('openaddialog').style.display="none";
                   document.getElementById('newdialog').style.display='none';
                   document.getElementById('spltg').style.display='none';
                   //document.getElementById('colorcodeT_F').disabled=true;
                   //document.getElementById('bgcolor').disabled=true;
                  // document.getElementById('toolsbox_fcolor').disabled=true;
                   //document.getElementById('colorcodeT_B').value="";
                   //document.getElementById('toolsbox_bgcolor').disabled="disabled";
                   //document.getElementById('openaddialog').style.display='none';
                   
                   return false;
           }
        else if(splitevalu[1]=="picture")
         {
                fonttoolbardisabled();
                document.getElementById('linedialog').style.display='none';
                document.getElementById('textdialog').style.display="none";
                document.getElementById('tagsdiv').style.display='none';
                //document.getElementById('tmpcat').style.display="none";
                document.getElementById('picdialog').style.display='Block';
                document.getElementById('myhdnval').value=obj.id;
                document.getElementById('opendialog1').style.display='none';
                document.getElementById('opendialog').style.display='none';
                document.getElementById('rotatediv').style.display='none';
                document.getElementById('openaddialog').style.display="none";
                document.getElementById('newdialog').style.display='none';
                 document.getElementById('spltg').style.display='none';
                 //document.getElementById('toolsbox_bgcolor').disabled="disabled";
                //document.getElementById('popups').style.display='none';
                //document.getElementById('openTemplate1').style.display='none';
                // alert("4");
                return false;
         }
     else if(splitevalu[1]=="line")
       {        
                fonttoolbardisabled();
                document.getElementById('textdialog').style.display="none";
                document.getElementById('picdialog').style.display='none';
                document.getElementById('tagsdiv').style.display='none';
                //document.getElementById('tmpcat').style.display="none";
                document.getElementById('linedialog').style.display='Block';
                document.getElementById('toolsbox_fcolor').disabled=true;
                //document.getElementById('sampleclrbckL').disabled=true;
                document.getElementById('myhdnval').value=""
                document.getElementById('myhdnval').value=obj.id;
                //document.getElementById('editordiv').disabled=true;
                document.getElementById('opendialog1').style.display='none';
                document.getElementById('opendialog').style.display='none';
                document.getElementById('rotatediv').style.display='none';
                document.getElementById('openaddialog').style.display="none";
                document.getElementById('newdialog').style.display='none';
                 document.getElementById('spltg').style.display='none';
                //getdimsP();
                return false;
        }
        
        else if(splitevalu[1]!="tag")
        {
            // alert(obj.id);
            fonttoolbarenabled();
            document.getElementById('myhdnval').value=""
            document.getElementById('myhdnval').value=obj.id;
            //document.getElementById('editordiv').disabled=true;
            document.getElementById('opendialog1').style.display='none';
            document.getElementById('opendialog').style.display='none';
            document.getElementById('rotatediv').style.display='none';
            document.getElementById('newdialog').style.display='none';
             document.getElementById('spltg').style.display='none';
             document.getElementById('opendialog').style.display='none';
             document.getElementById('newdialog').style.display='none';
             return false
        }
        
    }
        currentid=obj.id;document.getElementById('myhdnval').value=currentid;
       // alert(document.getElementById('myhdnval').value);
  }
  else
  {
  // alert("getid");
  if(obj.id=="outer")
        {
            document.getElementById('linedialog').style.display="none";
            document.getElementById('textdialog').style.display="none";
            //document.getElementById('colorcodeT_F').disabled=true;
            document.getElementById('picdialog').style.display='none';
            document.getElementById('tagsdiv').style.display='none';
            document.getElementById('toolsbox_fcolor').disabled=true;
            document.getElementById('spltg').style.display='none';
            document.getElementById('spltg').style.visibility;
            document.getElementById('opendialog1').style.display='none';
            document.getElementById('opendialog').style.display='none';
            document.getElementById('rotatediv').style.display='none';
            document.getElementById('openaddialog').style.display="none";
            document.getElementById('newdialog').style.display='none';
             document.getElementById('spltg').style.display='none';
             document.getElementById('toolsbox_fcolor').disabled="disabled";
            getdimsT();
            editmode(obj);
         }
     else
       {
           // alert("2");
           var splitevalu=obj.id.split("~")
          // alert("3");
          // alert(splitevalu[1]);
           if(splitevalu[1]=="text")
            {
                   fonttoolbarenabled();
                   document.getElementById('linedialog').style.display='none';
                   document.getElementById('picdialog').style.display='none';
                   //document.getElementById('tmpcat').style.display="none";
                   document.getElementById('tagsdiv').style.display='none';
                   document.getElementById('textdialog').style.display='Block';
                   document.getElementById('myhdnval').value=obj.id;
                   document.getElementById('opendialog1').style.display='none';
                   document.getElementById('opendialog').style.display='none';
                   document.getElementById('rotatediv').style.display='none';
                   document.getElementById('openaddialog').style.display="none";
                   document.getElementById('newdialog').style.display='none';
                    document.getElementById('spltg').style.display='none';
                    document.getElementById('toolsbox_fcolor').disabled=false;
                    //document.getElementById('toolsbox_fcolor').disabled="disabled";
                    //document.getElementById('toolsbox_bgcolor').disabled="disabled";
                    //alert("text");
                   getdimsT();
                   editmode(obj);
                   
                   //alert("text1");
                   //document.getElementById('popups').style.display='none';
                   //document.getElementById('openTemplate1_xmllist1').style.display='none';
                  //   document.getElementById('openaddialog').style.display='none';
                   //return false;
           }
        else if(splitevalu[1]=="picture")
         {
                fonttoolbardisabled();
                document.getElementById('linedialog').style.display='none';
                document.getElementById('textdialog').style.display="none";
                document.getElementById('tagsdiv').style.display='none';
                //document.getElementById('tmpcat').style.display="none";
                document.getElementById('picdialog').style.display='Block';
                document.getElementById('myhdnval').value=obj.id;
                document.getElementById('opendialog1').style.display='none';
                document.getElementById('opendialog').style.display='none';
                document.getElementById('rotatediv').style.display='none';
                document.getElementById('openaddialog').style.display="none";
                document.getElementById('newdialog').style.display='none';
                 document.getElementById('spltg').style.display='none';
                 //document.getElementById('toolsbox_bgcolor').disabled="disabled";
                 document.getElementById('toolsbox_fcolor').disabled="disabled";
                getdimsP();
                editmode(obj);
                //editmode2(obj);
                //document.getElementById('popups').style.display='none';
                //document.getElementById('openTemplate1').style.display='none';
                //alert("4");
                //return false;
         }
     else if(splitevalu[1]=="line")
       {        
                fonttoolbardisabled();
                document.getElementById('textdialog').style.display="none";
                document.getElementById('picdialog').style.display='none';
                document.getElementById('tagsdiv').style.display='none';
                //document.getElementById('tmpcat').style.display="none";
                document.getElementById('linedialog').style.display='Block';
                document.getElementById('toolsbox_fcolor').disabled=true;
                document.getElementById('newdialog').style.display='none';
                //document.getElementById('sampleclrbckL').disabled=true;
                document.getElementById('myhdnval').value=""
                document.getElementById('myhdnval').value=obj.id;
                //document.getElementById('editordiv').disabled=true;
                document.getElementById('opendialog1').style.display='none';
                document.getElementById('opendialog').style.display='none';
                document.getElementById('rotatediv').style.display='none';
                document.getElementById('openaddialog').style.display="none";
                 document.getElementById('spltg').style.display='none';
                getdimsL();
                editmode(obj);
                //editmode2(obj);
                //return false;
        }
        
       else if(splitevalu[1]!="tag")
        {
            // alert(obj.id);
            fonttoolbarenabled();
            document.getElementById('myhdnval').value=""
            document.getElementById('myhdnval').value=obj.id;
            //document.getElementById('editordiv').disabled=true;
            document.getElementById('opendialog1').style.display='none';
            document.getElementById('opendialog').style.display='none';
            document.getElementById('rotatediv').style.display='none';
            document.getElementById('newdialog').style.display='none';
             document.getElementById('spltg').style.display='none';
             document.getElementById('tagsdiv').style.display='block';
             //document.getElementById('opendialog').style.display='none';
             //document.getElementById('newdialog').style.display='none';
             return false
        }
        
    }
        currentid=obj.id;document.getElementById('myhdnval').value=currentid;
        //alert(document.getElementById('myhdnval').value);
 
  
  }      
 }

/******************end of function *********/

function roll_over(img_name, img_src)
 { 
 //alert('8')
 if(document.all)
 {
  document[img_name].src = img_src;
 }
 else
 {
 if(enable==1)
 {
 document[img_name].src = img_src;
 }
 }
 
 }
 
/***************************************************/ 
 
function alignText()
  {
    if(document.getElementById('myhdnval').value!=null)
      {
        //mytext=document.getElementById('fonttoolbar_alignment').value;
        mytext=document.getElementById('textboxprop_alignment').value;
        document.getElementById(document.getElementById('myhdnval').value).align=mytext;
        document.getElementById('fonttoolbar_alignment').value=mytext;
        return false;
      }
    else
     {
       alert('Please select item !');
      }
  }

function alignText1(){
    if(document.getElementById('myhdnval').value!=null){
        mytext=document.getElementById('fonttoolbar_alignment').value;
        //mytext=document.getElementById('textboxprop_alignment').value;
        if(mytext!="justify")
        {
            document.getElementById(document.getElementById('myhdnval').value).align=mytext;
            document.getElementById('textboxprop_alignment').value = mytext;
        }
        else
        {
            document.getElementById(document.getElementById('myhdnval').value).align="left";
            document.getElementById('textboxprop_alignment').value = mytext;
        }
       return false;
        }
    else{alert('Please select item !');}
}

function spacing()
  {
   if(document.all)
    {
         abc();
        var val = document.getElementById('txtlinespacing').value;
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight = val;
        return false;
    }
    else
      {
        var value = document.getElementById('txtlinespacing').value;
        if(parseInt(value)==0)
        {   
            alert("This value not allowed Line Spacing");
            document.getElementById('txtlinespacing').value=1;
            return false
        }
        
        var fsize=document.getElementById(document.getElementById('myhdnval').value).style.fontSize;
      var val= parseInt(value)*parseInt(fsize);
        if(unit==1)
        {
        
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight = val+"px";
        document.getElementById('txtlinespacing').value=value;
        }
        if(unit==2)
        {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight = val+"px";
        document.getElementById('txtlinespacing').value=value;
        }
        if(unit==3)
        {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight = val+"px";
        document.getElementById('txtlinespacing').value=value;
        }
        if(unit==4)
        {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight = val+"px";
        document.getElementById('txtlinespacing').value=value;
        }
      }
 }
/**********************this is code for FontName*****************/
function fontName()
 {
 //alert('kumar');
    if(document.getElementById('myhdnval').value!=null)
    {
        //myfnt=document.getElementById('fonttoolbar_fntname').value;
        myfnt=document.getElementById('textboxprop_fntname').value;
        document.getElementById(document.getElementById('myhdnval').value).style.fontFamily=myfnt;
        document.getElementById('fonttoolbar_fntname').value=myfnt;
        return false;
    }
   else
    { 
     alert('no item selected');
    }
}



function fontName1()
{
 
 try
  {
//  if(document.getElementById('myhdnval').value!=null)
if(document.getElementById('myhdnval').value!=null)
        {
            //myfnt=document.getElementById('fonttoolbar_fntname').value;
            myfnt=document.getElementById('fonttoolbar_fntname').value;
            document.getElementById(document.getElementById('myhdnval').value).style.fontFamily=myfnt;
            document.getElementById('textboxprop_fntname').value;
            return false;
        }
       else
        {
          alert('no item selected');
         }
   }
    catch(er){}
}



/*************font size****************/

function fontsize()
{
 //alert('abc');
 if(document.all)
 {
   if(document.getElementById('myhdnval').value!=null)
    {
    mysize=document.getElementById('textboxprop_fntsize').value;
    document.getElementById(document.getElementById('myhdnval').value).style.fontSize=mysize;
    if(mysize>8 && mysize<18)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=20+"px";
        up();
    }
    if(mysize>18 && mysize<30)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=30+"px";
        up();
    }
    if(mysize>29 && mysize<60)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=60+"px";
          up();
    } 
    if(mysize>59)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=72+"px";
          up();
    }
     document.getElementById('textboxprop_fntsize').value = mysize;
     return false;
    }
  else
   {
    alert('no item selected');
   }
 }
//}
  else
    {
     if(document.getElementById('myhdnval').value!=null)
         {
  
    mysize=document.getElementById('textboxprop_fntsize').value;
   
    document.getElementById(document.getElementById('myhdnval').value).style.fontSize=mysize+"px";
    //alert(currentid)
   // alert(document.getElementById(currentid).style.lineHeight)
   if(mysize>8 && mysize<18)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=20+"px";
        spacing();
        up();
    }
    if(mysize>18 && mysize<30)
    {
      document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=30+"px";
      spacing();
      up();
    }
    if(mysize>29 && mysize<60)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=60+"px";
        spacing();
        up();
    } 
    if(mysize>59)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=72+"px";
        spacing();
        up();
    }
      document.getElementById('textboxprop_fntsize').value = mysize;
      spacing();
      return false;
    }
    else
    {
     alert('no item selected');
    }
   }
}
/*************end font size*************/



/*************8font size1*********************/
function fontsize1()
{
 //alert('ankur');
 if(document.all)
 {
   if(document.getElementById('myhdnval').value!=null)
    {
    //if(document.getElementById('fonttoolbar_fntsize1').type=="text")
    
    //mysize=document.getElementById('fonttoolbar_fntsize1').value;
    
    //else
    //{
    mysize=document.getElementById('fonttoolbar_fntsize').value;
    //}
    if(mysize!="more")
    {
    document.getElementById(document.getElementById('myhdnval').value).style.fontSize=mysize;
    if(mysize>8 && mysize<18)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=20+"px";
        up();
    }
    if(mysize>18 && mysize<30)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=30+"px";
        
        abc();
        up();
    }
    if(mysize>29 && mysize<60)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=60+"px";
        abc();
          up();
    } 
    if(mysize>59)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=72+"px";
//        alert(document.getElementById(document.getElementById('myhdnval').value).style.height);
//        if(document.getElementById(document.getElementById('myhdnval').value).style.height<document.getElementById(document.getElementById('myhdnval').value).style.lineHeight)
//        {
//        document.getElementById(document.getElementById('myhdnval').value).style.height=parseInt(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.lineHeight)+10)+"px";
//        }
//        alert(document.getElementById(document.getElementById('myhdnval').value).style.height);
        abc();
          up();
    }
     document.getElementById('textboxprop_fntsize').value = mysize;
     return false;
     }
     else
     {
     document.getElementById('fonttoolbar_fontsizef').style.display="none";
     document.getElementById('fonttoolbar_fontsizef').value="";
     document.getElementById('fonttoolbar_fontsizef1').style.display="block";
       
     }
    }
  else
   {
    alert('no item selected');
   }
 }
//}
else
{
//alert('ankur');
  if(document.getElementById('myhdnval').value!=null)
    {
   
         mysize=document.getElementById('fonttoolbar_fntsize').value;
 
     if(mysize!="more")
        {
            document.getElementById(document.getElementById('myhdnval').value).style.fontSize=mysize+"px";
            if(mysize>8 && mysize<18)
            {
                document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=20+"px";
                spacing();
                up();
            }
            if(mysize>18 && mysize<30)
             {
            
                document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=30+"px";
                spacing();
                up();
              }
            if(mysize>29 && mysize<60)
            {
                document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=60+"px";
                spacing();
                up();
            } 
            if(mysize>59)
            {
                document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=72+"px";
                spacing();               // alert(document.getElementById(document.getElementById('myhdnval').value).style.height);
//        if(document.getElementById(document.getElementById('myhdnval').value).style.height<document.getElementById(document.getElementById('myhdnval').value).style.lineHeight)
//        {
//        document.getElementById(document.getElementById('myhdnval').value).style.height=parseInt(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.lineHeight)+10)+"px";
//        }
       // alert(document.getElementById(document.getElementById('myhdnval').value).style.height);
                up();
            }
          document.getElementById('textboxprop_fntsize').value = mysize;
           spacing();
          return false;
         }
    
    else
    {
    document.getElementById('fonttoolbar_fontsizef').style.display="none";
    spacing();
     document.getElementById('fonttoolbar_fontsizef1').style.display="block";
       
    }
    }
    else
    {
     alert('no item selected');
    }
   }
}




function fontsizef1(ev)
{
//alert(ev.keyCode);
if(document.all)
 {
 
   if(document.getElementById('myhdnval').value!=null)
    {
       mysize=document.getElementById('fonttoolbar_fntsize1').value;
    
    
    document.getElementById(document.getElementById('myhdnval').value).style.fontSize=mysize;
    if(mysize>8 && mysize<18)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=20+"px";
        up();
    }
    if(mysize>18 && mysize<30)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=30+"px";
        abc();
        up();
    }
    if(mysize>29 && mysize<60)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=50+"px";
        abc();
          up();
    } 
    if(mysize>59)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=70+"px";
        abc();
          up();
    }
     document.getElementById('textboxprop_fntsize').value = mysize;
     document.getElementById('fonttoolbar_fntsize').value = mysize;
     
     document.getElementById('fonttoolbar_fontsizef').style.display="block";
     document.getElementById('fonttoolbar_fontsizef1').style.display="none";
     return false;
     }
     
    
  else
   {
    alert('no item selected');
   }
   
 }
//}
else
{

  if(document.getElementById('myhdnval').value!=null)
    {
   
    mysize=document.getElementById('fonttoolbar_fntsize1').value;
   // alert(mysize);
    
    document.getElementById(document.getElementById('myhdnval').value).style.fontSize=mysize+"px";
    //alert(document.getElementById('editordiv').childNodes[0].innerHTML);
     document.getElementById('textboxprop_fntsize').value = mysize;
      document.getElementById('fonttoolbar_fntsize').value = mysize;
      if(mysize>8 && mysize<18)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=20+"px";
        spacing();
        up();
    }
    if(mysize>18 && mysize<30)
     {
    
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=30+"px";
        spacing();
        up();
      }
    if(mysize>29 && mysize<60)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=50+"px";
        spacing();
        up();
    } 
    if(mysize>59)
    {
        document.getElementById(document.getElementById('myhdnval').value).style.lineHeight=70+"px";
        spacing();
        up();
    }
    //  document.getElementById('textboxprop_fntsize').value = mysize.replace("px","");
      //document.getElementById('fonttoolbar_fntsize').value = mysize.replace("px","");
      //alert(document.getElementById('textboxprop_fntsize').value);
      //alert(document.getElementById('fonttoolbar_fntsize').value);
      document.getElementById('fonttoolbar_fontsizef').style.display="block";
     document.getElementById('fonttoolbar_fontsizef1').style.display="none";
     spacing();
      return false;
    }
    else
    {
     alert('no item selected');
    }
  
 
   document.getElementById('fonttoolbar_fontsizef').style.display="block";
     document.getElementById('fonttoolbar_fontsizef1').style.display="none";
}

}


/******************To get fonts name******************/
    var Fonts = new Array();
    Fonts[0] = "Arial";
    Fonts[1] = "Sans Serif";
    Fonts[2] = "Tahoma";
	Fonts[3] = "Verdana";
	Fonts[4] = "Courier New";
	Fonts[5] = "Georgia";
	Fonts[6] = "Times New Roman";
	Fonts[7] = "Impact";
    Fonts[8] = "Comic Sans MS";
    Fonts[9] = "Arial Black";
    Fonts[10] = "Arial Narrow";
    Fonts[11] = "Book Antiqua";
    Fonts[12] = "Courier";
    Fonts[13] = "Latha";
    Fonts[14] = "Lucida Console";
    Fonts[15] = "Bookman Old Style";


function getFonts()
{
if(document.all)
{
   var nFontLen = dlgHelper.fonts.count;
   var rgFonts = new Array();

   for ( var i = 1; i < nFontLen + 1; i++ )
   {
      rgFonts[i] = dlgHelper.fonts(i);
   }
   rgFonts.sort();
   //alert(document.getElementById('fonttoolbar_fntname'))
   var objfont=document.getElementById('fonttoolbar_fntname');
   var obj2font=document.getElementById('textboxprop_fntname');
   //objfont.options.length=0;
   for ( var j = 0; j < nFontLen; j++ )
   {
      objfont.options[j] = new Option(rgFonts[j],rgFonts[j]);
      obj2font.options[j] = new Option(rgFonts[j],rgFonts[j]);
   }
}
 else
   {
       Fonts.sort();
       var objfont=document.getElementById('fonttoolbar_fntname');
       var obj2font=document.getElementById('textboxprop_fntname');
       //objfont.options.length=0;
       
       for ( var j = 0; j < 16; j++ )
       {
          objfont.options[j] = new Option(Fonts[j],Fonts[j]);
          obj2font.options[j] = new Option(Fonts[j],Fonts[j]);
       }

   }
}     



/*************************************/     
function enable_resize(){   
//alert("resize");
    if(document.all)
    {
        try{
            document.getElementById(document.getElementById('myhdnval').value).className='nodrag';
            }
            catch(er){}      
      }
    else
    {
    //alert(document.getElementById(document.getElementById('myhdnval').value).id);
    new Draggable(document.getElementById(document.getElementById('myhdnval').value).id);
    }


}

/******************************************/
function enable_drag()
{
//alert("drag");
       if(document.all)
       {
        try
         {
           document.getElementById(document.getElementById('myhdnval').value).className='drag';
         }
         
       catch(er){}
       }
       else
       {
       new Dropable(document.getElementById(document.getElementById('myhdnval').value).id);
        }
       
}
  
/**********************************************/  
       
       

function Draggable(el2)
{
//                                                                                                       v     alert(el2);
  var xDelta = 0, yDelta = 0;
  var xStart = 0, yStart = 0;

  // remove the events
  function enddrag()
  {
    document.onmouseup =null;
    document.onmousemove = null;
    if(unit==2)
    {
        document.getElementById(el2).style.width = conversion(document.getElementById(el2).style.width,unit)+"in";
        document.getElementById(el2).style.height = conversion(document.getElementById(el2).style.height,unit)+"in"; 
    }
    if(unit==3)
    {
        document.getElementById(el2).style.width = conversion(document.getElementById(el2).style.width,unit)+"cm";
        document.getElementById(el2).style.height = conversion(document.getElementById(el2).style.height,unit)+"cm"; 
    }
    if(unit==4)
    {
        document.getElementById(el2).style.width = conversion(document.getElementById(el2).style.width,unit)+"mm";
        document.getElementById(el2).style.height = conversion(document.getElementById(el2).style.height,unit)+"mm"; 
    }   
    el2="";
    return false;
    //document.getElementById('outer').focus();
  }

  // fire each time it's dragged
  function drag1(e)
  {

    e = e || window.event;
    xDelta = xStart - parseInt(e.clientX);
    yDelta = yStart - parseInt(e.clientY);
    xStart = parseInt(e.clientX);
    yStart = parseInt(e.clientY);
   
   document.getElementById(el2).style.height = (parseInt(document.getElementById(el2).style.height) - yDelta) + 'px';
    document.getElementById(el2).style.width = (parseInt(document.getElementById(el2).style.width) - xDelta) + 'px';
    
    
    var el2new=el2.split('~')[1];
     if(el2new=="picture")
    {
    document.getElementById(el2+"pic").style.height=document.getElementById(el2).style.height;
    document.getElementById(el2+"pic").style.width=document.getElementById(el2).style.width;
    //alert(document.getElementById(el2).innerHTML);
    
    }
//    var splitevalue=document.getElementById(el2).id.split("~")
//    if(splitevalue[1]=="text")
//    getdimsT();
//    else if(splitevalue[1]=="picture")
//    getdimsP();
//    else if(splitevalue[1]=="line")
//    getdimsL();
//    
    
    
  }
   function drag2(e)
  {
  
    e = e || window.event;
    xDelta = xStart - parseInt(e.clientX);
    yDelta = yStart-parseInt(e.clientY);
    xStart = parseInt(e.clientX);
    yStart = parseInt(e.clientY);
   document.getElementById(el2).style.top=(yStart-170)+"px";
   //alert(document.getElementById(el2).style.top);
   //document.getElementById(el2).style.left=yStart-170;
   document.getElementById(el2).style.height = (parseInt(document.getElementById(el2).style.height) + yDelta) + 'px';
    document.getElementById(el2).style.width = (parseInt(document.getElementById(el2).style.width) - xDelta) + 'px';
     var el2new=el2.split('~')[1];
     if(el2new=="picture")
    {
    document.getElementById(el2+"pic").style.height=document.getElementById(el2).style.height;
    document.getElementById(el2+"pic").style.width=document.getElementById(el2).style.width;
    //alert(document.getElementById(el2).innerHTML);
    
    }
//    var splitevalue=document.getElementById(el2).id.split("~")
//    if(splitevalue[1]=="text")
//    getdimsT();
//    else if(splitevalue[1]=="picture")
//    getdimsP();
//    else if(splitevalue[1]=="line")
//    getdimsL();
//    
    
    
  }

  // initiate the drag
  function md(e)
  {
    //alert("in md")
    e = e || window.event;
    xStart = parseInt(e.clientX);
    
    yStart = parseInt(e.clientY);
//    if(unit==1)
//    {
    document.getElementById(el2).style.height = parseInt(document.getElementById(el2).style.height) + 'px';
   document.getElementById(el2).style.width = parseInt(document.getElementById(el2).style.width) + 'px';
//   }
//   if(unit==2)
//    {
//    document.getElementById(el2).style.height = parseInt(document.getElementById(el2).style.height) + 'in';
//   document.getElementById(el2).style.width = parseInt(document.getElementById(el2).style.width) + 'in';
//   }
//   if(unit==3)
//    {
//    document.getElementById(el2).style.height = parseInt(document.getElementById(el2).style.height) + 'cm';
//   document.getElementById(el2).style.width = parseInt(document.getElementById(el2).style.width) + 'cm';
//   }
//   if(unit==4)
//    {
//    document.getElementById(el2).style.height = parseInt(document.getElementById(el2).style.height) + 'mm';
//   document.getElementById(el2).style.width = parseInt(document.getElementById(el2).style.width) + 'mm';
//   }
//   alert(document.getElementById(el2).offsetLeft);
//   alert(document.getElementById(el2).offsetTop);
//   alert(document.getElementById(el2).offsetHeight);
//   alert(document.getElementById(el2).offsetWidth);
   var x12=(document.getElementById(el2).offsetLeft+document.getElementById(el2).offsetWidth)/2;
   var y12=(parseInt(document.getElementById(el2).offsetTop))+((parseInt(document.getElementById(el2).offsetHeight))/2);
   
   
//   var ycheck=yStart-170;     
//   if(ycheck>y12)
//   {
   document.onmousemove = drag1;
    document.onmouseup = enddrag;
//    }
////    else
//    {
//  
//    document.onmousemove = drag2;
//    document.onmouseup = enddrag;
//    }
    
  }

  // tie it into the element
  
   
   //alert(document.getElementById(el2).style.height)
   //alert(document.getElementById(el2).style.width)
 document.getElementById(el2).onmousedown = md;
if((document.getElementById(el2).style.width).indexOf("px")<0)
{
if(unit==2)
{
 document.getElementById(el2).style.width = r_conversion(document.getElementById(el2).style.width.replace("in",""),unit)+"px"; 
}
if(unit==3)
{
 document.getElementById(el2).style.width = r_conversion(document.getElementById(el2).style.width.replace("cm",""),unit)+"px"; 
}
if(unit==4)
{
 document.getElementById(el2).style.width = r_conversion(document.getElementById(el2).style.width.replace("mm",""),unit)+"px"; 
}  
  
 // alert(document.getElementById(el2).style.width);
}
if((document.getElementById(el2).style.height).indexOf("px")<0)
{
if(unit==2)
{
    document.getElementById(el2).style.height = r_conversion(document.getElementById(el2).style.height.replace("in",""),unit)+"px"; 
}
if(unit==3)
{
    document.getElementById(el2).style.height = r_conversion(document.getElementById(el2).style.height.replace("cm",""),unit)+"px"; 
}
if(unit==4)
{
    document.getElementById(el2).style.height = r_conversion(document.getElementById(el2).style.height.replace("mm",""),unit)+"px"; 
}   
//alert(document.getElementById(el2).style.height)

}
}
/******************************************************************************/


function Dropable(el2)
{

var xDelta = 0, yDelta = 0;
  var xStart = 0, yStart = 0;

  // remove the events
  function enddrag()
  {
    document.onmouseup =null;
    document.onmousemove = null;
   el2="";
    return false;
    //document.getElementById('outer').focus();
  }

  // fire each time it's dragged
  function drag1(e)
  {
 // alert("hello");
    e = e || window.event;
    xDelta = xStart - parseInt(e.clientX);
    yDelta = yStart - parseInt(e.clientY);
    xStart = parseInt(e.clientX);
    yStart = parseInt(e.clientY);
   document.getElementById(el2).style.top = (parseInt(document.getElementById(el2).style.top) - yDelta) + 'px';
    document.getElementById(el2).style.left = (parseInt(document.getElementById(el2).style.left) - xDelta) + 'px';
    up();
//    var splitevalue=document.getElementById(el2).id.split("~")
//    if(splitevalue[1]=="text")
//    getdimsT();
//    else if(splitevalue[1]=="picture")
//    getdimsP();
//    else if(splitevalue[1]=="line")
//    getdimsL();
//    
    
    
  }

  // initiate the drag
  function md(e)
  {
    //alert("in md")
    e = e || window.event;
    xStart = parseInt(e.clientX);
    yStart = parseInt(e.clientY);
    document.getElementById(el2).style.top = parseInt(document.getElementById(el2).style.top) + 'px';
   document.getElementById(el2).style.left = parseInt(document.getElementById(el2).style.left) + 'px';
   document.onmousemove = drag1;
    document.onmouseup = enddrag;
    
  }

  // tie it into the element
 document.getElementById(el2).onmousedown = md;




}



/*******************************************************************/
function bullet()
  {
  if(document.all)
  {
        try{
        //document.execCommand("InsertUnorderedList");
          if(document.getElementById('myhdnval').value !='img1'|| document.getElementById('myhdnval').value==null)
        {
            alert('Select TextBox to apply.');
            //document.getElementById('editordiv').focus();
        }
         else
        {
            document.execCommand("InsertUnorderedList");
            document.getElementById(document.getElementById('myhdnval').value).focus();
        }
        }catch(er){}
        }
    else
    {
         if(document.getElementById('myhdnval').value == 'img1'|| document.getElementById('myhdnval').value==null)
        {
            alert('Select TextBox to apply.');
            //document.getElementById('editordiv').focus();
        }
        else
        {
            //alert("bullet");
            document.execCommand("insertUnorderedList",false,null);
            document.getElementById(document.getElementById('myhdnval').value).focus();
        }
    }
 }

function numbers()
 {
  if(document.all)
   {
      try
      {
    
      if(document.getElementById('myhdnval').value !='img1' || document.getElementById('myhdnval').value==null)
        {
           alert('Select TextBox to apply !');
        }
    else
        {
            document.execCommand("InsertOrderedList");
            document.getElementById(document.getElementById('myhdnval').value).focus();
        }
    }catch(er){}
}

else
  {
    if(document.getElementById('myhdnval').value == 'img1'|| document.getElementById('myhdnval').value==null)
        {
           alert('Select TextBox to apply !');
        }
      else
        {
            //alert("numbers");
            document.execCommand("insertOrderedList",false,null);
            document.getElementById(document.getElementById('myhdnval').value).focus();
        }
   }
 }
/**************************************/
function edittemplate()
{
    openlayout();
    flagsaveedit=1;
    document.getElementById('saveedittemplate').onclick=null;
    document.getElementById('saveedittemplate').style.cursor="pointer";
    document.getElementById('savesT').onclick=ignoreClick;
    document.getElementById('savesT').style.cursor="text";
    

}

/***********************************************/
function saveedittemplate()
{
    var browser=navigator.appName;
 if(browser=="Microsoft Internet Explorer")
 {
     //alert('saveaddialog');
    if(saveme1 && !saveme1.closed){saveme1.focus();}
    else
       {
          var h = document.getElementById('editordiv');
          var ht1 = h.innerHTML;
          if(ht1=="")
            {
              alert('Nothing to be save!!');
             }
            else
            {
             if(CheckTemplate("save")=="true")
              {
              //CheckAd();
              var limit=ht1.split("</DIV>");
              document.getElementById('editordivfullhtml').value=h.innerHTML;
  
            /*******************************************************/
            for(var b=1; b<= limit.length; b++)
            {
                ht1 = ht1.replace("class=drag", "");
                ht1 = ht1.replace("onactivate=javascript:getid(this);","");
                ht1 = ht1.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsT();","");
                ht1 = ht1.replace("onresize=javascript:getdimsT();","");
                ht1 = ht1.replace("onmove=javascript:moves();","");
                ht1 = ht1.replace("onkeypress=","");
                ht1 = ht1.replace("javascript:blockkey(event,\'bcd\');","");
                ht1 = ht1.replace("onactivate=javascript:editmode(this);","");
                ht1 = ht1.replace("ondeactivate=javascript:dragmode(this);","");
                ht1 = ht1.replace("onfocus=javascript:getid(this);","");
                ht1 = ht1.replace("onclick=javascript:getid(this);","");
                ht1 = ht1.replace("onresize=javascript:getdimsP();","");
                ht1 = ht1.replace("contentEditable=true","");
                ht1 = ht1.replace("oncontextmenu=javascript:context_menu(this);   oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);","");
                ht1 = ht1.replace("oncontextmenu=javascript:context_menu(this);   javascript:showprop(this); \"\" ","");
            }
            document.getElementById('editordivhtml').value=ht1;
            for(var temp=0;temp<limit.length-2;temp++)
            {
             if(limit[temp]!="")
             {
                var id1 = limit[temp].split("id=");
                var id2 = id1[1].split(" ");/*****ERROR*********/
              }
            var adhght = document.getElementById('ad_height').value;
            var adwdth = document.getElementById('ad_width').value;
            document.getElementById('adheight').value = adhght;
            document.getElementById('adwidth').value = adwdth;
                //var tempxml = tempxml + "<textboxa>a<rdrirmuennsion>ajay<height>" + document.getElementById(temp).style.height + "</height><width>" + document.getElementById(temp).style.width + "</width><xpos>" + document.getElementById(temp).style.left + "</xpos><ypos>" + document.getElementById(temp).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(temp).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(temp).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(temp).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(temp).innerHTML +"</text><bgcolor>" + document.getElementById(temp).backgroundColor + "</bgcolor></textbox>" ;
               // var tempxml = tempxml + "<textbox><dimension><height>" + document.getElementById(id2[0]).style.height + "</height><width>" + document.getElementById(id2[0]).style.width + "</width><xpos>" + document.getElementById(id2[0]).style.left + "</xpos><ypos>" + document.getElementById(id2[0]).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(id2[0]).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(id2[0]).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(id2[0]).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(id2[0]).innerHTML +"</text><bgcolor>" + document.getElementById(id2[0]).backgroundColor + "</bgcolor><bgimage>" + document.getElementById(id2[0]).style.backgroundImage + "</bgimage></textbox>" ;
                var tempxml = tempxml + "<textbox><dimension><height>" + adhght + "</height><width>" + adwdth + "</width><xpos>" + document.getElementById(id2[0]).style.left + "</xpos><ypos>" + document.getElementById(id2[0]).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(id2[0]).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(id2[0]).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(id2[0]).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(id2[0]).innerHTML +"</text><bgcolor>" + document.getElementById(id2[0]).backgroundColor + "</bgcolor><bgimage>" + document.getElementById(id2[0]).style.backgroundImage + "</bgimage></textbox>" ;
                }
            var xmlfile = "<template>" + tempxml + "</template>" ;
            document.getElementById('editordivxml').value=xmlfile;
            if(document.getElementById('fetchid').value == ""){
            var ajay;
            ajay=document.getElementById('selected_name').value;
            //var ankur;
            ankur=document.getElementById('savehidden').value;
           
            if(document.getElementById('savehidden').value=="")
              {
              _Default.update
                saveme1=window.open('saveme.aspx?ajay='+ajay,'','left=300px,top=250px,height=130px,width=350px,scroll=no,status=off' );     
               }
              else
               {
                  alert('This File Already Saved')
                  return;
               }
                //window.close();
                //document.getElementById('saveT').focus();
                //return false;
                }
                else
                {
                    var xhtml = document.getElementById('editordiv').innerHTML;
                    var id=document.getElementById('temp_id').value;
                    _Default.update(id,tempxml,xhtml,ht1);
                    alert('Template modified successfully !!');
                    currentid=null;
                    //return false;
                 }     
            } }  
     }
}
else if(browser!="Microsoft Internet Explorer")
  {
  //alert("hello");
  if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
        {

  
    if(saveme1 && !saveme1.closed){saveme1.focus();}
    else
       {
      
          var h = document.getElementById('editordiv');
          var ht1 = h.innerHTML;
          if(ht1=="")
            {
              alert('Nothing to be save!!');
             }
            else
            {
            
              //CheckAd();
               if(CheckTemplate("save")=="true")
              {
              var limit=ht1.split("</div>");
              //alert(limit.length);
              
              document.getElementById('editordivfullhtml').value=h.innerHTML;
  
            /*******************************************************/
            for(var b=1; b<= limit.length; b++)
            {
                ht1 = ht1.replace("class=drag", "");
                ht1 = ht1.replace("onactivate=javascript:getid(this);","");
                ht1 = ht1.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsT();","");
                ht1 = ht1.replace("onresize=javascript:getdimsT();","");
                ht1 = ht1.replace("onmove=javascript:moves();","");
                ht1 = ht1.replace("onkeypress=","");
                ht1 = ht1.replace("javascript:blockkey(event,\'bcd\');","");
                ht1 = ht1.replace("onactivate=javascript:editmode(this);","");
                ht1 = ht1.replace("ondeactivate=javascript:dragmode(this);","");
                ht1 = ht1.replace("onfocus=javascript:getid(this);","");
                ht1 = ht1.replace("onclick=javascript:getid(this);","");
                ht1 = ht1.replace("onresize=javascript:getdimsP();","");
                ht1 = ht1.replace("contentEditable=true","");
                ht1 = ht1.replace("oncontextmenu=javascript:context_menu(this);   oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);","");
                ht1 = ht1.replace("oncontextmenu=javascript:context_menu(this);   javascript:showprop(this); \"\" ","");
            }
            document.getElementById('editordivhtml').value=ht1;
            //alert(ht1);
            for(var temp=0;temp<limit.length-2;temp++)
            {
             if(limit[temp]!="")
             {
                var id1 = limit[temp].split("id=");
                var id2 = id1[1].split(" ");/*****ERROR*********/
              }
            var adhght = document.getElementById('ad_height').value;
            var adwdth = document.getElementById('ad_width').value;
            document.getElementById('adheight').value = adhght;
            document.getElementById('adwidth').value = adwdth;
            
            var nh=id2[0];;
                while(nh.indexOf('"')>=0)
                {
                   nh=nh.replace('"',"")
                }
                id2[0]=nh;
                //var tempxml = tempxml + "<textboxa>a<rdrirmuennsion>ajay<height>" + document.getElementById(temp).style.height + "</height><width>" + document.getElementById(temp).style.width + "</width><xpos>" + document.getElementById(temp).style.left + "</xpos><ypos>" + document.getElementById(temp).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(temp).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(temp).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(temp).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(temp).innerHTML +"</text><bgcolor>" + document.getElementById(temp).backgroundColor + "</bgcolor></textbox>" ;
               // var tempxml = tempxml + "<textbox><dimension><height>" + document.getElementById(id2[0]).style.height + "</height><width>" + document.getElementById(id2[0]).style.width + "</width><xpos>" + document.getElementById(id2[0]).style.left + "</xpos><ypos>" + document.getElementById(id2[0]).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(id2[0]).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(id2[0]).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(id2[0]).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(id2[0]).innerHTML +"</text><bgcolor>" + document.getElementById(id2[0]).backgroundColor + "</bgcolor><bgimage>" + document.getElementById(id2[0]).style.backgroundImage + "</bgimage></textbox>" ;
              // alert(id2[0]);
                var tempxml = tempxml + "<textbox><dimension><height>" + adhght + "</height><width>" + adwdth + "</width><xpos>" + document.getElementById(id2[0]).style.left + "</xpos><ypos>" + document.getElementById(id2[0]).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(id2[0]).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(id2[0]).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(id2[0]).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(id2[0]).innerHTML +"</text><bgcolor>" + document.getElementById(id2[0]).backgroundColor + "</bgcolor><bgimage>" + document.getElementById(id2[0]).style.backgroundImage + "</bgimage></textbox>" ;
                
                }
                //alert(tempxml);
            var xmlfile = "<template>" + tempxml + "</template>" ;
            document.getElementById('editordivxml').value=xmlfile;
            
            if(document.getElementById('fetchid').value == "")
            {
            var ajay;
            ajay=document.getElementById('selected_name').value;
            //var ankur;
            ankur=document.getElementById('savehidden').value;
            
            if(document.getElementById('savehidden').value=="")
              {
              _Default.update
              saveme1=window.open('saveme.aspx?ajay='+ajay,'','left=300px,top=250px,height=130px,width=350px,scroll=no,status=off' );     
               }
              else
               {
                  alert('This File Already Saved')
                  return;
               }
                //window.close();
                //document.getElementById('saveT').focus();
                //return false;
                }
                else
                {
                    var xhtml = document.getElementById('editordiv').innerHTML;
                    var id=document.getElementById('temp_id').value;
                    _Default.update(id,tempxml,xhtml,ht1);
                    alert('Template modified successfully !!');
                    currentid=null;
                    //return false;
                 }     
            }  } 
       }

    }
  
   } 





}
/**********************************************/ 
 
 
 
/*****************************************************/
function savedialog()
  {
  var browser=navigator.appName;
 if(browser=="Microsoft Internet Explorer")
 {
     //alert('saveaddialog');
    if(saveme1 && !saveme1.closed){saveme1.focus();}
    else
       {
          var h = document.getElementById('editordiv');
          var ht1 = h.innerHTML;
          if(ht1=="")
            {
              alert('Nothing to be save!!');
             }
            else
            {
              if(CheckTemplate("save")=="true")
              {
              var limit=ht1.split("</DIV>");
              document.getElementById('editordivfullhtml').value=h.innerHTML;
  
            /*******************************************************/
            for(var b=1; b<= limit.length; b++)
            {
                ht1 = ht1.replace("class=drag", "");
                ht1 = ht1.replace("onactivate=javascript:getid(this);","");
                ht1 = ht1.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsT();","");
                ht1 = ht1.replace("onresize=javascript:getdimsT();","");
                ht1 = ht1.replace("onmove=javascript:moves();","");
                ht1 = ht1.replace("onkeypress=","");
                ht1 = ht1.replace("javascript:blockkey(event,\'bcd\');","");
                ht1 = ht1.replace("onactivate=javascript:editmode(this);","");
                ht1 = ht1.replace("ondeactivate=javascript:dragmode(this);","");
                ht1 = ht1.replace("onfocus=javascript:getid(this);","");
                ht1 = ht1.replace("onclick=javascript:getid(this);","");
                ht1 = ht1.replace("onresize=javascript:getdimsP();","");
                ht1 = ht1.replace("contentEditable=true","");
                ht1 = ht1.replace("oncontextmenu=javascript:context_menu(this);   oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);","");
                ht1 = ht1.replace("oncontextmenu=javascript:context_menu(this);   javascript:showprop(this); \"\" ","");
            }
            document.getElementById('editordivhtml').value=ht1;
            for(var temp=0;temp<limit.length-2;temp++)
            {
             if(limit[temp]!="")
             {
                var id1 = limit[temp].split("id=");
                var id2 = id1[1].split(" ");/*****ERROR*********/
              }
            var adhght = document.getElementById('ad_height').value;
            var adwdth = document.getElementById('ad_width').value;
            document.getElementById('adheight').value = adhght;
            document.getElementById('adwidth').value = adwdth;
                //var tempxml = tempxml + "<textboxa>a<rdrirmuennsion>ajay<height>" + document.getElementById(temp).style.height + "</height><width>" + document.getElementById(temp).style.width + "</width><xpos>" + document.getElementById(temp).style.left + "</xpos><ypos>" + document.getElementById(temp).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(temp).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(temp).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(temp).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(temp).innerHTML +"</text><bgcolor>" + document.getElementById(temp).backgroundColor + "</bgcolor></textbox>" ;
               // var tempxml = tempxml + "<textbox><dimension><height>" + document.getElementById(id2[0]).style.height + "</height><width>" + document.getElementById(id2[0]).style.width + "</width><xpos>" + document.getElementById(id2[0]).style.left + "</xpos><ypos>" + document.getElementById(id2[0]).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(id2[0]).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(id2[0]).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(id2[0]).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(id2[0]).innerHTML +"</text><bgcolor>" + document.getElementById(id2[0]).backgroundColor + "</bgcolor><bgimage>" + document.getElementById(id2[0]).style.backgroundImage + "</bgimage></textbox>" ;
                var tempxml = tempxml + "<textbox><dimension><height>" + adhght + "</height><width>" + adwdth + "</width><xpos>" + document.getElementById(id2[0]).style.left + "</xpos><ypos>" + document.getElementById(id2[0]).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(id2[0]).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(id2[0]).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(id2[0]).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(id2[0]).innerHTML +"</text><bgcolor>" + document.getElementById(id2[0]).backgroundColor + "</bgcolor><bgimage>" + document.getElementById(id2[0]).style.backgroundImage + "</bgimage></textbox>" ;
                }
            var xmlfile = "<template>" + tempxml + "</template>" ;
            document.getElementById('editordivxml').value=xmlfile;
            if(document.getElementById('fetchid').value == "")
            {
               var ajay;
              ajay=document.getElementById('selected_name').value;
              //var ankur;
             ankur=document.getElementById('savehidden').value;
            if(document.getElementById('savehidden').value=="")
              {
                _Default.update
                saveme1=window.open('saveme.aspx?ajay='+ajay,'','left=300px,top=250px,height=130px,width=350px,scroll=no,status=off' );     
              }
              else
               {
                  alert('This File Already Saved')
                  return;
               }
                //window.close();
                //document.getElementById('saveT').focus();
                //return false;
                }
                else
                {
                    var xhtml = document.getElementById('editordiv').innerHTML;
                    var id=document.getElementById('temp_id').value;
                    _Default.update(id,tempxml,xhtml,ht1);
                    alert('Template modified successfully !!');
                    currentid=null;
                    //return false;
                 }     
            }   
     }
     }
     
     
}
else if(browser!="Microsoft Internet Explorer")
  {
  if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
        {

  
    if(saveme1 && !saveme1.closed){saveme1.focus();}
    else
       {
       
          var h = document.getElementById('editordiv');
          var ht1 = h.innerHTML;
          if(h.childNodes[0].innerHTML=="")
            {
              alert('Nothing to save!!');
             }
            else
            {
              //if(CheckTemplate("save")=="true")
              //{
              var limit=ht1.split("</DIV>");
              document.getElementById('editordivfullhtml').value=h.innerHTML;
  
            /*******************************************************/
            for(var b=1; b<= limit.length; b++)
            {
                ht1 = ht1.replace("class=drag", "");
                ht1 = ht1.replace("onactivate=javascript:getid(this);","");
                ht1 = ht1.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsT();","");
                ht1 = ht1.replace("onresize=javascript:getdimsT();","");
                ht1 = ht1.replace("onmove=javascript:moves();","");
                ht1 = ht1.replace("onkeypress=","");
                ht1 = ht1.replace("javascript:blockkey(event,\'bcd\');","");
                ht1 = ht1.replace("onactivate=javascript:editmode(this);","");
                ht1 = ht1.replace("ondeactivate=javascript:dragmode(this);","");
                ht1 = ht1.replace("onfocus=javascript:getid(this);","");
                ht1 = ht1.replace("onclick=javascript:getid(this);","");
                ht1 = ht1.replace("onresize=javascript:getdimsP();","");
                ht1 = ht1.replace("contentEditable=true","");
                ht1 = ht1.replace("oncontextmenu=javascript:context_menu(this);   oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);","");
                ht1 = ht1.replace("oncontextmenu=javascript:context_menu(this);   javascript:showprop(this); \"\" ","");
            }
            document.getElementById('editordivhtml').value=ht1;
            for(var temp=0;temp<limit.length-2;temp++)
            {
             if(limit[temp]!="")
             {
                var id1 = limit[temp].split("id=");
                var id2 = id1[1].split(" ");/*****ERROR*********/
              }
            var adhght = document.getElementById('ad_height').value;
            var adwdth = document.getElementById('ad_width').value;
            document.getElementById('adheight').value = adhght;
            document.getElementById('adwidth').value = adwdth;
            var ajju = adhght * adwdth ;
                //var tempxml = tempxml + "<textboxa>a<rdrirmuennsion>ajay<height>" + document.getElementById(temp).style.height + "</height><width>" + document.getElementById(temp).style.width + "</width><xpos>" + document.getElementById(temp).style.left + "</xpos><ypos>" + document.getElementById(temp).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(temp).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(temp).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(temp).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(temp).innerHTML +"</text><bgcolor>" + document.getElementById(temp).backgroundColor + "</bgcolor></textbox>" ;
               // var tempxml = tempxml + "<textbox><dimension><height>" + document.getElementById(id2[0]).style.height + "</height><width>" + document.getElementById(id2[0]).style.width + "</width><xpos>" + document.getElementById(id2[0]).style.left + "</xpos><ypos>" + document.getElementById(id2[0]).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(id2[0]).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(id2[0]).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(id2[0]).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(id2[0]).innerHTML +"</text><bgcolor>" + document.getElementById(id2[0]).backgroundColor + "</bgcolor><bgimage>" + document.getElementById(id2[0]).style.backgroundImage + "</bgimage></textbox>" ;
                var tempxml = tempxml + "<textbox><dimension><height>" + adhght + "</height><width>" + adwdth + "</width><xpos>" + document.getElementById(id2[0]).style.left + "</xpos><ypos>" + document.getElementById(id2[0]).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(id2[0]).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(id2[0]).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(id2[0]).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(id2[0]).innerHTML +"</text><bgcolor>" + document.getElementById(id2[0]).backgroundColor + "</bgcolor><bgimage>" + document.getElementById(id2[0]).style.backgroundImage + "</bgimage></textbox>" ;
                }
            var xmlfile = "<template>" + tempxml + "</template>" ;
            document.getElementById('editordivxml').value=xmlfile;
            if(document.getElementById('fetchid').value == ""){
            var ajay;
            ajay=document.getElementById('selected_name').value;
            //var ankur;
            ankur=document.getElementById('savehidden').value;
            
           // alert(ankur);
            if(document.getElementById('savehidden').value=="")
              {
              _Default.update
                saveme1=window.open('saveme.aspx?ajay='+ajay,'','left=300px,top=250px,height=130px,width=350px,scroll=no,status=off' );     
               }
              else
               {
                  alert('This File Already Saved')
                  return;
               }
                //window.close();
                //document.getElementById('saveT').focus();
                //return false;
                }
                else
                {
                    var xhtml = document.getElementById('editordiv').innerHTML;
                    var id=document.getElementById('temp_id').value;
                    _Default.update(id,tempxml,xhtml,ht1);
                    alert('Template modified successfully !!');
                    currentid=null;
                    //return false;
                 }     
            }   
       }
       }

    }
  
   //} 
 }
/***************************************************/
function CheckTemplate(findval)
{
 var browser=navigator.appName;
 if(browser=="Microsoft Internet Explorer")
 {
    var htm = document.getElementById('editordiv').innerHTML;
    var spthtm = htm.split("<DIV");
    var countckad = spthtm.length;
    var adwidth = document.getElementById('outer').style.width;
    var adhght = document.getElementById('outer').style.height;
    var adwidth1 = adwidth.replace("px","");
    var adhght1 = adhght.replace("px","");
    for(var l=2; l < countckad; l++)
        {
           var i=0;
           var id1 = spthtm[l].split("id=");
           var id2 = id1[1].split(" ");
           //alert(id2[0]);
//           if(document.getElementById(id2[0]).innerHTML == "" || document.getElementById(id2[0]).innerText==sample)
//              {
//                  alert('Any box remain without Picture or Text ');
//                  break;
//              }
//            else
//            {
//                i=i+1;
//            }
           
            var h = document.getElementById(id2[0]).style.height.replace("px","");
            var w = document.getElementById(id2[0]).style.width.replace("px","");
            var l1 = document.getElementById(id2[0]).style.left.replace("px","");
            var t = document.getElementById(id2[0]).style.top.replace("px","");
            var outt = document.getElementById('outer').style.top.replace("px","");
            outt=parseInt(outt-15);
            var outl = document.getElementById('outer').style.left.replace("px","");
            outl=parseInt(outl-10);
            if((parseInt(adwidth1) + parseInt(outl)) < (parseInt(l1) + parseInt(w)) || (parseInt(adhght1) + parseInt(outt)) <(parseInt(t) + parseInt(h)) || parseInt(outt) > parseInt(t) || parseInt(outl) > parseInt(l1))
                {
                    //alert('Any Box Out From Main Border');
                    break;
                }
             else
                {
                    i=i+1;
                    //document.getElementById('checkAds').disabled = true;
                    //alert('abc');
                }
         }
         if(i==1)
         {
         
         if(findval=="save")
         {
         return "true"
         }
         else
         {
         alert("Template is OK");
         return ;
         }
           // alert("Template is Ok");
         }
      }
    else if(browser!="Microsoft Internet Explorer")
      {
      if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
        {
     //alert("in ad");
           var htm = document.getElementById('editordiv').innerHTML;
    var spthtm = htm.split("<div");
    var countckad = spthtm.length;
    var adwidth = document.getElementById('outer').style.width;
    var adhght = document.getElementById('outer').style.height;
    //alert(adwidth);
    //alert(adhght);
    var adwidth1 = adwidth.replace("px","");
    //alert(ad)
    var adhght1 = adhght.replace("px","");
    //var i=0;
    for(var l=2; l < countckad; l++)
        {
          var i=0;
         // alert(spthtm[l]);
           var id1 = spthtm[l].split("id=");
           //alert(id1[1]);
           var id2 = id1[1].split(" ");
           //alert(id2[0]);
           while(id2[0].indexOf('"')>=0)
           {
           id2[0]=id2[0].replace('"',"");
           }
           //alert(id2[0]);
//           if(document.getElementById(id2[0]).innerHTML == "" || document.getElementById(id2[0]).innerText==sample)
//              {
//                  alert('Any box remain without Picture or Text ');
//                  break;
//              }
//              else{
//              i=parseInt(i+1);
//              }
               //alert(document.getElementById(id2[0]).style.height);
            var h = document.getElementById(id2[0]).style.height.replace("px","");
            var w = document.getElementById(id2[0]).style.width.replace("px","");
            var l1 = document.getElementById(id2[0]).style.left.replace("px","");
            var t = document.getElementById(id2[0]).style.top.replace("px","");
           var outt = document.getElementById('outer').style.top.replace("px","");
            outt=parseInt(outt-15);
            var outl = document.getElementById('outer').style.left.replace("px","");
            outl=parseInt(outl-10);
            if((parseInt(adwidth1) + parseInt(outl)) < (parseInt(l1) + parseInt(w)) || (parseInt(adhght1) + parseInt(outt)) <(parseInt(t) + parseInt(h)) || parseInt(outt) > parseInt(t) || parseInt(outl) > parseInt(l1))
                {
                    alert('Any Box Out From Main Border');
                    break;
                }
             else
                {
                  i=parseInt(i+1);
                }
         }     
      if(i==1)
      {
      if(findval=="save")
         {
         return "true"
         }
         else
         {
         alert("Template is OK");
         return ;
         }
       
      }
   }
   }           
}

/********************function saveaddialog****************************/
function saveaddialog()
 {
   if(document.all)
   {
    
    if(saveme1 && !saveme1.closed){saveme1.focus();}
        else{
       
            var h = document.getElementById('editordiv');
            var ht1 = h.innerHTML;
             if(ht1=="")
              {
                alert('Nothing to be save!!!');
              }
            else
            {
              //alert('ajay');
            var limit=ht1.split("<DIV ")
            document.getElementById('editordivfullhtml').value=h.innerHTML;
            for(var b=1; b<= limit.length; b++){
            ht1 = ht1.replace("class=drag", "");
            ht1 = ht1.replace("oncontextmenu=javascript:context_menu(this);","");
            ht1 = ht1.replace("onactivate=javascript:getid(this);","");
            ht1 = ht1.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsT();","");
            ht1 = ht1.replace("onresize=javascript:getdimsT();","");
            ht1 = ht1.replace("onmove=javascript:moves();","");
            ht1 = ht1.replace("onkeypress=","");
            ht1 = ht1.replace("javascript:blockkey(event,\'bcd\');","");
            ht1 = ht1.replace("onactivate=javascript:editmode(this);","");
            ht1 = ht1.replace("ondeactivate=javascript:dragmode(this);","");
            ht1 = ht1.replace("onfocus=javascript:getid(this);","");
            ht1 = ht1.replace("onclick=javascript:getid(this);","");
            ht1 = ht1.replace("onresize=javascript:getdimsP();","");
            ht1 = ht1.replace("contentEditable=true","");
            //ht1 = ht1.replace("absolute","relative");
            }
            document.getElementById('editordivhtml').value=ht1;
            for(var temp=1;temp<=limit.length;temp++){
            try{
            var id1 = limit[temp].split("id=");
            var id2 = id1[1].split(" "); }
            catch(er){}
                //var tempxml = tempxml + "<textbox><dimension><height>" + document.getElementById(temp).style.height + "</height><width>" + document.getElementById(temp).style.width + "</width><xpos>" + document.getElementById(temp).style.left + "</xpos><ypos>" + document.getElementById(temp).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(temp).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(temp).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(temp).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(temp).innerHTML +"</text><bgcolor>" + document.getElementById(temp).backgroundColor + "</bgcolor></textbox>" ;
                var tempxml = tempxml + "<textbox><dimension><height>" + document.getElementById(id2[0]).style.height + "</height><width>" + document.getElementById(id2[0]).style.width + "</width><xpos>" + document.getElementById(id2[0]).style.left + "</xpos><ypos>" + document.getElementById(id2[0]).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(id2[0]).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(id2[0]).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(id2[0]).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(id2[0]).innerText+"</text><bgcolor>" + document.getElementById(id2[0]).style.backgroundColor + "</bgcolor><bgimage>" + document.getElementById(id2[0]).style.backgroundImage + "</bgimage></textbox>" ;
                }
            var xmlfile = "<template>" + tempxml + "</template>" ;
            document.getElementById('editordivxml').value=xmlfile;
            var adhght = document.getElementById('ad_height').value;
            var adwdth = document.getElementById('ad_width').value;
            document.getElementById('adheight').value = adhght;
            document.getElementById('adwidth').value = adwdth;
            
            //opener.document.getElementById('adheight').value=adhght
            //opener.document.getElementById('adwidth').value= adwdth;
            
             var finalfilterhtml=document.getElementById('editordivfullhtml').value
           while(finalfilterhtml.indexOf("rgb(")>0)
           {
                var mozillastart=finalfilterhtml.indexOf("rgb(");
                var mozillaend=mozillastart+20;
                var  finalfilterhtmlan=finalfilterhtml.substring(mozillastart+4,mozillaend);
                var rgbvalue=finalfilterhtmlan.split(")");
                str = rgbvalue[0].split(",");
                str[0] = parseInt(str[0], 10).toString(16).toLowerCase();
                str[1] = parseInt(str[1], 10).toString(16).toLowerCase();
                str[2] = parseInt(str[2], 10).toString(16).toLowerCase();
                str[0] = (str[0].length == 1) ? '0' + str[0] : str[0];
                str[1] = (str[1].length == 1) ? '0' + str[1] : str[1];
                str[2] = (str[2].length == 1) ? '0' + str[2] : str[2];
                var anka='#' + str.join("")
                var ank="rgb("+rgbvalue[0]+")";
               
               finalfilterhtml=document.getElementById('editordivfullhtml').value.replace(ank,anka);
               document.getElementById('editordivfullhtml').value=finalfilterhtml;
            }
            if(document.getElementById('fetchid1').value == "")
              {
               _Default.test(document.getElementById('editordivhtml').value,document.getElementById('editordivfullhtml').value,document.getElementById('editordivxml').value,document.getElementById('adheight').value,document.getElementById('adwidth').value,document.getElementById('sel_unit').value,document.getElementById('hdnadsname').value,document.getElementById('fetchins').value,document.getElementById('hidattach').value, test_callback)
                //public string test(string editordivhtml, string editordivfullhtml, string editordivxml, string height, string width, string uom, string adname, string fetchins)
                //saveme1=window.open('savead.aspx','','left=300px,top=250px,height=100px,width=250px,scroll=no,status=off');     
               
              }
             else
               {
                    var xhtml = document.getElementById('editordiv').innerHTML;
                    var id=document.getElementById('temp_id').value;
                    _Default.adupdate(id,tempxml,xhtml,ht1);
                     alert('Ad Modified Successfully !!');
                     currentid=null;
               }     
            } //}  
       }
  }
  //mozilla
    else
      {
        if(saveme1 && !saveme1.closed){saveme1.focus();}
        else{
        //alert("hreer")
            var h = document.getElementById('editordiv');
            var ht1 = h.innerHTML;
            //alert(ht1);
             if(ht1=="")
              {
                alert('Nothing to be save!!!');
              }
            else
            {
            
            //alert('mozsave3');
                var limit=ht1.split("<div ")
                document.getElementById('editordivfullhtml').value=h.innerHTML;
                for(var b=1; b<= limit.length; b++){
                ht1 = ht1.replace("class=drag", "");
                ht1 = ht1.replace("oncontextmenu=javascript:context_menu(this);","");
                ht1 = ht1.replace("onactivate=javascript:getid(this);","");
                ht1 = ht1.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsT();","");
                ht1 = ht1.replace("onresize=javascript:getdimsT();","");
                ht1 = ht1.replace("onmove=javascript:moves();","");
                ht1 = ht1.replace("onkeypress=","");
                ht1 = ht1.replace("javascript:blockkey(event,\'bcd\');","");
                ht1 = ht1.replace("onactivate=javascript:editmode(this);","");
                ht1 = ht1.replace("ondeactivate=javascript:dragmode(this);","");
                ht1 = ht1.replace("onfocus=javascript:getid(this);","");
                ht1 = ht1.replace("onclick=javascript:getid(this);","");
                ht1 = ht1.replace("onresize=javascript:getdimsP();","");
                ht1 = ht1.replace("contentEditable=true","");
                //ht1 = ht1.replace("absolute","relative");
            }
            document.getElementById('editordivhtml').value=ht1;
            for(var temp=1;temp<=limit.length;temp++){
            try{
            var id1 = limit[temp].split("id=");
            var id2 = id1[1].split(" ");
            //alert(id2);
             }
            catch(er){}
             var nh=id2[0];
                          while(nh.indexOf('"')>=0)
                          {
                           nh=nh.replace('"',"")
                          }
                        id2[0]=nh;
                        //alert(id2[0]);
                //var tempxml = tempxml + "<textbox><dimension><height>" + document.getElementById(temp).style.height + "</height><width>" + document.getElementById(temp).style.width + "</width><xpos>" + document.getElementById(temp).style.left + "</xpos><ypos>" + document.getElementById(temp).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(temp).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(temp).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(temp).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(temp).innerHTML +"</text><bgcolor>" + document.getElementById(temp).backgroundColor + "</bgcolor></textbox>" ;
                var tempxml = tempxml + "<textbox><dimension><height>" + document.getElementById(id2[0]).style.height + "</height><width>" + document.getElementById(id2[0]).style.width + "</width><xpos>" + document.getElementById(id2[0]).style.left + "</xpos><ypos>" + document.getElementById(id2[0]).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(id2[0]).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(id2[0]).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(id2[0]).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(id2[0]).textContent +"</text><bgcolor>" + document.getElementById(id2[0]).style.backgroundColor + "</bgcolor><bgimage>" + document.getElementById(id2[0]).style.backgroundImage + "</bgimage></textbox>" ;
                }
                //alert('mozsave4');
            var xmlfile = "<template>" + tempxml + "</template>" ;
            document.getElementById('editordivxml').value=xmlfile;
            var adhght = document.getElementById('ad_height').value;
            var adwdth = document.getElementById('ad_width').value;
            document.getElementById('adheight').value = adhght;
            document.getElementById('adwidth').value = adwdth;
             //alert('mozsave5');

            
            
            if(document.getElementById('fetchid1').value == ""){
             //alert('mozsave6');
           var finalfilterhtml=document.getElementById('editordivfullhtml').value
           while(finalfilterhtml.indexOf("rgb(")>0)
           {
            var mozillastart=finalfilterhtml.indexOf("rgb(");
            var mozillaend=mozillastart+20;
          var  finalfilterhtmlan=finalfilterhtml.substring(mozillastart+4,mozillaend);
            var rgbvalue=finalfilterhtmlan.split(")");
            str = rgbvalue[0].split(",");
           str[0] = parseInt(str[0], 10).toString(16).toLowerCase();
           str[1] = parseInt(str[1], 10).toString(16).toLowerCase();
           str[2] = parseInt(str[2], 10).toString(16).toLowerCase();
           str[0] = (str[0].length == 1) ? '0' + str[0] : str[0];
           str[1] = (str[1].length == 1) ? '0' + str[1] : str[1];
           str[2] = (str[2].length == 1) ? '0' + str[2] : str[2];
           var anka='#' + str.join("")
           var ank="rgb("+rgbvalue[0]+")";
            //alert('mozsave7');
          finalfilterhtml=document.getElementById('editordivfullhtml').value.replace(ank,anka);
          document.getElementById('editordivfullhtml').value=finalfilterhtml;
           }
            document.getElementById('editordivfullhtml').value
             //alert('mozsave8');
             _Default.test(document.getElementById('editordivhtml').value,document.getElementById('editordivfullhtml').value,document.getElementById('editordivxml').value,document.getElementById('adheight').value,document.getElementById('adwidth').value,document.getElementById('sel_unit').value,document.getElementById('hdnadsname').value,document.getElementById('fetchins').value,document.getElementById('hidattach').value,"Mozilla",test_callback)
                //saveme1=window.open('savead.aspx','','left=300px,top=250px,height=100px,width=250px,scroll=no,status=off');     
                //alert('mozsave9');
              }
             else
               {
               
                  var xhtml = document.getElementById('editordiv').innerHTML;
                  var id=document.getElementById('temp_id').value;
                  _Default.adupdate(id,tempxml,xhtml,ht1);
                  alert('Ad Modified Successfully !!');
                  currentid=null;
                }     
            }   
         //}
       
         }
      } 
  
}  
  
function test_callback(res)
     {
      if(document.all)
        {
            var xml = new ActiveXObject("Microsoft.XMLHTTP");
            xml.Open( "GET","saveadas.aspx", false );
            xml.Send();
            //alert(xml.responseText);
             var value=xml.responseText; 
            var value=value.split("~");
            //alert(value);
           
            opener.document.getElementById('txtadsize1').value= value[1];
            opener.document.getElementById('txtadsize2').value= value[2];
            if(value[5]=="")
            {
                var idlen=opener.document.getElementById("bookdiv").childNodes[0].childNodes[0].children.length
                for(i=1;i<idlen;i++)
                {
                var num=parseInt(i)-parseInt(1)
                    if(opener.document.getElementById("fil"+num).value=="")
                    {
                        opener.document.getElementById("fil"+num).value=value[4];
                    }
                    if(opener.document.getElementById("hei"+num).value=="")
                    {
                        opener.document.getElementById("hei"+num).value=value[1];
                    }
                    if(opener.document.getElementById("wid"+num).value=="")
                    {
                        opener.document.getElementById("wid"+num).value=value[2];
                    }
                    opener.document.getElementById("siz"+num).value=parseFloat(value[1])*parseFloat(value[2]);
                }
            }
            else
            {
                 opener.document.getElementById("fil"+value[5]).value=value[4];
                 opener.document.getElementById("hei"+value[5]).value=value[1];
                 opener.document.getElementById("wid"+value[5]).value=value[2];
                 opener.document.getElementById("siz"+value[5]).value=parseFloat(value[1])*parseFloat(value[2]);
            }
             opener.document.getElementById("txttotalarea").value=value[6];
             alert("Ad Save Successfull");  
             window.close();
       } 
     else
     {
        //alert('mozsave10');
          httpRequest= new XMLHttpRequest();
          if(httpRequest.overrideMimeType)
		   {
             httpRequest.overrideMimeType('text/xml'); 
           }
         httpRequest.onreadystatechange = function()
          {
             alertContents(httpRequest); }
         httpRequest.open('GET', "mozillasave.aspx", true);
         httpRequest.send('');
         var value=httpRequest.responseText; 
        var value=value.split("~");
        //alert(value);
       // opener.document.getElementById('adheight').value= value[1];
      //opener.document.getElementById('adwidth').value= value[2];
      alert("Ad Save Successfull");
      window.close();
     
     }  
}

/********************end of function saveaddialog********************/

 function showhtml(){
        var xmlid=document.getElementById('xmllist').value;
        openlayout.getthevalue(xmlid,show_reference);
        return false;		 
  }
  function show_reference(response){
        var ds=response.value;
        //alert(ds.Tables[0].Rows[0].ToString());
        //if(ds.Tables[0].Rows[0].temp_xhtml==null)
        //{
            var myval=ds.Tables[0].Rows[0].temp_xhtml;
            preview.document.body.innerHTML=myval;
        //}
        //else alert('Select from list');
  }
/******************************/
//if(document.getElementById('openTemplate1_xmllist1').value=="")
//        {
//           alert("No Template Selected !");
//           return false;
//        }
//        var xmlid=document.getElementById('openTemplate1_xmllist1').value;

/***********************************/  
  
  
 function gethtm() 
 {
   //alert("gethtm");
     var browser=navigator.appName;
  if(browser!="Microsoft Internet Explorer")
    {
    
    try
     {
          if(document.getElementById('openTemplate_xmllist').value=="")
           {
                alert("No Template Selected !");
                return false;
            }
             
            //var xmlid=document.getElementById('openTemplate$xmllist').value;
            var xmlid=document.getElementById('openTemplate_xmllist').value;
            //var xmlid=document.getElementById('openTemplate1_xmllist1').value;
            //alert('ankit');
            _Default.getthevalue(xmlid,call_referrence);
            //openlayout.getthevalue(xmlid,call_referrence);
           //   currentid='outer';
          
           return false;
       }
       catch (er){return false;}
       
     }
   else if(browser=="Microsoft Internet Explorer")
     {
      try
         {
              if(document.getElementById('openTemplate_xmllist').value=="")
               {
                    alert("No Template Selected !");
                    return false;
                }
                var xmlid=document.getElementById('openTemplate$xmllist').value;
                _Default.getthevalue(xmlid,call_referrence);
                //openlayout.getthevalue(xmlid,call_referrence);
               //   currentid='outer';
               return false;
           }
         catch (er){return false;}
      }
     
    }
  



/******************************************************/ 
function call_referrence(response)
{
 // alert('4cplus');
  var browser=navigator.appName;
  if(browser!="Microsoft Internet Explorer")
    {
       var ds=response.value;
      //alert("hello");
        var abc=ds.Tables[0].Rows[0].temp_html;
        var uom2=ds.Tables[0].Rows[0].uom;
        var id=ds.Tables[0].Rows[0].template_id;/* changes occurred when page change to Uctrl*/
        /*opener.*/document.getElementById('temp_id').value="";
        /*opener.*/document.getElementById('temp_id').value=id;
        document.getElementById('sav').value="";
        document.getElementById('sav').value=1;
        document.getElementById('selected_name').value= ds.Tables[0].Rows[0].name;
        /*opener.*/document.getElementById('fetchid').value=1;
        var count=abc.split("</div>");
        /*opener.*/document.getElementById('ctrval').value = parseInt(count.length);
        ad_template=0;
        document.getElementById('myhdnval').value="";
//         document.getElementById('ad_height').value="";
//          document.getElementById('ad_width').value="";
        document.getElementById('xvalue').value="";
          document.getElementById('yvalue').value="";
          document.getElementById('hghtsel').value="";
          document.getElementById('wdthsel').value=""; 
         
          document.getElementById('savehidden').value="test";
           document.getElementById('toolsbox_fcolor').style.backgroundColor="ButtonFace";
            document.getElementById('toolsbox_bgcolor').style.backgroundColor="ButtonFace"; 
        template_ads();
        enabled();
        
        for(var i=1; i<count.length; i++)
            {
                var abc1 = abc.replace("editmode","em");
                //src=\"http://localhost:2023/Admaking/images1/Image2-.jpg\"
               // count[i] = count[i].replace("http://localhost:1506/Admaking/","http://ajay/admaking/");
                abc=abc1;
             }
             
            // abc = abc.replace("http://localhost:1506/Admaking/","http://ajay/admaking/");
//            alert(ds.Tables[0].Rows[0].adheight);
//            document.getElementById('ad_height').value = ds.Tables[0].Rows[0].adheight;
//            document.getElementById('ad_width').value = ds.Tables[0].Rows[0].adwidth;
            unit=uom2;
        /*window.opener.*/document.getElementById('editordiv').innerHTML=abc;
//        alert(document.getElementById('outer').style.height);
        document.getElementById('ad_height').value=parseInt(document.getElementById('outer').style.height);
        document.getElementById('ad_width').value=parseInt(document.getElementById('outer').style.width);       
        document.getElementById('sel_unit').value = uom2;
        if(uom2==1)
            {
              document.getElementById('sel_unit_disp').value="px";
            }
        if(uom2==2)
            {
                document.getElementById('sel_unit_disp').value="inch";
            }
        if(uom2==3)
            {
                document.getElementById('sel_unit_disp').value="cm";
            }
        if(uom2==4)
            {
                document.getElementById('sel_unit_disp').value="mm";
            }
            
        //return currentid;
     }
     else if(browser=="Microsoft Internet Explorer") 
     {
      var ds=response.value;
      
        var abc=ds.Tables[0].Rows[0].temp_html;
        var uom2=ds.Tables[0].Rows[0].uom;
        var id=ds.Tables[0].Rows[0].template_id;/* changes occurred when page change to Uctrl*/
        /*opener.*/document.getElementById('temp_id').value="";
        /*opener.*/document.getElementById('temp_id').value=id;
        document.getElementById('sav').value="";
        document.getElementById('sav').value=1;
        document.getElementById('selected_name').value= ds.Tables[0].Rows[0].name;
        /*opener.*/document.getElementById('fetchid').value=1;
        var count=abc.split("</DIV>");
        /*opener.*/document.getElementById('ctrval').value = count.length;
        ad_template=0;
        template_ads();
        enabled();
        for(var i=1; i<count.length; i++)
            {
                var abc1 = abc.replace("editmode","em");
                //src=\"http://localhost:2023/Admaking/images1/Image2-.jpg\"
               // count[i] = count[i].replace("http://localhost:1506/Admaking/","http://ajay/admaking/");
                abc=abc1;
             }
             
            // abc = abc.replace("http://localhost:1506/Admaking/","http://ajay/admaking/");
            document.getElementById('ad_height').value = ds.Tables[0].Rows[0].adheight;
            document.getElementById('ad_width').value = ds.Tables[0].Rows[0].adwidth;
            unit=uom2;
        /*window.opener.*/document.getElementById('editordiv').innerHTML=abc;
        document.getElementById('sel_unit').value = uom2;
        if(uom2==1)
            {
              document.getElementById('sel_unit_disp').value="px";
            }
        if(uom2==2)
            {
                document.getElementById('sel_unit_disp').value="inch";
            }
        if(uom2==3)
            {
                document.getElementById('sel_unit_disp').value="cm";
            }
        if(uom2==4)
            {
                document.getElementById('sel_unit_disp').value="mm";
            }
            
       // return currentid;
     
     
     }
   }  
 /*************************end of function**********/     
     
function call_referrence1(response)
{
 var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
    {
       //alert(document.getElementById('editordiv').innerHTML);
       
        var stext=document.getElementById('savehtml').value;
        stext=stext.toLowerCase();
        
        var newabc1=document.getElementById('editordiv').innerHTML;
       newabc1=newabc1.toLowerCase();
//        while(stext.indexOf('<DIV')>=0)
//        {
//        stext=stext.replace("<DIV","<div");
//        }
//        while(stext.indexOf('</DIV')>=0)
//        {
//        stext=stext.replace("</DIV","</div");
//        }
//        
//        stext=stext.replace("getdimsO","getdimsT");
//       
//        while(stext.indexOf('em')>=0)
//        {
//        stext=stext.replace("em","editmode");
//        }
        document.getElementById('savehtml').value=stext;
         //alert(document.getElementById('savehtml').value);
        if(document.getElementById('savehtml').value!="")
        {
            if(newabc1!=document.getElementById('savehtml').value)
            {
            var choice = confirm ("Do You Want To Save Ad before Opening New Ad");
            if(choice)
           {    
                saveaddialog();
               
            }
            else
            {
            
            
            }
            
            
            }
        }
        var ds=response.value;
        var abc=ds.Tables[0].Rows[0].temp_html;
        var uom2=ds.Tables[0].Rows[0].uom;
        var id=ds.Tables[0].Rows[0].template_id;/* changes occurred when page change to Uctrl*/
        /*opener.*/document.getElementById('temp_id').value="";
        /*opener.*/document.getElementById('temp_id').value=id;
        
        document.getElementById('ad_height').value = ds.Tables[0].Rows[0].adheight;
        document.getElementById('ad_width').value = ds.Tables[0].Rows[0].adwidth;
        document.getElementById('selected_name').value = ds.Tables[0].Rows[0].name;
        document.getElementById('sav').value="";
        document.getElementById('sav').value=2;
        document.getElementById('fetchid').value=1;
        
        /*opener.*///document.getElementById('fetchid1').value=1;
        var count=abc.split("</div>");
        /*opener.*/document.getElementById('ctrval').value =parseInt( count.length);
         
       // enabled();
         document.getElementById('myhdnval').value="";
       document.getElementById('ad_height').value="";
          document.getElementById('ad_width').value="";
        document.getElementById('xvalue').value="";
          document.getElementById('yvalue').value="";
          document.getElementById('hghtsel').value="";
          document.getElementById('wdthsel').value=""; 
           document.getElementById('toolsbox_fcolor').style.backgroundColor="ButtonFace";
        document.getElementById('toolsbox_bgcolor').style.backgroundColor="ButtonFace";
        ad_template=1;
        template_ads();
        x = new Array();
        for(var i=0; i<parseInt(count.length); i++)
        {
            //alert(count[i]);
            var sp1 = count[i].split('true">');
            x[i] = sp1[1];
            //alert(x[i]);
            //alert(x[i]);
            //var sp2 = sp1.split("\"");
        }
        for(var i=1; i<count.length; i++)
            {
                var abc1 = abc.replace("em","editmode");
                abc=abc1;
             }
             
        abc=abc.replace("getdimsO","getdimsT");
        //abc=abc.replace("javascript:getdimsO();","")
        //var sp1 = abc.split(
        document.getElementById('sel_unit').value = uom2;
        /*window.opener.*/document.getElementById('editordiv').innerHTML=abc;
        document.getElementById('savehtml').value=abc;
        document.getElementById('ad_height').value=parseInt(document.getElementById('outer').style.height);
        document.getElementById('ad_width').value=parseInt(document.getElementById('outer').style.width);       
       
        document.getElementById('sel_unit').value = uom2;
        if(uom2==1)
            {
                document.getElementById('sel_unit_disp').value="px";
            }
        if(uom2==2)
            {
                document.getElementById('sel_unit_disp').value="inch";
            }
        if(uom2==3)
            {
                document.getElementById('sel_unit_disp').value="cm";
            }
        if(uom2==4)
            {
                document.getElementById('sel_unit_disp').value="mm";
            }
             
        return currentid;
     } 
  else if(browser=="Microsoft Internet Explorer")
  {
        var ds=response.value;
        var abc=ds.Tables[0].Rows[0].temp_html;
        var uom2=ds.Tables[0].Rows[0].uom;
        var id=ds.Tables[0].Rows[0].template_id;/* changes occurred when page change to Uctrl*/
        /*opener.*/document.getElementById('temp_id').value="";
        /*opener.*/document.getElementById('temp_id').value=id;
        document.getElementById('ad_height').value = ds.Tables[0].Rows[0].adheight;
            document.getElementById('ad_width').value = ds.Tables[0].Rows[0].adwidth;
            document.getElementById('selected_name').value = ds.Tables[0].Rows[0].name;
        document.getElementById('sav').value="";
        document.getElementById('sav').value=2;
        document.getElementById('fetchid').value=1;
        /*opener.*///document.getElementById('fetchid1').value=1;
        var count=abc.split("</DIV>");
        /*opener.*/document.getElementById('ctrval').value = count.length;
        enabled();
        ad_template=1;
        template_ads();
        
        for(var i=1; i<count.length-1; i++)
        {
            
            var sp1 = count[i].split("Box\">");  //count[1].split("\">")
            x[i] = sp1[1];
            //var sp2 = sp1.split("\"");
        }
        for(var i=1; i<count.length; i++)
            {
                var abc1 = abc.replace("em","editmode");
                abc=abc1;
             }
        abc=abc.replace("getdimsO","getdimsT");
        //abc=abc.replace("javascript:getdimsO();","")
        //var sp1 = abc.split(
        document.getElementById('sel_unit').value = uom2;
        /*window.opener.*/document.getElementById('editordiv').innerHTML=abc;
        document.getElementById('sel_unit').value = uom2;
        if(uom2==1)
            {
                document.getElementById('sel_unit_disp').value="px";
            }
        if(uom2==2)
            {
                document.getElementById('sel_unit_disp').value="inch";
            }
        if(uom2==3)
            {
                document.getElementById('sel_unit_disp').value="cm";
            }
        if(uom2==4)
            {
                document.getElementById('sel_unit_disp').value="mm";
            }
        return currentid;
  
  }
     
}     
     

 /********************/
function getadhtm1() 
 {
   try
     {
     ad_template=1;
        template_ads();
       if(document.getElementById('openads_xmllist3').value=="")
        {
            alert("No Template Selected !");
            return false;
        }
        var xmlid=document.getElementById('openads_xmllist3').value;
        _Default.getadvalue(xmlid,call_adreferrence1);
        
        //openlayout.getthevalue(xmlid,call_referrence);
       //   currentid='outer';
        return false;
     }
       catch (er){return false;}
       
     }
     
function call_adreferrence1(response)
 {
    
   if(document.all)
   {
      var ds=response.value;
        var abc=ds.Tables[0].Rows[0].ad_html;
        var uom2=ds.Tables[0].Rows[0].ad_uom;
        var id=ds.Tables[0].Rows[0].ad_id;/* changes occurred when page change to Uctrl*/
        /*opener.*/document.getElementById('temp_id').value="";
        /*opener.*/document.getElementById('temp_id').value=id;
        /*opener.*/document.getElementById('fetchid1').value=1;
        document.getElementById('sav').value="";
        document.getElementById('sav').value=2;
        document.getElementById('selected_name').value= ds.Tables[0].Rows[0].name;
        var count=abc.split("</DIV>");
        /*opener.*/document.getElementById('ctrval').value = count.length;
        enabled();
        document.getElementById('edittemplate').onclick=ignoreClick;
         document.getElementById('edittemplate').style.cursor="text";
        ad_template=1;
        template_ads();
          document.getElementById('myhdnval').value="";
        document.getElementById('ad_height').value="";
          document.getElementById('ad_width').value="";
        document.getElementById('xvalue').value="";
          document.getElementById('yvalue').value="";
          document.getElementById('hghtsel').value="";
          document.getElementById('wdthsel').value="";
           document.getElementById('toolsbox_fcolor').style.backgroundColor="ButtonFace";
                            document.getElementById('toolsbox_bgcolor').style.backgroundColor="ButtonFace"; 
        /*window.opener.*/
        document.getElementById('ad_height').value = ds.Tables[0].Rows[0].ad_height;
        document.getElementById('ad_width').value = ds.Tables[0].Rows[0].ad_width;
        /*window.opener.*/document.getElementById('editordiv').innerHTML=abc;
        document.getElementById('ad_height').value=parseInt(document.getElementById('outer').style.height);
        document.getElementById('ad_width').value=parseInt(document.getElementById('outer').style.width);       
        document.getElementById('sel_unit').value = uom2;
        if(uom2==1)
            {
                document.getElementById('sel_unit_disp').value="px";
            }
        if(uom2==2)
            {
                document.getElementById('sel_unit_disp').value="inch";
            }
        if(uom2==3)
            {
                document.getElementById('sel_unit_disp').value="cm";
            }
        if(uom2==4)
            {
                document.getElementById('sel_unit_disp').value="mm";
            }
              
     
        //document.getElementById('editordiv').innerHTML=abc;
       // return currentid;
    // } 
   
   
   
    /* function call_adreferrence1(response){
      var ds=response.value;
        var abc=ds.Tables[0].Rows[0].ad_html;
        var id=ds.Tables[0].Rows[0].ad_id;/* changes occurred when page change to Uctrl*/
        /*opener.*/document.getElementById('temp_id').value="";
        /*opener.*/document.getElementById('temp_id').value=id;
        /*opener.*/document.getElementById('fetchid1').value=1;
        var count=abc.split("</DIV>");
        /*opener.*/document.getElementById('ctrval').value = count.length;
        //enabled();
        /*window.opener.*/document.getElementById('editordiv').innerHTML=abc;
         //alert('ajay');
        return currentid;
        }
        else
        {
        var ds=response.value;
        var abc=ds.Tables[0].Rows[0].ad_html;
        var uom2=ds.Tables[0].Rows[0].ad_uom;
        var id=ds.Tables[0].Rows[0].ad_id;/* changes occurred when page change to Uctrl*/
        /*opener.*/document.getElementById('temp_id').value="";
        /*opener.*/document.getElementById('temp_id').value=id;
        /*opener.*/document.getElementById('fetchid1').value=1;
        document.getElementById('sav').value="";
        document.getElementById('sav').value=2;
        document.getElementById('selected_name').value= ds.Tables[0].Rows[0].name;
        var count=abc.split("</div>");
        /*opener.*/document.getElementById('ctrval').value = count.length;
        
        enabled();
        document.getElementById('edittemplate').onclick=ignoreClick;
         document.getElementById('edittemplate').style.cursor="text";
        ad_template=1;
        template_ads();
          document.getElementById('myhdnval').value="";
        document.getElementById('ad_height').value="";
          document.getElementById('ad_width').value="";
        document.getElementById('xvalue').value="";
          document.getElementById('yvalue').value="";
          document.getElementById('hghtsel').value="";
          document.getElementById('wdthsel').value="";
           document.getElementById('toolsbox_fcolor').style.backgroundColor="ButtonFace";
           document.getElementById('toolsbox_bgcolor').style.backgroundColor="ButtonFace"; 
        /*window.opener.*/
        document.getElementById('ad_height').value = ds.Tables[0].Rows[0].ad_height;
        document.getElementById('ad_width').value = ds.Tables[0].Rows[0].ad_width;
        /*window.opener.*/document.getElementById('editordiv').innerHTML=abc;
        document.getElementById('ad_height').value=parseInt(document.getElementById('outer').style.height);
        document.getElementById('ad_width').value=parseInt(document.getElementById('outer').style.width);       
        document.getElementById('sel_unit').value = uom2;
        if(uom2==1)
            {
                document.getElementById('sel_unit_disp').value="px";
            }
        if(uom2==2)
            {
                document.getElementById('sel_unit_disp').value="inch";
            }
        if(uom2==3)
            {
                document.getElementById('sel_unit_disp').value="cm";
            }
        if(uom2==4)
            {
                document.getElementById('sel_unit_disp').value="mm";
            }
              
     
        //document.getElementById('editordiv').innerHTML=abc;
       // return currentid;
    // } 
   
   
   
    /* function call_adreferrence1(response){
      var ds=response.value;
        var abc=ds.Tables[0].Rows[0].ad_html;
        var id=ds.Tables[0].Rows[0].ad_id;/* changes occurred when page change to Uctrl*/
        /*opener.*/document.getElementById('temp_id').value="";
        /*opener.*/document.getElementById('temp_id').value=id;
        /*opener.*/document.getElementById('fetchid1').value=1;
        var count=abc.split("</div>");
        /*opener.*/document.getElementById('ctrval').value = count.length;
        //alert(document.getElementById('ctrval').value)
        //enabled();
        /*window.opener.*/document.getElementById('editordiv').innerHTML=abc;
         //alert('ajay');
        return currentid;
        
        
        
        
        
        
        }
        
        
        
        
        
        
        }
     //}


     /**********************/
function gethtml1() 
  {
  //alert('getad');
   var browser=navigator.appName;
   if(browser!="Microsoft Internet Explorer")
    {
        if(document.getElementById('openTemplate1_xmllist1').value=="")
        {
           alert("No Template Selected !");
           return false;
        }
        var xmlid=document.getElementById('openTemplate1_xmllist1').value;
        _Default.getthevalue(xmlid,call_referrence1);
        //openlayout.getthevalue(xmlid,call_referrence);
       //currentid='outer';
        return false;
     }
    else if(browser=="Microsoft Internet Explorer")
     {
         if(document.getElementById('openTemplate1_xmllist1').value=="")
                {
                   alert("No Template Selected !");
                   return false;
                }
            var xmlid=document.getElementById('openTemplate1_xmllist1').value;
            _Default.getthevalue(xmlid,call_referrence1);
            //openlayout.getthevalue(xmlid,call_referrence);
           //currentid='outer';
            return false;
     }
  }
  
//   var h = document.getElementById('editordiv');
//          var ht1 = h.innerHTML;
//          if(ht1=="")
//            {
//              alert('Nothing to be save!!');
//             }
  
/****************************end of function***************/     
 function saveasdialog1(){
     if(saveas && !saveas.closed){saveas.focus();}
     else{
            
            var h = document.getElementById('editordiv');
            var ht1 = h.innerHTML;
            //alert("h1"+h.childNodes[0].innerHTML)
            //if(h.childNodes[0].innerHTML=="")
            if(ht1=="")
            {
                alert("Nothing To Save");
            }
            else
            {
            var limit=ht1.split("<DIV")
            document.getElementById('editordivfullhtml').value=h.innerHTML;
            //var limit=document.getElementById('ctrval').value
            for(var b=0; b<= limit.length; b++){
                ht1 = ht1.replace("class=drag", "");
                ht1 = ht1.replace("oncontextmenu=javascript:context_menu(this);","");
                ht1 = ht1.replace("  javascript:showprop(this);","");
                ht1 = ht1.replace("onfocusout=javascript:lostfocus();","")
                ht1 = ht1.replace("onactivate=javascript:getid(this);","");
                ht1 = ht1.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);","");
                ht1 = ht1.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsT();","");
                ht1 = ht1.replace("onresize=javascript:getdimsT();","");
                ht1 = ht1.replace("onmove=javascript:moves();","");
                ht1 = ht1.replace("onkeypress=","");
                ht1 = ht1.replace("javascript:blockkey(event,\'bcd\');","");
                ht1 = ht1.replace("onactivate=javascript:editmode(this);","");
                ht1 = ht1.replace("ondeactivate=javascript:dragmode(this);","");
                ht1 = ht1.replace("onfocus=javascript:getid(this);","");
                ht1 = ht1.replace("onclick=javascript:getid(this);","");
                ht1 = ht1.replace("onresize=javascript:getdimsP();","");
                ht1 = ht1.replace("contentEditable=true","");
               //ht1 = ht1.replace("absolute","relative"); 
            }
            document.getElementById('editordivhtml').value=ht1;
            //for(var temp=1;temp<limit.length-1;temp++){ 
            
             /********************************************/
            var limitorg="";
            for(var i=1; i<limit.length-1; i++)
                {
                
                    var limit1 = limit[i].split("id=");
                    var limit11 = limit1[1].split(" ");
                    var id =limit11[0];
                  if(i==0)
                   {
                    var width = document.getElementById(id).style.width;
                    width = width.replace("px","");
                    
                    var height = document.getElementById(id).style.height;
                    height = height.replace("px","");
                    
//                    var top = document.getElementById(id).style.top;
//                    top = top.replace("px","");
//                    
//                    var left = document.getElementById(id).style.left;
//                    left = left.replace("px","");
                    
                    var border = document.getElementById(id).style.borderWidth;
                    border = border.replace("px","");
                    var h= "HEIGHT: " + height;
                    var h1= "HEIGHT: " + (parseInt(height)+parseInt(2*border));
                    
                    var w = "WIDTH: " + width;
                    var w1 = "WIDTH: " + (parseInt(width)+parseInt(2*border));
                    
                    var t = "TOP: " + top;
                    var t1 = "TOP: " + (parseInt(top)+parseInt(2*border));
                    
                    var l = "LEFT: " + left;
                    var l1 = "LEFT: " + (parseInt(left)+parseInt(2*border));
                    }
                    else
                    {
                    var width = document.getElementById(id).style.width;
                    width = width.replace("px","");
                    
                    var height = document.getElementById(id).style.height;
                    height = height.replace("px","");
                    
                    var top = document.getElementById(id).style.top;
                    top = top.replace("px","");
                    
                    var left = document.getElementById(id).style.left;
                    left = left.replace("px","");
                    
                    var border = document.getElementById(id).style.borderWidth;
                    border = border.replace("px","");
                    var h= "HEIGHT: " + height;
                    var h1= "HEIGHT: " + (parseInt(height)+parseInt(2*border));
                    
                    var w = "WIDTH: " + width;
                    var w1 = "WIDTH: " + (parseInt(width)+parseInt(2*border));
                    
                    var t = "TOP: " + top;
                    var t1 = "TOP: " + (parseInt(top)+parseInt(2*border));
                    
                    var l = "LEFT: " + left;
                    var l1 = "LEFT: " + (parseInt(left)+parseInt(2*border));
                    }
                    var limitfin = limit[i].replace(h, h1);
                    limitfin = limitfin.replace(w, w1);
                    limitfin = limitfin.replace(t, t1);
                    limitfin = limitfin.replace(l, l1);
                    //limitorg = 
                    limitorg = limitorg + a + limitfin;
                    var a = "</DIV>";
                    //var limit11 = 
                    
                 } 
                 document.getElementById('newhtml1').value=limitorg;
            /*******************************************/ 
               for(var temp=1;temp<limit.length-1;temp++){
            var id1 = limit[temp].split("id=");
            var id2 = id1[1].split(" ");    
            var tempxml = tempxml + "<textbox><dimension><height>" + document.getElementById(id2[0]).style.height + "</height><width>" + document.getElementById(id2[0]).style.width + "</width><xpos>" + document.getElementById(id2[0]).style.left + "</xpos><ypos>" + document.getElementById(id2[0]).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(id2[0]).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(id2[0]).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(id2[0]).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(id2[0]).innerHTML +"</text><bgcolor>" + document.getElementById(id2[0]).backgroundColor + "</bgcolor><bgimage>" + document.getElementById(id2[0]).style.backgroundImage + "</bgimage></textbox>" ;

                }
            var xmlfile = "<template>" + tempxml + "</template>" ;
            document.getElementById('editordivxml').value=xmlfile;
            
            //
            
               if(document.getElementById('fetchid').value == "")
              {
               var ajay;
              ajay=document.getElementById('selected_name').value;
              //var ankur;
             ankur=document.getElementById('savehidden').value;
            //if(document.getElementById('savehidden').value=="")
             // {
                _Default.update
                saveasdialog=window.open('saveas.aspx?ajay='+ajay,'','left=300px,top=250px,height=130px,width=350px,scroll=no,status=off' );     
             // }
             // else
              // {
                //  alert('This File Already Saved')
                //  return;
               //}
            
           
           }
            //
            
            
            
            
            
            
            
            
           // saveasdialog=window.open('saveas.aspx','saveme1','left=300px,top=300px,width=250px,height=100px,left=275,top=230');
            }
            }
      
  }
       
       
       
   var saveasad;
  function saveasaddialog()
       {
        if(saveasad && !saveasad.closed){saveasad.focus();}
     else{
            var h = document.getElementById('editordiv');
            var ht1 = h.innerHTML;
            var limit=ht1.split("</DIV>")
            document.getElementById('editordivfullhtml').value=h.innerHTML;
            //var limit=document.getElementById('ctrval').value
            for(var b=0; b<= limit.length; b++){
                ht1 = ht1.replace("class=drag", "");
                ht1 = ht1.replace("oncontextmenu=javascript:context_menu(this);","");
                ht1 = ht1.replace("  javascript:showprop(this);","");
                ht1 = ht1.replace("onfocusout=javascript:lostfocus();","")
                ht1 = ht1.replace("onactivate=javascript:getid(this);","");
                ht1 = ht1.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);","");
                ht1 = ht1.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsT();","");
                ht1 = ht1.replace("onresize=javascript:getdimsT();","");
                ht1 = ht1.replace("onmove=javascript:moves();","");
                ht1 = ht1.replace("onkeypress=","");
                ht1 = ht1.replace("javascript:blockkey(event,\'bcd\');","");
                ht1 = ht1.replace("onactivate=javascript:editmode(this);","");
                ht1 = ht1.replace("ondeactivate=javascript:dragmode(this);","");
                ht1 = ht1.replace("onfocus=javascript:getid(this);","");
                ht1 = ht1.replace("onclick=javascript:getid(this);","");
                ht1 = ht1.replace("onresize=javascript:getdimsP();","");
                ht1 = ht1.replace("contentEditable=true","");
                //ht1 = ht1.replace("absolute","relative"); 
                /****************/
//////            document.getElementById('editordivhtml').value=ht1;
//////            for(var temp=0;temp<limit.length-2;temp++){
//////          if(limit[temp]!="")
//////          {
//////             var id1 = limit[temp].split("id=");
//////             var id2 = id1[1].split(" ");/*****ERROR*********/
//////            }
//////            var adhght = document.getElementById('ad_height').value;
//////            var adwdth = document.getElementById('ad_width').value;
//////            document.getElementById('adheight').value = adhght;
//////            document.getElementById('adwidth').value = adwdth;
                /****************/
                
            }
            document.getElementById('editordivhtml').value=ht1;
            //for(var temp=1;temp<limit.length-1;temp++){ 
               for(var temp=0;temp<limit.length-2;temp++){
               if(limit[temp]!="")
               {
            var id1 = limit[temp].split("id=");
            var id2 = id1[1].split(" ");
            }    
            var tempxml = tempxml + "<textbox><dimension><height>" + document.getElementById(id2[0]).style.height + "</height><width>" + document.getElementById(id2[0]).style.width + "</width><xpos>" + document.getElementById(id2[0]).style.left + "</xpos><ypos>" + document.getElementById(id2[0]).style.top + "</ypos></dimension>" + "<border><bordercolor>" + document.getElementById(id2[0]).style.borderColor + "</bordercolor>" + "<borderwidth>" + document.getElementById(id2[0]).style.borderWidth + "</borderwidth><borderstyle>" + document.getElementById(id2[0]).style.borderStyle + "</borderstyle></border><text>" + document.getElementById(id2[0]).innerHTML +"</text><bgcolor>" + document.getElementById(id2[0]).backgroundColor + "</bgcolor><bgimage>" + document.getElementById(id2[0]).style.backgroundImage + "</bgimage></textbox>" ;

                }
            var xmlfile = "<template>" + tempxml + "</template>" ;
            document.getElementById('editordivxml').value=xmlfile;
            saveasad=window.open('saveadas.aspx','saveme1','left=300px,top=300px,width=250px,height=120px,left=275,top=230');
            }
       
       
       }
       function abc()
        {
          document.getElementById('editordivhtml').value=document.getElementById('editordiv').innerHTML;
          saveasdialog = window.open('DefaultPDF.aspx');
        }
//function toggle(v) { $S(v).display=($S(v).display=='none'?'block':'none'); }
/*********** this is code for close editor*********/
function closeme()
  {
    //alert('closeT');
   var browser=navigator.appName;
   if(browser=="Microsoft Internet Explorer")
     {
      this.close();
     }
   else if(browser!="Microsoft Internet Explorer")
    {
      window.close();
       
   }
} 
   
/*************end of function****************/   
function checktag(){
    temp= document.getElementById('tags');
    if(temp.checked==true){
        r1.style.display='block';
        r2.style.display='block';
    }else{
        r1.style.display='none';
        r2.style.display='none';
      
    }
}

/*******************this is code for special tag************************/
    function spltags(){
    if(document.all)
    {
        if(ctr<=100){
            myElement=document.createElement('<div class ="drag" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();" onresize="javascript:getdimsT();" onmove ="javascript:moves();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" style="position:relative;width:10px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;top:105px;left:80px; "></div>');
            var text=document.getElementById('spltxt').value;
            if(document.getElementById('tags').checked==false){
            tagval=text;}
            else
            {
                pre=document.getElementById('tagsprop_prefix').value;
                suff=document.getElementById('tagsprop_DropDownList1').value;
                tagval=pre+text+suff;
            }
        myElement.setAttribute('id',ctr);
        myElement.setAttribute('innerText',tagval);
        editordiv.appendChild(myElement);
        currentid=ctr;
        ctr=ctr+1;
         document.getElementById('spltxt').value="";
        }
    }
    else
    {
    ctr = parseInt(document.getElementById('ctrval').value);
    var cid=ctr+'~'+'tag';
    ctr=parseInt(ctr+1);
     document.getElementById('ctrval').value=ctr;
    //alert(cid);
    var text=document.getElementById('spltxt').value;
           
     pre=document.getElementById('tagsprop_prefix').value;
     suff=document.getElementById('tagsprop_DropDownList1').value;
     if(text.indexOf('.')>=0)
     {
     tagval=pre+text;
     }
     else
     {
     tagval=pre+text+suff;
     }
     
    var mystmt= '<Div id="'+cid+'" class="key-point" contentEditable="true" onkeydown="javascript:return blockpicture(event);" oncontrolselect="javascript:getid(this);" onclick="javascript:getid(this);" onresize="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this,event);" onmove ="javascript:moves();" onactivate="javascript:getid(this);" ondeactivate="javascript:dragmode(this);" style="position:absolute;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;top:105px;left:80px;height:20px; width:80px;">'+tagval+'</Div>';
    //alert(mystmt);
    
    //moves();
            
     //document.getElementById(cid).textContent=tagval;
    document.getElementById('editordiv').childNodes[0].innerHTML+=mystmt;
   // alert(document.getElementById('editordiv').childNodes[0].innerHTML);
  // getid(this);
   
    //currentid=cid;
     document.getElementById('spltxt').value="";
    
    }
    
    }
/****************************/    
    
    
 function toggle()
  {
    var browser= navigator.appName;
    if(browser=="Microsoft Internet Explorer")
     {
        if(document.getElementById('selectmargin').checked)
        {
            document.getElementById('Label3').disabled = false;
            document.getElementById('imgbrdr').disabled = false;
            document.getElementById('Label4').disabled = false;
            document.getElementById('Label5').disabled = false;
            document.getElementById('Label6').disabled = false;
            document.getElementById('Label7').disabled = false;
            document.getElementById('rght').disabled = false;
            document.getElementById('top').disabled = false;
            document.getElementById('left').disabled = false;
            document.getElementById('btm').disabled = false;
        }
        else
        {
            document.getElementById('Label3').disabled = true;
            document.getElementById('imgbrdr').disabled = true;
            document.getElementById('Label4').disabled = true;
            document.getElementById('Label5').disabled = true;
            document.getElementById('Label6').disabled = true;
            document.getElementById('Label7').disabled = true;
            document.getElementById('rght').disabled = true;
            document.getElementById('top').disabled = true;
            document.getElementById('left').disabled = true;
            document.getElementById('btm').disabled = true;
        }
      }
    else if(browser!="Microsoft Internet Explorer")
     {
         if(document.getElementById('selectmargin').checked==true)
          {
            document.getElementById('Label3').disabled = false;
            document.getElementById('imgbrdr').disabled = false;
            document.getElementById('Label4').disabled = false;
            document.getElementById('Label5').disabled = false;
            document.getElementById('Label6').disabled = false;
            document.getElementById('Label7').disabled = false;
            document.getElementById('rght').disabled = false;
            document.getElementById('top').disabled = false;
            document.getElementById('left').disabled = false;
            document.getElementById('btm').disabled = false;
         }
        else
         {
            document.getElementById('Label3').disabled=true;
            document.getElementById('imgbrdr').disabled=true;
            document.getElementById('Label4').disabled=true;
            document.getElementById('Label5').disabled=true;
            document.getElementById('Label6').disabled=true;
            document.getElementById('Label7').disabled=true;
            document.getElementById('rght').disabled=true;
            document.getElementById('top').disabled=true;
            document.getElementById('left').disabled=true;
            document.getElementById('btm').disabled=true;
         }
    }
 }
 
/******************************************************************/ 
 
function uploadimg()
{
      //alert('upload');
        //alert('ajay');
        source=document.getElementById('thumimg').value;
        if(source=="")alert('Please Specify the Image path ?');
        else if(currentid==null)alert('Item not Selected !');
        else if(document.getElementById(currentid)==null)
        //alert('ajay');
        alert('Item not exist !');
        else   document.getElementById(currentid).style.backgroundImage="url("+source+")";
    }
    
/***************************************************/


    var uploadwin;
    function showupload()
      {
            if(document.all)
            {
            //alert('39')
            try {
                if(uploadwin && !uploadwin.closed){uploadwin.focus();}
                else
                {
                    if(document.getElementById('myhdnval').value!="outer")
                    {
                        if(document.getElementById('myhdnval').value.indexOf("text")>=0)
                        {
                           
                                alert('Image not applied without Image Box');
                            return;
                        }
                    else
                    {
                    
                      if(document.getElementById(document.getElementById('myhdnval').value).outerHTML.contains!="textBox")
                          {
                             document.getElementById(document.getElementById('myhdnval').value).outerHTML;
                             //currentid = document.getElementById('current_id').value;
                             var temp_id = document.getElementById('temp_id').value;
                             var str = "fileupload.aspx?currentid="+document.getElementById('myhdnval').value+"&temp_id="+temp_id;
                             uploadwin=window.open(str,'','height=205px,width=440px,top=300,left=200');
                          }
                         else
                          {
                            alert("Image not applied without Image Box");
                          }
                     }
                 }
              }
            }
            catch(err){
            alert('Item not exist !');
            }
            }
            else
            {
             if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
        { 
       // alert(document.getElementById('myhdnval').value);
             if(uploadwin && !uploadwin.closed){uploadwin.focus();}
                else
                {
                //alert(document.getElementById('myhdnval').value)
                    if(document.getElementById('myhdnval').value!="outer")
                    {
                        if(document.getElementById('myhdnval').value.indexOf("text")>=0)
                        {
                         //alert(document.getElementById('myhdnval').value);
                        alert('Image not applied without Image Box');
                        return;
                        }
                    else
                    {
                    //alert("here")
                    //alert(document.getElementById(document.getElementById('myhdnval').value).outerHTML)
                    //alert(document.getElementById(document.getElementById('myhdnval').value).innerHTML)
                    //alert(document.getElementById('myhdnval').value.indexOf("~picture"))
                      if(document.getElementById('myhdnval').value.indexOf("~picture")>=0)
                          {
                            
                             //currentid = document.getElementById('current_id').value;
                             var temp_id = document.getElementById('temp_id').value;
                             var str = "fileupload.aspx?currentid="+document.getElementById('myhdnval').value+"&temp_id="+temp_id;
                             uploadwin=window.open(str,'','height=205px,width=440px,top=300,left=200');
                            }
                            
                         else
                          {
                            alert("Image not applied without Image Box");
                          }
                     }
                }
           }  
           }         
      }
}
/*************************************************************/
 function showupload1()
      {
            if(document.all)
            {
            //alert('39')
            try {
                if(uploadwin && !uploadwin.closed){uploadwin.focus();}
                else
                {
                    if(document.getElementById('myhdnval').value!="outer")
                    {
                        if(document.getElementById('myhdnval').value.indexOf("text")>=0)
                        {
                           
                                alert('Image not applied without Tag Box');
                            return;
                        }
                    else
                    {
                    
                      if(document.getElementById(document.getElementById('myhdnval').value).outerHTML.contains!="textBox")
                          {
                             document.getElementById(document.getElementById('myhdnval').value).outerHTML;
                             //currentid = document.getElementById('current_id').value;
                             var temp_id = document.getElementById('temp_id').value;
                             var str = "fileupload.aspx?currentid="+document.getElementById('myhdnval').value+"&temp_id="+temp_id;
                             uploadwin=window.open(str,'','height=205px,width=440px,top=300,left=200');
                          }
                         else
                          {
                            alert("Image not applied without Tag Box");
                          }
                     }
                 }
              }
            }
            catch(err){
            alert('Item not exist !');
            }
            }
            else
            {
             if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
        { 
       // alert(document.getElementById('myhdnval').value);
             if(uploadwin && !uploadwin.closed){uploadwin.focus();}
                else
                {
                //alert(document.getElementById('myhdnval').value)
                    if(document.getElementById('myhdnval').value!="outer")
                    {
                        if(document.getElementById('myhdnval').value.indexOf("text")>=0)
                        {
                         //alert(document.getElementById('myhdnval').value);
                        alert('Image not applied without Tag Box');
                        return;
                        }
                    else
                    {
                    //alert("here")
                    //alert(document.getElementById(document.getElementById('myhdnval').value).outerHTML)
                    //alert(document.getElementById(document.getElementById('myhdnval').value).innerHTML)
                    //alert(document.getElementById('myhdnval').value.indexOf("~picture"))
                      
                             if(document.getElementById('myhdnval').value.indexOf("~img")>0)
                            {
                             var temp_id = document.getElementById('temp_id').value;
                             var str = "fileupload.aspx?currentid="+document.getElementById('myhdnval').value+"&temp_id="+temp_id;
                             uploadwin=window.open(str,'','height=205px,width=440px,top=300,left=200');
                            
                            }
                         else
                          {
                            alert("Image not applied without Tag Box");
                          }
                     }
                }
           }  
           }         
      }
}
/**************************************************************/
function insertimg(a,foldername,filename,ankur)
   {
  // alert('insert');
    var browser= navigator.appName;
    if(browser=="Microsoft Internet Explorer")
    {
        var aa = a.split(",");
        var currentid = aa[0];
        if(currentid==null){alert('Item not Selected !');}
        var source1 = aa[1];
        if(source1==""){alert('Please specify the Image path ?');}
        for(var i=0; i<aa[2]; i++)
        {
          var source = source1.replace("+","\\");
          source1=source;
        }
        source1= source1.replace("///","\\\\");
        source1= source1.replace("/","\\");
        var rght = aa[9];
        var left = aa[8];
        var imgborder = aa[6]+"px";
        var top = aa[7];
        var btm = aa[5];
        var ftb = aa[10];
       //source1=ankur+foldername + filename;
        
         source1=opener.document.getElementById('txtpathname').value+foldername + filename;
        //source1=document.getElementById('insimage').value+foldername + filename;insertimage
         
    if(ftb=="1")
     {
        //alert(opener.document.getElementById('myhdnval').value)
        if(opener.document.getElementById('myhdnval').value=="")
            {
                opener.document.getElementById(currentid).style.paddingTop = top;
                opener.document.getElementById(currentid).style.paddingLeft = left;
                opener.document.getElementById(currentid).style.paddingRight = rght;
                opener.document.getElementById(currentid).style.paddingBottom = btm;
                var hght = opener.document.getElementById(currentid).style.height;
                var wdth = opener.document.getElementById(currentid).style.width;
                //alert(opener.document.getElementById('myhdnval').value)
           }
          else
            {
                  opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingTop = top;
                  opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingLeft = left;
                  opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingRight = rght;
                  opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingBottom = btm;
                  var hght = opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.height;
                  var wdth = opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.width;
                  // alert(opener.document.getElementById('myhdnval').value)
                  opener.document.getElementById(currentid).innerHTML="<img ondragstart='return false' style='z-index:0;' src="+source1+" height="+hght+" id='image1'  width="+wdth+" height="+hght+" border="+imgborder+" />";
                  //alert(opener.document.getElementById(currentid).innerHTML);
             }
        }
        else
        {
          if(opener.document.getElementById('myhdnval').value=="")
           {
              opener.document.getElementById(currentid).style.paddingTop = top;
              opener.document.getElementById(currentid).style.paddingLeft = left;
              opener.document.getElementById(currentid).style.paddingRight = rght;
              opener.document.getElementById(currentid).style.paddingBottom = btm;
              var hght = opener.document.getElementById(currentid).style.height;
              var wdth = opener.document.getElementById(currentid).style.width;
              opener.document.getElementById(currentid).innerHTML="<img ondragstart='return false' style='z-index:0;' src="+source1+" height="+hght+" id='image1'  width="+wdth+" height="+hght+" border="+imgborder+" />";
           }
           else
            {
                var myresult="";
                opener.document.getElementById(currentid).style.paddingTop = top;
                opener.document.getElementById(currentid).style.paddingLeft = left;
                opener.document.getElementById(currentid).style.paddingRight = rght;
                opener.document.getElementById(currentid).style.paddingBottom = btm;
                // myresult="<img src="+source1+"  id='image1'    border="+imgborder+" />";
                // var theImg = document.getElementById('image1');
                // alert(theImg.width)
                // alert(theImg.height)
                opener.document.getElementById(currentid).innerHTML="<div ondragstart='return false's test'33' style='z-index:0;' ><img src="+source1+"  id='image1'    border="+imgborder+" /></div>";
            }
       }
        window.close();
    }
    
   else if(browser!="Microsoft Internet Explorer")
   {
        
        getdimsP();
        unit=parseInt(opener.document.getElementById('sel_unit').value);
        var aa = a.split(",");
        var currentid = aa[0];
        if(currentid==null){alert('Item not Selected !');}
        var source1 = aa[1];
        if(source1==""){alert('Please specify the Image path ?');}
        for(var i=0; i<aa[2]; i++)
        {
          var source = source1.replace("+","\\");
          source1=source;
         }
        source1= source1.replace("///","\\\\");
        source1= source1.replace("/","\\");
        var rght = aa[9];
        var left = aa[8];
        var imgborder = aa[6]+"px";
        var top = aa[7];
        var btm = aa[5];
        var ftb = aa[10];
       
        var ht=0;
        ht=parseFloat(top)+parseFloat(btm);
        //alert(ht);
        var wt=0;
        wt=parseFloat(rght)+parseFloat(left);
       //alert(wt);
        if(parseFloat(top)>parseFloat(opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.height))
        {
        alert("Value of top margin should not be greater than image box size ");
        document.getElementById('top').value="";
        return false
        } 
         if(parseFloat(btm)>parseFloat(opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.height))
        {
        alert("Value of bottom margin should not be greater than image box size ");
        document.getElementById('btm').value="";
        return false
        } 
         if(parseFloat(rght)>parseFloat(opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.width))
        {
        alert("Value of right margin should not be greater than image box size ");
        document.getElementById('rght').value="";
        return false;
        } 
         if(parseFloat(left)>parseFloat(opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.width))
        {
        alert("Value of left margin should not be greater than image box size ");
        document.getElementById('left').value="";
        return false
        } 
        if(ht>parseFloat(opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.height))
        {
       //alert(
       alert("Value of top margin & bottom margin should not be greater than image box size ");
       document.getElementById('top').value="";
       document.getElementById('btm').value="";
        return false
        }
        if(wt>parseFloat(opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.width))
        {
       //alert(
       alert("Value of right margin & left margin should not be greater than image box size ");
       document.getElementById('left').value="";
       document.getElementById('rght').value="";
        return false
        }
        
        //alert(imgborder);
        //source1=ankur+foldername + filename;
        source1=opener.document.getElementById('txtpathname').value+foldername + filename;
        //source1=document.getElementById('insimage').value+foldername + filename;
       if(ftb=="1")
        {
       if(opener.document.getElementById('myhdnval').value=="")
        {
            opener.document.getElementById(currentid).style.paddingTop = top;
            opener.document.getElementById(currentid).style.paddingLeft = left;
            opener.document.getElementById(currentid).style.paddingRight = rght;
            opener.document.getElementById(currentid).style.paddingBottom = btm;
            var hght = opener.document.getElementById(currentid).style.height;
            var wdth = opener.document.getElementById(currentid).style.width;
            
         }
         else
          {
            if(unit==1)
            {
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingTop = top+"px";
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingLeft = left+"px";
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingRight = rght+"px";
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingBottom = btm+"px";
            }
            if(unit==2)
            {
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingTop = top+"in";
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingLeft = left+"in";
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingRight = rght+"in";
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingBottom = btm+"in";
            }
            if(unit==3)
            {
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingTop = top+"cm";
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingLeft = left+"cm";
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingRight = rght+"cm";
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingBottom = btm+"cm";
            }
            if(unit==4)
            {
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingTop = top+"mm";
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingLeft = left+"mm";
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingRight = rght+"mm";
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingBottom = btm+"mm";
            }
              var hght = opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.height;
             // alert(hght);
              var wdth = opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.width;
              //alert(wdth);
              var cpicid=opener.document.getElementById('myhdnval').value+"pic"
              
              
              //alert(cpicid);
              //alert(opener.document.getElementById('myhdnval').value)
             if(hght.indexOf('px')>=0 && wdth.indexOf('px')>=0  )
             {
              opener.document.getElementById(opener.document.getElementById('myhdnval').value).innerHTML="<img onmousemove='javascript:testmousedown();' onmouseout='javascript:testmousedown();' onmousedown='javascript:testmousedown();' onmouseup='javascript:testmousedown();' oncontextmenu='javascript:menuthis();' id='"+cpicid+"' ondragstart='return false' style='z-index:0;'  src="+source1+"  width="+wdth+" height="+hght+"  border="+imgborder+" />";
             } 
           else
           {
           opener.document.getElementById(opener.document.getElementById('myhdnval').value).innerHTML="<img onmousemove='javascript:testmousedown();' onmouseout='javascript:testmousedown();' onmousedown='javascript:testmousedown();' onmouseup='javascript:testmousedown();' oncontextmenu='javascript:menuthis();' id='"+cpicid+"' ondragstart='return false' style='z-index:0;width:"+wdth+"; height:"+hght+";'  src="+source1+"   border="+imgborder+" />";   
           }
                        
           
             // alert( opener.document.getElementById('pic123').style.size);
              //alert(opener.document.getElementById(opener.document.getElementById('myhdnval').value).innerHTML);
          }
    }
        else
        {
             // alert(opener.document.getElementById('ad_height').value)
            //alert(opener.document.getElementById('myhdnval').value)
          if(opener.document.getElementById('myhdnval').value=="")
            {
                opener.document.getElementById(document.getElementById('myhdnval').value).style.paddingTop = top;
                opener.document.getElementById(document.getElementById('myhdnval').value).style.paddingLeft = left;
                opener.document.getElementById(document.getElementById('myhdnval').value).style.paddingRight = rght;
                opener.document.getElementById(document.getElementById('myhdnval').value).style.paddingBottom = btm;
                var hght = opener.document.getElementById(document.getElementById('myhdnval').value).style.height;
                var wdth = opener.document.getElementById(document.getElementById('myhdnval').value).style.width;
                opener.document.getElementById(document.getElementById('myhdnval').value).innerHTML="<img ondragstart='return false' style='z-index:0;' src="+source1+" height="+hght+" id='image1'width="+wdth+" height="+hght+" border="+imgborder+" />";
             }
          else
            {
                var myresult="";
                opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingTop = top;
                opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingLeft = left;
                opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingRight = rght;
                opener.document.getElementById(opener.document.getElementById('myhdnval').value).style.paddingBottom = btm;
                opener.document.getElementById(opener.document.getElementById('myhdnval').value).innerHTML="<div ondragstart='return false's test'33' style='z-index:0;' ><img src="+source1+"  id='image1' border="+imgborder+" /></div>";
            }
       }
        window.close();
    }
 
 }
/*****************************************/ 
 
 function menuthis()
 {
        
        document.getElementById(document.getElementById('myhdnval').value+"pic").onmousedown=ignoreClick;
	    document.getElementById(document.getElementById('myhdnval').value+"pic").onmouseup=ignoreClick;
	    document.getElementById(document.getElementById('myhdnval').value+"pic").onmouseout=ignoreClick;
 
 
 }
 
 function testmousedown()
 {
 //alert("in mouse down");
 if(document.getElementById(document.getElementById('myhdnval').value+"pic").style.height!="")
 {
     document.getElementById(document.getElementById('myhdnval').value).style.height=document.getElementById(document.getElementById('myhdnval').value+"pic").style.height;
     getdimsP();
   
 }
 if(document.getElementById(document.getElementById('myhdnval').value+"pic").style.width!="")
 {
     document.getElementById(document.getElementById('myhdnval').value).style.width=document.getElementById(document.getElementById('myhdnval').value+"pic").style.width;
     
      //document.getElementById('test_height').value=document.getElementById(document.getElementById('myhdnval').value+"pic").style.height;
     //document.getElementById('test_width').value=document.getElementById(document.getElementById('myhdnval').value+"pic").style.width;
     getdimsP();
 
    
 }
   return;
 }
 
/***********************/
//function atloading(obj)
// {
//    document.getElementById('hiddentxt').value=opener.document.getElementById('previewhtml').value;
//    //alert(document.getElementById('hiddentxt').value);
//    xyz=document.getElementById('hiddentxt').value;
//    //document.getElementById('txtarea12').innerHTML=xyz
//    //document.getElementById('previewme134').contentWindow.document.body.readonly=true
//    document.getElementById('previewme134').outerHTML=xyz//+clientHeight;
// }

//if(document.getElementById('outer').value=="")
//          {
//               
//          }
//         else
//           {}
//            
//            var tmplate =document.getElementById('editordiv').innerHTML;
//            //alert(tmplate);
//            var counter=parseInt(document.getElementById('ctrval').value);
//            counter= counter-1;
//            while(tmplate.indexOf('class="key-point"')>=0)
/****************************/
      var previewdialog1;
    function previewdialog()
    {
    
     if(document.getElementById('outer').value=="")
          {
               
          }
         else
           {}
            var browser=navigator.appName;
       if(browser=="Microsoft Internet Explorer")
        {
            var tmplate =document.getElementById('editordiv').innerHTML;
            //alert(tmplate);
            var counter=parseInt(document.getElementById('ctrval').value);
            counter= counter-1;
            while(tmplate.indexOf("class=drag")>=0)
            {
                tmplate = tmplate.replace("class=drag", "");
            }
            while(tmplate.indexOf("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsT();")>=0)
            {
                tmplate = tmplate.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsT();", "");
            }
            while(tmplate.indexOf("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);")>=0)
            {
                tmplate = tmplate.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);", "");
            }
            while(tmplate.indexOf("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);")>=0)
            {
                tmplate = tmplate.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);", "");
            }
            while(tmplate.indexOf("oncontextmenu=javascript:context_menu(this);")>=0)
            {
                tmplate = tmplate.replace("oncontextmenu=javascript:context_menu(this);", "");
            }
            while(tmplate.indexOf("javascript:showprop(this);")>=0)
            {
                tmplate = tmplate.replace("javascript:showprop(this);", "");
            }
            while(tmplate.indexOf("onfocusout=javascript:lostfocus();")>=0)
            {
                tmplate = tmplate.replace("onfocusout=javascript:lostfocus();", "");
            }
            while(tmplate.indexOf("onactivate=javascript:getid(this);")>=0)
            {
                tmplate = tmplate.replace("onactivate=javascript:getid(this);", "");
            }
            while(tmplate.indexOf("onactivate=javascript:editmode(this);")>=0)
            {
                tmplate = tmplate.replace("onactivate=javascript:editmode(this);", "");
            }
            while(tmplate.indexOf("ondeactivate=javascript:dragmode(this);")>=0)
            {
                tmplate = tmplate.replace("ondeactivate=javascript:dragmode(this);", "");
            }
            while(tmplate.indexOf("onmove=javascript:moves();")>=0)
            {
                tmplate = tmplate.replace("onmove=javascript:moves();", "");
            }
            while(tmplate.indexOf("onkeypress=")>=0)
            {
                tmplate = tmplate.replace("onkeypress=", "");
            }
            
            while(tmplate.indexOf("onresize=javascript:getdimsT();")>=0)
            {
                tmplate = tmplate.replace("onresize=javascript:getdimsT();", "");
            }
            while(tmplate.indexOf("onfocus=javascript:getid(this);")>=0)
            {
              tmplate = tmplate.replace("onfocus=javascript:getid(this);", "");
            }
            while(tmplate.indexOf("onresize=javascript:getdimsP();")>=0)
            {
                tmplate = tmplate.replace("onresize=javascript:getdimsP();", "");
            }
            while(tmplate.indexOf("onresize=javascript:getdimsO();")>=0)
            {
                tmplate = tmplate.replace("onresize=javascript:getdimsO();", "");
            }
            while(tmplate.indexOf("contentEditable=true")>=0)
            {
                tmplate = tmplate.replace("contentEditable=true", "contentEditable=false");
            }
            
           
            
            while(tmplate.indexOf("oncontextmenu=javascript:context_menu(this);")>=0)
            {
                tmplate = tmplate.replace("oncontextmenu=javascript:context_menu(this);", "");
            }
            while(tmplate.indexOf("onmove=javascript:moves();")>=0)
            {
                tmplate = tmplate.replace("onmove=javascript:moves();", "");
            }
            while(tmplate.indexOf("oncontrolselect=javascript:getid(this);")>=0)
            {
                tmplate = tmplate.replace("oncontrolselect=javascript:getid(this);", "");
            }
            while(tmplate.indexOf("javascript:getdimsT();")>=0)
            {
                tmplate = tmplate.replace("javascript:getdimsT();", "");
            }
            while(tmplate.indexOf("onkeypress=\"javascript:blockkey(event,'bcd');\"")>=0)
            {
                tmplate = tmplate.replace("onkeypress=\"javascript:blockkey(event,'bcd');\"", "");
            }
            while(tmplate.indexOf("contentEditable=true")>=0)
            {
                tmplate = tmplate.replace("contentEditable=true", "contentEditable=false");
            }
            while(tmplate.indexOf("onfocusout=javascript:lostfocus();")>=0)
            {
                tmplate = tmplate.replace("onfocusout=javascript:lostfocus();", "");
            }
            while(tmplate.indexOf("onfocus=javascript:getid(this);")>=0)
            {
                tmplate = tmplate.replace("onfocus=javascript:getid(this);", "");
            }
            while(tmplate.indexOf("onclick=javascript:getid(this);")>=0)
            {
                tmplate = tmplate.replace("onclick=javascript:getid(this);", "");
            }
            while(tmplate.indexOf("onfocus=javascript:getid(this);")>=0)
            {
                tmplate = tmplate.replace("onfocus=javascript:getid(this);", "");
            }
            while(tmplate.indexOf("onactivate=javascript:editmode(this);")>=0)
            {
                tmplate = tmplate.replace("onactivate=javascript:editmode(this);", "");
            }
            while(tmplate.indexOf("javascript:showprop(this);")>=0)
            {
                tmplate = tmplate.replace("javascript:showprop(this);", "");
            }
            while(tmplate.indexOf("ondeactivate=javascript:dragmode(this);")>=0)
            {
                tmplate = tmplate.replace("ondeactivate=javascript:dragmode(this);", "");
            }
            while(tmplate.indexOf("\"javascript:blockkey(event,'bcd');\"")>=0)
            {
                tmplate = tmplate.replace("\"javascript:blockkey(event,'bcd');\"", "");
            }
            while(tmplate.indexOf("onmouseup=javascript:up();")>=0)
            {
                tmplate = tmplate.replace("onmouseup=javascript:up();", "");
            }
            while(tmplate.indexOf("class=key-point")>=0)
            {
                tmplate = tmplate.replace("class=key-point", "");
            }
            while(tmplate.indexOf("oncontextmenu=javascript:context_menu(this,event);")>=0)
            {
                tmplate = tmplate.replace("oncontextmenu=javascript:context_menu(this,event);", "");
            }
            
            while(tmplate.indexOf("javascript:up();")>=0)
            {
                tmplate = tmplate.replace("javascript:up();", "");
            }
            
            while(tmplate.indexOf("javascript:moves();")>=0)
            {
                tmplate = tmplate.replace("javascript:moves();", "");
            }
            while(tmplate.indexOf("javascript:abc();")>=0)
            {
                tmplate = tmplate.replace("javascript:abc();", "");
            }
            
            while(tmplate.indexOf("onmousedown=javascript:getid(this);")>=0)
            {
                tmplate = tmplate.replace("onmousedown=javascript:getid(this);", "");
            }
            while(tmplate.indexOf("onkeydown=javascript:deleted();")>=0)
            {
                tmplate = tmplate.replace("onkeydown=javascript:deleted();", "");
            }
            
            while(tmplate.indexOf("\"javascript:blockkey(event,'bcd');\"")>=0)
            {
                tmplate = tmplate.replace("\"javascript:blockkey(event,'bcd');\"", "");
            }
           while(tmplate.indexOf("onactivate=javascript:em(this);")>=0)
            {
                tmplate = tmplate.replace("onactivate=javascript:em(this);", "");
            }
             while(tmplate.indexOf("onclick=javascript:editmode(this);")>=0)
            {
                tmplate = tmplate.replace("onclick=javascript:editmode(this);", "");
            }
    
    ///     if(document.getElementById('outer').value=="")
////          {
////               
////          }
////         else
////           {}
////       //alert('preview');
////       var browser=navigator.appName;
////       if(browser=="Microsoft Internet Explorer")
////        {
////            var tmplate =document.getElementById('editordiv').innerHTML;
////            var counter=parseInt(document.getElementById('ctrval').value);
////            counter= counter-1;
////            while(tmplate.indexOf("class=drag")>=0)
////            {
////                tmplate = tmplate.replace("class=drag", "");
////            }
////            while(tmplate.indexOf("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsT();")>=0)
////            {
////                tmplate = tmplate.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsT();", "");
////            }
////            while(tmplate.indexOf("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);")>=0)
////            {
////                tmplate = tmplate.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);", "");
////            }
////            while(tmplate.indexOf("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);")>=0)
////            {
////                tmplate = tmplate.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);", "");
////            }
////            while(tmplate.indexOf("oncontextmenu=javascript:context_menu(this);")>=0)
////            {
////                tmplate = tmplate.replace("oncontextmenu=javascript:context_menu(this);", "");
////            }
////            while(tmplate.indexOf("javascript:showprop(this);")>=0)
////            {
////                tmplate = tmplate.replace("javascript:showprop(this);", "");
////            }
////            while(tmplate.indexOf("onfocusout=javascript:lostfocus();")>=0)
////            {
////                tmplate = tmplate.replace("onfocusout=javascript:lostfocus();", "");
////            }
////            while(tmplate.indexOf("onactivate=javascript:getid(this);")>=0)
////            {
////                tmplate = tmplate.replace("onactivate=javascript:getid(this);", "");
////            }
////            while(tmplate.indexOf("onactivate=javascript:editmode(this);")>=0)
////            {
////                tmplate = tmplate.replace("onactivate=javascript:editmode(this);", "");
////            }
////            while(tmplate.indexOf("ondeactivate=javascript:dragmode(this);")>=0)
////            {
////                tmplate = tmplate.replace("ondeactivate=javascript:dragmode(this);", "");
////            }
////            while(tmplate.indexOf("onmove=javascript:moves();")>=0)
////            {
////                tmplate = tmplate.replace("onmove=javascript:moves();", "");
////            }
////            while(tmplate.indexOf("onmove=javascript:editdiv();") >=0)
////            {
////             tmplate = tmplate.replace("onmove=javascript:editdiv();","");
////            }
////            while(tmplate.indexOf("onkeypress=")>=0)
////            {
////                tmplate = tmplate.replace("onkeypress=", "");
////            }
//////            while(tmplate.indexOf(" javascript:getdimsP();") >=0);
//////              {
//////                tmplate = tmplate.replace("javascript:getdimsP();","");
//////              }
////            while(tmplate.indexOf("onresize=javascript:getdimsT();")>=0)
////            {
////                tmplate = tmplate.replace("onresize=javascript:getdimsT();", "");
////            }
////            while(tmplate.indexOf("onfocus=javascript:getid(this);")>=0)
////            {
////              tmplate = tmplate.replace("onfocus=javascript:getid(this);", "");
////            }
////            while(tmplate.indexOf("onresize=javascript:getdimsP();")>=0)
////            {
////                tmplate = tmplate.replace("onresize=javascript:getdimsP();", "");
////            }
////            while(tmplate.indexOf("onresize=javascript:getdimsO();")>=0)
////            {
////                tmplate = tmplate.replace("onresize=javascript:getdimsO();", "");
////            }
////            while(tmplate.indexOf("contentEditable=true")>=0)
////            {
////                tmplate = tmplate.replace("contentEditable=true", "contentEditable=false");
////            }
////            
////            while(tmplate.indexOf("oncontextmenu=javascript:context_menu(this);")>=0)
////            {
////                tmplate = tmplate.replace("oncontextmenu=javascript:context_menu(this);", "");
////            }
////            while(tmplate.indexOf("onmove=javascript:moves();")>=0)
////            {
////                tmplate = tmplate.replace("onmove=javascript:moves();", "");
////            }
////            while(tmplate.indexOf("oncontrolselect=javascript:getid(this);")>=0)
////            {
////                tmplate = tmplate.replace("oncontrolselect=javascript:getid(this);", "");
////            }
////            while(tmplate.indexOf("javascript:getdimsT();")>=0)
////            {
////                tmplate = tmplate.replace("javascript:getdimsT();", "");
////            }
////            while(tmplate.indexOf("onkeypress=\"javascript:blockkey(event,'bcd');\"")>=0)
////            {
////                tmplate = tmplate.replace("onkeypress=\"javascript:blockkey(event,'bcd');\"", "");
////            }
////            while(tmplate.indexOf("contentEditable=true")>=0)
////            {
////                tmplate = tmplate.replace("contentEditable=true", "contentEditable=false");
////            }
////            while(tmplate.indexOf("onfocusout=javascript:lostfocus();")>=0)
////            {
////                tmplate = tmplate.replace("onfocusout=javascript:lostfocus();", "");
////            }
////            while(tmplate.indexOf("onfocus=javascript:getid(this);")>=0)
////            {
////                tmplate = tmplate.replace("onfocus=javascript:getid(this);", "");
////            }
////            while(tmplate.indexOf("onclick=javascript:getid(this);")>=0)
////            {
////                tmplate = tmplate.replace("onclick=javascript:getid(this);", "");
////            }
////            while(tmplate.indexOf("onfocus=javascript:getid(this);")>=0)
////            {
////                tmplate = tmplate.replace("onfocus=javascript:getid(this);", "");
////            }
////            while(tmplate.indexOf("onactivate=javascript:editmode(this);")>=0)
////            {
////                tmplate = tmplate.replace("onactivate=javascript:editmode(this);", "");
////            }
////            while(tmplate.indexOf("javascript:showprop(this);")>=0)
////            {
////                tmplate = tmplate.replace("javascript:showprop(this);", "");
////            }
////            while(tmplate.indexOf("ondeactivate=javascript:dragmode(this);")>=0)
////            {
////                tmplate = tmplate.replace("ondeactivate=javascript:dragmode(this);", "");
////            }
////            while(tmplate.indexOf("\"javascript:blockkey(event,'bcd');\"")>=0)
////            {
////                tmplate = tmplate.replace("\"javascript:blockkey(event,'bcd');\"", "");
////            }
////            while(tmplate.indexOf("onmouseup=javascript:up();")>=0)
////            {
////                tmplate = tmplate.replace("onmouseup=javascript:up();", "");
////            }
////            while(tmplate.indexOf("class=key-point")>=0)
////            {
////                tmplate = tmplate.replace("class=key-point", "");
////            }
////            while(tmplate.indexOf("oncontextmenu=javascript:context_menu(this,event);")>=0)
////            {
////                tmplate = tmplate.replace("oncontextmenu=javascript:context_menu(this,event);", "");
////            }
////            
////            while(tmplate.indexOf("javascript:up();")>=0)
////            {
////                tmplate = tmplate.replace("javascript:up();", "");
////            }
////            
////            while(tmplate.indexOf("javascript:moves();")>=0)
////            {
////                tmplate = tmplate.replace("javascript:moves();", "");
////            }
////            while(tmplate.indexOf("javascript:abc();")>=0)
////            {
////                tmplate = tmplate.replace("javascript:abc();", "");
////            }
////            
////            while(tmplate.indexOf("onmousedown=javascript:getid(this);")>=0)
////            {
////                tmplate = tmplate.replace("onmousedown=javascript:getid(this);", "");
////            }
////            while(tmplate.indexOf("onkeydown=javascript:deleted();")>=0)
////            {
////                tmplate = tmplate.replace("onkeydown=javascript:deleted();", "");
////            }
////            
////            while(tmplate.indexOf("\"javascript:blockkey(event,'bcd');\"")>=0)
////            {
////                tmplate = tmplate.replace("\"javascript:blockkey(event,'bcd');\"", "");
////            }
////           while(tmplate.indexOf("onactivate=javascript:em(this);")>=0)
////            {
////                tmplate = tmplate.replace("onactivate=javascript:em(this);", "");
////            }
////             while(tmplate.indexOf("onclick=javascript:editmode(this);")>=0)
////            {
////                tmplate = tmplate.replace("onclick=javascript:editmode(this);", "");
////            }
           document.getElementById('previewhtml').value=tmplate;
           previewdialog1= window.open('preview.aspx','','left=50px,top=50px,height=530px,width=830px,scrollbars=yes');//dialogLeft:800px;dialogHeight:200px;dialogWidth:230px;
           
        } 
      else if(browser!="Microsoft Internet Explorer") 
      {
        //alert('hello');
        if(document.getElementById('outer').value=="")
          {
               
          }
         else
           {}
            
            var tmplate =document.getElementById('editordiv').innerHTML;
            //alert(tmplate);
            var counter=parseInt(document.getElementById('ctrval').value);
            counter= counter-1;
            while(tmplate.indexOf('class="key-point"')>=0)
            {
                tmplate = tmplate.replace('class="key-point"', "");
            }
            while(tmplate.indexOf("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsT();")>=0)
            {
                tmplate = tmplate.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsT();", "");
            }
            while(tmplate.indexOf("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);")>=0)
            {
                tmplate = tmplate.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);", "");
            }
            while(tmplate.indexOf("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);")>=0)
            {
                tmplate = tmplate.replace("oncontrolselect=javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);", "");
            }
            while(tmplate.indexOf("oncontextmenu=javascript:context_menu(this);")>=0)
            {
                tmplate = tmplate.replace("oncontextmenu=javascript:context_menu(this);", "");
            }
            while(tmplate.indexOf("javascript:showprop(this);")>=0)
            {
                tmplate = tmplate.replace("javascript:showprop(this);", "");
            }
            while(tmplate.indexOf("onfocusout=javascript:lostfocus();")>=0)
            {
                tmplate = tmplate.replace("onfocusout=javascript:lostfocus();", "");
            }
            while(tmplate.indexOf("onactivate=javascript:getid(this);")>=0)
            {
                tmplate = tmplate.replace("onactivate=javascript:getid(this);", "");
            }
            while(tmplate.indexOf("onactivate=javascript:editmode(this);")>=0)
            {
                tmplate = tmplate.replace("onactivate=javascript:editmode(this);", "");
            }
            while(tmplate.indexOf("ondeactivate=javascript:dragmode(this);")>=0)
            {
                tmplate = tmplate.replace("ondeactivate=javascript:dragmode(this);", "");
            }
            while(tmplate.indexOf("onmove=javascript:moves();")>=0)
            {
                tmplate = tmplate.replace("onmove=javascript:moves();", "");
            }
            while(tmplate.indexOf("onkeypress=")>=0)
            {
                tmplate = tmplate.replace("onkeypress=", "");
            }
            
            while(tmplate.indexOf("onresize=javascript:getdimsT();")>=0)
            {
                tmplate = tmplate.replace("onresize=javascript:getdimsT();", "");
            }
            while(tmplate.indexOf("onfocus=javascript:getid(this);")>=0)
            {
              tmplate = tmplate.replace("onfocus=javascript:getid(this);", "");
            }
            while(tmplate.indexOf("onresize=javascript:getdimsP();")>=0)
            {
                tmplate = tmplate.replace("onresize=javascript:getdimsP();", "");
            }
            while(tmplate.indexOf("onresize=javascript:getdimsO();")>=0)
            {
                tmplate = tmplate.replace("onresize=javascript:getdimsO();", "");
            }
            while(tmplate.indexOf("contentEditable=true")>=0)
            {
                tmplate = tmplate.replace("contentEditable=true", "contentEditable=false");
            }
            while(tmplate.indexOf("oncontextmenu=javascript:context_menu(this);")>=0)
            {
                tmplate = tmplate.replace("oncontextmenu=javascript:context_menu(this);", "");
            }
            while(tmplate.indexOf("onmove=javascript:moves();")>=0)
            {
                tmplate = tmplate.replace("onmove=javascript:moves();", "");
            }
            while(tmplate.indexOf("oncontrolselect=javascript:getid(this);")>=0)
            {
                tmplate = tmplate.replace("oncontrolselect=javascript:getid(this);", "");
            }
            while(tmplate.indexOf("javascript:getdimsT();")>=0)
            {
                tmplate = tmplate.replace("javascript:getdimsT();", "");
            }
            while(tmplate.indexOf("onkeypress=\"javascript:blockkey(event,'bcd');\"")>=0)
            {
                tmplate = tmplate.replace("onkeypress=\"javascript:blockkey(event,'bcd');\"", "");
            }
            while(tmplate.indexOf("contentEditable=true")>=0)
            {
                tmplate = tmplate.replace("contentEditable=true", "contentEditable=false");
            }
            while(tmplate.indexOf("onfocusout=javascript:lostfocus();")>=0)
            {
                tmplate = tmplate.replace("onfocusout=javascript:lostfocus();", "");
            }
            while(tmplate.indexOf("onfocus=javascript:getid(this);")>=0)
            {
                tmplate = tmplate.replace("onfocus=javascript:getid(this);", "");
            }
            while(tmplate.indexOf("onclick=javascript:getid(this);")>=0)
            {
                tmplate = tmplate.replace("onclick=javascript:getid(this);", "");
            }
            while(tmplate.indexOf("onfocus=javascript:getid(this);")>=0)
            {
                tmplate = tmplate.replace("onfocus=javascript:getid(this);", "");
            }
            while(tmplate.indexOf("onactivate=javascript:editmode(this);")>=0)
            {
                tmplate = tmplate.replace("onactivate=javascript:editmode(this);", "");
            }
            while(tmplate.indexOf("javascript:showprop(this);")>=0)
            {
                tmplate = tmplate.replace("javascript:showprop(this);", "");
            }
            while(tmplate.indexOf("ondeactivate=javascript:dragmode(this);")>=0)
            {
                tmplate = tmplate.replace("ondeactivate=javascript:dragmode(this);", "");
            }
            while(tmplate.indexOf("\"javascript:blockkey(event,'bcd');\"")>=0)
            {
                tmplate = tmplate.replace("\"javascript:blockkey(event,'bcd');\"", "");
            }
            while(tmplate.indexOf("onmouseup=javascript:up();")>=0)
            {
                tmplate = tmplate.replace("onmouseup=javascript:up();", "");
            }
            while(tmplate.indexOf("class=key-point")>=0)
            {
                tmplate = tmplate.replace("class=key-point", "");
            }
            while(tmplate.indexOf("oncontextmenu=javascript:context_menu(this,event);")>=0)
            {
                tmplate = tmplate.replace("oncontextmenu=javascript:context_menu(this,event);", "");
            }
            
            while(tmplate.indexOf("javascript:up();")>=0)
            {
                tmplate = tmplate.replace("javascript:up();", "");
            }
            
            while(tmplate.indexOf("javascript:moves();")>=0)
            {
                tmplate = tmplate.replace("javascript:moves();", "");
            }
            while(tmplate.indexOf("javascript:abc();")>=0)
            {
                tmplate = tmplate.replace("javascript:abc();", "");
            }
            
            while(tmplate.indexOf("onmousedown=javascript:getid(this);")>=0)
            {
                tmplate = tmplate.replace("onmousedown=javascript:getid(this);", "");
            }
            while(tmplate.indexOf("onkeydown=javascript:deleted();")>=0)
            {
                tmplate = tmplate.replace("onkeydown=javascript:deleted();", "");
            }
            
            while(tmplate.indexOf("\"javascript:blockkey(event,'bcd');\"")>=0)
            {
                tmplate = tmplate.replace("\"javascript:blockkey(event,'bcd');\"", "");
            }
           while(tmplate.indexOf("onactivate=javascript:em(this);")>=0)
            {
                tmplate = tmplate.replace("onactivate=javascript:em(this);", "");
            }
             while(tmplate.indexOf("onclick=javascript:editmode(this);")>=0)
            {
                tmplate = tmplate.replace("onclick=javascript:editmode(this);", "");
            }
           document.getElementById('previewhtml').value=tmplate;
           //alert(tmplate);
           previewdialog1= window.open('preview.aspx','','left=50px,top=50px,height=530px,width=830px,scrollbars=yes');//dialogLeft:800px;dialogHeight:200px;dialogWidth:230px;
         }      
    }
     
    /*************************************************/
    function atloading(obj)
     {
     var browser=navigator.appName;
     if(browser==" Microsoft Internet Explorer")
      {
        document.getElementById('hiddentxt').value=opener.document.getElementById('previewhtml').value;
        //alert(document.getElementById('hiddentxt').value);
        xyz=document.getElementById('hiddentxt').value;
        document.getElementById('previewme134').outerHTML = xyz;
        //previewme.document.body.innerHTML=xyz;
       }
     else if(browser!=" Microsoft Internet Explorer")
      {
         //alert('ajayp');
        //alert(innerHTML);
         document.getElementById('hiddentxt').value=opener.document.getElementById('previewhtml').value;
         //alert(document.getElementById('hiddentxt').value);
         xyz=document.getElementById('hiddentxt').value;
         var abc1=xyz;
         while(xyz.indexOf('contenteditable="true"')>=0)
         {
         xyz=xyz.replace('contenteditable="true"','contenteditable="false"');
         }
         //alert(xyz);
         document.getElementById('previewme134').innerHTML = xyz;
      }
    }

/*************************************preview dialog***********************/
   
function printme(){previewdialog();}
//function printme()

function printas()
{
 //alert('print');
  var browser=navigator.appName;
  if(browser=="Microsoft Internet Explorer")
  {
      document.getElementById('printme').style.visibility="hidden";
      document.getElementById('cancelme').style.visibility="hidden";
      document.getElementById('previewme134').style.borderColor='white';
      var coll = document.all.tags("Span");
      for (var i=0; i<coll.length; i++)
      {
       coll(i).style.display = "none";
      }
      document.getElementById('printme').style.visibility="visible";
      document.getElementById('cancelme').style.visibility="visible";
      document.getElementById('previewme134').style.borderColor='black';
      window.print();
      window.close()
   }
   else if(browser!="Microsoft Internet Explorer")
   {
      document.getElementById('printme').style.visibility="hidden";
      document.getElementById('cancelme').style.visibility="hidden";
      document.getElementById('previewme134').style.borderColor='white';
      window.print();
      window.close();
   }
 }  
/***********************this is code for print**********/
function printasajay()
{
 var tmplate =document.getElementById('editordiv').innerHTML;
  window.print();
 //window.location.reload();
}

/********************************/

function newdocument(obj)
{
     if(document.all)
     {
        if(currentid==null){
            alert("Please select a template");
            document.getElementById('newdialog').style.display='block';
    
        }
        else if(currentid=="img1")
         {
         //alert("hello");
           document.getElementById('newdialog').style.display='none'; 
         document.getElementById('popups').style.display="block";
         document.getElementById('measuredialog').style.display='block';
         
        
         }
         else
         {
           document.getElementById('newdialog').style.display='none'; 
         create();
         }
     
     
     }
     else
     {
     //alert(currentid);
        if(currentid==null){
            alert("Please select a template");
           document.getElementById('newdialog').style.display='block';
    
          }
        else if(currentid=="i1")
         {
           document.getElementById('newdialog').style.display='none'; 
           document.getElementById('popups').style.display="block";
           document.getElementById('measuredialog').style.display='block';
            document.getElementById('savesT').onclick=null;
    document.getElementById('savesT').style.cursor="pointer";
    document.getElementById('applylink').style.visibility="hidden";
     document.getElementById('imgToolMenu').style.visibility="hidden";
    // document.getElementById('editordiv').innerHTML="";
         }
         else
         {
           document.getElementById('newdialog').style.display='none'; 
            
         create();
         document.getElementById('savesT').onclick=null;
    document.getElementById('savesT').style.cursor="pointer";
    document.getElementById('applylink').style.visibility="hidden";
     document.getElementById('imgToolMenu').style.visibility="hidden";
     //document.getElementById('editordiv').innerHTML="";
         }
    }
  
}

function changeunits()
{
    var unit = document.getElementById('units').value;
    document.getElementById('sel_unit').value=unit;
    document.getElementById('wdthTemp').value=conversion(662,unit);
    document.getElementById('hghtTemp').value=conversion(330,unit);
    //document.getElementById('gutter').value=conversion(15,unit);
}

/*********************************************/
function numeric(e)
			{
				var iKeyCode = 0;
				if (window.event)
				{
				iKeyCode = window.event.keyCode
				}
				else if (e)
				{
				iKeyCode = e.which;
				}
				if ((iKeyCode >= 48 && iKeyCode <= 57) || (iKeyCode==8 || iKeyCode==0 ||iKeyCode==13 ||iKeyCode==46  ))
				{
				return true
				}
				else
				{
				 // alert('Please enter only numeric value');
				  return false;
				}
			}

/**********************************************/


function checkvalue()
{
    try{
    
        if(document.getElementById('UOMnew_if_column').checked){
            document.getElementById('colmns').style.visibility='visible';
            //document.getElementById('gutter').style.visibility='visible';
            //document.getElementById('UOMnew_Label5').style.visibility='visible';
            document.getElementById('colmns').focus();
            //document.getElementById('UOMnew_if_width').checked='false';
            document.getElementById('wdthTemp').style.visibility='hidden';
            document.getElementById('wdthTemp').value="";
        }else if(document.getElementById('UOMnew_if_width').checked){
            document.getElementById('colmns').style.visibility='hidden';
            //document.getElementById('gutter').style.visibility='hidden';
            //document.getElementById('UOMnew_Label5').style.visibility='hidden';
            document.getElementById('wdthTemp').style.visibility='visible';
            document.getElementById('wdthTemp').value=662;
            document.getElementById('wdthTemp').focus();
            //document.getElementById('UOMnew_if_column').checked='false';
        }
        }
        catch(er)
        {
        alert("Error : Occurred !!");
        }
}

/*************test create function*************************/
function create()
{
 var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
    {
      if(currentid=="i1")
        {
          createnew1();
        }
     if(currentid=="i2")
        {
         createnew2();
        }
        //alert(currentid)
    if(currentid=="i3")
        {
           createnew3();
        }
    if(currentid=="i4")
        {
            createnew4();
        }
        //alert(currentid)
    if(currentid=="i5")
        {
            createnew5();
        }
  }

else if (browser=="Microsoft Internet Explorer") 
  {
        if(currentid=="img1")
            {
                createnew1();
            }
        if(currentid=="img2")
            {
                createnew2();
            }
        if(currentid=="img3")
            {
                createnew3();
            }
        if(currentid=="img4")
            {
                createnew4();
            }
        if(currentid=="img5")
            {
                createnew5();
            }
   }


}
 

function createnew1()
{
     var browser=navigator.appName;
     if(browser!="Microsoft Internet Explorer")
      {
         document.getElementById('savehidden').value=="";
        //document.getElementById('colorcodeT_B').disabled="true";
       //alert(document.getElementById('editordiv').innerHTML)
   //if(document.getElementById('editordiv').innerHTML!="")// && currentid==null)
   if(document.getElementById('editordiv').innerHTML.indexOf('<div')!=0 && currentid=='i1')
    {
        Clear();
        currentid = null;
        document.getElementById('colorcodeT_B').disabled="true";
        
       // document.getElementById('fcolor').disabled="true";
        //document.getElementById('linedialog').style.display='none';
        var i = 1;
        unit = document.getElementById('units').value;
        document.getElementById('sel_unit').value=unit;
        if(document.getElementById('hghtTemp').value!="")
        {
            document.getElementById('ad_height').value=document.getElementById('hghtTemp').value;
//            if(document.getElementById('UOMnew_if_width').checked)
//            {
                if(document.getElementById('wdthTemp').value!="")
                {
                    var width =document.getElementById('wdthTemp').value;
                    document.getElementById('ad_width').value=width;
                    width=r_conversion(width,unit);
                    
                    generate_div(width);
                }
                else
                {
                    alert('Please specify the Width !');
                    document.getElementById('wdthTemp').focus();
                }
//            }
//            else if(document.getElementById('UOMnew_if_column').checked)
//            {
//                if(document.getElementById('colmns').value!="")
//                {
//                    //if( document.getElementById('gutter').value!="")
//                    //{
//                        var columns=document.getElementById('colmns').value;
//                       // document.getElementById('linedialog').style.display='none';
//                        //var gutter=document.getElementById('gutter').value;
//                        //gutter=r_conversion(gutter,unit);
//                        
//                        width=114;
//                        newwidth = conversion(width,unit);
//                        document.getElementById('ad_width').value=newwidth;
//                        width=width*columns;
//                        if(columns>1)
//                        {
//                          width=parseInt(width)+(18*(columns-1));
//                        }
//                        generate_div(width);
//                        document.getElementById('ad_width').value = width;
//                    //}
////                    else
////                    {
////                        alert('Please specify Gutter!');
////                        document.getElementById('gutter').focus();
////                     }
//                  }  
//                  else
//                  { 
//                     alert('Please specify Number of Columns!');
//                     document.getElementById('colmns').focus();
//                   }
//              }
         } 
         else
         {
            alert('Please specify the height !');
            document.getElementById('hghtTemp').focus();
        }
        
    }
    else
    {
      closediv();
    }
       document.getElementById('selected_name').value = "Untitled Template"
       //document.getElementById('linedialog').style.display='none';
        document.getElementById('editordiv').disabled=false;
       document.getElementById('editordiv').focus();
}
else if (browser=="Microsoft Internet Explorer") 
  {
   document.getElementById('savehidden').value=="";
  //document.getElementById('colorcodeT_B').disabled="true";
    if(document.getElementById('editordiv').innerHTML=="" && currentid!=null)
    {
        Clear();
        //currentid = null;
        document.getElementById('colorcodeT_B').disabled="true";
       // document.getElementById('fcolor').disabled="true";
        //document.getElementById('linedialog').style.display='none';
        var i = 1;
        unit = document.getElementById('units').value;
        document.getElementById('sel_unit').value=unit;
        if(document.getElementById('hghtTemp').value!="")
        {
            document.getElementById('ad_height').value=document.getElementById('hghtTemp').value;
//            if(document.getElementById('UOMnew_if_width').checked)
//            {
                if(document.getElementById('wdthTemp').value!="")
                {
                    var width =document.getElementById('wdthTemp').value;
                    document.getElementById('ad_width').value=width;
                    width=r_conversion(width,unit);
                    
                    generate_div(width);
                }
                else
                {
                    alert('Please specify the Width !');
                    document.getElementById('wdthTemp').focus();
                }
//            }
//            else if(document.getElementById('UOMnew_if_column').checked)
//            {
//                if(document.getElementById('colmns').value!="")
//                {
//                    //if( document.getElementById('gutter').value!="")
//                    //{
//                        var columns=document.getElementById('colmns').value;
//                       // document.getElementById('linedialog').style.display='none';
//                        //var gutter=document.getElementById('gutter').value;
//                        //gutter=r_conversion(gutter,unit);
//                        
//                        width=114;
//                        newwidth = conversion(width,unit);
//                        document.getElementById('ad_width').value=newwidth;
//                        width=width*columns;
//                        if(columns>1)
//                        {
//                            width=parseInt(width)+(18*(columns-1));
//                        }
//                        generate_div(width);
//                        document.getElementById('ad_width').value = width;
//                    //}
////                    else
////                    {
////                        alert('Please specify Gutter!');
////                        document.getElementById('gutter').focus();
////                     }
//                  }  
//                  else
//                  { 
//                    alert('Please specify Number of Columns!');
//                    document.getElementById('colmns').focus();
//                  }
//               }
         } 
         else
         {
            alert('Please specify the height !');
            document.getElementById('hghtTemp').focus();
        }
        
    }
    else
    {
        closediv();
    }
        document.getElementById('selected_name').value = "Untitled Template"
        //document.getElementById('linedialog').style.display='none';
        document.getElementById('editordiv').disabled=false;
        document.getElementById('editordiv').focus();
  }
  
  }
  
//}

/****************************end of function create1*********************/
            
function generate_div(width)
  {
    
     var browser=navigator.appName;
     if(browser!="Microsoft Internet Explorer")
      {
        var height=document.getElementById('hghtTemp').value;
        height=r_conversion(height,unit);
        if(document.getElementById('portrait').checked ==true)
        {
            var temp= height;
            height = width;
            width = temp;
        }
       
          temp_html='<div  class="key-point" id ="outer" align=left name="textBox"  oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();" onresize ="javascript:getdimsT();"  onmove ="javascript:moves();" onactivate="javascript:getid(this);" onkeypress="javascript:blockkey(event,\'abc\');" style="font-family:Arial;font-size:12px;font-style:normal; position:absolute; top:15px; left:10px; width:'+width+'px; height:'+height+'px; border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid"></div>';
          document.getElementById('editordiv').innerHTML=temp_html;
            
          enabled();
          ad_template=0;
          template_ads();
           document.getElementById('toolsbox_fcolor').disabled="disabled"; 
          if(unit==1)document.getElementById('sel_unit_disp').value="Pixel";
          else if(unit==2)document.getElementById('sel_unit_disp').value="Inches";
          else if(unit==3)document.getElementById('sel_unit_disp').value="CM";
          else if(unit==4)document.getElementById('sel_unit_disp').value="MM";
          document.getElementById('measuredialog').style.display='none'; 
     }
 else if (browser=="Microsoft Internet Explorer") 
  {
        var height=document.getElementById('hghtTemp').value;
        height=r_conversion(height,unit);
        if(document.getElementById('portrait').checked ==true)
        {
        
            var temp= height;
            height = width;
            width = temp;
        }
          temp_html='<div id ="outer" align=left name="textBox"  oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:editdiv();" onactivate="javascript:getid(this);" onkeypress="javascript:blockkey(event,\'abc\');" style="font-family:Arial;font-size:12px;font-style:normal; position:absolute; top:15px; left:10px; width:'+width+'px; height:'+height+'px; border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid"></div>';
          document.getElementById('editordiv').innerHTML= temp_html;
          enabled();
          ad_template=0;
          template_ads();
          if(unit==1)document.getElementById('sel_unit_disp').value="Pixel";
          else if(unit==2)document.getElementById('sel_unit_disp').value="Inches";
          else if(unit==3)document.getElementById('sel_unit_disp').value="CM";
          else if(unit==4)document.getElementById('sel_unit_disp').value="MM";
          document.getElementById('measuredialog').style.display='none'; 
     }
  
  
  }
  
  function editdiv()
     {
     if(document.all)
     {
        //alert("Cannot move");
        document.getElementById(document.getElementById('myhdnval').value).style.left="10px";
        document.getElementById(document.getElementById('myhdnval').value).style.top="15px";
     }
     }
  
/************************************************************/        
function createnew2()
    {
     var browser=navigator.appName;
     if(browser!="Microsoft Internet Explorer")
     {
     
       //alert(document.getElementById('editordiv').innerHTML);
       //alert(document.getElementById(currentid).value);
       //if(document.getElementById('editordiv').innerHTML=="" || document.getElementById('myhdnval').value!=null)
      // alert(document.getElementById('editordiv').innerHTML);
      // alert(currentid)
       //if(document.getElementById('editordiv').innerHTML=="")// || currentid!= null)// || document.getElementById('myhdnval').value!=null)
          //if(document.getElementById('editordiv').innerHTML=="")// || document.getElementById('editordiv').innerHTML!="") 
          if((document.getElementById('editordiv').innerHTML.indexOf('<div')!=0 || document.getElementById('savehidden').value!="") && currentid=='i2')
            {
                document.getElementById('sel_unit_disp').value="Pixel";
                document.getElementById('sel_unit').value="1";
                currentid=null;
                document.getElementById('editordiv').innerHTML='<div id ="outer" align=left name="textBox" onresize="javascript:getdimsO();" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();" onactivate="javascript:getid(this);" onkeypress="javascript:blockkey(event,\'bcd\');" style="font-family:Arial;font-size:12px;font-style:normal; position:absolute; top:15px; left:10px; width:662px; height:332px; border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid"></div>' 
                document.getElementById('editordiv').childNodes[0].innerHTML+='<DIV class="key-point" id="2~picture" ondragstart="return false"  onkeydown="javascript:return blockpicture(event);"  oncontrolselect="javascript:getid(this);javascript:showprop(this);javascript:moves();" onresize="javascript:getdimsP();" oncontextmenu="javascript:context_menu(this,event);" onmove ="javascript:moves();javascript:up();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onmouseup="javascript:up();" onmousedown="javascript:getid(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);" contenteditable="true" style="position:absolute;width:105px; left:10px;top:5px; height:100px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;background-image:url(icons/logo.jpg);"></div>'
                //document.getElementById('editordiv').childNodes[0].innerHTML+='<div id =picture oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true"  style="position:absolute;width:105px; left:20px;top:20px; height:100px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;background-image:url(icons/logo.jpg);"></div>'
                document.getElementById('editordiv').childNodes[0].innerHTML+='<DIV class="key-point" id="1~text" onmouseup=javascript:up(); ondragstart="return false" oncontextmenu=javascript:context_menu(this,event); onactivate=javascript:editmode(this); onmove=javascript:moves();javascript:up(); oncontrolselect=javascript:getid(this);javascript:moves();javascript:showprop(this); onkeypress="javascript:abc();" onmousedown=javascript:getid(this);  onkeyup=javascript:abc(); onresize=javascript:getdimsT(); contentEditable=true style="z-index:0;background-color:#999999;color:Black;font-family:Arial;font-size:12px;font-style:normal;line-height:15px;position:absolute;word-wrap:break-word;padding-top:2px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;left:5px; top:110px; width:650px; height:210px;"  ondeactivate=javascript:dragmode(this); onfocus=javascript:getid(this); onclick=javascript:editmode(this); align=center name=" textBox">Click to add text</DIV>'
               // document.getElementById('editordiv').childNodes[0].innerHTML+='<div id =Txt1  oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" ></div>';
                document.getElementById('ctrval').value=4;
                enabled();
                document.getElementById('ad_height').value=330
                document.getElementById('ad_width').value=660;
                document.getElementById('measuredialog').style.display='none';

              }
            else
             {
               closediv();
             }
       }
     else if(browser=="Microsoft Internet Explorer")
     {
        if(document.getElementById('editordiv').innerHTML=="")
            {
                document.getElementById('sel_unit_disp').value="Pixel";
                document.getElementById('sel_unit').value="1";
                currentid=null;
                document.getElementById('editordiv').innerHTML='<div id ="outer" align=left name="textBox" onresize="javascript:getdimsO();" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();" onactivate="javascript:getid(this);" onkeypress="javascript:blockkey(event,\'bcd\');" style="font-family:Arial;font-size:12px;font-style:normal; position:absolute; top:15px; left:10px; width:662px; height:332px; border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid"></div>' 
                document.getElementById('editordiv').innerHTML+='<div id =picture oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true"  style="position:absolute;width:105px; left:20px;top:20px; height:100px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;background-image:url(icons/logo.jpg);"></div>'
                document.getElementById('editordiv').innerHTML+='<div id =Txt1  oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" style="z-index:0;background-color:#999999;color:Black;font-family:Arial;font-size:12px;font-style:normal;line-height:15px;position:absolute;word-wrap:break-word;padding-top:2px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;left:20px; top:125px; width:650px; height:210px;"></div>';
                document.getElementById('ctrval').value=4;
                enabled();
                document.getElementById('ad_height').value=330
                document.getElementById('ad_width').value=660;
                document.getElementById('measuredialog').style.display='none';
              }
            else
             {
                closediv();
             }
     }
     
   }    
             
//function createnew3(){
//            closeme();
//            window.opener.editordiv.innerHTML='<div id ="outer" oncontrolselect="javascript:getid(this);" onmove ="javascript:moves();" onresize="javascript:getdimsT();" onactivate="javascript:getid(this);" onkeypress="javascript:blockkey(event,\'bcd\');" style=" position:absolute; top:15px; left:15px; width:662px; height:330px; border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid"></div> <div id =leftD oncontrolselect="javascript:getid(this);" onmove ="javascript:moves();" onresize="javascript:getdimsT();" onactivate="javascript:getid(this);" onkeypress="javascript:blockkey(event,\'bcd\');" style=" position:absolute; left:25px; top:20px; width:195px; height:200px; border-bottom: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-right: black 1px solid"></div> <div id =rghtD oncontrolselect="javascript:getid(this);" onmove ="javascript:moves();" onresize="javascript:getdimsT();" onkeypress="javascript:blockkey(event,\'bcd\');" onactivate="javascript:getid(this);" style="position:absolute; width:440px; left:210px; top:20px; height:100px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;"></div><div id =middleD oncontrolselect="javascript:getid(this);" onmove ="javascript:moves();" onresize="javascript:getdimsT();" onkeypress="javascript:blockkey(event,\'bcd\');" onactivate="javascript:getid(this);" style="position:absolute; width:440px; left:205px;top:108px; height:97px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;"></div><div id =lower oncontrolselect="javascript:getid(this);" onmove ="javascript:moves();" onresize="javascript:getdimsT();" onkeypress="javascript:blockkey(event,\'bcd\');" onactivate="javascript:getid(this);" style="position:absolute; width:640px; left:5px;top:210px; height:110px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;"></div>';
//            opener.document.getElementById('ctrval').value=6;
//            enabled();
//            }
function createnew4()
  {
      var browser=navigator.appName;
      if(browser!="Microsoft Internet Explorer")
       {
        //if(document.getElementById('editordiv').innerHTML=="")// || currentid!=null)
        if((document.getElementById('editordiv').innerHTML.indexOf('<div')!=0 || document.getElementById('savehidden').value!="") && currentid=='i4')
         {
               document.getElementById('sel_unit_disp').value="Pixel";
               document.getElementById('sel_unit').value="1";
               currentid=null;  
          //align=left name="textBox" onresize="javascript:getdimsO();" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();" onactivate="javascript:getid(this);" onkeypress="javascript:blockkey(event,\'bcd\');"<div id ="rghtD" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();" onresize="javascript:getdimsT();" onactivate="javascript:getid(this);" oncontextmenu="javascript:context_menu(this);" onkeypress="javascript:blockkey(event,\'bcd\');" style=" position:absolute; left:130px; top:20px; width:540px; height:100px; border-bottom: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-right: black 1px solid;"></div> //'<div class="drag"  align=left name="textBox" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true" style="z-index:0;background-color:#999999;color:Black;font-family:Arial;font-size:12px;font-style:normal;line-height:15px;position:absolute;word-wrap:break-word;padding-top:2px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;top:'+topT+'px;left:'+leftT+'px;"></div>');//
               document.getElementById('editordiv').innerHTML='<div id ="outer" align=left name="textBox" onresize="javascript:getdimsO();" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();" onactivate="javascript:getid(this);" onkeypress="javascript:blockkey(event,\'bcd\');" style="font-family:Arial;font-size:12px;font-style:normal; position:absolute; top:15px; left:10px; width:662px; height:332px; border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid"></div> '
               document.getElementById('editordiv').childNodes[0].innerHTML+='<DIV class="key-point" id="1~text" onmouseup=javascript:up(); ondragstart="return false" oncontextmenu=javascript:context_menu(this,event); onactivate=javascript:editmode(this); onmove=javascript:moves();javascript:up(); oncontrolselect=javascript:getid(this);javascript:moves();javascript:showprop(this); onkeypress="javascript:abc();" onmousedown=javascript:getid(this);  onkeyup=javascript:abc(); onresize=javascript:getdimsT(); contentEditable=true style=" position:absolute; border: 1px solid black; top: 10px; left: 5px; z-index: 0; background-color: #999999; color: Black; font-family: Arial; font-size: 12px; font-style: normal; position: absolute; padding-top: 2px; line-height: 20px; width: 643px; height: 72px;"  ondeactivate=javascript:dragmode(this); onfocus=javascript:getid(this); onclick=javascript:editmode(this); align=center name=" textBox">Click to add text</DIV>';
              // document.getElementById('editordiv').innerHTML+='<div id = Txt1 oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true" style=" position:absolute; top:20px; left:20px; width:650px; height:105px; z-index:0;background-color:#999999;color:Black;font-family:Arial;font-size:12px;font-style:normal;line-height:15px;position:absolute;word-wrap:break-word;padding-top:2px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;"></div>'
               document.getElementById('editordiv').childNodes[0].innerHTML+='<DIV class="key-point" id="2~text" onmouseup=javascript:up(); ondragstart="return false" oncontextmenu=javascript:context_menu(this,event); onactivate=javascript:editmode(this); onmove=javascript:moves();javascript:up(); oncontrolselect=javascript:getid(this);javascript:moves();javascript:showprop(this); onkeypress="javascript:abc();" onmousedown=javascript:getid(this);  onkeyup=javascript:abc(); onresize=javascript:getdimsT(); contentEditable=true style=" position:absolute;left:435px; top:15px; width:200px; height:80px;z-index:1;background-color:#999999;color:Black;font-family:Arial;font-size:12px;font-style:normal;line-height:15px;position:absolute;word-wrap:break-word;padding-top:2px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;"  ondeactivate=javascript:dragmode(this); onfocus=javascript:getid(this); onclick=javascript:editmode(this); align=center name=" textBox">Click to add text</DIV>';
              // document.getElementById('editordiv').innerHTML+='<div id =Txt2 oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true" style=" position:absolute;left:450px; top:30px; width:200px; height:80px;z-index:0;background-color:#999999;color:Black;font-family:Arial;font-size:12px;font-style:normal;line-height:15px;position:absolute;word-wrap:break-word;padding-top:2px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;"></div>'
               document.getElementById('editordiv').childNodes[0].innerHTML+='<DIV class="key-point" id="3~text" onmouseup=javascript:up(); ondragstart="return false" oncontextmenu=javascript:context_menu(this,event); onactivate=javascript:editmode(this); onmove=javascript:moves();javascript:up(); oncontrolselect=javascript:getid(this);javascript:moves();javascript:showprop(this); onkeypress="javascript:abc();" onmousedown=javascript:getid(this);  onkeyup=javascript:abc(); onresize=javascript:getdimsT(); contentEditable=true style=" position:absolute;left:5px; top:110px; width:650px; height:210px;z-index:0;background-color:#999999;color:Black;font-family:Arial;font-size:12px;font-style:normal;line-height:15px;position:absolute;word-wrap:break-word;padding-top:2px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;"  ondeactivate=javascript:dragmode(this); onfocus=javascript:getid(this); onclick=javascript:editmode(this); align=center name=" textBox">Click to add text</DIV>';
              // document.getElementById('editordiv').innerHTML+='<div id =Txt3 oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true" style=" position:absolute;left:20px; top:130px; width:650px; height:210px;z-index:0;background-color:#999999;color:Black;font-family:Arial;font-size:12px;font-style:normal;line-height:15px;position:absolute;word-wrap:break-word;padding-top:2px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;"></div>'
               document.getElementById('ctrval').value=5;
               enabled();
               document.getElementById('ad_height').value=330
               document.getElementById('ad_width').value=660;
               document.getElementById('measuredialog').style.display='none';
            
          }
          else
            {
                closediv();
            }
       }
       else if(browser=="Microsoft Internet Explorer")
         {
           if(document.getElementById('editordiv').innerHTML=="")
            {
               document.getElementById('sel_unit_disp').value="Pixel";
               document.getElementById('sel_unit').value="1";
               currentid=null;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       //align=left name="textBox" onresize="javascript:getdimsO();" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();" onactivate="javascript:getid(this);" onkeypress="javascript:blockkey(event,\'bcd\');"<div id ="rghtD" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();" onresize="javascript:getdimsT();" onactivate="javascript:getid(this);" oncontextmenu="javascript:context_menu(this);" onkeypress="javascript:blockkey(event,\'bcd\');" style=" position:absolute; left:130px; top:20px; width:540px; height:100px; border-bottom: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-right: black 1px solid;"></div> //'<div class="drag"  align=left name="textBox" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true" style="z-index:0;background-color:#999999;color:Black;font-family:Arial;font-size:12px;font-style:normal;line-height:15px;position:absolute;word-wrap:break-word;padding-top:2px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;top:'+topT+'px;left:'+leftT+'px;"></div>');//
               document.getElementById('editordiv').innerHTML='<div id ="outer" align=left name="textBox" onresize="javascript:getdimsO();" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();" onactivate="javascript:getid(this);" onkeypress="javascript:blockkey(event,\'bcd\');"  contenteditable="false" style="font-family:Arial;font-size:12px;font-style:normal; position:absolute; top:15px; left:10px; width:662px; height:332px; border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid"></div> '
               document.getElementById('editordiv').innerHTML+='<div id = Txt1 oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true" style=" position:absolute; top:20px; left:20px; width:650px; height:105px; z-index:0;background-color:#999999;color:Black;font-family:Arial;font-size:12px;font-style:normal;line-height:15px;position:absolute;word-wrap:break-word;padding-top:2px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;"></div>'
               document.getElementById('editordiv').innerHTML+='<div id =Txt2 oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true" style=" position:absolute;left:450px; top:30px; width:200px; height:80px;z-index:0;background-color:#999999;color:Black;font-family:Arial;font-size:12px;font-style:normal;line-height:15px;position:absolute;word-wrap:break-word;padding-top:2px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;"></div>'
               document.getElementById('editordiv').innerHTML+='<div id =Txt3 oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true" style=" position:absolute;left:20px; top:130px; width:650px; height:210px;z-index:0;background-color:#999999;color:Black;font-family:Arial;font-size:12px;font-style:normal;line-height:15px;position:absolute;word-wrap:break-word;padding-top:2px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;"></div>'
               document.getElementById('ctrval').value=5;
               enabled();
               document.getElementById('ad_height').value=330
               document.getElementById('ad_width').value=660;
               document.getElementById('measuredialog').style.display='none';
            }
          else
            {
                closediv();
            }
        }
     
   }
       
function createnew5()
    {
      var browser=navigator.appName;
      if(browser!="Microsoft Internet Explorer")
       {
         //if(document.getElementById('editordiv').innerHTML=="")// || currentid!=null)
         if((document.getElementById('editordiv').innerHTML.indexOf('<div')!=0 || document.getElementById('savehidden').value!="") && currentid=='i5')
            {
                document.getElementById('sel_unit_disp').value="Pixel";
                document.getElementById('sel_unit').value="1";
                currentid=null;
                document.getElementById('editordiv').innerHTML='<div id ="outer" align=left name="textBox" onresize="javascript:getdimsO();" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();" onmove ="javascript:moves();" onactivate="javascript:getid(this);" onkeypress="javascript:blockkey(event,\'bcd\');" style="font-family:Arial;font-size:12px;font-style:normal; position:absolute; top:15px; left:10px; width:662px; height:332px; border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid"></div> '
               document.getElementById('editordiv').childNodes[0].innerHTML+='<div id= leftD oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this,event);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="false" style=" position:absolute;top:5px; left:10px; width:200px; height:320px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid"></div>'
                document.getElementById('editordiv').childNodes[0].innerHTML+='<DIV class="key-point" id="2~picture" ondragstart="return false"  onkeydown="javascript:return blockpicture(event);"   oncontrolselect="javascript:getid(this);javascript:showprop(this);javascript:moves();" onresize="javascript:getdimsP();" oncontextmenu="javascript:context_menu(this,event);" onmove ="javascript:moves();javascript:up();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onmouseup="javascript:up();" onmousedown="javascript:getid(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);" contenteditable="true" style="position:absolute;top:10px;left:15px; width:190px; height:100px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid; background-image:url(icons/logo.jpg);"></div>'
                document.getElementById('editordiv').childNodes[0].innerHTML+='<DIV class="key-point" id="3~picture" ondragstart="return false"  onkeydown="javascript:return blockpicture(event);"  oncontrolselect="javascript:getid(this);javascript:showprop(this);javascript:moves();" onresize="javascript:getdimsP();" oncontextmenu="javascript:context_menu(this,event);" onmove ="javascript:moves();javascript:up();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onmouseup="javascript:up();" onmousedown="javascript:getid(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);" contenteditable="true" style="position:absolute;top:145px;left:15px; width:190px; height:100px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid; background-image:url(icons/logo.jpg);"></div>'
               // document.getElementById('editordiv').innerHTML+='<div id=picture oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true" style="position:absolute;top:25px;left:25px; width:190px; height:100px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid; background-image:url(icons/logo.jpg);"></div>'
                
                //document.getElementById('editordiv').innerHTML+='<div id=picture oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true" style="position:absolute;top:160px;left:25px; width:190px; height:100px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid; background-image:url(icons/logo.jpg);"></div>'
                document.getElementById('editordiv').childNodes[0].innerHTML+='<DIV class="key-point" id="1~text" onmouseup=javascript:up(); ondragstart="return false" oncontextmenu=javascript:context_menu(this,event); onactivate=javascript:editmode(this); onmove=javascript:moves();javascript:up(); oncontrolselect=javascript:getid(this);javascript:moves();javascript:showprop(this); onkeypress="javascript:abc();" onmousedown=javascript:getid(this);  onkeyup=javascript:abc(); onresize=javascript:getdimsT(); contentEditable=true style=" position:absolute;left:215px; top:5px; width:440px; height:320px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid"  ondeactivate=javascript:dragmode(this); onfocus=javascript:getid(this); onclick=javascript:editmode(this); align=center name=" textBox">Click to add text</DIV>'
                //document.getElementById('editordiv').innerHTML+='<div id =Txt4 oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true" style=" position:absolute;left:230px; top:20px; width:440px; height:320px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid"></div>';
                document.getElementById('ctrval').value=6;    
                enabled();
                document.getElementById('ad_height').value=330
                document.getElementById('ad_width').value=660;
                document.getElementById('measuredialog').style.display='none';
            }
           else
            {
                closediv();
            }
       }
     else if(browser=="Microsoft Internet Explorer")
     {
       if(document.getElementById('editordiv').innerHTML=="")
            {
                document.getElementById('sel_unit_disp').value="Pixel";
                document.getElementById('sel_unit').value="1";
                currentid=null;
                document.getElementById('editordiv').innerHTML='<div id ="outer" align=left name="textBox" onresize="javascript:getdimsO();" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();" onactivate="javascript:getid(this);" onkeypress="javascript:blockkey(event,\'bcd\');" style="font-family:Arial;font-size:12px;font-style:normal; position:absolute; top:15px; left:10px; width:662px; height:332px; border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid"></div> '
                document.getElementById('editordiv').innerHTML+='<div id= leftD oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true" style=" position:absolute;top:20px; left:20px; width:200px; height:320px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid"></div>'
                document.getElementById('editordiv').innerHTML+='<div id=picture oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true" style="position:absolute;top:25px;left:25px; width:190px; height:100px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid; background-image:url(icons/logo.jpg);"></div>'
                document.getElementById('editordiv').innerHTML+='<div id=picture oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true" style="position:absolute;top:160px;left:25px; width:190px; height:100px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid; background-image:url(icons/logo.jpg);"></div>'
                document.getElementById('editordiv').innerHTML+='<div id =Txt4 oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true" style=" position:absolute;left:230px; top:20px; width:440px; height:320px;border-bottom: black 1px solid;word-wrap:break-word;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid"></div>';
                document.getElementById('ctrval').value=6;    
                enabled();
                document.getElementById('ad_height').value=330
                document.getElementById('ad_width').value=660;
                document.getElementById('measuredialog').style.display='none';
            }
          else
            {
                closediv();
            }
     }
  }  
/************end create function******************/

function selected()
        {
           //alert('select');
            if(currentid==null)
                {
                    alert('No Sample Selected!');
                }
                else
                switch(currentid){
                case 'img1':{ createnew1();document.getElementById('newdialog').style.display='none'; break;}
                case 'img2':{ createnew2();document.getElementById('newdialog').style.display='none'; break;}
                case 'img3':{ createnew3();document.getElementById('newdialog').style.display='none'; break;}
                case 'img4':{ createnew4();document.getElementById('newdialog').style.display='none'; break;}
                case 'img5':{ createnew5();document.getElementById('newdialog').style.display='none'; break;}
                }
           }
           var k='';
           function blockkey(e,t)
           {
           //alert(t);
           try{
           if(t=='abc' && k!='bcd')
           e.keyCode=0;
           if(t=='bcd')
           k='bcd';
           else
           k='';
           }catch(er){}
          }
          
           function blockpicture(ev)
          {
          //alert(ev.keyCode);
          //ev.keyCode=0;
          return false;
          }
/*************************** this is code for genrate text box**********/ 
var sample="Click to Add Text";   
function addelement1()
 {
        var browser= navigator.appName;
        if(browser=="Microsoft Internet Explorer")
           {
                var myElement = document.createElement('<div class="drag" align=left name="textBox" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();javascript:showprop(this);" onresize ="javascript:getdimsT();" oncontextmenu="javascript:context_menu(this,event);" onmove ="javascript:moves();javascript:getdimsT();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');javascript:abc();" onkeyup = "javascript:abc();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);"  onfocusout="javascript:lostfocus();" onkeydown="javascript:deleted();"  onmouseup="javascript:up();" onmousedown="javascript:getid(this);" contenteditable="true" style="z-index:0;background-color:#999999;color:Black;font-family:Arial;font-size:12px;font-style:normal;line-height:15px;position:absolute;word-wrap:break-word;padding-top:2px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;top:'+topT+'px;left:'+leftT+'px;"></div>');//
                ctr = parseInt(document.getElementById('ctrval').value);
                myElement.setAttribute('id',ctr+"~text");
                document.getElementById('hidden1').value=ctr; 
                editordiv.appendChild(myElement);
                myElement.innerText=sample;
                if(flagtxt==0)opentxtdialog();
                currentid=ctr+"~text";
                ctr=ctr+1;
                document.getElementById('ctrval').value=ctr;
                if(topT>parseInt(r_conversion(document.getElementById('ad_height').value,unit))-100)
                {
                topT=parseInt(r_conversion(document.getElementById('ad_height').value,unit))-200;
                }
                else
                {
                topT=topT+10;
                }
                if(leftT>parseInt(r_conversion(document.getElementById('ad_width').value,unit))-150)
                {
                leftT=parseInt(r_conversion(document.getElementById('ad_width').value,unit))-200;
                }
                else
                {
                leftT=leftT+10;
                }
                
                editordiv.focus();
              }
      
   
    else if(browser!="Microsoft Internet Explorer")
      {
         if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
        {
           ctr = parseInt(document.getElementById('ctrval').value);
           var cid=ctr+"~text";
           ank='<DIV class="key-point" id="'+cid+'" onmouseup=javascript:up(); onmouseout=javascript:up(); ondragstart="return false" oncontextmenu=javascript:context_menu(this,event); onactivate=javascript:editmode(this); onmove=javascript:moves();javascript:up(); oncontrolselect=javascript:getid(this);javascript:moves();javascript:showprop(this); onkeypress="javascript:abc();" onmousedown=javascript:getid(this);  onkeyup=javascript:abc(); onresize=javascript:getdimsT(); contentEditable=true style="z-index:0;background-color:#999999;color:Black;font-family:Arial;font-size:12px;font-style:normal;line-height:15px;position:absolute;word-wrap:break-word;padding-top:2px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;top:'+topT+'px;left:'+leftT+'px;"  ondeactivate=javascript:dragmode(this); onfocus=javascript:getid(this); onclick=javascript:editmode(this); align=center name=" textBox">Click to add text</DIV>'
           document.getElementById('editordiv').childNodes[0].innerHTML+=ank;
           if(flagtxt==0)opentxtdialog();
           ctr= parseInt(ctr+1);
           document.getElementById('ctrval').value=ctr;
           if(topT>parseInt(r_conversion(document.getElementById('ad_height').value,unit))-100)
                {
                topT=parseInt(r_conversion(document.getElementById('ad_height').value,unit))-200;
                }
                else
                {
                topT=topT+10;
                }
         if(leftT>parseInt(r_conversion(document.getElementById('ad_width').value,unit))-150)
                {
                leftT=parseInt(r_conversion(document.getElementById('ad_width').value,unit))-200;
                }
                else
                {
                leftT=leftT+10;
                }
           document.getElementById('editordiv').focus();
           document.getElementById('myhdnval').value=cid;
           getdimsT();
           //alert(currentid);
      }  
      
      } 
  } 

        
 /*********************************this is code for genrate for picture box***************/
   function addelement2()
     { 
       var browser= navigator.appName;
      if(browser=="Microsoft Internet Explorer")
        {
            var myElement = document.createElement('<div class ="drag" name="pictureBox" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);" onresize="javascript:getdimsP();" oncontextmenu="javascript:context_menu(this,event);" onmove ="javascript:moves();javascript:getdimsP();javascript:up();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onmouseup="javascript:up();" onmousedown="javascript:getid(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);" contenteditable="true" style="z-index:0;position:absolute;background-image:url(icons/logo.jpg); background-repeat:no-repeat;background-position:center;width:135px;top:'+topT+'px;left:'+leftT+'px;height:100px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid; background-color:White;"></div>');//onfocus="javascript:getid(this);" onactivate="javascript:getid(this);" onclick="javascript:getid(this);" onkeypress="javascript:blockkey(event,\'bcd\');"
            ctr = parseInt(document.getElementById('ctrval').value);
            myElement.setAttribute('id',ctr+"~picture");
            document.getElementById('hidden1').value=ctr; 
            editordiv.appendChild(myElement);
            if(flagpic==0)
            openpicdialog();
            currentid=ctr+"~picture";
            ctr=ctr+1;
            document.getElementById('ctrval').value=ctr;
            if(topT>parseInt(r_conversion(document.getElementById('ad_height').value,unit))-100)
                {
                topT=parseInt(r_conversion(document.getElementById('ad_height').value,unit))-200;
                }
                else
                {
                topT=topT+10;
                }
                if(leftT>parseInt(r_conversion(document.getElementById('ad_width').value,unit))-150)
                {
                leftT=parseInt(r_conversion(document.getElementById('ad_width').value,unit))-200;
                }
                else
                {
                leftT=leftT+10;
                }
            editordiv.focus();
            //editordiv.focus();
         }
         
         
      else if(browser!="Microsoft Internet Explorer")
       {
       if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
        {
       
           ctr = parseInt(document.getElementById('ctrval').value);
           cid=ctr+"~picture";
           //var mydiv='<DIV class="key-point" id="'+cid+'" onmouseup=javascript:up(); ondragstart="return false" oncontextmenu=javascript:context_menu(this,event); onactivate=javascript:editmode(this); onmove=javascript:moves();javascript:up(); oncontrolselect=javascript:getid(this);javascript:moves();javascript:showprop(this); onkeypress="javascript:abc();" onmousedown=javascript:getid(this);  onkeyup=javascript:abc(); onresize=javascript:getdimsT(); contentEditable=true style="z-index:0;background-color:#999999;color:Black;font-family:Arial;font-size:12px;font-style:normal;line-height:15px;position:absolute;word-wrap:break-word;padding-top:2px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;top:'+topT+'px;left:'+leftT+'px;" onfocusout=javascript:lostfocus(); ondeactivate=javascript:dragmode(this); onfocus=javascript:getid(this); onclick=javascript:getid(this); align=center name=" textBox">Click to add text</DIV>'
           var mydiv='<DIV class="key-point" id="'+cid+'" ondragstart="return false" onkeydown="javascript:return blockpicture(event);" oncontrolselect="javascript:getid(this);javascript:showprop(this);javascript:moves();" onmouseout=javascript:up(); onresize="javascript:getdimsP();" oncontextmenu="javascript:context_menu(this,event);" onmove ="javascript:moves();javascript:up();" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onmouseup="javascript:up();" onmousedown="javascript:getid(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);" contenteditable="true" style="z-index:0;position:absolute;background-image:url(icons/logo.jpg); background-repeat:no-repeat;background-position:center;width:135px;top:'+topT+'px;left:'+leftT+'px;height:100px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid; background-color:White;"></div>';
           document.getElementById('editordiv').childNodes[0].innerHTML+=mydiv;
           if(flagtxt==0)
           openpicdialog();
           cid=ctr+"~picture";
           ctr= parseInt(ctr+1);
           document.getElementById('ctrval').value=ctr;
           if(topT>parseInt(r_conversion(document.getElementById('ad_height').value,unit))-100)
                {
                topT=parseInt(r_conversion(document.getElementById('ad_height').value,unit))-200;
                }
                else
                {
                topT=topT+10;
                }
                if(leftT>parseInt(r_conversion(document.getElementById('ad_width').value,unit))-150)
                {
                leftT=parseInt(r_conversion(document.getElementById('ad_width').value,unit))-200;
                }
                else
                {
                leftT=leftT+10;
                }
           document.getElementById('editordiv').focus();
           document.getElementById('myhdnval').value=cid;
           getdimsP();
           //alert(currentid);
      }
    }   
  }

/*****************************this is code for genrate line********************/      
function addelement3()
 {
    var browser= navigator.appName;
    if(browser=="Microsoft Internet Explorer")
  // if(document.all)
      { 
         var myElement = document.createElement('<div class ="drag" name="line" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsL();javascript:showprop(this);" onresize="javascript:getdimsL();" oncontextmenu="javascript:context_menu(this,event);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);" onmouseup="javascript:up();" onmousedown="javascript:getid(this);" style=" position:absolute; left:20px; width:0px; height:100px; top:'+topT+'px;left:'+leftT+'px; border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;border-style:none;background-color:Black"> </div>');//onfocus="javascript:getid(this);" onactivate="javascript:getid(this);" onclick="javascript:getid(this);" onkeypress="javascript:blockkey(event,\'bcd\');"
         //var myElement = document.createElement('<div class ="drag" name="line" oncontrolselect="javascript:getid(this);"  onactivate="javascript:editmode(this);" onresize="javascript:getdimsL();" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);"onclick ="javascript:getid(this);"  style=" position:absolute; left:20px; width:0px; height:100px; top:'+topT+'px;left:'+leftT+'px; border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;border-style:none;background-color:Black"> </div>');//onfocus="javascript:getid(this);" onactivate="javascript:getid(this);" onclick="javascript:getid(this);" onkeypress="javascript:blockkey(event,\'bcd\');"
         //if(ctr<100){
         ctr = parseInt(document.getElementById('ctrval').value);
         myElement.setAttribute('id',ctr+"~line");
         document.getElementById('hidden1').value=ctr; 
         editordiv.appendChild(myElement);
         if(flagline==0)
         openlinedialog();
         currentid=ctr+"~line";
         ctr=ctr+1;
         document.getElementById('ctrval').value=ctr;
         if(topT>parseInt(r_conversion(document.getElementById('ad_height').value,unit))-100)
                {
                topT=parseInt(r_conversion(document.getElementById('ad_height').value,unit))-200;
                }
                else
                {
                topT=topT+10;
                }
                if(leftT>parseInt(r_conversion(document.getElementById('ad_width').value,unit))-150)
                {
                leftT=parseInt(r_conversion(document.getElementById('ad_width').value,unit))-200;
                }
                else
                {
                leftT=leftT+10;
                }
        }
        else if(browser!="Microsoft Internet Explorer")
           {
             if(document.getElementById('outer').value=="")
                 {
                   //alert('Please select the Template first');
                 }
          else
           {
               ctr = parseInt(document.getElementById('ctrval').value);
               currentid=ctr+"~line"
               var mydiv = '<div class="key-point" contenteditable="true" onmouseout=javascript:up(); id="'+currentid+'" name="line"  onkeydown="javascript:return blockpicture(event);"  oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsP();javascript:showprop(this);" onresize="javascript:getdimsL();" oncontextmenu="javascript:context_menu(this,event);" onmove ="javascript:moves();javascript:up();" onkeypress="javascript:blockkey(event,\'bcd\');" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);"onclick ="javascript:getid(this);" onmouseup="javascript:up();" onmousedown="javascript:getid(this);" style=" position:absolute; left:20px; width:1px; height:100px; top:'+topT+'px;left:'+leftT+'px; border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;border-style:none;background-color:Black"> </div>';
               //alert(mydiv)
               document.getElementById('editordiv').childNodes[0].innerHTML += mydiv
                //alert(document.getElementById('editordiv').childNodes[0]);
                if(flagline==0)openlinedialog();
                currentid=ctr+"~line";
                ctr=parseInt(ctr+1);
                document.getElementById('ctrval').value=ctr;
               // alert(currentid);
               if(topT>parseInt(r_conversion(document.getElementById('ad_height').value,unit))-100)
                {
                topT=parseInt(r_conversion(document.getElementById('ad_height').value,unit))-200;
                }
                else
                {
                topT=topT+10;
                }
                if(leftT>parseInt(r_conversion(document.getElementById('ad_width').value,unit))-150)
                {
                leftT=parseInt(r_conversion(document.getElementById('ad_width').value,unit))-200;
                }
                else
                {
                leftT=leftT+10;
                }
                document.getElementById('myhdnval').value=currentid;
           getdimsL();
                //editordiv.focus()
                //editordiv.focus(); 
            }
          }
     }
/******************************end of code for line***************************/     
     
     
     
 function abc()
     {
      var browser = navigator.appName;
     if(browser=="Microsoft Internet Explorer")
     {
        if(document.getElementById('myhdnval').value=="" || document.getElementById('myhdnval').value==null )
            {
              if(document.getElementById(document.getElementById('myhdnval').value).clientHeight > parseInt(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("px",""))+2)
                 {
                   alert('Text Exceed Size of Box');
                   document.getElementById(document.getElementById('myhdnval').value).innerText=document.getElementById(document.getElementById('myhdnval').value).innerText.substr(0,document.getElementById(document.getElementById('myhdnval').value).innerText.length - 1);
                   blockkey(event,'bc');
                   //deleted();
                  }
             }
         else
          {
              if(document.getElementById(document.getElementById('myhdnval').value).clientHeight > parseInt(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("px",""))+2)
                  {
                      exceedmatter=document.getElementById(document.getElementById('myhdnval').value).innerHTML;
                      alert('Text Exceed Size of Box');
                      document.getElementById(document.getElementById('myhdnval').value).innerText=document.getElementById(document.getElementById('myhdnval').value).innerText.substr(0,document.getElementById(document.getElementById('myhdnval').value).innerText.length - 1);
                      blockkey(event,'abc');
                      document.getElementById(document.getElementById('myhdnval').value).innerHTML=exceedmatter;
                      // deleted();
                  }
              else
               {
//                  if(event.keyCode==32)
//                     {
//                       checkbword()
//                     }
               }
          }
      }
      }
      
      
/***************************************************/      
function up()
 {
 //alert('up');
 var browser = navigator.appName;
 if(browser=="Microsoft Internet Explorer")
  {
     var xval=parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetLeft);
     var yval=parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetTop);
     var xright=parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetWidth)+parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetLeft);
     var ybottom=parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetHeight)+parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetTop);
     var xvall=xval.toString();
     var yvall=yval.toString();
     var xrightt=xright.toString();
     var ybotomm =ybottom.toString();

      if(xvall.indexOf('-')>=0)
       {
         document.getElementById(document.getElementById('myhdnval').value).style.pixelLeft="10";
         return false;
     }
     
     if(yvall.indexOf('-')>=0)
     {
     document.getElementById(document.getElementById('myhdnval').value).style.pixelTop="15";         
     return false;
     }
     
     if(document.getElementById('myhdnval').value=="" || document.getElementById('myhdnval').value==null)
      {
          document.getElementById(document.getElementById('myhdnval').value).style.pixelLeft="12";
          document.getElementById(document.getElementById('myhdnval').value).style.pixelTop="16";
        }
      else
        {
         if(xval < 10 )
         {
           document.getElementById(document.getElementById('myhdnval').value).style.pixelLeft="10";
           
         }
         if(yval < 15)
         {
            document.getElementById(document.getElementById('myhdnval').value).style.pixelTop="15";
         }
         if(xright>parseInt(document.getElementById('outer').offsetWidth+document.getElementById('outer').offsetLeft))
           {
              document.getElementById(document.getElementById('myhdnval').value).style.pixelLeft=parseInt(document.getElementById('outer').offsetWidth+document.getElementById('outer').offsetLeft)-parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetWidth);
              //document.getElementById(document.getElementById('myhdnval').value).style.pixelTop="16";
             
            }
         if(ybottom>parseInt(document.getElementById('outer').offsetHeight+document.getElementById('outer').offsetTop))
         {
           //document.getElementById(document.getElementById('myhdnval').value).style.pixelLeft="12";
            document.getElementById(document.getElementById('myhdnval').value).style.pixelTop=parseInt(document.getElementById('outer').offsetHeight+document.getElementById('outer').offsetTop)-parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetHeight);
           return;
         }
         
      }
   }
  else if(browser!="Microsoft Internet Explorer")
   {
      var xval=parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetLeft);
     var yval=parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetTop);
     var xright=parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetWidth)+parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetLeft);
     var ybottom=parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetHeight)+parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetTop);
     var xvall=xval.toString();
     var yvall=yval.toString();
     var xrightt=xright.toString();
     var ybotomm =ybottom.toString();
//       alert(xval);
//       alert(yval);
//       alert(xright);
//       alert(ybottom);
//        
      if(xvall.indexOf('-')>=0)
       {
       //alert(document.getElementById(document.getElementById('myhdnval').value).offsetLeft);
       document.getElementById(document.getElementById('myhdnval').value).style.left="0px";
     
     }
    
     if(yvall.indexOf('-')>=0)
     {
     document.getElementById(document.getElementById('myhdnval').value).style.top="0px";         
    
     }
     if(xrightt.indexOf('-')>=0)
     {
   
     }
     if(document.getElementById('myhdnval').value=="" || document.getElementById('myhdnval').value==null)
      {
          document.getElementById(document.getElementById('myhdnval').value).style.left="12";
          document.getElementById(document.getElementById('myhdnval').value).style.top="16";
        }
      else
        {
         if(xval <= 0 )
         {
         //alert("hello1");
           document.getElementById(document.getElementById('myhdnval').value).style.left="0px";
           
         }
         if(yval <= 0)
         {
       // alert("hello2");
            document.getElementById(document.getElementById('myhdnval').value).style.top="0px";
         }
         if(xright>parseInt(document.getElementById('outer').offsetWidth+document.getElementById('outer').offsetLeft))
           {
           //alert("hello3");
              document.getElementById(document.getElementById('myhdnval').value).style.left=(parseInt(document.getElementById('outer').offsetWidth+document.getElementById('outer').offsetLeft)-parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetWidth)-10)+"px";
              //document.getElementById(document.getElementById('myhdnval').value).style.pixelTop="16";
             
            }
         if(ybottom>parseInt(document.getElementById('outer').offsetHeight+document.getElementById('outer').offsetTop)-10)
         {
       // alert("hello4");
           //document.getElementById(document.getElementById('myhdnval').value).style.pixelLeft="12";
          // alert(parseInt(document.getElementById('outer').offsetHeight+document.getElementById('outer').offsetTop)-parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetHeight)+"px");
           document.getElementById(document.getElementById('myhdnval').value).style.top=(parseInt(document.getElementById('outer').offsetHeight+document.getElementById('outer').offsetTop)-parseInt(document.getElementById(document.getElementById('myhdnval').value).offsetHeight)-15)+"px";
           
         }
         moves();
         
      }
   
   }
 }
 /*************************************/
 function changeW_L()
     {
      //alert('manoj');
      var browser=navigator.appName;
      if(browser=="Microsoft Internet Explorer")
      {
        if(currentid==null || currentid=='editordiv')
        alert('Please select Item !');
        if(document.getElementById('input_wdthL').value >= 21)
         {
           alert('Line Width Should Not Greater Than 20');
           document.getElementById(document.getElementById('myhdnval').value).style.width=20;
           document.getElementById('input_wdthL').value=20;
           //document.getElementById('input_wdthL').value="";
           //document.getElementById('input_wdthL').focus();
        }
        else
        {
        temp=document.getElementById('input_wdthL').value;
        if(document.getElementById('myhdnval').value!="outer")
        {
        document.getElementById(document.getElementById('myhdnval').value).style.width=temp;
        }
        else
        {
        
        }
       // document.getElementById(document.getElementById('myhdnval').value).style.width=temp;
        
    }  
    }
    else if(browser!="Microsoft Internet Explorer")
      {
        if(currentid==null || currentid=='editordiv')
        alert('Please select Item !');
        if(document.getElementById('input_wdthL').value > conversion(20,unit))
         {
           alert('Line Width Should Not Greater Than '+ conversion(20,unit));
           document.getElementById(document.getElementById('myhdnval').value).style.width=20+"px";
           if(unit==1)
           {
           document.getElementById('input_wdthL').value=20;
           }
           else
           {
            document.getElementById('input_wdthL').value=conversion(20,unit);
           }
           document.getElementById('input_wdthL').focus();
          }
        else
         {
          temp=document.getElementById('input_wdthL').value;
          if(document.getElementById('myhdnval').value!="outer")
           {
            if(unit==1)
            {
             document.getElementById(document.getElementById('myhdnval').value).style.width=temp+"px";
            }
            if(unit==2)
            {
             document.getElementById(document.getElementById('myhdnval').value).style.width=temp+"in";
            }
            if(unit==3)
            {
             document.getElementById(document.getElementById('myhdnval').value).style.width=temp+"cm";
            }
            if(unit==4)
            {
             document.getElementById(document.getElementById('myhdnval').value).style.width=temp+"mm";
            }
           }
        else
        {
        
        }
       // document.getElementById(document.getElementById('myhdnval').value).style.width=temp;
     }  
      
      }
   } 
 
 /*************************************/
   
function changeH_L()
  {
    var browser=navigator.appName;
    if(browser!="Microsoft Internet Explorer")
     {
     //alert("hello");
       if(currentid==null || currentid=='editordiv')
       alert('Please select Item !');
       else if (document.getElementById(document.getElementById('myhdnval').value)==null)
       alert('Item not Exist ?');
       else
       {
        
         // document.getElementById('').
        temp=document.getElementById('input_hghtL').value;
        if(document.getElementById('myhdnval').value !="outer")
         {
            //alert(temp); 
          if(unit==1)     
           {  
            document.getElementById(document.getElementById('myhdnval').value).style.height=temp+"px";
           }
           if(unit==2)     
           {  
            document.getElementById(document.getElementById('myhdnval').value).style.height=temp+"in";
           }
           if(unit==3)     
           {  
            document.getElementById(document.getElementById('myhdnval').value).style.height=temp+"cm";
           }
           if(unit==4)     
           {  
            document.getElementById(document.getElementById('myhdnval').value).style.height=temp+"mm";
           }
           getdimsL();
         }
        else
        {
        
        }
          // document.getElementById(document.getElementById('myhdnval').value).style.height=temp;
       }
    }
    else if(browser=="Microsoft Internet Explorer")
     {
       if(currentid==null || currentid=='editordiv')
       alert('Please select Item !');
       else if (document.getElementById(document.getElementById('myhdnval').value)==null)
       alert('Item not Exist ?');
       else
       {
         // document.getElementById('').
        temp=document.getElementById('input_hghtL').value;
        if(document.getElementById('myhdnval').value !="outer")
         {
               
                document.getElementById(document.getElementById('myhdnval').value).style.height=temp;
               
         }
        else
        {
        
        }
          // document.getElementById(document.getElementById('myhdnval').value).style.height=temp;
       }
     } 
  }
/*******************************end of code for line width**********************/
function horline()
{
  if(document.all)
      {
            var hght = document.getElementById('input_hghtL').value;
            var wid = document.getElementById('input_wdthL').value;
            document.getElementById(document.getElementById('myhdnval').value).style.filter='progid:DXImageTransform.Microsoft.BasicImage(rotation=0)';
       }
     else
      {
         alert("Mozilla does not support this feature");
          document.getElementById('lineprop_hlr').checked='true';
      }
}
function verline()
{
if(document.all)
    {
        var hght = document.getElementById('input_hghtL').value;
        var wid = document.getElementById('input_wdthL').value;
        document.getElementById(document.getElementById('myhdnval').value).style.filter='progid:DXImageTransform.Microsoft.BasicImage(rotation=1)';
     }
  else
    {
      alert("Mozilla does not support this feature");
       document.getElementById('lineprop_hlr').checked='true';
    }
}


/*********************/    
    
//  function editmode(obj)
//  {
//     if(document.all)
//     {
// 
//      //alert("gerere")
//        document.getElementById('hidden1').value=obj.id;
//        obj.className=obj.className.replace('drag','nodrag');
//        var a = obj.innerText;
//        if(obj.innerText==sample)
//        {
//            obj.innerHTML="";
//        }
//        for(var i=1; i < x.length; i++)
//            {
//             if(obj.innerText==sample || obj.innerHTML==x[i])
//                {
//                    obj.innerHTML="";
//                 }
//                    
//                else if(a=="")
//                {
//                  obj.innerText==sample;
//                }
//          }
//      }
//      else
//      {
//         getid(obj); 
//         var a=obj.textContent;
//         //alert(a);
//         if(a=="Click to add text" || a==sample)
//         {
//           obj.textContent="";
//         }
//     }
// }      
/****************************************/


     function editmode(obj)
	{
	//alert('editmod');
	var browser=navigator.appName;
	if(browser=="Microsoft Internet Explorer")
	{
        //alert("gerere")
        document.getElementById('hidden1').value=obj.id;
        obj.className=obj.className.replace('drag','nodrag');
        var a = obj.innerText;
        if(obj.innerText==sample)
        {
            obj.innerHTML="";
        }
       
        for(var i=0; i <parseInt( x.length); i++)
         {
         //alert(x[i])
            if(obj.innerText==sample || obj.innerHTML==x[i])
            {
              obj.innerHTML="";
		    }
                    
            else if(a=="")
			 {
				obj.innerText==sample;
			 }
           }
       } 
    else if(browser!="Microsoft Internet Explorer")
      {
       // alert(obj.id)
        var av= obj.id.split("~")
        
        //alert('edit');
         //alert(document.getElementById('prevalue').value)
        a=obj.innerHTML;
         if(document.getElementById('prevalue').value=="")
            {}
            else if(document.getElementById('prevalue').value==undefined)
            {}
            
             else
             
            {
            //alert(document.getElementById('prevalue').value)
            if(obj.id!=document.getElementById('prevalue').value)
            {
            //alert(document.getElementById('prevalue').value);
            if(document.getElementById('prevalue').value!="" || document.getElementById('prevalue').value==undefined)
            {
				if(document.getElementById(document.getElementById('prevalue').value).innerHTML=="")
				{
                document.getElementById(document.getElementById('prevalue').value).innerHTML=document.getElementById('word1').value;
				}        
            }
            }
             else
             {
//                document.getElementById('prevalue').value="";
//                document.getElementById('word1').value="";
//                
             }
             }
             
        if(av[1]=="text")
        {
        if(obj.innerHTML=="Click to add text")
        {k
           
    
        
        document.getElementById('prevalue').value=obj.id;
        document.getElementById('word1').value=obj.innerHTML;
            // alert(document.getElementById('word1').value);
         document.getElementById(obj.id).textContent="";
         document.getElementById(obj.id).innerHTML=""
         }
         
        // alert(parseInt( x.length));
       
          for(var i=0; i <parseInt( x.length); i++)
         {
      //  alert(x[i]);
       // alert(obj.innerHTML);
            if(obj.innerHTML==x[i])
            {
            if(obj.innerHTML!="")
            {
             //alert("in inner if");
             document.getElementById('prevalue').value=obj.id;
             document.getElementById('word1').value=obj.innerHTML;
              obj.textContent="";
              obj.innerHTML="";
              return;
		    }
		    }
         }           
//            else if(a=="")
//			 {
//				obj.textContent=sample;
//			 }
           }
         // alert('edit')
//        document.getElementById('hidden1').value=obj.id;
//        alert('editmod2');
//        obj.className=obj.className.replace('drag','nodrag');
//        alert('editmod3');
//        var a = obj.textContent;
//        alert('editmod4');
//        if(obj.textContent==sample)
//        {
//         // alert('editmod5');
//            obj.innerHTML="";
//        }
//        for(var i=1; i < x.length; i++)
//         {
//           // alert('editmod6');
//            if(obj.textContent==sample || obj.innerHTML==x[i])
//            {
//            //alert('editmod7');
//              obj.innerHTML="";
//		    }
//                    
//            else if(a=="")
//			 {
//			 //alert('editmod8');
//				obj.textContent==sample;
//				
//			 }
//           } 
          // }
//    
    }
}

//function editmode2(obj)
//{
//alert("hello");
//if(document.all)
//{
//}
//else
//{
//alert(word1);
//    var objid2=obj.id;
//   // var html1=document.getElementById('editordiv').childNodes[0].innerHTML;
//    //var splithtm=document.getElementById('editordiv').childNodes[0].innerHTML.split('');
//    //alert(objid);
//    if(objid2!=objid1)
//    {
//    
//    document.getElementById(objid).textContent=word1;
//    alert(document.getElementById(objid).textContent);
//    }
//    
//    
//    
//}
//}

/*************************************************************/                
                
//        function editmode(obj){obj.className=obj.className.replace('drag','nodrag');
//            if(obj.innerHTML!="")
//                {
//                    obj.innerHTML="";}
//            else if(obj.innerText==""){obj.innerText==sample;}
//                }
        function dragmode(obj){obj.className=obj.className.replace('nodrag','drag'); }
            
        function lostfocus(){
        //alert("hello");
         try{
        
            var aa = editordiv.innerHTML;
            var aa1 = aa.split("<DIV");
            for(var i = 2; i < aa1.length; i++)
            {
                var aa2 = aa1[i].split("id=");
                var aa3 = aa2[1].split(" ");
                var aa4 = aa2[1].split("\"");
                if(document.getElementById(aa3[0]).innerHTML=="" && aa4[3]=="textBox")
                    {
                        //document.getElementById(aa3[0]).innerHTML=sample;
                        document.getElementById(aa3[0]).innerHTML=x[i-1];
                    }
                    if(document.getElementById(aa3[0]).innerHTML=="undefined")
                        {
                            document.getElementById(aa3[0]).innerHTML=sample;                            
                        }
            }
            }
            catch(er)
            { alert('Error!!');}
            
            }
            /********************/
            
   function em(obj){obj.className=obj.className.replace('drag','nodrag');
            if(obj.innerHTML==sample)
                {
                  {
                     obj.innerText="";
                     var text = obj.innerText;
                     var text1 = obj.innerHTML.replace(text,"");
                     obj.innerText="";
                   }
                 }
                  else if(obj.innerText==""){obj.innerText=="sample text"}
                }
                
                
 function chkamount(ab)
          {
               //var fld =document.getElementById(ab).value;
               var fld=ab.value;
               if(fld!="")
               {
                 //var expression= ^-{0,1}\d*\.{0,1}\d+$;
                 if(fld.match(/^\d+(\.\d{2})?$/i))
                 {
                   return true;
                 }
                 else
                  {
                    alert("Input error")
                   //document.getElementById(ab).focus();
                   ab.focus();
                   ab.value="";
                   return false;
                 }
               }
               return true;
          }
 /*******************8 this is code for text box**********/
function getdimsT()
  {
   try
       {
        if(document.getElementById('editordiv').childNodes[0].id=="outer")
            {
              if(document.getElementById('ad_height').value!="")
                {
                 if(document.getElementById('sel_unit_disp').value=="px")
                    {
                        unit =1;
                    }
                    if(document.getElementById('sel_unit_disp').value=="inch")
                        {
                           unit =2;
                        }
                    if(document.getElementById('sel_unit_disp').value=="cm")
                        {
                            unit =3;
                        }
                    if(document.getElementById('sel_unit_disp').value=="mm")
                        {
                            unit =4;
                        }
                  document.getElementById(document.getElementById('editordiv').childNodes[0].id).style.height=r_conversion(document.getElementById('ad_height').value,unit);
                  document.getElementById(document.getElementById('editordiv').childNodes[0].id).style.width=r_conversion(document.getElementById('ad_width').value,unit);
                  //return;
                 }       
                          
            }
        else
        {
        
        }

      if(document.getElementById('myhdnval').value==null || document.getElementById('myhdnval').value=="" || document.getElementById('myhdnval').value=="outer" ){}
          else
           {
           if(document.all)
           {
           up();
           //alert("hi");
            imgToolMenu.style.visibility = 'hidden';
            document.getElementById('textboxprop_changecase').value=0;
            unit=parseInt(document.getElementById('sel_unit').value);
            document.getElementById('fonttoolbar_fntname').value=document.getElementById(document.getElementById('myhdnval').value).style.fontFamily;
            document.getElementById('textboxprop_fntname').value=document.getElementById(document.getElementById('myhdnval').value).style.fontFamily;
            var ab=document.getElementById(document.getElementById('myhdnval').value).style.fontSize;
            var ab1=ab.replace("px","");
            document.getElementById('textboxprop_fntsize').value = ab1;
            document.getElementById('fonttoolbar_fntsize').value=ab1;
           // document.getElementById('linsp').value=document.getElementById(currentid).style.lineHeight;
            document.getElementById('fonttoolbar_alignment').value=document.getElementById(document.getElementById('myhdnval').value).align;
            document.getElementById('textboxprop_alignment').value=document.getElementById(document.getElementById('myhdnval').value).align;
            //document.getElementById('hghtsel').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.height),unit);
            //document.getElementById('wdthsel').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.width),unit);
           // document.getElementById('input_hghtP').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.height),unit);
            document.getElementById('input_hght').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.height),unit);
            document.getElementById('input_wdth').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.width),unit);
            document.getElementById('sampleclrfont').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.color;
            document.getElementById('sampleclrbckT').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.backgroundColor;
            document.getElementById('sampleclrbrdrT').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.borderColor;
            document.getElementById('toolsbox_fcolor').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.color;
            document.getElementById('toolsbox_bgcolor').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.backgroundColor;
            document.getElementById('bsize').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.borderWidth),unit);
            document.getElementById('textboxprop_borderlist').value=document.getElementById(document.getElementById('myhdnval').value).style.borderStyle;
            document.getElementById('txtlinespacing').value = conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.lineHeight.replace("px","")),unit);
            document.getElementById('ad_height').value =conversion(parseInt(document.getElementById('outer').style.height),unit);
            document.getElementById('ad_width').value = conversion(parseInt(document.getElementById('outer').style.width),unit);
            //document.getElementById('hghtsel').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.height),unit);
            //document.getElementById('wdthsel').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.width),unit);
          
            up();
            
          if(parseInt(r_conversion(document.getElementById('input_hght').value,unit))>parseInt(r_conversion(document.getElementById('ad_height').value,unit))-2)  
             {
              
           // alert('Height should not be greater than'+" "+parseInt(document.getElementById('ad_height').value))
            document.getElementById(document.getElementById('myhdnval').value).style.height=r_conversion(document.getElementById('ad_height').value,unit)-1;
            }
           else if(r_conversion(document.getElementById('input_wdth').value,unit)>r_conversion(document.getElementById('ad_width').value,unit)-2)
            {
          //alert('Width should not be greater than'+"  "+parseInt(document.getElementById('ad_width').value))
            document.getElementById(document.getElementById('myhdnval').value).style.width=r_conversion(document.getElementById('ad_width').value,unit)-2;
            }    
          
            }
            else
            {
             document.getElementById('imgToolMenu').style.visibility = 'hidden';
             unit=parseInt(document.getElementById('sel_unit').value);
             document.getElementById('textboxprop_changecase').value=0;
            //alert(unit);
            //hgt=parseInt(document.getElementById(currentid).style.height);
            //editmode(document.getElementById(currentid));
            document.getElementById('fonttoolbar_fntname').value=document.getElementById(document.getElementById('myhdnval').value).style.fontFamily;
            document.getElementById('textboxprop_fntname').value=document.getElementById(document.getElementById('myhdnval').value).style.fontFamily;
            //document.getElementById('
            var ab=document.getElementById(document.getElementById('myhdnval').value).style.fontSize;
            var ab1=ab.replace("px","");
            // alert(ab);
            document.getElementById('textboxprop_fntsize').value = ab1;
            document.getElementById('fonttoolbar_fntsize').value=ab1;
            // document.getElementById('linsp').value=document.getElementById(currentid).style.lineHeight;
            document.getElementById('fonttoolbar_alignment').value=document.getElementById(document.getElementById('myhdnval').value).align;
            //alert(document.getElementById(document.getElementById('myhdnval').value).align);
            document.getElementById('textboxprop_alignment').value=document.getElementById(document.getElementById('myhdnval').value).align;
            if((document.getElementById(document.getElementById('myhdnval').value).style.height).indexOf("px")>=0)
          {
          document.getElementById('input_hght').value=conversion(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('px','')),unit);
         // document.getElementById('input_wdthP').value=conversion(parseInt((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('px','')),unit);
          }
            else
            {
            if(unit==2)
            {
                document.getElementById('input_hght').value=(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('in','')));
            }
             if(unit==3)
            {
                document.getElementById('input_hght').value=(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('cm','')));
            }
             if(unit==4)
            {
                document.getElementById('input_hght').value=(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('mm','')));
            }
            }
         
         if((document.getElementById(document.getElementById('myhdnval').value).style.width).indexOf("px")>=0)
          {
         // alert(document.getElementById(document.getElementById('myhdnval').value).style.width);
          //document.getElementById('input_hghtP').value=conversion(parseInt((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('px','')),unit);
          document.getElementById('input_wdth').value=conversion(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('px','')),unit);
          //alert(document.getElementById('input_wdthP').value)
          }
            else
            {
            if(unit==2)
            {
                document.getElementById('input_wdth').value=(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('in','')));
            }
             if(unit==3)
            {
                //alert(document.getElementById(document.getElementById('myhdnval').value).style.width);
                document.getElementById('input_wdth').value=(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('cm','')));
                //alert(document.getElementById('input_wdthP').value)
            }
             if(unit==4)
            {
                document.getElementById('input_wdth').value=(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('mm','')));
            }
            
            }
            
            
            
           // document.getElementById('input_hght').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.height),unit);
            //document.getElementById('input_wdth').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.width),unit);
            document.getElementById('sampleclrfont').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.color;
            document.getElementById('sampleclrbckT').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.backgroundColor;
            var bordercol=(document.getElementById(document.getElementById('myhdnval').value).style.borderColor);
            if(bordercol.indexOf(')')>0)
            {
              var col1=document.getElementById(document.getElementById('myhdnval').value).style.borderColor.split(')');
              var col=col1[1]+')';
            }
            else
            {
              var col1=document.getElementById(document.getElementById('myhdnval').value).style.borderColor.split(' ');
              var col=col1[1];
            }
            //alert(col);
            if(document.getElementById(document.getElementById('myhdnval').value).innerHTML.indexOf("<p>")>=0)
            {
                document.getElementById('dropcheck').checked=true;
            }
            else
            {
                document.getElementById('dropcheck').checked=false;
            }
            document.getElementById('sampleclrbrdrT').style.backgroundColor=col;
            document.getElementById('toolsbox_fcolor').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.color;
            document.getElementById('toolsbox_bgcolor').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.backgroundColor;
            var bsiz=((document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth));
         // alert(bsiz);
          if(bsiz.indexOf('px')>=0)
          {
            bsiz=bsiz.replace('px','');
            if(unit!=1)
            {
            bsiz=conversion(bsiz,unit);
            }
          }
            else if(unit==2)
            {
             bsiz=bsiz.replace('in','');
            }
            else if(unit==3)
            {
             bsiz=bsiz.replace('cm','');
            }
            
            else if(unit==4)
            {
             bsiz=bsiz.replace('mm','');
            }
            
            
            document.getElementById('bsize').value=bsiz;
            var border1=(document.getElementById(document.getElementById('myhdnval').value).style.borderStyle.split(' '));
            var bord=border1[1];
            // alert(bord);
            document.getElementById('textboxprop_borderlist').value=bord;
              var bspace=(document.getElementById(document.getElementById('myhdnval').value).style.lineHeight);
         // alert(bsiz);
         var lval= parseInt(bspace)/parseInt(ab1);
            document.getElementById('txtlinespacing').value=parseInt(lval);
             spacing();
          
            
          
           
            document.getElementById('ad_height').value =conversion((document.getElementById('outer').style.height.replace('px','')),unit);
            document.getElementById('ad_width').value = conversion((document.getElementById('outer').style.width.replace('px','')),unit);
 
            
           
             if(unit==1)
                {
                var psize=(parseInt(document.getElementById('input_hght').value)+parseInt(bsiz)+parseInt(bsiz)) 
                    if((parseInt(psize))>(parseInt(document.getElementById('ad_height').value)))  
                    {
                        var newpsize=parseInt(document.getElementById('ad_height').value)-parseInt(bsiz)-parseInt(bsiz);
                         document.getElementById(document.getElementById('myhdnval').value).style.height=parseInt(newpsize)+"px";
                   
                    }
                }
                
            
            
            else
            {
             var psize=parseFloat(r_conversion(document.getElementById('input_hght').value,unit))+parseFloat(r_conversion(bsiz,unit))+parseFloat(r_conversion(bsiz,unit));
                if((parseFloat(psize))>(r_conversion(document.getElementById('ad_height').value,unit)))  
                 {
                    //alert('Height should not be greater then'+ parseInt(document.getElementById('ad_height').value))
                   
                       
                   
                    if(unit==2)
                    {
                     var newpsize=parseFloat(document.getElementById('ad_height').value)-parseFloat(bsiz)-parseFloat(bsiz); 
                        document.getElementById(document.getElementById('myhdnval').value).style.height=parseFloat(newpsize)+"in";
                        moves();
                    }   
                    if(unit==3)
                    {
                     var newpsize=parseFloat(document.getElementById('ad_height').value)-parseFloat(bsiz)-parseFloat(bsiz); 
                        document.getElementById(document.getElementById('myhdnval').value).style.height=parseFloat(newpsize)+"cm";
                      
                    }   
                    if(unit==4)
                    {
                     var newpsize=parseFloat(document.getElementById('ad_height').value)-parseFloat(bsiz)-parseFloat(bsiz); 
                        document.getElementById(document.getElementById('myhdnval').value).style.height=parseFloat(newpsize)+"mm";
                       
                    }    
                
                }
            }
             if(unit==1)
                {
                 var psize=(parseInt(document.getElementById('input_wdth').value)+parseInt(bsiz)+parseInt(bsiz)) ;
                    if((parseInt(psize))>(parseInt(document.getElementById('ad_width').value)))  
                    {
                     var newpsize=parseInt(document.getElementById('ad_width').value)-parseInt(bsiz)-parseInt(bsiz);
                         document.getElementById(document.getElementById('myhdnval').value).style.width=parseInt(newpsize)+"px";
                        
                    }
                }
                else
                {
                 var psize=parseFloat(r_conversion(document.getElementById('input_wdth').value,unit))+parseFloat(r_conversion(bsiz,unit))+parseFloat(r_conversion(bsiz,unit));
                    if((parseFloat(psize))>(r_conversion(document.getElementById('ad_width').value,unit)))  
                     {
                        //alert('Height should not be greater then'+ parseInt(document.getElementById('ad_height').value))
                       
                        if(unit==2)
                        {
                        var newpsize=parseFloat(document.getElementById('ad_width').value)-parseFloat(bsiz)-parseFloat(bsiz);
                            document.getElementById(document.getElementById('myhdnval').value).style.width=parseFloat(newpsize)+"in";
                            
                        }   
                        if(unit==3)
                        {
                        var newpsize=parseFloat(document.getElementById('ad_width').value)-parseFloat(bsiz)-parseFloat(bsiz);
                            document.getElementById(document.getElementById('myhdnval').value).style.width=parseFloat(newpsize)+"cm";
                            moves();
                        }   
                        if(unit==4)
                        {
                        var newpsize=parseFloat(document.getElementById('ad_width').value)-parseFloat(bsiz)-parseFloat(bsiz);
                            document.getElementById(document.getElementById('myhdnval').value).style.width=parseFloat(newpsize)+"mm";
                        
                        
                        }    
                    
                    }
                }
//          if(parseInt(conversion(document.getElementById('input_hght').value,unit))>parseInt(conversion(document.getElementById('ad_height').value,unit)))  
//             {
//              //alert('Height should not be greater then'+ parseInt(document.getElementById('ad_height').value))
//              document.getElementById(document.getElementById('myhdnval').value).style.height=document.getElementById('ad_height').value+"px";
//              document.getElementById('input_hght').value=document.getElementById('ad_height').value;
//              //document.getElementById(document.getElementById('myhdnval').value).style.height=conversion(document.getElementById('ad_height').value,unit)
//            }
//          if(parseInt(conversion(document.getElementById('input_wdth').value,unit))>parseInt(conversion(document.getElementById('ad_width').value,unit)))
//            {
//              //alert('Width should not be greater then'+ parseInt(document.getElementById('ad_width').value))
//              document.getElementById(document.getElementById('myhdnval').value).style.width=document.getElementById('ad_width').value+"px";
//              document.getElementById('input_wdth').value=document.getElementById('ad_width').value;
//              //document.getElementById(document.getElementById('myhdnval').value).style.width=r_conversion(document.getElementById('ad_width').value,unit)
//            }    
            
          
            }
        }
        }
        catch(err){}
        
      
        }






/***************end of function ******************/         

function getdimsO()
{
if(conversion(parseInt(document.getElementById('outer').style.height),unit)==undefined)
        {
           document.getElementById('ad_height').value = "";
          }
else
{
    document.getElementById('ad_height').value=conversion(parseInt(document.getElementById('outer').style.height),unit);
}
if(conversion(parseInt(document.getElementById('outer').style.width),unit)==undefined)
{
        document.getElementById('ad_width').value = "";
}
else
   {
      document.getElementById('ad_width').value = conversion(parseInt(document.getElementById('outer').style.width),unit);
      }
if(conversion(parseInt(document.getElementById('outer').style.height),unit)==undefined)
  {
  document.getElementById('hghtsel').value=""
  
  } 
  
  else
  {
   document.getElementById('hghtsel').value=conversion(parseInt(document.getElementById('outer').style.height),unit);
  }
  
  
  if(conversion(parseInt(document.getElementById('outer').style.width),unit)==undefined)
   {
       document.getElementById('wdthsel').value=""
  
   }
  else
  {
  document.getElementById('wdthsel').value=conversion(parseInt(document.getElementById('outer').style.width),unit);
  }
 
}




/*******************************************/
function getdimsP()
{
   try
     {
    
        if(document.getElementById('myhdnval').value==null && document.getElementById('myhdnval').value==""){}
        else
         {
         if(document.all)
         {
         up();
            imgToolMenu.style.visibility = 'hidden';
            unit=parseInt(document.getElementById('sel_unit').value);
            document.getElementById('bsize_p').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.borderWidth),unit);
            document.getElementById('picboxprop_borderlist').value=document.getElementById(document.getElementById('myhdnval').value).style.borderStyle;
            document.getElementById('input_hghtP').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.height),unit);
            document.getElementById('input_wdthP').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.width),unit);
           //document.getElementById('sampleclrfont').style.backgroundColor=document.getElementById(currentid).style.color;
            document.getElementById('sampleclrbckP').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.backgroundColor;
            document.getElementById('sampleclrbrdrP').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.borderColor;
            document.getElementById('ad_height').value =conversion(parseInt(document.getElementById('outer').style.height),unit);
            document.getElementById('ad_width').value = conversion(parseInt(document.getElementById('outer').style.width),unit);
             document.getElementById('toolsbox_bgcolor').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.backgroundColor;
           document.getElementById('toolsbox_fcolor').style.backgroundColor="ButtonFace";
 
             
             up();
            
          if(parseInt(r_conversion(document.getElementById('input_hghtP').value,unit))>parseInt(r_conversion(document.getElementById('ad_height').value,unit))-1)  
             {
                //alert('Height should not be greater then'+ parseInt(document.getElementById('ad_height').value))
                document.getElementById(document.getElementById('myhdnval').value).style.height=r_conversion(document.getElementById('ad_height').value,unit)-1;
               // return false;
              }
          if(r_conversion(document.getElementById('input_wdthP').value,unit)>r_conversion(document.getElementById('ad_width').value,unit)-1)
               {
                  //alert('Width should not be greater then'+ parseInt(document.getElementById('ad_width').value))
                  //document.getElementById(currentid).style.width=parseInt(document.getElementById('ad_width').value-10)+"px";
                  document.getElementById(document.getElementById('myhdnval').value).style.width=r_conversion(document.getElementById('ad_width').value,unit)-1;
                  //return false;
               } 
          }
          else
          {
           
            document.getElementById('imgToolMenu').style.visibility = 'hidden';
            unit=parseInt(document.getElementById('sel_unit').value);
             document.getElementById('toolsbox_bgcolor').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.backgroundColor;
           document.getElementById('toolsbox_fcolor').style.backgroundColor="ButtonFace";
        // alert(document.getElementById('outer').style.height)
        //alert((document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth))
          var bsiz=((document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth));
         // alert(bsiz);
          if(bsiz.indexOf('px')>=0)
          {
            bsiz=bsiz.replace('px','');
            if(unit!=1)
            {
            bsiz=conversion(bsiz,unit);
            }
          }
            else if(unit==2)
            {
             bsiz=bsiz.replace('in','');
            }
            else if(unit==3)
            {
             bsiz=bsiz.replace('cm','');
            }
            
            else if(unit==4)
            {
             bsiz=bsiz.replace('mm','');
            }
            
           //alert(bsiz); 
          document.getElementById('bsize_p').value=bsiz;
          var border1=(document.getElementById(document.getElementById('myhdnval').value).style.borderStyle.split(' '));
          var bord=border1[1];
          document.getElementById('picboxprop_borderlist').value=bord;
          if((document.getElementById(document.getElementById('myhdnval').value).style.height).indexOf("px")>=0)
          {
          document.getElementById('input_hghtP').value=conversion(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('px','')),unit);
         // document.getElementById('input_wdthP').value=conversion(parseInt((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('px','')),unit);
          }
            else
            {
            if(unit==2)
            {
                document.getElementById('input_hghtP').value=(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('in','')));
            }
             if(unit==3)
            {
                document.getElementById('input_hghtP').value=(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('cm','')));
            }
             if(unit==4)
            {
                document.getElementById('input_hghtP').value=(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('mm','')));
            }
            }
         
         if((document.getElementById(document.getElementById('myhdnval').value).style.width).indexOf("px")>=0)
          {
         // alert(document.getElementById(document.getElementById('myhdnval').value).style.width);
          //document.getElementById('input_hghtP').value=conversion(parseInt((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('px','')),unit);
          document.getElementById('input_wdthP').value=conversion(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('px','')),unit);
          //alert(document.getElementById('input_wdthP').value)
          }
            else
            {
            if(unit==2)
            {
                document.getElementById('input_wdthP').value=(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('in','')));
            }
             if(unit==3)
            {
                //alert(document.getElementById(document.getElementById('myhdnval').value).style.width);
                document.getElementById('input_wdthP').value=(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('cm','')));
                //alert(document.getElementById('input_wdthP').value)
            }
             if(unit==4)
            {
                document.getElementById('input_wdthP').value=(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('mm','')));
            }
            
            }
         
         
            document.getElementById('sampleclrbckP').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.backgroundColor;
            var bordercol=(document.getElementById(document.getElementById('myhdnval').value).style.borderColor);
            if(bordercol.indexOf(')')>0)
            {
            var col1=document.getElementById(document.getElementById('myhdnval').value).style.borderColor.split(')');
            var col=col1[1]+')';
            }
            else
            {
            var col1=document.getElementById(document.getElementById('myhdnval').value).style.borderColor.split(' ');
            var col=col1[1];
            }
           //alert(col);
            document.getElementById('sampleclrbrdrP').style.backgroundColor=col;
            document.getElementById('ad_height').value =conversion((document.getElementById('outer').style.height.replace('px','')),unit);
            document.getElementById('ad_width').value = conversion((document.getElementById('outer').style.width.replace('px','')),unit);
 
//             alert((parseInt(document.getElementById('input_hghtP').value)+parseInt(bsiz)+parseInt(bsiz)-2))
//             var psize=(parseIt(document.getElementById('input_hghtP').value)+parseInt(bsiz)+parseInt(bsiz)-2)
                //alert(document.getElementById(document.getElementById('myhdnval').value).style.paddingTop);
                var ptop=document.getElementById(document.getElementById('myhdnval').value).style.paddingTop;
                var pleft=document.getElementById(document.getElementById('myhdnval').value).style.paddingLeft;
                var pright=document.getElementById(document.getElementById('myhdnval').value).style.paddingRight;
                var pbottom=document.getElementById(document.getElementById('myhdnval').value).style.paddingBottom;
            
                var pheight=0;
                if(ptop!="")
                {
                    if(pbottom!="")
                    {
                     var pheight=parseFloat(ptop)+parseFloat(pbottom);
                    }
                    else
                    {
                     var pheight=parseFloat(ptop);
                    }
                }
                else
                {
                     if(pbottom!="")
                    {
                     var pheight=parseFloat(pbottom);
                    }
                }
                var pwidth=0;
                if(pleft!="")
                {
                    if(pright!="")
                    {
                     var pwidth=parseFloat(pleft)+parseFloat(pright);
                    }
                    else
                    {
                     var pwidth=parseFloat(pleft);
                    }
                }
                else
                {
                     if(pbottom!="")
                    {
                     var pwidth=parseFloat(pright);
                    }
                }
               
                
//                if(unit!=1)
//                {
//                pheight=conversion(pheight,unit)
//                pwidth=conversion(pwidth,unit);
//                alert(pheight)
//                alert(pwidth)
//                }
//            if(pheight=="NaN")
//            {
//          alert("hello");
//            pheight=0;
//             alert(pheight)
//            }
//            if(pwidth=="NaN")
//            {
//            pwidth=0;
//            }
             up();
          if(unit==1)
                 { 
                     var psize=(parseInt(document.getElementById('input_hghtP').value)+parseInt(bsiz)+parseInt(bsiz)+parseInt(pheight)) 
                     //alert(psize);
                       if((parseInt(psize))>(parseInt(document.getElementById('ad_height').value)))
                       {
                       var newpsize=parseInt(document.getElementById('ad_height').value)-parseInt(bsiz)-parseInt(bsiz)-parseInt(pheight);
                      document.getElementById(document.getElementById('myhdnval').value).style.height=parseInt(newpsize)+"px";
                      //document.getElementById('input_wdthP').value=document.getElementById('ad_width').value;
                     
                      document.getElementById(document.getElementById('myhdnval').value+"pic").style.height=parseInt(newpsize)+"px";
                      
                       moves();
                       
                       }
                 }
                 else
                 {   
            var psize=parseFloat(r_conversion(document.getElementById('input_hghtP').value,unit))+parseFloat(r_conversion(bsiz,unit))+parseFloat(r_conversion(bsiz,unit))+parseFloat(r_conversion(pheight,unit));
          if((parseFloat(psize))>parseFloat(r_conversion(document.getElementById('ad_height').value,unit)))  
             {
                //alert('Height should not be greater then'+ parseInt(document.getElementById('ad_height').value))
               
                if(unit==2)
                {
                var newpsize=parseFloat(document.getElementById('ad_height').value)-parseFloat(bsiz)-parseFloat(bsiz)-parseFloat(pheight);
                    document.getElementById(document.getElementById('myhdnval').value).style.height=parseFloat(newpsize)+"in";
                    //document.getElementById('input_hghtP').value=document.getElementById('ad_height').value;
                    if( document.getElementById(document.getElementById('myhdnval').value+"pic")!=null)
                      {
                      document.getElementById(document.getElementById('myhdnval').value+"pic").style.height=parseFloat(newpsize)+"in";
                      }
                      
                      //alert(document.getElementById(document.getElementById('myhdnval').value).style.height);
                }  
                if(unit==3)
                {
                var newpsize=parseFloat(document.getElementById('ad_height').value)-parseFloat(bsiz)-parseFloat(bsiz)-parseFloat(pheight);
                    document.getElementById(document.getElementById('myhdnval').value).style.height=parseFloat(newpsize)+"cm";
                    //document.getElementById('input_hghtP').value=document.getElementById('ad_height').value;
                    if( document.getElementById(document.getElementById('myhdnval').value+"pic")!=null)
                      {
                      document.getElementById(document.getElementById('myhdnval').value+"pic").style.height=parseFloat(newpsize)+"cm";
                      }
                      
                }        
                if(unit==4)
                {
                var newpsize=parseFloat(document.getElementById('ad_height').value)-parseFloat(bsiz)-parseFloat(bsiz)-parseFloat(pheight);
                    document.getElementById(document.getElementById('myhdnval').value).style.height=parseFloat(newpsize)+"mm";
                   //s document.getElementById('input_hghtP').value=document.getElementById('ad_height').value;
                    if( document.getElementById(document.getElementById('myhdnval').value+"pic")!=null)
                      {
                      document.getElementById(document.getElementById('myhdnval').value+"pic").style.height=parseFloat(newpsize)+"mm";
                      }
                       
                }                     
               // return false;
              }
              }
//              alert(document.getElementById('input_wdthP').value)
//              alert(document.getElementById('ad_width').value)
             if(unit==1)
                 { 
                 var psize=(parseInt(document.getElementById('input_wdthP').value)+parseInt(bsiz)+parseInt(bsiz)+parseInt(pwidth)) ;
                         if((parseInt(psize))>(parseInt(document.getElementById('ad_width').value)))
                       {
                        var newpsize=parseInt(document.getElementById('ad_width').value)-parseInt(bsiz)-parseInt(bsiz)-parseInt(pwidth);
                        document.getElementById(document.getElementById('myhdnval').value).style.width=parseInt(newpsize)+"px";
                      //document.getElementById('input_wdthP').value=document.getElementById('ad_width').value;
                     
                      document.getElementById(document.getElementById('myhdnval').value+"pic").style.width=parseInt(newpsize)+"px";
                      
                       moves();
                       
                       }
                 }
                 else
                 {
                var psize=parseFloat(r_conversion(document.getElementById('input_wdthP').value,unit))+parseFloat(r_conversion(bsiz,unit))+parseFloat(r_conversion(bsiz,unit))+parseFloat(r_conversion(pwidth,unit));
                      if((parseFloat(psize))>parseFloat(r_conversion(document.getElementById('ad_width').value,unit)))
                           {
                          //alert("in getdims width")
                              //alert('Width should not be greater then'+ parseInt(document.getElementById('ad_width').value))
                              //document.getElementById(currentid).style.width=parseInt(document.getElementById('ad_width').value-10)+"px";
                             
                                  
                            
                             if(unit==2)
                             { 
                             var newpsize=parseFloat(document.getElementById('ad_width').value)-parseFloat(bsiz)-parseFloat(bsiz)-parseFloat(pwidth);
                                  document.getElementById(document.getElementById('myhdnval').value).style.width=parseFloat(newpsize)+"in";
                                  //document.getElementById('input_wdthP').value=document.getElementById('ad_width').value;
                                  if( document.getElementById(document.getElementById('myhdnval').value+"pic")!=null)
                                  {
                                  document.getElementById(document.getElementById('myhdnval').value+"pic").style.width=parseFloat(newpsize)+"in";
                                  }
                                   
                             }
                             if(unit==3)
                             { 
                              var newpsize=parseFloat(document.getElementById('ad_width').value)-parseFloat(bsiz)-parseFloat(bsiz)-parseFloat(pwidth);
                             // alert(newpsize);
                                  document.getElementById(document.getElementById('myhdnval').value).style.width=parseFloat(newpsize)+"cm";
                                 // alert(document.getElementById(document.getElementById('myhdnval').value).style.width)
                                  //document.getElementById('input_wdthP').value=document.getElementById('ad_width').value;
                                  if( document.getElementById(document.getElementById('myhdnval').value+"pic")!=null)
                                  {
                                  document.getElementById(document.getElementById('myhdnval').value+"pic").style.width=parseFloat(newpsize)+"cm";
                                  }
                                  
                             }
                             if(unit==4)
                             { 
                              var newpsize=parseFloat(document.getElementById('ad_width').value)-parseFloat(bsiz)-parseFloat(bsiz)-parseFloat(pwidth);
                                  document.getElementById(document.getElementById('myhdnval').value).style.width=parseFloat(newpsize)+"mm";
                                //  document.getElementById('input_wdthP').value=document.getElementById('ad_width').value;
                                  if( document.getElementById(document.getElementById('myhdnval').value+"pic")!=null)
                                  {
                                  document.getElementById(document.getElementById('myhdnval').value+"pic").style.width=parseFloat(newpsize)+"mm";
                                  }
                                  
                             }
                              //return false;
                           }
               } 
           up();
           moves();
          }
               
           } 
        }
        catch(err){}  
}




/*********************** this ocde for moves element**************/
function moves()
 {
    // alert('move');
     var browser=navigator.appName;
     if(browser=="Microsoft Internet Explorer")
     {
        try
         {
           if(document.getElementById('myhdnval').value==null || document.getElementById('myhdnval').value==""){}
             else
              {
                    up();
                    var xval=document.getElementById(document.getElementById('myhdnval').value).offsetLeft;
                    var yval=document.getElementById(document.getElementById('myhdnval').value).offsetTop;
//                  var ajayk=document.getElementById(document.getElementById('xyhidden').value).offestLeft;
//                  var ajay1=document.getElementById(document.getElementById('xyhidden').value).offestTop;
                    unit= document.getElementById('sel_unit').value;
                    document.getElementById('xvalue').value=conversion(xval,unit);
                    document.getElementById('yvalue').value=conversion(yval,unit);
                    //document.getElementById('selectedwidth').value=document.getElementById(document.getElementById('myhdnval').value).style.width.replace("px","");
                    document.getElementById('hghtsel').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("px",""),unit);
                    document.getElementById('wdthsel').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("px",""),unit);
                    return;
                                        //document.getElementById('input_hghtL').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("px",""),unit);
                  //  document.getElementById('input_wdthL').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("px",""),unit);
                
                }
        }
      catch(err){}
    }
else if(browser!="Microsoft Internet Explorer")
  {
  //alert('movefunct')
 // alert(browser)
    try
         {
           if(document.getElementById('myhdnval').value==null || document.getElementById('myhdnval').value==""){}
             else
              {
                    var xval=document.getElementById(document.getElementById('myhdnval').value).offsetLeft;
                    //alert(xval)
                    var yval=document.getElementById(document.getElementById('myhdnval').value).offsetTop;
                    //alert(yval)
            
                    document.getElementById('xvalue').value=conversion(xval,unit);
                   // alert(document.getElementById('xvalue').value)
                    
                    document.getElementById('yvalue').value=conversion(yval,unit);
                    //alert(document.getElementById('yvalue').value)
                    //document.getElementById('hghtsel').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("px",""),unit);
                   // document.getElementById('selectedheight').value=document.getElementById(document.getElementById('myhdnval').value).style.height.replace("px","");
                   
                    //document.getElementById('selectedwidth').value=document.getElementById(document.getElementById('myhdnval').value).style.width.replace("px","");
                    //alert(conversion(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("px",""),unit));
//                    document.getElementById('hghtsel').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("px",""),unit);
//                    //alert(document.getElementById('hghtsel').value);
//                    document.getElementById('wdthsel').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("px",""),unit);
//                    //alert("width");
                    //alert(document.getElementById('wdthsel').value);
                    if(document.getElementById(document.getElementById('myhdnval').value).style.height.indexOf('px')>=0)
                    {
                    //alert(conversion(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("px",""),unit));
                    document.getElementById('hghtsel').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("px",""),unit);
                    //document.getElementById('wdthsel').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("px",""),unit);
                    }
                    else
                    {
                    if(unit==2)
                    {
                       // alert((document.getElementById(document.getElementById('myhdnval').value).style.height).replace("in",""))
                        document.getElementById('hghtsel').value=(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("in",""));
                   //document.getElementById('wdthsel').value=(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("in",""));
                    }
                     if(unit==3)
                    {
                        document.getElementById('hghtsel').value=(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("cm",""));
                   //document.getElementById('wdthsel').value=(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("in",""));
                    }
                     if(unit==4)
                    {
                        document.getElementById('hghtsel').value=(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("mm",""));
                   //document.getElementById('wdthsel').value=(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("in",""));
                    }
                    }
                    
                    if(document.getElementById(document.getElementById('myhdnval').value).style.width.indexOf('px')>=0)
                    {
                   // document.getElementById('hghtsel').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("px",""),unit);
                  // alert(conversion(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("px",""),unit))
                    document.getElementById('wdthsel').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("px",""),unit);
                    }
                    else
                    {
                    if(unit==2)
                    {
                       // alert((document.getElementById(document.getElementById('myhdnval').value).style.width).replace("in",""))
                   //     document.getElementById('hghtsel').value=(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("in",""));
                   document.getElementById('wdthsel').value=(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("in",""));
                    }
                     if(unit==3)
                    {
                   //     document.getElementById('hghtsel').value=(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("cm",""));
                   document.getElementById('wdthsel').value=(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("cm",""));
                    }
                     if(unit==4)
                    {
                   //     document.getElementById('hghtsel').value=(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("mm",""));
                   document.getElementById('wdthsel').value=(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("mm",""));
                    }
                    }
                
                }
        }
      catch(err){}

   }
   
 }
/*******************************/
function showprop(obj)
{
var browser=navigator.appName;
if(browser=="Microsoft Internet Explorer")
 {
    gethtml=obj.outerHTML;
    var Temp = new Array();
    selected_element=obj.id;
    if(selected_element.indexOf("Txt")>=0)
     {
       opentxtdialog()
     }
    else if(selected_element.indexOf("picture")>=0){openpicdialog()}
    else if(selected_element.indexOf("line")>=0){
    openlinedialog()}
  }
  else if(browser!="Microsoft Internet Explorer")
  {
    gethtml=obj.outerHTML;
    var Temp = new Array();
    selected_element=obj.id;
    if(selected_element.indexOf("Txt")>=0)
     {
       opentxtdialog()
     }
    else if(selected_element.indexOf("picture")>=0){openpicdialog()}
    else if(selected_element.indexOf("line")>=0){
    openlinedialog()}
  }
}
/***********************************************/
function createlayout()
 {
   //alert('ajay');
   var browser=navigator.appName;
   if(browser!="Microsoft Internet Explorer")
   {
    if(flagnew==0)
       {     
          //alert('ajay2');
          document.getElementById('popups').style.display="block";
          document.getElementById('rotatediv').style.display='none';
          document.getElementById('stretchdiv').style.display='none';
          document.getElementById('tagsdiv').style.display='none';
          document.getElementById('linedialog').style.display='none';
          document.getElementById('picdialog').style.display="none";
          document.getElementById('spltg').style.display="none";
          document.getElementById('configdiv').style.display='none';
          document.getElementById('pic').checked='';
          document.getElementById('textdialog').style.display="none";
          document.getElementById('opendialog').style.display="none";
          document.getElementById('openaddialog').style.display="none";
          document.getElementById('opendialog1').style.display="none";
          document.getElementById('newdialog').style.display="block";
          document.getElementById('txt').checked='checked';
          document.getElementById('toolsbox_fcolor').disabled="disabled";
          document.getElementById('edittemplate').disabled=true;
          flagtxt=0;
          flagpic=0;
          flagnew=0;
          document.getElementById('img1').style.borderColor='buttonface';
          document.getElementById('img2').style.borderColor='buttonface';
          document.getElementById('img4').style.borderColor='buttonface';
          document.getElementById('img5').style.borderColor='buttonface'; 
          document.getElementById('xvalue').value="";
          document.getElementById('yvalue').value="";
          document.getElementById('hghtsel').value="";
          document.getElementById('wdthsel').value=""; 
          document.getElementById('myhdnval').value="";           
          currentid = null;
          document.getElementById('units').value=1;
          document.getElementById('hghtTemp').value=330;
          document.getElementById('wdthTemp').value=660;
          document.getElementById('landscape').checked="true";
          document.getElementById('savesT').onclick=null;
          document.getElementById('savesT').style.cursor="pointer";
          document.getElementById('applylink').style.visibility="hidden";
	  document.getElementById('imgToolMenu').style.visibility="hidden";
     document.getElementById('toolsbox_fcolor').style.backgroundColor="ButtonFace";
     document.getElementById('toolsbox_bgcolor').style.backgroundColor="ButtonFace";	
       }
  }
  else if(browser=="Microsoft Internet Explorer")
      {
          document.getElementById('popups').style.display="block";
          document.getElementById('rotatediv').style.display='none';
          document.getElementById('stretchdiv').style.display='none';
          document.getElementById('tagsdiv').style.display='none';
          document.getElementById('linedialog').style.display='none';
          document.getElementById('picdialog').style.display="none";
          document.getElementById('spltg').style.display="none";
          document.getElementById('configdiv').style.display='none';
          document.getElementById('pic').checked='';
          document.getElementById('textdialog').style.display="none";
          document.getElementById('opendialog').style.display="none";
          document.getElementById('openaddialog').style.display="none";
          document.getElementById('opendialog1').style.display="none";
          document.getElementById('newdialog').style.display="block";
           document.getElementById('xvalue').value="";
           document.getElementById('yvalue').value="";
            document.getElementById('hghtsel').value="";
             document.getElementById('wdthsel').value=""; 
             document.getElementById('myhdnval').value="";   
          document.getElementById('txt').checked='checked';
          document.getElementById('img1').style.borderColor='buttonface';
          document.getElementById('img2').style.borderColor='buttonface';
          document.getElementById('img4').style.borderColor='buttonface';
          document.getElementById('img5').style.borderColor='buttonface';
          flagtxt=0;
          flagpic=0;
          flagnew=0;         
          currentid = null;
          document.getElementById('units').value=1;
          document.getElementById('hghtTemp').value=330;
          document.getElementById('wdthTemp').value=660;
          document.getElementById('landscape').checked="true";
          document.getElementById('applylink').style.visibility="hidden";
	document.getElementById('imgToolMenu').style.visibility="hidden";
     document.getElementById('toolsbox_fcolor').style.backgroundColor="ButtonFace";
     document.getElementById('toolsbox_bgcolor').style.backgroundColor="ButtonFace";
      }
}
function openlinedialog()
   {
     var browser=navigator.appName;
     if(browser!="Microsoft Internet Explorer")
     {
     if(flagline==0)
     {  
        //document.getElementById('popups').style.display="block";
        document.getElementById('rotatediv').style.display='none';
        document.getElementById('stretchdiv').style.display='none';
        document.getElementById('textdialog').style.display='none';
        document.getElementById('spltg').style.display="none";
        document.getElementById('txt').checked='';
        document.getElementById('tagsdiv').style.display='none';
        document.getElementById('newdialog').style.display="none";
        document.getElementById('opendialog').style.display="none";
        document.getElementById('opendialog1').style.display="none";
        document.getElementById('picdialog').style.display='none';
        document.getElementById('linedialog').style.display='block';
        document.getElementById('configdiv').style.display='none';
        document.getElementById('pic').checked='checked';
        //document.getElementById('colorcodeT_B').style.display='none';
        //document.getElementById('colorcodeT_B').disabled=true;
        flagpic=0;
        flagtxt=0;
        flagline=1;
       }
   }
  else if(browser=="Microsoft Internet Explorer")
  {
     if(flagline==0)
     {  
        document.getElementById('rotatediv').style.display='none';
        document.getElementById('stretchdiv').style.display='none';
        document.getElementById('textdialog').style.display='none';
        document.getElementById('spltg').style.display="none";
        document.getElementById('txt').checked='';
        document.getElementById('tagsdiv').style.display='none';
        document.getElementById('newdialog').style.display="none";
        document.getElementById('opendialog').style.display="none";
        document.getElementById('opendialog1').style.display="none";
        document.getElementById('picdialog').style.display='none';
        document.getElementById('linedialog').style.display='block';
        document.getElementById('configdiv').style.display='none';
        document.getElementById('pic').checked='checked';
        flagpic=0;
        flagtxt=0;
        flagline=1;
      }
  }
 }  


function openlayout()
  {
        if(openlayouts &&!openlayouts.closed){
            openlayouts.focus();
         }else{
         document.getElementById('popups').style.display='block';
         document.getElementById('opendialog').style.display='block';
         document.getElementById('opendialog1').style.display='none';
         document.getElementById('openaddialog').style.display="none";
         //document.getElementById('popups').style.display="block";
            document.getElementById('rotatediv').style.display='none';
            document.getElementById('stretchdiv').style.display='none';
             document.getElementById('linedialog').style.display='none';
             document.getElementById('spltg').style.display="none";
            document.getElementById('tagsdiv').style.display='none';
            document.getElementById('picdialog').style.display="none";
            document.getElementById('configdiv').style.display='none';
            document.getElementById('newdialog').style.display='none';
            //document.getElementById('pic').checked='';
            document.getElementById('textdialog').style.display="none";
            document.getElementById('newdialog').style.display="none";
            
            _Default.bindxml(call);
            //document.getElementById('opendialog').location.reload(true);
            //document.getElementById('opendialog').location = document.getElementById('opendialog').location;
            //document.getElementById('txt').checked='checked';
         //alert(openTemplate_xmllist2);
        // document.getElementById('fetchid').value =1 ;
        /*openlayouts=window.open('openlayout.aspx','','left=735,top=260,width=230px,height=320px,titlebar=0');*/
        //openalyouts.focus();
        //window.showModalDialog ('openlayout.aspx','openlayout','dialogHeight:250px;dialogWidth:500px;scroll:no;status:off');
        }
}

function call(response)
{
        //alert('ankur2');
        //openTemplate$xmllist2
        //xmllist2.Items.Clear();
        //for (int a = 0; a <= ds.Tables[0].Rows.Count - 1; a++)
        //{
        //    ListItem li = new ListItem();
        //    li.Text = ds.Tables[0].Rows[a].ItemArray[0].ToString();
        //    li.Value = ds.Tables[0].Rows[a].ItemArray[0].ToString();
        //    //string[] temp = li.Value.Split('\\');
        //    //string[] temp2 = temp[2].Split('.');
        //    //string filename = temp2[0];
        //    xmllist2.Items.Add(li);
        //}
        var ds = response.value;
        var xmlid = document.getElementById('openTemplate_xmllist');
        //openTemplate_xmllist2.Items.Clear();
        xmlid.options.length = 0; 
       // xmlid.options[0]=new Option("-Select Client-","0");
        for (var a = 0; a <= ds.Tables[0].Rows.length - 1; a++)
        {
            xmlid.options[xmlid.options.length] = new Option(ds.Tables[0].Rows[a].name,ds.Tables[0].Rows[a].name);
        
            xmlid.options.length;
            //ListItem li = new ListItem();
            //li.Text = ds.Tables[0].Rows[a].ItemArray[0].ToString();
            //li.Value = ds.Tables[0].Rows[a].ItemArray[0].ToString();
            //string[] temp = li.Value.Split('\\');
            //string[] temp2 = temp[2].Split('.');
            //string filename = temp2[0];
            //openTemplate$xmllist2.Items.Add(li);
        }
}



function openlayout1(){
        try{
        
            if(openlayouts &&!openlayouts.closed){
            openlayouts.focus();
            }else{
             document.getElementById('openTemplate1_catname').options[0].selected=true
            document.getElementById('popups').style.display='block';
            document.getElementById('opendialog1').style.display='block';
            document.getElementById('opendialog').style.display='none';
            document.getElementById('linedialog').style.display='none';
             document.getElementById('openaddialog').style.display="none";
         //document.getElementById('popups').style.display="block";
            document.getElementById('rotatediv').style.display='none';
            document.getElementById('spltg').style.display="none";
            document.getElementById('stretchdiv').style.display='none';
            document.getElementById('tagsdiv').style.display='none';
            document.getElementById('picdialog').style.display="none";
            document.getElementById('configdiv').style.display='none';
            document.getElementById('newdialog').style.display='none';
            //document.getElementById('pic').checked='';
            document.getElementById('textdialog').style.display="none";
            document.getElementById('newdialog').style.display="none";
            enabled();
             document.getElementById('edittemplate').onclick=ignoreClick;
         document.getElementById('edittemplate').style.cursor="text";
            ad_template=1;
            template_ads();
            //document.getElementById('txt').checked='checked';
            document.getElementById('fetchid').value ="";
            if(document.getElementById('hiddencat').value!="")
            {
            _Default.bindtemplate(document.getElementById('hiddencat').value,temp_callback);
            }
            else
            {
                _Default.bindxml(call1);
                //_Default.binddrpname(call1);
            }
        /*openlayouts=window.open('openlayout.aspx','','left=735,top=260,width=230px,height=320px,titlebar=0');*/
        //openalyouts.focus();
        //window.showModalDialog ('openlayout.aspx','openlayout','dialogHeight:250px;dialogWidth:500px;scroll:no;status:off');
        }
      }
      catch(er){}
}

function call1(response)
   {
          //alert('ajay3');
          //openTemplate$xmllist2
         //xmllist2.Items.Clear();
        //for (int a = 0; a <= ds.Tables[0].Rows.Count - 1; a++)
        //{
        //    ListItem li = new ListItem();
        //    li.Text = ds.Tables[0].Rows[a].ItemArray[0].ToString();
        //    li.Value = ds.Tables[0].Rows[a].ItemArray[0].ToString();
        //    //string[] temp = li.Value.Split('\\');
        //    //string[] temp2 = temp[2].Split('.');
        //    //string filename = temp2[0];
        //    xmllist2.Items.Add(li);
        //}
  var ds = response.value;
  var xmlid = document.getElementById('openTemplate1_xmllist1');
  //openTemplate_xmllist2.Items.Clear();
  xmlid.options.length = 0; 
  // xmlid.options[0]=new Option("-Select Client-","0");
  for (var a = 0; a <= ds.Tables[0].Rows.length - 1; a++)
   {
     //alert('ajay3-1');
     xmlid.options[xmlid.options.length] = new Option(ds.Tables[0].Rows[a].name,ds.Tables[0].Rows[a].name);
     xmlid.options.length;
     //ListItem li = new ListItem();
     //li.Text = ds.Tables[0].Rows[a].ItemArray[0].ToString();
     //li.Value = ds.Tables[0].Rows[a].ItemArray[0].ToString();
     //string[] temp = li.Value.Split('\\');
     //string[] temp2 = temp[2].Split('.');
     //string filename = temp2[0];
    //openTemplate$xmllist2.Items.Add(li);
  }
}
// function getadhtm1() {
//   try{
//        if(document.getElementById('openads_xmllist3').value==""){
//            alert("No Template Selected !");
//            return false;
//        }
//        var xmlid=document.getElementById('openads_xmllist3').value;
//        _Default.getadvalue(xmlid,call_adreferrence1);
//        //openlayout.getthevalue(xmlid,call_referrence);
//            //   currentid='outer';
//        return false;
//       }
//       catch (er){return false;}
//       
//     }
//     function call_adreferrence1(response){
//      var ds=response.value;
//        var abc=ds.Tables[0].Rows[0].ad_html;
//        var id=ds.Tables[0].Rows[0].ad_id;/* changes occurred when page change to Uctrl*/
//        /*opener.*/document.getElementById('temp_id').value="";
//        /*opener.*/document.getElementById('temp_id').value=id;
//        /*opener.*/document.getElementById('fetchid1').value=1;
//        var count=abc.split("</DIV>");
//        /*opener.*/document.getElementById('ctrval').value = count.length;
//        enabled();
//        /*window.opener.*/document.getElementById('editordiv').innerHTML=abc;
//        return currentid;
//     } 
   
  
  function open_ads()
  {
  
        if(openlayouts &&!openlayouts.closed){
            openlayouts.focus();
         }else{
         document.getElementById('popups').style.display='block';
         document.getElementById('openaddialog').style.display='block';
         document.getElementById('opendialog1').style.display='none';
         document.getElementById('opendialog').style.display='none';
         //document.getElementById('popups').style.display="block";
            document.getElementById('rotatediv').style.display='none';
            document.getElementById('spltg').style.display="none";
            document.getElementById('stretchdiv').style.display='none';
            document.getElementById('tagsdiv').style.display='none';
            document.getElementById('picdialog').style.display="none";
             document.getElementById('linedialog').style.display='none';
            document.getElementById('configdiv').style.display='none';
            document.getElementById('newdialog').style.display='none';
            //document.getElementById('pic').checked='';
            document.getElementById('textdialog').style.display="none";
            document.getElementById('newdialog').style.display="none";
            
            ad_template=1;
            template_ads();
            document.getElementById('edittemplate').onclick=ignoreClick;
         document.getElementById('edittemplate').style.cursor="text";
//            alert('openad');
            _Default.bindadxml(call2);
            //document.getElementById('opendialog').location.reload(true);
            //document.getElementById('opendialog').location = document.getElementById('opendialog').location;
            //document.getElementById('txt').checked='checked';
         //alert(openTemplate_xmllist2);
        // document.getElementById('fetchid').value =1 ;
        /*openlayouts=window.open('openlayout.aspx','','left=735,top=260,width=230px,height=320px,titlebar=0');*/
        //openalyouts.focus();
        //window.showModalDialog ('openlayout.aspx','openlayout','dialogHeight:250px;dialogWidth:500px;scroll:no;status:off');
        }
}

function call2(response)
{
//alert('callback');
//openTemplate$xmllist2
//xmllist2.Items.Clear();
        //for (int a = 0; a <= ds.Tables[0].Rows.Count - 1; a++)
        //{
        //    ListItem li = new ListItem();
        //    li.Text = ds.Tables[0].Rows[a].ItemArray[0].ToString();
        //    li.Value = ds.Tables[0].Rows[a].ItemArray[0].ToString();
        //    //string[] temp = li.Value.Split('\\');
        //    //string[] temp2 = temp[2].Split('.');
        //    //string filename = temp2[0];
        //    xmllist2.Items.Add(li);
        //}
        var ds = response.value;
        var xmlid = document.getElementById('openads_xmllist3');
        //openTemplate_xmllist2.Items.Clear();
        xmlid.options.length = 0; 
        //xmlid.options[0]=new Option("-Select Client-","0");
        for (var a = 0; a <= ds.Tables[0].Rows.length - 1; a++)
        {
            xmlid.options[xmlid.options.length] = new Option(ds.Tables[0].Rows[a].name,ds.Tables[0].Rows[a].name);
        
       xmlid.options.length;
           
        }
}
  
             
function config(){
        document.getElementById('popups').style.display="block";
        document.getElementById('spltg').style.display="none";
        document.getElementById('stretchdiv').style.display='none';
        document.getElementById('textdialog').style.display='none';
         document.getElementById('openaddialog').style.display="none";
        document.getElementById('opendialog').style.display="none";
        document.getElementById('opendialog1').style.display="none";
         document.getElementById('linedialog').style.display='none';
        document.getElementById('txt').checked='';
        document.getElementById('pic').checked='';
        document.getElementById('newdialog').style.display="none";
        document.getElementById('picdialog').style.display='none';
        document.getElementById('tagsdiv').style.display='none';
        document.getElementById('rotatediv').style.display='none';
        document.getElementById('configdiv').style.display='block';
         //x= window.showModelessDialog('settings.aspx','title','dialogLeft:770px;dialogHeight:170px;dialogWidth:230px;scroll:no;status:off');
          }
function opentxtdialog(){
        try{
            if(flagtxt==0){ 
            
            var ht1=document.getElementById('editordiv').innerHTML;   
            //alert(ht1);        
            if(ht1.indexOf('~text')>=0)
            {
            
            document.getElementById('popups').style.display="block";
            document.getElementById('rotatediv').style.display='none';
            document.getElementById('stretchdiv').style.display='none';
            document.getElementById('spltg').style.display="none";
            document.getElementById('tagsdiv').style.display='none';
             document.getElementById('openaddialog').style.display="none";
            document.getElementById('opendialog').style.display="none";
            document.getElementById('opendialog1').style.display="none";
            document.getElementById('picdialog').style.display="none";
             document.getElementById('linedialog').style.display='none';
            document.getElementById('configdiv').style.display='none';
            document.getElementById('pic').checked='';
            document.getElementById('textdialog').style.display="block";
            document.getElementById('newdialog').style.display="none";
            document.getElementById('txt').checked='checked';
            flagtxt=1;
            flagpic=0;
            flagline=0;
            }
            else
            {
            //alert("No TextBox");
            }
            }
            else{
            
            flagtxt=0;
            document.getElementById('txt').checked='';
            document.getElementById('textdialog').style.display="block";
            }
      }catch(er){}
 }             
function openpicdialog()
 {
        try{
        
            if(flagpic==0){  
            var ht1=document.getElementById('editordiv').innerHTML;   
            //alert(ht1);        
            if(ht1.indexOf('~picture')>=0)
            {
            document.getElementById('configdiv').style.display='none';
            document.getElementById('popups').style.display="block";
            document.getElementById('rotatediv').style.display='none';
            document.getElementById('spltg').style.display="none";
            document.getElementById('stretchdiv').style.display='none';
             document.getElementById('openaddialog').style.display="none";
            document.getElementById('textdialog').style.display='none';
            document.getElementById('txt').checked='';
            document.getElementById('tagsdiv').style.display='none';
             document.getElementById('linedialog').style.display='none';
            document.getElementById('newdialog').style.display="none";
            document.getElementById('opendialog').style.display="none";
            document.getElementById('opendialog1').style.display="none";
            document.getElementById('picdialog').style.display='block';
            document.getElementById('pic').checked='checked';
             flagpic=1;
            flagtxt=0;
            flagline=0;
            }
            else
            {
            //alert("No ImageBox");
            }
          
            }else{
            //alert("hi in pic")
            document.getElementById('picdialog').style.display='block';
            flagpic=0;
            document.getElementById('pic').checked='';
            }
        }
        catch(er){}
        /*if (popuppic &&!popuppic.closed){
           popuppic.focus();
           }
           else{
           popuppic =window.open('picdialog.aspx','','left=750px,top=250px,height=280px,width=230px,scroll=no,status=off');
           aa= document.getElementById('pic');
           aa.checked='checked'; 
           popuppic.focus();
           }*/
       }

 function rotatedialog()
 {
  var browser=navigator.appName;
  if(browser=="Microsoft Internet explorer")
  {
        try
        {
            document.getElementById('popups').style.display="block";
            document.getElementById('configdiv').style.display='none';
            document.getElementById('stretchdiv').style.display='none';
            document.getElementById('textdialog').style.display='none';
            document.getElementById('spltg').style.display="none";
             document.getElementById('openaddialog').style.display="none";
             document.getElementById('linedialog').style.display='none';
            document.getElementById('txt').checked='';
            document.getElementById('pic').checked='';
            document.getElementById('picdialog').style.display='none';
            document.getElementById('opendialog').style.display="none";
            document.getElementById('opendialog1').style.display="none";
            document.getElementById('newdialog').style.display="none";
            flagpic=0;
            document.getElementById('tagsdiv').style.display='none';
            document.getElementById('rotatediv').style.display='block';
        }
        catch(er){}
 }  
 else if(browser!="Microsoft Internet explorer")
   {
    if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
        {
        try
        {
            document.getElementById('popups').style.display="block";
            document.getElementById('configdiv').style.display='none';
            document.getElementById('stretchdiv').style.display='none';
            document.getElementById('textdialog').style.display='none';
            document.getElementById('spltg').style.display="none";
             document.getElementById('openaddialog').style.display="none";
             document.getElementById('linedialog').style.display='none';
            document.getElementById('txt').checked='';
            document.getElementById('pic').checked='';
            document.getElementById('picdialog').style.display='none';
            document.getElementById('opendialog').style.display="none";
            document.getElementById('opendialog1').style.display="none";
            document.getElementById('newdialog').style.display="none";
            flagpic=0;
            document.getElementById('tagsdiv').style.display='none';
            document.getElementById('rotatediv').style.display='block';
        }
        catch(er){}
   }
 }
}
/*****************************/
var flagflip=0;
function flipHor()
{
  
  var browser=navigator.appName;
  if(browser!="Microsoft Internet Explorer")
    {
        if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
         {
          alert("Mozilla does not support this feature");
         }
    }
  else if(browser=="Microsoft Internet Explorer")
    {
      if(currentid==null || currentid=='editordiv')
         {
           alert('Item not Selected or Exist !');
         }
        else
        {
            if(flagflip==0)
             {
                document.getElementById(currentid).style.filter='progid:DXImageTransform.Microsoft.BasicImage(mirror=1)';
                flagflip=1;
             }
            else
             {
                document.getElementById(currentid).style.filter='progid:DXImageTransform.Microsoft.BasicImage(mirror=0)';
                flagflip=0;
             }
         }  
    }
  } 
/*********************************************/
function turn90(e){
//var browser= navigator.appName;
//if(browser!="microsoft Internet Explorer")
//{
 if(document.all)
 { 
   if(document.getElementById('myhdnval').value=="" || document.getElementById('myhdnval').value=='outer'){
        //alert(document.getElementById('myhdnval').value)
        alert('Ad Size Can Not Rotate!');
    }else{
        if(document.getElementById('myhdnval').value!="outer")
        {
            //alert(document.getElementById('myhdnval').value)
            if(document.getElementById('rotprop_radio0').checked==true)
            {
                
                //alert(document.getElementById('rotprop_radio0'))
                document.getElementById(document.getElementById('myhdnval').value).style.filter='progid:DXImageTransform.Microsoft.BasicImage(rotation=0)';
                //alert(document.getElementById(document.getElementById('myhdnval').value))
                flagtxt=0;
                flagpic=0;
                flagline=0;
               
                //return false;
            }
            if (document.getElementById('rotprop_radio90').checked==true)
            {   
                if(parseInt(conversion(document.getElementById(document.getElementById('myhdnval').value).style.width,unit))>parseInt(conversion(document.getElementById('outer').style.height,unit)))
                {
                    
                    document.getElementById(document.getElementById('myhdnval').value).style.width=parseInt(conversion(parseInt(document.getElementById('outer').style.height)-10,unit));
                }
                 if(parseInt(conversion(document.getElementById(document.getElementById('myhdnval').value).style.height,unit))>parseInt(conversion(document.getElementById('outer').style.width,unit)))
                {
                    document.getElementById(document.getElementById('myhdnval').value).style.height=parseInt(conversion(parseInt(document.getElementById('outer').style.width)-10,unit));
                }
                document.getElementById(document.getElementById('myhdnval').value).style.filter='progid:DXImageTransform.Microsoft.BasicImage(rotation=1)';
                flagtxt=0;
                flagpic=0;
                flagline=0;
               // return false;
            }
            if (document.getElementById('rotprop_radio180').checked==true)
            {
                document.getElementById(document.getElementById('myhdnval').value).style.filter='progid:DXImageTransform.Microsoft.BasicImage(rotation=2)';
                flagtxt=0;
                flagpic=0;
                flagline=0;
               // return false;
            }
            if (document.getElementById('rotprop_radio270').checked==true)
            {
                if(parseInt(conversion(document.getElementById(document.getElementById('myhdnval').value).style.width,unit))>parseInt(conversion(document.getElementById('outer').style.height,unit)))
                {
                    
                    document.getElementById(document.getElementById('myhdnval').value).style.width=parseInt(conversion(parseInt(document.getElementById('outer').style.height)-10,unit));
                }
                 if(parseInt(conversion(document.getElementById(document.getElementById('myhdnval').value).style.height,unit))>parseInt(conversion(document.getElementById('outer').style.width,unit)))
                {
                    document.getElementById(document.getElementById('myhdnval').value).style.height=parseInt(conversion(parseInt(document.getElementById('outer').style.width)-10,unit));
                }
                document.getElementById(document.getElementById('myhdnval').value).style.filter='progid:DXImageTransform.Microsoft.BasicImage(rotation=3)';
                flagtxt=0;
                flagpic=0;
                flagline=0;
                //return false;
            }
            var chckid=document.getElementById('myhdnval').value;
            var splitchck=chckid.split('~');
            if(splitchck[1]=="picture")
            {
            getdimsP();
            return false;
            }
            else if(splitchck[1]=="text")
            {
            getdimsT();
            return false;
            }
            else if(splitchck[1]=="line")
            {
            getdimsL();
            return false;
            }
        }
        else
          {
            alert("Ad Size Can Not Rotate.");
          }
    }
}

else  
{

  alert('Mozilla does not support this feature');
  document.getElementById('rotatediv').style.display='none';

  }
}
/**************this code for stretch_horizontal**********************/ 
function stretch_horizontal()
{
//var temp2=0;
    if(currentid==null || currentid=='editordiv'){alert('Please select Item !');}
        else{
            var temp=document.getElementById('hor').value;
            if(temp=="" || temp ==null){}
            else{
                var str=document.getElementById('selectedwidth').value;
                var  str2= str.replace("px","");
                if(parseInt(temp) < parseInt(str2)){
                    //str1 = document.write(str.split("") + "<br />");
                    var temp2 = str2 - temp;
                    document.getElementById(currentid).style.width = temp2;
                }
                else{
                    //var temp2 = parseInt(str2 + temp);
                    var temp2=parseInt(str2)+parseInt(temp);
                    document.getElementById(currentid).style.width = temp2;
              }
           }
        }
 }
 /*****************************/
 
function getdimsL()
 {
  var browser=navigator.appName;
  if(browser=="Microsoft Internet Explorer")
  {
    try
        {
          if(document.getElementById('myhdnval').value.indexOf("line")>=0)
             {
                if(document.getElementById(document.getElementById('myhdnval').value).style.width>"20px")
                      {
                       // document.getElementById(document.getElementById('myhdnval').value).style.width="5"
					      alert('Line Width Should Not Greater then 20px')
					      document.getElementById(document.getElementById('myhdnval').value).style.width="20"
                        return false;
                      }
             //}
                 else
                    {
                      if(document.getElementById('myhdnval').value==null || document.getElementById('myhdnval').value==""){}
                          else 
                          {
                                imgToolMenu.style.visibility = 'hidden';
                                document.getElementById('input_hghtL').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.height),unit);
                                document.getElementById('input_wdthL').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.width),unit);
                                //document.getElementById('sampleclrfont').style.backgroundColor=document.getElementById(currentid).style.color;
                                document.getElementById('sampleclrbckL').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.backgroundColor;
                                document.getElementById('toolsbox_bgcolor').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.backgroundColor;
                                 document.getElementById('toolsbox_fcolor').style.backgroundColor="ButtonFace";
                                //document.getElementById('sampleclrbrdrP').style.backgroundColor=document.getElementById(currentid).style.borderColor;
                               document.getElementById('ad_height').value =conversion(parseInt(document.getElementById('outer').style.height),unit);
                               document.getElementById('ad_width').value = conversion(parseInt(document.getElementById('outer').style.width),unit);
                               up();
                      
                            if(parseInt(r_conversion(document.getElementById('input_hghtL').value,unit))>parseInt(r_conversion(document.getElementById('ad_height').value,unit))-1)  
                               {
                                    //alert('Height should not be greater then'+ parseInt(document.getElementById('ad_height').value))
                                    document.getElementById(document.getElementById('myhdnval').value,unit).style.height=r_conversion(document.getElementById('ad_height').value,unit)-1;
                                    return false;
                                }
           
                        } 
                  }
            }
      }
        catch(err)
            {
               // alert('Errors?');
            }  
}
else if(browser!="Microsoft Internet Explorer")
      {
             try
        {
       // alert("in dims");
         
                       unit=parseInt(document.getElementById('sel_unit').value);
                           
                      if(document.getElementById('myhdnval').value==null || document.getElementById('myhdnval').value==""){}
                          else 
                          {
                            document.getElementById('imgToolMenu').style.visibility = 'hidden';
                            
                            if((document.getElementById(document.getElementById('myhdnval').value).style.height).indexOf("px")>=0)
                              {
                              document.getElementById('input_hghtL').value=conversion(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('px','')),unit);
                             // document.getElementById('input_wdthP').value=conversion(parseInt((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('px','')),unit);
                              }
                                else
                                {
                                if(unit==2)
                                {
                                    document.getElementById('input_hghtL').value=(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('in','')));
                                }
                                 if(unit==3)
                                {
                                    document.getElementById('input_hghtL').value=(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('cm','')));
                                }
                                 if(unit==4)
                                {
                                    document.getElementById('input_hghtL').value=(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('mm','')));
                                }
                                }
                             
                             if((document.getElementById(document.getElementById('myhdnval').value).style.width).indexOf("px")>=0)
                              {
                             // alert(document.getElementById(document.getElementById('myhdnval').value).style.width);
                              //document.getElementById('input_hghtP').value=conversion(parseInt((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('px','')),unit);
                              document.getElementById('input_wdthL').value=conversion(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('px','')),unit);
                              //alert(document.getElementById('input_wdthP').value)
                              }
                                else
                                {
                                if(unit==2)
                                {
                                    document.getElementById('input_wdthL').value=(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('in','')));
                                }
                                 if(unit==3)
                                {
                                    //alert(document.getElementById(document.getElementById('myhdnval').value).style.width);
                                    document.getElementById('input_wdthL').value=(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('cm','')));
                                    //alert(document.getElementById('input_wdthP').value)
                                }
                                 if(unit==4)
                                {
                                    document.getElementById('input_wdthL').value=(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('mm','')));
                                }
                                
                                }
                             
                                                
                            
                            
//                            document.getElementById('input_hghtL').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.height),unit);
//                            document.getElementById('input_wdthL').value=conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.width),unit);
                            //document.getElementById('sampleclrfont').style.backgroundColor=document.getElementById(currentid).style.color;
                            document.getElementById('sampleclrbckL').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.backgroundColor;
                            document.getElementById('toolsbox_bgcolor').style.backgroundColor=document.getElementById(document.getElementById('myhdnval').value).style.backgroundColor;
                             document.getElementById('toolsbox_fcolor').style.backgroundColor="ButtonFace";
                            //document.getElementById('sampleclrbrdrP').style.backgroundColor=document.getElementById(currentid).style.borderColor;
                            document.getElementById('ad_height').value =conversion(parseInt(document.getElementById('outer').style.height),unit);
                            document.getElementById('ad_width').value = conversion(parseInt(document.getElementById('outer').style.width),unit);
                             if(document.getElementById('myhdnval').value.indexOf("line")>=0)
             {
               //alert(document.getElementById(document.getElementById('myhdnval').value).style.width);
               if(document.getElementById(document.getElementById('myhdnval').value).style.width.indexOf('px')<0)
               {
                if(parseFloat(document.getElementById(document.getElementById('myhdnval').value).style.width)>parseFloat(conversion(20,unit)))
                      {
                       // document.getElementById(document.getElementById('myhdnval').value).style.width="5"
                       
					      
					      document.getElementById(document.getElementById('myhdnval').value).style.width=20+"px";
					      alert('Line Width Should Not Greater then '+ conversion(20,unit))
					      return false
                       
                      }
                }
                else
                {
                    if(parseFloat(document.getElementById(document.getElementById('myhdnval').value).style.width)>parseFloat(20))
                      {
                       // document.getElementById(document.getElementById('myhdnval').value).style.width="5"
                       
					      
					      document.getElementById(document.getElementById('myhdnval').value).style.width=20+"px";
					      alert('Line Width Should Not Greater then '+ conversion(20,unit))
					      return false
                       
                      }
                } 
                      if(unit==1)
                 { 
                         if((parseInt(document.getElementById('input_hghtL').value))>(parseInt(document.getElementById('ad_height').value)))
                       {
                        document.getElementById(document.getElementById('myhdnval').value).style.height=document.getElementById('ad_height').value+"px";
                      //document.getElementById('input_wdthP').value=document.getElementById('ad_width').value;
                      
                       moves();
                       
                       }
                 }
                 else
                 {   
            
          if((r_conversion(document.getElementById('input_hghtL').value,unit))>(r_conversion(document.getElementById('ad_height').value,unit)))  
             {
                
               
                if(unit==2)
                {
                    document.getElementById(document.getElementById('myhdnval').value).style.height=document.getElementById('ad_height').value+"in";
                  
                    
                       moves();
                     
                }  
                if(unit==3)
                {
                    document.getElementById(document.getElementById('myhdnval').value).style.height=document.getElementById('ad_height').value+"cm";
                    
                    
                       moves();
                }        
                if(unit==4)
                {
                    document.getElementById(document.getElementById('myhdnval').value).style.height=document.getElementById('ad_height').value+"mm";
                   
                    
                       moves();
                }                     
               
              }
              }
                      
                            up();
                            //alert(document.getElementById(document.getElementById('myhdnval').value).style.width);
                            
                        }
              }
      }
     catch(err)
        {
             // alert('Errors?');
         }   
   
      }
 }
/********************************************************************/

function stretch_vertical(){
    if(document.getElementById('myhdnval').value==null || document.getElementById('myhdnval').value=='editordiv')
      {
        alert('Please select a Item !');
        //document.getElementById('ver').focus;
      }
    else
     {
        var temp11=document.getElementById('ver').value;
        if(temp11=="" || temp11==null){}
        else
         {
           var str11=document.getElementById('selectedheight').value;
           var str12= str11.replace("px","");
           if(parseInt(temp11) < parseInt(str12))
           {
              //str1 = document.write(str.split("") + "<br />");
              var temp12 = str12 - temp11;
              document.getElementById(document.getElementById('myhdnval').value).style.height = temp12;
           }
            else
            {
                //var temp2 = parseInt(str2 + temp);
                var temp12=parseInt(str12)+parseInt(temp11);
                document.getElementById(currentid).style.height = temp12;
            }
        }
   }
}


function Stretch(){ 
        document.getElementById('popups').style.display="block";
        document.getElementById('textdialog').style.display='none';
        document.getElementById('opendialog1').style.display="none";
        document.getElementById('spltg').style.display="none";
        document.getElementById('opendialog').style.display="none";
        document.getElementById('openaddialog').style.display="none";
        document.getElementById('linedialog').style.display='none';
        document.getElementById('configdiv').style.display='none';
        document.getElementById('txt').checked='';
        document.getElementById('pic').checked='';
        document.getElementById('picdialog').style.display='none';
        flagpic=0;
        document.getElementById('rotatediv').style.display='none';
        document.getElementById('tagsdiv').style.display='none';
        document.getElementById('stretchdiv').style.display='block';
        
            
            //   window.showModelessDialog ('stretch.aspx','','dialogHeight:200px;dialogWidth:175px;dialogLeft:800px;scroll:no;status:off');      
     }
function opentags()
{
  var browser=navigator.appName;
  if(browser=="Microsoft Internet Explorer")
   {
        //document.getElementById('popups').style.display="block";
        document.getElementById('spltg').style.display="none";
        document.getElementById('configdiv').style.display='none';
        document.getElementById('textdialog').style.display='none';
        document.getElementById('opendialog').style.display="none";
         document.getElementById('openaddialog').style.display="none";
        document.getElementById('opendialog1').style.display="none";
         document.getElementById('linedialog').style.display='none';
        document.getElementById('txt').checked='';
        document.getElementById('pic').checked='';
        document.getElementById('picdialog').style.display='none';
        flagpic=0;
        document.getElementById('rotatediv').style.display='none';
        document.getElementById('stretchdiv').style.display='none';
        document.getElementById('tagsdiv').style.display='block';
          //tags=window.open('tagdialog.aspx','','width=200px,height=150px,left=770,top=300');
     }
  else if(browser!="Microsoft Internet Explorer")
     {
       if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
        {
     
             document.getElementById('spltg').style.display="none";
            document.getElementById('configdiv').style.display='none';
            document.getElementById('textdialog').style.display='none';
            document.getElementById('opendialog').style.display="none";
             document.getElementById('openaddialog').style.display="none";
            document.getElementById('opendialog1').style.display="none";
             document.getElementById('linedialog').style.display='none';
            document.getElementById('txt').checked='';
            document.getElementById('pic').checked='';
            document.getElementById('picdialog').style.display='none';
            flagpic=0;
            document.getElementById('rotatediv').style.display='none';
            document.getElementById('stretchdiv').style.display='none';
            document.getElementById('tagsdiv').style.display='block';
            document.getElementById('newdialog').style.display='none';
     
        }
     }
  }   
  /*************************************/
  function closestretch(){
  document.getElementById('stretchdiv').style.display='none';
  }
  function closetags(){
  document.getElementById('tagsdiv').style.display='none';
  document.getElementById('tagsprop_abc').checked=false;
  document.getElementById('spltg').style.display='none';
  }
  function closerotatediv(){
  document.getElementById('rotatediv').style.display='none';
  }
  function closeconfigdiv(){
  document.getElementById('configdiv').style.display='none';
  }
  function closeprop(){
  document.getElementById('textdialog').style.display='none';
  document.getElementById('txt').checked='';
  flagtxt=0;
  }
  function closeprop1(){
  document.getElementById('picdialog').style.display='none';
  document.getElementById('pic').checked='';
  flagpic=0;
  }
  function closeprop3(){
  document.getElementById('statusb').style.display='none';
  document.getElementById('sts').checked='';
  flagsts=0;
  }
  function closepropl(){
  document.getElementById('linedialog').style.display='none';
  flagline=0;
  }
  function closepropN(){
  document.getElementById('newdialog').style.display='none';
  }
  function closepropM(){
  document.getElementById('measuredialog').style.display='none';
  }
  function closepropTool()
  {
  document.getElementById('toolboxdialog').style.display='none';
  document.getElementById('tls').checked='';
  flagtools=0;
  }
  function closepropO()
  {
    document.getElementById('opendialog').style.display='none';
  
  }
   function closepropO1()
  {
    document.getElementById('opendialog1').style.display='none';
  
  }
  function closepropoad(){document.getElementById('openaddialog').style.display='none';}

  
/**************************************************/  
function change_case()
 {
    //getid(this);
    if(document.all)
    {
    if(document.getElementById('myhdnval').value==null || document.getElementById('myhdnval').value=='editordiv'){alert('Please Select an item !');}
           else{
            var item=document.getElementById(document.getElementById('myhdnval').value);
            Itemtext=item.innerText;
            ch=document.getElementById('textboxprop_changecase').value;
            switch(ch){
//                case '0':{alert('Double Click to select item from Editor');break;}
                case '1':{firstChr=Itemtext.substring(0,1);
                            len=Itemtext.length;
                            remainchar=Itemtext.substring(1,len);
                            remainchar=remainchar.toLowerCase();
                            tempData=firstChr.toUpperCase();
                            rep=tempData+remainchar;
                            //rep=Itemtext.replace(firstChr,tempData);//string.replace("find this","replace with this")
                            item.innerText=rep;break;}
                case '2':{tempData=Itemtext.toUpperCase();item.innerText=tempData;break;}
                case '3':{tempData=Itemtext.toLowerCase();item.innerText=tempData;break;}
                }
                }
           }
    else
         {
             if(document.getElementById('myhdnval').value==null || document.getElementById('myhdnval').value=='editordiv'){alert('Please Select an item !');}
           else{
            var item=document.getElementById(document.getElementById('myhdnval').value);
            Itemtext=item.textContent;
            ch=document.getElementById('textboxprop_changecase').value;
            switch(ch){
//                case '0':{alert('Double Click to select item from Editor');break;}
                case '1':{firstChr=Itemtext.substring(0,1);
                            len=Itemtext.length;
                            remainchar=Itemtext.substring(1,len);
                            remainchar=remainchar.toLowerCase();
                            tempData=firstChr.toUpperCase();
                            rep=tempData+remainchar;
                            //rep=Itemtext.replace(firstChr,tempData);//string.replace("find this","replace with this")
                            item.textContent=rep;break;}
                case '2':{tempData=Itemtext.toUpperCase();item.textContent=tempData;break;}
                case '3':{tempData=Itemtext.toLowerCase();item.textContent=tempData;break;}
              }
              }
        }
}

/***********************this is code for drop check*********************/
function dropcheck_onclick() {

    temp= document.getElementById('dropcheck');
    
    if(document.all)
    {
    if(temp.checked==true)
    {
        //simpletext=document.getElementById(currentid).innerText;
        text=document.getElementById(document.getElementById('myhdnval').value).innerText;
        if(text=="")
        {
            alert('please write some Text to apply!!');
            document.getElementById('dropcheck').checked=false;
        }
        else{
            //alert(text);
            firstChr=text.substring(0,1);
            len=text.length;
            remainchar=text.substring(1,len);
            text='<p><span class="firstChar">'+firstChr+'</span>'+remainchar+'</p>';
            //alert(text);
            document.getElementById(document.getElementById('myhdnval').value).innerHTML=text;
        }
     }
     else{document.getElementById(document.getElementById('myhdnval').value).innerHTML=firstChr + remainchar;}
     }
     else
     {
     if(temp.checked==true)
    {
        //simpletext=document.getElementById(currentid).innerText;
        text=document.getElementById(document.getElementById('myhdnval').value).innerHTML;
        //alert(text);
        if(text=="")
        {
            alert('please write some Text to apply!!');
            document.getElementById('dropcheck').checked=false;
        }
        else{
           // alert(text);
            firstChr=text.substring(0,1);
            len=text.length;
            remainchar=text.substring(1,len);
            //var alignt=document.getElementById(document.getElementById('myhdnval').value).align;
            //alert(alignt);
            
            text='<p><span class="firstChar">'+firstChr+'</span>'+remainchar+'</p>';
             var text1=document.getElementById(document.getElementById('myhdnval').value).innerHTML;
    //alert(text1);
            //alert(text);
            document.getElementById(document.getElementById('myhdnval').value).innerHTML=text;
        }
     }
     else{
     var text1=document.getElementById(document.getElementById('myhdnval').value).innerHTML;
    // alert(text);
     //alert(text1);
     if(text==text1)
     {
     document.getElementById(document.getElementById('myhdnval').value).innerHTML=firstChr + remainchar;
     }
     else
     {
    alert(text1);
     var newtext= text1.split('>');
    // alert(newtext.length);
     var lendr=newtext.length;
     for(var i=0;i<lendr;i++)
     {
     alert(newtext[i])
     }

        var a1= newtext[2].split('<');
        var a2= newtext[3].split('<');
        document.getElementById(document.getElementById('myhdnval').value).innerHTML=a1[0]+a2[0];
     }
     }
     }
}
/**********************************end*********************************/
function changeH()
{
    if(document.getElementById('myhdnval').value==null || document.getElementById('myhdnval').value=='editordiv')
    alert('Please select Item !');
    else
     {
       if(document.all)
        {
          temp=document.getElementById('input_hght').value;
          if(document.getElementById('myhdnval').value !="outer")
           {
             document.getElementById(document.getElementById('myhdnval').value).style.height=r_conversion(temp,unit);
           }
        else
        {
        
        }
    }
    else
    {
      temp=document.getElementById('input_hght').value;
      if(document.getElementById('myhdnval').value !="outer")
        {
          if(unit==1)
            {
              document.getElementById(document.getElementById('myhdnval').value).style.height=temp+"px";
             document.getElementById('input_hght').value=temp;
              //document.getElementById('selectedheight').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("px",""),unit);
              //document.getElementById('selectedwidth').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("px",""),unit);
              //alert(document.getElementById(document.getElementById('myhdnval').value).style.height);
            }
            if(unit==2)
            {
              document.getElementById(document.getElementById('myhdnval').value).style.height=temp+"in";
              //document.getElementById('selectedheight').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("in",""),unit);
              //document.getElementById('selectedwidth').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("in",""),unit);
              //alert(document.getElementById(document.getElementById('myhdnval').value).style.height);
            }
            if(unit==3)
            {
              document.getElementById(document.getElementById('myhdnval').value).style.height=temp+"cm";
              //document.getElementById('selectedheight').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("cm",""),unit);
              //document.getElementById('selectedwidth').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("cm",""),unit);
              //alert(document.getElementById(document.getElementById('myhdnval').value).style.height);
            }
            if(unit==4)
            {
              document.getElementById(document.getElementById('myhdnval').value).style.height=temp+"mm";
              //document.getElementById('selectedheight').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("mm",""),unit);
              //document.getElementById('selectedwidth').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("mm",""),unit);
              //alert(document.getElementById(document.getElementById('myhdnval').value).style.height);
            }
            
        }
       else
        {
        
        }
    }
    //document.getElementById(document.getElementById('myhdnval').value).style.height=r_conversion(temp,unit);
  }
}

/**************** this is code for height of pic box************/
function changeH_P()
  {
    //alert('110')
    if(document.getElementById('myhdnval').value==null || document.getElementById('myhdnval').value=='editordiv')
    alert('Please select Item !');
    else if (document.getElementById(document.getElementById('myhdnval').value)==null)
    alert('Item not Exist ?');
    else{
    if(document.all)
     {
       temp=document.getElementById('input_hghtP').value;
       document.getElementById(document.getElementById('myhdnval').value).style.height=r_conversion(temp,unit);

     }
    else
    {
      temp=document.getElementById('input_hghtP').value;
     // alert(temp);
      //temp=conversion(temp,unit);
      //alert(temp);
    if(unit==1)
      {
        document.getElementById(document.getElementById('myhdnval').value).style.height=temp+"px";
        if(document.getElementById(document.getElementById('myhdnval').value+"pic"))
        {
        document.getElementById(document.getElementById('myhdnval').value+"pic").style.height=document.getElementById(document.getElementById('myhdnval').value).style.height;
        }
    
      }
      if(unit==2)
      {
        document.getElementById(document.getElementById('myhdnval').value).style.height=temp+"in";
        if(document.getElementById(document.getElementById('myhdnval').value+"pic"))
        {
        document.getElementById(document.getElementById('myhdnval').value+"pic").style.height=document.getElementById(document.getElementById('myhdnval').value).style.height;
        }
        }
        if(unit==3)
      {
        document.getElementById(document.getElementById('myhdnval').value).style.height=temp+"cm";
        if(document.getElementById(document.getElementById('myhdnval').value+"pic"))
        {
        document.getElementById(document.getElementById('myhdnval').value+"pic").style.height=document.getElementById(document.getElementById('myhdnval').value).style.height;
        }
    
      }
    
      if(unit==4)
      {
        document.getElementById(document.getElementById('myhdnval').value).style.height=temp+"mm";
        if(document.getElementById(document.getElementById('myhdnval').value+"pic"))
        {
        document.getElementById(document.getElementById('myhdnval').value+"pic").style.height=document.getElementById(document.getElementById('myhdnval').value).style.height;
        }
    
      }
     //alert(document.getElementById(document.getElementById('myhdnval').value).style.height);
    }
    }
}
/***************************/
function changeW()
{
//alert('111')
        if(document.getElementById('myhdnval').value==null || document.getElementById('myhdnval').value=='editordiv')
        alert('Please select Item !');
        else{
        if(document.all)
        {
        temp=document.getElementById('input_wdth').value;
        if(document.getElementById('myhdnval').value !="outer")
        {
           document.getElementById(document.getElementById('myhdnval').value).style.width=r_conversion(temp,unit);
           document.getElementById('selectedwidth').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("px",""),unit);
        }
        
        }
        else
        {
        //alert("check");
        temp=document.getElementById('input_wdth').value;
     
       // alert(unit);
        if(unit==1)
        {
          document.getElementById(document.getElementById('myhdnval').value).style.width=temp+"px";
          //document.getElementById('selectedwidth').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("px",""),unit);
        }
        if(unit==2)
        {
          document.getElementById(document.getElementById('myhdnval').value).style.width=temp+"in";
          //document.getElementById('selectedwidth').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("in",""),unit);
        }
        if(unit==3)
        {
          document.getElementById(document.getElementById('myhdnval').value).style.width=temp+"cm";
         // document.getElementById('selectedwidth').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("cm",""),unit);
        }
        if(unit==4)
        {
          document.getElementById(document.getElementById('myhdnval').value).style.width=temp+"mm";
         // document.getElementById('selectedwidth').value=conversion(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("mm",""),unit);
        }
        //alert(document.getElementById(document.getElementById('myhdnval').value).style.width);
        
        }
        
        //document.getElementById(currentid).style.width=r_conversion(temp,unit);
    }
}    

/*************************************/  
  function changeW_P()
{
//alert('112')
        if(document.getElementById('myhdnval').value==null || document.getElementById('myhdnval').value=='editordiv')
        alert('Please select Item !');
        else{
        if(document.all)
        {
        //alert("check");
        temp=document.getElementById('input_wdthP').value;
        
        document.getElementById(document.getElementById('myhdnval').value).style.width=r_conversion(temp,unit);
        
       // alert(document.getElementById(document.getElementById('myhdnval').value).style.width);
        }
        else
        {
        //alert("check");
        temp=document.getElementById('input_wdthP').value;
     
       // alert(unit);
        if(unit==1)
        {
        document.getElementById(document.getElementById('myhdnval').value).style.width=temp+"px";
        document.getElementById(document.getElementById('myhdnval').value+"pic").style.width=document.getElementById(document.getElementById('myhdnval').value).style.width;
        }
         if(unit==2)
        {
        document.getElementById(document.getElementById('myhdnval').value).style.width=temp+"in";
        document.getElementById(document.getElementById('myhdnval').value+"pic").style.width=document.getElementById(document.getElementById('myhdnval').value).style.width;
        }
         if(unit==3)
        {
        document.getElementById(document.getElementById('myhdnval').value).style.width=temp+"cm";
        document.getElementById(document.getElementById('myhdnval').value+"pic").style.width=document.getElementById(document.getElementById('myhdnval').value).style.width;
        }
         if(unit==4)
        {
        document.getElementById(document.getElementById('myhdnval').value).style.width=temp+"mm";
        document.getElementById(document.getElementById('myhdnval').value+"pic").style.width=document.getElementById(document.getElementById('myhdnval').value).style.width;
        }
        //alert(document.getElementById(document.getElementById('myhdnval').value).style.width);
        
        }
    }  
    }
    
    
/********************************************/    

function changeB()
{    
//alert('113')
if(document.all)
{
   if(document.getElementById('myhdnval').value==null || document.getElementById('myhdnval').value=='editordiv'){alert('Please Select Item !');}
    else
    {
        temp=document.getElementById('textboxprop$borderlist').value;
         //alert(temp)
         if(temp)
         {
            document.getElementById(document.getElementById('myhdnval').value).style.borderBottomStyle=temp;
            document.getElementById(document.getElementById('myhdnval').value).style.borderLeftStyle=temp;
            document.getElementById(document.getElementById('myhdnval').value).style.borderRightStyle=temp;
            document.getElementById(document.getElementById('myhdnval').value).style.borderTopStyle=temp;
          }
     }
  }
  else
  {
  
    if(document.getElementById('myhdnval').value==null || document.getElementById('myhdnval').value=='editordiv'){alert('Please Select Item !');}
     else
      {
        temp=document.getElementById('textboxprop_borderlist').value;
      
         if(temp)
         {
         //alert(temp)
         
            document.getElementById(document.getElementById('myhdnval').value).style.borderBottomStyle=temp;
            document.getElementById(document.getElementById('myhdnval').value).style.borderLeftStyle=temp;
            document.getElementById(document.getElementById('myhdnval').value).style.borderRightStyle=temp;
            document.getElementById(document.getElementById('myhdnval').value).style.borderTopStyle=temp;
         
         
          }
       }
    }
 }
    
    
    
function changeB_P()
 {    
 if(document.all)
 {
   if(document.getElementById('myhdnval').value==null ||document.getElementById('myhdnval').value=='editordiv'){alert('Please Select Item !');}
    else{
    temp=document.getElementById('picboxprop$borderlist').value;
    if(temp){
        document.getElementById(document.getElementById('myhdnval').value).style.borderBottomStyle=temp;
        document.getElementById(document.getElementById('myhdnval').value).style.borderLeftStyle=temp;
        document.getElementById(document.getElementById('myhdnval').value).style.borderRightStyle=temp;
        document.getElementById(document.getElementById('myhdnval').value).style.borderTopStyle=temp;
        }
    }
    }
    
    else
    {
     if(document.getElementById('myhdnval').value==null ||document.getElementById('myhdnval').value=='editordiv'){alert('Please Select Item !');}
    else{
    temp=document.getElementById('picboxprop_borderlist').value;
    if(temp)
         {
         //alert(temp)
        
            document.getElementById(document.getElementById('myhdnval').value).style.borderBottomStyle=temp;
            document.getElementById(document.getElementById('myhdnval').value).style.borderLeftStyle=temp;
            document.getElementById(document.getElementById('myhdnval').value).style.borderRightStyle=temp;
            document.getElementById(document.getElementById('myhdnval').value).style.borderTopStyle=temp;
       
         
          }
    }   
    }
    }

function changeBsize()
{
//alert('113')
    if(document.getElementById('myhdnval').value==null || document.getElementById('myhdnval').value=='editordiv'){
    alert('Please Select Item !');}
    else{
    temp=document.getElementById('bsize').value;
    //alert(temp)
    if(temp){
    //alert(temp)
    var browser=navigator.appName;
    //alert(browser)
     if(browser=="Microsoft Internet Explorer")
    {
    //alert(browser)
        document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth=r_conversion(temp,unit);
        document.getElementById(document.getElementById('myhdnval').value).style.borderLeftWidth=r_conversion(temp,unit);
        document.getElementById(document.getElementById('myhdnval').value).style.borderRightWidth=r_conversion(temp,unit);
        document.getElementById(document.getElementById('myhdnval').value).style.borderTopWidth=r_conversion(temp,unit);
        }
        else if(browser!="Microsoft Internet Explorer")
        {
       if((document.getElementById(document.getElementById('myhdnval').value).style.height).indexOf("px")>=0)
          {
          document.getElementById('input_hght').value=conversion(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('px','')),unit);
         // document.getElementById('input_wdthP').value=conversion(parseInt((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('px','')),unit);
          }
            else
            {
            if(unit==2)
            {
                document.getElementById('input_hght').value=(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('in','')));
            }
             if(unit==3)
            {
                document.getElementById('input_hght').value=(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('cm','')));
            }
             if(unit==4)
            {
                document.getElementById('input_hght').value=(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('mm','')));
            }
            }
         
         if((document.getElementById(document.getElementById('myhdnval').value).style.width).indexOf("px")>=0)
          {
         // alert(document.getElementById(document.getElementById('myhdnval').value).style.width);
          //document.getElementById('input_hghtP').value=conversion(parseInt((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('px','')),unit);
          document.getElementById('input_wdth').value=conversion(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('px','')),unit);
          //alert(document.getElementById('input_wdthP').value)
          }
            else
            {
            if(unit==2)
            {
                document.getElementById('input_wdth').value=(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('in','')));
            }
             if(unit==3)
            {
                //alert(document.getElementById(document.getElementById('myhdnval').value).style.width);
                document.getElementById('input_wdth').value=(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('cm','')));
                //alert(document.getElementById('input_wdthP').value)
            }
             if(unit==4)
            {
                document.getElementById('input_wdth').value=(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('mm','')));
            }
            
            }
       
       
       
       
       temp=document.getElementById('bsize').value;
       
       document.getElementById('ad_height').value =conversion((document.getElementById('outer').style.height.replace('px','')),unit);
            document.getElementById('ad_width').value = conversion((document.getElementById('outer').style.width.replace('px','')),unit);
        if(unit==1)
         {  
            var currentbs=document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth.replace('px','');
            
            // alert((parseInt(document.getElementById('input_hght').value)+parseInt(temp)+parseInt(temp)-2))
             var psize=(parseInt(document.getElementById('input_hght').value)+parseInt(temp)+parseInt(temp)-2)
             var wsize=(parseInt(document.getElementById('input_wdth').value)+parseInt(temp)+parseInt(temp)-2)
           
                if(parseInt(psize)>(parseInt(document.getElementById('ad_height').value)))
                {
                       //alert("hello");
                       if((parseInt(document.getElementById('input_hght').value))<=(parseInt(document.getElementById('ad_height').value)))
                       {
                       alert("Border Size greater than permissible");
                       document.getElementById('bsize').value=parseFloat(currentbs);
                       return false
                       //document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth=currentbs+"px";
                       }
                     
                  }
                  if(parseInt(wsize)>(parseInt(document.getElementById('ad_width').value)))
                {
                       //alert("hello");
                       if((parseInt(document.getElementById('input_wdth').value))<=(parseInt(document.getElementById('ad_width').value)))
                       {
                       alert("Border Size greater than permissible");
                       document.getElementById('bsize').value=parseFloat(currentbs);
                       return false
                       //document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth=currentbs+"px";
                       }
                     
                  }
                  else
                  {
                        document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth=temp+"px";
                        document.getElementById(document.getElementById('myhdnval').value).style.borderLeftWidth=temp+"px";
                        document.getElementById(document.getElementById('myhdnval').value).style.borderRightWidth=temp+"px";
                        document.getElementById(document.getElementById('myhdnval').value).style.borderTopWidth=temp+"px";
                  }
            getdimsP();

         }
         if(unit==2)
         {
           // alert(parseFloat(document.getElementById('input_hghtP').value)+parseFloat(temp)+parseFloat(temp))
             var psize=(parseFloat(document.getElementById('input_hght').value)+parseFloat(temp)+parseFloat(temp))
             var wsize=(parseFloat(document.getElementById('input_wdth').value)+parseFloat(temp)+parseFloat(temp))
             //alert(psize);
           if(r_conversion(psize,unit)>r_conversion(document.getElementById('ad_height').value,unit))
           {
             if((r_conversion(document.getElementById('input_hght').value,unit))<=(r_conversion(document.getElementById('ad_height').value,unit)))  
             {
                alert("Border Size greater than permissible");
                document.getElementById('bsize').value=parseFloat(currentbs);
                       return false
             }
            }
            else if(r_conversion(wsize,unit)>r_conversion(document.getElementById('ad_width').value,unit))
               {
                 if((r_conversion(document.getElementById('input_wdth').value,unit))<=(r_conversion(document.getElementById('ad_width').value,unit)))  
                 {
                    alert("Border Size greater than permissible");
                    document.getElementById('bsize').value=parseFloat(currentbs);
                       return false
                 }
               }
            else
            {
                document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth=temp+"in";
                document.getElementById(document.getElementById('myhdnval').value).style.borderLeftWidth=temp+"in";
                document.getElementById(document.getElementById('myhdnval').value).style.borderRightWidth=temp+"in";
                document.getElementById(document.getElementById('myhdnval').value).style.borderTopWidth=temp+"in";
            }
         }
         if(unit==3)
         {
             var psize=(parseFloat(document.getElementById('input_hght').value)+parseFloat(temp)+parseFloat(temp))
             var wsize=(parseFloat(document.getElementById('input_wdth').value)+parseFloat(temp)+parseFloat(temp))
           if(r_conversion(psize,unit)>r_conversion(document.getElementById('ad_height').value,unit))
           {
             if((r_conversion(document.getElementById('input_hght').value,unit))<=(r_conversion(document.getElementById('ad_height').value,unit)))  
             {
                alert("Border Size greater than permissible");
                document.getElementById('bsize').value=parseFloat(currentbs);
                       return false
             }
           }
           else if(r_conversion(wsize,unit)>r_conversion(document.getElementById('ad_width').value,unit))
               {
                 if((r_conversion(document.getElementById('input_wdth').value,unit))<=(r_conversion(document.getElementById('ad_width').value,unit)))  
                 {
                    alert("Border Size greater than permissible");
                    document.getElementById('bsize').value=parseFloat(currentbs);
                       return false
                 }
               }
            else
            {
                document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth=temp+"cm";
                document.getElementById(document.getElementById('myhdnval').value).style.borderLeftWidth=temp+"cm";
                document.getElementById(document.getElementById('myhdnval').value).style.borderRightWidth=temp+"cm";
                document.getElementById(document.getElementById('myhdnval').value).style.borderTopWidth=temp+"cm";
            }
         }
         if(unit==4)
         {  
              var psize=(parseFloat(document.getElementById('input_hght').value)+parseFloat(temp)+parseFloat(temp))
              var wsize=(parseFloat(document.getElementById('input_wdth').value)+parseFloat(temp)+parseFloat(temp))
               if(r_conversion(psize,unit)>r_conversion(document.getElementById('ad_height').value,unit))
               {
                 if((r_conversion(document.getElementById('input_hght').value,unit))<=(r_conversion(document.getElementById('ad_height').value,unit)))  
                 {
                    alert("Border Size greater than permissible");
                    document.getElementById('bsize').value=parseFloat(currentbs);
                       return false
                 }
               }
               else if(r_conversion(wsize,unit)>r_conversion(document.getElementById('ad_width').value,unit))
               {
                 if((r_conversion(document.getElementById('input_wdth').value,unit))<=(r_conversion(document.getElementById('ad_width').value,unit)))  
                 {
                    alert("Border Size greater than permissible");
                    document.getElementById('bsize').value=parseFloat(currentbs);
                       return false
                 }
               }
                else
                {
                    document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth=temp+"mm";
                    document.getElementById(document.getElementById('myhdnval').value).style.borderLeftWidth=temp+"mm";
                    document.getElementById(document.getElementById('myhdnval').value).style.borderRightWidth=temp+"mm";
                    document.getElementById(document.getElementById('myhdnval').value).style.borderTopWidth=temp+"mm";
                }
         }
        }
        
        
        }
     }
    }
/********************this is code for chanebdr**********/  
function changeBsize_P()
     {
      //alert('114')

    if(document.getElementById('myhdnval').value==null || document.getElementById('myhdnval').value=='editordiv'){
    alert('Please Select Item !');}
    else{
    temp=document.getElementById('bsize_p').value;
    //alert(temp)
    if(temp){
    //alert(temp)
    var browser=navigator.appName;
    //alert(browser)
    if(browser=="Microsoft Internet Explorer")
    {
        document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth=r_conversion(temp,unit);
        document.getElementById(document.getElementById('myhdnval').value).style.borderLeftWidth=r_conversion(temp,unit);
        document.getElementById(document.getElementById('myhdnval').value).style.borderRightWidth=r_conversion(temp,unit);
        document.getElementById(document.getElementById('myhdnval').value).style.borderTopWidth=r_conversion(temp,unit);
        }
        else if(browser!="Microsoft Internet Explorer")
        {
        
        if((document.getElementById(document.getElementById('myhdnval').value).style.height).indexOf("px")>=0)
          {
             document.getElementById('input_hghtP').value=conversion(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('px','')),unit);
            // document.getElementById('input_wdthP').value=conversion(parseInt((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('px','')),unit);
          }
            else
            {
                if(unit==2)
                {
                    document.getElementById('input_hghtP').value=(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('in','')));
                }
                 if(unit==3)
                {
                    document.getElementById('input_hghtP').value=(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('cm','')));
                }
                 if(unit==4)
                {
                    document.getElementById('input_hghtP').value=(((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('mm','')));
                }
            }
         
         if((document.getElementById(document.getElementById('myhdnval').value).style.width).indexOf("px")>=0)
          {
             // alert(document.getElementById(document.getElementById('myhdnval').value).style.width);
              //document.getElementById('input_hghtP').value=conversion(parseInt((document.getElementById(document.getElementById('myhdnval').value).style.height).replace('px','')),unit);
              document.getElementById('input_wdthP').value=conversion(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('px','')),unit);
              //alert(document.getElementById('input_wdthP').value)
          }
            else
            {
                if(unit==2)
                {
                    document.getElementById('input_wdthP').value=(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('in','')));
                }
                 if(unit==3)
                {
                    //alert(document.getElementById(document.getElementById('myhdnval').value).style.width);
                    document.getElementById('input_wdthP').value=(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('cm','')));
                    //alert(document.getElementById('input_wdthP').value)
                }
                 if(unit==4)
                {
                    document.getElementById('input_wdthP').value=(((document.getElementById(document.getElementById('myhdnval').value).style.width).replace('mm','')));
                }
            
            }
            
        //alert(unit)
            document.getElementById('ad_height').value =conversion((document.getElementById('outer').style.height.replace('px','')),unit);
            document.getElementById('ad_width').value = conversion((document.getElementById('outer').style.width.replace('px','')),unit);
            temp=document.getElementById('bsize_p').value;
//        alert(temp);
//        alert(unit);
        if(unit==1)
         {  
            var currentbs=document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth.replace('px','');
            
             //alert((parseInt(document.getElementById('input_hghtP').value)+parseInt(temp)+parseInt(temp)-2))
             var psize=(parseInt(document.getElementById('input_hghtP').value)+parseInt(temp)+parseInt(temp)-2)
             var wsize=(parseInt(document.getElementById('input_wdthP').value)+parseInt(temp)+parseInt(temp)-2)   
                if(parseInt(psize)>(parseInt(document.getElementById('ad_height').value)))
                {
                       //alert("hello");
                       if((parseInt(document.getElementById('input_hghtP').value))<=(parseInt(document.getElementById('ad_height').value)))
                       {
                       alert("Border Size greater than permissible");
                       document.getElementById('bsize_p').value=parseFloat(currentbs);
                       return false
                       //document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth=currentbs+"px";
                       }
                     
                  }
                  if(parseInt(wsize)>(parseInt(document.getElementById('ad_width').value)))
                {
                       //alert("hello");
                       if((parseInt(document.getElementById('input_wdthP').value))<=(parseInt(document.getElementById('ad_width').value)))
                       {
                       alert("Border Size greater than permissible");
                         document.getElementById('bsize_p').value=parseFloat(currentbs);
                       return false
                       //document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth=currentbs+"px";
                       }
                     
                  }
                  else
                  {
                        document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth=temp+"px";
                        document.getElementById(document.getElementById('myhdnval').value).style.borderLeftWidth=temp+"px";
                        document.getElementById(document.getElementById('myhdnval').value).style.borderRightWidth=temp+"px";
                        document.getElementById(document.getElementById('myhdnval').value).style.borderTopWidth=temp+"px";
                  }
            getdimsP();

         }
         if(unit==2)
         {
          
             var psize=(parseFloat(document.getElementById('input_hghtP').value)+parseFloat(temp)+parseFloat(temp))
             var wsize=(parseFloat(document.getElementById('input_wdthP').value)+parseFloat(temp)+parseFloat(temp))
           if(r_conversion(psize,unit)>r_conversion(document.getElementById('ad_height').value,unit))
           {
             if((r_conversion(document.getElementById('input_hghtP').value,unit))<=(r_conversion(document.getElementById('ad_height').value,unit)))  
             {
                alert("Border Size greater than permissible");
                  document.getElementById('bsize_p').value=parseFloat(currentbs);
                       return false
             }
            }
           else if(r_conversion(wsize,unit)>r_conversion(document.getElementById('ad_width').value,unit))
           {
             if((r_conversion(document.getElementById('input_wdthP').value,unit))<=(r_conversion(document.getElementById('ad_width').value,unit)))  
             {
                alert("Border Size greater than permissible");
                  document.getElementById('bsize_p').value=parseFloat(currentbs);
                       return false
             }
            }
            else
            {
                document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth=temp+"in";
                document.getElementById(document.getElementById('myhdnval').value).style.borderLeftWidth=temp+"in";
                document.getElementById(document.getElementById('myhdnval').value).style.borderRightWidth=temp+"in";
                document.getElementById(document.getElementById('myhdnval').value).style.borderTopWidth=temp+"in";
            }
         }
         if(unit==3)
         {
             var psize=(parseFloat(document.getElementById('input_hghtP').value)+parseFloat(temp)+parseFloat(temp))
              var wsize=(parseFloat(document.getElementById('input_wdthP').value)+parseFloat(temp)+parseFloat(temp))
           if(r_conversion(psize,unit)>r_conversion(document.getElementById('ad_height').value,unit))
           {
             if((r_conversion(document.getElementById('input_hghtP').value,unit))<=(r_conversion(document.getElementById('ad_height').value,unit)))  
             {
                alert("Border Size greater than permissible");
                  document.getElementById('bsize_p').value=parseFloat(currentbs);
                       return false
             }
           }
           else if(r_conversion(wsize,unit)>r_conversion(document.getElementById('ad_width').value,unit))
           {
             if((r_conversion(document.getElementById('input_wdthP').value,unit))<=(r_conversion(document.getElementById('ad_width').value,unit)))  
             {
                alert("Border Size greater than permissible");
                  document.getElementById('bsize_p').value=parseFloat(currentbs);
                       return false
             }
            }
            else
            {
                document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth=temp+"cm";
                document.getElementById(document.getElementById('myhdnval').value).style.borderLeftWidth=temp+"cm";
                document.getElementById(document.getElementById('myhdnval').value).style.borderRightWidth=temp+"cm";
                document.getElementById(document.getElementById('myhdnval').value).style.borderTopWidth=temp+"cm";
            }
         }
         if(unit==4)
         {  
              var psize=(parseFloat(document.getElementById('input_hghtP').value)+parseFloat(temp)+parseFloat(temp))
               var wsize=(parseFloat(document.getElementById('input_wdthP').value)+parseFloat(temp)+parseFloat(temp))
               if(r_conversion(psize,unit)>r_conversion(document.getElementById('ad_height').value,unit))
               {
                 if((r_conversion(document.getElementById('input_hghtP').value,unit))<=(r_conversion(document.getElementById('ad_height').value,unit)))  
                 {
                    alert("Border Size greater than permissible");
                      document.getElementById('bsize_p').value=parseFloat(currentbs);
                       return false
                 }
               }
               else if(r_conversion(wsize,unit)>r_conversion(document.getElementById('ad_width').value,unit))
               {
                 if((r_conversion(document.getElementById('input_wdthP').value,unit))<=(r_conversion(document.getElementById('ad_width').value,unit)))  
                 {
                    alert("Border Size greater than permissible");
                      document.getElementById('bsize_p').value=parseFloat(currentbs);
                       return false
                 }
                }
                else
                {
                    document.getElementById(document.getElementById('myhdnval').value).style.borderBottomWidth=temp+"mm";
                    document.getElementById(document.getElementById('myhdnval').value).style.borderLeftWidth=temp+"mm";
                    document.getElementById(document.getElementById('myhdnval').value).style.borderRightWidth=temp+"mm";
                    document.getElementById(document.getElementById('myhdnval').value).style.borderTopWidth=temp+"mm";
                }
         }
        }
        moves();
        }
    }
}

/************ end of code*********************/


function borderclr()
{
    document.getElementById('myhdnval').value=opener.document.activeElement.id;
    if(document.getElementById('myhdnval').value==null){alert('Please Select Item !');}
    else{
    tempc=document.getElementById('colorcode1').value;
    opener.document.activeElement.style.borderBottomColor=tempc;
    opener.document.activeElement.style.borderLeftColor=tempc;
    opener.document.activeElement.style.borderRightColor=tempc;
    opener.document.activeElement.style.borderTopColor=tempc;
    }
}
function enablestn(){
        if(flagstn==0)
        {
            document.getElementById('toolboxs').style.display='block';
            aa= document.getElementById('stn');
            aa.checked='checked';
            flagstn=1;
        }
        else
        {
            document.getElementById('toolboxs').style.display='none';
            aa= document.getElementById('stn');
            aa.checked='';
            flagstn=0;
        }  
           
       }    
function enablefnt()
       {
       if(flagfnt==0){
            document.getElementById('toolboxf').style.display='block';
            aa= document.getElementById('fnt');
            aa.checked='checked';
            flagfnt=1;
        }
        else{
            document.getElementById('toolboxf').style.display='none';
            aa= document.getElementById('fnt');
            aa.checked='';
            flagfnt=0;
        }
       
       }
function enablests(){
       if(flagsts==0){
       ed=document.getElementById('statusb');//contenteditable="true"
       ed.style.display='block';
       document.getElementById('sts').checked='checked';
       flagsts=1;
       //ed.setAttribute('contenteditable','true');
       }else{
            document.getElementById('sts').checked='';
            document.getElementById('statusb').style.display='none';
            flagsts=0;
        }
       }
       function enabletools(){
       if(flagtools==0){
       document.getElementById('toolboxdialog').style.display='block';
       document.getElementById('tls').checked='checked';
       flagtools=1;
       //ed.setAttribute('contenteditable','true');
       }else{
            document.getElementById('tls').checked='';
            document.getElementById('toolboxdialog').style.display='none';
            flagtools=0;
        }
       }
function promptdialog()
{
        //alert('promdialog');
            document.getElementById('popups').style.display="block";
            document.getElementById('confirmdialog').style.display='block';
            document.getElementById('measuredialog').style.display='none';
            document.getElementById('configdiv').style.display='none';
            document.getElementById('stretchdiv').style.display='none';
            document.getElementById('textdialog').style.display='none';
            document.getElementById('spltg').style.display="none";
             document.getElementById('openaddialog').style.display="none";
             document.getElementById('linedialog').style.display='none';
            document.getElementById('txt').checked='';
            document.getElementById('pic').checked='';
            document.getElementById('picdialog').style.display='none';
            document.getElementById('opendialog').style.display="none";
            document.getElementById('opendialog1').style.display="none";
            document.getElementById('newdialog').style.display="none";
            flagpic=0;
            document.getElementById('tagsdiv').style.display='none';
            document.getElementById('rotatediv').style.display='none';

}


function closediv()
{
  //alert('close2')
    var browser=navigator.appName;
    if(browser!="Microsoft Internet Explorer")
    {
   
        //try{
        //ankngtif(document.getElementById('myhdnval').value==null || document.getElementById('fetchid').value== 1 ||document.getElementById('fetchid1').value==1  )
        if(document.getElementById('myhdnval').value==null ||document.getElementById('savehidden').value!="")
         {
            Clear();
            document.getElementById('editordiv').innerHTML="";
            ad_template=2;
            template_ads()
            //}catch(er){}
             //alert('close');
         }
       else
        {
           promptdialog();               
        }
    }
   else if(browser=="Microsoft Internet Explorer")
     {
       if(document.getElementById('myhdnval').value==null || document.getElementById('fetchid').value== 1 ||document.getElementById('fetchid1').value==1 ||document.getElementById('savehidden').value!="" )
         {
            Clear();
            document.getElementById('editordiv').innerHTML="";
            ad_template=2;
            template_ads()
            //}catch(er){}
         }
       else
        {
           promptdialog();               
        }
  
     }
    
  }  
    
    
 function ifyes()
  {
     var browser=navigator.appName;
    if(browser!="Microsoft Internet Explorer")
        {
            savedialog();
            document.getElementById('myhdnval').value=null;
            document.getElementById('confirmdialog').style.display='none';
            //document.getElementById('measuredialog').style.display='block';
            //document.getElementById('editordiv').innerHTML="";
            //Clear();
        }
   else if(browser=="Microsoft Internet Explorer")
      {
            savedialog();
            document.getElementById('myhdnval').value=null;
            document.getElementById('confirmdialog').style.display='none';
            //document.getElementById('measuredialog').style.display='block';
            //document.getElementById('editordiv').innerHTML="";
            //Clear();
      }
   
 }
 
 
       
   function ifno()
    {
       var browser=navigator.appName;
       if(browser!="Microsoft Internet Explorer")
        {
            document.getElementById('editordiv').innerHTML="";
            // alert(document.getElementById('editordiv').innerHTML)
             Clear();
            //currentid="img1";
            //alert('img1');
            create();
            //alert('koi');
            document.getElementById('confirmdialog').style.display='none';
            //document.getElementById('measuredialog').style.display='block';
        } 
    else if(browser=="Microsoft Internet Explorer")
      {
           //currentid=null;
            document.getElementById('editordiv').innerHTML="";
            Clear();
            //alert('clear');
            //currentid="img1";
            if(currentid=='i1' || currentid=='i2' ||currentid=='i3' ||currentid=='i4' ||currentid=='i5'  )
            create();
            document.getElementById('confirmdialog').style.display='none';
            //document.getElementById('measuredialog').style.display='block';
     }
    
 }    

 function ifcancel()
    {
       var browser=navigator.appName;
      if(browser!="Microsoft Internet Explorer")
        {
            document.getElementById('myhdnval').value=null;
            document.getElementById('confirmdialog').style.display='none';
            //document.getElementById('measuredialog').style.display='none';
        }
   else if(browser=="Microsoft Internet Explorer")
     {
       document.getElementById('myhdnval').value=null;
       document.getElementById('confirmdialog').style.display='none';
       //document.getElementById('measuredialog').style.display='none';
     }       
  } 
/***********8end of function*********/  
   
function Clear()
 {
    var browser=navigator.appName;
    if(browser!="Microsoft Internet Explorer")
      {
        document.getElementById("editordiv").innerHTML = '';
        document.getElementById('fetchid').value="";
        document.getElementById('fetchid1').value="";
        document.getElementById('editordivfullhtml').value="";
        document.getElementById('previewhtml').value="";
        document.getElementById('ctrval').value=1;
        document.getElementById('editordivxml').value="";
        document.getElementById('temp_id').value="";
        document.getElementById('current_id').value=1;
        document.getElementById('txtpathname').value="";
        document.getElementById('sel_unit').value="";
        document.getElementById('newhtml1').value="";
        document.getElementById('adwidth').value="";
        document.getElementById('adheight').value="";
         document.getElementById('spltg').style.display='none';
        document.getElementById('sav').value=1;
        document.getElementById('picdialog').style.display='none';
        document.getElementById('textdialog').style.display='none';
		document.getElementById('tagsdiv').style.display='none';
        document.getElementById('selected_name').value="";   
        //currentid=null;
        disabled();
        
      }
      else if(browser=="Microsoft Internet Explorer")
      {
        document.getElementById("editordiv").innerHTML = '';
        document.getElementById('fetchid').value="";
        document.getElementById('fetchid1').value="";
        document.getElementById('editordivfullhtml').value="";
        document.getElementById('previewhtml').value="";
        document.getElementById('ctrval').value=1;
        document.getElementById('editordivxml').value="";
        document.getElementById('temp_id').value="";
        document.getElementById('current_id').value=1;
        document.getElementById('txtpathname').value="";
        document.getElementById('sel_unit').value="";
        document.getElementById('newhtml1').value="";
        document.getElementById('adwidth').value="";
        document.getElementById('adheight').value="";
        document.getElementById('sav').value=1;
        document.getElementById('picdialog').style.display='none';
        document.getElementById('textdialog').style.display='none';
		document.getElementById('tagsdiv').style.display='none';
		 document.getElementById('spltg').style.display='none';
        document.getElementById('selected_name').value="";   
        //currentid=null;
        disabled();    
      }
   }

function undo1(){
    document.execCommand('undo', false, null);
    }
function redo1(){
    document.execCommand('redo', false, null);
    }
    function deleted()
    {

if(event.keyCode==46)
        {
            document.execCommand("Delete");
            }
           
    }
    
function deleted1(ev)
   {
   if(document.all)
   {
  if(event.ctrlKey==true && event.keyCode==83)
         {
            if(document.getElementById('sav').value=="1")
                {
                    savedialog();
                }
            if(document.getElementById('sav').value=="2")
                {
                    saveaddialog();
                }
           }
          
         if(event.ctrlKey==true && event.keyCode==86)//&& document.getElementById(currentid)!=null)
            {
            try{
            if(document.getElementById(document.getElementById('myhdnval').value).clientHeight > ((conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.height),unit))+2))
                {
                event.keyCode=8;
                 return event.keyCode;
                 alert('Plz Increase The Height Of TextBox');
     
                 }
            else
             {
                    event.keyCode=32;
                    
                        paste_selected();
            }
            }catch(er){}
            
            }
            
//            if(event.ctrlKey==true && event.keyCode==86)//&& document.getElementById(currentid)!=null)
//            {
//                return false;
//            }
          if(event.ctrlKey==true && event.keyCode==67)//&& document.getElementById(currentid)!=null)
            {
                CopyToClipboard();
            }
            if(event.ctrlKey==true && event.keyCode==88)//&& document.getElementById(currentid)!=null)
            {
                CutToClipboard();
            }
            if(event.ctrlKey==true && event.keyCode==80)//&& document.getElementById(currentid)!=null)
            {
                addelement1();
            }
            if(event.keyCode==46 && document.getElementById('myhdnval').value!="outer")
        {
            document.getElementById('textdialog').style.display='none';
            document.getElementById('linedialog').style.display='none';
            document.getElementById('picdialog').style.display='none';
            flagtxt=0;
            flagpic=0;
            flagline=0;
            currentid=null;
         } 
        else
         {
            if(event.ctrlKey==false )
            {
            if( event.shiftKey==false)
            { 
           if(event.keyCode==0)
           {
           
           //document.getElementById(document.getElementById('myhdnval').value).style.display='none';
           document.getElementById('linedialog').style.display='none';
           document.getElementById('picdialog').style.display='none';
           document.getElementById('textdialog').style.display='none';
           //editordiv.childNodes[1].outerHTML="";
          if(document.getElementById('myhdnval').value=="")
          {
            alert('Please Select the Item  which you want to delete')
            return;
          }
          else
          {
          
           for(i=0;i<editordiv.children.length;i++)
           {
                if(editordiv.childNodes[i].id==document.getElementById('myhdnval').value)
                {
                if(document.getElementById('myhdnval').value!="outer")
                {
                   editordiv.childNodes[i].outerHTML="" 
                 }
                }
           }
           }
           //document.getElementById(document.getElementById('myhdnval').value).outerHTML="";
          // document.getElementById(document.getElementById('myhdnval').value).outerHTML="";
            flagtxt=0;
            flagpic=0;
            flagline=0;
            currentid=null;
            document.getElementById('hidden1').value="";
           }
                event.keyCode=0;
                return event.keyCode;
            }
            }
         }
      
         currentid==null;  
         //alert("hte")
         }
         else
         {
         if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
       {
     //  alert("deleted1");
         //alert(document.getElementById('editordiv').childNodes[0].innerHTML);
        // alert(document.getElementById('editordiv').innerHTML);
           // alert(document.getElementById('editordiv').innerHTML)
            //alert("hello");
            if(ev.ctrlKey==true && ev.keyCode==83)
         {
            if(document.getElementById('sav').value=="1")
                {
                    savedialog();
                }
            if(document.getElementById('sav').value=="2")
                {
                    saveaddialog();
                }
           }
          // alert("deleted2");
         //alert(ev.keyCode);
         if(ev.ctrlKey==true && ev.keyCode==86)//&& document.getElementById(currentid)!=null)
            {
            try{
            if(document.getElementById(document.getElementById('myhdnval').value).clientHeight > ((conversion(parseInt(document.getElementById(document.getElementById('myhdnval').value).style.height),unit))+2))
                {
                ev.keyCode=8;
                 return ev.keyCode;
                 alert('Plz Increase The Height Of TextBox');
     
                 }
            else
             {
                    ev.keyCode=32;
                    
                        paste_selected();
            }
            }catch(er){}
            
            }
            
//            if(event.ctrlKey==true && event.keyCode==86)//&& document.getElementById(currentid)!=null)
//            {
//                return false;
//            }
        
            if(ev.keyCode==46 && document.getElementById('myhdnval').value!="outer")
        {
       // alert("check");
                   
                    
                    //alert( document.getElementById(document.getElementById('myhdnval').value).textContent)
                    
                   if(document.getElementById('myhdnval').value.indexOf('~text')>=0 && document.getElementById(document.getElementById('myhdnval').value).innerHTML!="")
                   {
                   //alert("inthis");
                   }
                   else{
                    //alert("hello");
                    document.getElementById('linedialog').style.display='none';
                   document.getElementById('picdialog').style.display='none';
                   document.getElementById('textdialog').style.display='none';
                  
                  if(document.getElementById('myhdnval').value=="")
                  {
                    alert('Please Select the Item  which you want to delete')
                    return;
                  }
                  else
                  {
                      document.getElementById(document.getElementById('myhdnval').value).innerHTML="";    
                             
                        var arr = new Array();
                        var all_divs = new Array();
                        var inner_html = document.getElementById('editordiv').childNodes[0].innerHTML;
                        all_divs = inner_html.split("<div ");
                       
                         for (i = 1; i <=(all_divs.length); i++)
                        {
                        
                            var itemsplit=""
                            itemsplit = "<div " + all_divs[i];
                            var idindex=itemsplit.indexOf("id=");
                            var itemid= itemsplit.substring(idindex+3,idindex+17);
                            var finalid=itemid.split(" ");
                          var nh=finalid[0];
                          while(nh.indexOf('"')>=0)
                          {
                           nh=nh.replace('"',"")
                          }
                             if(document.getElementById('prevalue').value==nh)
                        {
                            document.getElementById('prevalue').value="";
                        }
        
        
        
        
                        if (nh == document.getElementById('myhdnval').value)
                          {
                              document.getElementById('editordiv').childNodes[0].innerHTML=document.getElementById('editordiv').childNodes[0].innerHTML.replace(itemsplit,"");
                           }
                      }
                   document.getElementById('textdialog').style.display='none';
            document.getElementById('linedialog').style.display='none';
            document.getElementById('picdialog').style.display='none';
            flagtxt=0;
            flagpic=0;
            flagline=0;
            currentid=null; 
            document.getElementById('xvalue').value="";
          document.getElementById('yvalue').value="";
          document.getElementById('hghtsel').value="";
          document.getElementById('wdthsel').value=""; 
             document.getElementById('myhdnval').value="";  
                }    
                 }
          
           
          //  currentid=null;
         } 
        else
         {
           // alert('ev.keyCode');
            if(ev.keyCode==undefined)
            {
                if(ev.ctrlKey==false )
                {
                if( ev.shiftKey==false)
                { 
            
             
                   document.getElementById('linedialog').style.display='none';
                   document.getElementById('picdialog').style.display='none';
                   document.getElementById('textdialog').style.display='none';
                  
                  if(document.getElementById('myhdnval').value=="")
                  {
                    alert('Please Select the Item  which you want to delete')
                    return;
                  }
                  else
                  {
                     // alert('delete');
                      document.getElementById(document.getElementById('myhdnval').value).innerHTML="";      
                        var arr = new Array();
                        var all_divs = new Array();
                        var inner_html = document.getElementById('editordiv').childNodes[0].innerHTML;
                        all_divs = inner_html.split("<div ");
                       
                         for (i = 1; i <=(all_divs.length); i++)
                        {
                          //alert('delete1');
                          var itemsplit=""
                          itemsplit = "<div " + all_divs[i];
                          var idindex=itemsplit.indexOf("id=");
                          var itemid= itemsplit.substring(idindex+3,idindex+17);
                          var finalid=itemid.split(" ");
                          var nh=finalid[0];
                          while(nh.indexOf('"')>=0)
                          {
                           nh=nh.replace('"',"")
                          }
                         //alert('delete2');
                         if(document.getElementById('prevalue').value==nh)
                        {
                            document.getElementById('prevalue').value="";
                            //document.getElementById('fcolor').value="";
                            //document.getElementById('bgcolor').value="";
                        }
                        //alert('delete3');
                      if (nh == document.getElementById('myhdnval').value)
                          {
                            //alert('delete4')
                            document.getElementById('editordiv').childNodes[0].innerHTML=document.getElementById('editordiv').childNodes[0].innerHTML.replace(itemsplit,"");
                           document.getElementById('toolsbox_fcolor').style.backgroundColor="ButtonFace";
                            document.getElementById('toolsbox_bgcolor').style.backgroundColor="ButtonFace";
                          }
                      }
                 }
                 //alert('delete5');
                 flagtxt=0;
                 flagpic=0;
                 flagline=0;
                 currentid=null;
                 document.getElementById('xvalue').value="";
          document.getElementById('yvalue').value="";
          document.getElementById('hghtsel').value="";
          document.getElementById('wdthsel').value=""; 
                 
                 document.getElementById('myhdnval').value="";
          }
                
                return ev.keyCode;
            }
           } 
         }
       }   
     }
  }
      
///****************************************/
function CutToClipboard()
 {
    var browser= navigator.appName;
    if(browser!="Microsoft Internet Explorer")
     {
     if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
        {
         alert("Mozilla does not support this feature");
      }
  }
     else if(browser=="Microsoft Internet Explorer")  
      {
         var obj1=document.selection;
	    //alert(obj1=document.selection);
	    if(obj1.type=="Text")
         {
            //alert(obj1.type);
            var r = obj1.createRange();
            c1="text";
           document.execCommand("Cut");
           //document.getElementById(document.getElementById('myhdnval').value).focus();
           document.getElementById('editordiv').focus;
           document.getElementById('pasteT').disabled=false;
           document.getElementById('paste').disabled=false;
           document.getElementById('rightpaste').disabled=false;
           //document.getElementById('rightpaste').style.unselectable="off";
           document.getElementById('paste').src="icons/paste.jpg"; 
           document.selection.empty();
         }
         else
         {
            //alert('cut3');
            c1="control"
            document.execCommand("Cut");
            //document.getElementById(document.getElementById('myhdnval').value).focus();
             document.getElementById('editordiv').focus();
            document.getElementById('pasteT').disabled=false;
            document.getElementById('paste').disabled=false;
            document.getElementById('rightpaste').disabled=false;
            //document.getElementById('rightpaste').style.unselectable="off";
            document.getElementById('paste').src="icons/paste.jpg"
            document.selection.empty();
         }
      
      }
   } 
      
      
      
function CopyToClipboard()
 {
  
  var browser=navigator.appName;
  if(browser!="Microsoft Internet Explorer")
  {
    if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
        {
         alert("Mozilla does not support this feature"); 
       }
  }
  else if(browser=="Microsoft Internet Explorer")
  {
    // alert('abhu');
      //alert(document.getElementById('myhdnval').value)
      if(document.getElementById(document.getElementById('myhdnval').value).innerText.length=="571")
        {
          //alert('moves');
          alert('nothing to copy')
          return false;
        }
        else
         {
            //alert('abp');
             var obj1=document.selection;
	         if(obj1.type=="Text")
             {
                 var r = obj1.createRange();
                 c1="text";
                 document.execCommand("Copy");
                 //document.getElementById(document.getElementById('myhdnval').value).focus();
                 document.getElementById('editordiv').focus;
                /*opener.*/document.getElementById('pasteT').disabled=false;
                 document.getElementById('paste').disabled=false;
                 document.getElementById('rightpaste').disabled=false;
                 document.getElementById('paste').src="icons/paste.jpg"; 
                 document.selection.empty();
             }
            else  
            {
              c1="control"
              document.execCommand("Copy");
              //document.getElementById(document.getElementById('myhdnval').value).focus();
              document.getElementById('editordiv').focus;
              /*opener.*/document.getElementById('pasteT').disabled=false;
              document.getElementById('paste').disabled=false;
              document.getElementById('rightpaste').disabled=false;
              document.getElementById('paste').src="icons/paste.jpg"; 
              document.selection.empty();
             }
        
         } 
  
   }
}
   
  function PasteFromClipboard()
   { 
     //alert('ppppp');
     var browser=navigator.appName;
     if(browser=="Microsoft Internet Explorer")
      {
        var obj1=document.selection;
        if(c1=="text")
         {
            var d= document.getElementById(document.getElementById('myhdnval').value).id.split("~")[1];
            if(d== "text")
            {
                var ch=document.getElementById('myhdnval').value;
                document.getElementById(document.getElementById('myhdnval').value).focus();
                document.execCommand("Paste");
               // document.getElementById('ch').focus();
                //document.getElementById(document.getElementById('myhdnval').value).focus();
                abc();
                var ab = document.getElementById(document.getElementById('myhdnval').value).innerText;
                 //var ab = document.getElementById(document.getElementById('myhdnval').value).innerHTML;
                //var ab = document.getElementById('editordiv').innerHTML;
                var ab1 = ab.split("<DIV");
               for(var i=2; i < ab1.length; i++)
                {
                  var ab2 = ab1[i].split("id=");
                }
               document.getElementById('editordiv').focus();
             }
             else
             {
               alert("No Textbox To Paste");
             }   
         }
           else
            {
              document.getElementById('editordiv').focus();
              document.execCommand("Paste");
              var mycount=document.getElementById('editordiv').children.length
              var myid=""
              var count=0;
             for(i=0;i<=mycount-1;i++)
              {
                myid=document.getElementById('editordiv').childNodes[i].id
                count=0;
                for(k=0;k<=mycount-1;k++)
                 {
                  if(count==0)
                   {
                     if(myid==document.getElementById('editordiv').childNodes[k].id)
                      {
                         count=1;
                      }
                   }
               else
               {
               if(myid==document.getElementById('editordiv').childNodes[k].id)
                {
                    var splitval=document.getElementById('editordiv').childNodes[k].id.split("~")[1];
                    document.getElementById('editordiv').childNodes[k].id=ctr+"~"+splitval;
                    ctr=ctr+1;
                    document.getElementById('ctrval').value=ctr;
                }
             }
         }
       
      }
          document.getElementById('editordiv').focus();
    }
  }
 else if(browser!="Microsoft Internet Explorer")
  {
    alert("Mozilla does not support this feature");
  }
 } 
 
/****************end of code cut copy or paste*****************************/

    var src1;
    var name1;
    var id=1;
    var id1=1;
    var flagimg=0;
    var htt;
    var i;
//    function ankur()
//    {
//        alert("ankur")
//    }

  function addElementtag()
   {
    //alert('addElementtag');
      var browser=navigator.appName;
      if(browser!="Microsoft Internet Explorer")
        {
            //alert('addElementtag2');
             var name = document.getElementById('tagsprop_arrayname').value;
              var sevpath = document.getElementById('tagsprop_path11').value;
               name1 = name.split(",");
               var mytable = document.createElement("table");
               var mytablebody = document.createElement("tbody");
               var mycurrent_row = document.createElement("tr");
                  for(var i=1; i<name1.length-1; i++)
                {
                src1 = sevpath + name1[i];
                           if(i<4)
			        {
				        var mycurrent_cell = document.createElement("td");
				        var imgTag = document.createElement("img");
				        mycurrent_cell.appendChild(imgTag)
				        
				        imgTag.setAttribute('src', src1);
				        imgTag.setAttribute('onclick',"showimg(this)");
				       //imgTag.src = ("C:\\Inetpub\\wwwroot\\AdmakingQC\\images\\tools2.jpg");
				        mycurrent_row.appendChild(mycurrent_cell);
				       // alert(mycurrent_row.innerHTML)
			        }
			        if(i==3)
			        {
        			  document.getElementById('spltg').appendChild(mycurrent_row);
        			}
			        if(i>=4)
			        {
				        var mycurrent_cell1 = document.createElement("td");
				        var imgTag = document.createElement("img");
				        mycurrent_cell1.appendChild(imgTag)
				       imgTag.setAttribute('src', src1);
				         //imgTag.setAttribute('onclick', "ankur()");
				         imgTag.setAttribute('onclick',"showimg(this)");
				       
				        mycurrent_row.appendChild(mycurrent_cell1);
				        //alert("d")
				        //alert(mycurrent_row.innerHTML)
			        }
			        if(i == 6)
			        {
					         document.getElementById('spltg').appendChild(mycurrent_row);
			        }
                    
                    
                }
               //showimg();      
         }
      else if(browser=="Microsoft Internet Explorer")
       {
             var name = document.getElementById('tagsprop_arrayname').value;
              var sevpath = document.getElementById('tagsprop_path11').value;
              // spacial = savpath + ("");
              //file = sevpath.replace ("/file/", "");
              //   spacial = sevpath.replace ("/spacial/","");
              //   var ab = spacial+"\\images\\Global-library.jpg";
               name1 = name.split(",");   
               var ht = "<table><tr>";
               for(var i=1; i<name1.length-1; i++)
              {
                //myElement.innerHTML = "<table>";
                // var htt;
                 src1 = sevpath + name1[i];
                 src1=src1.replace("/", "\\");
                 if(i%5==0){
                 //alert('ankit');
                 htt = ht + "<tr><td style='border: solid 1;width:50px;' id="+id+" onclick =\"showimg(this);\" ><img id="+id1+" src="+src1+" onmouseover=\"javascript:mover(this);\" onmouseout=\"document.getElementById('"+id+"').style.borderColor='#CCC';\" unselectable='on'></td>";
              }
              else
               {
                 htt = ht + "<td style='border: solid 1;width:50px;' id="+id+" onclick =\"showimg(this);\" ><img id="+id1+" src="+src1+" onmouseover=\"javascript:mover(this);\" onmouseout=\"document.getElementById('"+id+"').style.borderColor='#CCC';\" unselectable='on'></td>";
               }
           ht=htt;
           id++;
           id1++;  
     }
    
document.getElementById('spltg').innerHTML=htt;
  }
  //alert( document.getElementById('spltg').innerHTML)
}
/**************************end of function**************/
      
var av=0;
flagtag=0;
function showsymbol(obj)
{
  var browser=navigator.appName;
  if(browser!="Microsoft Internet Explorer")
  // if(document.all)
   {
   //alert('xy');
     if(obj.checked==true)
     {
       document.getElementById('spltg').style.display='block';
       if(flagtag==0)
         {
            addElementtag();
            
            flagtag=1;
         }
         i=0
     }
      else
        {
           //spltg.style.display='none';
           document.getElementById('spltg').style.display='none';
        }
  }
  else if(browser=="Microsoft Internet Explorer")
  {
     if(obj.checked==true)
         {
           spltg.style.display='block';
           if(flagtag==0)
             {
                 addElementtag();
                 flagtag=1;
              }
             i=0
         }
       else
       {
         spltg.style.display='none';
       }
    }
 }

var av;
function mover(obj1)
    {
      av = obj1.id;
      document.getElementById(av).style.borderColor='blue';
   }
   
   


function showimg(obj)
  {
    var browser=navigator.appName;
   if(browser!="Microsoft Internet Explorer")
     {
        //var ab = document.getElementById('tagsprop_path11').value;
        var cid=ctr+'~img';
        ctr=parseInt(ctr+1);
        document.getElementById('ctrval').value=ctr;
        fonttoolbarenabled();
        var mydiv ='<div id='+cid+' class="key-point" contenteditable="true" name="div" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();" onresize="javascript:getdimsT();" onmove ="javascript:moves();" onkeypress="javascript:blockkey(event,\'bcd\');" oncontextmenu="javascript:context_menu(this,event);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);" contenteditable="false" style="line-height:30px;position:absolute; border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;padding-top:8px;line-height:20px;width:50px;height:50px; background-color: white; top:'+topT+'px;left:'+leftT+'px; "></div>';
        document.getElementById('editordiv').childNodes[0].innerHTML+=mydiv;
        var apath=obj.src;
        var mydiv1="<div id='div1' runat='server'onkeypress=javascript:clinthight(); javascript:getdimsT(); contenteditable='true'><img src='"+apath+"' unselectable='on'></div>";
        document.getElementById(cid).innerHTML+=mydiv1;
     }
 else if(browser=="Microsoft Internet Explorer")
  {
    var ab = document.getElementById('tagsprop_path11').value;
    var img =img1;
    var myElement = document.createElement('<div class="drag" contenteditable="false" name="div" oncontrolselect="javascript:getid(this);javascript:moves();javascript:getdimsT();" onresize="javascript:getdimsT();" onmove ="javascript:moves();" onkeypress="javascript:blockkey(event,\'bcd\');" oncontextmenu="javascript:context_menu(this,event);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);" onclick ="javascript:getid(this);" contenteditable="false" style="line-height:30px;position:absolute; border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;padding-top:8px;line-height:20px;width:50px;height:50px; background-color: white; top:'+topT+'px;left:'+leftT+'px; "></div>');
    myElement.setAttribute('id',ctr);
    editordiv.appendChild(myElement);
    currentid=ctr+'~img';
    ctr=ctr+1;
    document.getElementById('ctrval').value=ctr;
    var apath=ab+"/"+name1[av];
    fonttoolbarenabled();
    myElement.innerHTML="<div id='div1' runat='server'onkeypress=javascript:clinthight(); javascript:getdimsT(); contenteditable='true'><img src='"+apath+"' unselectable='on'></div>";
    editordiv.appendChild(myElement); 
   }
 }
 //}
/********end of tag code*************************/
function shape_select()
 {
    if(document.getElementById('myhdnval').value== null || document.getElementById('myhdnval').value=='editordiv')
    { alert('Please select item !');}
    else{
        ch=document.getElementById('picboxprop_shape').value;
        switch(ch)
        {
            case '1':{
            x =parseInt(document.getElementById(document.getElementById('myhdnval').value).style.height.replace("px",""));
            y =parseInt(document.getElementById(document.getElementById('myhdnval').value).style.width.replace("px",""));
            var newwidth  =  x+ y;
            document.getElementById(document.getElementById('myhdnval').value).style.width = newwidth;
        }break;
        case '2':{
        document.getElementById(currentid).style.width=document.getElementById(document.getElementById('myhdnval').value).style.height;
        //document.getElementById('hght').style.display='block';
        //document.getElementById('Radius').style.visibility='hidden';
        /*document.getElementById('wdth').style.display='none';*/
        }break;
        case '3':{

    obj = document.getElementById(document.getElementById('myhdnval').value);
    currentid = obj.id;
    var myElement = document.createElement('<div id="container"><b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4"></b></b><b class="rbottom"><b class="r4"></b><b class="r3"></b><b class="r2"></b><b class="r1"></b></b></div>');
    myElement.innerHTML='<div class="drag" name="textBox" oncontrolselect="javascript:getid(this);" onresize ="javascript:getdimsT();" onmove ="javascript:moves();" onkeypress="javascript:blockkey(event,\'bcd\');" onactivate="javascript:editmode(this);" ondeactivate="javascript:dragmode(this);" onfocus="javascript:getid(this);"onclick ="javascript:getid(this);" contenteditable="true" style="position:absolute;padding-top:5px;line-height:20px;width:150px;height:50px;border-bottom: black 1px solid;border-top: black 1px solid;border-left: black 1px solid; border-right: black 1px solid;top:'+topT+'px;left:'+leftT+'px;"></div>';
    //myElement.setAttribute('id',currentid);
    editordiv.appendChild(myElement);

        
        }break;
        }
    }
   }
function uploadpic(){
    opener.document.activeElement.style.borderBottomColor=tempc;
}


function select_all()
 { 
    document.getElementById("editordiv").focus();
    document.execCommand("SelectAll");
    document.getElementById("editordiv").focus();
    imgToolMenu.style.visibility = 'hidden';
  }
/******************************************************/
function getselect(a)
 {
   var browser=navigator.appName;
   if(browser!="Microsoft Internet Explorer")
    {
    if(currentid==null)
      {
       // alert('vast');
       currentid=a.id;
       // alert(currentid)
       if(currentid=='i1')
      {
       document.getElementById('img1').style.borderColor='blue';
       }
       else if(currentid=='i2')
      {
       document.getElementById('img2').style.borderColor='blue';
       }
       else if(currentid=='i4')
      {
       document.getElementById('img4').style.borderColor='blue';
       }
      else if(currentid=='i5')
      {
       document.getElementById('img5').style.borderColor='blue';
       }
       //document.getElementById('linedialog').style.display='none';
      }
    else
      {
       // alert(document.getElementById(currentid).style.borderColor);
       // alert(a.id);
        //alert(document.getElementById(a.id).style.borderColor);
        if(currentid=='i1')
      {
       document.getElementById('img1').style.borderColor='buttonface';
       }
       else if(currentid=='i2')
      {
       document.getElementById('img2').style.borderColor='buttonface';
       }
       else if(currentid=='i4')
      {
       document.getElementById('img4').style.borderColor='buttonface';
       }
      else if(currentid=='i5')
      {
       document.getElementById('img5').style.borderColor='buttonface';
       }
        //document.getElementById('img2').style.borderColor='buttonface';
        currentid=a.id;
        if(currentid=='i1')
      {
       document.getElementById('img1').style.borderColor='blue';
       }
       else if(currentid=='i2')
      {
       document.getElementById('img2').style.borderColor='blue';
       }
       else if(currentid=='i4')
      {
       document.getElementById('img4').style.borderColor='blue';
       }
      else if(currentid=='i5')
      {
       document.getElementById('img5').style.borderColor='blue';
       }
       //document.getElementById('img4').style.borderColor='blue';
      }
    
   }
 else if (browser=="Microsoft Internet Explorer") 
  {
   if(currentid==null)
      {
        currentid=document.activeElement.id;
        document.getElementById(currentid).style.borderColor='blue';
        //document.getElementById('linedialog').style.display='none';
      }
    else
      {
        document.getElementById(currentid).style.borderColor='buttonface';
        currentid=document.activeElement.id;
        document.getElementById(currentid).style.borderColor='blue';
      }
    
  }
   
}
/****************88this is code for check ad****************************/
function CheckAd(findval)
{
 var browser=navigator.appName;
 if(browser=="Microsoft Internet Explorer")
 {
    var htm = document.getElementById('editordiv').innerHTML;
    var spthtm = htm.split("<DIV");
    var countckad = spthtm.length;
    var adwidth = document.getElementById('outer').style.width;
    var adhght = document.getElementById('outer').style.height;
    var adwidth1 = adwidth.replace("px","");
    var adhght1 = adhght.replace("px","");
    for(var l=2; l < countckad; l++)
        {
           var i=0;
           var id1 = spthtm[l].split("id=");
           var id2 = id1[1].split(" ");
           //alert(id2[0]);
           if(document.getElementById(id2[0]).innerHTML == "" || document.getElementById(id2[0]).innerText==sample)
              {
                  alert('Any box remain without Picture or Text ');
                  break;
              }
            else
            {
                i=i+1;
            }
           
            var h = document.getElementById(id2[0]).style.height.replace("px","");
            var w = document.getElementById(id2[0]).style.width.replace("px","");
            var l1 = document.getElementById(id2[0]).style.left.replace("px","");
            var t = document.getElementById(id2[0]).style.top.replace("px","");
            var outt = document.getElementById('outer').style.top.replace("px","");
            outt=parseInt(outt-15);
            var outl = document.getElementById('outer').style.left.replace("px","");
            outl=parseInt(outl-10);
            if((parseInt(adwidth1) + parseInt(outl)) < (parseInt(l1) + parseInt(w)) || (parseInt(adhght1) + parseInt(outt)) <(parseInt(t) + parseInt(h)) || parseInt(outt) > parseInt(t) || parseInt(outl) > parseInt(l1))
                {
                    //alert('Any Box Out From Main Border');
                    break;
                }
             else
                {
                    i=i+1;
                    //document.getElementById('checkAds').disabled = true;
                    //alert('abc');
                }
         }
         if(i==2)
         {
            if(findval=="save")
            {
                return "true;"
            }
            else
            {
                alert("Ad is Ok");
                return;
            }
         }
      }
    else if(browser!="Microsoft Internet Explorer")
      {
      if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
        {
     //alert("in ad");
           var htm = document.getElementById('editordiv').innerHTML;
    var spthtm = htm.split("<div");
    var countckad = spthtm.length;
    var adwidth = document.getElementById('outer').style.width;
    var adhght = document.getElementById('outer').style.height;
    //alert(adwidth);
    //alert(adhght);
    var adwidth1 = adwidth.replace("px","");
    //alert(ad)
    var adhght1 = adhght.replace("px","");
    //var i=0;
    for(var l=2; l < countckad; l++)
        {
          var i=0;
         // alert(spthtm[l]);
           var id1 = spthtm[l].split("id=");
           //alert(id1[1]);
           var id2 = id1[1].split(" ");
           //alert(id2[0]);
           while(id2[0].indexOf('"')>=0)
           {
           id2[0]=id2[0].replace('"',"");
           }
           //alert(id2[0]);
           if(document.getElementById(id2[0]).innerHTML == "" || document.getElementById(id2[0]).innerText==sample)
              {
                  alert('Any box remain without Picture or Text ');
                  break;
              }
              else{
              i=parseInt(i+1);
              }
               //alert(document.getElementById(id2[0]).style.height);
            var h = document.getElementById(id2[0]).style.height.replace("px","");
            var w = document.getElementById(id2[0]).style.width.replace("px","");
            var l1 = document.getElementById(id2[0]).style.left.replace("px","");
            var t = document.getElementById(id2[0]).style.top.replace("px","");
           var outt = document.getElementById('outer').style.top.replace("px","");
            outt=parseInt(outt-15);
            var outl = document.getElementById('outer').style.left.replace("px","");
            outl=parseInt(outl-10);
            if((parseInt(adwidth1) + parseInt(outl)) < (parseInt(l1) + parseInt(w)) || (parseInt(adhght1) + parseInt(outt)) <(parseInt(t) + parseInt(h)) || parseInt(outt) > parseInt(t) || parseInt(outl) > parseInt(l1))
                {
                    //alert('Any Box Out From Main Border');
                    break;
                }
             else
                {
                  i=parseInt(i+1);
                }
         }     
      if(i==2)
      {
            if(findval=="save")
            {
                return "true;"
            }
            else
            {
                alert("Ad is Ok");
                return;
            }
      }
   }
   }           
}
/**********************************end of function ***********************/
function conversion(i_val,unit)
{
    var o_val;
    if(unit==1){o_val = i_val;}
    else if (unit==2){o_val=i_val/96;
        o_val = Math.round(o_val*100)/100;
    }else if (unit==3){o_val=(i_val/96*2.54);
        o_val = Math.round(o_val*100)/100;
    }else if(unit==4){o_val=(i_val/96*2.54*10);
        o_val=Math.round(o_val*100)/100;
    }
    return o_val;

}
function r_conversion(i_val,unit)
{   
    var o_val;
    if(unit==1){o_val = i_val;}
    else if (unit==2){o_val=i_val*96;
        o_val = Math.round(o_val*100)/100;
    }else if (unit==3){o_val=(i_val*96/2.54);
        o_val = Math.round(o_val*100)/100;
    }else if(unit==4){o_val=((i_val*96/2.54)/10);
        o_val=Math.round(o_val*100)/100;
    }
    return o_val;

}
/******************************/
function getcropped()
{
var browser=navigator.appName;
if(browser=="Microsoft Internet Explorer")
{
    var temp1 = new Array();
    var temp2 = new Array();
    //var choice = confirm('Do you want to Crop the Image');
    //if(choice){
    try
    {
        obj = document.getElementById(document.getElementById('myhdnval').value);
        if(obj==null){alert('No Element Found !');}
        else
        {
            src=obj.innerHTML;
            if(src!="")
             {
                var xx= src.match("src");
                if(xx!=null)
                 {
                    temp1 = src.split("src=\"");
                    temp2 = temp1[1].split("\"");
                    var imgsrc = temp2[0];
                    imgsrc=imgsrc.replace("file:///","");
                    imgsrc=imgsrc.replace("%20"," ");
                    document.getElementById('imagepath').value=imgsrc;
                    mywin = window.open('crop.aspx?image='+imgsrc,'','scroll=yes,status=off');
                 }
             }
             else alert("No Image!!");
         }
         //else alert("No picture available to Crop ?");
     }
    catch(er){}   
 }
 else if(browser!="Microsoft Internet Explorer")
 {
  if(document.getElementById('outer').value=="")
         {
           //alert('Please select the Template first');
         }
       else
        {
    var temp1 = new Array();
    var temp2 = new Array();
    //var choice = confirm('Do you want to Crop the Image');
    //if(choice){
    try
    {
        obj = document.getElementById(document.getElementById('myhdnval').value);
        if(obj==null){alert('No Element Found !');}
        else
        {
            src=obj.innerHTML;
            if(src!="")
             {
                var xx= src.match("src");
                if(xx!=null)
                 {
                    temp1 = src.split("src=\"");
                    temp2 = temp1[1].split("\"");
                    var imgsrc = temp2[0];
                    imgsrc=imgsrc.replace("file:///","");
                    imgsrc=imgsrc.replace("%20"," ");
                    document.getElementById('imagepath').value=imgsrc;
                    mywin = window.open('crop.aspx?image='+imgsrc,'','scroll=yes,status=off');
                 }
             }
             else alert("No Image!!");
         }
         //else alert("No picture available to Crop ?");
     }
    catch(er){} 
 }
 }
} 

/*************************************/
 function showcrop()
   {
    imageP=document.getElementById('imagepath').value;
    var hght = document.getElementById(document.getElementById('myhdnval').value).style.height;
    var wdth = document.getElementById(document.getElementById('myhdnval').value).style.width;
    var cid=document.getElementById('myhdnval').value+"pic";
    document.getElementById(document.getElementById('myhdnval').value).innerHTML='<IMG onmousemove="javascript:testmousedown();" onmouseout="javascript:testmousedown();" onmousedown="javascript:testmousedown();" onmouseup="javascript:testmousedown();" oncontextmenu="javascript:menuthis();" id=\"'+cid+'\" alt=\"\" hspace=0 src=\"'+imageP+'\" height=\"'+hght+'\" width=\"'+wdth+'\" align=baseline border=0>';
    document.getElementById('applylink').disabled=true;
   //"<IMG alt=\"\" hspace=0 src=\"D:\My Documents\Z1eu0led[1].jpg\" align=baseline border=0>"
   
   }
/*---insert--before--this--code--------------------------------------------*/ 
   
        var dragobject={
        z: 0, x: 0, y: 0, offsetx : null, offsety : null, targetobj : null , dragapproved:0,
        initialize:function(){
                document.onmousedown=this.drag
                document.onmouseup=function(){ 
                            this.dragapproved=0
                            }
                    },//9766827505 Akhil ajay 
                    drag:function(e){
                        var evtobj=window.event? window.event : e
                        this.targetobj=window.event? event.srcElement : e.target
                        if (this.targetobj.className=="drag"){
                            this.dragapproved=1
                            if (isNaN(parseInt(this.targetobj.style.left)))
                            {
                                this.targetobj.style.left=0
                            }
                            if (isNaN(parseInt(this.targetobj.style.top)))
                            {
                                this.targetobj.style.top=0
                            }
                            this.offsetx=parseInt(this.targetobj.style.left)
                            this.offsety=parseInt(this.targetobj.style.top)
                            this.x=evtobj.clientX
                            this.y=evtobj.clientY
                                                     
                            if (evtobj.preventDefault)
                            evtobj.preventDefault()
                            document.onmousemove=dragobject.moveit
                           
                            }
                            if (this.targetobj.className=="dragprop"){
                            this.dragapproved=1
                            if (isNaN(parseInt(this.targetobj.style.left)))
                            {
                                this.targetobj.style.left=0
                            }
                            if (isNaN(parseInt(this.targetobj.style.top)))
                            {
                                this.targetobj.style.top=0
                            }
                            this.offsetx=parseInt(this.targetobj.style.left)
                            this.offsety=parseInt(this.targetobj.style.top)
                            this.x=evtobj.clientX
                            this.y=evtobj.clientY
                                                     
                            if (evtobj.preventDefault)
                            evtobj.preventDefault()
                            document.onmousemove=dragobject.moveitprop
                           }
                            /************/
//                            else
//                            {
//                            this.targetobj.className="nodrag"
//                            this.dragapproved=0;
//                            }
                           /******************/ 
                        },        
                        moveit:function(e){
                            var evtobj=window.event? window.event : e
                            if (this.dragapproved==1){
                                
                                if(parseInt(this.targetobj.style.left)+parseInt(this.targetobj.style.width)> evtobj.clientX-68)
                                //if(parseInt(this.targetobj.style.left)+parseInt(this.targetobj.style.width)< evtobj.clientX-60)
                                // && (this.targetobj.style.left).replace("px","")<evtobj.clientX-70)
                               {                                
                                  this.targetobj.style.left=this.offsetx+evtobj.clientX-this.x+"px"
                                  this.targetobj.style.top=this.offsety+evtobj.clientY-this.y+"px"
                               }
                                                              
                                return false
                                }
                            },
                            moveitprop:function(e){
                            var evtobj=window.event? window.event : e
                            if (this.dragapproved==1){
                                this.targetobj.style.left=this.offsetx+evtobj.clientX-this.x+"px"
                                this.targetobj.style.top=this.offsety+evtobj.clientY-this.y+"px"
                                return false
                                }
                            }
                                
                                 
                            
                    }
                    dragobject.initialize()
                    
                    
                  
                      
/*------------------do not change--above--this--code--------------------------------------------*/ 
              
                
 function notchar2()
{
//alert(event.keyCode);

if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
{
return true;
}
else
{
return false;
}

}


/***********************/


function clinthight()
  {
    if(parseInt(document.getElementById('div1').offsetWidth)>parseInt(660))
      {
        return false;
      }
//   else
//      {
//       (parseInt(document.getElementById('div1').offsetHeight)>parseInt(660))
//       return false;
//      }

if(parseInt(document.getElementById('div1').offsetHeight)>parseInt(660))
      {
        return false;
      }
   }



/******************this is code for spell check***************/


function spellcheck()
{




}


/***********************************bad word************/

function checkbword()
{


if(document.getElementById('textdialog').innerText!="")
str= document.getElementById(document.getElementById('myhdnval').value).outerText;
 {
 
     if(str.indexOf(ank)>=0)
     {
     if(ank!="")
     {
          blockkey(event,'abc');
      }
      else
      {
         if(badcount==0)
       {
       badcount=str.length;
       _Default.chk2badword(str.trim(),fillcall1);
       }
       else
       {
       var mynewstring="";
       mynewstring=str.substring(badcount,str.length)
        badcount=str.length;
        if(mynewstring.trim()!="")
        {
        _Default.chk2badword(mynewstring.trim(),fillcall1);
        }
      }
     }
     }
     else
     
     {
       ank=str;
       
       if(badcount==0)
       {
       badcount=str.length;
       _Default.chk2badword(str,fillcall1);
       }
       else
       {
       var mynewstring="";
       mynewstring=str.substring(badcount,str.length)
        badcount=str.length;
       _Default.chk2badword(mynewstring,fillcall1);
       }
    
   return;
   }
  
  }
 }  
 
// if(ds.Tables[1].Rows.length==0

//}

function fillcall1(res)
{
var ds=res.value;
var splitval=ds.split("~");
var length=document.getElementById('editordiv').children.length;
if(splitval[0]=="True")
{
   
   myresult="True";


   
   alert('You can not use this word'+splitval[1]+' Coz this is Badword')
   editordiv.innerHTML=editordiv.innerHTML.replace(splitval[1],"")
   return;
}
else
{
    
}



//if(ajay!=null)
//{

//var code=ajay;
//code++;
//document.getElementById('textdialog').value=str.substr(0,2)+code;
//}

}


///**********************************/
//       
//		                    if(newstr !=null )
//		                        {
//		                        //var code=newstr.substr(2,4);
//		                        var code=newstr;
//		                        code++;
//		                        document.getElementById('Autocode').value=str.substr(0,2)+ code;
//		                         }
//		                    else
//		                      {
//		                        document.getElementById('Autocode').value=str.substr(0,2)+ "0";
//		                      }
//		     }
//		     
//		     
//		     
//	return false ;
//		}
/**************************************/

function catwise(obj)
{
 if(document.getElementById('newlayoutprop_cattmp').checked==true)
   {
   //alert('abcv');
   document.getElementById('newdialog').style.display='none';
   document.getElementById('tmpcat').style.display='block';
   _Default.binddiv(aa_callback);
    return false;
   }
//   else
//   {
//   
//   
//   }


}
function  aa_callback(res)
{
 var catname=document.getElementById('catname')
  for (var i = (catname.options.length-1); i >= 0; i--)

    {
         catname.remove(i)
     }
   var ds=res.value
  
   for (var a = 0; a <= ds.Tables[0].Rows.length - 1; a++)
        {
            catname.options[catname.options.length] = new Option(ds.Tables[0].Rows[a].adv_cat_name ,ds.Tables[0].Rows[a].adv_cat_code);
           //catname.options.length;
        }
   }
function test(a)
{
 document.getElementById('aaaa').value=a
 //document.getElementById('tmpcat').style.display='none';
 document.getElementById('newdialog').style.display='block';
 
}

function mydata(a)
{
if(a=="All")
{
 //alert('ankur-2');
_Default.bindxml(temp_callback);
}
else
{
   //alert('ankur-4');
  _Default.bindtemplate(a,temp_callback);
}
  

}
function temp_callback(res)
 {
 //('ankur4-1');
  var ds=res.value;
 var tempname="";
 var  xmllist1=document.getElementById('openTemplate1_xmllist1')
 for (var i = (xmllist1.options.length-1); i >= 0; i--)

    {
         xmllist1.remove(i)
     }
    // tempname=ds.Tables[0].Rows[0].adv_cat_name;
  
   for (var a = 0; a <= ds.Tables[0].Rows.length - 1; a++)
        {
            xmllist1.options[xmllist1.options.length] = new Option(ds.Tables[0].Rows[a].name ,ds.Tables[0].Rows[a].name);
           //catname.options.length;
        }
        
        
        //select the value
        if(document.getElementById('hiddencat').value!="")
        {
            for(k=0;k<document.getElementById('openTemplate1_catname').length-1;k++)
            {
                if(document.getElementById('openTemplate1_catname').options[k].value==document.getElementById('hiddencat').value)
                {
                    document.getElementById('openTemplate1_catname').options[k].selected=true;
                }
                else
                {
                  document.getElementById('openTemplate1_catname').options[k].selected=false;                    
                }
                            
            }

        }
        document.getElementById('hiddencat').value="";

}
//}

//<a href =window.open("adtaker.aspx",'','left=300px,top=250px,height=200px,width=450px,scroll=no,status=off');

/*****************************************/

function popupwindow()
{
  formatadd = window.open('adpreview.aspx','','left=150px,top=100px,height=100px,width=200px,scroll=no,status=off');
}




/**************************************/
function check(e)
{
var splitval=e.split("_")
  if(document.getElementById(e).checked==true)
    {
        document.getElementById('btndelete_'+splitval[1]).disabled=false;
        document.getElementById('btnedit_'+splitval[1]).disabled=false;
        return false;
    }
    else
    {
        document.getElementById('btndelete_'+splitval[1]).disabled=true;
        document.getElementById('btnedit_'+splitval[1]).disabled=true;
        document.getElementById('btnupdate_'+splitval[1]).disabled=true;
        return false;
    }
}


/*******this code for edit button*********** +splitval[1]*/

function editval(name,code,id)
  {
       var splitval=id.split("_")
        document.getElementById('btnedit_'+splitval[1]).disabled=true;
       document.getElementById('btndelete_'+splitval[1]).disabled=false;
       document.getElementById('btnupdate_'+splitval[1]).disabled=false;
       document.getElementById('txtname_'+splitval[1]).readOnly=false;

  }
  
  
  
  function updateval(name,code,id)
   {
      var splitval=id.split("_")
      var word=document.getElementById('txtname_'+splitval[1]).value;
      updaterecord=id;
      badwordnew.updatedata(word,code,res)
      
   }
  
  function res(rr)
  {
      var ank=rr.value;
      var splitval=updaterecord.split("_")
      document.getElementById('btnedit_'+splitval[1]).disabled=true;
      document.getElementById('btndelete_'+splitval[1]).disabled=true;
      document.getElementById('btnupdate_'+splitval[1]).disabled=true;
      document.getElementById('txtname_'+splitval[1]).readOnly=true;
      document.getElementById('chkbad_'+splitval[1]).checked=false;
    
  }
  
  
  
function deleteval(name,code,id)
{
   var splitval=id.split("_")
   var word=document.getElementById('txtname_'+splitval[1]).value;
   deleterecord=id;
   badwordnew.deletedata(word,code,resdelete)
}

function resdelete(ab)
{
   var del=ab.value;
   var splitval=deleterecord.split("_")
   document.getElementById('btnedit_'+splitval[1]).disabled=true;
   document.getElementById('btndelete_'+splitval[1]).disabled=true;
   document.getElementById('btnupdate_'+splitval[1]).disabled=true;
   document.getElementById('txtname_'+splitval[1]).readOnly=true;
   document.getElementById('chkbad_'+splitval[1]).checked=false;
      
   document.getElementById('btnedit_'+splitval[1]).value="deleted";
   document.getElementById('btndelete_'+splitval[1]).value="deleted";
   document.getElementById('btnupdate_'+splitval[1]).value="ssdeleted";
   document.getElementById('chkbad_'+splitval[1]).disabled=true;
}
  
  