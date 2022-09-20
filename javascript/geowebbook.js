

       var i = 0;
       var browser = navigator.appName;
       function exit() {
           window.close();
           return false;
       }



       function savegeo() {

           
           var aa = document.getElementById('dynamicvalue');
           var trobject = document.getElementById('someTree');

           var aa1 = aa.innerHTML;

           var bb = aa.innerHTML.split('temptables**')

           var cc = bb.length - 1
           cc = cc + 6;
            try {

                var rowth = document.getElementById('dynamicvalue');
                var divcount = rowth.childNodes.length;

           


                    if (browser!= "Microsoft Internet Explorer") {

                        for (var i = 0; i < divcount - 1; i++) {
                       // var id1 = rowth.childNodes[i+1].innerHTML.split('width="180px">')[1].split('</td>')[0];
                            var id1 =rowth.childNodes[i + 1].textContent;
                           // alert(rowth.childNodes[i + 1].textContent);
//                            alert(rowth.childNodes[i+1].textContent);
//                            alert(rowth.childNodes[i+1].innerHTML);
                            //                        '
//                            alert(id1)
//                          var country, state, city;
//                          var s1 = id1.split('---')[0];
//                          var s2 = (id1.split('---')[1]);
//                          alert(s2);
//                          var s3 = id1.split('---')[2];
//                          var s4 = id1.split('---')[3];
//                          var s5 = id1.split('---')[4];
//                          var s6 = id1.split('---')[5];
                         

                        
                          var le = id1.split('---');
                          var len = le.length;
                          
               
                             if (len == 4) {
                             
                             

                                      country = id1.split('---')[1].split('(')[1].split(')')[0];

                                     state = id1.split('---')[2].split('(')[1].split(')')[0];


                                    city = id1.split('---')[3].split('(')[1].split(')')[0]


                                }

                              if (len == 3) {

                                  country = id1.split('---')[1].split('(')[1].split(')')[0];

                                state = id1.split('---')[2].split('(')[1].split(')')[0];
                                city = ""

                       

                               }

                                  if (len == 2) {

                                   country = id1.split('---')[1].split('(')[1].split(')')[0]

                                   state = "";
                                    city = "";

                             }
                             var ciobookid = document.getElementById('hdnciobookid').value;
                             var editiongeo = document.getElementById('hdneditiongeo').value;
                             var noofinsert = document.getElementById('hdnnoinsert').value;
                             var re = geoweb.savegeography(country, state, city, editiongeo, ciobookid, noofinsert, document.getElementById('hiddencompcode').value)

                         }



                         var rotation = document.getElementById('txtrotation').value;
                         var priority = document.getElementById('txtpriority').value;




                         if (document.getElementById('chks').checked.toString() == "true") {

                             var chs = "Y";
                         }
                         else {
                             chs = "N";


                         }


                         var sunday_from = document.getElementById('tfs').value;
                         var sunday_to = document.getElementById('tts').value;


                         if (document.getElementById('chkm').checked.toString() == "true") {

                             var chm = "Y";
                         }
                         else {
                             chm = "N";


                         }

                         var monday_from = document.getElementById('tfm').value;
                         var monday_to = document.getElementById('ttm').value;




                         if (document.getElementById('chkt').checked.toString() == "true") {

                             var cht = "Y";
                         }
                         else {
                             cht = "N";


                         }

                         var tuesday_from = document.getElementById('tft').value;
                         var tuesday_to = document.getElementById('ttt').value;




                         if (document.getElementById('chkw').checked.toString() == "true") {

                             var chw = "Y";
                         }
                         else {
                             chw = "N";


                         }


                         var wednesday_from = document.getElementById('tfw').value;
                         var wednesday_to = document.getElementById('ttw').value;



                         if (document.getElementById('chkth').checked.toString() == "true") {

                             var chth = "Y";
                         }
                         else {
                             chth = "N";


                         }


                         var thursday_from = document.getElementById('tft1').value;
                         var thursday_to = document.getElementById('ttt1').value;




                         if (document.getElementById('chkf').checked.toString() == "true") {

                             var chf = "Y";
                         }
                         else {
                             chf = "N";


                         }

                         var friday_from = document.getElementById('tff').value;
                         var friday_to = document.getElementById('ttf').value;





                         if (document.getElementById('chksat').checked.toString() == "true") {

                             var chsat = "Y";
                         }
                         else {
                             chsat = "N";


                         }



                         var saturday_from = document.getElementById('tfsat').value;
                         var saturday_to = document.getElementById('ttsat').value;

                         if (document.getElementById('ml1').checked.toString() == "true") {

                             var Sex = "M";


                         }
                         else {

                             var Sex = "F";
                         }

                         var agegroup = document.getElementById('age1').value;
                         var occupy = document.getElementById('occup').value;

                         var compcode = document.getElementById('hiddencompcode').value;
                         var cioid = document.getElementById('hdnciobookid').value;
                         var nooinsert = document.getElementById('hdnnoinsert').value;

                         var edition = document.getElementById('hdneditiongeo').value;


                         var uom = document.getElementById('hdnuom').value;
                         var premium = document.getElementById('hdnpageprem').value;
                         var adcatgeory = document.getElementById('hdnadcategory').value;
                         var dummydate = document.getElementById('hdndummydate').value;
                         var check = document.getElementById('dynamiccheck').innerHTML
                         var pp = "";
                 
                         for (var kk = 0; kk < document.getElementById('dynamiccheck').innerHTML.split('id=').length - 1; kk++) {
                             if (document.getElementById('te' + kk).checked == true) {

                                 pp += document.getElementById('te' + kk).value + ",";

                                
                             }
                             var rem = pp.slice(0, -1);
                         }

                    

                         geoweb.sayedays123(rotation, priority, chs, sunday_from, sunday_to, chm, monday_from, sunday_to, cht, tuesday_from, tuesday_to, chw, wednesday_from, wednesday_to, chth, thursday_from, thursday_to, chf, friday_from, friday_to, chsat, saturday_from, saturday_to, Sex, agegroup, occupy, "", cioid, nooinsert, compcode, edition, uom, premium, adcatgeory, dummydate, rem) 
                         
                         
                         
                         
                         
                         
                         alert('Data Saved Sucessfully');

                         window.close();
                        

                    }

                    else {


                        for (var i = 0; i < divcount ; i++) {

                        var id1 = rowth.childNodes[i].innerText;

                 
                       
                         var country, state, city;

                    var le = id1.split('---');
                             var len = le.length;
                             if (len == 4) {

                                      country = id1.split('---')[1].split('(')[1].split(')')[0];

                                     state = id1.split('---')[2].split('(')[1].split(')')[0];


                                    city = id1.split('---')[3].split('(')[1].split(')')[0]


                                }

                              if (len == 3) {

                                  country = id1.split('---')[1].split('(')[1].split(')')[0];

                                 state = id1.split('---')[2].split('(')[1].split(')')[0];
                               city=""

                               }

                                  if (len == 2) {

                                   country = id1.split('---')[1].split('(')[1].split(')')[0]

                                   state = "";
                                    city = "";

                             }
                             var ciobookid = document.getElementById('hdnciobookid').value;
                             var editiongeo = document.getElementById('hdneditiongeo').value;

                             var noofinsert = document.getElementById('hdnnoinsert').value;
                             var re = geoweb.savegeography(country, state, city, editiongeo, ciobookid, noofinsert, document.getElementById('hiddencompcode').value)

                         }


                         var rotation = document.getElementById('txtrotation').value;
                         var priority = document.getElementById('txtpriority').value;




                         if (document.getElementById('chks').checked.toString() == "true") {

                             var chs = "Y";
                         }
                         else {
                             chs = "N";


                         }


                         var sunday_from = document.getElementById('tfs').value;
                         var sunday_to = document.getElementById('tts').value;


                         if (document.getElementById('chkm').checked.toString() == "true") {

                             var chm = "Y";
                         }
                         else {
                             chm = "N";


                         }

                         var monday_from = document.getElementById('tfm').value;
                         var monday_to = document.getElementById('ttm').value;




                         if (document.getElementById('chkt').checked.toString() == "true") {

                             var cht = "Y";
                         }
                         else {
                             cht = "N";


                         }

                         var tuesday_from = document.getElementById('tft').value;
                         var tuesday_to = document.getElementById('ttt').value;




                         if (document.getElementById('chkw').checked.toString() == "true") {

                             var chw = "Y";
                         }
                         else {
                             chw = "N";


                         }


                         var wednesday_from = document.getElementById('tfw').value;
                         var wednesday_to = document.getElementById('ttw').value;



                         if (document.getElementById('chkth').checked.toString() == "true") {

                             var chth = "Y";
                         }
                         else {
                             chth = "N";


                         }


                         var thursday_from = document.getElementById('tft1').value;
                         var thursday_to = document.getElementById('ttt1').value;




                         if (document.getElementById('chkf').checked.toString() == "true") {

                             var chf = "Y";
                         }
                         else {
                             chf = "N";


                         }

                         var friday_from = document.getElementById('tff').value;
                         var friday_to = document.getElementById('ttf').value;





                         if (document.getElementById('chksat').checked.toString() == "true") {

                             var chsat = "Y";
                         }
                         else {
                             chsat = "N";


                         }



                         var saturday_from = document.getElementById('tfsat').value;
                         var saturday_to = document.getElementById('ttsat').value;

                         if (document.getElementById('ml1').checked.toString() == "true") {

                             var Sex = "M";


                         }
                         else {

                             var Sex = "F";
                         }

                         var agegroup = document.getElementById('age1').value;
                         var occupy = document.getElementById('occup').value;

                         var compcode = document.getElementById('hiddencompcode').value;
                         var cioid = document.getElementById('hdnciobookid').value;
                         var nooinsert = document.getElementById('hdnnoinsert').value;

                         var edition = document.getElementById('hdneditiongeo').value;


                         var uom = document.getElementById('hdnuom').value;
                         var premium = document.getElementById('hdnpageprem').value;
                         var adcatgeory = document.getElementById('hdnadcategory').value;
                         var dummydate = document.getElementById('hdndummydate').value;
                         var check = document.getElementById('dynamiccheck').innerHTML
                         var pp="";
                         
                         for(var kk=0 ; kk<document.getElementById('dynamiccheck').innerHTML.split('INPUT id=').length-1 ; kk++)
                         {
                         if(document.getElementById('te'+kk).checked==true)
                         {

                              pp+=document.getElementById('te' + kk).Text + ",";

                          }
                          var rem = pp.slice(0, -1);
                         
                         
                         
                         }

                       
                         geoweb.sayedays123(rotation, priority, chs, sunday_from, sunday_to, chm, monday_from, sunday_to, cht, tuesday_from, tuesday_to, chw, wednesday_from, wednesday_to, chth, thursday_from, thursday_to, chf, friday_from, friday_to, chsat, saturday_from, saturday_to, Sex, agegroup, occupy, "", cioid, nooinsert, compcode, edition, uom, premium, adcatgeory, dummydate,rem)
                         
                         
                         
                         
                         
                         alert('Data Saved Sucessfully');

                         window.close();
                        
                   
                    
                    }
                
                
            
            
            }
            catch(e) {
            alert(e);
            }
            
           
           
           
           
           

             
               
               
               
           
           
           }


  



