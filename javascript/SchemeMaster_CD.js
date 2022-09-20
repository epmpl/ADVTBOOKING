// JScript File

var gdsexecute;
var rowN=0;
var hiddentext;
var glschemename;
var deleteid="";
var chkschemename="";
var exeschemecode;
var exefrominsert;
var exetoinserta;
var  exediscount;
var exeschemename;

//------------on page load -----------------------//
function onpage_load()
{
    if( document.getElementById("btnNew").disabled ==false)
        document.getElementById("btnNew").focus();
     document.getElementById("txtschemename").value="";
     document.getElementById("txtschemename").disabled=true;
     document.getElementById("tblgrid").disabled=true;
     document.getElementById("tblbutton").disabled=true;
     
     document.getElementById("tblbutton").style.display="block";
     document.getElementById("tblgrid").style.display="block";
     var tableToSort=document.getElementById("tblgrid");
     newRow = tableToSort.insertRow();
 
       //------ Dynamic TABLE  heading-----//
          newRow.className ="dtGridrate";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "";
          
          newCell = newRow.insertCell();
          newCell.align="center";
         
          newCell.innerHTML = "Description";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "From Insertion";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "To Insertion";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "Discount (%)";
          
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "Scheme ID";
          newCell.style.display="none";
          newRow = tableToSort.insertRow();
          
          newCell = newRow.insertCell();
          var element1 = document.createElement("input");
          element1.type = "checkbox";
          newCell.appendChild(element1);

          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text maxLength='20' disabled=true  class=btextsmallsize1_k  OnBlur=\"return checkdescription(this);\" >";//document.getElementById("txtfrminsert").value;
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  maxLength='5' disabled=true class=btextsmallsize onkeypress=\"return ClientisNumber(event);\" OnBlur=\"return checkdescriptionInsert(event,this.parentNode.parentNode);\" >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  maxLength='5' disabled=true class=btextsmallsize onkeypress=\"return ClientisNumber(event);\" OnBlur=\"return checkdescriptionInsert(event,this.parentNode.parentNode);\" >";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  maxLength='5' disabled=true class=btextsmallsize onkeypress=\"return rateenter(event);\"  onkeydown=\"return activeinsertbutton(event,this.parentNode.parentNode);\">"; // 
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text  style='display:none' class=btextsmallsize >";
        
          return false;     
}

function newclick()
{
   clearclick();
  hiddentext="new";
 
   for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
    {
        document.getElementById("tblgrid").disabled=false;
        document.getElementById("tblgrid").rows(i).cells(1).children[0].disabled=false;
        document.getElementById("tblgrid").rows(i).cells(2).children[0].disabled=false;
        document.getElementById("tblgrid").rows(i).cells(3).children[0].disabled=false;
        document.getElementById("tblgrid").rows(i).cells(4).children[0].disabled=false;
    }
  document.getElementById("txtschemename").disabled=false;
  document.getElementById("tblgrid").disabled=false;
  document.getElementById("tblbutton").disabled=false;
  document.getElementById("txtschemename").focus();
  chkstatus(FlagStatus);
  setButtonImages();	
  return false;
  
}


function clearclick()
{
  hiddentext="clear";
  deleteid="";
  chkstatus(FlagStatus);	
  givebuttonpermission("Scheme_Master_CD");
  hiddentext="";
   var Parent = document.getElementById("tblgrid");
   while(Parent.hasChildNodes())
   {
     Parent.removeChild(Parent.lastChild);
   }
   
   document.getElementById("txtschemename").value="";
   onpage_load();
 setButtonImages();
  return false;
}

function queryclick()
{
   clearclick();
   hiddentext="query";
   deleteid="";
   chkstatus(FlagStatus);
   document.getElementById('btnQuery').disabled=true;
   document.getElementById('btnExecute').disabled=false;
   document.getElementById('btnSave').disabled=true;
   document.getElementById('btnExecute').focus();
  
   document.getElementById("tblgrid").disabled=false;
   document.getElementById("tblbutton").disabled=false;
   document.getElementById("txtschemename").value="";
   document.getElementById("txtschemename").disabled=false;
   document.getElementById("tblbutton").disabled=true;
   rowN=0;
   setButtonImages();
   return false;
}

