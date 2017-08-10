
function goToPage(url)
{
	document.location.href = url;
}
var timer;
var timerClock;
var timeDiv;
var time
function journey(backBut,startBut,stopBut,forwardBut,backURL,forwardURL,timeNextPage,timePanel)
{
	var backButton = backBut;
    var startButton = startBut;
	var stopButton = stopBut;
	var forwardButton = forwardBut;
	timeDiv = timePanel;
	startButton.disabled = true;
	time = timeNextPage;
	startTimer(forwardURL);
	
	stopButton.onclick = function() {
      startButton.disabled = false;
      stopButton.disabled = true;
	  stopTimer();
    }
	startButton.onclick = function() {
      startButton.disabled = true;
      stopButton.disabled = false;
	  
	startTimer(forwardURL);
	}
	backButton.onclick = function() {
      goToPage(backURL);
	}
	forwardButton.onclick = function() {
      goToPage(forwardURL);
	}
	
}

function startTimer(nextPageURL)
{
	timer = setTimeout(function() {
	goToPage(nextPageURL);
	}, time);
	timerClock = setInterval(function(){
		refreshClock();
	},20);
}

function stopTimer()
{
	clearTimeout(timer);
	clearInterval(timerClock);
}

function refreshClock()
{
	time-=20;
	timeDiv.innerHTML = Math.floor(time/1000)+":"+Math.floor(time%1000);
}

function lastPage(firstPageURL)
{
	var result = confirm ("Повторить? ");
	if(result)
	{
		goToPage(firstPageURL);
	}else{
		window.close();
	}
}
