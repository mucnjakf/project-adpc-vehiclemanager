package hr.mucnjakf.models;

import javax.persistence.Embeddable;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Embeddable
@Entity
@Table(name = "Drivers")
public class Driver {
    @Id
    private int id;
    private String firstName;
    private String lastName;
    private String phoneNumber;
    private String driversLicenceNumber;

    public Driver() {
    }

    public int getId() {
        return id;
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

    public String printToConsole() {
        return "Driver: " + firstName + " " + lastName;
    }

    @Override
    public String toString() {
        return "Driver{" +
                "id=" + id +
                ", firstName='" + firstName + '\'' +
                ", lastName='" + lastName + '\'' +
                ", phoneNumber='" + phoneNumber + '\'' +
                ", driversLicenceNumber='" + driversLicenceNumber + '\'' +
                '}';
    }
}
