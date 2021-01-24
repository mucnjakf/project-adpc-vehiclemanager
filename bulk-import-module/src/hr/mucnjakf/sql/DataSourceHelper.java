package hr.mucnjakf.sql;

import com.microsoft.sqlserver.jdbc.SQLServerDataSource;

import javax.sql.DataSource;

public class DataSourceHelper {

    public static DataSource createDataSource(){

        SQLServerDataSource dataSource = new SQLServerDataSource();

        dataSource.setServerName("vehiclemanager.database.windows.net");
        dataSource.setDatabaseName("VehicleManagerDB");
        dataSource.setUser("vehicleManagerAdmin");
        dataSource.setPassword("0vehicleManagerPassword0");

        return dataSource;
    }
}