function modifyclick()
{
    deleteid="";
    chkstatus(FlagStatus);
    document.getElementById('btnSave').disabled = false;
    document.getElementById('btnQuery').disabled = true; 
    document.getElementById('btnExecute').disabled=true;
   
    document.getElementById("tblbutton").disabled=false; 
    chkschemename= document.getElementById("txtschemename").value;
    hiddentext="modify";
  
    for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
    {
        document.getElementById("tblgrid").disabled=false;
        document.getElementById("tblgrid").rows(i).cells(1).children[0].disabled=false;
        document.getElementById("tblgrid").rows(i).cells(2).children[0].disabled=false;
        document.getElementById("tblgrid").rows(i).cells(3).children[0].disabled=false;
        document.getElementById("tblgrid").rows(i).cells(4).children[0].disabled=false;
    }
   setButtonImages(); 
    return false;
}


function saveclick()
{
    
    var compcode = document.getElementById("hiddencompcode").value;
    var userid=document.getElementById("hiddenuserid").value;
    var dateformat=document.getElementById("hiddendateformat").value;
    document.getElementById("txtschemename").value= trim(document.getElementById("txtschemename").value);
    var schemecode=document.getElementById("txtschemename").value;
    var lbschemename= document.getElementById("lblschemename").innerHTML;
    var validfromdate="";
    var validtill="";
    var discount_type="per";
    if((document.getElementById("txtschemename").value =="") && (lbschemename.indexOf("*") >=0))
    {
      alert("Please Enter Scheme Name." );
      document.getElementById("txtschemename").focus();
      return false;
    }
  
    if(parseInt(document.getElementById("tblgrid").rows.length) == 1)
    {
       alert("Please Enter Detail for Ist Row." );
       return false;
    }
    for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
    {
            var txtdescription =  trim(document.getElementById("tblgrid").rows(i).cells(1).children[0].value);
            var txtfrominsert =   trim(document.getElementById("tblgrid").rows(i).cells(2).children[0].value);
            var txttoinsert   =   trim(document.getElementById("tblgrid").rows(i).cells(3).children[0].value);
            var txtdiscount   =   trim(document.getElementById("tblgrid").rows(i).cells(4).children[0].value);
            if(txtdescription=="")
            {
                alert("Please Enter Description for "+i+" Row");
                return false;
            }
            if(txtfrominsert=="")
            {
                alert("Please Enter From Insertion for "+i+" Row");
                return false;
            }
            if(txttoinsert=="")
            {
                alert("Please Enter To Insertion for "+i+" Row");
                return false;
            }
             if(txtdiscount=="")
            {
                alert("Please Enter Discount for "+i+" Row");
                return false;
            }
            
            if(txtdiscount >100)
            {
                alert("Discount cannot be greater than 100 for "+i+" Row");
                document.getElementById("tblgrid").rows(i).cells(4).children[0].value="";
                return false;
            }
             
            if(txtdiscount!="")
            {
//			    if(txtdiscount.match(/^\d+(\.\d{1,3})?$/i))
//			    {
//			      // checkpackagerate();
//			    }
			    var tomatch=/^\d*(\.\d{1,2})?$/;
                if (tomatch.test(txtdiscount))
                {
               // return true;
                }
			    else
			    {
			        alert("Input Error")
			        document.getElementById("tblgrid").rows(i).cells(4).children[0].value="";
			        return false;
			    }
           }

    } 
   if(hiddentext != "modify") 
   {
        var flag="0";
        for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
        {
            var txtdescription =  document.getElementById("tblgrid").rows(i).cells(1).children[0].value;
            var frominsert =   document.getElementById("tblgrid").rows(i).cells(2).children[0].value;
            var toinsert   =   document.getElementById("tblgrid").rows(i).cells(3).children[0].value;
            var discount   =   document.getElementById("tblgrid").rows(i).cells(4).children[0].value;
            var schemeid= schemecode + frominsert +toinsert;
            
            Scheme_Master_CD.savescheme(schemeid, schemecode, frominsert, toinsert, validfromdate, validtill, discount_type, discount, compcode, userid, flag, txtdescription);
            schemeid="";
            
        }
        
          alert("Data Saved Successfully.");
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
         
          clearclick();
          return false;
        
    } 
    else
    {
        var flag="1";
        for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
        {
            var txtdescription =  document.getElementById("tblgrid").rows(i).cells(1).children[0].value;
            var frominsert =   document.getElementById("tblgrid").rows(i).cells(2).children[0].value;
            var toinsert   =   document.getElementById("tblgrid").rows(i).cells(3).children[0].value;
            var discount   =   document.getElementById("tblgrid").rows(i).cells(4).children[0].value;
            var schemeid   =   document.getElementById("tblgrid").rows(i).cells(5).children[0].value;
            
            if(schemeid != "")
            {
                falg="1";
                Scheme_Master_CD.savescheme(schemeid, schemecode, frominsert, toinsert, validfromdate, validtill, discount_type, discount, compcode, userid, flag, txtdescription);
            }
            else
            {
               flag="0";
               schemeid= schemecode + frominsert +toinsert;
               Scheme_Master_CD.savescheme(schemeid, schemecode, frominsert, toinsert, validfromdate, validtill, discount_type, discount, compcode, userid, flag, txtdescription);
               document.getElementById("tblgrid").rows(i).cells(5).children[0].value=schemeid;
            }
            
        }
        
         alert("Data Updated Successfully.");
         //clearclick();
//         var res1=Scheme_Master_CD.schemeexecute(document.getElementById("txtschemename").value,compcode);
//         executeclick_call(res1);
        // executeclick();
        if(deleteid !="")
        {
           var delschemeid=deleteid.split(',');
           var len=delschemeid.length-1;
           for (var m=0; m<len; m++)
           {
             Scheme_Master_CD.deletegrid(delschemeid[m],document.getElementById('hiddencompcode').value);
           }
        }
         for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
         {
            document.getElementById("tblgrid").disabled=true;
            document.getElementById("tblgrid").rows(i).cells(1).children[0].disabled=true;
            document.getElementById("tblgrid").rows(i).cells(2).children[0].disabled=true;
            document.getElementById("tblgrid").rows(i).cells(3).children[0].disabled=true;
            document.getElementById("tblgrid").rows(i).cells(4).children[0].disabled=true;
         }
         updateStatus();
         document.getElementById("tblbutton").disabled=true;
         var x=gdsexecute.Tables[0].Rows.length;
         y=z;	
         if (z==0)
         {
            document.getElementById('btnfirst').disabled=true;
            document.getElementById('btnprevious').disabled=true;
         }
  
         if(z==(gdsexecute.Tables[0].Rows.length-1))
         {
            document.getElementById('btnNext').disabled=true;
            document.getElementById('btnLast').disabled=true;
         }
          rowN=0;
          setButtonImages();
          return false;         
    } 
                  
}

