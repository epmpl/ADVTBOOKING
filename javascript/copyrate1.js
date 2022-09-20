// JScript File

function copyrate()
{
    if(document.getElementById("txtsrcrcode").value=="")
    {
        alert("Please Enter Source Rate Code");
        document.getElementById("txtsrcrcode").focus();
        return false;
    }
    else if(document.getElementById("txtdestrcode").value=="")
    {
        alert("Please Enter Destination Rate Code");
        document.getElementById("txtdestrcode").focus();
        return false;
    }
    else if(document.getElementById("drpsrcrgrcode").value=="0")
    {
        alert("Please Enter Source Rate Group Code");
        document.getElementById("drpsrcrgrcode").focus();
        return false;
    }
    else if(document.getElementById("drpdestrgrcode").value=="0")
    {
        alert("Please Enter Destination Rate Group Code");
        document.getElementById("drpdestrgrcode").focus();
        return false;
    }
    else if(trim(document.getElementById("txtsrcrcode").value)==trim(document.getElementById("txtdestrcode").value))
    {
        alert("Source and Destination Rate Code Can't Be Same");
        document.getElementById("txtdestrcode").value=="";
        document.getElementById("txtdestrcode").focus();
        return false;
    }
    else
    {
        var scrRCode=document.getElementById("txtsrcrcode").value;
        var destRCode=document.getElementById("txtdestrcode").value;
        var srcRGrCode=document.getElementById("drpsrcrgrcode").value;
        var destRGrCode=document.getElementById("drpdestrgrcode").value;
        var dateformat=document.getElementById("hiddendateformat").value;
        copyrate1.copyrate(scrRCode,destRCode,srcRGrCode,destRGrCode,dateformat);
        alert("Rates Copied Successfully");
        
    }
    return false;
}

function rset1()
{
    document.getElementById("txtsrcrcode").value="";
    document.getElementById("txtdestrcode").value="";
    document.getElementById("drpsrcrgrcode").value="0";
    document.getElementById("drpdestrgrcode").value="0";
    return false;
}



//*******************************************************************************//
//*********************This For The Do The laters in capital laters**************//
//*******************************************************************************//	
function eventcalling(event)
{

    if(event.keyCode==97) 
        event.keyCode= 65;
    if(event.keyCode==98) 
        event.keyCode= 66;
    if(event.keyCode==99) 
        event.keyCode= 67;
    if(event.keyCode==100) 
        event.keyCode= 68;
    if(event.keyCode==101) 
        event.keyCode= 69;
    if(event.keyCode==102) 
        event.keyCode= 70;
    if(event.keyCode==103) 
        event.keyCode= 71;
    if(event.keyCode==104) 
        event.keyCode= 72;
    if(event.keyCode==105) 
        event.keyCode= 73;
    if(event.keyCode==106) 
        event.keyCode= 74;
    if(event.keyCode==107) 
        event.keyCode= 75;
    if(event.keyCode==108) 
        event.keyCode= 76;
    if(event.keyCode==109) 
        event.keyCode= 77;
    if(event.keyCode==110) 
        event.keyCode= 78;
    if(event.keyCode==111) 
        event.keyCode= 79;
    if(event.keyCode==112) 
        event.keyCode= 80;
    if(event.keyCode==113) 
        event.keyCode= 81;
    if(event.keyCode==114) 
        event.keyCode= 82;
    if(event.keyCode==115) 
        event.keyCode= 83;
    if(event.keyCode==116) 
        event.keyCode= 84;
    if(event.keyCode==117) 
        event.keyCode= 85;
    if(event.keyCode==118) 
        event.keyCode= 86;
    if(event.keyCode==119) 
        event.keyCode= 87;
    if(event.keyCode==120) 
        event.keyCode= 88;
    if(event.keyCode==121) 
        event.keyCode= 89;
    if(event.keyCode==122) 
        event.keyCode= 90;

}