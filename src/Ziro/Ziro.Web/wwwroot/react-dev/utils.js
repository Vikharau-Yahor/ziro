
export function fetchData(url, httpMethod, requestData, successFunc, errorFunc) {
   //fetch(`http://ziroweb.azurewebsites.net/${url}`, { 
   fetch(`http://localhost:49763/${url}`, {
        method: httpMethod,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(requestData)
    })
    .then(response => response.json())
    .then(r => successFunc(r))
    .catch(error => errorFunc(error));
}