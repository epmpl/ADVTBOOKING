/*\
|*| Version : 0.92
|*| Author  : Chaitanya Yinti
|*| Contact : yinti@users.sourceforge.net
|*| WebSite : http://dhtmlgrid.sourceforge.net/
|*|
|*| Feel free to use this script under the terms of the GNU General Public
|*| License, as long as you do not remove or alter this notice.
\*/

  /*************************************\
  |       Start of Config Param         |
  \*************************************/ 
  var f_grid="";
  var objinput_var;
  var colName="";
  var activeIDNo;
  var activeRow="";
    var activeCell="";
  // Color used for hilighting a selected row
  var clrHilight = 'blue';

  // Set this to false if you want 'click to select' and
  // 'doubleclick to Edit' mode
  var blnPointToSelect = true;

  // Full path of the blank image used to hide the sort images 
  var strBlankImage = "blank.gif";

  // Full path of the up image used on sort asc
  var strUpImage = "up.gif";  

  // Full path of the up image used on sort des
  var strDownImage = "down.gif";

  // The width of the images used to indicate the asc/des sort
  var intImgWidth = 12;

  // The height of the images used to indicate the asc/des sort
  var intImgHeight = 13;  
  /*************************************\
  |           End of Config Param       |
  \*************************************/

  /*************************************\
  |           Globals start             |
  \*************************************/

  // Stores the last used object during sort
  var objLastClick = -1;

  // Stores the text being edited
  var txtOld = "";

  // Stores the total table width
  var intTotalWidth = 0;

  // Stores the flag used by capturemouse
  var blnMouseOver = false;  

  // Stores the div being moved
  var objDivToMove = null;

  // Stores the number of coloumns; initialized in init ()
  var intColCount = 0;

  // Stores the row element currently selected
  var objRowSelected = null;

  //THE element which holds the table... 
  var element = null;
  /*************************************\
  |           Globals end               |
  \*************************************/

  /*********************TODO*****************************\
   prototype setCapture/releaseCapture PROPERLY
   Get rid of isIE, isNS4 completely ...
   Extend keycapture to navigate the table on up/down arrow
   Fix escape/unescape on text change
  \******************************************************/
    
  /*\
  |*| The entry point. This will 
  |*|    Attache all the appropriate functions to the table
  |*|    Call function to create the IMG elems used during the sorting
  |*|    call function to init the DIV elems that are used for moving
  |*|    call function to init the DIV elems used for about box
  \*/
//  function addRow()
//  {
//     var tbl = document.getElementById('tblGrid');
//  var lastRow = tbl.rows.length;
//  // if there's no header row in the table, then iteration = lastRow + 1
//  var iteration = lastRow;
//  var row = tbl.insertRow(lastRow);

