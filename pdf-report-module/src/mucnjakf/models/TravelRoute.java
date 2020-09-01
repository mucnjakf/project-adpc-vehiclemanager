package mucnjakf.models;

import javax.persistence.Embeddable;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import java.sql.Date;
import java.sql.Time;

@Embeddable
@Entity
@Table(name = "TravelRoutes")
public class TravelRoute {
    @Id
    private int id;
    private Date dateIssued;
    private Time timeIssued;
    private String origin;
    private String destination;
    private float kilometersTraveled;
    private float averageSpeed;
    private float spentFuel;

    public TravelRoute() {
    }

    public int getId() {
        return id;
    }

    public Date getDateIssued() {
        return dateIssued;
    }

    public Time getTimeIssued() {
        return timeIssued;
    }

    public String getOrigin() {
        return origin;
    }

    public String getDestination() {
        return destination;
    }

    public float getKilometersTraveled() {
        return kilometersTraveled;
    }

    public float getAverageSpeed() {
        return averageSpeed;
    }

    public float getSpentFuel() {
        return spentFuel;
    }

    public String printToConsole() {
        return "Travel route: " + origin + " -> " + destination + "\n";
    }

    @Override
    public String toString() {
        return "TravelRoute{" +
                "id=" + id +
                ", dateIssued=" + dateIssued +
                ", timeIssued=" + timeIssued +
                ", origin='" + origin + '\'' +
                ", destination='" + destination + '\'' +
                ", kilometersTraveled=" + kilometersTraveled +
                ", averageSpeed=" + averageSpeed +
                ", spentFuel=" + spentFuel +
                '}';
    }
}
