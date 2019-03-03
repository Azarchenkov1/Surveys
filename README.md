# Surveys
Surveys service

Angular: 5.2.5
.NET Core: 2.0

Project contain 13 api methods on server and 4 pages on client as described in technical task list.
Method names in the project and in the technical assignment may differ.

Application contain:
1.Client app writed with angular. Defined in ClientApp/src/app folder
2.Web API defined in Controllers folder(data contracts defined in ReceiverContractLibrary and SenderContractLibrary)
3.Data access layer in DAL folder
4.Model writed with EF Core, defined in Model folder

Download and open in VS.

Wait before all dependencies fetch to your computer.

!!!warning:

Properties of project can be reset. So you must assure that everything allright before run project.
Go to properties of project. In properties -> debug (you see two dropdown menus)
in first dropdown you must define "Surveys" option(not IIS Express),
in second dropdown "Project". In down of tabwindow you must see URL input. You must write here http://localhost:4000/
Now in top, where you see the green play logo(as run app in debug), in drop down you must choose "Surveys" option, not browser.

This all options must be, because client sending requests on port: 4000. In another case IIS choose port randomely.
So client may does not work because of that. Be aware of this!

When you run project first time you must set IsInitialize and IsRecreate property as true. in Model/Model.cs 11 and 12line.
Then wait before app load in browser, and off it. Now set this properties as false and run it again. Also be aware that you must edit connection string on 32line due to your mssqlserver.

If you add new survey, please reload main page to see it in list.

If you have questions, call me 0937041428.
Best wishes.