//===============================check duplicay for scheme Name====================================//
function CheckSchemeName()
{
    document.getElementById("txtschemename").value=trim(document.getElementById("txtschemename").value);
    document.getElementById("txtschemename").value=document.getElementById("txtschemename").value.toUpperCase();
  if( hiddentext=="new" )
 {
    var compcode = document.getElementById("hiddencompcode").value;
    var schemecode = document.getElementById("txtschemename").value;
    var res=Scheme_Master_CD.schemecheck("",schemecode,"",compcode);
    var ds=res.value;
    if(ds.Tables[0].Rows.length > 0)
    {
      alert("Scheme Name is already assigned.");
      document.getElementById("txtschemename").focus();
      return false;
    }
  }
}

function executeclick()
{
    var compcode = document.getElementById("hiddencompcode").value;
    var schemecode = document.getElementById("txtschemename").value;
    glschemename=schemecode;
    var res1=Scheme_Master_CD.schemeexecute(schemecode,compcode);
    executeclick_call(res1);
    
    rowN=0;
//    updateStatus();
//    document.getElementById('btnfirst').disabled=true;				
//	document.getElementById('btnnext').disabled=false;					
//	document.getElementById('btnprevious').disabled=true;			
//	document.getElementById('btnlast').disabled=false;	
	if(document.getElementById('btnModify').disabled==false)					
	   document.getElementById('btnModify').focus();
	   
    return false;
}


