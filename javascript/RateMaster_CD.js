// JScript File

var gdsexecute;
var rowN=0;
var hiddentext;
var gladtype;
var gladcat;
var gluomcode;
var gleditioncode;
var glschemecode;

// on pageload
function pagedef()
{
   document.getElementById("drpadtype").disabled=true;
   document.getElementById("listcategory").disabled=true;
   document.getElementById("listsubcategory").disabled=true;
   document.getElementById("listsubsubcatgory").disabled=true;
   document.getElementById("RadioButton1").disabled=true;
   document.getElementById("RadioButton2").disabled=true;
   document.getElementById("drpmainedilist").disabled=true;
   document.getElementById("drpuom").disabled=true;
   document.getElementById("drpcolor").disabled=true;
   document.getElementById("txtline").disabled=true;
   document.getElementById("txtrate").disabled=true;
   document.getElementById("txtextrarate").disabled=true;
   document.getElementById('Adslabs').disabled=true;
   document.getElementById('Adslabs').checked=false;
   document.getElementById("drpscheme").disabled=true;
   document.getElementById("txtvalidfrom").disabled=true;
  
   
   return false;
}

function newclick()
{
   clearclick();
   hiddentext="new";
   document.getElementById("drpadtype").disabled=false;
   document.getElementById("drpadtype").focus();
   document.getElementById("listcategory").disabled=false;
   document.getElementById("listsubcategory").disabled=false;
   document.getElementById("listsubsubcatgory").disabled=false;
   document.getElementById("RadioButton1").disabled=false;
   document.getElementById("RadioButton2").disabled=false;
   document.getElementById("drpmainedilist").disabled=false;
   document.getElementById("drpuom").disabled=false;
   document.getElementById("drpcolor").disabled=false;
   document.getElementById("txtline").disabled=false;
   document.getElementById("txtrate").disabled=false;
   document.getElementById("txtextrarate").disabled=false;
   document.getElementById('Adslabs').disabled=false;
   document.getElementById("drpscheme").disabled=false;
   document.getElementById("txtvalidfrom").disabled=false;
   chkstatus(FlagStatus);	
  setButtonImages();
   return false;
}

function clearclick()
{
   chkstatus(FlagStatus);
   givebuttonpermission("RateMaster_CD");
   hiddentext="";
   document.getElementById("tblinsertion").style.display="none";
   document.getElementById("tblgrid").innerHtml="";
   document.getElementById("Adslabs").checked=false;
   document.getElementById("drpadtype").value="0";
   document.getElementById("listcategory").options.length="1";
   document.getElementById("listsubcategory").options.length="1";
   document.getElementById("listsubsubcatgory").options.length="1";
  
   document.getElementById("drpmainedilist").options.length="0";
   document.getElementById("drpuom").value="0";
   document.getElementById("drpcolor").value="0";
   document.getElementById("txtline").value="";
   document.getElementById("txtrate").value="";
   document.getElementById("txtextrarate").value="";
   document.getElementById("drpscheme").value="0";
    document.getElementById("txtvalidfrom").value="";
  
   document.getElementById("drpadtype").disabled=true;
   document.getElementById("listcategory").disabled=true;
   document.getElementById("listsubcategory").disabled=true;
   document.getElementById("listsubsubcatgory").disabled=true;
   document.getElementById("RadioButton1").disabled=true;
   document.getElementById("RadioButton2").disabled=true;
   document.getElementById("drpmainedilist").disabled=true;
   document.getElementById("drpuom").disabled=true;
   document.getElementById("drpcolor").disabled=true;
   document.getElementById("txtline").disabled=true;
   document.getElementById("txtrate").disabled=true;
   document.getElementById("txtextrarate").disabled=true;
   document.getElementById('Adslabs').disabled=true;
   document.getElementById("drpscheme").disabled=true;
   document.getElementById("txtvalidfrom").disabled=true;
   
   document.getElementById("RadioButton1").checked=false;
   document.getElementById("RadioButton2").checked=false;
   document.getElementById("tblrate").style.display="block";
    var Parent = document.getElementById("tblgrid");
       while(Parent.hasChildNodes())
       {
         Parent.removeChild(Parent.firstChild);
       }
       
   document.getElementById('hiddenuomdesc').value="";
   setButtonImages();
   return false;
}


function queryclick()
{
   clearclick();
   chkstatus(FlagStatus);
   document.getElementById('btnQuery').disabled=true;
   document.getElementById('btnExecute').disabled=false;
   document.getElementById('btnSave').disabled=true;
   document.getElementById('btnExecute').focus();
   
   document.getElementById("drpadtype").value="0";
   document.getElementById("listcategory").value="0";
   document.getElementById("listsubcategory").value="0";
   document.getElementById("listsubsubcatgory").value="0";
   document.getElementById("drpmainedilist").value="0";
   document.getElementById("drpuom").value="0";
   document.getElementById("drpcolor").value="0";
   document.getElementById("txtline").value="";
   document.getElementById("txtrate").value="";
   document.getElementById("txtextrarate").value="";
   document.getElementById("txtvalidfrom").value="";
   
   document.getElementById("drpadtype").disabled=false;
   document.getElementById("listcategory").disabled=false;
   document.getElementById("listsubcategory").disabled=true;
   document.getElementById("listsubsubcatgory").disabled=true;
   document.getElementById("RadioButton1").disabled=false;
   document.getElementById("RadioButton2").disabled=false;
   document.getElementById("drpmainedilist").disabled=false;
   document.getElementById("drpuom").disabled=false;
   document.getElementById("drpcolor").disabled=true;
   document.getElementById("txtline").disabled=true;
   document.getElementById("txtrate").disabled=true;
   document.getElementById("txtextrarate").disabled=true;
   document.getElementById('Adslabs').disabled=false;
   document.getElementById("drpscheme").disabled=false;
   document.getElementById("txtvalidfrom").disabled=false;
   
   document.getElementById("RadioButton1").checked=false;
   document.getElementById("RadioButton2").checked=false;
   document.getElementById('hiddenuomdesc').value="";
   setButtonImages();
  return false;
}

