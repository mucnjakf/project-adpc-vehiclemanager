package hr.mucnjakf.sql;

import hr.mucnjakf.models.*;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import java.util.List;
import java.util.logging.Level;

public class SqlRepository {

    private final EntityManagerFactory emf = Persistence.createEntityManagerFactory("vehicleManager");
    private EntityManager em = null;

    public List<TravelWarrant> getTravelWarrants() {
        List<TravelWarrant> travelWarrants = null;

        try {
            em = emf.createEntityManager();
            em.getTransaction().begin();

            Query getTravelWarrantsJPQL = em.createQuery("select travelWarrant from TravelWarrant as travelWarrant", TravelWarrant.class);

            travelWarrants = getTravelWarrantsJPQL.getResultList();

            em.getTransaction().commit();
        } catch (Exception e) {
            e.printStackTrace();
            emf.close();
        } finally {
            if (em != null) {
                em.close();
            }
        }
        return travelWarrants;
    }

    public TravelWarrant getTravelWarrant(int id) {
        TravelWarrant travelWarrant = new TravelWarrant();

        try {
            em = emf.createEntityManager();
            em.getTransaction().begin();

            travelWarrant = em.find(TravelWarrant.class, id);

            em.getTransaction().commit();
        } catch (Exception e) {
            e.printStackTrace();
            emf.close();
        } finally {
            if (em != null) {
                em.close();
            }
        }
        return travelWarrant;
    }

    public Driver getDriver(int id) {
        Driver driver = new Driver();

        try {
            em = emf.createEntityManager();
            em.getTransaction().begin();

            driver = em.find(Driver.class, id);

            em.getTransaction().commit();
        } catch (Exception e) {
            e.printStackTrace();
            emf.close();
        } finally {
            if (em != null) {
                em.close();
            }
        }
        return driver;
    }

    public Vehicle getVehicle(int id) {
        Vehicle vehicle = new Vehicle();

        try {
            em = emf.createEntityManager();
            em.getTransaction().begin();

            vehicle = em.find(Vehicle.class, id);

            em.getTransaction().commit();
        } catch (Exception e) {
            e.printStackTrace();
            emf.close();
        } finally {
            if (em != null) {
                em.close();
            }
        }
        return vehicle;
    }

    public FuelCost getFuelCost(int id) {
        FuelCost fuelCost = new FuelCost();

        try {
            em = emf.createEntityManager();
            em.getTransaction().begin();

            fuelCost = em.find(FuelCost.class, id);

            em.getTransaction().commit();
        } catch (Exception e) {
            e.printStackTrace();
            emf.close();
        } finally {
            if (em != null) {
                em.close();
            }
        }
        return fuelCost;
    }

    public TravelRoute getTravelRoute(int id) {
        TravelRoute travelRoute = new TravelRoute();

        try {
            em = emf.createEntityManager();
            em.getTransaction().begin();

            travelRoute = em.find(TravelRoute.class, id);

            em.getTransaction().commit();
        } catch (Exception e) {
            e.printStackTrace();
            emf.close();
        } finally {
            if (em != null) {
                em.close();
            }
        }
        return travelRoute;
    }
}




















