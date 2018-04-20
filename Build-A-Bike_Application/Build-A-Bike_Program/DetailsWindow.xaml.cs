// Kieran Burns
// Last edit: 23/03/2018
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Build_A_Bike_Program
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {

        private Customer currentCustomer;
        private double depositCost;

        public DetailsWindow(Customer customer, double totalCost)
        {
            InitializeComponent();

            currentCustomer = customer;
            depositCost = totalCost / 10;

            depositLabel.Content = "A deposit of £" + depositCost.ToString("0.00") + " (10 % of total cost) \n is required on this order.";

        }

        private void completeButton_Click(object sender, RoutedEventArgs e)
        {
            int errors = 0;

            if (nameBox.Text.Equals(""))
            {
                errors++;
            }

            if (addressBox.Text.Equals(""))
            {
                errors++;
            }

            if (emailBox.Text.Equals(""))
            {
                errors++;
            }

            if (errors == 0)
            {
                currentCustomer.Name = nameBox.Text;
                currentCustomer.Address = addressBox.Text;
                currentCustomer.Email = emailBox.Text;

                try
                {
                    Int32.Parse(cardNoBox.Text);
                    Int32.Parse(cvcBox.Text);
                    if(!cardNameBox.Text.Equals(""))
                    {
                        //This is where the program would request the funds from the bank, a YesNo box is used here instead for demonstration purposes.
                        MessageBoxResult bankPrompt = MessageBox.Show("Confirm Payment?", "Bank Prompt", MessageBoxButton.YesNo);
                        if(bankPrompt == MessageBoxResult.Yes)
                        {
                            MessageBox.Show("Payment Success! Thank you for using our service!");

                            //This is where the currentCustomer would be saved to some form of order database to be processed and completed if the program were to continue further.
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Payment declined! Please try another method or cancel order!");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(
                        "Invalid input within the payment details section, please ensure none of the fields are empty and that the card number and cvc fields contain no letters then try again!");
                }   
            }
            else
            {
                MessageBox.Show("Invalid input within the personal details section, please ensure none of the fields are empty then try again!");
            }

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
