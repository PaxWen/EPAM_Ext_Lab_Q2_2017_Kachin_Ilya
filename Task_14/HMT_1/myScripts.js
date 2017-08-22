function deleteUselles(sentence)
{
	var i = 0;
	var word = "";
	var matches = ['?',',',' ',';'];//todo pn ты учел не все символы разделители: ?!:;,.
	var letterForDelete = [];
	sentence+=" ";
	while (i < sentence.length)
	{
		if (matches.indexOf(sentence[i])==-1){
			word+=sentence[i];
		}else{
			for	(var j = 0;j<word.length;j++){
				if (letterForDelete.indexOf(word[j])==-1 && repetedLetter(word,word[j]))
				{
					letterForDelete.push(word[j]);
				}
			}		
			word="";
		}
		i++;
	}
	for(var i = 0;i<letterForDelete.length;i++){
		sentence = deleteLetter(sentence,letterForDelete[i]);
	}
	return sentence;
}

function repetedLetter(word,letter)
{
	var k = 0;
	for(var i = 0;i<word.length;i++){
		if (word[i]===letter){
			k++;
		}
	}
	return k>1;	
}

function deleteLetter(sentence,letter)
{
	var i = 0;
	while (i < sentence.length)
	{
		if (sentence[i]==letter)
		{
			sentence=sentence.substring(0,i)+sentence.substring(i+1,sentence.length);
		}else{
			i++;
		}
	}
	return sentence;
}

var j = i+1;
		while (j < sentence.length)
		{
			if (sentence[i]==sentence[j] & sentence[i]!=" ")
			{
				sentence = deleteLetter(sentence,sentence[i]);
				i--;
				break;
			}else{
				j++;
			}
		}
		i++;