function executeclick_call(responce)
{
    if(responce.error!=null)
    {
        alert("ERROR : \n"+responce.error.description);
        return false;
    }
    gdsexecute=responce.value;
    if(gdsexecute!=null)
    {
        if(gdsexecute.Tables[0].Rows.length>0)
        {
            bindctrls();
        }
        else
        {
            alert("Your Search Produces No Result");
            clearclick();
            return false;
        }
    }
    
     updateStatus();
    
    if(gdsexecute.Tables[0].Rows.length==1)
    {
        document.getElementById("btnfirst").disabled=true;
        document.getElementById("btnprevious").disabled=true;
        document.getElementById("btnnext").disabled=true;
        document.getElementById("btnlast").disabled=true;
    }
    else
    {
        document.getElementById("btnfirst").disabled=true;
        document.getElementById("btnprevious").disabled=true;
        document.getElementById("btnnext").disabled=false;
        document.getElementById("btnlast").disabled=false;
    }
    setButtonImages();
}

function bindctrls()
{
    var res=Scheme_Master_CD.executegrid(gdsexecute.Tables[0].Rows[rowN].scheme_code,document.getElementById('hiddencompcode').value);
    var ds=res.value;
    if(ds==null)
    {
        alert(res.error.description);
        return false;
    }
    if(ds.Tables[0].Rows.length >0)
    {
        exeschemecode=ds.Tables[0].Rows[0].scheme_code;
        exefrominsert=ds.Tables[0].Rows[0].from_insertion_no;
        exetoinsert=ds.Tables[0].Rows[0].to_insertion_no;
        exediscount=ds.Tables[0].Rows[0].discount;
        exeschemename=ds.Tables[0].Rows[0].scheme_name;
        
        document.getElementById("txtschemename").value=ds.Tables[0].Rows[0].scheme_code;
        document.getElementById("tblgrid").rows(1).cells(1).children[0].value=ds.Tables[0].Rows[0].scheme_name;
        document.getElementById("tblgrid").rows(1).cells(2).children[0].value=ds.Tables[0].Rows[0].from_insertion_no;
        document.getElementById("tblgrid").rows(1).cells(3).children[0].value=ds.Tables[0].Rows[0].to_insertion_no;
        document.getElementById("tblgrid").rows(1).cells(4).children[0].value=ds.Tables[0].Rows[0].discount;
        document.getElementById("tblgrid").rows(1).cells(5).children[0].value=ds.Tables[0].Rows[0].scheme_id;
       
        document.getElementById("txtschemename").disabled=true;
        document.getElementById("tblgrid").rows(1).cells(1).children[0].disabled=true;
        document.getElementById("tblgrid").rows(1).cells(2).children[0].disabled=true;
        document.getElementById("tblgrid").rows(1).cells(3).children[0].disabled=true;
        document.getElementById("tblgrid").rows(1).cells(4).children[0].disabled=true;
        
    }
    if(ds.Tables[0].Rows.length >1)
    {
            for(i=1;i<ds.Tables[0].Rows.length;i++)
            {
           
              var tableToSort=document.getElementById("tblgrid");
              newRow = tableToSort.insertRow();
              
              newCell = newRow.insertCell();
              var element1 = document.createElement("input");
              element1.type = "checkbox";
              newCell.appendChild(element1);

              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text disabled maxLength='20'class=btextsmallsize1_k value='"+ds.Tables[0].Rows[i].scheme_name+"' onblur=\"return checkdescription(this);\">";//document.getElementById("txtfrminsert").value;
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text disabled maxLength='5'class=btextsmallsize value='"+ds.Tables[0].Rows[i].from_insertion_no+"' onkeypress=\"return ClientisNumber(event);\" OnBlur=\"return checkdescriptionInsert(event,this.parentNode.parentNode);\">";
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text disabled maxLength='5'class=btextsmallsize value='"+ds.Tables[0].Rows[i].to_insertion_no+"' onkeypress=\"return ClientisNumber(event);\" OnBlur=\"return checkdescriptionInsert(event,this.parentNode.parentNode);\">";
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text disabled maxLength='5'class=btextsmallsize value='"+ds.Tables[0].Rows[i].discount+"' onkeypress=\"return rateenter(event);\" onkeydown=\"return activeinsertbutton(event,this.parentNode.parentNode);\">";
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text style='display:none' class=btextsmallsize value='"+ds.Tables[0].Rows[i].scheme_id+"' onkeypress=\"return rateenter(event);\">";
             } 
    }

     document.getElementById("tblgrid").disabled=true;
     document.getElementById("tblbutton").disabled=true; 
  
}

