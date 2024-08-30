mergeInto(LibraryManager.library, {
	Hello: function () {
    window.alert("Hello, world!");
	console.log("hello world");
  },
    RateGame: function () {
		ysdk.feedback.canReview()
			.then(({ value, reason }) => {
				if (value) {
					ysdk.feedback.requestReview()
						.then(({ feedbackSent }) => {
							console.log(feedbackSent);
						})
				} else {
					console.log(reason)
				}
			})
  },
  	SaveExtern: function (data) {
		var dateString = UTF8ToString(data);
		var myObj = JSON.parse(dateString);
		console.log("save progress " + myObj);
		player.setData(myObj);
  },
  	LoadExtern: function () {
		player.getData()
		.then(data=>{
			const myJSON = JSON.stringify(data);
			console.log("Load progress in yaJsLib ", myJSON);
			MyGameInstance.SendMessage("Progress", "LoadProgress", myJSON);
		})
  },
});