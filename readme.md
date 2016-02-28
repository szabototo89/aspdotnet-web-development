ASP.NET MVC web development
---------------------------

# Agenda


1. Introduction to Entity Framework
  - **Code-First**, **Database-First** and **Model-First** approach
  - **Code-First**:
    -  Implement **Data Transfer Objects** as pure **C#** classes
    -  Implement a **DbContext** class which represents current database
    -  Specify constraints on properties with Data Annotations and Fluent API
    -  Show a use case when multiple DbContext implementations are used (eg. same data model, but different database scheme)
2. Introduction to ASP.NET MVC - Part 1
  - *Hello World application* in ASP.NET MVC
  - Architecture patterns: **Model-View**, **Model-View-View Model**, **Model-View-Controller** and **Flux**
  - General information about project: project structure, configurations and Global.asax (routing etc.)
  - Introduction to Razor engine (expressions, **@foreach**, **@if**, **@model ** etc.)
  - Passing models to view via controllers
3. Introduction to ASP.NET MVC - Part 2
  - Multiple actions in controllers and multiple views
  - Navigating between views (**ActionLinks**)
  - **HTML Helpers** in ASP.NET MVC
  - View Models and Models
  - Basic HTTP protocol actions: **GET**, **POST**, **PUT** and **DELETE**
  - Submitting data back to controllers
  - **Controller factory**