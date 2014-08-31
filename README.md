FluentArchitecture
==================

by TBAPI-0KA

About
-----

FluentArchitecture is "framework-over-framework" for ASP .NET MVC and WebAPI. However, some of its parts could be used in any .NET application. Whilst MVC and WebAPI themselves propose modular architecture and backbone for all the others, FluentArchitecture inspire the soul into this backbone by implementing best practices and bindings to the most useful libraries.

FluentArchitecture even propose a way how well-structured app should be built. But, a lot of its components could be used independently from the others.

FluentArchitecture consists from two conceptually different parts. They almost are not visible, however.

First is responsible for architectural aspects, and brings up generics, fluent interfaces and builders, dependency injection, unit testing to the top of development concepts. Mostly, its just a syntax sugar, but very powerful.

Second part is much closer to "library" concept than to "framework". Its set of reusable components for everyday web development. How much times did you download encryption library, but was forced to write a lot of code to encode your passwords? Social login? Object-to-object mapper? Validation? With FluentArchitecture most of those tasks becomes one to three lines of code.

FluentArchitecture uses Semantic Versioning.

History
-------

Idea of this framework lives in my mind for over than three years. Whilst a lot of components I want to implement are simple, some of them, such as Security, are really, REALLY complicated. I can not even understand the whole concept at once inside my mind. I need to take a list of paper, split it in three parts, and design every part separately.

So, it was complicated to even start. But, some code already exists in a bunch of projects I am working on. And I am tired to copy it from project to project all the time. One beautiful day I decide to clean up at least what I already have and put it in separate set of assemblies. Will see how it will go.

Production
----------

Is it ready to production? Well, right now there is almost nothing to use. Personally I use this in "copy-paste" form in almost all my projects. I will publish NuGet packages as soon as at least all the code I already have will be moved to FluentArchitecture.

Components
----------

There is not a lot of documentation. Please refer to the Demo project sources, it shows everything very well.

Web Infrastructure
------------------

Enables IoC-augmented Tasks for HttpApplication events. To be short - look at the Global.asax.cs files of Demo project. I am trying to avoid references to IoC library implementation and have some ideas how to do that. Right now, only Autofac is supported.

Data Access
-----------

Simply, Unit of Work pattern with unit testing ability. Entity Framework supported for now.

Cryptography
------------

TBD

HTML Sanitization
-----------------

TBD

Validation
----------

TBD

Remote validation
-----------------

TBD

Security
--------

TBD

Social login
------------

TBD

Mapper
------

TBD

Fluent data annotations
-----------------------

TBD

Localization
-----------------------

TBD

Contribution
------------

Your help will be really appreciated! This project is under MIT license. Right now, you can help with bindings to different IoC containers (at least Unity, Ninject, Castle Windsor, StructureMap required) and ORMs (at least NHibernate). Look at the FluentArchitecture.Autofac, FluentArchitecture.Autofac.Web, FluentArchitecture.EntityFramework respectively. It is just few classes for every library, but it also takes a time to write a code.

Also, I am not native speaker, so typos and grammar corrections in this document and other documentation will useful too.

Thanks!