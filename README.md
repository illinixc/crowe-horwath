# hello world

sample hello world app

### Note
As I dont currently have a Windows machine, this was my first attempt at using 
the .Net App Core on a Mac. Unity and Ninject aren't currently compatible. Since using configuration file
was in the requirements, I would probably have used Unity for the appSettings type binding. I realize writing the
Assembly Full Name in the appsettings.json is just asking for a runtime error. This implemention allows for
binding a single writer. If multiple writers is required then it would be a different pattern, such as chain of 
responsibility with a collection of writers, each one responsible for determining if it was able to handle a given Writer request
