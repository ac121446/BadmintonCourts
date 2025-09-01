BadmintonCourts Web Application

---Explanation of the Software---
This Software is an online booking system that is designed to manage court reservations at SmashRentals. The main sections of my application includes the Home page, Locations, Bookings, Courts, Payments, and Equipments. There is also a pricing page but it is purely for visuals to display the prices. Users are able to easily book courts by choosing a location, 
selecting a court, picking a date and deciding on the start and end times of their booking on the Bookings page. On Locations page, users can filter locations and search by their name to quickly find on in their locations. Admins have the ability to view all the pages including Courts, Payments and Equipment as the user is unable to these ones. They can also 
possess the authority to add, update or remove all these records.Regular users have access to view their own Bookings and all available locations. They can also manage their own bookings and view details of locations. They can create and delete their own bookings. Overall ht eapplication provides a user friendly platform for both customers and administrators 
to book and mange badminton courts efficiently. 

---Prerequisites--- 
.NET SDK (Version 6.0 or later) - https://dotnet.microsoft.com/en-us/download Visual Studio (2022 is advised) - https://visualstudio.microsoft.com/

---Cloning and Opening solution--- After installing Visual Studio 2022, select Clone a repositor from the start page and then paste the repository link into the box that shows up. Paste this into the bos "https://github.com/ac121446/BadmintonCourts". Click clone and wait for the repository to load and when it opens, navigate to solution explorer. If it is not visible, go to the top menu and click view then solution explorer. In this tab, double click BadmintonCourts.sln to open the project.

---Package Manager Console and running the application--- After, open the Package Manager Console by clicking view, other windows then package manager console. A tab will appear at the bottom of the screen then at the PM> prompt, etner "update-database" then press enter. This applies database migrations and may also install required NuGet packages. Once the database has been updated, the projec is ready to run. At the top of the application, click the green play button with https next to it and launch the application. When the web application opens, you can register and start using the system. 
