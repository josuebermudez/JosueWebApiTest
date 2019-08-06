# JosueWebApiTest
Web Api Test

This is a .Net Web Api project, with basic CRUD operations, who implements dependency injection and Mock library to unit testing.

The entity and ApiController to test is User.
After download the entire visual studio solution you should build it, and you can do testing using debug options
Here you have some request examples how you can run the test in postman app.
Please set the data format parameter as Json(application/json) in postman.
Get User list
GET http://{host}/api/user

Get User By Id
GET http://{host}/api/user/1

Create new User
POST GET http://{host}/api/user
{
    "Id": 10,
    "Name": "Carlos",
    "LastName": "Garcia",
    "Address": "Test Address",
    "CreateDate": "2019-07-31",
    "UpdateDate": "2019-07-31"
}

Update User
PUT http://{host}/api/user
{
    "Id": 10,
    "Name": "Carlos",
    "LastName": "Garcia",
    "Address": "Test Address",
    "UpdateDate": "2019-07-31"
}

Delete User
DELETE  http://{host}/api/user/2
