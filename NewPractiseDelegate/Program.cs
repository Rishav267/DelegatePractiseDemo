using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPractiseDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            //c1
            Account acc1 = new Account();
            //subscribe for email
            acc1.subscription += Alert.Mail;
            acc1.Deposit(5000);
            //acc1.subscription("Deposited 9999999");

            //c2
            Account acc2 = new Account();
            //subscribe for sms
            acc1.subscription += Alert.Mail;
            acc1.subscription += Alert.SMS;

            acc1.subscription -= Alert.Mail;
            acc1.subscription += Alert.WhatsApp;
            acc2.Deposit(1000);
            acc2.Withdraw(400);

            //c3
            Account acc3 = new Account();
            //subscribe for email+sms
            acc3.Deposit(10000);

            //c4
            Account acc4 = new Account();
            // no subscribtion
            acc4.Deposit(10000);
        }

        public void Method(string action,double amount,string subs)
        {
            Account acc1 = new Account();
            //subscribe for email
            acc1.subscription += Alert.Mail;
            acc1.Deposit(5000);
            //acc1.subscription("Deposited 9999999");
        }
    }

    public delegate void Subscription(string message);
    class Account
    {
        public double Balance { get; set; }
        public event Subscription subscription;
        public void Deposit(double amt)
        {
            Balance += amt;
            if (subscription != null)
                subscription("Deposited " + amt);
        }

        public void Withdraw(double amt)
        {
            Balance -= amt;
            if (subscription != null)
                subscription("Withdrawn " + amt);
        }
    }

    class Alert
    {
        public static void Mail(string msg)
        {
            Console.WriteLine("Mail : " + msg);
        }

        public static void SMS(string msg)
        {
            Console.WriteLine("SMS : " + msg);
        }

        public static void WhatsApp(string msg)
        {
            Console.WriteLine("WhatsApp : " + msg);
        }
    }
}