function firstclick()
{
    var Parent = document.getElementById("tblgrid");
       while(Parent.hasChildNodes())
       {
         Parent.removeChild(Parent.lastChild);
       }
       onpage_load();
    rowN=0;
    
    document.getElementById("btnfirst").disabled=true;
    document.getElementById("btnprevious").disabled=true;
    document.getElementById("btnnext").disabled=false;
    document.getElementById("btnlast").disabled=false;
    
    bindctrls();
   setButtonImages();
    return false;
}

function prevclick()
{
     var Parent = document.getElementById("tblgrid");
       while(Parent.hasChildNodes())
       {
         Parent.removeChild(Parent.lastChild);
       }
       onpage_load();
    rowN--;
    if(rowN<=0)
    {
        document.getElementById("btnfirst").disabled=true;
        document.getElementById("btnprevious").disabled=true;
        document.getElementById("btnnext").disabled=false;
        document.getElementById("btnlast").disabled=false;
        rowN=0;
    }
    else
    {
        document.getElementById("btnnext").disabled=false;
        document.getElementById("btnlast").disabled=false;
    }
    bindctrls();
    setButtonImages();
    return false;
}

function nextclick()
{
     var Parent = document.getElementById("tblgrid");
       while(Parent.hasChildNodes())
       {
         Parent.removeChild(Parent.lastChild);
       }
       onpage_load();
    rowN++;
    if(rowN>=gdsexecute.Tables[0].Rows.length-1)
    {
        document.getElementById("btnfirst").disabled=false;
        document.getElementById("btnprevious").disabled=false;
        document.getElementById("btnnext").disabled=true;
        document.getElementById("btnlast").disabled=true;
        rowN=gdsexecute.Tables[0].Rows.length-1;
    }
    else
    {
        document.getElementById("btnfirst").disabled=false;
        document.getElementById("btnprevious").disabled=false;
    }
    bindctrls();
    setButtonImages();
    return false;
}

function lastclick()
{
    var Parent = document.getElementById("tblgrid");
       while(Parent.hasChildNodes())
       {
         Parent.removeChild(Parent.lastChild);
       }
       onpage_load();
    rowN=gdsexecute.Tables[0].Rows.length-1;
    
    document.getElementById("btnfirst").disabled=false;
    document.getElementById("btnprevious").disabled=false;
    document.getElementById("btnnext").disabled=true;
    document.getElementById("btnlast").disabled=true;
    
    bindctrls();
   setButtonImages();
    return false;
}

