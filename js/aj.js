   function applyimg()
   {
       var xx= document.getElementById('imgCropped').src;
       opener.document.getElementById('imagepath').value=xx;
       opener.document.getElementById('applylink').style.visibility='visible';
       opener.document.getElementById('applylink').disabled=false;
       window.close();
      }
 