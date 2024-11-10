


//var  : when the variable has to be globlly accesable 
//let : when the variable is limited to the block execution
//const : use it for variable which doesnt change any value in the application 


// const cars = ["Volvo","BMW","Audi"]

// const para = document.getElementById("DemoJS");
//     para.innerHTML = cars[2];

//hjghfhg
// console.log("Hello, this in in Console log")
$(document).ready(function(){
    $("#get").click(function(){
        $.get("https://localhost:7135/api/v1.0/Product",function(data,status){
            console.log(JSON.stringify(data));
            alert(status);     
        });

    });
    var settings = {
        "url": "https://localhost:7135/api/v1.0/Product",
        "method": "POST",
        "timeout": 0,
        "headers": {
          "Content-Type": "application/json"
        },
        "data": JSON.stringify({
          "name": "Mouse",
          "price": 1000
        }),
    };
      
    $("#post").click(function(){
        $.post(settings,function (response,status) {
            console.log(response);
            alert(status);
          });
      }); 
    
    var putsettings = {
        "url": "https://localhost:7135/api/v1.0/Product/1",
        "method": "Put",
        "timeout": 0,
        "headers": {
          "Content-Type": "application/json"
        },
        "data": JSON.stringify({
          "id": 1,
          "name": "Laptop",
          "price": 200
        }),
    };

    $("#put").click(function(){
        $.ajax(putsettings).done(function (response,status) {
            console.log(response);
            alert(status);
          });
    });

    var deletesettings = {
        "url": "https://localhost:7135/api/v1.0/Product/1",
        "method": "DELETE",
        "timeout": 0,
    };

    $("#delete").click(function(){
          $.ajax(deletesettings).done(function (response,status) {
            alert(status);
            console.log(response);
          });
    });

    $("#get1").click(function(){
        $.get("https://localhost:7135/api/v1.0/Product/2",function(data,status){
            console.log(JSON.stringify(data));
            alert(status);     
        });

    });
}); 
