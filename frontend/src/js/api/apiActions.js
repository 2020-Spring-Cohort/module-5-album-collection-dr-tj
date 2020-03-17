function getRequest(location, callback) {
    fetch(location)
    .then(response => response.json())
    .then(data => callback(data))
    .catch(err => console.log(err))
}
  
function postRequest(location, requestBody, callback) {
    
}
  
function deleteRequest(location, callback) {

}
  
function putRequest(location, requestBody, callback) {

}
  
export default {
    getRequest,
    postRequest,
    deleteRequest,
    putRequest
};