<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="OpenBox.Website.checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<title>Open Box - Checkout</title>

	<link rel="stylesheet" href="/assets/navbar.css">
  <link rel="stylesheet" href="/assets/checkout-page.css">
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
<div class="container wrapper">
   <div class="row cart-body">
      <form class="form-horizontal" method="post" action="">
         <div class="row">
            <!--REVIEW ORDER-->
            <div class="panel panel-info">
               <div class="panel-heading">
                  <span><i class="fa fa-search" aria-hidden="true"></i></span> Review Order
               </div>
               <div class="panel-body">
                  <div class="form-group">
                     <div class="col-sm-3 col-xs-3">
											  <img class="img-responsive" src="<%= offer.imageURL %>" width="100" height="100">
                     </div>
                     <div class="col-sm-6 col-xs-6">
                        <div class="col-xs-12"><%= offer.title %></div>
                        <div class="col-xs-12"><small>Quantity: <span><%= offer.quantity %></span></small></div>
                     </div>
                     <div class="col-sm-3 col-xs-3 text-right">
                        <h6><span>$</span><%= offer.price %></h6>
                     </div>
                  </div>
                  <div class="form-group">
                     <hr />
                  </div>
                  <div class="form-group">
                     <div class="col-xs-12">
                        <strong>Order Total</strong>
                        <div class="pull-right"><span>$</span><span><%= offer.price %></span></div>
                     </div>
                  </div>
               </div>
            </div>
            <!--REVIEW ORDER END-->
         </div>
         <div class="row">
            <!--SHIPPING METHOD-->
            <div class="panel panel-info col-md-6">
							<div class="col-md-12">
               <div class="panel-heading" style="border-bottom: 0.25em solid #0b2532;"><span><i class="fa fa-map-marker" aria-hidden="true"></i></span> Address</div>
               <div class="panel-body">
                  <div class="form-group">
                     <div class="col-md-12">
                        <h4>Shipping Address</h4>
                     </div>
                  </div>
                  <div class="form-group">
                     <div class="col-md-12"><strong>Country:</strong></div>
                     <div class="col-md-12">
                        <input type="text" class="form-control" name="country" value="" />
                     </div>
                  </div>
                  <div class="form-group">
                     <div class="col-md-6 col-xs-12">
                        <strong>First Name:</strong>
                        <input type="text" name="first_name" class="form-control" value="" />
                     </div>
                     <div class="span1"></div>
                     <div class="col-md-6 col-xs-12">
                        <strong>Last Name:</strong>
                        <input type="text" name="last_name" class="form-control" value="" />
                     </div>
                  </div>
                  <div class="form-group">
                     <div class="col-md-12"><strong>Address:</strong></div>
                     <div class="col-md-12">
                        <input type="text" name="address" class="form-control" value="" />
                     </div>
                  </div>
                  <div class="form-group">
                     <div class="col-md-12"><strong>City:</strong></div>
                     <div class="col-md-12">
                        <input type="text" name="city" class="form-control" value="" />
                     </div>
                  </div>
                  <div class="form-group">
                     <div class="col-md-12"><strong>State:</strong></div>
                     <div class="col-md-12">
                        <input type="text" name="state" class="form-control" value="" />
                     </div>
                  </div>
                  <div class="form-group">
                     <div class="col-md-12"><strong>Zip / Postal Code:</strong></div>
                     <div class="col-md-12">
                        <input type="text" name="zip_code" class="form-control" value="" />
                     </div>
                  </div>
                  <div class="form-group">
                     <div class="col-md-12"><strong>Phone Number:</strong></div>
                     <div class="col-md-12"><input type="text" name="phone_number" class="form-control" value="" /></div>
                  </div>
                  <div class="form-group">
                     <div class="col-md-12"><strong>Email Address:</strong></div>
                     <div class="col-md-12"><input type="text" name="email_address" class="form-control" value="" /></div>
                  </div>
									<div class="form-group">
										 <div class="col-md-12"><input type="checkbox" name="vehicle" checked> Billing Address Same as Shipping Address</div>
									</div>
               </div>
						 </div>
            </div>
            <!--SHIPPING METHOD END-->
            <!--CREDIT CART PAYMENT-->
            <div class="panel panel-info col-md-6">
							<div class="col-md-12">
               <div class="panel-heading" style="border-bottom: 0.25em solid #0b2532;"><span><i class="fa fa-lock" aria-hidden="true"></i></span> Secure Payment</div>
               <div class="panel-body">
                  <div class="form-group">
                     <div class="col-md-12"><strong>Card Type:</strong></div>
                     <div class="col-md-12">
                        <select id="CreditCardType" name="CreditCardType" class="form-control">
                           <option value="5">Visa</option>
                           <option value="6">MasterCard</option>
                           <option value="7">American Express</option>
                           <option value="8">Discover</option>
                        </select>
                     </div>
                  </div>
                  <div class="form-group">
                     <div class="col-md-12"><strong>Credit Card Number:</strong></div>
                     <div class="col-md-12"><input type="text" class="form-control" name="car_number" value="" /></div>
                  </div>
                  <div class="form-group">
                     <div class="col-md-12"><strong>Card CVV:</strong></div>
                     <div class="col-md-12"><input type="text" class="form-control" name="car_code" value="" /></div>
                  </div>
                  <div class="form-group">
                     <div class="col-md-12">
                        <strong>Expiration Date</strong>
                     </div>
                     <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <select class="form-control" name="">
                           <option value="">Month</option>
                           <option value="01">01</option>
                           <option value="02">02</option>
                           <option value="03">03</option>
                           <option value="04">04</option>
                           <option value="05">05</option>
                           <option value="06">06</option>
                           <option value="07">07</option>
                           <option value="08">08</option>
                           <option value="09">09</option>
                           <option value="10">10</option>
                           <option value="11">11</option>
                           <option value="12">12</option>
                        </select>
                     </div>
                     <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <select class="form-control" name="">
                           <option value="">Year</option>
                           <option value="2015">2015</option>
                           <option value="2016">2016</option>
                           <option value="2017">2017</option>
                           <option value="2018">2018</option>
                           <option value="2019">2019</option>
                           <option value="2020">2020</option>
                           <option value="2021">2021</option>
                           <option value="2022">2022</option>
                           <option value="2023">2023</option>
                           <option value="2024">2024</option>
                           <option value="2025">2025</option>
                        </select>
                     </div>
                  </div>
                  <div class="form-group">
                     <div class="col-md-12">
                        <span>Pay secure using your credit card.</span>
                     </div>
                     <div class="col-md-12 cards">
													 <i class="visa hand fa fa-cc-visa fa-3x credit-card-active" aria-hidden="true"></i>
													 <i class="mastercard hand fa fa-cc-mastercard fa-3x" aria-hidden="true"></i>
													 <i class="amex hand fa fa-cc-amex fa-3x" aria-hidden="true"></i>
                        <div class="clearfix"></div>
                     </div>
                  </div>
                  <div class="form-group">
                     <div>
                        <button type="submit" class="btn btn-primary btn-submit-fix btn-lg" style="display: block;margin: 0 auto;">Place Order</button>
                     </div>
                  </div>
               </div>
						 </div>
            </div>
            <!--CREDIT CART PAYMENT END-->
         </div>
      </form>
   </div>
   <div class="row cart-footer"></div>
</div>

<footer>
  &copy; Copyright &nbsp &nbsp <span style="font: normal 2em Cookie, Arial, Helvetica, sans-serif;">open<span style="color: #5383d3;">box</span></span>
</footer>

</body>
</html>
