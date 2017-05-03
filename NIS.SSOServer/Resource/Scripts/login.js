var modelStr = document.getElementById("loginViewModel").innerHTML;
var model = JSON.parse(modelStr);
document.forms[0].attributes["action"].value = model.LoginUrl;
var antiInput = document.getElementById("anti");
antiInput.attributes["name"].value = model.AntiForgery.Name;
antiInput.value = model.AntiForgery.Value;
alert('t');