//-------------function for delete rows of grid-------------------------------//
function deleteRow()
 {
  try {
          
            var flag =0;
             if(document.getElementById('tblbutton').disabled ==true)
             return false;
            var table = document.getElementById("tblgrid");
            var rowCount = table.rows.length;

        for(var i=0; i<rowCount; i++) {
            var row = table.rows[i];
            var chkbox = row.cells[0].childNodes[0];

            if(null != chkbox && true == chkbox.checked) 
            {
                 flag=1;
                var schemeid=row.cells[5].childNodes[0].value;
                if(hiddentext!="modify")
                {
                    table.deleteRow(i);
                    rowCount--;
                    i--;
                }
                else
                {
                   table.deleteRow(i);
                   deleteid=schemeid+","+deleteid;
                   //Scheme_Master_CD.deletegrid(schemeid,document.getElementById('hiddencompcode').value);
                   rowCount--;
                   i--;
                }
            }

        }
        }catch(e) {
            alert(e);
        }
        if(flag==0)
        {
          alert("Please select checkbox for delete row.")
        }
        return false;
  }



//---------------- On addclick Create New Rows -------------------//
function addClick()
{
      if(document.getElementById('tblbutton').disabled ==true)
         return false;
      var tableToSort=document.getElementById("tblgrid");
      
//    if(n==parseInt(document.getElementById("tblgrid").rows.length))
//    {
        
      newRow = tableToSort.insertRow();
      
      newCell = newRow.insertCell();
      var element1 = document.createElement("input");
      element1.type = "checkbox";
     // element1.rowIndex;
      newCell.appendChild(element1);

      newCell = newRow.insertCell();
      newCell.align="center";
      newCell.innerHTML = "<input type=text class=btextsmallsize1_k  maxLength='20' onblur=\"return checkdescription(this);\">";//document.getElementById("txtfrminsert").value;
      newCell.focus();
      newCell = newRow.insertCell();
      newCell.align="center";
      newCell.innerHTML = "<input type=text  maxLength='5' class=btextsmallsize onkeypress=\"return ClientisNumber(event);\" OnBlur=\"return checkdescriptionInsert(event,this.parentNode.parentNode);\">";
      newCell = newRow.insertCell();
      newCell.align="center";
      newCell.innerHTML = "<input type=text  maxLength='5' class=btextsmallsize onkeypress=\"return ClientisNumber(event);\" OnBlur=\"return checkdescriptionInsert(event,this.parentNode.parentNode);\">";
      newCell = newRow.insertCell();
      newCell.align="center";
      newCell.innerHTML = "<input type=text  maxLength='5' class=btextsmallsize onkeypress=\"return rateenter(event);\" onkeydown=\"return activeinsertbutton(event,this.parentNode.parentNode);\" >";
      newCell = newRow.insertCell();
      newCell.align="center";
      newCell.innerHTML = "<input type=text style='display:none' class=btextsmallsize >";
      return false;
   // }
//    else 
//    {  
//           document.getElementById("tblgrid").rows(n+1).cells(1).children[0].focus();
//           return false;
//    }

//}
      
      
}


//---------------------check duplicacy for description ---------------------------//

