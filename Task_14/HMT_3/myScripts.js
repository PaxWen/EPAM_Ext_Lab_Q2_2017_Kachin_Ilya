var mainForm;
var select1;
var select2;
function shuffling(mForm,fLeftBut,leftBut1,rightBut1,fRightBut)
{
	mainForm = mForm
	select1 = mainForm.elements.mySelectId1;
	select2 = mainForm.elements.mySelectId2;
	
	var fullLeftBut = fLeftBut;
	var leftBut = leftBut1;
	var rightBut = rightBut1;
	var fullRightBut = fRightBut;
	
	fullLeftBut.onclick = function() {
      if (select2.options.length == 0)
	  {
		alert("Объектов нет");
	  }else{
		while(select2.options.length >0)
		{
		  select1.appendChild(select2[select2.options.length-1]);
		}
	  }
	  checkButton(fLeftBut,leftBut1,rightBut1,fRightBut);
    }
	
	leftBut.onclick = function() {
		if(select2.selectedIndex == -1)
		{
			alert("Элемент не выделен!");
		}else{
		 var i = 0;
		 while (i<select2.options.length){
			  if(select2.options[i].selected) {
				select1.appendChild(select2[i]);
			  }else{
				  i++;
			  }
		  }
		}
		checkButton(fLeftBut,leftBut1,rightBut1,fRightBut);
    }
	
	rightBut.onclick = function() {
		if(select1.selectedIndex == -1)
		{
			alert("Элемент не выделен!");
		}else{
		  var i = 0;
		 while (i<select1.options.length){
			  if(select1.options[i].selected) {
				select2.appendChild(select1[i]);
			  }else{
				  i++;
			  }
		  }
		}
		checkButton(fLeftBut,leftBut1,rightBut1,fRightBut);
    }
	
	fullRightBut.onclick = function() {
      if (select1.options.length == 0)
	  {
		alert("Объектов нет");
	  }else{
		while(select1.options.length >0)
		{
		  select2.appendChild(select1[select1.options.length-1]);
		}
	  }
	  checkButton(fLeftBut,leftBut1,rightBut1,fRightBut);
    }
	
}

function checkButton(fLeft,left,right,fRight)
{
	if (select2.options.length == 0)
	{
		
		fLeft.disabled = true;
		left.disabled = true;
	}else{
		fLeft.disabled = false;
		left.disabled = false;
	}
	if (select1.options.length == 0)
	{
		fRight.disabled = true;
		right.disabled = true;
	}else{
		fRight.disabled = false;
		right.disabled = false;
	}
	
	
	if(select2.selectedIndex == -1)
	{
		
	}
}