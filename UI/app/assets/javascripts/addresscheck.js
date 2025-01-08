document.getElementById("address_form").addEventListener('submit', function (event) {
    event.preventDefault();  // Prevent the form from submitting traditionally
    const postcode = document.getElementById('address-postcode').value.replace(/ /g, "_").toUpperCase();  // Get the postcode entered by the user
    const url = `http://localhost:8080/api/Addresses/Check/${postcode}`;

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
  });