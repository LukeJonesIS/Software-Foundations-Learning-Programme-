document.getElementById("address_form").addEventListener('submit', function (event) {
    event.preventDefault();  // Prevent the form from submitting traditionally
    const postcode = document.getElementById('address-postcode').value.replace(/ /g, "_").toUpperCase();  // Get the postcode entered by the user
    const url = `http://localhost:8080/api/Addresses/Check/${postcode}`;
    let errors = [];
    // Clear any previous error summary or input errors
    const errorSummaryContainer = document.querySelector('.govuk-grid-column-two-thirds');
    const existingErrorSummary = document.querySelector('.govuk-error-summary');
    if (existingErrorSummary) {
      existingErrorSummary.remove();
    }
    console.log(document.getElementById('addressStore').value)
    if (document.getElementById('addressStore').value ==""){
      errors.push({
        text: "Enter an address",
        href: "#addressStore"
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
        if (data) {

          localStorage.setItem("address", document.getElementById('addressStore').value)
          window.location.href = '/Check-eligible-path/check-eligible-answers.html';  // Redirect to the page for eligible users
        } else {
          window.location.href = '/Check-eligible-path/Confirmation-pages/not-eligible.html';  // Redirect to the page for ineligible users
        }
      })
      .catch(error => {
        console.error('Error fetching data:', error);
        alert('There was an error processing your request. Please try again.');
      });
    }
  });