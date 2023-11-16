Overview:
This system was built with the following tools
 .NET 7
EF Core 7
NUnit
MSSSQL Server
Visual Studio for MAC. (But the solution can run on windows since it is a .net core solution which is cross platform).

I adopted Clean architecture with a touch of Repository Pattern

To run this application, kindly change the connection string in the appSettings.json to suit your own environment
execute migrations then the tables and seed data will be created and migrated to your environment
for example: open terminal or package manager console and enter doentet ef database update


Note: For demo purpose:
I implemented a small code unit to allow Admin users to pass in a default value in the header.
I will use this to differentiate between an admin user and a regular user.
This should not be used in an ideal production related environment

In the case of updating a claim, only the following status are allowed:
1) "Approved" or "APPROVED"
2) "Declined" or "DECLINED"
3) "In-Review" or "IN-REVIEW"

Also note that in an ideal production environment, an API will be used to pull the status and it will be passed from the frontend to the API


Please note that you will not be able to use Swagger to test the Update and Get all claims end point as it requires header authentication.
Kindly use Postman or Insomnia to simulate this process.
For example,
request body:
{
  "id": 1,
  "claimsStatus": "Declined"
}

Headers:
Key: TempAuth
Value: can be anything.

Please note that in a real life senario, this project would have a logging system, Encryption module using RSACryptoServiceProvider that was built in
.net and an authentication system. But these modules were skipped for brevity
But i had to do a lot of tradeoffs since this is a demo system