function checkdescription(el)
{
try {
        var table = document.getElementById("tblgrid");
        var rowCount = table.rows.length;
        while(rowCount>1)
       {
            var name=table.rows[rowCount-1].cells[1].childNodes[0].value;
            for(var i=1; i<rowCount-1; i++) {
                var row = table.rows[i];
                var chkbox = row.cells[1].childNodes[0].value;
                if(name==chkbox && name!=""  && chkbox!="") 
                {
                    alert("Description already defined");
                    el.value="";
                    el.focus();
                    i=rowCount;
                    return false;
                }

           }
          rowCount--;
        }
        }catch(e) {
            alert(e);
        }
       // document.getElementById("tblgrid").rows(1).cells(1).children[0].focus();
        return false;
}
function checkdescriptionInsert(event,name)
{
try {
        var table = document.getElementById("tblgrid");
        var rowCount = table.rows.length;
      
        while(rowCount>1)
       {
            var rowindex=parseInt(name.rowIndex);
           
            var row1 = table.rows[rowindex];
            var fromInsert =row1.cells[2].childNodes[0].value;
            var toInsert =  row1.cells[3].childNodes[0].value;
            
            for(var i=1; i<=rowCount-1; i++) 
            {
                 if(fromInsert !="" && toInsert!="")
                 {  
                    if(parseInt(toInsert,10) < parseInt(fromInsert,10))
                        {
                        alert("To Insertion Can't be lesser than From Insertion.");
                                row1.cells[3].childNodes[0].value="";
                                row1.cells[3].childNodes[0].focus();
                        return false;
                        }
                 }
              if(parseInt(rowindex,10)!=parseInt(i,10))
              {
                  var row = table.rows[i];
                  var frominsert1 = row.cells[2].childNodes[0].value;
                  var toinsert1 = row.cells[3].childNodes[0].value;
                  if(fromInsert !="" && toInsert!="")
                 {  
                    if(parseInt(toInsert,10) < parseInt(fromInsert,10))
                        {
                        alert("To Insertion Can't be lesser than From Insertion.");
                                row1.cells[3].childNodes[0].value="";
                                row1.cells[3].childNodes[0].focus();
                        return false;
                        }
                    if((parseInt(fromInsert,10) < parseInt(frominsert1,10) && parseInt(toInsert,10) > parseInt(toinsert1,10)))
                        {
                        alert("This data can't be inserted....");
                        row1.cells[3].childNodes[0].value="";
                         row1.cells[3].childNodes[0].focus();
                        return false;
                        }
                 }
                 
                 if(fromInsert !="" && frominsert1!="" ) //&& toinsert1 !="" && toInsert!="" )
                 {
                         if ((parseInt(fromInsert,10) >= parseInt(frominsert1,10) && parseInt(fromInsert,10) <= parseInt(toinsert1,10)) )
                          {
                             alert("From Insertion already defined");
                             row1.cells[2].childNodes[0].value="";
                             row1.cells[2].childNodes[0].focus();
                             i=rowCount;
                             return false;
                          }       
                  }
                 if( toinsert1 !="" && toInsert!="" )
                  {
                          if ((parseInt(toInsert,10) >= parseInt(frominsert1,10) && parseInt(toInsert,10) <= parseInt(toinsert1,10)) )
                          {
                            
                                alert("To Insertion already defined");
                                row1.cells[3].childNodes[0].value="";
                                row1.cells[3].childNodes[0].focus();
                                i=rowCount;
                                return false;
                        }
                 }
                
              }
           }
          rowCount--;
        }
        }catch(e) {
            alert(e);
        }
       // document.getElementById("tblgrid").rows(1).cells(1).children[0].focus();
        return false;
}
function deleteclick()
{
  if(confirm('Are you sure you want to delete?'))
  {
     var compcode = document.getElementById("hiddencompcode").value;
     var schemecode=document.getElementById("txtschemename").value;
      
     Scheme_Master_CD.deletescheme(schemecode, compcode);
      alert("Data Deleted Successfully");
       var Parent = document.getElementById("tblgrid");
       while(Parent.hasChildNodes())
       {
         Parent.removeChild(Parent.lastChild);
       }
       onpage_load();
     //document.getElementById("tblgrid").rows.length
     //rowN=0;  
     Scheme_Master_CD.schemeexecute(glschemename,compcode,call_deletedschemecode);
    // executeclick_call(res1);
  }
  return false;
}

