package mucnjakf.models;

import javax.persistence.Embeddable;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import java.sql.Date;
import java.sql.Time;

@Embeddable
@Entity
@Table(name = "TravelWarrants")
public class TravelWarrant {
    @Id
    private int id;
    private String warrantStatus;
    private Date dateIssued;
    private Time timeIssued;
    private int driverId;
    private int vehicleId;
    private int fuelCostId;
    private int travelRouteId;

    public TravelWarrant() {
    }

    public int getId() {
        return id;
    }

    public String getWarrantStatus() {
        return warrantStatus;
    }

    public Date getDateIssued() {
        return dateIssued;
    }

    public Time getTimeIssued() {
        return timeIssued;
    }

    public int getDriverId() {
        return driverId;
    }

    public int getVehicleId() {
        return vehicleId;
    }

    public int getFuelCostId() {
        return fuelCostId;
    }

    public int getTravelRouteId() {
        return travelRouteId;
    }

    public String printToConsole() {
        return "\nID: " + id + "\nTravel warrant: " + timeIssued + " - " + dateIssued;
    }

    @Override
    public String toString() {
        return "TravelWarrant{" +
                "id=" + id +
                ", warrantStatus='" + warrantStatus + '\'' +
                ", dateIssued=" + dateIssued +
                ", timeIssued=" + timeIssued +
                ", driverId=" + driverId +
                ", vehicleId=" + vehicleId +
                ", fuelCostId=" + fuelCostId +
                ", travelRouteId=" + travelRouteId +
                '}';
    }
}

