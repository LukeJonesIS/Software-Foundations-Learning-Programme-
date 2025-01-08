document.addEventListener('DOMContentLoaded', function () {
    // Get the postcode input element and the dropdown for addresses
    const postcodeInput = document.getElementById('address-postcode');
    const addressDropdown = document.getElementById('address-dropdown');
    
    // Ensure the postcode input exists before proceeding
    if (!postcodeInput || !addressDropdown) {
        console.error("Postcode input or address dropdown not found!");
        return;
    }

    postcodeInput.addEventListener('change', function() {
        const postcode = postcodeInput.value.replace(/ /g, "_").toUpperCase();

        if (postcode) {
            fetchAddress(postcode);
        } else {
            addressDropdown.innerHTML = '<option value="">Select an address</option>';
        }
    });

    if (postcodeInput.value.replace(/ /g, "_").toUpperCase()) {
        fetchAddress(postcodeInput.value.replace(/ /g, "_").toUpperCase());
    }

    function fetchAddress(postcode) {
        const apiEndpoint = 'http://localhost:8080/api/Addresses/';
        
        addressDropdown.innerHTML = '<option>Loading...</option>';
        console.error(apiEndpoint + postcode);
        fetch(apiEndpoint + postcode)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                addressDropdown.innerHTML = '<option value="">Select an address</option>';

                if (Array.isArray(data) && data.length > 0) {
                    data.forEach(address => {
                        const option = document.createElement('option');
                        option.value = address.address_line1 + ', ' + address.address_line2 + ', ' + address.city + ', ' + address.postcode; // Unique value for submission
                        option.textContent = address.address_line1 + ', ' + address.address_line2 + ', ' + address.city + ', ' + address.postcode; // Display text
                        addressDropdown.appendChild(option);
                    });
                } else {
                    const option = document.createElement('option');
                    option.value = '';
                    option.textContent = 'No addresses found for this postcode';
                    addressDropdown.appendChild(option);
                }
            })
            .catch(error => {
                console.error('Error fetching data:', error);
                addressDropdown.innerHTML = '<option value="">Error loading addresses</option>';
            });
    }
});
