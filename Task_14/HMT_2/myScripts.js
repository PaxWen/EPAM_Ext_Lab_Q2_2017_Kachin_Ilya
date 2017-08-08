var maches = ['+','-','*','/','='];
function Calculate(sentence){
	var result = 0.0;
	var operation = '';
	var number = "";
	sentence = deleteSpace(sentence);
	alert(sentence);
	for(var i = 0;i<sentence.length;i++){
		if (maches.indexOf(sentence[i])==-1){
			number+=sentence[i];
		}else{
			switch (operation){
				case '+':
					result+=Number(number);
					break;
				case '-':
					result-=Number(number);
					break;
				case '*':
					result*=Number(number);
					break;
				case '/':
					result/=Number(number);
					break;
				case '':
					result=Number(number);
					break;
			}
			number="";
			operation = sentence[i];
		}
	}
	return result.toFixed(2);
}

function deleteSpace(sentence)
{
	var i = 0;
	while (i < sentence.length)
	{
		if (sentence[i]==" ")
		{
			sentence=sentence.substring(0,i)+sentence.substring(i+1,sentence.length);
		}else{
			i++;
		}
	}
	return sentence;
}