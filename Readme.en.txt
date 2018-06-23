   Environment and Development
   ========================================================


   
This project is generated in Visual Studio 2017.In order to run this project you need 
   to have full version of Visual studio 2017 and a Microsoft Operation System.


  Running Server and Endpoint
  ==========================================================
   Server

Run IISExpress on Internet Explorer but should be able to run on any microsoft OS
   competable browser for user interface.
   By running the project you need to navigate http://localhost:50032/
   By adding books to the cart, a small cart should be appeared on the top left that 
   identifies the number of books are added. After completing the shopping a click on 
   cart will lead you to http://localhost:50032/Store/ViewCart
   here all the necessary details will be seen, book title, author, instock, remove from
   cart and price of each book together with total shopping books cost.

  Required dependecies and C# libraries
  ==========================================================
  The following required to run the project( setup from the beginning)
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using Newtonsoft.Json;
  using System.Web.Mvc;


  Functionality
  ==========================================================
  A potential user upon successfully running the project with http://localhost:50032/ 
  will be promoted to the page with a search box. At first glance the user will be
  able to see all the books details, title, author, instock, price and Add to cart
  option. A small search box will also appear on top.The user can either search a book
  by Title or Author by entering at least one or more letters.After writing letters i.e. either 
  in small or big letters in search box a user need to click on search button. If the book 
  with specified criteria i.e.letters matches a book the book with title, author, instock
  and price will appear.
  A user can click on "Add to cart". Once clicked the cart will show one item added. A user
  get directed to the store book page.

  A user may want to buy more books, a click on "Back to store" will lead a user to the
  book store and Add to cart will keep adding books to the cart.  
  In case if a user want to scroll up and down he can also add books to the cart 
  without searching it in the search box.
 
  Add to cart options is active for the books that are inStock. e.g. if instock shows 0 ,
  that means that book does not exist in the store so the Add to cart option will be 
  inactive for that particular book. Similarly a user can add one book at a time, first 
  he/she adds one book to the cart, upon clicking on Add to cart, the instock value
  gets updated.
  e.g. It will show 0 instead of 1(if one book was in store before add to cart click).
  Similarly if the stock for a book is more than 1 upon each click on add to cart will
  update the stock value of the book.

  Once user is done shopping, clicking on cart will lead a user to an endpoint,
  http://localhost:50032/Store/ViewCart . Here a user gets all the details of the potential
  purchasing books in a table. The book details are Title, Author, Price, inStock. There is 
  a Remove from cart option if a user does not want to buy a particular book. Upon clicking
  on Remove from cart the book will be removed from cart and total sum of purchsed books
  will get updated. If a user want to continue shopping, he/she can click on back to store
  and can add more books to the cart.

 Technicality and architecture
 ==========================================================
 First opening the visual studio 2017, in file choosing new then project and then ASP.net
 Application and select web on the left side(if not being selected). Name the project and 
 by clicking ok a small window appears where empty is selected, down clicking both mvc and
 web api as checklist.
 
 This project does not contain any data store folder as I have been provided with a Json 
 which is converted it into a String and then put it in a List.

 Architecture contains an interface folder where I created the interfaces and then in
 Controller folder I created the necessary controller i.e. Store Controller. For modeling 
 I created a class and for services I created a service folder where I added the bookstoreservices
 class. For views I have two views one for index(book store) and Cart view. 
 

 As the inStock and other attributes are provided to me in hard coded format,
 first I take the Json as a string and then deserialize objects by jsonconvert and
 put them into the List.In order to update the instock value I used the session cookies. 
 That enabled me to update the stock as per add to cart or remove from cart.
 
 The instruction for the task are focusing on the back end. I could have opted to add a
 little bit of graphics with the help of CSS and may have used angular and jquery etc. 
 However, that may have taken me more time and being advised that assume that frontend
 can be repaceable.I am using the view with HTML@ that help me to add the backend 
 functionality at ease.

 Comments are added where I feel they were needed.
 

  Running unit tests

Run
  ===========================================================
  Unit tests are not provided but can be added easily as I personally did not feel the
  need of them.Perhaps with more profound frontend with Javascript(Angular JS) may 
  would have required to test the logic.
