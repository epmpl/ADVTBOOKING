// JScript File

// JScript File
var boola=false;
		var a
		var b
		function abc3(t,e)
		{
		//alert('danish');
		//alert(t.id);
		//alert(t.style.width);
		//t.style.width=parseInt(t.style.width.replace('px',''))+50;
		if(e.button== 2)
		{
		boola=true
		t.style.cursor="w-resize";
		a=e.x
		}
		}
		function abc2(t,e)
		{
		//alert('danish');
		//alert(t.id);
		//alert(t.style.width);
		if(boola==true)
		{
		    var z=parseInt(e.x)-parseInt(a)
		    if(parseInt(t.style.width.replace('px',''))+z<10)
		    {
		        t.style.width=10;
		    }
		    else
		        t.style.width=parseInt(t.style.width.replace('px',''))+z;
		    a=e.x
		 }
		}
		function abc1(t,e)
		{
		//alert('danish');
		boola=false;
		t.style.cursor="w-resize";
		}

