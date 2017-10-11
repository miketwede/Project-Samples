function formatName(customer) {
	var fullName = "";
	if (customer.Title) {
		fullName += customer.title + " ";
	}
	fullName += customer.firstName + " ";
	if (customer.middleInitial) {
		fullName += customer.middleInitial + " ";
	}
	fullName += customer.lastName + " ";
	if (customer.suffix) {
		fullName += customer.suffix;
	}

	return fullName.trim();
}

function formatAddress(customer) {
	var fullAddress = "";

	fullAddress += customer.address1 + " ";
	if (customer.address2) {
		fullAddress += customer.address2 + " ";
	}

	fullAddress += customer.city + " ";
	fullAddress += customer.state + " ";
	fullAddress += customer.zip + " ";
	if (customer.country) {
		fullAddress += customer.country;
	}

	return fullAddress.trim();
}