function saveclick()
{
  var compcode = document.getElementById("hiddencompcode").value;
  var userid=document.getElementById("hiddenuserid").value;
  var dateformat=document.getElementById("hiddendateformat").value;
 //---- -------------- for Validation ------------------------------//
  
  var lbadtype= document.getElementById("lbladtype").innerHTML;
  var lbadcategory=document.getElementById("lbladcategory").innerHTML;
  var lbadsubcategory=document.getElementById("lblsubcategory").innerHTML;
  var lbadscat3= document.getElementById("lblsubsubcategory").innerHTML;
  var lbedition=document.getElementById("ediname").innerHTML;
  var lbuom=document.getElementById("lbluom").innerHTML;
  var lbcolor=document.getElementById("lblcolor").innerHTML;
  var lbsizeto=document.getElementById("lblline").innerHTML;
  var lbrate=document.getElementById("lbrate").innerHTML;
  var lbextrarate=document.getElementById("lbextrarate").innerHTML;
  var lbtxtvalidfrom=document.getElementById("lbltxtfrom").innerHTML;

  
  if((document.getElementById("drpadtype").value =="0") && (lbadtype.indexOf("*") >=0))
  {
    alert("Please Enter Ad Type." );
    document.getElementById("drpadtype").focus();
    return false;
  }
  else if((document.getElementById("listcategory").value =="0" ||document.getElementById("listcategory").value=="") && (lbadcategory.indexOf("*") >="0"))
  {
    alert("Please Enter Ad Category." );
    document.getElementById("listcategory").focus();
    return false;
  }
  else if((document.getElementById("drpmainedilist").value =="0"  || document.getElementById("drpmainedilist").value =="" ) && (lbedition.indexOf("*") >="0"))
  {
    alert("Please Enter Edition." );
    document.getElementById("drpmainedilist").focus();
    return false;
  }
   else if((document.getElementById("drpcolor").value =="0") && (lbcolor.indexOf("*") >="0"))
  {
    alert("Please Enter Color." );
    document.getElementById("drpcolor").focus();
    return false;
  }
   else if((document.getElementById("drpuom").value =="0") && (lbuom.indexOf("*") >="0"))
  {
    alert("Please Enter Uom." );
    document.getElementById("drpuom").focus();
    return false;
  }
    else if((document.getElementById("txtline").value =="") && (lbsizeto.indexOf("*") >="0"))
  {
    alert("Please Enter Minimum Line.");
    document.getElementById("txtline").focus();
    return false;
  }
     else if((document.getElementById("txtrate").value =="") && (lbrate.indexOf("*") >="0") && document.getElementById("Adslabs").checked==false)
  {
    alert("Please Enter Minimum Amount." );
    document.getElementById("txtrate").focus();
    return false;
  }
     else if((document.getElementById("txtextrarate").value =="") && (lbextrarate.indexOf("*") >="0") && document.getElementById("Adslabs").checked==false)
  {
    alert("Please Enter Rate." );
    document.getElementById("txtextrarate").focus();
    return false;
  }
  else if((document.getElementById("txtvalidfrom").value =="") && (lbtxtvalidfrom.indexOf("*") >="0"))
  {
      alert("Please Enter Effective From." );
      document.getElementById("txtvalidfrom").focus();
      return false;
  }
  for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
      {
            var txtfrominsert = document.getElementById("tblgrid").rows(i).cells(1).children[0].value;
            var txttoinsert =   document.getElementById("tblgrid").rows(i).cells(2).children[0].value;
            var rate =   document.getElementById("tblgrid").rows(i).cells(3).children[0].value;
            var extrate =   document.getElementById("tblgrid").rows(i).cells(4).children[0].value;
            if(txtfrominsert=="")
            {
                alert("Please Enter From Insert for "+i+" Row.");
                return false;
            }
            if(txttoinsert=="")
            {
                alert("Please Enter To Insert for "+i+" Row.");
                return false;
            }
            if(rate=="")
            {
                alert("Please Enter Minimum Amount for "+i+" Row.");
                return false;
            }
          //------ check rate and extra rate for more than one decimal point=----------//  
             if(rate!="")
            {
			    if(rate.match(/^\d+(\.\d{1,3})?$/i))
			    {
			      // checkpackagerate();
			    }
			    else
			    {
			        alert("Input Error")
			        document.getElementById("tblgrid").rows(i).cells(3).children[0].value="";
			        return false;
			    }
           }
            if(extrate!="")
            {
			    if(extrate.match(/^\d+(\.\d{1,3})?$/i))
			    {
			      // checkpackagerate();
			    }
			    else
			    {
			        alert("Input Error")
			        document.getElementById("tblgrid").rows(i).cells(4).children[0].value="";
			        return false;
			    }
           }
           
           if(parseInt(txtfrominsert) > parseInt(txttoinsert))
           {
             alert("From Insertion cannot be greater than To Insertion for "+i+" Row.");
             return false;
           }
           //if ((txtfdate >= fdate && txtfdate <= tdate) || (txttdate >= fdate && txttdate <= tdate) ) 
                var tblid=document.getElementById("tblgrid");  
//           if((tblid.rows(i+1).cells(1).children[0].value> tblid.rows(i).cells(1).children[0].value && tblid.rows(i+1).cells(1).children[0].value <tblid.rows(i).cells(2).children[0].value)  || (tblid.rows(i+1).cells(2).children[0].value> tblid.rows(i).cells(1).children[0].value && tblid.rows(i+1).cells(2).children[0].value <tblid.rows(i).cells(2).children[0].value) )
//           {
//              alert("Insertion already exist with this this Range ");
//              return false;
//           }
              
      }  
      
        //------------------------------------------------------------------------//
          
//            //  var count=1;
//            // var j=parseInt(document.getElementById("tblgrid").rows.length)-1;
//             var j=1;
//             var count=parseInt(document.getElementById("tblgrid").rows.length)-1;
//          
//           if (parseInt(document.getElementById("tblgrid").rows.length) > 1)
//           {
//             while (j < count)
//              {
//                  var fIns = parseInt(document.getElementById("tblgrid").rows(j).cells(1).children[0].value);
//                  var tIns =   parseInt(document.getElementById("tblgrid").rows(j).cells(2).children[0].value);
//                
//                  var fromInsert = parseInt(document.getElementById("tblgrid").rows(j+1).cells(1).children[0].value);
//                  var toInsert =   parseInt(document.getElementById("tblgrid").rows(j+1).cells(2).children[0].value);
//                 
////                  var fromInsert = parseInt(document.getElementById("tblgrid").rows(j-1).cells(1).children[0].value);
////                  var toInsert =   parseInt(document.getElementById("tblgrid").rows(j-1).cells(2).children[0].value);
//                  if ((fromInsert >= fIns && fromInsert <= tIns) || (toInsert >= fIns && toInsert <= tIns) ) //|| (txtfdate == fdate && txttdate > tdate)
//                  {
//                      alert("Insertion already exist with this this Range for"+(j+1)+" Row.");
//                      return false;
//                  }
//                   j++;
//              }
//           }
          //-------------------------end -------------------------------------------//                      
  
  var adtype= document.getElementById("drpadtype").value;
  var adcategory=document.getElementById("listcategory").value;
  var adsubcategory=document.getElementById("listsubcategory").value;
  var adscat3= document.getElementById("listsubsubcatgory").value;
  var edition=document.getElementById("drpmainedilist").value;
  var edition_desc=document.getElementById("drpmainedilist").options[document.getElementById("drpmainedilist").selectedIndex].innerText;
  var uom=document.getElementById("drpuom").value;
  var color=document.getElementById("drpcolor").value;
  var sizeto=document.getElementById("txtline").value;
  var rate=document.getElementById("txtrate").value;
  var extrarate=document.getElementById("txtextrarate").value;
  var txtfrominsert="1";
  var txttoinsert="999";
  var scheme=document.getElementById("drpscheme").value;
  var fromdate=document.getElementById("txtvalidfrom").value;
  var currency=document.getElementById("hiddencurrency").value;
 /* var fdate;

   if(document.getElementById('hiddendateformat').value=="dd/mm/yyyy")
	{
	    var txt=fromdate;
        var txt1=txt.split("/");
        var dd=txt1[0];
        var mm=txt1[1];
        var yy=txt1[2];
        fromdate=mm+'/'+dd+'/'+yy;
	    fdate=new Date(fromdate);
	}
	else if(document.getElementById('hiddendateformat').value=="yyyy/mm/dd")
	{
	    var txt=fromdate;
        var txt1=txt.split("/");
        var yy=txt1[0];
        var mm=txt1[1];
        var dd=txt1[2];
        fromdate=mm+'/'+dd+'/'+yy;
	    fdate=new Date(fromdate);
	}
	else if(document.getElementById('hiddendateformat').value=="mm/dd/yyyy")
	{
	    fdate=new Date(fromdate);
	}
*/
   var sizefrom;
   if(sizeto =="0")
       sizefrom="0";
   else 
       sizefrom="1";
    var count=0;
    if(hiddentext != "modify")
    {
        // for checking subcategory is selected o rnot
        var fcat1=false;
        var fcat2=false;
         for(var k=1; k<document.getElementById("listsubcategory").options.length; k++)
         {
             if(document.getElementById("listsubcategory").options[k].selected==true)
                   {
                    fcat1=true;
                    break;
                   }
         }
          for(var l=1; l<document.getElementById("listsubsubcatgory").options.length; l++)
           {
            if(document.getElementById("listsubsubcatgory").options[l].selected==true)
                   {
                    fcat2=true;
                    break;
                   }
           }
        for(var j=1;j<document.getElementById("listcategory").options.length;j++)
        {
           if(document.getElementById("listcategory").options[j].selected==true)
           {
           //--------------------  for creation of rate unique id -----------------------------------//
               count++;
                var rateuniqueid = "";
//                if(adsubcategory=="")
//                    adsubcategory="0";
//                if(adscat3=="")
//                    adscat3="0";
                adcategory=document.getElementById("listcategory").options[j].value;
                adcategoryname=document.getElementById("listcategory").options[j].innerText;
              

              //--------------------- for multiple  subcategory  --------------------------------//
              if(fcat2==true && fcat1==true)
              {
                for(var k=1; k<document.getElementById("listsubcategory").options.length; k++)
                {
                  if(document.getElementById("listsubcategory").options[k].selected==true)
                   {
                      adsubcategory=document.getElementById("listsubcategory").options[k].value;

                 
             //-----------------------------------------------------------------------------------//   
             
          
                for(var l=1; l<document.getElementById("listsubsubcatgory").options.length; l++)
                {
                  if(document.getElementById("listsubsubcatgory").options[l].selected==true)
                   {
                     adscat3=document.getElementById("listsubsubcatgory").options[l].value;

             //-----------------------------------------------------------------------------------//   
                // if slab rates are not there
                if(document.getElementById("Adslabs").checked==false)
                {
                //pubcenter + ratecode + adtype + adcategory + adsubcategory + color + packagecode + currency + fromdate + tilldate + uom + adscat4 + adscat5 + adscat6 + premium + sizefrom + sizeto + txtfrominsert + txttoinsert + clientcat;
                            if(adtype=="CL0")
                            {
                                rateuniqueid = "0" + "LOCAL" + adtype + adcategory + adsubcategory + color + edition + currency + "" + "01/12/2020" + uom + adscat3 + "0" + "0" + "0" + sizefrom + sizeto + txtfrominsert + txttoinsert + "0";
                            }
                            if(adtype=="DI0")
                            {
                                 rateuniqueid = "0" + "LOCAL" + adtype + adcategory + adsubcategory + color + edition + currency+ "" + "01/12/2020" + uom + adscat3 + "0" + "0" + "0" + sizefrom + sizeto + txtfrominsert + txttoinsert + "0";
                            }
                            var res = RateMaster_CD.checkrate(compcode,userid ,rateuniqueid);
                            //----------------- insert rate in rate master table--------------------------------------//
                            var ds=res.value;
                           if(ds.Tables[0].Rows.length >0)
                           {
                             alert("Rates are already defined for SubSubCategory: " + document.getElementById("listsubsubcatgory").options[l].innerText);
                              return false;
                           }
                           else 
                           {
                              RateMaster_CD.saverate(compcode, userid, "LOCAL", adtype, "0", adcategory, currency, adsubcategory, edition, edition_desc, uom, sizefrom, sizeto, "0", color, "0", rate, "", extrarate, "", "", "",fromdate , "", "", "0", "", rateuniqueid, "", "", "", "", "", "", "", "", scheme, adscat3, "0", "0", txtfrominsert, txttoinsert, "0", "0", "", "", "", dateformat, "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                             //  alert("Data Saved Successfully.");
                           }
                }         
                else
                {
                    for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
                    {
                        txtfrominsert = document.getElementById("tblgrid").rows(i).cells(1).children[0].value;
                        txttoinsert =   document.getElementById("tblgrid").rows(i).cells(2).children[0].value;
                        rate =   document.getElementById("tblgrid").rows(i).cells(3).children[0].value;
                        extrarate =   document.getElementById("tblgrid").rows(i).cells(4).children[0].value;
                            if(adtype=="CL0")
                            {
                                rateuniqueid = "0" + "LOCAL" + adtype + adcategory + adsubcategory + color + edition + currency + "" + "01/12/2020" + uom + adscat3 + "0" + "0" + "0" + sizefrom + sizeto + txtfrominsert + txttoinsert + "0";
                            }
                            if(adtype=="DI0")
                            {
                                 rateuniqueid = "0" + "LOCAL" + adtype + adcategory + adsubcategory + color + edition + currency + "" + "01/12/2020" + uom + adscat3 + "0" + "0" + "0" + sizefrom + sizeto + txtfrominsert + txttoinsert + "0";
                            }
                            var res = RateMaster_CD.checkrate(compcode,userid ,rateuniqueid);
                            //----------------- insert rate in rate master table--------------------------------------//
                            var ds=res.value;
                           if(ds.Tables[0].Rows.length >0)
                           {
                             alert("Rates are already defined for SubSubCategory: " + document.getElementById("listsubsubcatgory").options[l].innerText + " and Slab " + txtfrominsert + " to " + txttoinsert);
                             return false;
                           }
                           else 
                           {
                              RateMaster_CD.saverate(compcode, userid, "LOCAL", adtype, "0", adcategory, currency, adsubcategory, edition, edition_desc, uom, sizefrom, sizeto, "0", color, "0", rate, "", extrarate, "", "", "", fromdate, "", "", "0", "", rateuniqueid, "", "", "", "", "", "", "", "", scheme, adscat3, "0", "0", txtfrominsert, txttoinsert, "0", "0", "", "", "", dateformat, "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                             
                           }
                    }
                }
                
               }// for sub cat
             // } for sub cat
             //} for subsub cat
            }// for subsub cat
            }
            }
            }// if subcategory and subsubcategory selected
            else if(fcat1==true && fcat2==false)
            {
                 for(var k=1; k<document.getElementById("listsubcategory").options.length; k++)
                {
                  if(document.getElementById("listsubcategory").options[k].selected==true)
                   {
                      adsubcategory=document.getElementById("listsubcategory").options[k].value;
                      adscat3="0";
                  
             //-----------------------------------------------------------------------------------//   
                // if slab rates are not there
                    if(document.getElementById("Adslabs").checked==false)
                    {
                                if(adtype=="CL0")
                                {
                                    rateuniqueid = "0" + "LOCAL" + adtype + adcategory + adsubcategory + color + edition + currency + "" + "01/12/2020" + uom + adscat3 + "0" + "0" + "0" + sizefrom + sizeto + txtfrominsert + txttoinsert + "0";
                                }
                                if(adtype=="DI0")
                                {
                                     rateuniqueid = "0" + "LOCAL" + adtype + adcategory + adsubcategory + color + edition + currency+ "" + "01/12/2020" + uom + adscat3 + "0" + "0" + "0" + sizefrom + sizeto + txtfrominsert + txttoinsert + "0";
                                }
                                var res = RateMaster_CD.checkrate(compcode,userid ,rateuniqueid);
                                //----------------- insert rate in rate master table--------------------------------------//
                                var ds=res.value;
                               if(ds.Tables[0].Rows.length >0)
                               {
                                 alert("Rates are already defined for SubCategory: " + document.getElementById("listsubcategory").options[k].innerText);
                                  return false;
                               }
                               else 
                               {
                                  RateMaster_CD.saverate(compcode, userid, "LOCAL", adtype, "0", adcategory, currency, adsubcategory, edition, edition_desc, uom, sizefrom, sizeto, "0", color, "0", rate, "", extrarate, "", "", "", fromdate, "", "", "0", "", rateuniqueid, "", "", "", "", "", "", "", "", scheme, adscat3, "0", "0", txtfrominsert, txttoinsert, "0", "0", "", "", "", dateformat, "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                                 //  alert("Data Saved Successfully.");
                               }
                    }         
                    else
                    {
                                    for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
                                    {
                                        txtfrominsert = document.getElementById("tblgrid").rows(i).cells(1).children[0].value;
                                        txttoinsert =   document.getElementById("tblgrid").rows(i).cells(2).children[0].value;
                                        rate =   document.getElementById("tblgrid").rows(i).cells(3).children[0].value;
                                        extrarate =   document.getElementById("tblgrid").rows(i).cells(4).children[0].value;
                                            if(adtype=="CL0")
                                            {
                                                rateuniqueid = "0" + "LOCAL" + adtype + adcategory + adsubcategory + color + edition + currency + "" + "01/12/2020" + uom + adscat3 + "0" + "0" + "0" + sizefrom + sizeto + txtfrominsert + txttoinsert + "0";
                                            }
                                            if(adtype=="DI0")
                                            {
                                                 rateuniqueid = "0" + "LOCAL" + adtype + adcategory + adsubcategory + color + edition +currency + "" + "01/12/2020" + uom + adscat3 + "0" + "0" + "0" + sizefrom + sizeto + txtfrominsert + txttoinsert + "0";
                                            }
                                            var res = RateMaster_CD.checkrate(compcode,userid ,rateuniqueid);
                                            //----------------- insert rate in rate master table--------------------------------------//
                                            var ds=res.value;
                                           if(ds.Tables[0].Rows.length >0)
                                           {
                                             alert("Rates are already defined for SubCategory: " + document.getElementById("listsubcategory").options[k].innerText + " and Slab " + txtfrominsert + " to " + txttoinsert);
                                             return false;
                                           }
                                           else 
                                           {
                                              RateMaster_CD.saverate(compcode, userid, "LOCAL", adtype, "0", adcategory, currency, adsubcategory, edition, edition_desc, uom, sizefrom, sizeto, "0", color, "0", rate, "", extrarate, "", "", "", fromdate, "", "", "0", "", rateuniqueid, "", "", "", "", "", "", "", "", scheme, adscat3, "0", "0", txtfrominsert, txttoinsert, "0", "0", "", "", "", dateformat, "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                                             
                                           }
                                    }// end of for
                        }// end of else
                }//end of if
               }// end of for sub category
             
           
            }// end main else if
            else
            {
                adsubcategory="0";
                adscat3="0";
                // if slab rates are not there
                    if(document.getElementById("Adslabs").checked==false)
                    {
                                if(adtype=="CL0")
                                {
                                    rateuniqueid = "0" + "LOCAL" + adtype + adcategory + adsubcategory + color + edition + currency + "" + "01/12/2020" + uom + adscat3 + "0" + "0" + "0" + sizefrom + sizeto + txtfrominsert + txttoinsert + "0";
                                }
                                if(adtype=="DI0")
                                {
                                     rateuniqueid = "0" + "LOCAL" + adtype + adcategory + adsubcategory + color + edition + currency + "" + "01/12/2020" + uom + adscat3 + "0" + "0" + "0" + sizefrom + sizeto + txtfrominsert + txttoinsert + "0";
                                }
                                var res = RateMaster_CD.checkrate(compcode,userid ,rateuniqueid);
                                //----------------- insert rate in rate master table--------------------------------------//
                                var ds=res.value;
                               if(ds.Tables[0].Rows.length >0)
                               {
                                 alert("Rates are already defined for category: " + adcategoryname);
                                  return false;
                               }
                               else 
                               {
                                  RateMaster_CD.saverate(compcode, userid, "LOCAL", adtype, "0", adcategory, currency, adsubcategory, edition, edition_desc, uom, sizefrom, sizeto, "0", color, "0", rate, "", extrarate, "", "", "", fromdate, "", "", "0", "", rateuniqueid, "", "", "", "", "", "", "", "", scheme, adscat3, "0", "0", txtfrominsert, txttoinsert, "0", "0", "", "", "", dateformat, "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                                 //  alert("Data Saved Successfully.");
                               }
                    }         
                    else
                    {
                                    for(var i=1;i<parseInt(document.getElementById("tblgrid").rows.length);i++)
                                    {
                                        txtfrominsert = document.getElementById("tblgrid").rows(i).cells(1).children[0].value;
                                        txttoinsert =   document.getElementById("tblgrid").rows(i).cells(2).children[0].value;
                                        rate =   document.getElementById("tblgrid").rows(i).cells(3).children[0].value;
                                        extrarate =   document.getElementById("tblgrid").rows(i).cells(4).children[0].value;
                                            if(adtype=="CL0")
                                            {
                                                rateuniqueid = "0" + "LOCAL" + adtype + adcategory + adsubcategory + color + edition + currency + "" + "01/12/2020" + uom + adscat3 + "0" + "0" + "0" + sizefrom + sizeto + txtfrominsert + txttoinsert + "0";
                                            }
                                            if(adtype=="DI0")
                                            {
                                                 rateuniqueid = "0" + "LOCAL" + adtype + adcategory + adsubcategory + color + edition + currency + "" + "01/12/2020" + uom + adscat3 + "0" + "0" + "0" + sizefrom + sizeto + txtfrominsert + txttoinsert + "0";
                                            }
                                            var res = RateMaster_CD.checkrate(compcode,userid ,rateuniqueid);
                                            //----------------- insert rate in rate master table--------------------------------------//
                                            var ds=res.value;
                                           if(ds.Tables[0].Rows.length >0)
                                           {
                                             alert("Rates are already defined for category: " + adcategoryname + " and Slab " + txtfrominsert + " to " + txttoinsert);
                                             return false;
                                           }
                                           else 
                                           {
                                              RateMaster_CD.saverate(compcode, userid, "LOCAL", adtype, "0", adcategory, currency, adsubcategory, edition, edition_desc, uom, sizefrom, sizeto, "0", color, "0", rate, "", extrarate, "", "", "", fromdate, "", "", "0", "", rateuniqueid, "", "", "", "", "", "", "", "", scheme, adscat3, "0", "0", txtfrominsert, txttoinsert, "0", "0", "", "", "", dateformat, "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                                             
                                           }
                                    }// end of for
                        }// end of else
            }// end of main else
           } // category selected
          }// for loop of category
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
      
      document.getElementById("tblgrid").style.display="none";
      document.getElementById("tblbutton").style.display="none";
      clearclick();  
      return false;
    }
    else 
    {
      var rateuniqueid = "";
        if(adtype=="CL0")
        {
            rateuniqueid = "0" + "LOCAL" + adtype + adcategory + adsubcategory + color + edition + currency + "" + "01/12/2020" + uom + adscat3 + "0" + "0" + "0" + sizefrom + sizeto + txtfrominsert + txttoinsert + "0";
        }
        if(adtype=="DI0")
        {
             rateuniqueid = "0" + "LOCAL" + adtype + adcategory + adsubcategory + color + edition + currency + "" + "01/12/2020" + uom + adscat3 + "0" + "0" + "0" + sizefrom + sizeto + txtfrominsert + txttoinsert + "0";
        }
       RateMaster_CD.modifyrate(compcode,userid ,rateuniqueid,rate,extrarate,sizeto);
       gdsexecute.Tables[0].Rows[rowN].Week_Day_Rate= document.getElementById("txtrate").value;
       gdsexecute.Tables[0].Rows[rowN].Week_Extra_Rate=document.getElementById("txtextrarate").value;
       
       alert("Data Modified Successfully.");
       updateStatus();
        document.getElementById('btnfirst').disabled=false;				
	    document.getElementById('btnnext').disabled=false;					
	    document.getElementById('btnprevious').disabled=false;			
	    document.getElementById('btnlast').disabled=false;
	    document.getElementById('btnExit').disabled=false;
       var x=gdsexecute.Tables[0].Rows.length;
       y=rowN;	
       if (rowN==0)
       {
        document.getElementById('btnfirst').disabled=true;
        document.getElementById('btnprevious').disabled=true;
       }

        if(rowN==(gdsexecute.Tables[0].Rows.length-1))
        {
            document.getElementById('btnNext').disabled=true;
            document.getElementById('btnLast').disabled=true;
        }
       document.getElementById("txtrate").disabled=true;
       document.getElementById("txtextrarate").disabled=true;
       document.getElementById("txtline").disabled=true;
       setButtonImages();
       return false;
    }  
}


function call_saverate(res)
{
   var ds=res.value;
   if(ds.Tables[0].Rows.length >0)
   {
     alert("This entry is already exists.");
     return false;
   }
   else 
   {
      var compcode = document.getElementById("hiddencompcode").value;
      var userid=document.getElementById("hiddenuserid").value;
      var dateformat=document.getElementById("hiddendateformat").value;
      var adtype= document.getElementById("drpadtype").value;
      var adcategory=document.getElementById("listcategory").value;
      var adsubcategory=document.getElementById("listsubcategory").value;
      var adscat3= document.getElementById("listsubsubcatgory").value;
      var edition=document.getElementById("drpmainedilist").value;
      var edition_desc=document.getElementById("drpmainedilist").options[document.getElementById("drpmainedilist").selectedIndex].innerText;
      var uom=document.getElementById("drpuom").value;
      var color=document.getElementById("drpcolor").value;
      var sizeto=document.getElementById("txtline").value;
      var rate=document.getElementById("txtrate").value;
      var extrarate=document.getElementById("txtextrarate").value;
      var txtfrominsert=document.getElementById("txtfrminsert").value;
      var txttoinsert=document.getElementById("txttoinsert").value;
      var scheme="";
     //--------------------for creation of rate unique id -----------------------------------//
     var rateuniqueid = "";
     if(adtype=="CL0")
     {
        rateuniqueid = "0" + "LOCAL" + adtype + adcategory + adsubcategory + color + edition + "0" + "" + "01/12/2020" + uom + adscat3 + "0" + "0" + "0" + "1" + sizeto + txtfrominsert + txttoinsert + "0";
     }
     if(adtype=="DI0")
     {
          rateuniqueid = "0" + "LOCAL" + adtype + adcategory + adsubcategory + color + edition + "0" + "" + "01/12/2020" + uom + adscat3 + "0" + "0" + "0" + "1" + sizeto + txtfrominsert + txttoinsert + "0";
     }
     
      RateMaster_CD.saverate(compcode, userid, "0", adtype, "0", adcategory, "0", adsubcategory, edition, edition_desc, uom, "1", sizeto, "0", color, "0", rate, "", extrarate, "", "", "", "", "", "", "0", "", rateuniqueid, "", "", "", "", "", "", "", "", scheme, adscat3, "0", "0", txtfrominsert, txttoinsert, "0", "0", "", "", "", dateformat, "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
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
  
}

function modifyclick()
{
   chkstatus(FlagStatus);
   document.getElementById('btnSave').disabled = false;
   document.getElementById('btnQuery').disabled = true; 
   document.getElementById('btnExecute').disabled=true;
   
   hiddentext="modify";
   document.getElementById("drpadtype").disabled=true;
   document.getElementById("listcategory").disabled=true;
   document.getElementById("listsubcategory").disabled=true;
   document.getElementById("listsubsubcatgory").disabled=true;
   document.getElementById("RadioButton1").disabled=true;
   document.getElementById("RadioButton2").disabled=true;
   document.getElementById("drpmainedilist").disabled=true;
   document.getElementById("drpuom").disabled=true;
   document.getElementById("drpcolor").disabled=true;
   document.getElementById("txtline").disabled=true;
//////   if(document.getElementById('hiddenuomdesc').value=="CD" || document.getElementById('hiddenuomdesc').value=="SQCM")
//////      document.getElementById("txtrate").disabled=true;
//////   else
     document.getElementById("txtrate").disabled=false;
  // onchange_uom();
   document.getElementById("txtextrarate").disabled=false;
   document.getElementById('Adslabs').disabled=true;
   document.getElementById("drpscheme").disabled=true;
   setButtonImages();
   return false;
}

function executeclick()
{

   // disableflds();
    pagedef();
    hiddentext="execute";
    var dateformat=document.getElementById("hiddendateformat").value;
    document.getElementById("tblinsertion").style.display="block";
    var compcode=document.getElementById("hiddencompcode").value;
    var adtype=document.getElementById("drpadtype").value;
    gladtype=adtype;
    var adcat =document.getElementById("listcategory").value;
    gladcat=adcat;
    var uomcode = document.getElementById("drpuom").value;
    gluomcode=uomcode;
    var editioncode = document.getElementById("drpmainedilist").value;
    gleditioncode=editioncode;
    var schemecode = document.getElementById("drpscheme").value;
    glschemecode=schemecode;
    
    rowN=0;
    var res = RateMaster_CD.executerate(compcode,adtype, adcat, uomcode, editioncode,schemecode,dateformat)
    executeclick_call(res);
   //updateStatus();
//    document.getElementById('btnfirst').disabled=true;				
//	document.getElementById('btnnext').disabled=false;					
//	document.getElementById('btnprevious').disabled=true;			
//	document.getElementById('btnlast').disabled=false;	
	if(document.getElementById('btnModify').disabled==false)					
	   document.getElementById('btnModify').focus();
  onchange_uom();
   
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

     document.getElementById('hiddenrateuniqid').value=gdsexecute.Tables[0].Rows[rowN].rateuniqueid;
     document.getElementById("drpadtype").value = gdsexecute.Tables[0].Rows[rowN].Adv_Type_Code;
     bind_pkg_adcat_uom(gdsexecute.Tables[0].Rows[rowN].Adv_Type_Code);
    
     for(var i=1;i<document.getElementById("listcategory").options.length;i++)
     {
       document.getElementById('listcategory').options[i].selected=false;
       if(document.getElementById("listcategory").options[i].value==gdsexecute.Tables[0].Rows[rowN].Adv_Cat_Code)
       {
        document.getElementById("listcategory").options[i].selected=true;
       }
     }
    
     bind_subcat(gdsexecute.Tables[0].Rows[rowN].Adv_Cat_Code);
////     for(var t=0;t<document.getElementById('listcategory').options.length;t++)
////     {
////          if(document.getElementById('listcategory').options[t].value == gdsexecute.Tables[0].Rows[rowN].Adv_Cat_Code)
////               document.getElementById('listcategory').options[t].selected=true;
////     }
    
  
//     document.getElementById("listsubcategory").value = gdsexecute.Tables[0].Rows[rowN].Adv_subcat_code;
     bind_subcat5(gdsexecute.Tables[0].Rows[rowN].Adv_subcat_code);
       for(var t1=0; t1<document.getElementById('listsubcategory').options.length;t1++)
     {
             document.getElementById('listsubcategory').options[t1].selected=false;
          if(document.getElementById('listsubcategory').options[t1].value == gdsexecute.Tables[0].Rows[rowN].Adv_subcat_code)
               document.getElementById('listsubcategory').options[t1].selected=true;
     }
     
//     document.getElementById("listsubsubcatgory").value = gdsexecute.Tables[0].Rows[rowN].Ad_Subcat4;
       for(var t12=0; t12<document.getElementById('listsubsubcatgory').options.length;t12++)
     {
        document.getElementById('listsubsubcatgory').options[t12].selected=false;
          if(document.getElementById('listsubsubcatgory').options[t12].value == gdsexecute.Tables[0].Rows[rowN].Ad_Subcat4)
               document.getElementById('listsubsubcatgory').options[t12].selected=true;
     }
     //document.getElementById("txtpkgdesc").value = gdsexecute.Tables[0].Rows[rowN].combin_desc;
     
     document.getElementById("drpuom").value = gdsexecute.Tables[0].Rows[rowN].Uom;
     document.getElementById("txtline").value = gdsexecute.Tables[0].Rows[rowN].Size_To;
 
     document.getElementById("drpmainedilist").options[0]=new Option(gdsexecute.Tables[0].Rows[rowN].desc,gdsexecute.Tables[0].Rows[rowN].Combin_Code);
     document.getElementById("drpmainedilist").options.length;
     document.getElementById("drpmainedilist").value = gdsexecute.Tables[0].Rows[rowN].Combin_Code;
     document.getElementById("drpcolor").value=gdsexecute.Tables[0].Rows[rowN].Color;
     document.getElementById("txtrate").value=gdsexecute.Tables[0].Rows[rowN].Week_Day_Rate;
    
  
    if(gdsexecute.Tables[0].Rows[rowN].Week_Extra_Rate==null || gdsexecute.Tables[0].Rows[rowN].Week_Extra_Rate=="null")
        document.getElementById("txtextrarate").value="";
    else    
        document.getElementById("txtextrarate").value=gdsexecute.Tables[0].Rows[rowN].Week_Extra_Rate;
      
    document.getElementById("txtfrminsert").value=gdsexecute.Tables[0].Rows[rowN].From_insertion;  
    document.getElementById("txttoinsert").value=gdsexecute.Tables[0].Rows[rowN].To_insertion;
    document.getElementById("drpscheme").value=gdsexecute.Tables[0].Rows[rowN].Scheme_Name;
    if(gdsexecute.Tables[0].Rows[rowN].Valid_From ==null)
       document.getElementById("txtvalidfrom").value="";
    else
       document.getElementById("txtvalidfrom").value=gdsexecute.Tables[0].Rows[rowN].Valid_From;
    
     
}

function firstclick()
{
    rowN=0;
    
    document.getElementById("btnfirst").disabled=true;
    document.getElementById("btnprevious").disabled=true;
    document.getElementById("btnnext").disabled=false;
    document.getElementById("btnlast").disabled=false;
    
    bindctrls();
    onchange_uom();
    setButtonImages();
    return false;
}

function prevclick()
{
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
    onchange_uom();
    setButtonImages();
    return false;
}

function nextclick()
{
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
    onchange_uom();
    setButtonImages();
    return false;
}

function lastclick()
{
    rowN=gdsexecute.Tables[0].Rows.length-1;
    
    document.getElementById("btnfirst").disabled=false;
    document.getElementById("btnprevious").disabled=false;
    document.getElementById("btnnext").disabled=true;
    document.getElementById("btnlast").disabled=true;
    
    bindctrls();
    onchange_uom();
    setButtonImages();
    return false;
}


function onchage_adtype()
{
    var adtype = document.getElementById("drpadtype").value;  
    var drpadcat=document.getElementById("listcategory");
    var drpsubcategory=document.getElementById("listsubcategory");
    var drpadscat4=document.getElementById("listsubsubcatgory");
       
    drpadcat.options.length=0;
    drpadcat.options[0]=new Option("--Select Category--","0");
    
    drpsubcategory.options.length=0;
    drpsubcategory.options[0]=new Option("--Select Sub Category--","0");
    
    drpadscat4.options.length=0;
    drpadscat4.options[0]=new Option("-Select Sub Sub Category-","0");
    
    if(adtype!="0")
        bind_pkg_adcat_uom(adtype);
    return false;
}

function bind_pkg_adcat_uom(adtype)
{
    var compcode=document.getElementById("hiddencompcode").value;
    var center="" ;
    var res=RateMaster_CD.pkg_adcat_uom_bind(compcode, adtype, center);
    var ds=res.value;
    
    var drpadcat=document.getElementById("listcategory");
    drpadcat.options.length=0;
    drpadcat.options[0]=new Option("--Select Adcategory--","0");
    
    var drpuom=document.getElementById("drpuom");
    
    drpuom.options.length=0;
    drpuom.options[0]=new Option("--Select UOM--","0");
    
     var i;
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                drpadcat.options[drpadcat.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name,ds.Tables[0].Rows[i].Adv_Cat_Code);
                drpadcat.options.length;   
            }
        }
        
       if(ds.Tables[1].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[1].Rows.length; ++i)
            {
                drpuom.options[drpuom.options.length] = new Option(ds.Tables[1].Rows[i].Uom_Name,ds.Tables[1].Rows[i].Uom_Code);
                drpuom.options.length;   
            }
        }
        
    }
}


function onclick_radiobutton()
{
   var flag;
    if(document.getElementById("drpadtype").value =="0")
  {
    alert("Please Enter Ad Type." );
    document.getElementById("drpadtype").focus();
    return false;
  }
   if(document.getElementById("RadioButton1").checked == true)
         flag=1;
    else
         flag=0;
     
     var adtype=document.getElementById("drpadtype").value;   
     var drpmainedilist=document.getElementById("drpmainedilist");
     drpmainedilist.options.length=0;
     drpmainedilist.options[0]=new Option("--Select Edition--","0");    
     var res=RateMaster_CD.bindedition(flag,adtype);
     if(res.value!=null)
     {
       if(res.value.Tables[0].Rows.length >0)
       {
         for(var i=0; i<res.value.Tables[0].Rows.length; i++)
         {
                drpmainedilist.options[drpmainedilist.options.length] = new Option(res.value.Tables[0].Rows[i].Combin_Desc,res.value.Tables[0].Rows[i].Combin_Code);
                drpmainedilist.options.length;  
         }
       }
     }
      
      
}


function onchange_cat()
{
    var count=0;
    var adcatvalue;
    for(var t1=0; t1<document.getElementById('listcategory').options.length; t1++)
    {
      if(document.getElementById("listcategory").options[t1].selected == true)
         count++;
    }  
    if(count ==1)
         adcatvalue = document.getElementById("listcategory").value;
     else
         adcatvalue="0";
      var drpadsubcat=document.getElementById("listsubcategory");
      var drpadscat4=document.getElementById("listsubsubcatgory");
      
       drpadsubcat.options.length=0;
       drpadsubcat.options[0]=new Option("--Select Sub Category--","0");
       
      drpadscat4.options.length=0;
      drpadscat4.options[0]=new Option("Select Sub Sub Category","0");
     
      if(adcatvalue!="0")
    {
        bind_subcat(adcatvalue);
    }
    return false;
}

function bind_subcat(adcat)
{
    var compcode=document.getElementById("hiddencompcode").value;
    var res=RateMaster_CD.adcatclick(compcode, adcat);
    var ds=res.value;
    var drpadsubcat=document.getElementById("listsubcategory");
    drpadsubcat.options.length=0;
    drpadsubcat.options[0]=new Option("--Select Sub Category--","0");
    var i;
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                drpadsubcat.options[drpadsubcat.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Subcat_Name,ds.Tables[0].Rows[i].Adv_Subcat_Code);
                drpadsubcat.options.length;   
            }
        }
    }
}


function onchange_cat4()
{
    var count=0;
    var adcat4value;
    for(var t1=0; t1<document.getElementById('listsubcategory').options.length; t1++)
    {
      if(document.getElementById("listsubcategory").options[t1].selected == true)
         count++;
    }  
   
    if(count ==1)
         adcat4value = document.getElementById("listsubcategory").value;
     else
         adcat4value="0";
         
    var drpadscat5=document.getElementById("listsubsubcatgory");    
    drpadscat5.options.length=0;
    drpadscat5.options[0]=new Option("Select Sub Sub Category","0");
     
    if(adcat4value!="0")
    {
        bind_subcat5(adcat4value);
    }
    return false;
}

function bind_subcat5(adscatvalue)
{
    var compcode=document.getElementById("hiddencompcode").value;
    var res=RateMaster_CD.bindsubcats(compcode, adscatvalue,"0");
    var ds=res.value;
    var drpadscat5=document.getElementById("listsubsubcatgory");
    drpadscat5.options.length=0;
    drpadscat5.options[0]=new Option("Select Sub Sub Category","0");
    var i;
    if(ds!=null)
    {
        if(ds.Tables[0].Rows.length>0)
        {
            for (i = 0  ; i < ds.Tables[0].Rows.length; ++i)
            {
                drpadscat5.options[drpadscat5.options.length] = new Option(ds.Tables[0].Rows[i].Cat_Name,ds.Tables[0].Rows[i].Cat_Code);
                drpadscat5.options.length;   
            }
        }
    }
}

function onchange_uom()
{
   
   var uom =document.getElementById('drpuom').value;
   var res_desc=RateMaster_CD.binddesc(uom);
   var ds=res_desc.value;
   if(ds!=null)
   {
     if(ds.Tables[0].Rows.length > 0)
     {
       if(ds.Tables[0].Rows[0].uom_desc == "ROL")
       {
          document.getElementById('hiddenuomdesc').value="" ;
          document.getElementById('lblline').innerHTML="Minimum Line<FONT color ='Red'>*</FONT>";
          if(hiddentext =="new") //if(hiddentext !="execute")
          { 
              document.getElementById("txtline").value ="";
              document.getElementById("txtrate").value="";
              document.getElementById("txtrate").disabled=false;
              document.getElementById("txtline").disabled=false;
          }
       }
       else if(ds.Tables[0].Rows[0].uom_desc == "ROW")
       {
          document.getElementById('hiddenuomdesc').value="";
          document.getElementById('lblline').innerHTML="Minimum Words<FONT color ='Red'>*</FONT>";
           if(hiddentext=="new")//if(hiddentext !="execute")
          {
              document.getElementById("txtline").value ="";
              document.getElementById("txtrate").value="";
              document.getElementById("txtrate").disabled=false;
              document.getElementById("txtline").disabled=false;
          }
       }
       else if(ds.Tables[0].Rows[0].uom_desc == "ROC")
       {
          document.getElementById('hiddenuomdesc').value="" ;
          document.getElementById('lblline').innerHTML="Minimum Character<FONT color ='Red'>*</FONT>";
          if(hiddentext =="new")// if(hiddentext=="execute")
          {
              document.getElementById("txtline").value ="";
              document.getElementById("txtrate").value="";
              document.getElementById("txtrate").disabled=false;
              document.getElementById("txtline").disabled=false;
          }
       }
        else if(ds.Tables[0].Rows[0].uom_desc == "CD" || ds.Tables[0].Rows[0].uom_desc=="SQCM")
       {
         document.getElementById('hiddenuomdesc').value=ds.Tables[0].Rows[0].uom_desc ;
        document.getElementById('lblline').innerHTML="Minimum Size<FONT color ='Red'>*</FONT>";
        if(hiddentext=="new")// if(hiddentext !="execute")
         {
           document.getElementById("txtline").value ="0";
              document.getElementById("txtrate").value="0";
              document.getElementById("txtrate").disabled=false;
              document.getElementById("txtline").disabled=false;
         }
       }
     }
   }
}

function deleteclick()
{
  if(confirm('Are you sure you want to delete?'))
  {
     var compcode = document.getElementById("hiddencompcode").value;
     var rateuniqueid=document.getElementById("hiddenrateuniqid").value;
     var dateformat=document.getElementById('hiddendateformat').value;
      
     RateMaster_CD.deleterate(rateuniqueid, compcode);
        alert("Data Deleted Successfully");
       rowN=0;  
      var res = RateMaster_CD.executerate(compcode,gladtype, gladcat, gluomcode, gleditioncode,glschemecode,dateformat)
      executeclick_call(res);
  }
  return false;
   
}
function addClick()
{
      var tableToSort=document.getElementById("tblgrid");
      newRow = tableToSort.insertRow();
      
      newCell = newRow.insertCell();
      var element1 = document.createElement("input");
      element1.type = "checkbox";
      newCell.appendChild(element1);

      newCell = newRow.insertCell();
      newCell.align="center";
      newCell.innerHTML = "<input type=text maxLength='5'  class=btextsmallsize onkeypress=\"return ClientisNumber(event)\"  OnBlur=\"return CheckInsertion(event,this.parentNode.parentNode);\">";//document.getElementById("txtfrminsert").value;
      newCell = newRow.insertCell();
      newCell.align="center";
      newCell.innerHTML = "<input type=text maxLength='5' class=btextsmallsize onkeypress=\"return ClientisNumber(event);\" OnBlur=\"return CheckInsertion(event,this.parentNode.parentNode);\">";
//////       if(document.getElementById('hiddenuomdesc').value=="CD" || document.getElementById('hiddenuomdesc').value=="SQCM")
//////         {
//////              newCell = newRow.insertCell();
//////              newCell.align="center";
//////              newCell.innerHTML = "<input type=text maxLength='6' disabled=true class=btextsmallsize onkeypress=\"return rateenter(event);\" >";
//////          }
//////          else
//////          {
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text maxLength='6' class=btextsmallsize onkeypress=\"return rateenter(event);\" >";
         ////// }
      newCell = newRow.insertCell();
      newCell.align="center";
      newCell.innerHTML = "<input type=text maxLength='6' class=btextsmallsize onkeypress=\"return rateenter(event);\">";
      return false;
}

function adslabclick()
{ 

  var lbadtype= document.getElementById("lbladtype").innerHTML;
  var lbadcategory=document.getElementById("lbladcategory").innerHTML;
  var lbadsubcategory=document.getElementById("lblsubcategory").innerHTML;
  var lbadscat3= document.getElementById("lblsubsubcategory").innerHTML;
  var lbedition=document.getElementById("ediname").innerHTML;
  var lbuom=document.getElementById("lbluom").innerHTML;
  var lbcolor=document.getElementById("lblcolor").innerHTML;
  var lbsizeto=document.getElementById("lblline").innerHTML;
  var lbrate=document.getElementById("lbrate").innerHTML;
  var lbextrarate=document.getElementById("lbextrarate").innerHTML;

  if((document.getElementById("drpadtype").value =="0") && (lbadtype.indexOf("*") >=0))
  {
    alert("Please Enter Ad Type." );
    document.getElementById("drpadtype").focus();
    return false;
  }
  else if((document.getElementById("listcategory").value =="") && (lbadcategory.indexOf("*") >="0"))
  {
    alert("Please Enter Ad Category." );
    document.getElementById("listcategory").focus();
    return false;
  }
  else if((document.getElementById("drpmainedilist").value =="0") && (lbedition.indexOf("*") >="0"))
  {
    alert("Please Enter Edition." );
    document.getElementById("drpmainedilist").focus();
    return false;
  }
   else if((document.getElementById("drpcolor").value =="0") && (lbcolor.indexOf("*") >="0"))
  {
    alert("Please Enter Color." );
     if(document.getElementById("drpcolor").disabled==false)
    document.getElementById("drpcolor").focus();
    return false;
  }
   else if((document.getElementById("drpuom").value =="0") && (lbuom.indexOf("*") >="0"))
  {
    alert("Please Enter Uom." );
    document.getElementById("drpuom").focus();
    return false;
  }
    else if((document.getElementById("txtline").value =="") && (lbsizeto.indexOf("*") >="0"))
  {
    alert("Please Enter Size To." );
    if(document.getElementById("txtline").disabled==false)
      document.getElementById("txtline").focus();
    return false;
  }
  
  if (document.getElementById("Adslabs").checked == true)
 {
     document.getElementById("tblrate").style.display="none";
     document.getElementById("tblgrid").style.display="block";
     document.getElementById("tblbutton").style.display="block";
     var tableToSort=document.getElementById("tblgrid");
     newRow = tableToSort.insertRow();
 
       //------ Dynamic TABLE  heading-----//
          newRow.className ="dtGridrate";
            newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "";
          
          newCell = newRow.insertCell();
          newCell.align="center";
         
          newCell.innerHTML = "From Insert";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "To Insert";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "Minimum Amount";
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "Rate";
          
          newRow = tableToSort.insertRow();
          
            newCell = newRow.insertCell();
            var element1 = document.createElement("input");
	        element1.type = "checkbox";
	        newCell.appendChild(element1);

          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text maxLength='5'  class=btextsmallsize onkeypress=\"return ClientisNumber(event);\" OnBlur=\"return CheckInsertion(event,this.parentNode.parentNode);\">";//document.getElementById("txtfrminsert").value;
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text maxLength='5' class=btextsmallsize onkeypress=\"return ClientisNumber(event);\"  OnBlur=\"return CheckInsertion(event,this.parentNode.parentNode);\" >";
//////         if(document.getElementById('hiddenuomdesc').value=="CD" || document.getElementById('hiddenuomdesc').value=="SQCM")
//////         {
//////              newCell = newRow.insertCell();
//////              newCell.align="center";
//////              newCell.innerHTML = "<input type=text maxLength='6' disabled=true class=btextsmallsize onkeypress=\"return rateenter(event);\" >";
//////          }
//////          else
//////          {
              newCell = newRow.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text maxLength='6' class=btextsmallsize onkeypress=\"return rateenter(event);\" >";
        //////  }
          newCell = newRow.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text maxLength='6' class=btextsmallsize onkeypress=\"return rateenter(event);\" >";

          newRow1 = tableToSort.insertRow();
          newCell = newRow1.insertCell();
            var element1 = document.createElement("input");
	        element1.type = "checkbox";
	        newCell.appendChild(element1);
	        
          newCell = newRow1.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text maxLength='5' class=btextsmallsize onkeypress=\"return ClientisNumber(event);\" OnBlur=\"return CheckInsertion(event,this.parentNode.parentNode);\">";//document.getElementById("txtfrminsert").value;
          newCell = newRow1.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text maxLength='5' class=btextsmallsize onkeypress=\"return ClientisNumber(event);\" OnBlur=\"return CheckInsertion(event,this.parentNode.parentNode);\">";
//////           if(document.getElementById('hiddenuomdesc').value=="CD" || document.getElementById('hiddenuomdesc').value=="SQCM")
//////         {
//////             newCell = newRow1.insertCell();
//////             newCell.align="center";
//////             newCell.innerHTML = "<input type=text maxLength='5' disabled=true class=btextsmallsize onkeypress=\"return rateenter(event);\" >";//onchange=\"return chkamount('txtrate');
//////          }
//////          else
//////          {
              newCell = newRow1.insertCell();
              newCell.align="center";
              newCell.innerHTML = "<input type=text maxLength='5' class=btextsmallsize onkeypress=\"return rateenter(event);\" >";//onchange=\"return chkamount('txtrate');
        //////  }
         
          newCell = newRow1.insertCell();
          newCell.align="center";
          newCell.innerHTML = "<input type=text maxLength='5' class=btextsmallsize onkeypress=\"return rateenter(event);\" >";
}
 else
 {
       document.getElementById("tblrate").style.display="block";
       document.getElementById("tblgrid").style.display="none";
       document.getElementById("tblbutton").style.display="none";
       var Parent = document.getElementById("tblgrid");
       while(Parent.hasChildNodes())
       {
         Parent.removeChild(Parent.firstChild);
       }
    
 }
     
}
//**************************  function for check Insertion************************///
//var maxRow=document.getElementById('tblgrid').rows.length-1;
//if(parseInt(maxRow)==parseInt(name.rowIndex))
//{
function CheckInsertion(event,name)
{
  try {
        var table = document.getElementById("tblgrid");
        var rowCount = table.rows.length;
      
        while(rowCount>1)
       {
            var rowindex=parseInt(name.rowIndex);
           
            var row1 = table.rows[rowindex];
            var fromInsert =row1.cells[1].childNodes[0].value;
            var toInsert =  row1.cells[2].childNodes[0].value;
            
            for(var i=1; i<=rowCount-1; i++) 
            {
              if(parseInt(rowindex,10)!=parseInt(i,10))
              {
                  var row = table.rows[i];
                  var frominsert1 = row.cells[1].childNodes[0].value;
                  var toinsert1 = row.cells[2].childNodes[0].value;
                  if(fromInsert !="" && toInsert!="")
                 {  
                    if(parseInt(toInsert,10) < parseInt(fromInsert,10))
                        {
                        alert("To Insert Can't be lesser than From Insert.");
                                row1.cells[2].childNodes[0].value="";
                                row1.cells[2].childNodes[0].focus();
                        return false;
                        }
                    if((parseInt(fromInsert,10) < parseInt(frominsert1,10) && parseInt(toInsert,10) > parseInt(toinsert1,10)))
                        {
                        alert("This data can't be inserted....");
                        row1.cells[2].childNodes[0].value="";
                         row1.cells[2].childNodes[0].focus();
                        return false;
                        }
                 }
                 
                 if(fromInsert !="" && frominsert1!="" ) //&& toinsert1 !="" && toInsert!="" )
                 {
                         if ((parseInt(fromInsert,10) >= parseInt(frominsert1,10) && parseInt(fromInsert,10) <= parseInt(toinsert1,10)) )
                          {
                             alert("From Insert already defined");
                             row1.cells[1].childNodes[0].value="";
                             row1.cells[1].childNodes[0].focus();
                             i=rowCount;
                             return false;
                          }       
                  }
                 if( toinsert1 !="" && toInsert!="" )
                  {
                          if ((parseInt(toInsert,10) >= parseInt(frominsert1,10) && parseInt(toInsert,10) <= parseInt(toinsert1,10)) )
                          {
                            
                                alert("ToInsert already defined");
                                row1.cells[2].childNodes[0].value="";
                                row1.cells[2].childNodes[0].focus();
                                i=rowCount;
                                return false;
                        }
                 }
                
              }
           }
          rowCount--;
        }
      }catch(e)
       {
            alert(e);
       }
       // document.getElementById("tblgrid").rows(1).cells(1).children[0].focus();
        return false;

}
//*********************************************************************************///

function disableflds()
{
   document.getElementById("drpadtype").disabled=true;
   document.getElementById("listcategory").disabled=true;
   document.getElementById("listsubcategory").disabled=true;
   document.getElementById("listsubsubcatgory").disabled=true;
   document.getElementById("RadioButton1").disabled=true;
   document.getElementById("RadioButton2").disabled=true;
   document.getElementById("drpmainedilist").disabled=true;
   document.getElementById("drpuom").disabled=true;
   document.getElementById("drpcolor").disabled=true;
   document.getElementById("txtline").disabled=true;
   document.getElementById("txtrate").disabled=true;
   document.getElementById("txtextrarate").disabled=true;
   document.getElementById('Adslabs').disabled=true;
   document.getElementById("lblscheme").disabled=true;
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

function chkamount(e)
{
    var flag="";
    e=document.getElementById(e);//.value;
    var fld=e.value;
	if(fld!="")
    {
	    if(fld.match(/^\d+(\.\d{1,3})?$/i))
		{
			flag="t";
			return flag;
	    }
		else
		{
			alert("Input Error")
			var str=e.id;
			e.value="";
			document.getElementById(str).focus();
			flag="f";
			return flag;
		}
	}
}
function deleteRow()
 {
        try {
        var flag =0;
        var table = document.getElementById("tblgrid");
        var rowCount = table.rows.length;

        for(var i=0; i<rowCount; i++) {
            var row = table.rows[i];
            var chkbox = row.cells[0].childNodes[0];
            if(null != chkbox && true == chkbox.checked) {
                table.deleteRow(i);
                flag=1;
                rowCount--;
                i--;
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