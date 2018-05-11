# ElectronicColorCode
Web Application that calculates the resistor value based on the electronic color code. This uses the .NET MVC framework.

<h3>To use:</h3>
<p>Download code from https://github.com/annstephen/ElectronicColorCode</p>
<p>Open ElectronicColorCode.sln in visual studio.</p>
<p>Run the code from Visual Studio - IIS Express(Google Chrome).</p>

<h3>UI - Built for Google Chrome</h3>
<p>
The UI consists of 4 drop down menus. </p>
<p>These designate selection options for the 1st(Band 1) and 2nd(Band 2) significant figures, multipliers and the tolerance.</p>
<p>To calculate the value the user is required select an option for band 1, band 2 and the multiplier. </p>
<p>The tolerance defaults to None (20%).</p>
<p>Once all selections are made, user can use the calculate button to calculate the resistance value, upper and lower bounds.</p>
<p>This webpage was built and tested on Google Chrome (Version 66.0.3359.139). The drop down menu might not be fully supported on other browsers.</p>

<h3>Calculation:</h3>
<p>The Electronic Color Coding logic is based on IEC 60062:2016 as given on https://en.wikipedia.org/wiki/Electronic_color_code.</p>
The color code is as follows:

<table>Significant Figures:

<tr><td>Black</td>  <td>0</td></tr>
<tr><td>Brown</td> <td>1</td></tr>
<tr><td>Red</td>    <td>2</td></tr>
<tr><td>Orange</td> <td>3</td></tr>
<tr><td>Yellow</td> <td>4</td></tr>
<tr><td>Green</td>  <td>5</td></tr>
<tr><td>Blue</td>   <td>6</td></tr>
<tr><td>Violet</td> <td>7</td></tr>
<tr><td>Gray</td>   <td>8</td></tr>
<tr><td>White</td>  <td>9</td></tr>
</table>

<table>Multipliers:

<tr><td>Pink</td>  <td>0.001</td></tr>
<tr><td>Silver</td>  <td>0.01</td></tr>
<tr><td>Gold</td>  <td>0.1</td></tr>
<tr><td>Black</td>  <td>1</td></tr>
<tr><td>Brown</td>  <td>10</td></tr>
<tr><td>Red</td>  <td>100</td></tr>
<tr><td>Orange</td>  <td>1000</td></tr>
<tr><td>Yellow</td>  <td>10,000</td></tr>
<tr><td>Green</td>  <td>100,000</td></tr>
<tr><td>Blue</td>  <td>1,000,000</td></tr>
<tr><td>Violet</td>  <td>10,000,000</td></tr>
<tr><td>Gray</td>  <td>100,000,000</td></tr>
<tr><td>White</td>  <td>1,000,000,000</td></tr>
</table>

<table>Tolerance:
<tr><td>None</td>  <td>20%</td></tr>
<tr><td>Silver</td>  <td>10%</td></tr>
<tr><td>Gold</td>  <td>5%</td></tr>
<tr><td>Brown</td>  <td>1%</td></tr>
<tr><td>Red</td>  <td>2%</td></tr>
<tr><td>Green</td>  <td>0.5%</td></tr>
<tr><td>Blue</td>  <td>0.25%</td></tr>
<tr><td>Violet</td>  <td> 0.1%</td></tr>
<tr><td>Gray </td>  <td>0.05%</td></tr></table>
