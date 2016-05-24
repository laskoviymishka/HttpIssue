# HttpIssue

Repository to sample that show strange issue with http client latency.
to run sample do following steps:

1. Clone repository
2. Run `cd src\WebApplication1 & dotnet restore & dotnet run`
3. Run `cd ..\ConsoleApp1\ & dotnet restore & dotnet run`
4. Check how long it takes to make 20 post api requests

To see how it works in classic .net open solution 
There is 2 console project with really same code, but .netcore version take significant longer
