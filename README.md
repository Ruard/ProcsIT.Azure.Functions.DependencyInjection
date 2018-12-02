# ProcsIT.Azure.Functions.DependencyInjection
Azure functions using Microsoft.Extensions.DependencyInjection. Including ILogger and ILogger&lt;T>

This project shows how ILogger<T> from referenced service can log to the function. The approach is based on the [AutofacOnFunctions project](https://github.com/holgerleichsenring/AutofacOnFunctions) of Holger Leichsenring. The main difference is that for this project Autofac isn't used and ILogger&lt;T> is implemented. The project contains the Dependency Injection library and a basic sample function to show how to implement it.

Please note that this project is only meant as an example. It is not fully tested among different scenarios.

Remarks:
 - The project containing the WebJobsExtensionStartup class needs to target netstandard2.0. Otherwise the Startup is ignored.
 - ILogger is for the function only. Ilogger is not injected in referenced services. Use ILogger&lt;T> for those services.