//           return false;
//       }
   
   
   

       function OnTreeClick(evt) {

           var src = window.event != window.undefined ? window.event.srcElement : evt.target;

      
           

           var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");

           if (isChkBoxClick) {

               var parentTable = GetParentByTagName("table", src);

               if (browser != "Microsoft Internet Explorer") {

                   var aa = parentTable.textContent

                 
                   dynamicgrid(aa, src.checked, src);
               }
               else {

                   var aa = parentTable.outerText
                   dynamicgrid(aa, src.checked, src);
                }
               
              
               

               var nxtSibling = parentTable.nextSibling;

               //check if nxt sibling is not null & is an element node

               if (nxtSibling && nxtSibling.nodeType == 1) {

                   //if node has children    

                   if (nxtSibling.tagName.toLowerCase() == "div") {

                       //check or uncheck children at all levels

                       CheckUncheckChildren(parentTable.nextSibling, src.checked);

                   }

               }

               //check or uncheck parents at all levels

               CheckUncheckParents(src, src.checked);

           }

       }



       function CheckUncheckChildren(childContainer, check) {

           var childChkBoxes = childContainer.getElementsByTagName("input");

           var childChkBoxCount = childChkBoxes.length;

           for (var i = 0; i < childChkBoxCount; i++) {

               childChkBoxes[i].checked = check;
               childChkBoxes[i].disabled = check;
               
               

           }

       }



       function CheckUncheckParents(srcChild, check) {

           var parentDiv = GetParentByTagName("div", srcChild);

           var parentNodeTable = parentDiv.previousSibling;

           if (parentNodeTable) {

               var checkUncheckSwitch;

               //checkbox checked 

               if (check) {

                   var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);

                   if (isAllSiblingsChecked)

                       checkUncheckSwitch = true;

                   else

                       return; //do not need to check parent if any(one or more) child not checked

               }

               else //checkbox unchecked
               {

                   checkUncheckSwitch = false;

               }



               var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");

               if (inpElemsInParentTable.length > 0) {

                   var parentNodeChkBox = inpElemsInParentTable[0];

                   parentNodeChkBox.checked = checkUncheckSwitch;

                   //do the same recursively

                   CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);

               }

           }

       }



       function AreAllSiblingsChecked(chkBox) {

           var parentDiv = GetParentByTagName("div", chkBox);

           var childCount = parentDiv.childNodes.length;

           for (var i = 0; i < childCount; i++) {

               if (parentDiv.childNodes[i].nodeType == 1) {

                   //check if the child node is an element node

                   if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {

                       var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];

                       //if any of sibling nodes are not checked, return false

                       if (!prevChkBox.checked) {

                           return false;

                       }

                   }

               }

           }

           return true;

       }



       //utility function to get the container of an element by tagname

       function GetParentByTagName(parentTagName, childElementObj) {

           var parent = childElementObj.parentNode;

           while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {

               parent = parent.parentNode;

           }

           return parent;

       }


       function dynamicgrid(aa, check1, treeviewobject) {

         
           var parentDiv123 = GetParentByTagName("div", treeviewobject);
           var te = treeviewobject.id;
                      if (check1 == true) {
                          var aa1 = "";
                          // document.getElementById(treeviewobject);



                          if (browser != "Microsoft Internet Explorer") {
                              if (treeviewobject.parentNode.cellIndex == 3) {


                                  var parentDiv12345 = GetParentByTagName("div", parentDiv123.previousSibling);
                                  var main = parentDiv12345.previousSibling.innerText

                                  aa1 += "<div class ='gridtext' id=dydiv!" + aa + "><table   width='200px'><tr><td width='180px' value=" + "Country~" + parentDiv12345.previousSibling.textContent + "State~" + parentDiv123.previousSibling.textContent + "City~" + aa + " id=" + "temptables**" + i + ">" + "<i>Country</i>" + "---" + parentDiv12345.previousSibling.textContent + "</br><i>State</i>" + "---" + parentDiv123.previousSibling.textContent + "</br><i>City</i>" + "---" + aa + "</td><td class='image1' align='right' width='20px'><a href='#'  id=dydiv!" + aa + " onclick='a_close(this.id," + te + ")'><img id='img1'  src='btimages/cross.JPG' class='image'/></a></td></tr></table></div>"
                                  dynamicvalue.innerHTML += aa1;
                                  i++;
                              }



                              if (treeviewobject.parentNode.cellIndex == 2) {


                                  aa1 += "<div class ='gridtext' id=dydiv!" + aa + "><table   width='200px'><tr><td width='180px' value=" + "Country~" + parentDiv123.previousSibling.textContent + "State~" + aa + " id=" + "temptables**" + i + ">" + "<i>Country</i>" + "---" + parentDiv123.previousSibling.textContent + "</br><i>State</i>" + "---" + aa + "</td><td class='image1' align='right' width='20px'><a href='#'  id=dydiv!" + aa + " onclick='a_close(this.id," + te + ")'><img id='img1'  src='btimages/cross.JPG' class='image'/></a></td></tr></table></div>"
                                  dynamicvalue.innerHTML += aa1;
                                  i++;
                              }
                              if (treeviewobject.parentNode.cellIndex == 1) {

                                  aa1 += "<div class ='gridtext' id=dydiv!" + aa + "><table  width='200px'><tr><td width='180px' value=" + "Country~" + aa + " id=" + "temptables**" + i + ">" + "<i>Country</i>" + "---" + aa + "</td><td class='image1' align='right' width='20px'><a href='#'  id=dydiv!" + aa + " onclick='a_close(this.id," + te + ")'><img id='img1'  src='btimages/cross.JPG' class='image'/></a></td></tr></table></div>"
                                  dynamicvalue.innerHTML += aa1;
                                  i++;

                              }
                          }

                          else {

                              if (treeviewobject.parentNode.cellIndex == 3) {


                                  var parentDiv12345 = GetParentByTagName("div", parentDiv123.previousSibling);
                                  var main = parentDiv12345.previousSibling.innerText

                                  aa1 += "<div class ='gridtext' id=dydiv!" + aa + "><table   width='200px'><tr><td width='180px' value=" + "Country~" + parentDiv12345.previousSibling.innerText + "State~" + parentDiv123.previousSibling.innerText + "City~" + aa + " id=" + "temptables**" + i + ">" + "<i>Country</i>" + "---" + parentDiv12345.previousSibling.innerText + "</br><i>State</i>" + "---" + parentDiv123.previousSibling.innerText + "</br><i>City</i>" + "---" + aa + "</td><td class='image1' align='right' width='20px'><a href='#'  id=dydiv!" + aa + " onclick='a_close(this.id," + te + ")'><img id='img1'  src='btimages/cross.JPG' class='image'/></a></td></tr></table></div>"
                                  dynamicvalue.innerHTML += aa1;
                                  i++;
                              }



                              if (treeviewobject.parentNode.cellIndex == 2) {


                                  aa1 += "<div class ='gridtext' id=dydiv!" + aa + "><table   width='200px'><tr><td width='180px' value=" + "Country~" + parentDiv123.previousSibling.innerText + "State~" + aa + " id=" + "temptables**" + i + ">" + "<i>Country</i>" + "---" + parentDiv123.previousSibling.innerText + "</br><i>State</i>" + "---" + aa + "</td><td class='image1' align='right' width='20px'><a href='#'  id=dydiv!" + aa + " onclick='a_close(this.id," + te + ")'><img id='img1'  src='btimages/cross.JPG' class='image'/></a></td></tr></table></div>"
                                  dynamicvalue.innerHTML += aa1;
                                  i++;
                              }
                              if (treeviewobject.parentNode.cellIndex == 1) {

                                  aa1 += "<div class ='gridtext' id=dydiv!" + aa + "><table  width='200px'><tr><td width='180px' value=" + "Country~" + aa + " id=" + "temptables**" + i + ">" + "<i>Country</i>" + "---" + aa + "</td><td class='image1' align='right' width='20px'><a href='#'  id=dydiv!" + aa + " onclick='a_close(this.id," + te + ")'><img id='img1'  src='btimages/cross.JPG' class='image'/></a></td></tr></table></div>"
                                  dynamicvalue.innerHTML += aa1;
                                  i++;

                              }
                          
                          
                          }
                          
                          
                          
                          
                       
                    }
                   else {
                     var divid="dydiv!"+aa;

                     a_close1(divid, te);
                  }
       }


       function a_close(i,obj) {
           var aa = document.getElementById('dynamicvalue');
           var bb = document.getElementById(i);
           if (bb != null) {

               aa.removeChild(bb);
           }

         //  if (obj.nextSibling.innerText == bb.innerText) {

               var parentTable1 = GetParentByTagName("table", obj);
               if (obj.checked == true) {


                   obj.checked = false;
                   var nxtSibling = parentTable1.nextSibling;

                   if (nxtSibling && nxtSibling.nodeType == 1) {

                       //if node has children    

                       if (nxtSibling.tagName.toLowerCase() == "div") {

                           CheckUncheckChildren(parentTable1.nextSibling, false)
                       }
                   }
             //  }
           }
   
           return false;
       }


       function a_close1(i, obj) {
           var aa = document.getElementById('dynamicvalue');
           var bb = document.getElementById(i);

           if (bb != null) {


               aa.removeChild(bb);
           }
           return false;
       }
       
       function aa1(ii) {

           var cc = ii.innerText;
      
           var tree = document.getElementById('someTree');

       }


       function abc_close(id) {

           if (browser != "Microsoft Internet Explorer") {

               var bb1 = document.getElementById(id).textContent;
           }
           else {
               var bb1 = document.getElementById(id).innerText;
           }
           var country1 = "";
           var State1 = "";
           var City1 = "";

           if (bb1.split('Country')[1].length > 0) {

               country1 = bb1.split('Country')[1].split('(')[1].split(')')[0].toString();
           }

           if (bb1.split('State')[1] != undefined && bb1.split('State')[1] != "undefined" && bb1.split('State')[1].length > 0) {

               State1 = bb1.split('State')[1].split('(')[1].split(')')[0].toString();
           }


           if (bb1.split('City')[1] != undefined && bb1.split('City')[1] != "undefined" && bb1.split('City')[1].length > 0) {

               City1 = bb1.split('State')[1].split('(')[1].split(')')[0].toString();
           }


           var id1 = bb1.split('**');
           var child = id1[0];
           var del = id1[1];



           var edition = del.split('+')[0];
           var bookingid = del.split('+')[1];
           var noofinsert = del.split('+')[2];
           var compcode = del.split('+')[3];


           if (document.getElementById('hdnflag').value == "M") {
               geoweb1.deltegeo(compcode, edition, noofinsert, bookingid, country1, State1, City1);
               var aa = document.getElementById('dynamicvalue');
               var bb = document.getElementById(id);

               if (bb != null) {
                   aa.removeChild(bb);
               }
            
           }


        return false;

    }



    function abc_close123(id) {


        if (browser != "Microsoft Internet Explorer") {

            var bb1 = document.getElementById(id).textContent;
        }
        else {
            var bb1 = document.getElementById(id).innerText;
        }
        var country1 = "";
        var State1 = "";
        var City1 = "";
        
        if (bb1.split('Country')[1].length>0) {

             country1 = bb1.split('Country')[1].split('(')[1].split(')')[0].toString();
        }

        if (bb1.split('State')[1]!=undefined && bb1.split('State')[1]!="undefined" && bb1.split('State')[1].length > 0) {


            if (bb1.split('State')[1].split('(')[1] != undefined && bb1.split('State')[1].split('(')[1] != "undefined") {
                State1 = bb1.split('State')[1].split('(')[1].split(')')[0].toString();
            }
        }


        if (bb1.split('City')[1] != undefined && bb1.split('City')[1] != "undefined" && bb1.split('City')[1].length > 0) {

            if (bb1.split('City')[1].split('(')[1] != undefined && bb1.split('City')[1].split('(')[1] != "undefined") {


                City1 = bb1.split('State')[1].split('(')[1].split(')')[0].toString();
            }
        }


        var id1 = bb1.split('**');
        var child = id1[0];
        var del = id1[1];



        var edition = del.split('+')[0];
        var bookingid = del.split('+')[1];
        var noofinsert = del.split('+')[2];
        var compcode = del.split('+')[3];




        geoweb.tempdeltegeo(compcode, edition, noofinsert, bookingid, country1, State1, City1);

            var aa = document.getElementById('dynamicvalue');
            var bb = document.getElementById(id);

            if (bb != null) {
                aa.removeChild(bb);
            }



        return false;

    }


    function savegeo1() {
    
    
        var rowth = document.getElementById('dynamicvalue');
        var divcount = rowth.childNodes.length;


        if (browser != "Microsoft Internet Explorer") {


            for (var i = 0; i < divcount - 1; i++) {
                // var id1 = rowth.childNodes[i+1].innerHTML.split('width="180px">')[1].split('</td>')[0];
                var id1 = rowth.childNodes[i + 1].textContent;
                // alert(rowth.childNodes[i + 1].textContent);
                //                            alert(rowth.childNodes[i+1].textContent);
                //                            alert(rowth.childNodes[i+1].innerHTML);
                //                        '
                //                            alert(id1)
                //                          var country, state, city;
                //                          var s1 = id1.split('---')[0];
                //                          var s2 = (id1.split('---')[1]);
                //                          alert(s2);
                //                          var s3 = id1.split('---')[2];
                //                          var s4 = id1.split('---')[3];
                //                          var s5 = id1.split('---')[4];
                //                          var s6 = id1.split('---')[5];



                var le = id1.split('---');
                var len = le.length;
                if (len == 4) {

                    country = id1.split('---')[1].split('(')[1].split(')')[0];

                    state = id1.split('---')[2].split('(')[1].split(')')[0];


                    city = id1.split('---')[3].split('(')[1].split(')')[0]


                }

                if (len == 3) {

                    country = id1.split('---')[1].split('(')[1].split(')')[0];

                    state = id1.split('---')[2].split('(')[1].split(')')[0];
                    city = ""

                }

                if (len == 2) {

                    country = id1.split('---')[1].split('(')[1].split(')')[0]

                    state = "";
                    city = "";

                }
                var ciobookid = document.getElementById('hdnciobookid123').value;
                var editiongeo = document.getElementById('hdneditiongeo123').value;

                var noofinsert = document.getElementById('hdnnoinsert123').value;
                var re = geoweb1.savegeography(country, state, city, editiongeo, ciobookid, noofinsert, document.getElementById('hiddencompcode').value)



            }






        }
        else {



            for (var i = 0; i < divcount; i++) {

                var id1 = rowth.childNodes[i].innerText;



                var country, state, city;

                var le = id1.split('---');
                var len = le.length;
                if (len == 4) {

                    country = id1.split('---')[1].split('(')[1].split(')')[0];

                    state = id1.split('---')[2].split('(')[1].split(')')[0];


                    city = id1.split('---')[3].split('(')[1].split(')')[0]


                }

                if (len == 3) {

                    country = id1.split('---')[1].split('(')[1].split(')')[0];

                    state = id1.split('---')[2].split('(')[1].split(')')[0];
                    city = ""

                }

                if (len == 2) {

                    country = id1.split('---')[1].split('(')[1].split(')')[0]

                    state = "";
                    city = "";

                }
                var ciobookid = document.getElementById('hdnciobookid123').value;
                var editiongeo = document.getElementById('hdneditiongeo123').value;

                var noofinsert = document.getElementById('hdnnoinsert123').value;
                var re = geoweb1.savegeography(country, state, city, editiongeo, ciobookid, noofinsert, document.getElementById('hiddencompcode').value)



            }
            
            
        }



        var rotation = document.getElementById('txtrotation').value;
        var priority = document.getElementById('txtpriority').value;




        if (document.getElementById('chks').checked.toString() == "true") {

            var chs = "Y";
        }
        else {
            chs = "N";


        }


        var sunday_from = document.getElementById('tfs').value;
        var sunday_to = document.getElementById('tts').value;


        if (document.getElementById('chkm').checked.toString() == "true") {

            var chm = "Y";
        }
        else {
            chm = "N";


        }

        var monday_from = document.getElementById('tfm').value;
        var monday_to = document.getElementById('ttm').value;




        if (document.getElementById('chkt').checked.toString() == "true") {

            var cht = "Y";
        }
        else {
            cht = "N";


        }

        var tuesday_from = document.getElementById('tft').value;
        var tuesday_to = document.getElementById('ttt').value;




        if (document.getElementById('chkw').checked.toString() == "true") {

            var chw = "Y";
        }
        else {
            chw = "N";


        }


        var wednesday_from = document.getElementById('tfw').value;
        var wednesday_to = document.getElementById('ttw').value;



        if (document.getElementById('chkth').checked.toString() == "true") {

            var chth = "Y";
        }
        else {
            chth = "N";


        }


        var thursday_from = document.getElementById('tft1').value;
        var thursday_to = document.getElementById('ttt1').value;




        if (document.getElementById('chkf').checked.toString() == "true") {

            var chf = "Y";
        }
        else {
            chf = "N";


        }

        var friday_from = document.getElementById('tff').value;
        var friday_to = document.getElementById('ttf').value;





        if (document.getElementById('chksat').checked.toString() == "true") {

            var chsat = "Y";
        }
        else {
            chsat = "N";


        }



        var saturday_from = document.getElementById('tfsat').value;
        var saturday_to = document.getElementById('ttsat').value;

        if (document.getElementById('ml1').checked.toString() == "true") {

            var Sex = "M";


        }
        else {

            var Sex = "F";
        }

        var agegroup = document.getElementById('age1').value;
        var occupy = document.getElementById('occup').value;

        var compcode = document.getElementById('hiddencompcode').value;
        var cioid = document.getElementById('hdnciobookid123').value;
        var nooinsert = document.getElementById('hdnnoinsert123').value;

        var edition = document.getElementById('hdneditiongeo123').value;







        geoweb1.sayedays12345(rotation, priority, chs, sunday_from, sunday_to, chm, monday_from, sunday_to, cht, tuesday_from, tuesday_to, chw, wednesday_from, wednesday_to, chth, thursday_from, thursday_to, chf, friday_from, friday_to, chsat, saturday_from, saturday_to, Sex, agegroup, occupy, "", cioid, nooinsert, compcode, edition)
        
        
        

        alert('Data Saved Sucessfully');

        window.close();
        
        

        return false;
    }



    function excutedays123() {

        var res = geoweb1.excutedays12345(document.getElementById('hdnciobookid123').value, document.getElementById('hiddencompcode').value, document.getElementById('hdnnoinsert123').value);
       
       showdays123(res)
       
        return false;
    }

    function showdays123(res) {

        dx = res.value;

        if (dx.Tables[0].Rows.length > 0) {
            document.getElementById('txtrotation').value = dx.Tables[0].Rows[0].Rotation;
            document.getElementById('txtpriority').value = dx.Tables[0].Rows[0].Priority;



            if (dx.Tables[0].Rows[0].Sunday == "Y") {
                document.getElementById('chks').checked = true;
            }
            else {

                document.getElementById('chks').checked = false;
            }

            document.getElementById('tfs').value = dx.Tables[0].Rows[0].Sunday_From;
            document.getElementById('tts').value = dx.Tables[0].Rows[0].Sunday_To;



            if (dx.Tables[0].Rows[0].Monday == "Y") {
                document.getElementById('chkm').checked = true;
            }
            else {

                document.getElementById('chkm').checked = false;
            }


            document.getElementById('tfm').value = dx.Tables[0].Rows[0].Monday_From;
            document.getElementById('ttm').value = dx.Tables[0].Rows[0].Monday_To;



            if (dx.Tables[0].Rows[0].Tuesday == "Y") {
                document.getElementById('chkt').checked = true;
            }
            else {

                document.getElementById('chkt').checked = false;
            }

            document.getElementById('tft').value = dx.Tables[0].Rows[0].Tuesday_From;
            document.getElementById('ttt').value = dx.Tables[0].Rows[0].Tuesday_To;



            if (dx.Tables[0].Rows[0].Wednesday == "Y") {
                document.getElementById('chkw').checked = true;
            }
            else {

                document.getElementById('chkw').checked = false;
            }

            document.getElementById('tfw').value = dx.Tables[0].Rows[0].Wednesday_From;
            document.getElementById('ttw').value = dx.Tables[0].Rows[0].Wednesday_To;




            if (dx.Tables[0].Rows[0].Thursday == "Y") {
                document.getElementById('chkth').checked = true;
            }
            else {

                document.getElementById('chkth').checked = false;
            }

            document.getElementById('tft1').value = dx.Tables[0].Rows[0].Thursday_From;
            document.getElementById('ttt1').value = dx.Tables[0].Rows[0].Thursday_To;



            if (dx.Tables[0].Rows[0].Friday == "Y") {
                document.getElementById('chkf').checked = true;
            }
            else {

                document.getElementById('chkf').checked = false;
            }


            document.getElementById('tff').value = dx.Tables[0].Rows[0].Friday_From;
            document.getElementById('ttf').value = dx.Tables[0].Rows[0].Friday_To;




            if (dx.Tables[0].Rows[0].Saturday == "Y") {
                document.getElementById('chksat').checked = true;
            }
            else {

                document.getElementById('chksat').checked = false;
            }


            document.getElementById('tfsat').value = dx.Tables[0].Rows[0].Saturday_From;
            document.getElementById('ttsat').value = dx.Tables[0].Rows[0].Saturday_To;






            if (dx.Tables[0].Rows[0].Demog_sex == "M") {
                document.getElementById('ml1').checked = true;
            }
            else {

                document.getElementById('fe1').checked = true;
            }



            document.getElementById('age1').value = dx.Tables[0].Rows[0].Demog_agegroup;
            document.getElementById('occup').value = dx.Tables[0].Rows[0].Demog_Occup;


           // for (var s = 0; s < dx.Tables[0].Rows[0].interest.split(',').length; s++) {


            

                for (var kk = 0; kk < document.getElementById('dynamiccheck').innerHTML.split('id=').length-1; kk++) {

                    
                    if (dx.Tables[0].Rows[0].interest.split(',').length == 1) {
                       
                        //document.getElementById("te" + kk).disabled = true;
                        if (document.getElementById("te" + kk).value == dx.Tables[0].Rows[0].interest) {
                           // document.getElementById("te" + kk).disabled = true;
                          
                            document.getElementById("te" + kk).checked = true;
                        }
                    
                    }
                    else
                    {
                      document.getElementById("te" + kk).disabled = true;
                      if (document.getElementById("te" + kk).value == dx.Tables[0].Rows[0].interest.split(',')[kk]) {
                        document.getElementById("te" + kk).checked = true;
                    }

                }




            }


        }
       

        
        
        


        return false;
    }












    function tempexcutedays123() {

        var res = geoweb.tempexcutedays12345(document.getElementById('hdnciobookid').value, document.getElementById('hiddencompcode').value, document.getElementById('hdnnoinsert').value);

        showdays123(res)

        return false;
    }

    function tempshowdays123(res) {

        dx = res.value;

        if (dx.Tables[0].Rows.length > 0) {
            document.getElementById('txtrotation').value = dx.Tables[0].Rows[0].Rotation;
            document.getElementById('txtpriority').value = dx.Tables[0].Rows[0].Priority;

        }

        if (dx.Tables[0].Rows[0].Sunday == "Y") {
            document.getElementById('chks').checked = true;
        }
        else {

            document.getElementById('chks').checked = false;
        }

        document.getElementById('tfs').value = dx.Tables[0].Rows[0].Sunday_From;
        document.getElementById('tts').value = dx.Tables[0].Rows[0].Sunday_To;



        if (dx.Tables[0].Rows[0].Monday == "Y") {
            document.getElementById('chkm').checked = true;
        }
        else {

            document.getElementById('chkm').checked = false;
        }


        document.getElementById('tfm').value = dx.Tables[0].Rows[0].Monday_From;
        document.getElementById('ttm').value = dx.Tables[0].Rows[0].Monday_To;



        if (dx.Tables[0].Rows[0].Tuesday == "Y") {
            document.getElementById('chkt').checked = true;
        }
        else {

            document.getElementById('chkt').checked = false;
        }

        document.getElementById('tft').value = dx.Tables[0].Rows[0].Tuesday_From;
        document.getElementById('ttt').value = dx.Tables[0].Rows[0].Tuesday_To;



        if (dx.Tables[0].Rows[0].Wednesday == "Y") {
            document.getElementById('chkw').checked = true;
        }
        else {

            document.getElementById('chkw').checked = false;
        }

        document.getElementById('tfw').value = dx.Tables[0].Rows[0].Wednesday_From;
        document.getElementById('ttw').value = dx.Tables[0].Rows[0].Wednesday_To;




        if (dx.Tables[0].Rows[0].Thursday == "Y") {
            document.getElementById('chkth').checked = true;
        }
        else {

            document.getElementById('chkth').checked = false;
        }

        document.getElementById('tft1').value = dx.Tables[0].Rows[0].Thursday_From;
        document.getElementById('ttt1').value = dx.Tables[0].Rows[0].Thursday_To;



        if (dx.Tables[0].Rows[0].Friday == "Y") {
            document.getElementById('chkf').checked = true;
        }
        else {

            document.getElementById('chkf').checked = false;
        }


        document.getElementById('tff').value = dx.Tables[0].Rows[0].Friday_From;
        document.getElementById('ttf').value = dx.Tables[0].Rows[0].Friday_To;




        if (dx.Tables[0].Rows[0].Saturday == "Y") {
            document.getElementById('chksat').checked = true;
        }
        else {

            document.getElementById('chksat').checked = false;
        }


        document.getElementById('tfsat').value = dx.Tables[0].Rows[0].Saturday_From;
        document.getElementById('ttsat').value = dx.Tables[0].Rows[0].Saturday_To;






        if (dx.Tables[0].Rows[0].Demog_sex == "M") {
            document.getElementById('ml1').checked = true;
        }
        else {

            document.getElementById('fe1').checked = true;
        }



        document.getElementById('age1').value = dx.Tables[0].Rows[0].Demog_agegroup;
        document.getElementById('occup').value = dx.Tables[0].Rows[0].Demog_Occup;











        return false;
    }



    function comparesundayfrom() {

        if (parseInt(document.getElementById('tfs').value) > parseInt(document.getElementById('tts').value)) {


            alert('Sunday From should be less than Sunday To');
            document.getElementById('tfs').focus();
            document.getElementById('tfs').value = "0";
            return false;
        }
        return false;
    }






    function comparesundayto() {

        if (parseInt(document.getElementById('tfs').value) > parseInt(document.getElementById('tts').value)) {


            alert('Sunday To should be greater than Sunday From');
            document.getElementById('tts').focus();
            document.getElementById('tts').value = "0";
            return false;
        }
        return false;
    }





    function comparemondayfrom() {

        if (parseInt(document.getElementById('tfm').value) > parseInt(document.getElementById('ttm').value)) {


            alert('Monday From should be less than Monday To');
            document.getElementById('tfm').focus();
            document.getElementById('tfm').value = "0";
            return false;
        }
        return false;
    }






    function comparemondayto() {

        if (parseInt(document.getElementById('tfm').value) > parseInt(document.getElementById('ttm').value)) {


            alert('Monday To should be greater than Monday From');
            document.getElementById('ttm').focus();
            document.getElementById('ttm').value = "0";
            return false;
        }
        return false;
    }



    function comparetuesdayfrom() {

        if (parseInt(document.getElementById('tft').value) > parseInt(document.getElementById('ttt').value)) {


            alert('Tuesday From should be less than Tuesday To');
            document.getElementById('tft').focus();
            document.getElementById('tft').value = "0";
            return false;
        }
        return false;
    }






    function comparetuesdayto() {

        if (parseInt(document.getElementById('tft').value) > parseInt(document.getElementById('ttt').value)) {



            alert('Tuesday From should be greater than Tuesday To');
            document.getElementById('ttt').focus();
            document.getElementById('ttt').value = "0";
            return false;
        }
        return false;
    }




    function comparewednesdayfrom() {

        if (parseInt(document.getElementById('tfw').value) > parseInt(document.getElementById('ttw').value)) {


            alert('Wednesday From should be less than Wednesday To');
            document.getElementById('tfw').focus();
            document.getElementById('tfw').value = "0";
            return false;
        }
        return false;
    }






    function comparewednesdayto() {

        if (parseInt(document.getElementById('tfw').value) > parseInt(document.getElementById('ttw').value)) {



            alert('Wednesday To should be greater than Wednesday From');
            document.getElementById('ttw').focus();
            document.getElementById('ttw').value = "0";
            return false;
        }
        return false;
    }




  









    function comparethursdayfrom() {

        if (parseInt(document.getElementById('tft1').value) > parseInt(document.getElementById('ttt1').value)) {


            alert('Thursday From should be less than Thursday To');
            document.getElementById('tft1').focus();
            document.getElementById('tft1').value = "0";
            return false;
        }
        return false;
    }


    





    function comparethursdayto() {

        if (parseInt(document.getElementById('tft1').value) > parseInt(document.getElementById('ttt1').value)) {



            alert('Thursday From should be less than Thursday To');
            document.getElementById('ttt1').focus();
            document.getElementById('ttt1').value = "0";
            return false;
        }
        return false;
    }




    function comparefridayfrom() {

        if (parseInt(document.getElementById('tff').value) > parseInt(document.getElementById('ttf').value)) {


            alert('Friday From should be less than Friday To');
            document.getElementById('tff').focus();
            document.getElementById('ttf').value = "0";
            return false;
        }
        return false;
    }






    function comparefridayto() {

        if (parseInt(document.getElementById('tff').value) > parseInt(document.getElementById('ttf').value)) {



            alert('Friday From should be less than Friday To');
            document.getElementById('ttf').focus();
            document.getElementById('ttf').value = "0";
            return false;
        }
        return false;
    }



    function comparedsaturdayfrom() {

        if (parseInt(document.getElementById('tfsat').value) > parseInt(document.getElementById('ttsat').value)) {


            alert('Saturday From should be less than Saturday To');
            document.getElementById('tfsat').focus();
            document.getElementById('tfsat').value = "0";
            return false;
        }
        return false;
    }






    function comparesaturdayto() {

        if (parseInt(document.getElementById('tfsat').value) > parseInt(document.getElementById('ttsat').value)) {



            alert('Saturday From should be less than Saturday To');
            document.getElementById('ttsat').focus();
            document.getElementById('ttsat').value = "0";
            return false;
        }
        return false;
    }



    function openrotation() {


        window.open('defaultviews.aspx?filename=bookdiv' + "&ciobookid=" + document.getElementById('hdnciobookid').value + "&adcategory=" + document.getElementById('hdnadcategory').value + "&uom=" + document.getElementById('hdnuom').value + "&dummydate=" + document.getElementById('hdndummydate').value + "&pageprem=" + document.getElementById('hdnpageprem').value + "&edition=" + document.getElementById('hdneditiongeo').value, '', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=220px,height=150px');
        return false;

    }





    function openrotation1() {


        window.open('defaultviews.aspx?filename=bookdiv' + "&ciobookid=" + document.getElementById('hdnciobookid123').value + "&adcategory=" + document.getElementById('hdnadcategory').value + "&uom=" + document.getElementById('hdnuom').value + "&dummydate=" + document.getElementById('hdndummydate').value + "&pageprem=" + document.getElementById('hdnpageprem').value + "&edition=" + document.getElementById('hdneditiongeo123').value, '', 'status=0,toolbar=0,resizable=0,scrollbars=yes,top=144,left=210,width=220px,height=150px');
        return false;

    }




    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }


    function tabvalue123(event) {
                            var key = event.keyCode ? event.keyCode : event.which;

        if (key == 13 || key == 9) {


            if (document.activeElement.id == "txtrotation") {
            
            
            if(  document.getElementById('txtrotation').value==""||document.getElementById('txtrotation').value!="")
{
    document.getElementById('txtpriority').focus();
    return false;       
            }
            
            }
            
            
            
           if (document.activeElement.id == "txtpriority") {
            
              if(  document.getElementById('txtpriority').value==""||document.getElementById('txtpriority').value!="")
{
    document.getElementById('chks').focus();
    return false;             
            }
            }
            
            
                       if (document.activeElement.id == "chks") {
              if(  document.getElementById('chks').value==""||document.getElementById('chks').value!="")
{
    document.getElementById('chks').focus();
    return false;           
           
           
           
            }
            }



        return false;
    }
 
 }




function RTrim(value) {

     var re = /((\s*\S+)*)\s*/;
     return value.replace(re, "document.getElementById1");

 }

 // Removes leading and ending whitespaces
 function trim(value) {

     return LTrim(RTrim(value));

 }



 function LTrim(value) {

     var re = /\s*((\S+\s*)*)/;
     return value.replace(re, "document.getElementById1");

 }








 