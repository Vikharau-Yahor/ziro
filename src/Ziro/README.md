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
### Authentication API urls
#### 1) POST api/account/login - for user authentication
Role: Anonym

***Request***:


Data:
```sh  
{  
  "email":"test@dom.com",   
  "password":"523"    
}
```  
***Response***: 

Errors: possible validation errors

Headers: cookies

Data:

```sh 
null
```
#### 2) GET api/account/logout - for user sign out (remove user coockies)
Role: Anonym

***Request***:

Data: null

***Response***:

Errors: no

Data: null

### Test API urls
#### 1) GET api/test/testanonym - test request (no any authorization required)
Role: Anonym

***Request***:

Data:
```sh  
null
```  
***Response***: 

Errors: no

Data:

```sh 
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

Data:
```sh  
null
```  
***Response***: 

Errors: no

Data:

```sh 
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

Data:
```sh  
null
```  
***Response***: 

Errors: no

Data:

```sh 
{
  "info":"TestData available for Admin only",
  "someBool":true,
  "someArray":[1,23,54],
  "date":"2019-05-05T00:00:00+00:00"
}
```
#### 4) GET api/test/testerror - test request (no authorization required)
Role: Anonym

***Request***:

Data:
```sh  
null
```  
***Response***: 

Internal server error (see response structure in **Failure response** chapter)
