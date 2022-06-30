# Movies Tracker
Web API using .Net Framework that keeps track of the movies you watched. It has features for following other users, discover and rating movies.

## Team members
- [Dobre Adriana-Lia](https://github.com/DobreAdriana)
- [Guțu Ștefania-Alexandra](https://github.com/StefaniaGutu)
- [Lăzăroiu Teodora-Bianca](https://github.com/TeodoraLazaroiu)
- [Pirlogea Luciana-Elena](https://github.com/LucianaPirlogea)

## Database Design
The diagram that we used for our API is displayed below:
![SQL-Diagram](https://user-images.githubusercontent.com/79576756/176704477-8daca699-c305-44a2-9ab3-369f2741312e.jpg)


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
![UML-Diagram](https://user-images.githubusercontent.com/79576756/176692554-8d57f073-0547-4f14-904d-960066f7f6da.jpg)

## Automation Testing

For testing we have created an xUnit Testing Project containing 4 classes for the following controllers of the API: ActorController, CategoryController, MovieController and ReviewController. Each class contains methods that check the behaviour of the application when new entities are created. The methods follow the Arrange-Act-Assert method for writing tests which means preparing the testing objects, performing the test and verifying the result by giving an answer (Passed or Failed) to the test.

We have used the xUnit and Microsoft.NET.Test.Sdk NuGet packages for creating and building unit tests. After finishing all tests, it is displayed the number of tests that the application has runned on successfully and what problems have occurred on tests that the application has failed on.

## Bug Reporting
We have encountered the following bugs: Here is the [link](https://github.com/LucianaPirlogea/MovieTracker/issues?q=is%3Aissue+is%3Aclosed) where you can see how we fixed them.

## Code Standards
We followed the [Microsoft C# Code standards](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions).

## Design Patterns
