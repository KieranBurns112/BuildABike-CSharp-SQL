// Kieran Burns
// Last edit: 23/03/2018
//
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Build_A_Bike_Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Create the variables used for the order.
        private Customer currentCustomer = new Customer();
        private Bike currentBike;
        private int bikeNo = 1;
        double totalCost;

        public MainWindow()
        {
            InitializeComponent();

            //Call the method to create the first bike on the order.
            NewBike();

            //Call the output areas boxes to be filled with their default values.
            RefreshBoxes();

            //Call the method to load the available part selection.
            LoadOptions();
        }

        private String QueryDB(String queryString)
        {
            //Set up the connection to the database where each parts information is stored.
            SqlConnection partsDatabase = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =\"|DataDirectory|\\BikeParts.mdf\"; Integrated Security = True");
            SqlCommand command;
            SqlDataReader reader;

            //Open the linked database, query it for the requested query, close the linked database and then retrun the first (and what should be only) result.
            partsDatabase.Open();
            command = new SqlCommand(queryString, partsDatabase);
            reader = command.ExecuteReader();
            reader.Read();
            String returnValue = reader[0].ToString();
            partsDatabase.Close();
            return returnValue;
        }


        private void DataError(string errorArea)
        {
            //Display a message prompt if the program does not have any parts sored in the selected table.
            MessageBox.Show("There is no part data available in the '" + errorArea + "' data table, please fix this then try again.");

            //Terminate the program.
            Close();
        }

        private void LoadOptions()
        {
            //Set up the dropdown box content for the bike frame size selection.
            frameSizeBox.Items.Add("<Select Part>");
            frameSizeBox.SelectedIndex = 0;
            try
            {
                int sizesCount = Int32.Parse(QueryDB("SELECT COUNT(SizeNo) FROM Frame_Size"));
                if (sizesCount != 0)
                {
                    for (int sizesLoop = 1; sizesLoop <= sizesCount; sizesLoop++)
                    {
                        String currentSize = QueryDB("SELECT SizeName FROM Frame_Size WHERE SizeNo=" + sizesLoop);
                        frameSizeBox.Items.Add(currentSize);
                    }
                }
                else
                {
                    DataError("Frame_Size");
                }
            }
            catch
            {
                DataError("Frame_Size");
            }

            //Set up the dropdown box content for the bike frame colour selection.
            frameColourBox.Items.Add("<Select Part>");
            frameColourBox.SelectedIndex = 0;
            try
            {
                int colourCount = Int32.Parse(QueryDB("SELECT COUNT(ColourNo) FROM Frame_Colour"));
                if (colourCount != 0)
                {
                    for (int colourLoop = 1; colourLoop <= colourCount; colourLoop++)
                    {
                        String currentColour = QueryDB("SELECT ColourName FROM Frame_Colour WHERE ColourNo=" + colourLoop);
                        frameColourBox.Items.Add(currentColour);
                    }
                }
                else
                {
                    DataError("GroupSet_Gears");
                }
            }
            catch
            {
                DataError("Frame_Colour");
            }

            //Set up the dropdown box content for the bike gears selection.
            groupSetGearsBox.Items.Add("<Select Part>");
            groupSetGearsBox.SelectedIndex = 0;
            try
            {
                int gearsCount = Int32.Parse(QueryDB("SELECT COUNT(GearsNo) FROM GroupSet_Gears"));
                if (gearsCount != 0)
                {
                    for (int gearsLoop = 1; gearsLoop <= gearsCount; gearsLoop++)
                    {
                        String currentGears = QueryDB("SELECT GearsName FROM GroupSet_Gears WHERE GearsNo=" + gearsLoop);
                        groupSetGearsBox.Items.Add(currentGears);
                    }
                }
                else
                {
                    DataError("GroupSet_Gears");
                }
            }
            catch
            {
                DataError("GroupSet_Gears");
            }

            //Set up the dropdown box content for the bike brakes selection.
            groupSetBrakesBox.Items.Add("<Select Part>");
            groupSetBrakesBox.SelectedIndex = 0;
            try
            {
                int brakesCount = Int32.Parse(QueryDB("SELECT COUNT(BrakesNo) FROM GroupSet_Brakes"));
                if (brakesCount != 0)
                {
                    for (int brakesLoop = 1; brakesLoop <= brakesCount; brakesLoop++)
                    {
                        String currentBrakes = QueryDB("SELECT BrakesName FROM GroupSet_Brakes WHERE BrakesNo=" + brakesLoop);
                        groupSetBrakesBox.Items.Add(currentBrakes);
                    }
                }
                else
                {
                    DataError("GroupSet_Brakes");
                }
            }
            catch
            {
                DataError("GroupSet_Brakes");
            }

            //Set up the dropdown box content for the bike wheels selection.
            wheelsBox.Items.Add("<Select Part>");
            wheelsBox.SelectedIndex = 0;
            try
            {
                int wheelsCount = Int32.Parse(QueryDB("SELECT COUNT(WheelsNo) FROM Bike_Wheels"));
                if (wheelsCount != 0)
                {
                    for (int wheelsLoop = 1; wheelsLoop <= wheelsCount; wheelsLoop++)
                    {
                        String currentWheels = QueryDB("SELECT WheelsName FROM Bike_Wheels WHERE WheelsNo=" + wheelsLoop);
                        wheelsBox.Items.Add(currentWheels);
                    }
                }
                else
                {
                    DataError("Bike_Wheels");
                }
            }
            catch
            {
                DataError("Bike_Wheels");
            }

            //Set up the dropdown box content for the bike handlebars selection.
            handlebarsBox.Items.Add("<Select Part>");
            handlebarsBox.SelectedIndex = 0;
            try
            {
                int handlebarsCount = Int32.Parse(QueryDB("SELECT COUNT(HandlebarsNo) FROM FinishingSet_Handlebars"));
                if (handlebarsCount != 0)
                {
                    for (int handlebarsLoop = 1; handlebarsLoop <= handlebarsCount; handlebarsLoop++)
                    {
                        String currentHandlebars = QueryDB("SELECT HandlebarsName FROM FinishingSet_Handlebars WHERE HandlebarsNo=" + handlebarsLoop);
                        handlebarsBox.Items.Add(currentHandlebars);
                    }
                }
                else
                {
                    DataError("FinishingSet_Handlebars");
                }
            }
            catch
            {
                DataError("FinishingSet_Handlebars");
            }

            //Set up the dropdown box content for the bike saddle selection.
            saddleBox.Items.Add("<Select Part>");
            saddleBox.SelectedIndex = 0;
            try
            {
                int saddleCount = Int32.Parse(QueryDB("SELECT COUNT(SaddleNo) FROM FinishingSet_Saddle"));
                if (saddleCount != 0)
                {
                    for (int saddleLoop = 1; saddleLoop <= saddleCount; saddleLoop++)
                    {
                        String currentSaddle = QueryDB("SELECT SaddleName FROM FinishingSet_Saddle WHERE SaddleNo=" + saddleLoop);
                        saddleBox.Items.Add(currentSaddle);
                    }
                }
                else
                {
                    DataError("FinishingSet_Saddle");
                }
            }
            catch
            {
                DataError("FinishingSet_Saddle");
            }
        }

        private void NewBike()
        {
            //Create a new Bike, assign it a bike no, add it to the customers order and then allow it to be edited with parts.
            currentBike = new Bike();
            currentBike.Bike_No = bikeNo;
            currentBike.ExtendedWarranty = false;
            currentCustomer.Bikes.Add(currentBike);
            currentBike = currentCustomer.findBike(bikeNo);
            bikeNo++;
        }

        private bool isBikeComplete()
        {
            bool isComplete = false;

            //Check each field has been filled out
            if (currentBike.Frame_Size != 0 && currentBike.Frame_Colour != 0 && currentBike.GroupSet_Gears != 0
                && currentBike.GroupSet_Brakes != 0 && currentBike.Wheels != 0 && currentBike.FinishingSet_Handlebars != 0 
                && currentBike.FinishingSet_Saddle != 0)
            {
                isComplete = true;
            }

            return isComplete;
        }

        private void RefreshBoxes()
        {
            //Set the part boxes to the values of the current bike.
            bikeNoLabel.Content = "Bike " + currentBike.Bike_No + " Component Select:";
            frameSizeBox.SelectedIndex = currentBike.Frame_Size;
            frameColourBox.SelectedIndex = currentBike.Frame_Colour;
            groupSetGearsBox.SelectedIndex = currentBike.GroupSet_Gears;
            groupSetBrakesBox.SelectedIndex = currentBike.GroupSet_Brakes;
            wheelsBox.SelectedIndex = currentBike.Wheels;
            handlebarsBox.SelectedIndex = currentBike.FinishingSet_Handlebars;
            saddleBox.SelectedIndex = currentBike.FinishingSet_Saddle;
            if(currentBike.ExtendedWarranty)
            {
                warrantyCheck.IsChecked = true;
            }
            else
            {
                warrantyCheck.IsChecked = false;
            }

            //Clear the existing items from the cost and time boxes to be replaced with the new values.
            costBreakdown.Items.Clear();
            timeBreakdown.Items.Clear();
 
            //Reset the total cost counter.
            totalCost = 0;
            costBreakdown.Items.Add("Price Breakdown:");
            int totalTime = 0;
            timeBreakdown.Items.Add("Time Breakdown:");

            //Fill the cost and time breakdown boxs and calculate the current total cost and time by looping through all bikes the customer has ordered.
            for (int bikes = 1; bikes < bikeNo; bikes++)
            {
                Bike bikeDetails = currentCustomer.findBike(bikes);
                costBreakdown.Items.Add("Bike " + bikes + "-");

                String partName;
                String partCost;
                double singleBikeCost = 0;
                int singleBikeTime = 0;
                int singlePartTime = 0;

                if (bikeDetails.Frame_Size != 0)
                {
                    partName = QueryDB("SELECT SizeName FROM Frame_Size WHERE SizeNo=" + bikeDetails.Frame_Size);
                    partCost = QueryDB("SELECT Price FROM Frame_Size WHERE SizeNo=" + bikeDetails.Frame_Size);
                    singleBikeCost += double.Parse(partCost);
                    singlePartTime = Int32.Parse(QueryDB("SELECT Time FROM Frame_Size WHERE SizeNo=" + bikeDetails.Frame_Size));
                    if (singlePartTime > singleBikeTime)
                    {
                        singleBikeTime = singlePartTime;
                    }
                    costBreakdown.Items.Add(partName + " frame - £" + partCost);
                }

                if (bikeDetails.Frame_Colour != 0)
                {
                    partName = QueryDB("SELECT ColourName FROM Frame_Colour WHERE ColourNo=" + bikeDetails.Frame_Colour);
                    partCost = QueryDB("SELECT Price FROM Frame_Colour WHERE ColourNo=" + bikeDetails.Frame_Colour);
                    singleBikeCost += double.Parse(partCost);
                    singlePartTime = Int32.Parse(QueryDB("SELECT Time FROM Frame_Colour WHERE ColourNo=" + bikeDetails.Frame_Colour));
                    if (singlePartTime > singleBikeTime)
                    {
                        singleBikeTime = singlePartTime;
                    }
                    costBreakdown.Items.Add(partName + " frame colour - £" + partCost);
                }

                if (bikeDetails.GroupSet_Gears != 0)
                {
                    partName = QueryDB("SELECT GearsName FROM GroupSet_Gears WHERE GearsNo=" + bikeDetails.GroupSet_Gears);
                    partCost = QueryDB("SELECT Price FROM GroupSet_Gears WHERE GearsNo=" + bikeDetails.GroupSet_Gears);
                    singleBikeCost += double.Parse(partCost);
                    singlePartTime = Int32.Parse(QueryDB("SELECT Time FROM GroupSet_Gears WHERE GearsNo=" + bikeDetails.GroupSet_Gears));
                    if (singlePartTime > singleBikeTime)
                    {
                        singleBikeTime = singlePartTime;
                    }
                    costBreakdown.Items.Add(partName + " gears - £" + partCost);
                }

                if (bikeDetails.GroupSet_Brakes != 0)
                {
                    partName = QueryDB("SELECT BrakesName FROM GroupSet_Brakes WHERE BrakesNo=" + bikeDetails.GroupSet_Brakes);
                    partCost = QueryDB("SELECT Price FROM GroupSet_Brakes WHERE BrakesNo=" + bikeDetails.GroupSet_Brakes);
                    singleBikeCost += double.Parse(partCost);
                    singlePartTime = Int32.Parse(QueryDB("SELECT Time FROM GroupSet_Brakes WHERE BrakesNo=" + bikeDetails.GroupSet_Brakes));
                    if (singlePartTime > singleBikeTime)
                    {
                        singleBikeTime = singlePartTime;
                    }
                    costBreakdown.Items.Add(partName + " brakes - £" + partCost);
                }

                if (bikeDetails.Wheels != 0)
                {
                    partName = QueryDB("SELECT WheelsName FROM Bike_Wheels WHERE WheelsNo=" + bikeDetails.Wheels);
                    partCost = QueryDB("SELECT Price FROM Bike_Wheels WHERE WheelsNo=" + bikeDetails.Wheels);
                    singleBikeCost += double.Parse(partCost);
                    singlePartTime = Int32.Parse(QueryDB("SELECT Time FROM Bike_Wheels WHERE WheelsNo=" + bikeDetails.Wheels));
                    if (singlePartTime > singleBikeTime)
                    {
                        singleBikeTime = singlePartTime;
                    }
                    costBreakdown.Items.Add(partName + " wheels - £" + partCost);
                }

                if (bikeDetails.FinishingSet_Handlebars != 0)
                {
                    partName = QueryDB("SELECT HandlebarsName FROM FinishingSet_Handlebars WHERE HandlebarsNo=" + bikeDetails.FinishingSet_Handlebars);
                    partCost = QueryDB("SELECT Price FROM FinishingSet_Handlebars WHERE HandlebarsNo=" + bikeDetails.FinishingSet_Handlebars);
                    singleBikeCost += double.Parse(partCost);
                    singlePartTime = Int32.Parse(QueryDB("SELECT Time FROM FinishingSet_Handlebars WHERE HandlebarsNo=" + bikeDetails.FinishingSet_Handlebars));
                    if (singlePartTime > singleBikeTime)
                    {
                        singleBikeTime = singlePartTime;
                    }
                    costBreakdown.Items.Add(partName + " handlebars - £" + partCost);
                }

                if (bikeDetails.FinishingSet_Saddle != 0)
                {
                    partName = QueryDB("SELECT SaddleName FROM FinishingSet_Saddle WHERE SaddleNo=" + bikeDetails.FinishingSet_Saddle);
                    partCost = QueryDB("SELECT Price FROM FinishingSet_Saddle WHERE SaddleNo=" + bikeDetails.FinishingSet_Saddle);
                    singleBikeCost += double.Parse(partCost);
                    singlePartTime = Int32.Parse(QueryDB("SELECT Time FROM FinishingSet_Saddle WHERE SaddleNo=" + bikeDetails.FinishingSet_Saddle));
                    if (singlePartTime > singleBikeTime)
                    {
                        singleBikeTime = singlePartTime;
                    }
                    costBreakdown.Items.Add(partName + " saddle - £" + partCost);
                }

                if (bikeDetails.ExtendedWarranty)
                {
                    costBreakdown.Items.Add("Extended Warranty - £50");
                    singleBikeCost += 50;
                }

                costBreakdown.Items.Add("Building and Testing - £100");
                singleBikeCost += 100;
                costBreakdown.Items.Add(" ");
                costBreakdown.Items.Add("Bike " + bikeDetails.Bike_No + " total - £" + singleBikeCost);
                totalCost += singleBikeCost;
                costBreakdown.Items.Add(" ");
                costBreakdown.Items.Add(" ");

                if (singleBikeTime > totalTime)
                {
                    totalTime = singleBikeTime;
                }

                timeBreakdown.Items.Add("Bike " + bikeDetails.Bike_No + " Building and testing - Half a day");
            }
            if (totalTime != 0)
            {
                if (totalTime == 1)
                {
                    timeBreakdown.Items.Add("Parts delivery - 1 day");
                }
                else
                {
                    timeBreakdown.Items.Add("Parts delivery - " + totalTime + " days");
                }
            }

            totalTime += (bikeNo/2);

            //Display the calculated total cost and total time.
            costOut.Text = "Total Cost: £" + totalCost.ToString("0.00");
            if (totalTime == 1)
            {
                timeOut.Text = "Delivery Time: 1 Day";
            }
            else
            {
                timeOut.Text = "Delivery Time: " + totalTime + " Days";
            }
        }


        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            //Terminate the program.
            Close();
        }

        private void frameSizeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentBike.Frame_Size = frameSizeBox.SelectedIndex;
            RefreshBoxes();
        }

        private void frameColourBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentBike.Frame_Colour = frameColourBox.SelectedIndex;
            RefreshBoxes();
        }

        private void groupSetGearsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentBike.GroupSet_Gears = groupSetGearsBox.SelectedIndex;
            RefreshBoxes();
        }

        private void groupSetBrakesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentBike.GroupSet_Brakes = groupSetBrakesBox.SelectedIndex;
            RefreshBoxes();
        }

        private void wheelsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentBike.Wheels= wheelsBox.SelectedIndex;
            RefreshBoxes();
        }

        private void handlebarsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentBike.FinishingSet_Handlebars = handlebarsBox.SelectedIndex;
            RefreshBoxes();
        }

        private void saddleBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentBike.FinishingSet_Saddle = saddleBox.SelectedIndex;
            RefreshBoxes();
        }

        private void warrantyCheck_Clicked(object sender, RoutedEventArgs e)
        {
            if (warrantyCheck.IsChecked.Equals(true))
            {
                currentBike.ExtendedWarranty = true;
            }
            else
            {
                currentBike.ExtendedWarranty = false;
            }

            RefreshBoxes();
        }

        private void addBike_Click(object sender, RoutedEventArgs e)
        {
            bool bikeComplete = isBikeComplete();
            if (bikeComplete == true)
            {
                if (bikeNo > (currentBike.Bike_No + 1))
                {
                    currentBike = currentCustomer.findBike(currentBike.Bike_No + 1);
                }
                else
                {
                    NewBike();
                }
                RefreshBoxes();
            }
            else
            {
                MessageBox.Show("Current bike is incomplete, please select an option for each componant");
            }
        }

        private void lastBike_Click(object sender, RoutedEventArgs e)
        {
            if (currentBike.Bike_No > 1)
            {
                currentBike = currentCustomer.findBike(currentBike.Bike_No - 1);
            }
            else
            {
                MessageBox.Show("There are no previous bikes to load");
            }
            RefreshBoxes();
        }

        private void agreeButton_Click(object sender, RoutedEventArgs e)
        {
            bool bikeComplete = isBikeComplete();
            if (bikeComplete == true)
            {
                DetailsWindow nextWindow = new DetailsWindow(currentCustomer, totalCost);
                nextWindow.Show();
                Close();         
            }
            else
            {
                MessageBox.Show("Current bike is incomplete, please select an option for each componant");
            }
        }
    }
}
