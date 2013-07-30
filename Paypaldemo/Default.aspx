<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="DoDirPay" method="post" runat="server">
			<center><font face="Verdana" color="black" size="2"><b>Create Profile</b></font>
				<table class="api">
					<tr>
					</tr>
					<tr>
						<td class="field">First Name:</td>
						<td><input id="firstName" type="text" maxLength="32" size="30" value="John" name="firstName"
								runat="server"></td>
					</tr>
					<tr>
						<td class="field">Last Name:</td>
						<td><input id="lastName" type="text" maxLength="32" size="30" value="Doe" name="lastName" runat="server"></td>
					</tr>
					<tr>
						<td class="field">Card Type:</td>
						<td><asp:dropdownlist id="creditCardType" Runat="server" AutoPostBack="True">
								<asp:ListItem Selected="True" value="Visa">Visa</asp:ListItem>
								<asp:ListItem value="MasterCard">MasterCard</asp:ListItem>
								<asp:ListItem value="Discover">Discover</asp:ListItem>
								<asp:ListItem value="Amex">American Express</asp:ListItem>
							</asp:dropdownlist></td>
					</tr>
					<tr>
						<td class="field">Card Number:</td>
						<td><input id="creditCardNumber" type="text" maxLength="19" size="19" name="creditCardNumber"
								runat="server"></td>
					</tr>
					<tr>
						<td class="field">Expiration Date:</td>
						<td><select id="expdate_month" name="expdate_month" runat="server">
								<option value="01" selected>01</option>
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
							<select id="expdate_year" name="expdate_year" runat="server">
								<option value="2004">2004</option>
								<option value="2005">2005</option>
								<option value="2006">2006</option>
								<option value="2007">2007</option>
								<option value="2008">2008</option>
								<option value="2009">2009</option>
								<option value="2010">2010</option>
								<option value="2011">2011</option>
								<option value="2012" selected>2012</option>
								<option value="2013">2013</option>
								<option value="2014">2014</option>
								<option value="2015">2015</option>
							</select>
						</td>
					</tr>
					<tr>
						<td class="field">Card Verification Number:</td>
						<td><input id="cvv2Number" type="text" maxLength="4" size="3" value="962" name="cvv2Number"
								runat="server"></td>
					</tr>
					<tr>
						<td align="right"><br>
							<b>Profile Details:</b></td>
						</TD></tr>
					<tr>
						<td class="field">Profile Description:
						</td>
						<td><input id="ProfileDescription" type="text" maxLength="100" size="50" value="Welcome to the world of shipping where you get anything"
								name="ProfileDescription" runat="server"></td>
					</tr>
					<tr>
						<td class="field">Billing Period:</td>
						<td><select id="BillingPeriod" name="period" runat="server">
								<option value="Day">Day</option>
								<option value="Week" selected>Week</option>
								<option value="SemiMonth">SemiMonth</option>
								<option value="Month">Month</option>
								<option value="Year">Year</option>
							</select>
						</td>
					</tr>
					<tr>
						<td class="field">Billing Frequency:
						</td>
						<td><input id="BillingFrequency" type="text" maxLength="100" size="50" value="4" name="BillingFrequency"
								runat="server"></td>
					</tr>
					<tr>
						<td class="field">Total Billing Cycles:</td>
						<td align="left"><input id="totalBillingCycles" type="text" maxLength="100" size="25" name="totalBillingCycles" runat="server"></td>
					</tr>
					<tr>
						<td class="field">Profile Start Date:</td>
						<td align="left"><select id="pDate" name="profileStartDateDay" runat="server">
								<option value="1">01</option>
								<option value="2">02</option>
								<option value="3">03</option>
								<option value="4">04</option>
								<option value="5">05</option>
								<option value="6">06</option>
								<option value="7" selected>07</option>
								<option value="8">08</option>
								<option value="9">09</option>
								<option value="10">10</option>
								<option value="11">11</option>
								<option value="12">12</option>
								<option value="13">13</option>
								<option value="14">14</option>
								<option value="15">15</option>
								<option value="16">16</option>
								<option value="17">17</option>
								<option value="18">18</option>
								<option value="19">19</option>
								<option value="20">20</option>
								<option value="21">21</option>
								<option value="22">22</option>
								<option value="23">23</option>
								<option value="24">24</option>
								<option value="25">25</option>
								<option value="26">26</option>
								<option value="27">27</option>
								<option value="28">28</option>
								<option value="29">29</option>
								<option value="30">30</option>
								<option value="31">31</option>
							</select>
							<select id="pMonth" name="profileStartDateMonth" runat="server">
								<option value="1" selected>01</option>
								<option value="2">02</option>
								<option value="3">03</option>
								<option value="4">04</option>
								<option value="5">05</option>
								<option value="6">06</option>
								<option value="7">07</option>
								<option value="8">08</option>
								<option value="9">09</option>
								<option value="10">10</option>
								<option value="11">11</option>
								<option value="12">12</option>
							</select>
							<select id="pYear" name="profileStartDateYear" runat="server">
								<option value="2009">2009</option>
								<option value="2010" selected>2010</option>
								<option value="2011">2011</option>
								<option value="2012">2012</option>
								<option value="2013">2013</option>
								<option value="2014">2014</option>
								<option value="2015">2015</option>
								<option value="2016">2016</option>
								<option value="2017">2017</option>
							</select>
						</td>
					</tr>
					<tr>
						<td align="right"><br>
							<b>Billing Address:</b></td>
						</TD></tr>
					<tr>
						<td class="field">Address 1:
						</td>
						<td><input id="address1" type="text" maxLength="100" size="25" value="123 Fake St" name="address1"
								runat="server"></td>
					</tr>
					<tr>
						<td class="field">Address 2:
						</td>
						<td><input id="address2" type="text" maxLength="100" size="25" name="address2" runat="server">"(optional)"</td>
					</tr>
					<tr>
						<td class="field">City:
						</td>
						<td><input id="city" type="text" maxLength="40" size="25" value="Omaha" name="city" runat="server"></td>
					</tr>
					<tr>
						<td class="field">State:
						</td>
						<td><select id="state" name="state" runat="server">
								<option></option>
								<option value="AK">AK</option>
								<option value="AL">AL</option>
								<option value="AR">AR</option>
								<option value="AZ">AZ</option>
								<option value="CA">CA</option>
								<option value="CO">CO</option>
								<option value="CT">CT</option>
								<option value="DC">DC</option>
								<option value="DE">DE</option>
								<option value="FL">FL</option>
								<option value="GA">GA</option>
								<option value="HI">HI</option>
								<option value="IA">IA</option>
								<option value="ID">ID</option>
								<option value="IL">IL</option>
								<option value="IN">IN</option>
								<option value="KS">KS</option>
								<option value="KY">KY</option>
								<option value="LA">LA</option>
								<option value="MA">MA</option>
								<option value="MD">MD</option>
								<option value="ME">ME</option>
								<option value="MI">MI</option>
								<option value="MN">MN</option>
								<option value="MO">MO</option>
								<option value="MS">MS</option>
								<option value="MT">MT</option>
								<option value="NC">NC</option>
								<option value="ND">ND</option>
								<option value="NE" selected>NE</option>
								<option value="NH">NH</option>
								<option value="NJ">NJ</option>
								<option value="NM">NM</option>
								<option value="NV">NV</option>
								<option value="NY">NY</option>
								<option value="OH">OH</option>
								<option value="OK">OK</option>
								<option value="OR">OR</option>
								<option value="PA">PA</option>
								<option value="RI">RI</option>
								<option value="SC">SC</option>
								<option value="SD">SD</option>
								<option value="TN">TN</option>
								<option value="TX">TX</option>
								<option value="UT">UT</option>
								<option value="VA">VA</option>
								<option value="VT">VT</option>
								<option value="WA">WA</option>
								<option value="WI">WI</option>
								<option value="WV">WV</option>
								<option value="WY">WY</option>
								<option value="AA">AA</option>
								<option value="AE">AE</option>
								<option value="AP">AP</option>
								<option value="AS">AS</option>
								<option value="FM">FM</option>
								<option value="GU">GU</option>
								<option value="MH">MH</option>
								<option value="MP">MP</option>
								<option value="PR">PR</option>
								<option value="PW">PW</option>
								<option value="VI">VI</option>
							</select>
						</td>
					</tr>
					<tr>
						<td class="field">ZIP Code:
						</td>
						<td><input id="zip" type="text" maxLength="10" size="10" value="68104" name="zip" runat="server">(5 
							or 9 digits)
						</td>
					</tr>
					<tr>
						<td class="field">Country:
						</td>
						<td>United States
						</td>
					</tr>
					<tr>
						<td class="field">Amount:</td>
						<td><input id="amount" type="text" maxLength="7" size="4" value="1.00" name="amount" runat="server">
							<select id="currency" name="currency" runat="server">
								<option value="USD" selected>USD</option>
							</select>
						</td>
					</tr>
					<tr>
						<td>
						
					</tr>
					<tr>
						<td class="field"></td>
						<td><asp:button id="PayButton" runat="server" Text="Submit" 
                                onclick="PayButton_Click1"></asp:button></td>
					</tr>
				</table>
			</center>
			<A class="home" id="CallsLink" href="RecurringPayments.aspx">Recurring Payments HomeRecurring Payments Home</A>
		</form>
</body>
</html>

