package hr.mucnjakf.models;

public class Vehicle {

    private String make;
    private String model;
    private int yearOfManufacture;
    private int initialMileage;
    private boolean available;

    public Vehicle(String make, String model, int yearOfManufacture, int initialMileage, boolean available) {
        this.make = make;
        this.model = model;
        this.yearOfManufacture = yearOfManufacture;
        this.initialMileage = initialMileage;
        this.available = available;
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

    @Override
    public String toString() {
        return "Vehicle{" +
                "make='" + make + '\'' +
                ", model='" + model + '\'' +
                ", yearOfManufacture=" + yearOfManufacture +
                ", initialMileage=" + initialMileage +
                ", available=" + available +
                '}';
    }
}
