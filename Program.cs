// See https://aka.ms/new-console-template for more information


public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum,int pin,string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;

    }

    public String getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public String getFirstName()
    {
        return firstName;
    }
    public String getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }
    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(String newFristName)
    {
       firstName = newFristName;
    }
    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }
    
    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Change Pin");
            Console.WriteLine("5. Exit");
        }
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance()+"\n");
        }
        void changePin(cardHolder currentUser)
        {
            Console.WriteLine("Please Enter your new pin: ");
            int pin = int.Parse(Console.ReadLine());
            int confirmPin = 0;
            do
            {
                Console.WriteLine("Please confirm new pin");
                confirmPin = int.Parse(Console.ReadLine());
                if (confirmPin == pin)
                {
                    currentUser.setPin(pin);
                    
                }
                else
                {
                    Console.WriteLine("New pin does not match:");
                }
            }while (pin != confirmPin);
            Console.WriteLine("Pin Changed!\n");


        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //check if user has enough
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficent Balance");
            }
            else
            {

                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're all set!");
            }
        }
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("5544900001", 1234, "John", "Potter", 2041.42));
        cardHolders.Add(new cardHolder("5544900002", 5678, "Ashley", "Dohner", 1021.32));
        cardHolders.Add(new cardHolder("5544900003", 9874, "Muchi", "Vang", 61.32));
        cardHolders.Add(new cardHolder("5544900003", 9874, "Frank", "Stauerg", 156582.32));

        // Prompt User
        Console.WriteLine("-----------------------\nWelcome to Zeek Bank ATM\n-----------------------");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;
        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check agains our DB
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }

            }
            catch
            { Console.WriteLine("Card not recognized. Please try again"); }
        }
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect Pin. Please try again"); }
            }catch { Console.WriteLine("Incorrect Pin. Please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser);}
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { changePin(currentUser); }
            else if (option == 5) { break; }
            else { option = 0; }

        }
        while (option != 5);
        Console.WriteLine("Have a nice day");
        
    }
}