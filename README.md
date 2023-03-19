# EntryProject_TUFAPI

<p>This is a Rest Web API built with .net6 core
The goal of this API was fulfill the criteria of Gambit challenge at:
https://github.com/gambit-labs/challenge Criterias were to have a Rest API that parses TUF-200M devices register date sent to text file at:
http://tuftuf.gambitlabs.fi/feed.txt This data is to be converted to a human readable format based on the actual values defined by TUF devices manual
at https://github.com/gambit-labs/challenge/blob/master/docs/tuf-2000m.pdf
and returned back to the user as in a json format, with authentication included. </p>


<p>For now this project has been deployed to Azure at: https://entryprojecttufapi.azurewebsites.net/swagger/index.html</p>
<p>To test this, you can go to the above azurewebsites link, hit login tab and try it out on the right. Then in the opened up request body text box,
change the "string" for username to either "albert_admin" or "johndoe_standard". Both will work to return a key, but only albert_admin has
authorization access to get result from TUFAPI's get request. The password string for both is the same: "MyTempPa55_W0rd". Once you have entered
these, hit execute and you will receive a response with the key. copy that key for yourself without the "" symbols on each end.</p>

<p>Now you have the authorization key, now you can either authorize yourself in the Swagger ui with green authorize button on top right, enter your key into the
small window that opens, click authorize and close that small window. You can now go to TUFAPI get request, try it out and execute, which will give you the json
formatted tuf device data with converted values.</p>

<p>Alternatively, for the next 15 mins your key is active, you can go to an api tester
website such as: https://reqbin.com/ https://extendsclass.com/rest-client-online.html or https://resttesttest.com/</p>
<p>In the above api testers, you can send a get request to: https://entryprojecttufapi.azurewebsites.net/api and send your key either in bearer token if
tester has the option, or in header with name: Authorization and value: Bearer InsertYourKeyHereAfterBearer</p>
