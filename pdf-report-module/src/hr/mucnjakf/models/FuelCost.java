package hr.mucnjakf.models;

import javax.persistence.Embeddable;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import java.math.BigDecimal;
import java.sql.Date;
import java.sql.Time;

@Embeddable
@Entity
@Table(name = "FuelCosts")
public class FuelCost {
    @Id
    private int id;
    private Date dateIssued;
    private Time timeIssued;
    private String position;
    private float amount;
    private BigDecimal price;

    public FuelCost() {
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

    public String getPosition() {
        return position;
    }

    public float getAmount() {
        return amount;
    }

    public BigDecimal getPrice() {
        return price;
    }

    public String printToConsole() {
        return "Fuel cost: " + position + " - $" + price;
    }

    @Override
    public String toString() {
        return "FuelCost{" +
                "id=" + id +
                ", dateIssued=" + dateIssued +
                ", timeIssued=" + timeIssued +
                ", position='" + position + '\'' +
                ", amount=" + amount +
                ", price=" + price +
                '}';
    }
}
