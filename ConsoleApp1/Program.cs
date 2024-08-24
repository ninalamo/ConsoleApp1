namespace ConsoleApp1
{
    public enum Action : int
    {
        CheckBalance = 1,
        DepositMoney = 2,
        WithdrawMoney = 3,
        Exit = 4
    }

    internal class Program
    {
        static int balance = 1000;

        static void Print(string message)
        {

           Console.WriteLine(message);
        }

        static Action Validate(string userInput)
        {
          
            try
            {
                Action result = Enum.Parse(typeof(Action), int.Parse(userInput));
                return result;
            }catch(Exception ex)
            {
                Console.WriteLine("Invalid input. Please try again.");
            }

            return Action.Exit;
        }

        static void CheckBalance()
        {
            Print($"Your balance is ₱{balance}");
        }

        static void DepositMoney()
        {
            Print("Enter the amount you want to deposit: ");
            int deposit = Convert.ToInt32(Console.ReadLine());
            balance += deposit;
            Print($"You have successfully deposited {deposit}. Your new balance is {balance}");
        }
        static void WithdrawMoney()
        {
            Print("Enter the amount you want to withdraw: ");
            int withdraw = Convert.ToInt32(Console.ReadLine());

            if (withdraw > balance)
            {
                Print("Insufficient funds!");
            }
            else
            {
                balance -= withdraw;
                Print($"You have successfully withdrawn {withdraw}. Your new balance is {balance}");
            }
        }

        static void Exit() 
        {
            Print("Thank you for using our ATM. Goodbye!");
            Environment.Exit(0);
        }
        public static void Main(string[] args)
        {
            Print("ATM Simulator");

          

            while (true)
            {
                Print("\n1 - Check Balance");
                Print("2 - Deposit Money");
                Print("3 - Withdraw Money");
                Print("4 - Exit");


                Print("Enter your choice: ");
                string choice = Console.ReadLine();

                var convertToEnum = Validate(choice!);

                if (convertToEnum ==  Action.CheckBalance)
                {
                    CheckBalance();
                }
                else if (convertToEnum == Action.DepositMoney)
                {
                    DepositMoney();
                }
                else if (convertToEnum == Action.WithdrawMoney)
                {
                    WithdrawMoney();
                }
                else if (convertToEnum == Action.Exit)
                {
                    Exit();
                }
          
            }
        }
    }
}