//  }
  function init (tableName)
  {
    //Handle all javascript errors 
    window.onerror = handleError;

    isIE = (navigator.appVersion.indexOf ("MSIE") != -1);
    isNS4 = (document.layers) ? true : false;
    isNS6 = (!document.layers) && (navigator.userAgent.indexOf ('Netscape')!=-1);

    if ((isNS4) && (!isNS6)) alert ("Currently only supports NN 6 and above");

    if (document.getElementById)
      element = document.getElementById (tableName);
    else  //TODO: Need to test this piece of code still. Happens only in NN4 so far 
      eval (element = "document." + tableName);

    if (element == null)
      return alert ("Error: Not able to get table element ");

    if (element.tagName != 'TABLE')
      return alert ("Error: Not able to control element " + element.tagName);

    initNNFunctions ();

    if (blnPointToSelect)
    {
    //  element.attachEvent ('onmouseover', selectRow);
      element.attachEvent ('onclick', onClickCell);
    }
    else
    {
      element.attachEvent ('onclick', selectRow);
      element.attachEvent ('ondblclick', onClickCell);
    }

    document.attachEvent ('onkeydown' , captureDelKey);

    //Need this fix for IE only .. so element.focus is stubbed in NN
    try{
    element.focus ();
  }
  catch(err)
      {}
    initSortImages();
    //initDiv ();
    initAbout ();
    document.getElementById(tableName).disabled=true;
  }

  /*\
  |*| This function removes the textnodes from the table rows.
  |*| This cleanup work is needed to get rid of the EXTRA textnodes that NN gives
  \*/

  function removeTextNodes (t)
  {
    for (var i = 0; t.childNodes[i] ; i++)
    {
      if (!t.childNodes[i].tagName)
      {
         t.childNodes[i].parentNode.removeChild (t.childNodes[i]);
      }
      else
      {
        for (var j = 0; t.childNodes[i].childNodes[j] ; j++)
        {
          if (!t.childNodes[i].childNodes[j].tagName) 
            t.childNodes[i].childNodes[j].parentNode.removeChild (t.childNodes[i].childNodes[j]);
        }
      }
    }

  }

  /*\
  |*| This function adds the blank images to the head row of the table
  \*/
  function initSortImages ()
  {
    if (!element.tHead) return;
    removeTextNodes (element.tHead);
    var theadrow = element.tHead.childNodes[0]; //Assume just one Head row

    if (isIE) theadrow.style.cursor = "hand";
    else theadrow.style.cursor = "pointer";

    removeTextNodes (theadrow.parentNode);
    intColCount = theadrow.childNodes.length;

    for (var i = 0; i < intColCount; i++) 
    {
      objImg = document.createElement ("IMG");

      objImg.setAttribute ("src", strBlankImage);
      objImg.setAttribute ("id", "srtImg" + i);
      objImg.setAttribute ("width", intImgWidth);
      objImg.setAttribute ("height", intImgHeight);
      objImg.setAttribute ("align", "right");
      objImg.setAttribute ("valign", "middle");
      objImg.setAttribute ("border", 0);

      clickCell = theadrow.childNodes[i];
      clickCell.selectIndex = i;
      clickCell.insertAdjacentElement ("afterBegin", objImg);
      clickCell.style.width = clickCell.width;
    }
  }

  /*\
  |*| This will only be called once during initIALIZATION
  |*| This will create the DIV elems at the end of each col and
  |*| attach all the functions needed to resize the coloumns
  \*/
  function initDiv ()
  {
    var objLast = element, objDiv;
    removeTextNodes (element.tBodies[0]);

    for (var i = 1; i <= intColCount; i++)
    {  
      objDiv = document.createElement ("DIV");
      objDiv.setAttribute ('id', "DragMark" + (i - 1));
      objDiv.setAttribute ('name',  i);    //Used to track the TDs that have to be moved
      objDiv.style.position = "absolute";
      objDiv.style.top = 0; 

      var objTD = element.tHead.childNodes[0].childNodes[i - 1];
      if (!objTD || objTD.tagName != "TD") return;

      var intColWidth = (getRealPos (objTD) - 0) + (objTD.width - 0);

      objDiv.style.left = intColWidth - 3 ;
      objDiv.style.width = 6 + parseInt(element.border);
      objDiv.style.height = (element.tBodies[0].childNodes.length + 1) * objTD.offsetHeight;
      // for debugging only
      //objDiv.style.backgroundColor = clrHilight;
      
      //To make it more beautiful in IE 6  
      if (navigator.appVersion.indexOf ("MSIE 6.0") != -1)
        objDiv.style.cursor = "col-resize";
      else
        objDiv.style.cursor = "crosshair";

      objDiv.attachEvent ('onmouseover', flagTrue);
      objDiv.attachEvent ('onmousedown', captureMouse);
      objDiv.attachEvent ('onmousemove', resizeColoumn);
      objDiv.attachEvent ('onmouseup', releaseMouse);
      objDiv.attachEvent ('onmouseout', flagFalse);

      objLast.insertAdjacentElement ("afterEnd", objDiv);
      objLast = objDiv;
    }
  }

  /*\
  |*| This function will be fired onmouseover of the DIVs
  |*| Set the flag to true indicating that the mouse is over the DIV
  \*/
  function flagTrue ()
  {
    blnMouseOver = true;
  }

  /*\
  |*| This function will be fired onmousedown on the DIVs
  |*| Capture all the mosue events if mousedown is fired inside the DIV
  \*/
  function captureMouse ()
  {
    if (blnMouseOver)
    {
      objDivToMove = window.event.srcElement;
      objDivToMove.setCapture ();
    }
  }

  /*\
  |*| This function will be fired onmousemove of the DIVs
  |*| This will be used as a ondrag function... thanks to IE 5
  \*/
  function resizeColoumn ()
  {
    //If mouse button is down, objDivToMove will be valid... we can move/resize
    if (!objDivToMove) return;

    var intTDNum = objDivToMove.name - 1;
    var thead = element.tHead;

    if (!thead) return;

    var objTD = thead.childNodes[0].childNodes[intTDNum];

    if (!objTD || objTD.tagName != "TD") return;

    var intCurWidth = objTD.offsetWidth;
    var newX = window.event.clientX;
    //var newX = window.event.x;
    var intNewWidth = newX - objTD.offsetLeft;

    //TODO: who decided that the minimum col widhth is 50px?
    if (intNewWidth < 50) return;
    //Check to see if the table widht is more than the width of the window
    //Need that 20px buffer in IE to prevent scroll bars from appearing
    if (element.document.body.offsetWidth - 20 < element.offsetWidth - intCurWidth + intNewWidth) return;

    objTD.style.width = intNewWidth;

    var objDiv = objDivToMove;
    //Will be � 1 depending on which side the mouse moved
    //will be used to move all the DIVs remaining on the right
    var intDivMove = newX - objDiv.offsetLeft;
    objDiv.style.left = newX;

    //Move all the remaining DIVs on the right
    for (var i = 1; i < intColCount - intTDNum; i++)
    {        
      objDiv = objDiv.nextSibling;
      objDiv.style.left = objDiv.offsetLeft + intDivMove ;
    }
  }

  /*\
  |*| This function will be fired onmouseup
  |*| Release all the mouse events of the DIV
  \*/
  function releaseMouse ()
  {
    objDivToMove.releaseCapture ();
    objDivToMove = null;
  }

  /*\
  |*| This function will be fired onmouseout of the DIV
  |*| Set the flag indicating that the mouse is NOT over the DIV
  \*/
  function flagFalse ()
  {
    blnMouseOver = false;
  }

  /*\
  |*| This function will be called once during initIALIZATION
  |*| This will create DIV elm after the table to display the ABOUT informationA
  \*/
  function initAbout ()
  {
    objDiv = window.document.createElement ("DIV");
    objDiv.id = "About";
    objDiv.style.position = "absolute";
    objDiv.style.top = 0; 
    objDiv.style.left = 0 ;
    objDiv.align = "center";
    //element.document.body.offsetWidth ==> width of the IFRAME in IE
    objDiv.style.width = element.document.body.offsetWidth;
    objDiv.style.height = element.document.body.offsetHeight;
    objDiv.style.backgroundColor = "#0000FF";
    objDiv.style.color = "#FFFF00";
    objDiv.style.visibility = "hidden";
    objDiv.insertAdjacentText ("afterBegin", "DHTML Grid ver 0.92\n\n" + "");

    var objInput = document.createElement ("INPUT");
    objInput.id = "cmdAbout";
    objInput.title = "Ok";
    objInput.value = "Ok";
    objInput.align = "center";
    objInput.valign = "middle";
    objInput.style.height = "30px";
    objInput.style.width = "102px";
    objInput.type = "button";
    objInput.attachEvent ("onclick", about);

    objDiv.insertAdjacentElement ("beforeEnd", objInput);
    element.insertAdjacentElement ("afterEnd", objDiv);
  }

  /*\
  |*| Hilights the row on mouseover. This also sets the "previous row selected" to normal
  \*/
  function selectRow ()
  {
    var srcElem = getEventRow ();

    if (srcElem.tagName != "TR") return;
    if (objRowSelected)
    {
      objRowSelected.style.backgroundColor = '';
      objRowSelected = null;
    }
    if (srcElem.rowIndex > 0)
    {
      srcElem.style.backgroundColor = clrHilight;
      objRowSelected = srcElem;
    }
    element.focus ();
  }

  /*\
  |*| Entry point for all the click events on the table
  \*/
  function onClickCell ()
  {
  f_grid="";
//  var objSrcElm =  window.event.srcElement;
//    try{
//      if(document.activeElement!=null && document.activeElement.id!="lstcommon")
//      {
//       
//       // alert(objSrcElm.value);
//       
//        if(objSrcElm.value!="undefined" && objSrcElm.value!=undefined && objSrcElm.parentNode!="null" && objSrcElm.parentNode!=null)
//            objSrcElm.parentNode.innerHTML = unescape (objSrcElm.value);
//       
//       } 
//     // focusLost ();
//      }
//      catch(err){}
    var srcElem = getEventRow ();

    if (srcElem.tagName != "TR") return;
    if (srcElem.rowIndex == 0) sort ();
    else {
    var srcElem = getEventCell ();
    onEdit ();
    }
  }

  /*\
  |*| Capture the key press event, on del key see if a row is selected and delete
  \*/
  function captureDelKey ()
  {
    var keyPressed = event.keyCode;
    
    var srcElem = window.event.srcElement;
    if ((keyPressed == 46) && (srcElem.tagName != "INPUT") && (objRowSelected))
    {
      deleteRow (objRowSelected.rowIndex - 1);
      objRowSelected = null;
    }
   
  }

  /*\
  |*| detach all the events attached to the element and call other cleanup functions
  \*/
  function cleanup ()
  {
   // element.detachEvent ('onmouseover', selectRow);
    element.detachEvent ('onclick', onClickCell);
    cleanupDiv ();
    cleanupAbout ();
  }

  /*\
  |*| Used by cleanup to clean the DIVs created for moving the Cols
  |*| detach all the events and delete the elements here
  \*/
  function cleanupDiv ()
  {
    var objDiv;
    for (var i = 1; i <= intColCount; i++)
    {  
      objDiv = element.document.getElementById ("DragMark" + (i - 1));
      objDiv.detachEvent ('onmouseover', flagTrue);
      objDiv.detachEvent ('onmousedown', captureMouse);
      objDiv.detachEvent ('onmousemove', resizeColoumn);
      objDiv.detachEvent ('onmouseup', releaseMouse);
      objDiv.detachEvent ('onmouseout', flagFalse);
      objDiv.removeNode (true);
    }
  }

  /*\
  |*| Detach all the events and Delete the elms related to the about box here
  \*/
  function cleanupAbout ()
  {
    element.document.getElementById ("About").removeNode (true);
  }

  /*\
  |*| This is THE function which does all the real sorting of the rows
  |*| First get rid of all the text-node elements that NN returns for spaces in the tables
  |*| then sort the contents based on which coloumn is clicked
  \*/
  function insertionSort (t, iRowEnd, fReverse, iColumn)
  {
    var textRowInsert, textRowCurrent, eRowInsert, eRowWalk;
    removeTextNodes (t);
    for (var iRowInsert = 1 ; iRowInsert <= iRowEnd ; iRowInsert++)
    {
      if (iColumn)
      {
        if (typeof (t.childNodes[iRowInsert].childNodes[iColumn]) != "undefined")
           textRowInsert = t.childNodes[iRowInsert].childNodes[iColumn].innerText;
        else
          textRowInsert = "";
      }
      else
      {
        textRowInsert = t.childNodes[iRowInsert].innerText;
      }

      for (var iRowWalk = 0 ; iRowWalk < iRowInsert ; iRowWalk++)
      {
        if (iColumn)
        {
          if (typeof (t.childNodes[iRowWalk].childNodes[iColumn]) != "undefined")
            textRowCurrent = t.childNodes[iRowWalk].childNodes[iColumn].innerText;
          else
            textRowCurrent = "";
        }
        else
        {
          textRowCurrent = t.childNodes[iRowWalk].innerText;
        }
        if ((!fReverse && textRowInsert < textRowCurrent) || (fReverse && textRowInsert > textRowCurrent))
        {
          eRowInsert = t.childNodes[iRowInsert];
          eRowWalk = t.childNodes[iRowWalk];
          t.insertBefore (eRowInsert, eRowWalk);
          iRowWalk = iRowInsert; // done
        }
      }
    }
  }

  /*\
  |*|  This function is called when there is a click event on the top
  |*|  row
  \*/
  function sort ()
  {
    var srcElem = getEventCell ();
    if (srcElem.tagName != "TD") return;

    var thead = element.tHead;  
    // clear the sort images in the head
    var imgcol = thead.getElementsByTagName ("IMG");
    for (var x = 0; x < imgcol.length; x++) 
    {
      imgcol[x].setAttribute('src', strBlankImage);
    }

    if (objLastClick == srcElem.selectIndex)
    {
      if (reverse == false)
      {
        srcElem.childNodes[0].setAttribute ('src', strDownImage);
        reverse = true;
      }
      else 
      {
        srcElem.childNodes[0].setAttribute ('src', strUpImage);
        reverse = false;
      }
    }
    else
    {
      reverse = false;
      objLastClick = srcElem.selectIndex;
      srcElem.childNodes[0].setAttribute ('arc', strUpImage);

    }
    tbody = element.tBodies [0];
    insertionSort (tbody, tbody.rows.length-1, reverse, srcElem.selectIndex);
  }

  /*\
  |*| This function is called when focus is lost on the text box
  |*| that is used to read user input. Validate the contents of the
  |*| input box and write them back to the table cell
  \*/
  function focusLost ()
  {
 
  if(document.activeElement!=null && document.activeElement.id!="lstcommon")
  {
    var objSrcElm = window.event.srcElement; 
   // alert(objSrcElm.value);

    if (objSrcElm.value != "undefined" && objSrcElm.value != undefined && objSrcElm.value != "" && objSrcElm.parentNode != "null" && objSrcElm.parentNode != null && objSrcElm.value != "0")
        objSrcElm.parentNode.innerHTML = unescape (objSrcElm.value);
   
   } 
  }

  /*\
  |*| This function is called when user clicks on a cell other than
  |*| the top row.
  |*| Show the content of the cell in an input box
  \*/
   function onEditID (s)
  {
   try{
   

   if(document.getElementById("div_electronics").style.display=="none")
        element = document.getElementById ('tblGrid');
   else
        element = document.getElementById ('tblGridelec');     
    var srcElem = s;//getEventCell ();
      //alert(srcElem);
     var cellindex=srcElem.cellIndex;
     //alert(cellindex);
    // alert(element.tHead.childNodes[0]);
    colName=element.tHead.childNodes[0].childNodes[cellindex].childNodes[0].nextSibling.data;
    // alert(colName);
    if (srcElem.tagName != "TD") return;
    if (srcElem.firstChild && srcElem.firstChild.tagName == "INPUT") return;
    
    txtOld = srcElem.innerHTML;
    
   
    srcElem.innerHTML = ""; 
    var objInput = document.createElement ("INPUT");
    objInput.style.width = "100%";//srcElem.clientWidth;
    objInput.type = "text";
 
    //objInput.value = "" + escape (txtOld);
     objInput.value = "" +  (txtOld);
    //objInput.attachEvent ("onfocusout", focusLost);
    //the above onfocusout works fine in IE 6 but not in IE 5 so...
    objInput.attachEvent ("onblur", focusLost);
    objInput.attachEvent ("onkeypress", checkForEnter);

    srcElem.insertAdjacentElement ("beforeEnd", objInput);

    objInput.select ();
   
    objInput.focus();
    objinput_var=objInput;
     var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
    setTimeout("setfocuus1()",2);
  }  
    }
     catch(err)
      {}
  }
  function setfocuus1()
  {
  f_grid="";
  objinput_var.focus();
  
  }
  function onEdit ()
  {
    if(document.getElementById("div_electronics").style.display=="none")
        element = document.getElementById ('tblGrid');
   else
        element = document.getElementById ('tblGridelec');   
    var srcElem = getEventCell ();
    var cellindex=srcElem.cellIndex;
    try{
    colName=element.tHead.childNodes[0].childNodes[cellindex].childNodes[0].nextSibling.data;
    }
    catch(err)
    {
    }
    if (srcElem.tagName != "TD") return;
    if (srcElem.firstChild && srcElem.firstChild.tagName == "INPUT") return;
    
    txtOld = srcElem.innerHTML;
    srcElem.innerHTML = ""; 
    try{
        //alert(objinput_var);
     if(objinput_var.value!="undefined" && objinput_var.value!=undefined && objinput_var.parentNode!="null" && objinput_var.parentNode!=null)
            objinput_var.parentNode.innerHTML = unescape (objinput_var.value);

    }
    catch(err)
    {
    }
    var objInput = document.createElement ("INPUT");
    objInput.style.width = "100%";//srcElem.clientWidth;
    objInput.type = "text";
  //  objInput.value = "" + escape (txtOld);
    objInput.value = "" +  (txtOld);
    //objInput.attachEvent ("onfocusout", focusLost);
    //the above onfocusout works fine in IE 6 but not in IE 5 so...
    objInput.attachEvent ("onblur", focusLost);
    objInput.attachEvent ("onkeypress", checkForEnter);

    srcElem.insertAdjacentElement ("beforeEnd", objInput);

    objInput.select ();
    objinput_var=objInput;
  }

  /*\
  |*| This function is used to add a row at the end of the tabl
  |*| Once the rows are added it calls the function to change the height
  |*|  of the DIVs that are used for resizing the table.
  \*/
  function addRow ()
  {
    var objTR = document.createElement ("TR");
    var objTD = document.createElement ("TD");

    for (var i = 0; i < addRow.arguments.length; i++) 
    {
      objTD = document.createElement ("TD");
     
     
        if(element.id=='tblGridelec' && i==0)
        {
            objTD.title="Press F6 for Entering Electronics Detail";
        }
        if (element.id == 'tblGrid' && i == 0) {
            objTD.title = "Press F6 for Entering Print Detail";
        }
        else  if((i==addRow.arguments.length-3 || i==addRow.arguments.length-4 || i==addRow.arguments.length-2)&& element.id=='tblGridelec')
            objTD.className="tdcls1";
        else  if(i==addRow.arguments.length-3 && element.id=='tblGrid')
            objTD.className="tdcls1";    
        else  
            objTD.className="tdcls";
      objTD.appendChild (document.createTextNode ((arguments[i]=="")?"":arguments[i]));
      objTR.insertAdjacentElement ("beforeEnd", objTD);

    }

    objTBody = element.tBodies [0];
    objTBody.insertAdjacentElement ("beforeEnd", objTR);

    resizeDivs ();
    colName="";
  }
  

  /*\
  |*| The function deletes the last row by calling the deleteRow function 
  |*|  with the table row count
  \*/
  function deleteLastRow ()
  {
    removeTextNodes (element.tBodies[0]);
    this.deleteRow (element.tBodies[0].childNodes.length - 1);
  }

  /*\
  |*| The function checks if the rownum passed is a valid row 
  |*|  and deletes it 
  |*| This also calls the resizeDivs function to reduce the height
  |*|  of the DIVs that are used in resizing the table
  \*/
  function deleteRow (rowNum)
  {
    var tbody = element.tBodies [0];
    if (!tbody || rowNum < 0) return;

    removeTextNodes (tbody);
    tbody.childNodes[rowNum].removeNode (true);
    resizeDivs ();
  }
