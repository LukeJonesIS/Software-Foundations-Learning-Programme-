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
    let errors = [];

    // Get the form inputs
    const userVrn = document.querySelector('[name="user-vrn"]');

    // Clear any previous error summary or input errors
    const errorSummaryContainer = document.querySelector('.govuk-grid-column-two-thirds');
    const existingErrorSummary = document.querySelector('.govuk-error-summary');
    if (existingErrorSummary) {
      existingErrorSummary.remove();
    }
    userVrn.classList.remove('govuk-input--error');
    userVrn.removeAttribute('aria-invalid');

    // Check for empty fields
    if (!userVrn.value.trim()) {
      errors.push({
        text: "Enter a VRN",
        href: "#user-vrn"
      });
    } else if (userVrn.value.trim().length> 10) {
        errors.push({
          text: "VRN is too long",
          href: "#user-vrn"
        });
    }else if (userVrn.value.trim().length< 5) {
        errors.push({
          text: "VRN is too short",
          href: "#user-vrn"
        });
      }else{ 
        const regex = /^[a-zA-Z](?=.*\d)[a-zA-Z0-9]*$/;
        if (!regex.test(userVrn.value.trim())) {
          errors.push({
          text: "VRN is in an invalid format",
          href: "#user-vrn"
        });
      }
    };
    if (errors.length > 0) {
        // Add error class and aria-invalid attribute to inputs
        if (errors.some(error => error.href === '#user-vrn')) {
          userVrn.setAttribute('aria-invalid', 'true');
          userVrn.classList.add('govuk-input--error');
        }
      const errorSummaryHtml = `
      <div class="govuk-error-summary" role="alert" aria-labelledby="error-summary-title">
        <h2 id="error-summary-title" class="govuk-error-summary__title">There is a problem</h2>
        <ul class="govuk-error-summary__list">
          ${errors.map(error => `<li><a href="${error.href}">${error.text}</a></li>`).join('')}
        </ul>
      </div>
    `;
    errorSummaryContainer.insertAdjacentHTML('afterbegin', errorSummaryHtml);
    } else {
    getVehicleDetails(); // Call the function to fetch vehicle details
  }
});