package mucnjakf.core;

import mucnjakf.models.Driver;
import mucnjakf.models.Vehicle;

import java.util.ArrayList;
import java.util.Scanner;

import static mucnjakf.csvreader.DriversCsvReader.readDriversFromCsv;
import static mucnjakf.csvreader.VehiclesCsvReader.readVehiclesFromCsv;
import static mucnjakf.sql.SqlRepository.insertDrivers;
import static mucnjakf.sql.SqlRepository.insertVehicles;

public class ApplicationStart {

    public static void main(String[] args) {
        Scanner scn = new Scanner(System.in);

        System.out.println("Select data for import (1 or 2)");
        System.out.println("1. Drivers");
        System.out.println("2. Vehicles");

        System.out.print("Choice: ");
        String dataForImport = scn.nextLine();

        System.out.print("File name (include .csv): ");
        String userInput = scn.nextLine();

        switch (dataForImport) {
            case "1":
                try {
                    ArrayList<Driver> drivers = readDriversFromCsv(userInput);
                    insertDrivers(drivers);
                    break;
                } catch (Exception ex) {
                    System.out.println("File does not match drivers data.");
                    break;
                }
            case "2":
                try {
                    ArrayList<Vehicle> vehicles = readVehiclesFromCsv(userInput);
                    insertVehicles(vehicles);
                    break;
                } catch (Exception ex) {
                    System.out.println("File does not match vehicles data.");
                    break;
                }
            default:
                System.out.println("Invalid data import option!");
        }
    }
}