function deleteClickGrid()
{
    var count=document.getElementById('tblGrid').rows.length;
    for(var i=1;i<count;i++)
    {
       element = document.getElementById ('tblGrid');
       deleteLastRow();
    }
    addRow('', '', '', '', '', '', '0', '0', '0', '0', '0', '', '', '', '', '', '', '', '', '', 'Yes(Y)', '', document.getElementById('hiddencurrency').value, '', '', '', '', '', '','','','','','','');
    count=document.getElementById('tblGridelec').rows.length;
    for(var i=1;i<count;i++)
    {
       element = document.getElementById ('tblGridelec');
       deleteLastRow();
    }
    addRow('', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', document.getElementById('hiddencurrency').value, '', '', '', 'Yes(Y)', '', '', '', '', '', '', '', '', '', '', '', '','','','','','');//
    return false;
}
  /*\
  |*| This will be called on everkeypress event of the input box
  |*| This raises the focuslost event if the user hits enter
  \*/
  function checkForEnter ()
  {
 // alert("enter");
  var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
    if(f_grid!="")
        return;
    if (event.which == 13 || event.which == 9 && (document.activeElement.id!="lstcommon"))
    {
    
    if(colName=="Sponsorship From" || colName=="Sponsorship To" )
    {
        var res=checkdateG(document.activeElement);   
        if(res==false)
        {
            return false;
        }    
    }
    
   //  var srcElm=getEventRow();
   var srcElm = window.event.srcElement;
    var objSrcElm = srcElm; 
    //crawl up to find the row
    while (srcElm.tagName != "TR" && srcElm.tagName != "TABLE")
    {
      srcElm = srcElm.parentNode;
    }
    
     if(activeRow=="")
     activeRow=srcElm.rowIndex;
    var objSrcElm = window.event.srcElement; 
   var s=(objSrcElm.parentNode).parentNode;
    var f=false;
    var tn=0;
    
        for(i=0;i<s.childNodes.length;i++)
        {
            if(s.childNodes[i]==(objSrcElm.parentNode))
            {
                if((i+1)<s.childNodes.length)
                {
                    f=true;
                    
                     f_grid="a";
                     try{
                      if(document.activeElement!=null && document.activeElement.id!="lstcommon")
                      {
                       
                       // alert(objSrcElm.value);
                       
                        if(objSrcElm.value!="undefined" && objSrcElm.value!=undefined && objSrcElm.parentNode!="null" && objSrcElm.parentNode!=null)
                            objSrcElm.parentNode.innerHTML = unescape (objSrcElm.value);
                       
                       } 
                     // focusLost ();
                      }
                      catch(err){}
                    onEditID(s.childNodes[parseInt(i,10)+1]);
                    tn=i;
                    i=s.childNodes.length;
                  
                }
             }
        }
     // alert(objSrcElm.id);
    //var s=(objSrcElm.parentNode).parentNode;
//    var s=(objSrcElm.parentNode);
// //alert(s);
//    var f=false;
//    var tn=0;
//        for(i=0;i<s.parentNode.childNodes.length;i++)
//        {
//         //   alert(s.childNodes[i]);
//          // alert(objSrcElm);
//            if(s.childNodes[i]==(objSrcElm))
//            {
//            //    alert("parentnoce");
//                if((i+2)<s.parentNode.childNodes.length)
//                {
//                    f=true;
//                  
//                    onEditID(s.parentNode.childNodes[parseInt(i,10)+3]);
//                    tn=i;
//                    i=s.parentNode.childNodes.length;
//                }
//             }
//        }
        if(document.getElementById('div_electronics').style.display=="none" && tn==54)
            f=false;
        else if(document.getElementById('divprint').style.display=="none" && tn==76) 
            f=false;   
        if(f==false)
        {
            if(document.getElementById('div_electronics').style.display=="none")
            {
                if(s.rowIndex==document.getElementById('tblGrid').rows.length-1)
                {
                    if(confirm('Are you sure you want to Add Row?')==false)
                        return false;
                    else
                        addRow('', '', '', '', '', '', '0', '0', '0', '0', '0', '', '0', '', '', '', '', '', '', '', 'Yes(Y)', '', document.getElementById('hiddencurrency').value, '', '', '', '', '', '','','','','','','');
                } 
            }    
            else{
                if(s.rowIndex==document.getElementById('tblGridelec').rows.length-1)
                {
                     if(confirm('Are you sure you want to Add Row?')==false)
                        return false;
                    else
                        addRow('', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', document.getElementById('hiddencurrency').value, '', '', '', 'Yes(Y)', '', '', '', '', '', '', '', '', '', '', '', '','','','','','')//
                } 
            }   
           // onEdit();
        }    
   
     }
   }
   else{
    if (event.keyCode == 13 || event.keyCode == 9 && (document.activeElement.id!="lstcommon"))
    {
    if(colName=="Sponsorship From" || colName=="Sponsorship To" )
    {
        var res=checkdateG(document.activeElement);   
        if(res==false)
        {
            return false;
        }    
    }
     var srcElm=getEventRow();
     if(activeRow=="")
     activeRow=srcElm.rowIndex;
    var objSrcElm = window.event.srcElement; 
      //alert(objSrcElm.id);
    var s=(objSrcElm.parentNode).parentNode;
    var f=false;
    var tn=0;
        for(i=0;i<s.childNodes.length;i++)
        {
            if(s.childNodes[i]==(objSrcElm.parentNode))
            {
                if((i+1)<s.childNodes.length)
                {
                    f=true;
                      f_grid="a";
                     try{
                      if(document.activeElement!=null && document.activeElement.id!="lstcommon")
                      {
                       
                       // alert(objSrcElm.value);
                       
                        if(objSrcElm.value!="undefined" && objSrcElm.value!=undefined && objSrcElm.parentNode!="null" && objSrcElm.parentNode!=null)
                            objSrcElm.parentNode.innerHTML = unescape (objSrcElm.value);
                       
                       } 
                     // focusLost ();
                      }
                      catch(err){}
                   onEditID(s.childNodes[parseInt(i,10)+1]);
                    tn=i;
                    i=s.childNodes.length;
//                    onEditID(s.childNodes[parseInt(i,10)+1]);
//                    tn=i;
//                    i=s.childNodes.length;
                }
             }
        }
        if (document.getElementById('div_electronics').style.display == "none" && tn == 31)
            f=false;
        else if(document.getElementById('divprint').style.display=="none" && tn==38) 
            f=false;   
        if(f==false)
        {
            if(document.getElementById('div_electronics').style.display=="none")
            {
                if(s.rowIndex==document.getElementById('tblGrid').rows.length-1)
                {
                    if(confirm('Are you sure you want to Add Row?')==false)
                        return false;
                    else
                        addRow('', '', '', '', '', '', '0', '0', '0', '0', '0', '', '0', '', '', '', '', '', '', '', 'Yes(Y)', '', document.getElementById('hiddencurrency').value, '', '', '', '', '', '', '', '','','','','');
                } 
            }    
            else{
                if(s.rowIndex==document.getElementById('tblGridelec').rows.length-1)
                {
                     if(confirm('Are you sure you want to Add Row?')==false)
                        return false;
                    else
                        addRow('', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', document.getElementById('hiddencurrency').value, '', '', '', 'Yes(Y)', '', '', '', '', '', '', '', '', '', '', '', '','','','','','')//
                } 
            }   
           // onEdit();
        }    
     focusLost ();
     }
   }
  }

  /*\
  |*| Toggle the About div section
  \*/
  function about ()
  {
    if (element.document.getElementById ("About").style.visibility == "hidden")
      element.document.getElementById ("About").style.visibility = "visible";
    else
      element.document.getElementById ("About").style.visibility = "hidden";
  }

  /*\
  |*| Need this as IE 5 doesnt give the offsetLeft property properly
  \*/
  function getRealPos (elm)
  {
    intPos = 0;
    elm = elm.previousSibling;
    while ((elm!= null) && (elm.tagName!="BODY"))
    {
       intPos += elm.width - 0;
      elm = elm.previousSibling;
    }
    return intPos;
  }

  /*\
  |*| Return the TR elem on which an event has fireed
  \*/
  function getEventRow ()
  {
    var srcElem = window.event.srcElement;
    //crawl up to find the row
    while (srcElem.tagName != "TR" && srcElem.tagName != "TABLE")
    {
      srcElem = srcElem.parentNode;
    }
    return srcElem;
  }

  /*\
  |*| Return the TD elem on which an event has fireed
  \*/
  function getEventCell ()
  {
    var srcElem = window.event.srcElement;
    //crawl up the tree to find the table col
    while (srcElem!=null && srcElem.tagName != "TD" && srcElem.tagName != "TABLE")
    {
      srcElem = srcElem.parentNode;
    }
    return srcElem;
  }

  /*\
  |*| This funtion is used to change the height of the DIVs that are used to drag the cols
  |*| Used when a row is added or deleted.
  \*/
  function resizeDivs ()
  {
    for (var i = 0; i < intColCount; i++)
    {  
      var objDiv = element.document.getElementById ("DragMark" + (i));
      var objTD = element.tHead.childNodes[0].childNodes[i];

      if ((!objDiv) || (!objTD) || (objTD.tagName != "TD")) return;
      objDiv.style.height = (element.tBodies[0].childNodes.length + 1) * (objTD.offsetHeight - 1);
    }
  }

  /*\
  |*| Function to handle erros. Displayes a request to contact along with the error messagei, filename and line
  \*/
  function handleError (err, url, line)
  {
    alert ('Oops, something went wrong.\n' +
       'Please contact yinti AT users DOT sourceforge DOT net with the following text\n' + 
       'Error text: ' + err + '\n' + 
       'Location  : ' + url + '\n' +
       'Line no   : ' + line + '\n');
     return true; // let the browser handle the error */
  }

  /*\
  |*| Function to prototype all the functions needed by NN to emulate the functionality of IE
  \*/
  function initNNFunctions ()
  {
    if ((self.Node) && (self.Node.prototype)) {
    try{
      Node.prototype.removeNode = NNRemoveNode;

      Element.prototype.insertAdjacentText = NNInsertAdjacentText;
      Element.prototype.insertAdjacentElement = NNInsertAdjacentElement;
      Element.prototype.insert__Adj = NNInsertAdj;
      Element.prototype.attachEvent = NNAttachEvent;
      Element.prototype.detachEvent = NNDetachEvent;
      Element.prototype.setCapture = NNSetCapture;
      Element.prototype.releaseCapture = NNReleaseCapture;
      Element.prototype.__defineGetter__('document', NNDocumentGetter);

      HTMLElement.prototype.focus = NNNullFunction;
      HTMLElement.prototype.attachEvent = NNAttachEvent;
      HTMLElement.prototype.detachEvent = NNDetachEvent;
      HTMLElement.prototype.__defineGetter__('innerText', NNInnerTextGetter);
      HTMLElement.prototype.__defineSetter__('innerText', NNInnerTextSetter);

      HTMLDocument.prototype.attachEvent = NNAttachEvent;
      HTMLDocument.prototype.detachEvent = NNDetachEvent;

      Event.prototype.__defineGetter__('keyCode', NNKeyCodeGetter);
      }
      catch (err) { }
    }
  }

  /*\
  |*|
  \*/
  function NNRemoveNode (a1)
  {
    var p = this.parentNode;
    if (p&&!a1)
    {
      var df = document.createDocumentFragment ();
      for (var a = 0; a < this.childNodes.length; a++)
      {
        df.appendChild (this.childNodes[a])
      }
      p.insertBefore (df , this)
    }
    return p?p.removeChild (this):this;
  }

  /*\
  |*|
  \*/
  function NNInsertAdjacentText (a1 , a2)
  {
    var t = document.createTextNode (a2||"")
    this.insert__Adj (a1 , t);
  }

  /*\
  |*|
  \*/
  function NNInsertAdjacentElement (a1 , a2)
  {
    this.insert__Adj (a1 , a2);
    return a2;
  }

  /*\
  |*|
  \*/
  function NNInsertAdj (a1 , a2)
  {
    var p = this.parentNode;
    var s = a1.toLowerCase ();
    if (s == "beforebegin"){p.insertBefore (a2 , this)}
    if (s == "afterend"){p.insertBefore (a2 , this.nextSibling)}
    if (s == "afterbegin"){this.insertBefore (a2 , this.childNodes[0])}
    if (s == "beforeend"){this.appendChild (a2)}
  }

  /*\
  |*| Fuction to simulate attachEvent
  \*/
  function NNAttachEvent (strEvent, funcHandle)
  {
    var shortTypeName = strEvent.replace (/on/, "");
    funcHandle._ieEmuEventHandler = function (e)
    {
      window.event = e;
      window.event.srcElement = e.target;
      return funcHandle ();
    };
    this.addEventListener (shortTypeName, funcHandle._ieEmuEventHandler, false);
  }

  /*\
  |*| Fuction to simulate detachEvent
  \*/
  function NNDetachEvent (strEvent, funcHandle)
  {
    var shortTypeName = strEvent.replace (/on/, "");
    if (typeof funcHandle._ieEmuEventHandler == "function")
      this.removeEventListener (shortTypeName, funcHandle._ieEmuEventHandler, false);
    else 
      this.removeEventListener (shortTypeName, funcHandle, true);
  }

  /*\
  |*| A HUGE HACK to getaway with the lack of setcapture in NN
  \*/
  function NNSetCapture ()
  {
    //TODO: FIX THIS FIRST BEFORE ANYTHING ELSE!! MAJOR HACK FOR NOW
    document.attachEvent ('onmousemove', resizeColoumn);
    document.attachEvent ('onmouseup', releaseMouse);
  }

  /*\
  |*| A HUGE HACK to getaway with the lack of releasecapture in NN
  \*/
  function NNReleaseCapture ()
  {
    //TODO: FIX THIS SECOND THEN GO TO EVERYTHING ELSE! 
    document.detachEvent ('onmousemove', resizeColoumn);
    document.detachEvent ('onmouseup', releaseMouse);
  }

  /*\
  |*| Empty function used to remove any functions not needed in NN
  \*/
  function NNNullFunction () { /*Nothing here*/ }

  /*\
  |*| return the innerhtml by replacing all the <TAGNAME> from the string
  \*/
  function NNInnerTextGetter ()
  {
    return this.innerHTML.replace (/<[^>]+>/g,"");
  }

  /*\
  |*| Add the text as a textnode to the element
  \*/
  function NNInnerTextSetter (txtStr)
  {
    var parsedText = document.createTextNode (txtStr);
    this.innerHTML = "";
    this.appendChild (parsedText);
  }

  /*\
  |*| Function to simulate event.keyCode
  \*/
  function NNKeyCodeGetter ()
  {
    return this.which;
  }

  /*\
  |*| Function to simulate element.document
  \*/
  function NNDocumentGetter ()
  {
    return this.ownerDocument;
  }
function openPrint()
{
    document.getElementById('divprint').style.display="block";
    document.getElementById('div_electronics').style.display="none";
    document.getElementById('an_print').className="selected";
    document.getElementById('an_elec').className="";
    document.getElementById('an_web').className="";
    tableName='tblGrid';
      if (document.getElementById)
      element = document.getElementById (tableName);
    else  //TODO: Need to test this piece of code still. Happens only in NN4 so far 
      eval (element = "document." + tableName);
    return false;
}
function openElectronics()
{
    document.getElementById('divprint').style.display="none";
    document.getElementById('div_electronics').style.display="block";
    document.getElementById('an_print').className="";
    document.getElementById('an_elec').className="selected";
    document.getElementById('an_web').className="";
    tableName='tblGridelec';
      if (document.getElementById)
      element = document.getElementById (tableName);
    else  //TODO: Need to test this piece of code still. Happens only in NN4 so far 
      eval (element = "document." + tableName);
    return false;
}
function openWeb()
{
    document.getElementById('divprint').style.display="none";
    document.getElementById('div_electronics').style.display="none";
    document.getElementById('an_print').className="";
    document.getElementById('an_elec').className="";
    document.getElementById('an_web').className="selected";
    return false;
}
//function tabvalue1 (event)
//{

//var browser=navigator.appName;
// if(browser!="Microsoft Internet Explorer")
// {
//      if (event.which == 27)
//     {
//        document.getElementById("divcommon").style.display="none";
//         document.getElementById(activeIDNo).focus();
//         activeIDNo="";
//     }
//     else  if (event.which == 13 && document.activeElement.id=="lstcommon")
//     {
//        document.getElementById("divcommon").style.display="none";
//         document.getElementById(activeIDNo).value=document.getElementById("lstcommon").value;
//          if(colName=="Premium")
//       {
//            bindPremCharges(document.getElementById("lstcommon").value);
//       }
//       document.getElementById(activeIDNo).focus();
//        activeIDNo="";
//     }
//      else if (event.which == 113)
//     {
//      activeIDNo=document.activeElement.uniqueID;
//     var srcElem = getEventCell ();
//     
//    var cellindex=srcElem.cellIndex;
//    colName=element.tHead.childNodes[0].childNodes[cellindex].childNodes[0].nextSibling.data;
//    if(colName=="Adv Type" || colName=="Status" || colName=="Ad Type" || colName=="Hue" || colName=="Uom" || colName=="Rate Code" ||  colName=="Premium" || colName=="Day" || colName=="Comm. Allow" || colName=="Deal Start" || colName=="Package" || colName=="Category"  || colName=="Disc Type" || colName=="Disc On" || colName=="Currency" || colName=="Channel" || colName=="Location" || colName=="Program Type" || colName=="Program Name" || colName=="BTB" || colName=="ROS" || colName=="Paid/Bonus")
//    {
//        document.getElementById("divcommon").style.display="block";
//       aTag = eval( document.getElementById(document.activeElement.uniqueID))
//	                var btag;
//	                var leftpos=0;
//	                var toppos=0;        
//	                do
//	                {
//		                aTag = eval(aTag.offsetParent);
//		                leftpos	+= aTag.offsetLeft;
//		                toppos += aTag.offsetTop;
//		                btag=eval(aTag)
//	                } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
//	                 document.getElementById('divcommon').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + toppos + "px";
//	                 document.getElementById('divcommon').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
//	                  bindListBox(colName);
//	                  return false;
//	  }                
//     }
// }
// else{
//      if (event.keyCode == 27)
//     {
//        document.getElementById("divcommon").style.display="none";
//         document.getElementById(activeIDNo).focus();
//         activeIDNo="";
//         
//     }
//      else  if (event.keyCode == 13 && document.activeElement.id=="lstcommon")
//     {
//        document.getElementById("divcommon").style.display="none";
//        if(document.getElementById(activeIDNo)!=null)
//        {
//           document.getElementById(activeIDNo).value=document.getElementById("lstcommon").value;
//           if(colName=="Ad Type" || colName=="Category" || colName=="Package" || colName=="Hue" || colName=="Uom" || colName=="Currency" )
//           {
//           if(activeRow!="")
//           {
//           var srcElem=document.getElementById('tblGrid').rows[activeRow];
//           var adcat="";
//           var pkgcode=""; 
//           var color="";
//           var currency="";
//           var uom="";
//           var advtype="";
//           if(activeCell=="4")
//           {
//               if(srcElem.cells[4].childNodes[0]!="undefined" && srcElem.cells[4].childNodes[0]!=undefined && srcElem.cells[4].childNodes[0].value!=undefined)
//                 adcat=srcElem.cells[4].childNodes[0].value;
//               else
//                 adcat=srcElem.cells[4].childNodes[1].value;  
//           }
//           else{
//             adcat=srcElem.cells[4].innerHTML;
//           }
//           if(activeCell=="3")
//           {
//            if(srcElem.cells[3].childNodes[0]!="undefined" && srcElem.cells[3].childNodes[0]!=undefined && srcElem.cells[3].childNodes[0].value!=undefined)
//                pkgcode=srcElem.cells[3].childNodes[0].value;
//             else
//                 pkgcode=srcElem.cells[3].childNodes[1].value; 
//           }
//           else{
//             pkgcode=srcElem.cells[3].innerHTML;
//           }
//            if(activeCell=="1")
//           {
//            if(srcElem.cells[1].childNodes[0]!="undefined" && srcElem.cells[1].childNodes[0]!=undefined && srcElem.cells[1].childNodes[0].value!=undefined)
//                color=srcElem.cells[1].childNodes[0].value;
//            else
//                color=srcElem.cells[1].childNodes[1].value;    
//           }
//           else{
//             color=srcElem.cells[1].innerHTML;
//           }
//            if(activeCell=="22")
//           {
//            if(srcElem.cells[22].childNodes[0]!="undefined" && srcElem.cells[22].childNodes[0]!=undefined && srcElem.cells[22].childNodes[0].value!=undefined)
//                currency=srcElem.cells[22].childNodes[0].value;
//            else
//                currency=srcElem.cells[22].childNodes[1].value;    
//           }
//           else{
//             currency=srcElem.cells[22].innerHTML;
//           }
//            if(activeCell=="2")
//           {
//            if(srcElem.cells[2].childNodes[0]!="undefined" && srcElem.cells[2].childNodes[0]!=undefined && srcElem.cells[2].childNodes[0].value!=undefined)
//                uom=srcElem.cells[2].childNodes[0].value;
//            else
//                uom=srcElem.cells[2].childNodes[1].value;    
//           }
//           else{
//             uom=srcElem.cells[2].innerHTML;
//           }
//            if(activeCell=="0")
//           {
//            if(srcElem.cells[0].childNodes[0]!="undefined" && srcElem.cells[0].childNodes[0]!=undefined && srcElem.cells[0].childNodes[0].value!=undefined)
//                advtype=srcElem.cells[0].childNodes[0].value;
//            else
//                advtype=srcElem.cells[0].childNodes[1].value;    
//           }
//           else{
//             advtype=srcElem.cells[0].innerHTML;
//           }
//            getCardRate(adcat,pkgcode,color,currency,uom,advtype,document.getElementById('txtfromdate').value,document.getElementById('TextBox1').value,document.getElementById('hiddencompcode').value,document.getElementById('hiddendateformat').value);
//            }
//           }
//           else if(colName=="Premium")
//           {
//                bindPremCharges(document.getElementById("lstcommon").value);
//           }
//           else  if(colName=="Day")
//           {
//            var day="";
//            for(var i=0;i<document.getElementById("lstcommon").options.length;i++)
//            {
//             if(document.getElementById("lstcommon").options[i].selected==true)
//             {
//                if(day=="")
//                    day=document.getElementById("lstcommon").options[i].value;
//                else
//                    day=day + "," + document.getElementById("lstcommon").options[i].value;    
//             }   
//            }
//            document.getElementById(activeIDNo).value=day;
//           }
//           document.getElementById(activeIDNo).focus();
//        }   
//        activeIDNo="";
//     }
//     else if(event.keyCode == 13 || event.keyCode == 9)
//     {
//        checkForEnter();
//     }
//      else if (event.keyCode == 113)
//     {
//         var srcElem = getEventCell ();
//         var cellindex=srcElem.cellIndex;
//       colName=element.tHead.childNodes[0].childNodes[cellindex].childNodes[0].nextSibling.data;
//        if(colName=="Adv Type" || colName=="Status" || colName=="Ad Type" || colName=="Hue" || colName=="Uom" || colName=="Rate Code" || colName=="Premium" || colName=="Day" || colName=="Comm. Allow" || colName=="Deal Start" || colName=="Package" || colName=="Category" || colName=="Disc Type" || colName=="Disc On" || colName=="Currency" || colName=="Channel" || colName=="Location" || colName=="Program Type" || colName=="Program Name" || colName=="BTB" || colName=="ROS" || colName=="Paid/Bonus")
//        { 
//            activeIDNo=document.activeElement.uniqueID;
//            document.getElementById("divcommon").style.display="block";
//            
//              
//           aTag = eval( document.getElementById(document.activeElement.uniqueID))
//	                    var btag;
//	                    var leftpos=0;
//	                    var toppos=0;        
//	                    do
//	                    {
//		                    aTag = eval(aTag.offsetParent);
//		                    leftpos	+= aTag.offsetLeft;
//		                    toppos += aTag.offsetTop;
//		                    btag=eval(aTag)
//	                    } while(aTag.tagName!="BODY" && aTag.tagName!="HTML");
//	                     document.getElementById('divcommon').style.top=document.getElementById(document.activeElement.uniqueID).offsetTop + toppos + "px";
//	                     document.getElementById('divcommon').style.left=document.getElementById(document.activeElement.uniqueID).offsetLeft + leftpos+"px";
//	                     bindListBox(colName);
//	    }                 
//     }
// }
//}
function bindPremCharges(premcode)
{
     var res=ContractMaster.getPremPage_detail(premcode);
     var ds=res.value;
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
     {
        var cardprem=ds.Tables[0].Rows[0].premium_charges;
        if(document.getElementById("div_electronics").style.display=="none")
            document.getElementById('tblGrid').rows[activeRow].cells[6].innerHTML=cardprem;
        else
            document.getElementById('tblGridelec').rows[activeRow].cells[20].innerHTML=cardprem;    
     }
}
function bindListBox(colName)
{
    if(colName=="Ad Type")
    {
        var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
      var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var res=ContractMaster.bindadtype_detail(document.getElementById('hiddencompcode').value);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Type_Name,ds.Tables[0].Rows[i].Adv_Type_Code);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else if(colName=="Section Code")
    {
         var val_="";
            var res=ContractMaster.getSectionCode(val_);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME,ds.Tables[0].Rows[i].CODE);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else if(colName=="Resource No")
    {
          var val_="";
        var res=ContractMaster.getResourceNo(val_);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME,ds.Tables[0].Rows[i].CODE);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else if(colName=="Hue")
    {
        var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
          var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var res=ContractMaster.bindcolor_detail(document.getElementById('hiddencompcode').value,document.getElementById('hiddenuserid').value);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Col_Name,ds.Tables[0].Rows[i].Col_Code);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
       else if(colName=="Source")
    {
        var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
          var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var res=ContractMaster.bindSource_TV_Contract(document.getElementById('hiddencompcode').value);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME,ds.Tables[0].Rows[i].SOURCE_TYPE);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else if(colName=="Uom")
    {
        var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
        var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var adtype=document.getElementById('tblGrid').rows[srcElm.rowIndex].cells[0].innerHTML;
        if(adtype.indexOf("(")>0)
            adtype=adtype.substring(adtype.lastIndexOf('(')+1,adtype.lastIndexOf(')'));
        var res=ContractMaster.binduom_A_detail(document.getElementById('hiddencompcode').value,adtype,document.getElementById('hiddenuserid').value);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].UOM_Name,ds.Tables[0].Rows[i].UOM_Code);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else if(colName=="Rate Type")
    {
        var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
        var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var adtype="EL0";
        var res=ContractMaster.binduom_A_detail(document.getElementById('hiddencompcode').value,adtype,document.getElementById('hiddenuserid').value);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].UOM_Name,ds.Tables[0].Rows[i].UOM_Code);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
    else  if(colName=="Package")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
        var srcElm=getEventRow();
         activeRow=srcElm.rowIndex;
        var adtype="";
        var channel="";
         if(document.getElementById('div_electronics').style.display=="none")
         {
            adtype=document.getElementById('tblGrid').rows[srcElm.rowIndex].cells[0].innerHTML;
            if(adtype.indexOf("(")>0) 
                adtype=adtype.substring(adtype.lastIndexOf('(')+1,adtype.lastIndexOf(')'));
         }   
        else{
            adtype="EL0"; 
            channel=document.getElementById('tblGridelec').rows[srcElm.rowIndex].cells[0].innerHTML;
        }
       //  var channel=document.getElementById('tblGridelec').rows[srcElm.rowIndex].cells[0].innerHTML;
        if(channel.indexOf("(")>0)
            channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')'));       
        var res=ContractMaster.bindpackage_A_detail(document.getElementById('hiddencompcode').value,adtype,channel);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].PACKAGE_NAME,ds.Tables[0].Rows[i].COMBIN_CODE);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
    else  if(colName=="Category")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
        var srcElm=getEventRow();
         activeRow=srcElm.rowIndex;
        var adtype="";
        if(document.getElementById('div_electronics').style.display=="none")
        {
            adtype=document.getElementById('tblGrid').rows[srcElm.rowIndex].cells[0].innerHTML;
            if(adtype.indexOf("(")>0)
                adtype=adtype.substring(adtype.lastIndexOf('(')+1,adtype.lastIndexOf(')'));
        }    
        else
            adtype="EL0";    
        var res=ContractMaster.bindadvcategory_A_detail(adtype,document.getElementById('hiddencompcode').value);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="Premium")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
        var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var adtype="";
         if(document.getElementById('div_electronics').style.display=="none")
         {
            adtype=document.getElementById('tblGrid').rows[srcElm.rowIndex].cells[0].innerHTML;
            if(adtype.indexOf("(")>0)
                adtype=adtype.substring(adtype.lastIndexOf('(')+1,adtype.lastIndexOf(')'));
         }   
        else
            adtype="EL0";    
        var res=ContractMaster.bindpremium_A_detail(document.getElementById('hiddencompcode').value,adtype);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].premiumname,ds.Tables[0].Rows[i].Premiumcode);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
      else  if(colName=="Disc Type")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
        var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
        pkgitem.options[pkgitem.options.length] = new Option("Free","1");    
        pkgitem.options[pkgitem.options.length] = new Option("Discounted","2");  
        pkgitem.options[pkgitem.options.length] = new Option("Fixed Rate","3");              
        pkgitem.options.length;               
        document.getElementById("lstcommon").focus();
        return false;
    }
       else  if(colName=="Disc On")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
        var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
        pkgitem.options[pkgitem.options.length] = new Option("Discount On Bill","1");    
        pkgitem.options[pkgitem.options.length] = new Option("Discount through Credit Note","2");        
        pkgitem.options.length;               
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="Deal Start")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
        var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
        pkgitem.options[pkgitem.options.length] = new Option("After Target Achived","A");    
        pkgitem.options[pkgitem.options.length] = new Option("From Begining","B");        
        pkgitem.options.length;               
        document.getElementById("lstcommon").focus();
        return false;
    }
    else if (colName == "Status")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
        var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
        pkgitem.options[pkgitem.options.length] = new Option("Active","Y");
        pkgitem.options[pkgitem.options.length] = new Option("Inactive", "N");        
        pkgitem.options.length;               
        document.getElementById("lstcommon").focus();
        return false;
    }
    else  if(colName=="Comm. Allow")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
        var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
        pkgitem.options[pkgitem.options.length] = new Option("Yes","Y");    
        pkgitem.options[pkgitem.options.length] = new Option("No","N");        
        pkgitem.options.length;               
        document.getElementById("lstcommon").focus();
        return false;
    }
      else  if(colName=="Day")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
        var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple=true;
        pkgitem.options.length = 0; 
        pkgitem.options[pkgitem.options.length] = new Option("SUN","sun");    
        pkgitem.options[pkgitem.options.length] = new Option("MON","mon");     
        pkgitem.options[pkgitem.options.length] = new Option("TUE","tue");       
        pkgitem.options[pkgitem.options.length] = new Option("WED","wed");       
        pkgitem.options[pkgitem.options.length] = new Option("THU","thu");       
        pkgitem.options[pkgitem.options.length] = new Option("FRI","fri");       
        pkgitem.options[pkgitem.options.length] = new Option("SAT","sat");          
        pkgitem.options.length;               
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="Currency")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
       var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var adtype="EL0";
         if(document.getElementById('div_electronics').style.display=="none")
          {
             adtype=document.getElementById('tblGrid').rows[srcElm.rowIndex].cells[0].innerHTML;
             if(adtype.indexOf("(")>0)
                adtype=adtype.substring(adtype.lastIndexOf('(')+1,adtype.lastIndexOf(')'));
         }    
        var res=ContractMaster.bindcurrency_detail(document.getElementById('hiddencompcode').value,adtype,document.getElementById('hiddenuserid').value);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Curr_Name,ds.Tables[0].Rows[i].Curr_Code);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="Rate Code")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
          var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var adtype="";
        if(document.getElementById('div_electronics').style.display=="block")
        {
            adtype="EL0";
        }
        var res=ContractMaster.bindratecode_detail(document.getElementById('hiddencompcode').value,adtype);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].rate_mast_code,ds.Tables[0].Rows[i].rate_mast_code);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="Channel")
    {
//     var Return;
//      Return = window.showModalDialog("contractChild.aspx?name=lata",
//           "Sample.jpg","resizable: yes");
//document.getElementById('txtremark').value = Return.remarks;
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
       var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
     
        var res=ContractMaster.bindChannel_detail(document.getElementById('hiddencompcode').value);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME,ds.Tables[0].Rows[i].CHANNEL);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
      else  if(colName=="Location")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
       var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
      
        var res=ContractMaster.bindLocation_detail(document.getElementById('hiddencompcode').value);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME,ds.Tables[0].Rows[i].LOCCD);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="Program Type")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
       var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
         var channel=document.getElementById('tblGridelec').rows[srcElm.rowIndex].cells[0].innerHTML;
      if(channel.indexOf("(")>0)
            channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')'));
        var res=ContractMaster.bindProgramType_detail(document.getElementById('hiddencompcode').value,channel);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].NAME,ds.Tables[0].Rows[i].PROGRAMME_TY);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="Program Name")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
       var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var programtype=document.getElementById('tblGridelec').rows[srcElm.rowIndex].cells[24].innerHTML;
        var btb=document.getElementById('tblGridelec').rows[srcElm.rowIndex].cells[5].innerHTML;
        var channel=document.getElementById('tblGridelec').rows[srcElm.rowIndex].cells[0].innerHTML;
      if(channel.indexOf("(")>0)
            channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')'));
        if(programtype.indexOf("(")>0)
            programtype=programtype.substring(programtype.lastIndexOf('(')+1,programtype.lastIndexOf(')'));
        if(btb.indexOf("(")>0)
            btb=btb.substring(btb.lastIndexOf('(')+1,btb.lastIndexOf(')'));    
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0;     
        if(btb!='')
        {    
        var res=ContractMaster.bindProgram_detail(document.getElementById('hiddencompcode').value,programtype,btb,channel);
        var ds=res.value;
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].SHORT_NAME,ds.Tables[0].Rows[i].PRG_ID);                
                    pkgitem.options.length;               
                }
                
            }
        }    
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="BTB")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
       var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
      var channel=document.getElementById('tblGridelec').rows[srcElm.rowIndex].cells[0].innerHTML;
      if(channel.indexOf("(")>0)
            channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')'));
        var res=ContractMaster.bindBTB_detail(document.getElementById('hiddencompcode').value,channel);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].BTB_DESC,ds.Tables[0].Rows[i].BTB_CODE);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
     else  if(colName=="Adv Type")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
       var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
       var channel=document.getElementById('tblGridelec').rows[srcElm.rowIndex].cells[0].innerHTML;
      if(channel.indexOf("(")>0)
            channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')'));
        var res=ContractMaster.bindAdvType_TV_detail(document.getElementById('hiddencompcode').value,channel);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].DES,ds.Tables[0].Rows[i].AD_TYPE);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
      else  if(colName=="Time Band")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
       var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
     var channel=document.getElementById('tblGridelec').rows[srcElm.rowIndex].cells[0].innerHTML;
       if(channel.indexOf("(")>0)
        channel=channel.substring(channel.lastIndexOf('(')+1,channel.lastIndexOf(')'));
        var btb=document.getElementById('tblGridelec').rows[srcElm.rowIndex].cells[5].innerHTML;
        if(btb.indexOf("(")>0)
            btb=btb.substring(btb.lastIndexOf('(')+1,btb.lastIndexOf(')'));
        var res=ContractMaster.bindRos_detail(document.getElementById('hiddencompcode').value,btb,channel);
        var ds=res.value;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=true;
        pkgitem.options.length = 0; 
       // pkgitem.options[0]=new Option("-Select-","0");
        
            if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
            {
              //  pkgitem.options.length = 1; 
                for (var i = 0  ; i < ds.Tables[0].Rows.length; ++i)
                {
                    pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].BND_DESC,ds.Tables[0].Rows[i].BND_CODE);                
                    pkgitem.options.length;               
                }
                
            }
        document.getElementById("lstcommon").focus();
        return false;
    }
      else  if(colName=="Paid/Bonus")
    {
         var srcElm1=getEventCell();
        activeCell=srcElm1.cellIndex;
        var srcElm=getEventRow();
        activeRow=srcElm.rowIndex;
        var pkgitem = document.getElementById("lstcommon");
         pkgitem.multiple=false;
        pkgitem.options.length = 0; 
        pkgitem.options[pkgitem.options.length] = new Option("Paid","P");    
        pkgitem.options[pkgitem.options.length] = new Option("Bonus","B");        
        pkgitem.options.length;               
        document.getElementById("lstcommon").focus();
        return false;
    }

    else if (colName == "Position Premium") {
        var srcElm1 = getEventCell();
        activeCell = srcElm1.cellIndex;
        var srcElm = getEventRow();
        activeRow = srcElm.rowIndex;
        var prem = "";
        if (document.getElementById('div_electronics').style.display == "none") {
            prem = document.getElementById('tblGrid').rows[srcElm.rowIndex].cells[28].innerText;
            if (prem.indexOf("(") > 0)
                prem = adtype.substring(adtype.lastIndexOf('(') + 1, adtype.lastIndexOf(')'));
        }
        else
            adtype = "EL0";
        var res = ContractMaster.pagebindpremium_A_detail(document.getElementById('hiddencompcode').value, prem);
        var ds = res.value;
        var pkgitem = document.getElementById("lstcommon");
        pkgitem.multiple = false;
        pkgitem.options.length = 0;
        // pkgitem.options[0]=new Option("-Select-","0");

        if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
            //  pkgitem.options.length = 1; 
            for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
                pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].POS_TYPE, ds.Tables[0].Rows[i].POS_TYPE_CODE);
                pkgitem.options.length;
            }

        }
        document.getElementById("lstcommon").focus();
        return false;
    }
    
    
}
function getCardRate(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto, compcode, dateformat)
{
   
    if(advtype.indexOf("(")>0)
        advtype=advtype.substring(advtype.lastIndexOf('(')+1,advtype.lastIndexOf(')'));
    if(adcat.indexOf("(")>0)    
        adcat=adcat.substring(adcat.lastIndexOf('(')+1,adcat.lastIndexOf(')'));
    if(pkgcode.indexOf("(")>0)        
        pkgcode=pkgcode.substring(pkgcode.lastIndexOf('(')+1,pkgcode.lastIndexOf(')'));
    if(color.indexOf("(")>0)          
        color=color.substring(color.lastIndexOf('(')+1,color.lastIndexOf(')'));
    if(currency.indexOf("(")>0)         
        currency=currency.substring(currency.lastIndexOf('(')+1,currency.lastIndexOf(')'));
    if(uom.indexOf("(")>0)        
        uom=uom.substring(uom.lastIndexOf('(')+1,uom.lastIndexOf(')'));
     
     var res=ContractMaster.getrateforcontract_detail(adcat, pkgcode, color, currency, uom, advtype, validfrom, validto, compcode, dateformat);
     var ds=res.value;
     if(ds!= null && typeof(ds) == "object" && ds.Tables[0].Rows.length > 0) 
     {
        var cardRate=ds.Tables[0].Rows[0].Week_Day_Rate;
        document.getElementById('tblGrid').rows[activeRow].cells[9].innerHTML=cardRate;
     }
}
function closeClick()
{
    window.close();
    
}
 function checkdateG(input)
 {
 var dateformat=document.getElementById('hiddendateformat').value;
 if(dateformat=="mm/dd/yyyy")
 
 {
 var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
 
 }
 if(dateformat=="yyyy/mm/dd")
 
 {
var validformat=/^\d{4}\/\d{2}\/\d{2}$/ //Basic check for format validity
}
if(dateformat=="dd/mm/yyyy")
{
var validformat=/^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
}

if (!validformat.test(input.value))
{
if(input.value=="")
{
return true;
}
//alert(document.activeElement.id);
input.value="";
var s=getEventCell();
alert(" Please Fill The Date In "+dateformat+" Format");
onEditID(s);
//popUpCalendar(document.activeElement,document.activeElement,dateformat);
//setTimeout(settime1,15);
//daid=input;
return false;
//return;c
}
else
{ //Detailed check for valid date ranges
if(dateformat=="yyyy/mm/dd")

{
var yearfield=input.value.split("/")[0]
var monthfield=input.value.split("/")[1]
var dayfield=input.value.split("/")[2]
var dayobj = new Date(yearfield, monthfield-1, dayfield)
}
if(dateformat=="mm/dd/yyyy")

{
var yearfield=input.value.split("/")[2]
var monthfield=input.value.split("/")[0]
var dayfield=input.value.split("/")[1]
//var dayobj = new Date(monthfield-1, dayfield, yearfield)
var dayobj = new Date(yearfield, monthfield-1, dayfield)

}
if(dateformat=="dd/mm/yyyy")
{
var yearfield=input.value.split("/")[2]
var monthfield=input.value.split("/")[1]
var dayfield=input.value.split("/")[0]
//var dayobj = new Date(dayfield, monthfield-1, yearfield)
var dayobj = new Date(yearfield, monthfield-1, dayfield)
}
}

//if ((dayobj.getMonth()+1!=monthfield)||(dayobj.getDate()!=dayfield)||(dayobj.getFullYear()!=yearfield)) 
var abcd= dayobj.getMonth()+1;

var date1=dayobj.getDate();
var year1=dayobj.getFullYear();
if ((abcd!=monthfield)||(date1!=dayfield)||(year1!=yearfield))  
{
alert(" Please Fill The Date In "+dateformat+" Format");
input.value="";
return false;
}


 
returnval=true
 


if (returnval==false) 

input.select()
return returnval

}


