// JavaScript to handle form submission and send data to API
document.getElementById('submitForm').addEventListener('submit', function(event) {
    event.preventDefault();
  
    // Collect form data
    const data = {
      name: document.querySelectorAll('.govuk-summary-list__value')[0].textContent,
      email: document.querySelectorAll('.govuk-summary-list__value')[1].textContent,
      address: document.querySelectorAll('.govuk-summary-list__value')[2].textContent,
      vrn: document.querySelectorAll('.govuk-summary-list__value')[3].textContent
    };
  
    // Send data via POST request to the API
    fetch('http://localhost:8080/api/Applications/Create', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(data)
    })
    .then(response => response.json())
    .then(responseData => {
      console.log(responseData)
      window.location.href = '/Submission-path/application-submitted';

    })
    .catch(error => {
      console.error('Error submitting application:', error);
      alert('There was an error submitting your application. Please try again.');
    });
  });
window.addEventListener('load', function () {
    var address = localStorage.getItem('address'); 
    const vehicleVRN = localStorage.getItem('vehicleVRN');
    if (address) {
      var addressElement = document.querySelectorAll('.govuk-summary-list__value')[2];
      if (addressElement) {
        addressElement.textContent = address;
      }
    }
    if (vehicleVRN) {
      var vrnElement = document.querySelectorAll('.govuk-summary-list__value')[3];
      if (vrnElement) {
        vrnElement.textContent = vehicleVRN;
      }
    }
  });


