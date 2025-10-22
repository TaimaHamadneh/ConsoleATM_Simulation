


public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;            
    }
    public string getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public string getFirstName()
    {
        return firstName;
    }
    public string getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }

    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }
    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options: ");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Widthdrow");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine($"Thank you for your $$. Your new balance is: {currentUser.getBalance()}");

        }
        void Widthdrow(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to widthdrow? ");
            double widthdrowl = Double.Parse(Console.ReadLine());
            //Check if the user has enugh money:
            if(currentUser.getBalance() < widthdrowl)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - widthdrowl);
                Console.WriteLine("You're good to go! Thank you :)");

            }

        }
        void balance(cardHolder currentUser)
        {
            Console.WriteLine($"Current balance: {currentUser.getBalance()}");
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4532772818527395", 1234, "Taima", "Hama", 1500.31));
        cardHolders.Add(new cardHolder("4532666818632595", 4321, "Muneeb", "Jones", 321.13));
        cardHolders.Add(new cardHolder("5263859900224395", 9985, "Frida", "Dickerson", 105.59));
        cardHolders.Add(new cardHolder("6085554141127395", 2563, "Ashley", "Harding", 851.84));
        cardHolders.Add(new cardHolder("3490693053739511", 4826, "John", "Griffith", 160.31));
        cardHolders.Add(new cardHolder("4532789888889962", 2468, "Dawn", "Smith", 54.27));


        // prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if( currentUser != null) { break;  }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
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
            }
            catch
            {
                Console.WriteLine("Incorrect Pin. Please try again");
            }
        }
        Console.WriteLine($"Welcome {currentUser.getFirstName()} :)");
        int option = 0;
        do {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());

            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { Widthdrow(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");

    }
}