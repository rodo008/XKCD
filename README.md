# XKCD

1-The solution is segmented on 5 subproject:

a) Application: This project encapsuling only class around the app with common functions like as Response Class (It is used for return response from service to controller) and GeneralSettins( store app settings information from the json file settings)

B) Domain: This project keep the binary class (POCO) equivalent from json response in the remote site https://xkcd.com/info.0.json. This class is wrapper json from remote URL

C) Service: In this project It wrapper the remote url of XKCD exposing two methods that getting today's Comic info and specific Comic info. Here we do using the json response for serialization to WebComic binary class and use her as Model between the View and controller.

D) UnitTestProject: Keep the solution test of the class methods

E) Web : Its a simple MVC project built with asp net core. In this We used ViewComponents to show the UI screen using like as model the WebComic Class located in Domain Project.

The WebComicService class is persisted into controller scoped per request. This config is placed in the Startup.cs file.
  services.AddTransient<WebComicService>(); more info here: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1 on Service lifetimes Section.
  
  NOTE: The provided Urls were placed in appsettings.json file.
  
  best regards!
