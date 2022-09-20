// JScript File
///this function is to save the data in mm/dd/yyyy format
function savedateinto(dat,id)
{
var sadate=dat;
var setdate;
var dateformat=document.getElementById('hiddendateformat').value;
    if(id=="0")
    {
        if(sadate!="")
        {
                if(dateformat=="mm/dd/yyyy")
			    {
			    return setdate=sadate;
			    }
			    if(dateformat=="dd/mm/yyyy")
			    {
			        var txt1=sadate;
			        var txt2=txt1.split("/");
			        var dd=txt2[0];
			        var mm=txt2[1];
			        var yy=txt2[2];
			      return setdate=mm+'/'+dd+'/'+yy;
			    }
			     if(dateformat=="yyyy/mm/dd")
			    {
			        var txt1=sadate;
			        var txt2=txt1.split("/");
			        var yy=txt2[0];
			        var mm=txt2[1];
			        var dd=txt2[2];
			     return   setdate=mm+'/'+dd+'/'+yy;
			    
			    }
      }	
    }  
    if(id=="1")
    {
            var currdate=new Date(sadate);
			
			
			var dd=currdate.getDate();
			var mm=currdate.getMonth() + 1;
			var yyyy=currdate.getFullYear();
			
			var currdate1=mm+'/'+dd+'/'+yyyy;
			var currda=dd+'/'+mm+'/'+yyyy;
			var curryear=yyyy+'/'+mm+'/'+dd;
			
			if(dateformat=="mm/dd/yyyy")
			{
			    return currdate1;
			
			}
			else if(dateformat=="dd/mm/yyyy")
			{
			    return currda;
			
			}
			if(dateformat=="yyyy/mm/dd")
			{
			    return curryear;
			
			}
    
    
    
    }


}