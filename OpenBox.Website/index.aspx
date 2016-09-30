<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="OpenBox.Website.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<title>Open Box</title>

	<link rel="stylesheet" href="/assets/navbar.css">
  <link rel="stylesheet" href="/assets/content-list.css">
	<link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-T8Gy5hrqNKT+hzMclPo118YTQO6cYprQmhrYwIiQ/3axmI1hQomh7Ud2hPOy8SP1" crossorigin="anonymous">
  <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
	<link href='http://fonts.googleapis.com/css?family=Cookie' rel='stylesheet' type='text/css'>
	<link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.9/themes/base/jquery-ui.css" type="text/css" media="all" />

  <script type="text/javascript" src="/assets/script.js" async></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
	<script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.9/jquery-ui.min.js"></script>
</head>
<body>
<header class="header-basic-light">
	<div class="header-limiter">
		<h1><a href="#">open<span>box</span></a></h1>
		<nav>
			<a href="#">About Us</a>
			<a href="#">Contact Us</a>
			<a href="#" class="selected">My Account</a>
		</nav>
	</div>
</header>

<div class="row">
  <div class="container search-form" style="width: 25%;box-shadow: 0.5em 0.5em 4.5em #0b2532;padding-bottom: 2em;border-radius: 1.5em;">
			<div class="form-group" style="margin: 0 auto;display: block;">
			 <label for="stateSelect"></label>
			 <select class="form-control" id="stateSelect">
				<option value="N/A">Select State:</option>
				<option value="AL">Alabama</option>
			 	<option value="AK">Alaska</option>
			 	<option value="AZ">Arizona</option>
			 	<option value="AR">Arkansas</option>
			 	<option value="CA">California</option>
			 	<option value="CO">Colorado</option>
			 	<option value="CT">Connecticut</option>
			 	<option value="DE">Delaware</option>
			 	<option value="DC">District Of Columbia</option>
			 	<option value="FL">Florida</option>
			 	<option value="GA">Georgia</option>
			 	<option value="HI">Hawaii</option>
			 	<option value="ID">Idaho</option>
			 	<option value="IL">Illinois</option>
			 	<option value="IN">Indiana</option>
			 	<option value="IA">Iowa</option>
			 	<option value="KS">Kansas</option>
			 	<option value="KY">Kentucky</option>
			 	<option value="LA">Louisiana</option>
			 	<option value="ME">Maine</option>
			 	<option value="MD">Maryland</option>
			 	<option value="MA">Massachusetts</option>
			 	<option value="MI">Michigan</option>
			 	<option value="MN">Minnesota</option>
			 	<option value="MS">Mississippi</option>
			 	<option value="MO">Missouri</option>
			 	<option value="MT">Montana</option>
			 	<option value="NE">Nebraska</option>
			 	<option value="NV">Nevada</option>
			 	<option value="NH">New Hampshire</option>
			 	<option value="NJ">New Jersey</option>
			 	<option value="NM">New Mexico</option>
			 	<option value="NY">New York</option>
			 	<option value="NC">North Carolina</option>
			 	<option value="ND">North Dakota</option>
			 	<option value="OH">Ohio</option>
			 	<option value="OK">Oklahoma</option>
			 	<option value="OR">Oregon</option>
			 	<option value="PA">Pennsylvania</option>
			 	<option value="RI">Rhode Island</option>
			 	<option value="SC">South Carolina</option>
			 	<option value="SD">South Dakota</option>
			 	<option value="TN">Tennessee</option>
			 	<option value="TX">Texas</option>
			 	<option value="UT">Utah</option>
			 	<option value="VT">Vermont</option>
			 	<option value="VA">Virginia</option>
			 	<option value="WA">Washington</option>
			 	<option value="WV">West Virginia</option>
			 	<option value="WI">Wisconsin</option>
			 	<option value="WY">Wyoming</option>
			 </select>
			</div>
			<div class="price-search">
				<input type="number" class="search-query form-control" id="price-min-input" placeholder="Min Price:"  style="margin: 0 auto;display: block;"/>
				<input type="number" class="search-query form-control" id="price-max-input" placeholder="Max Price:" style="margin: 0 auto;display: block;"/>
			</div>
      <div id="custom-search-input" style="margin: 0 auto;display: block;">
         <div class="input-group">
					  <!-- <input type="number" class="search-query form-control" placeholder="Min Price:" />
						<input type="number" class="search-query form-control" placeholder="Max Price:" /> -->
            <input type="text" class="search-query form-control" id="keyword-input" placeholder="Keyword:" />
            <span  class="input-group-btn">
              <button class="btn btn-primary " id="search-button" type="button">
              	<span class=" glyphicon glyphicon-search"></span>
              </button>
            </span>
         </div>
      </div>
      <script>
				$("#search-button").click(function(){
					let keyword = $('#keyword-input').val();
					let priceMin = $('#price-min-input').val();
					let priceMax = $('#price-max-input').val();
					let state = $("#stateSelect").val();
					//let searchQuery = {keyword,priceMin,priceMax,state};
					console.log(state);
					if (state == "N/A") { $("#content-list-container").empty(); $("#content-list-container").append("<div><h2>Please Select a State to begin...</h2></div>"); return }

					if (priceMin == "") { priceMin = null; }
					if (priceMax == "") { priceMax = null; }

					var request = JSON.stringify({ location: state, tags: keyword, priceMin: priceMin, priceMax: priceMax });
					var response = {};
					var isAsync = true;

					$.ajax({
					    type: "POST",
					    url: "/PageService.svc/Offers_Search",
					    data: request,
					    contentType: "application/json; charset=utf-8",
					    dataType: "json",
					    async: isAsync,
					    success: function (msg) {
					        var products = JSON.parse(msg.d);
					        $("#content-list-container").empty();

					        console.log(products);

					        if (!products || products.length == 0) {
					            $("#content-list-container").append("<div><h2>No Result Found.</h2></div>");
					        }
					        else {
					            for (var i = 0, length = products.length; i < length; i++) {

					                // if(products[i].title.toLowerCase().indexOf(keyword.toLowerCase()) !== -1 ) {
					                // 	keyword products[i].title
					                // }	else {
					                // 	alert('Please enter a search word');
					                // }
					                $("#content-list-container").append(` <div class="product-info-container col-md-4">
																						        <div class ="poduct-image"><a href=${products[i].URL}><img src=${products[i].imageURL} height="200" width="200"></a></div>
																						        <div class ="poduct-description"><p>${products[i].displayTitle}</p></div>
																						        <div class="product-price"><p>${products[i].price}</p></div>
																					        </div>`);
					            }
					        }
					    },
					    error: function (xhr) {
					        response.html = "";
					        response.error = true;
					        console.log(xhr.statusText);
					    },
					    complete: function () {
					        if (isAsync) {
					            if (typeof callback == "function")
					                callback(response);
					        }
					    }
					});

					 //console.log(request);
				});
			</script>
  </div>
  <div class="container content-list">
    <div class="row" id="content-list-container">
        <h2>Please Start Searching...</h2>
    </div>
  </div>
  <!-- <ul class="pagination">
    <li><a href="#">«</a></li>
    <li><a class="active" href="#">1</a></li>
    <li><a href="#">2</a></li>
    <li><a href="#">3</a></li>
    <li><a href="#">4</a></li>
    <li><a href="#">5</a></li>
    <li><a href="#">6</a></li>
    <li><a href="#">»</a></li>
  </ul> -->
</div>

<footer style="right: 0;left: 0;bottom: 0;position: fixed;">
  &copy; Copyright &nbsp &nbsp <span style="font: normal 2em Cookie, Arial, Helvetica, sans-serif;">open<span style="color: #5383d3;">box</span></span>
</footer>

    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">


    </script>

</body>
</html>
