package hr.mucnjakf.sql;

import hr.mucnjakf.models.Driver;
import hr.mucnjakf.models.Vehicle;

import javax.sql.DataSource;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.util.ArrayList;
import java.util.Scanner;

public class SqlRepository {

    public static void insertVehicles(ArrayList<Vehicle> vehicles) {
        final String insertVehiclesQuery = "INSERT INTO Vehicles (Make, Model, YearOfManufacture, InitialMileage, Available) VALUES (?, ?, ?, ?, ?)";

        DataSource dataSource = DataSourceHelper.createDataSource();

        try (Connection connection = dataSource.getConnection()) {
            connection.setAutoCommit(false);

            try (PreparedStatement insertVehiclesStmnt = connection.prepareStatement(insertVehiclesQuery)){

                for (Vehicle vehicle : vehicles){
                    insertVehiclesStmnt.setString(1, vehicle.getMake());
                    insertVehiclesStmnt.setString(2, vehicle.getModel());
                    insertVehiclesStmnt.setInt(3, vehicle.getYearOfManufacture());
                    insertVehiclesStmnt.setInt(4, vehicle.getInitialMileage());
                    insertVehiclesStmnt.setBoolean(5, vehicle.isAvailable());

                    insertVehiclesStmnt.executeUpdate();
                }

                if (acceptImport()){
                    connection.commit();
                    System.out.println("Import saved.");
                } else {
                    connection.rollback();
                    System.out.println("Import canceled.");
                }
            } catch (Exception ex) {
                connection.rollback();
                System.out.println("Import canceled: " + ex.getMessage());
            } finally {
                connection.setAutoCommit(true);
            }
        } catch (Exception ex) {
            System.err.println(ex.getMessage());
        }
    }

    public static void insertDrivers(ArrayList<Driver> drivers) {
        final String insertDriversQuery = "INSERT INTO Drivers (FirstName, LastName, PhoneNumber, DriversLicenceNumber) VALUES (?, ?, ?, ?)";

        DataSource dataSource = DataSourceHelper.createDataSource();

        try (Connection connection = dataSource.getConnection()) {
            connection.setAutoCommit(false);

            try (PreparedStatement insertDriversStmnt = connection.prepareStatement(insertDriversQuery)){

                for (Driver driver : drivers){
                    insertDriversStmnt.setString(1, driver.getFirstName());
                    insertDriversStmnt.setString(2, driver.getLastName());
                    insertDriversStmnt.setString(3, driver.getPhoneNumber());
                    insertDriversStmnt.setString(4, driver.getDriversLicenceNumber());

                    insertDriversStmnt.executeUpdate();
                }

                if (acceptImport()){
                    connection.commit();
                    System.out.println("Import saved.");
                } else {
                    connection.rollback();
                    System.out.println("Import canceled.");
                }
            } catch (Exception ex) {
                connection.rollback();
                System.out.println("Import canceled: " + ex.getMessage());
            } finally {
                connection.setAutoCommit(true);
            }
        } catch (Exception ex) {
            System.err.println(ex.getMessage());
        }
    }

    private static boolean acceptImport() {
        System.out.print("Accept import (Y/N): ");
        return new Scanner(System.in).nextLine().matches("Y|y");
    }
}
