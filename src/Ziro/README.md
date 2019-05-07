# API

## Common API response structure

### Success response
Server sends 200 (Ok) if response processed successfully and all erros where handled.

Structure:

	{
		"errors":[],   
		"data":{}
	}
	
errors - (array of strings) any validation or other business errors

data - (object) response data (depends on requested api method)

Examples:
* {"errors":["Email is empty", "Password is empty"],"data":null}
* {"errors":null,"data":null} - for success empty response e.g. login
* {"errors":null,"data":{"info":"TestData available for USER only","someBool":true,"someArray":[1,23,54]}}

### Failure response
Server sends error object if some negative situation occured.

Structure:

	{
		"StatusCode": 0,
		"Error":""
	}

All possible situations and their status codes:
* 404 - not Found
* 401 - api require user authentication
* 403 - api require user authentication and certain role
* 500 - internall unhandled server error

Examples:
* {"StatusCode":404,"Error":"Not found"}
* {"StatusCode":500,"Error":"System.Exception: error: test server error\r\n..................."}

## Provided API
In next descriptions Data or Response data means "data" field of response (see response structure in **Common API response structure chapter**) 
### Authentication API
#### 1) POST api/account/login - user authentication
Role: not required

***Request***:

```sh  
{  
  "email":"test@dom.com",   
  "password":"523"    
}
```  
***Response***: 

Headers: cookies

```sh 
"data": null
```
#### 2) GET api/account/logout - user logout (remove user coockies)
Role: not required

***Request***:

```sh 
null
```

***Response***:

```sh 
"data": null
```

### Test API
#### 1) GET api/test/testanonym - test request (no any authorization required)
Role: not required

***Request***:

```sh  
null
```  
***Response***: 

```sh 
"data":
{
  "info":"TestData available for All",
  "someBool":true,
  "someArray":[1,23,54],
  "date":"2019-05-05T00:00:00+00:00"
}
```
#### 2) GET api/test/testuser - test request (User role required)
Role: User

***Request***:

```sh  
null
```  
***Response***: 

```sh 
"data":
{
  "info":"TestData available for USER only",
  "someBool":true,
  "someArray":[1,23,54],
  "date":"2019-05-05T00:00:00+00:00"
}
```
#### 3) GET api/test/testadmin - test request (Admin role required)
Role: Admin

***Request***:

```sh  
null
```  
***Response***: 

```sh 
"data":
{
  "info":"TestData available for Admin only",
  "someBool":true,
  "someArray":[1,23,54],
  "date":"2019-05-05T00:00:00+00:00"
}
```
#### 4) GET api/test/testerror - test request (no authorization required)
Role: not required

***Request***:

```sh  
null
```  
***Response***: 

Internal server error (see response structure in **Failure response** chapter)

### User API
#### 1) GET api/user/getProfile - get current user profile
Role: User

***Request***:

```sh  
null
```  
***Response***: 

```sh 
"data":
{
	"id":"93a09976-6a3c-4af8-a9cc-d0921741ce87",
	"name":"Сергей",
	"lastName":"Шикайло",
	"email":"testUser@mail.com",
	"skype":null,
	"phoneNumber":null,
	"position":
	{
		"id":"93a09976-6a3c-4af8-a9cc-d0921741ce87",
		"name":"Software Engineeer"
	},
	"dateOfBirth":"1994-03-11T00:00:00"
}
```
