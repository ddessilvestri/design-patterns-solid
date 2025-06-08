
// Bad example: Violates SRP by mixing validation, storage, and notifications
class UserService{
    public void register(String email, String password){
        if (!email.contains("@")){
            throw new IllegalArgumentException("Invalid email address");
        }

        System.out.println("Saving user to database...");
        System.out.println("Sending welcome email...");

    }
}


// Good example: Each class has a single responsability

class EmailValidator {
    public boolean isValid(String email){
        return email.contains("@");
    }
}

class UserRepository{
    public void save(String email, String password){
        System.out.println("Saving user to database...");
    }
}

class EmailSender{
    public void sendWelcomeEmail(String email){
        System.out.println("Sending welcome email");
    }
}


class UserRegistrationService{
    private EmailValidator validator = new EmailValidator();
    private UserRepository repository = new UserRepository();
    private EmailSender emailSender = new EmailSender();

    public void register(String email, String password){
        if (!validator.isValid(email)){
            throw new IllegalArgumentException("Invalid email address");
        }

        repository.save(email, password);
        emailSender.sendWelcomeEmail(email);
    }
}
