document.getElementById("vrncheck").addEventListener('click', function (event) {
    event.preventDefault();  // Prevent the form from submitting traditionally
    const fule_type = localStorage.getItem('vehicleFuelType');
    const url = `http://localhost:8080/api/Vehicles/Check/${fule_type}`;
    const radioButtons = document.getElementsByName('vrn-correct');
    let errors = [];
    // Clear any previous error summary or input errors
    const errorSummaryContainer = document.querySelector('.govuk-grid-column-two-thirds');
    const existingErrorSummary = document.querySelector('.govuk-error-summary');

    if (existingErrorSummary) {
      existingErrorSummary.remove();
    }

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

    if (getSelectedRadioValue() == null){
      errors.push({
        text: "Select a response",
        href: "#vrn-correct"
      });
      const errorSummaryHtml = `
      <div class="govuk-error-summary" role="alert" aria-labelledby="error-summary-title">
      <h2 id="error-summary-title" class="govuk-error-summary__title">There is a problem</h2>
      <ul class="govuk-error-summary__list">
      ${errors.map(error => `<li><a href="${error.href}">${error.text}</a></li>`).join('')}
      </ul>
      </div>
      `;

      errorSummaryContainer.insertAdjacentHTML('afterbegin', errorSummaryHtml);
    }else{
    fetch(url)
      .then(response => response.json())  // Assuming the API returns a JSON response
      .then(data => {
        if (getSelectedRadioValue() != "no"){
        if (data) {
          window.location.href = '/Check-eligible-path/is-address-eligible.html';
        } else {
          window.location.href = '/Check-eligible-path/Confirmation-pages/not-eligible.html';  // Redirect to the page for ineligible users
        }}
        else{
          window.location.href = '/Check-eligible-path/is-vrn-EV.html';
        }
      })
      .catch(error => {
        console.error('Error fetching data:', error);
        alert('There was an error processing your request. Please try again.');
      });
    }
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