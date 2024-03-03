package TestData;

import org.testng.annotations.DataProvider;

public class RentalAgreementData {

	@DataProvider(name = "RentalAgreement")
	public Object[][] RentalAgreement() {
		return new Object[][] { { "RentalAgreement", "96600024", "Jan 1, 2023", "10039690", "1234" } }; // 96610346
	}

	@DataProvider(name = "RentalAgreementManual")
	public Object[][] RentalAgreementManual() {
		return new Object[][] { { "96602223", "Lurpak Cooler", "1", "64", "10001", "Space Rental", "Yearly",
				"Jan 1, 2023", "10039690", "1234" } };
	}
}
