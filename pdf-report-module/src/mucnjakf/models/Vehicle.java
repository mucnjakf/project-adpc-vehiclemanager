package mucnjakf.models;

import javax.persistence.Embeddable;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Embeddable
@Entity
@Table(name = "Vehicles")
public class Vehicle {

    @Id
    private int id;
    private String make;
    private String model;
    private int yearOfManufacture;
    private int initialMileage;
    private boolean available;

    public Vehicle() {
    }

    public int getId() {
        return id;
    }

    public String getMake() {
        return make;
    }

    public String getModel() {
        return model;
    }

    public int getYearOfManufacture() {
        return yearOfManufacture;
    }

    public int getInitialMileage() {
        return initialMileage;
    }

    public boolean isAvailable() {
        return available;
    }

    public String printToConsole() {
        return "Vehicle: " + make + " " + model;
    }

    @Override
    public String toString() {
        return "Vehicle{" +
                "id=" + id +
                ", make='" + make + '\'' +
                ", model='" + model + '\'' +
                ", yearOfManufacture=" + yearOfManufacture +
                ", initialMileage=" + initialMileage +
                ", available=" + available +
                '}';
    }
}
