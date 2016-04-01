Twitter Clone

I have included a skeleton solution and a description / plan in the folder "Twitter Clone".

I will be using Visual Studio 2015 and starting this project with the ASP.NET 5 Web Application template.  I will be following an MVC pattern but will not be building a View.

For the code I chose to focus on a "Tweet".  I've included an example of a "Tweet" data model, controller, repository, and interface.  I chose this because most other classes and methods will follow the same pattern but with different properties.

If I was to go forward this app I would need to finish the rest of classes and methods I stubbed out. I would need to change how Tweet Id is given out, I'm currently using a Guid Hash but the chances for collision rise as the number of tweets increases. At 77000 tweets the chance of collision rises to 50%.  

I would also need to pay more attention to the ammount of data being sent.  As the amount of users and tweets grow I would need to implement paging or some other method to find a happy medium between load time and API calls.

