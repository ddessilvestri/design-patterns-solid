
public class Main {
    public static void main(String[] args){
        UserRegistrationService service = new UserRegistrationService();
        service.register("user@example.com", "sourcepassword");
    }
}