const userVrnInput = document.getElementById('user-vrn');
const continueButton = document.querySelector('.govuk-button');
 
function getVehicleDetails() {
    const userVrn = userVrnInput.value.toUpperCase();
    var apiEndpoint = 'http://localhost:8080/api/Vehicles/';
 
    fetch(apiEndpoint + userVrn).then(response => {

        if (!response.ok) {
            window.location.href = '/Check-eligible-path/vrn-not-found';
        }
        return response.json();
    })
        .then(data => {
            localStorage.setItem('vehicleVRN', data.vrn);
            localStorage.setItem('vehicleMake', data.make);
            localStorage.setItem('vehicleModel', data.model);
            localStorage.setItem('vehicleFuelType', data.fuel_type);
            window.location.href = '/Check-eligible-path/check-vehicle-details.html';
        })
        .catch(error => {
            console.error('Error fetching data:', error);
        });
}

continueButton.addEventListener('click', function(event) {
    event.preventDefault(); // Prevent default form submission
    getVehicleDetails(); // Call the function to fetch vehicle details
});