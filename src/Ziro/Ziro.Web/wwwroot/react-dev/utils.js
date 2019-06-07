import Cookies from 'js-cookie';
//const website = 'http://ziroweb.azurewebsites.net';
const website = 'http://testziro-001-site1.dtempurl.com';
//const website = 'http://localhost:49763';

export function fetchPostData(url, requestData, successFunc, errorFunc) {
   fetch(`${website}/${url}`, {
        method: 'POST',
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

export function fetchGetData(url, successFunc, errorFunc) {
	fetch(`${website}/${url}`, {
		method: 'GET',
		headers: {
			'Accept': 'application/json',
			'Content-Type': 'application/json'
		}
	})
	.then(response => response.json())
	.then(r => successFunc(r))
	.catch(error => errorFunc(error));
}

export function setCookies(email, role) {
	Cookies.set('email', email);
	Cookies.set('role', role);
}

export function isUserAuthenticated() {
	var role = Cookies.get('role');
	return (role !== undefined) && (role !== null);
}

export function isCurRoleUser() {
	var role = Cookies.get('role');
	return role === 'User';
}

export function isCurRoleAdmin() {
	var role = Cookies.get('role');
	return role === 'Administrator';
}

export function getRandomNumber(min, max) {
   return Math.random() * (max - min) + min;
}