function datecurr(event) {
    if (browser != "Microsoft Internet Explorer") {
        if ((event.which >= 48 && event.which <= 57)||(event.which >= 96 && event.which <= 105) || (event.which == 47) || (event.which == 11) || (event.which == 8) || (event.which == 9)) {

            return true;
        }

    }
    else
    {
     if ((event.keyCode >= 48 && event.keyCode <= 57)||(event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode == 47) || (event.keyCode == 11 || (event.which == 9))) {

            return true;
     }
     
     else
     {
       if(document.activeElement.id=='txtfromdate' || document.activeElement.id=='TextBox1')
       {
         if ((event.keyCode==111)||(event.keyCode==191)||(event.keyCode==8)||(event.keyCode==27)||(event.keyCode >= 48 && event.keyCode <= 57)||(event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode == 47) || (event.keyCode == 11 || (event.which == 9))) {
        {
        return true;
        }
       
     }
     else
     {
     return false;
     }
    }
    }
    }
   /* else {
        if ((event.keyCode >= 48 && event.keyCode <= 57)||(event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode == 47) || (event.keyCode == 11 || (event.which == 9))) {

            return true;
        }
        else
        { 
        if(document.activeElement.id=='txtfromdate' || document.activeElement.id=='TextBox1'){
        if ((event.keyCode >= 48 && event.keyCode <= 57)||(event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode == 47) || (event.keyCode == 8) || (event.keyCode == 27) || (event.keyCode == 11 || (event.which == 9))) 
        {
            return true;
        }
         
        }
        }
        else
        {
           return false;
        }
    }
 */   
}

function ClientisNumber() 
{
    if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 9) || (event.keyCode == 11)) {

        return true;
    }
    else {
        return false;
    }

}
