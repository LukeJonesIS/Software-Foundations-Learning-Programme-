document.getElementById("vrncheck").addEventListener('click', function (event) {
    event.preventDefault();  // Prevent the form from submitting traditionally
    const fule_type = localStorage.getItem('vehicleFuelType');
    const url = `http://localhost:8080/api/Vehicles/Check/${fule_type}`;
    const radioButtons = document.getElementsByName('vrn-correct');
    
    function getSelectedRadioValue() {
        let selectedValue = null;
        
        // Loop through the radio buttons and find the one that is checked
        radioButtons.forEach(function(radioButton) {
          if (radioButton.checked) {
            selectedValue = radioButton.value;  // Get the value of the selected radio
          }
        });
  
        // Return the selected value
        return selectedValue;
      }

    fetch(url)
      .then(response => response.json())  // Assuming the API returns a JSON response
      .then(data => {
        if (data) {
          window.location.href = '/Check-eligible-path/is-address-eligible.html';  // Redirect to the page for eligible users
        } else if (getSelectedRadioValue() != "yes"){
          window.location.href = '/Check-eligible-path/is-vrn-EV';
        } else {
          window.location.href = '/Check-eligible-path/Confirmation-pages/not-eligible.html';  // Redirect to the page for ineligible users
        }
      })
      .catch(error => {
        console.error('Error fetching data:', error);
        alert('There was an error processing your request. Please try again.');
      });
  });

window.addEventListener("load", function() {
    const vehicleVRN = localStorage.getItem('vehicleVRN');
    const vehicleMake = localStorage.getItem('vehicleMake');
    const vehicleModel = localStorage.getItem('vehicleModel');
    const vehicleFuelType = localStorage.getItem('vehicleFuelType');
    var addressElement = document.querySelectorAll('.govuk-table__cell')
    addressElement[1].textContent = vehicleVRN;
    addressElement[3].textContent = vehicleMake;
    addressElement[5].textContent = vehicleModel;
    addressElement[7].textContent = vehicleFuelType;
});