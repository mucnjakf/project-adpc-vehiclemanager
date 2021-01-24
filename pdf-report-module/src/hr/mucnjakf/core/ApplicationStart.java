package hr.mucnjakf.core;

import hr.mucnjakf.models.*;
import hr.mucnjakf.sql.SqlRepository;
import org.apache.pdfbox.pdmodel.PDDocument;
import org.apache.pdfbox.pdmodel.PDDocumentInformation;
import org.apache.pdfbox.pdmodel.PDPage;
import org.apache.pdfbox.pdmodel.PDPageContentStream;
import org.apache.pdfbox.pdmodel.font.PDType1Font;

import java.io.IOException;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.List;
import java.util.Scanner;
import java.util.logging.Level;

public class ApplicationStart {

    public static void main(String[] args) throws IOException {

        // Removes Hibernate's logging to console
        @SuppressWarnings("unused")
        org.jboss.logging.Logger logger = org.jboss.logging.Logger.getLogger("org.hibernate");
        java.util.logging.Logger.getLogger("org.hibernate").setLevel(Level.OFF);

        Scanner scn = new Scanner(System.in);

        System.out.println("Select type of report (1 or 2)");
        System.out.println("1. All travel warrant reports");
        System.out.println("2. Specific travel warrant report");

        System.out.print("Choice: ");
        String choice = scn.nextLine();

        switch (choice) {
            case "1" -> {
                System.out.println("\nGenerating reports...\n");
                generateAllTravelWarrantsReport();
            }
            case "2" -> {
                System.out.print("\nLoading travel warrants...\n");
                printToConsoleAllAvailableTravelWarrants();

                System.out.print("Insert travel warrant ID: ");
                int idTravelWarrant = Integer.parseInt(scn.nextLine());

                System.out.println("\nGenerating report...\n");
                generateTravelWarrantReport(idTravelWarrant);
            }
            default -> System.out.println("I must enter correct choice! (1 or 2)");
        }
    }

    private static void printToConsoleAllAvailableTravelWarrants() {
        SqlRepository sqlRepository = new SqlRepository();

        List<TravelWarrant> travelWarrants = sqlRepository.getTravelWarrants();

        for (TravelWarrant travelWarrant : travelWarrants) {
            Driver driver = sqlRepository.getDriver(travelWarrant.getDriverId());
            Vehicle vehicle = sqlRepository.getVehicle(travelWarrant.getVehicleId());
            FuelCost fuelCost = sqlRepository.getFuelCost(travelWarrant.getFuelCostId());
            TravelRoute travelRoute = sqlRepository.getTravelRoute(travelWarrant.getTravelRouteId());

            System.out.println(travelWarrant.printToConsole());
            System.out.println(driver.printToConsole());
            System.out.println(vehicle.printToConsole());
            System.out.println(fuelCost.printToConsole());
            System.out.println(travelRoute.printToConsole());
        }
    }

