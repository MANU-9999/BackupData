package driverManagerFactory;

public class DriverManagerFactory {
    public static DriverManager getDriveManager(DriverType type) {
        DriverManager drivermanager;
        switch (type) {
            case CHROME:
                drivermanager = new ChromeDriverManager();
                break;

            case FIREFOX:
                drivermanager = new FireFoxDriverManager();
                break;

            default:
                drivermanager = new SafariDriverManager();
                break;
        }
        return drivermanager;
    }

}
