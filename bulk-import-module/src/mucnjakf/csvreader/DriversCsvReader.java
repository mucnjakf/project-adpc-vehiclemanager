package mucnjakf.csvreader;

import mucnjakf.models.Driver;

import java.io.BufferedReader;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;

public class DriversCsvReader {

    public static ArrayList<Driver> readDriversFromCsv(String fileName) {

        ArrayList<Driver> drivers = new ArrayList<Driver>();
        Path pathToFile = Paths.get(fileName);

        try (BufferedReader br = Files.newBufferedReader(pathToFile, StandardCharsets.US_ASCII)) {

            String line = br.readLine();

            while (line != null) {

                String[] data = line.split(",");

                if (data.length != 4) {
                    return null;
                } else {
                    Driver driver = createDriver(data);

                    drivers.add(driver);

                    line = br.readLine();
                }

            }
        } catch (IOException ioe) {
            System.out.println("File not found.");
        }

        return drivers;
    }

    private static Driver createDriver(String[] data) {

        String firstName = data[0];
        String lastName = data[1];
        String phoneNumber = data[2];
        String driversLicenceNumber = data[3];

        return new Driver(firstName, lastName, phoneNumber, driversLicenceNumber);
    }
}