function call_deletedschemecode(response)
{
    gdsexecute=response.value;
 	var a=gdsexecute.Tables[0].Rows.length;
	var y=a-1;
	
	if( gdsexecute.Tables[0].Rows.length==0 )
	{
	    alert("There Is No Data In The Database");
	   	clearclick();
	}
	else if(rowN==-1 ||rowN>a)
	{
	 // document.getElementById("txtschemename").value=ds.Tables[0].Rows[0].scheme_code;   
	   bindctrls();
      return false;
	}
	else
	{
	  rowN=0;  
	  bindctrls();
	  //document.getElementById("txtschemename").value=ds.Tables[0].Rows[rowN].scheme_code;  
	}
	setButtonImages();
}

function exitclick()
{
    if(confirm("Do you want to skip this page."))
    {
       window.close();
       return false;
    }
  return false;
}


function activeinsertbutton(event,name)
{

var maxRow=document.getElementById('tblgrid').rows.length-1;
if(parseInt(maxRow)==parseInt(name.rowIndex))
{
   if(event.keyCode ==13)
    document.getElementById("btninsertrow").focus();
}    
}



function LTrim( value ) {
	
	var re = /\s*((\S+\s*)*)/;
	return value.replace(re, "$1");
	
}

// Removes ending whitespaces
function RTrim( value ) {
	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");
	
}

// Removes leading and ending whitespaces
function trim( value ) 

{
	
	return LTrim(RTrim(value));
	
}
function setButtonImages()
{
    if(document.getElementById('btnNew').disabled==true)
        document.getElementById('btnNew').src="btimages/new-off.jpg";
    else
        document.getElementById('btnNew').src="btimages/new.jpg";
        
    if(document.getElementById('btnSave').disabled==true)
        document.getElementById('btnSave').src="btimages/save-off.jpg";
    else
        document.getElementById('btnSave').src="btimages/save.jpg";
        
    if(document.getElementById('btnModify').disabled==true)
        document.getElementById('btnModify').src="btimages/modify-off.jpg";
    else
        document.getElementById('btnModify').src="btimages/modify.jpg";
        
    if(document.getElementById('btnQuery').disabled==true)
        document.getElementById('btnQuery').src="btimages/query-off.jpg";
    else
        document.getElementById('btnQuery').src="btimages/query.jpg";
    
    if(document.getElementById('btnExecute').disabled==true)
        document.getElementById('btnExecute').src="btimages/execute-off.jpg";
    else
        document.getElementById('btnExecute').src="btimages/execute.jpg";
        
    if(document.getElementById('btnCancel').disabled==true)
        document.getElementById('btnCancel').src="btimages/clear-off.jpg";
    else
        document.getElementById('btnCancel').src="btimages/clear.jpg";
        
    if(document.getElementById('btnfirst').disabled==true)
        document.getElementById('btnfirst').src="btimages/first-off.jpg";
    else
        document.getElementById('btnfirst').src="btimages/first.jpg";
        
    if(document.getElementById('btnprevious').disabled==true)
        document.getElementById('btnprevious').src="btimages/previous-off.jpg";
    else
        document.getElementById('btnprevious').src="btimages/previous.jpg";
        
    if(document.getElementById('btnnext').disabled==true)
        document.getElementById('btnnext').src="btimages/next-off.jpg";
    else
        document.getElementById('btnnext').src="btimages/next.jpg";
        
    if(document.getElementById('btnlast').disabled==true)
        document.getElementById('btnlast').src="btimages/last-off.jpg";
    else
        document.getElementById('btnlast').src="btimages/last.jpg";   
        
    if(document.getElementById('btnDelete').disabled==true)
        document.getElementById('btnDelete').src="btimages/delete-off.jpg";
    else
        document.getElementById('btnDelete').src="btimages/delete.jpg";
        
    if(document.getElementById('btnExit').disabled==true)
        document.getElementById('btnExit').src="btimages/exit-off.jpg";
    else
        document.getElementById('btnExit').src="btimages/exit.jpg";
}