    private static void generateTravelWarrantReport(int idTravelWarrant) throws IOException {
        SqlRepository sqlRepository = new SqlRepository();

        TravelWarrant travelWarrant = sqlRepository.getTravelWarrant(idTravelWarrant);
        Driver driver = sqlRepository.getDriver(travelWarrant.getDriverId());
        Vehicle vehicle = sqlRepository.getVehicle(travelWarrant.getVehicleId());
        FuelCost fuelCost = sqlRepository.getFuelCost(travelWarrant.getFuelCostId());
        TravelRoute travelRoute = sqlRepository.getTravelRoute(travelWarrant.getTravelRouteId());

        PDDocument pdf = new PDDocument();
        PDPage page = new PDPage();

        PDPageContentStream contentStream = new PDPageContentStream(pdf, page);

        contentStream.beginText();

        contentStream.newLineAtOffset(150, 750);
        contentStream.setFont(PDType1Font.TIMES_ROMAN, 36);

        contentStream.showText("Travel Warrant Report");

        contentStream.endText();

        contentStream.beginText();

        contentStream.newLineAtOffset(250, 700);
        contentStream.setFont(PDType1Font.TIMES_ROMAN, 12);

        contentStream.showText("Travel warrant ID: " + travelWarrant.getId());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Warrant status: " + travelWarrant.getWarrantStatus());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Date issued: " + travelWarrant.getDateIssued());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Time issued: " + travelWarrant.getTimeIssued());
        contentStream.newLineAtOffset(0, -30);
        contentStream.showText("Driver ID: " + driver.getId());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("First name: " + driver.getFirstName());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Last name: " + driver.getLastName());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Phone number: " + driver.getPhoneNumber());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Drivers licence number: " + driver.getDriversLicenceNumber());
        contentStream.newLineAtOffset(0, -30);
        contentStream.showText("Vehicle ID: " + vehicle.getId());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Make: " + vehicle.getMake());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Model: " + vehicle.getModel());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Year of manufacture: " + vehicle.getYearOfManufacture());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Initial mileage: " + vehicle.getInitialMileage());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Available: " + (vehicle.isAvailable() ? "Available" : "Not available"));
        contentStream.newLineAtOffset(0, -30);
        contentStream.showText("Fuel cost ID: " + fuelCost.getId());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Date issued: " + fuelCost.getDateIssued());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Time issued: " + fuelCost.getTimeIssued());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Position: " + fuelCost.getPosition());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Amount: " + fuelCost.getAmount());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Price: " + fuelCost.getPrice());
        contentStream.newLineAtOffset(0, -30);
        contentStream.showText("Travel route ID: " + travelRoute.getId());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Date issued: " + travelRoute.getDateIssued());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Time issued: " + travelRoute.getTimeIssued());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Origin: " + travelRoute.getOrigin());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Destination: " + travelRoute.getDestination());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Kilometers traveled: " + travelRoute.getKilometersTraveled());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Average speed: " + travelRoute.getAverageSpeed());
        contentStream.newLineAtOffset(0, -15);
        contentStream.showText("Spent fuel: " + travelRoute.getSpentFuel());
        contentStream.newLineAtOffset(0, -30);

        contentStream.endText();

        contentStream.close();

        pdf.addPage(page);

        PDDocumentInformation pdd = pdf.getDocumentInformation();

        pdd.setTitle("Travel warrant ID: " + travelWarrant.getId() + " report");

        Calendar date = Calendar.getInstance();
        pdd.setCreationDate(date);

        pdf.save("DataForExport/TravelWarrantReportID" + travelWarrant.getId() +".pdf");

        System.out.println("\nTravel warrant report PDF generated!");
        pdf.close();
    }

    private static void generateAllTravelWarrantsReport() throws IOException {
        SqlRepository sqlRepository = new SqlRepository();

        List<TravelWarrant> travelWarrants = sqlRepository.getTravelWarrants();

        PDDocument pdf = new PDDocument();

        int pageCounter = 1;

        for (TravelWarrant travelWarrant : travelWarrants) {
            Driver driver = sqlRepository.getDriver(travelWarrant.getDriverId());
            Vehicle vehicle = sqlRepository.getVehicle(travelWarrant.getVehicleId());
            FuelCost fuelCost = sqlRepository.getFuelCost(travelWarrant.getFuelCostId());
            TravelRoute travelRoute = sqlRepository.getTravelRoute(travelWarrant.getTravelRouteId());

            PDPage page = new PDPage();

            PDPageContentStream contentStream = new PDPageContentStream(pdf, page);

            contentStream.beginText();

            contentStream.newLineAtOffset(150, 750);
            contentStream.setFont(PDType1Font.TIMES_ROMAN, 36);

            contentStream.showText("Travel Warrant Report #" + pageCounter);

            contentStream.endText();

            contentStream.beginText();

            contentStream.newLineAtOffset(250, 700);
            contentStream.setFont(PDType1Font.TIMES_ROMAN, 12);

            contentStream.showText("Travel warrant ID: " + travelWarrant.getId());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Warrant status: " + travelWarrant.getWarrantStatus());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Date issued: " + travelWarrant.getDateIssued());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Time issued: " + travelWarrant.getTimeIssued());
            contentStream.newLineAtOffset(0, -30);
            contentStream.showText("Driver ID: " + driver.getId());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("First name: " + driver.getFirstName());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Last name: " + driver.getLastName());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Phone number: " + driver.getPhoneNumber());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Drivers licence number: " + driver.getDriversLicenceNumber());
            contentStream.newLineAtOffset(0, -30);
            contentStream.showText("Vehicle ID: " + vehicle.getId());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Make: " + vehicle.getMake());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Model: " + vehicle.getModel());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Year of manufacture: " + vehicle.getYearOfManufacture());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Initial mileage: " + vehicle.getInitialMileage());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Available: " + (vehicle.isAvailable() ? "Available" : "Not available"));
            contentStream.newLineAtOffset(0, -30);
            contentStream.showText("Fuel cost ID: " + fuelCost.getId());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Date issued: " + fuelCost.getDateIssued());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Time issued: " + fuelCost.getTimeIssued());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Position: " + fuelCost.getPosition());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Amount: " + fuelCost.getAmount());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Price: " + fuelCost.getPrice());
            contentStream.newLineAtOffset(0, -30);
            contentStream.showText("Travel route ID: " + travelRoute.getId());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Date issued: " + travelRoute.getDateIssued());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Time issued: " + travelRoute.getTimeIssued());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Origin: " + travelRoute.getOrigin());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Destination: " + travelRoute.getDestination());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Kilometers traveled: " + travelRoute.getKilometersTraveled());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Average speed: " + travelRoute.getAverageSpeed());
            contentStream.newLineAtOffset(0, -15);
            contentStream.showText("Spent fuel: " + travelRoute.getSpentFuel());
            contentStream.newLineAtOffset(0, -30);

            contentStream.endText();

            contentStream.close();

            pdf.addPage(page);

            PDDocumentInformation pdd = pdf.getDocumentInformation();

            pdd.setTitle("Travel warrants report");

            Calendar date = Calendar.getInstance();
            pdd.setCreationDate(date);

            pageCounter++;
        }

        pdf.save("DataForExport/TravelWarrantsReport.pdf");

        System.out.println("\nTravel warrants report PDF generated!");
        pdf.close();
    }
}




















