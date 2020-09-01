package mucnjakf.csvreader;

import mucnjakf.models.Vehicle;

import java.io.BufferedReader;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;

public class VehiclesCsvReader {
    public static ArrayList<Vehicle> readVehiclesFromCsv(String fileName) {

        ArrayList<Vehicle> vehicles = new ArrayList<Vehicle>();
        Path pathToFile = Paths.get(fileName);

        try (BufferedReader br = Files.newBufferedReader(pathToFile, StandardCharsets.US_ASCII)) {

            String line = br.readLine();

            while (line != null) {

                String[] data = line.split(",");

                if (data.length != 5) {
                    return null;
                } else {
                    Vehicle vehicle = createVehicle(data);

                    vehicles.add(vehicle);

                    line = br.readLine();
                }
            }
        } catch (IOException ioe) {
            System.out.println("File not found.");
        }

        return vehicles;
    }

    private static Vehicle createVehicle(String[] data) {

        String make = data[0];
        String model = data[1];
        int yearOfManufacture = Integer.parseInt(data[2]);
        int initialMileage = Integer.parseInt(data[3]);
        boolean available = Boolean.parseBoolean(data[4]);

        return new Vehicle(make, model, yearOfManufacture, initialMileage, available);
    }
}
