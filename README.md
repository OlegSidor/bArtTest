# bArtTest

## Installation
```git
git clone https://github.com/OlegSidor/bArtTest.git
```
using .NET v6

## DB
Change DefaultConnectionString in appsettings.json to connect database

run migrations
```bash
dotnet ef database update
```
OR
```bash
Update-Database
```
in NuGet package manager console


## API USAGE

Get info about account:  
```HTML
GET /api/accounts/<account_name>
```
```JSON
{
    "id": int,
    "name": string,
    "incidentname": string,
    "incident": Object,
    "contacts": Array
}
```

Get contacts connected to account:
```HTML
GET /api/contacts/<account_name>
```
```JSON
[{
    "id": int
    firts_name": string,
    "last_name": string,
    "email": string",
    "accountid": int,
    "account": object
},...]
```

Get incidents connected to account:
```HTML
GET /api/incidents/<account_name>
```
```JSON
{"name":string, "description": string}
```

Create incidents with account add contact
```JSON
POST /api/createincident/
{
    "account": string, 
    "email": string, 
    "first_name": string, 
    "last_name": string,
    "description": string
}
```

Add contact to account
```JSON
POST /api/addcontact/
{
    "account": string, 
    "email": string, 
    "first_name": string, 
    "last_name": string,
}
```

Edit contact in account:
```JSON
PUT /api/editcontact/
{ 
    "email": string, //(required) existing email 
    "first_name": string", //(optional) new first_name
    "last_name": string  //(optional) new last_name
}
```

Edit incident description connected to account:
```JSON
PUT /api/editincident/
{ 
    "account": string, //(required) account name 
    "description": string //(required) new description 
}

```
