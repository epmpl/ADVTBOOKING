// American and Indonatian Numbering System 



//var th = ['','thousand','million', 'billion','trillion'];
var th = ['','ribu','juta', 'milliar','trillion'];
// uncomment this line for English Number System
// var th = ['','thousand','million', 'milliard','billion'];

//var dg = ['zero','one','two','three','four', 'five','six','seven','eight','nine']; 
var dg = ['zero','satu','dua','tiga','empat', 'lima','enam','tujuh','delapan','sembilan']; 
//var tn = ['ten','eleven','twelve','thirteen', 'fourteen','fifteen','sixteen', 'seventeen','eighteen','nineteen']; 
var tn = ['sepuluh','sebelas','dua belas','tiga belas', 'empat belas','lima belas','enam belas', 'tujuh belas','delapan belas','sembilan belas']; 
//var tw = ['twenty','thirty','forty','fifty', 'sixty','seventy','eighty','ninety']; 
var tw = ['dua puluh','tiga puluh','empat puluh','lima puluh', 'enam puluh','tujuh puluh','delapan puluh','sembilan puluh']; 
function toWords(s)
{
    s = s.toString();
    s = s.replace(/[\, ]/g,'');
    if (s != String(parseFloat(s))) return 'not a number'; 
    var x = s.indexOf('.'); 
    if (x == -1) x = s.length; 
    if (x > 15) return 'too big'; 
    var n = s.split(''); var str = ''; 
    var sk = 0; 
    for (var i=0; i < x; i++) 
    {
        if ((x-i)%3==2) 
        {
            if (n[i] == '1') 
            {
                str += tn[Number(n[i+1])] + ' '; 
                i++; 
                sk=1;
            } 
            else if (n[i]!=0) 
            {
                str += tw[n[i]-2] + ' ';
                sk=1;
            }
        } 
        else if (n[i]!=0) 
        {
            str += dg[n[i]] +' ';
            if ((x-i)%3==0) 
                //str += 'hundred ';
                str += 'ratus ';
                sk=1;
        } 
        if ((x-i)%3==1) 
        {
            if (sk) 
                str += th[(x-i-1)/3] + ' ';
            sk=0;
        }
    } 
    if (x != s.length) 
    {
        var y = s.length; 
        str += 'point '; 
        for (var i=x+1; i<y; i++) 
        str += dg[n[i]] +' ';
    }
    
    var amt= str.replace(/\s+/g,' ');
    amt=amt.replace('satu ratus','seratus');
    amt=amt.replace('satu ribu','seribu');
    amt=amt.replace('satu juta','sejuta');
    //return str.replace(/\s+/g,' ');
    return amt;
    //document.getElementById('TextBox2').value=str.replace(/\s+/g,' ');
    //document.getElementById('TextBox2').value=document.getElementById('TextBox2').value.replace('satu ratus','seratus');
    //document.getElementById('TextBox2').value=document.getElementById('TextBox2').value.replace('satu ribu','seribu');
    return false;
}

function passvalue()
{
    toWords(document.getElementById('TextBox1').value);
    return false;
}

