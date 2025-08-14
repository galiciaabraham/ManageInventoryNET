# Overview

The Manage Inventory App is a simple and versatile tool designed for a ficticious "art supplies" company. But, it could be used for any company that wants to manage their inventory, the app allows you to perform CRUD operations and interact with your data. 

We used this project as a start-up on .NET development. The purpose of this project is to demonstrate our ability to articulate within the .NET development ecosystem, design and develop a .NET application, develop as a productive team member, and teach one another the principles of development in a team environment. 

The tests have been added to a folder named tests and were zipped to avoid conflicts with the actual project. (Since testing with Bunit requires you to start a new .NET project).

# Development Environment

The application was built using VS Code, .NET, and Blazor. 

We used Azure for project planning, management, and deployment. 

# Useful Websites

* [.NET / Blazor Docs](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-9.0&WT.mc_id=dotnet-35129-website)
* [ASP.NET Host and Deploy](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/server/?view=aspnetcore-9.0)
* [Original deployment](https://dev.azure.com/Team09CSE325/ManageInventoryNET/) This repository in github was created just in case you couldn't access the Azure Devops repository due to recent policy changes.

# Future Work

* The dashboard table is missing Ordering features, users should be able to order their data to see what they need.   
* Testing can be extended to many other operations such as page rendering or product filters.  
* The styling was kept in a basic stage because of time constrains, but as time allows, the project can gain variety and even more accessibility to make it more engaging and user friendly. 

# Collaborators

* Moises Parra Lozano
* Pedro Rafael Zelada Soruco
* Jose Roberto Martinez Cabrera
* Josue Abraham Galicia Sanchez

# User Guide: Table of Contents

1.  [Navigation](#navigation)
    
2.  [Register](#register)
    
3.  [Login](#login)
    
4.  [Filter Items](#filter-items)
    
5.  [Dashboard](#dashboard)
    
6.  [Add an Item](#add-an-item)
    
7.  [Edit an Item](#edit-an-item)
    
8.  [Delete an Item](#delete-an-item)
    

1\. Navigation
--------------

*   The top navigation bar contains quick links to:
    
    *   **Dashboard** — View your inventory.
        
    *   **User Management** — For admins only, access the user management dashboard.
        
    *   **Login or Logout** — Sign out of your account.
        
*   On mobile, a menu button (☰) is available for easier access.
    

2\. Register
------------

1.  Go to the **Register** page from the navigation menu.
    
2.  Fill in:
    
    *   **User Name**
        
    *   **Password**
        
3.  Click **Sign Up**.
    
4.  You’ll be redirected to the **Login** page.
    

3\. Login
---------

1.  Go to the **Login** page.
    
2.  Enter your **User Name** and **Password**.
    
3.  Click **Log In**.
    
4.  You’ll be taken to the **Home Page**.
    

4\. Filter Items
----------------

*   Use the **Filter Options** in the Dashboard to find specific items.
    
*   Filters may include:
            
    *   **Category**
        
    *   **Quantity**

    *   **Price**
        
*   Finally click filter to show the results.
    

5\. Dashboard
-------------

*   Display all your items in:
    
    *   **Table View** (desktop)
        
    *   **Card View** (mobile)
        
*   Each item shows:
    
    *   Name
        
    *   Quantity
        
    *   Category
        
    *   Actions (Edit/Delete)
        
*   Low-stock items are highlighted with a warning icon ⚠️.
    

6\. Add an Item
---------------

1.  Click **Add Item** in the top bar.
    
2.  Fill in:
    
    *   **Name**
        
    *   **Category**
        
    *   **Quantity**
        
    *   **Price**
            
3.  Click **Save**.
    
4.  The new item will appear in your Dashboard.
    

7\. Edit an Item
----------------

1.  In the Dashboard, find the item you want to update.
    
2.  Click the **Edit** button ✏️.
    
3.  Update the fields.
    
4.  Click **Save Changes**.
    

8\. Delete an Item
------------------

1.  In the Dashboard, find the item you want to remove.
    
2.  Click the **Delete** button 🗑️.
    
3.  Confirm the deletion.
    
4.  The item will be permanently removed from your inventory.