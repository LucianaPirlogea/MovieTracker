# Movies Tracker
Web API using .Net Framework that keeps track of the movies you watched. It has features for following other users, discover and rating movies.

## Team members
- [Dobre Adriana-Lia](https://github.com/DobreAdriana)
- [Guțu Ștefania-Alexandra](https://github.com/StefaniaGutu)
- [Lăzăroiu Teodora-Bianca](https://github.com/TeodoraLazaroiu)
- [Pirlogea Luciana-Elena](https://github.com/LucianaPirlogea)

## Demo 
Link Youtube : [here](https://youtu.be/s2ImtdFtMmY) 
## Database Design
The diagram that we used for our API is displayed below:

![SQL-Diagram](https://user-images.githubusercontent.com/79576756/177700492-722a081b-39b9-42fa-bae0-a5832a20fae0.jpg)



## User stories
|  | As | I want to | So that I can | 
| ------------- | ------------- | ------------- | ------------- |
| 1   | visitor | create an account    | use all the features of the app  |
| 2     | visitor, user, admin       | search movies    |  see all the details about them |
| 3     | visitor, user, admin       | see an actor's movies    |  see all the movies he/she/they played in |
| 4     | visitor, user, admin       | see all the movies from a category    |  filter them by my favourite genre |
| 5     | visitor, user, admin       | see the most popular movies    |  choose from the most viewed ones |
| 6     | user, admin       | log into my account    |  access my profile |
| 7     | user, admin       | review movies    |  tell my opinion about them |
| 8     | user, admin       | see my list of watched movies    |  remember which ones I have already viewed |
| 9     | user, admin       | see my personalized movies    |  see the recommendations for me |
| 10     | user, admin       | follow other people    |  see their activity |
| 11     | user, admin       | see my profile    |  see details about my account |
| 12     | user, admin       | see the people I follow    |  see their details and watched movies |
| 13     | admin       | add, edit and delete movies    |  keep the list of movies up to date |
| 14     | admin       | see anyone's account    |  see details about them |
| 15     | admin       | delete comments    | avoid inappropriate behaviour on the app |
| 16     | admin       | delete users    | eliminate rude people and bots |

## Backlog
We used Trello in order to manage and organise our tasks during the development of the application. This [link](https://trello.com/b/NZkGMXRF/proiect-mds) redirects to our backlog creation and user stories.

## UML Use Case Diagram
![UML-Diagram](https://user-images.githubusercontent.com/79576756/177638590-282c13e8-a7fa-48ea-96a2-d7a27443d5d0.jpg)



## Automation Testing

For testing we have created an xUnit [Testing Project](https://github.com/LucianaPirlogea/MovieTracker/tree/master/UnitTests) containing 4 classes for the following controllers of the API: ActorController, CategoryController, MovieController and ReviewController. Each class contains methods that check the behaviour of the application when new entities are created. The methods follow the Arrange-Act-Assert method for writing tests which means preparing the testing objects, performing the test and verifying the result by giving an answer (Passed or Failed) to the test.

We have used the xUnit and Microsoft.NET.Test.Sdk NuGet packages for creating and building unit tests. After finishing all tests, it is displayed the number of tests that the application has runned on successfully and what problems have occurred on tests that the application has failed on.
![teste](https://user-images.githubusercontent.com/45512830/176992767-1918b439-ef47-46e7-a7bc-495614d66050.png)

## Source Control
Our project is uploaded on github, our commits, branches and merging can be seen on [the main page](https://github.com/LucianaPirlogea/MovieTracker).


## Bug Reporting
We have encountered the following bugs: Here is the [link](https://github.com/LucianaPirlogea/MovieTracker/issues?q=is%3Aissue+is%3Aclosed) where you can see how we fixed them.

## Build Tool
Our backend application was built by the Visual Studio default MSBuild tool.
![Captură ecran (1157)](https://user-images.githubusercontent.com/45512830/176993076-6d54c917-62a1-432b-991e-0aa8c7124ef2.png)


## Code Standards
We followed the [Microsoft C# Code standards](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions).

## Design Patterns
In our implementation, we used two different design patterns: 
- [Repository Design Pattern](https://dotnettutorials.net/lesson/repository-design-pattern-csharp/#:~:text=The%20Repository%20Design%20Pattern%20in%20C%23%20Mediates%20between%20the%20domain,and%20the%20data%20access%20logic): mediates between the domain and the data mapping layers using a collection-like interface for accessing the domain objects. In other words, we can say that a Repository Design Pattern acts as a middleman or middle layer between the rest of the application and the data access logic.
![repositorydesignpattern](https://user-images.githubusercontent.com/79576756/177700536-3dd6cf6a-0301-4cb6-8a8a-ace2d05b27c1.jpg)

- [Factory Method](https://refactoring.guru/design-patterns/factory-method): a creational design pattern that provides an interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created.
![factory](https://user-images.githubusercontent.com/79576756/176868607-a08f9203-9fa8-484b-bf4b-9fb050ac8430.jpg)
