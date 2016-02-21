# Introduction to ASP.NET MVC framework

## 1. Architecture patterns

- Model-View
- Model-View-View Model
- Model-View-Controller
- Flux

## 2. Create a new ASP.NET MVC project (example)

**Usage**: How to create a new ASP.NET MVC project in Visual Studio. 

## 3. Implement a Hello World application (example)

Use cases:
  - Create a new controller (Home) without any view
  - Create a new view (static html page)
  - Pass any data from controller (eg. just a string)
  - How to evaluate expressions, control flows etc:
    - *@Model*, *@ViewBag*
    - *@if*, *@foreach* ...
    - expressions: @(index + 1) etc.

## 4. Project structure

**Main folders**: *Views*, *Models*, and *Controllers*. 
**Configuration files**: *web.config* (in Views and project), *RouteConfig* class, *Global.asax*.

 ## +1. Difference between object, var and dynamic keywords