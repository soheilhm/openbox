<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="OpenBox.Website.details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<title>Open Box - Offer Details</title>

	<link rel="stylesheet" href="/assets/navbar.css">
  <link rel="stylesheet" href="/assets/details-page.css">
	<link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css" rel="stylesheet" integrity="sha384-T8Gy5hrqNKT+hzMclPo118YTQO6cYprQmhrYwIiQ/3axmI1hQomh7Ud2hPOy8SP1" crossorigin="anonymous">
  <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
	<link href='http://fonts.googleapis.com/css?family=Cookie' rel='stylesheet' type='text/css'>

  <script type="text/javascript" src="/assets/script.js" async></script>
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

<div class="container" style="margin-bottom:5%;">
	<div class="product-info-area row">
		<h2 class="product-title"><%= offer.displayTitle %></h2>
		<div class="col-md-6 product-image">
			<img src="<%= offer.product.imageURL %>" height="450" width="450">
		</div>
		<div class="col-md-6 product-description-container">
			<h4 class="product-id"><%= offer.product.sku %></h4>
			<p class="product-description"><%= offer.product.details %></p>
			<p class="product-price"> $ <%= offer.price %></p>
			<a href="/checkout.aspx?id=<%= offer.returnDetailId %>"><button type="button" class="btn btn-lg btn-primary">Checkout</button></a>
		</div>
	</div>
</div>


<footer style="right: 0;left: 0;position: fixed;bottom: 0;">
  &copy; Copyright &nbsp &nbsp<span>open<span>box</span></span>
</footer>

</body>
</html>
