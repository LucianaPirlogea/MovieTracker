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

## Source Control
Our project is uploaded on github, our commits, branches and merging can be seen on [the main page](https://github.com/LucianaPirlogea/MovieTracker).

## Bug Reporting
We have encountered the following bugs: Here is the [link](https://github.com/LucianaPirlogea/MovieTracker/issues?q=is%3Aissue+is%3Aclosed) where you can see how we fixed them.

## Code Standards
We followed the [Microsoft C# Code standards](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions).

## Design Patterns
In our implementation, we used two different design patterns: 
- [Repository Design Pattern](https://dotnettutorials.net/lesson/repository-design-pattern-csharp/#:~:text=The%20Repository%20Design%20Pattern%20in%20C%23%20Mediates%20between%20the%20domain,and%20the%20data%20access%20logic): mediates between the domain and the data mapping layers using a collection-like interface for accessing the domain objects. In other words, we can say that a Repository Design Pattern acts as a middleman or middle layer between the rest of the application and the data access logic.
![repositorydesignpattern](https://user-images.githubusercontent.com/79576756/176862864-fa5d05fb-f080-4e2c-af76-8e031af70478.jpg)
- [Factory Method](https://refactoring.guru/design-patterns/factory-method): a creational design pattern that provides an interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created.
![factory](https://user-images.githubusercontent.com/79576756/176868607-a08f9203-9fa8-484b-bf4b-9fb050ac8430.jpg)
