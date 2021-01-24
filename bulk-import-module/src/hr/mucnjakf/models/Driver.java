package hr.mucnjakf.models;

public class Driver {

    private String firstName;
    private String lastName;
    private String phoneNumber;
    private String driversLicenceNumber;

    public Driver(String firstName, String lastName, String phoneNumber, String driversLicenceNumber) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phoneNumber = phoneNumber;
        this.driversLicenceNumber = driversLicenceNumber;
    }

    public String getFirstName() {
        return firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public String getDriversLicenceNumber() {
        return driversLicenceNumber;
    }

    @Override
    public String toString() {
        return "Driver{" +
                "firstName='" + firstName + '\'' +
                ", lastName='" + lastName + '\'' +
                ", phoneNumber='" + phoneNumber + '\'' +
                ", driversLicenceNumber='" + driversLicenceNumber + '\'' +
                '}';
    }
}
