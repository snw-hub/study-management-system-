using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyLibrary;
using System.Collections.Generic;
using System.Windows;
using System;
using System.Text.RegularExpressions;

namespace Task_1
{
    /// <summary>
    /// doubleeraction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<fetchDetails> userDetails = new List<fetchDetails>();
        private int hoursRemaining;

        public MainWindow()
        {
            InitializeComponent();
            Calendar.SelectedDate = DateTime.Today;
            logDateSelected.SelectedDate = DateTime.Today;
        }


        //When this button is clicked Everything is cleared on the textboxes and it usues the liubrar
        private void addDetails_Clicked(object sender, RoutedEventArgs e)
        {
            string classHoursPerWeek = txtClassHoursPerWeek.Text;
            string numOfCredits = txtNumberOfCredits.Text;
            string numberOfWeeks = txtNumberOfWeeks.Text;
            double credits;
            double weeks;
            double hoursPerWeek;


            if (double.TryParse(numOfCredits, out credits) && double.TryParse(classHoursPerWeek, out hoursPerWeek) && double.TryParse(numberOfWeeks, out weeks))
            {
                userDetails.Add(new fetchDetails()
                {
                    module_code = txtCode.Text,
                    module_name = txtName.Text,
                    number_of_credits = credits,
                    start_date = (DateTime)Calendar.SelectedDate,
                    number_of_weeks = weeks,
                    class_hours_per_week = hoursPerWeek
                });
            }
            else
            {
                MessageBox.Show("Please Input Your Details");
            }

            display();
            txtCode.Text = "";
            txtName.Text = "";
            txtNumberOfCredits.Text = "";
            txtClassHoursPerWeek.Text = "";
            txtNumberOfWeeks.Text = "";
            txtNumberOfHours.Text = "";

            for (int i = 0; i < list_of_added_modules.Items.Count; i++)
            {
                list_of_added_modules.Items.RemoveAt(i);
            }

            foreach (fetchDetails m in userDetails)
            {
                list_of_added_modules.Items.Add(m.module_name);

            }

        }



        //Method for displaying on the display screen when modules are added
        private void display()
        {
            studyCalculations studyCalc;

            lblDisplayScreen.Content = "Code \tName \t\t\tCredits \tClass hours\tNumber of weeks\t\tStart Date\t\tStudy hours per week for module \n" +
                                       "--------------------------------------------------------------------------------------------------------------------------------------------------------------\n";

            foreach (fetchDetails userdatails in userDetails)
            {
                studyCalc = new studyCalculations(userdatails.number_of_credits, userdatails.class_hours_per_week, userdatails.number_of_weeks);
                lblDisplayScreen.Content += $"{userdatails.module_code} \t{userdatails.module_name} \t\t\t{userdatails.number_of_credits} \t {userdatails.class_hours_per_week} hours \t\t{userdatails.number_of_weeks} weeks \t\t{userdatails.start_date}\t{studyCalc.study_hours_calculations()} hours\n";

            }
        }


        //This button shows the hours remaining for the selected Module
        private void btnShowRemainingHours_isClicked(object sender, RoutedEventArgs e)
        {
            studyCalculations studyCalc;
            if (int.TryParse(txtNumberOfHours.Text, out hoursRemaining))
            {
                if (txtNumberOfHours.Text == "")
                {
                    MessageBox.Show("Ensure the Number of Hours tab is not empty");
                }
                else
                {
                    foreach (fetchDetails de in userDetails)
                    {
                        if (list_of_added_modules.SelectedItem.ToString() == de.module_name)
                        {
                            studyCalc = new studyCalculations(de.number_of_credits, de.class_hours_per_week, de.number_of_credits);

                            display_remaining_hours.Content = $"*********************************************\n" +
                                $"Hours Remaining for {list_of_added_modules.SelectedItem.ToString()} are: \n\n";
                            display_remaining_hours.Content += $"{ studyCalc.study_hours_calculations() - int.Parse(txtNumberOfHours.Text)} hours\n" +
                                $" *********************************************";
                        }
                        else
                        {
                            MessageBox.Show("Please Select a Module");
                        }
                    }
                }

            }
        }

        private void txtNumberOfWeeks_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
            if (new Regex("[^0-9]+").IsMatch(e.Text))
            {
                MessageBox.Show("Please insert integers only");
            }
        }

        private void txtNumberOfCredits_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
            if (new Regex("[^0-9]+").IsMatch(e.Text))
            {
                MessageBox.Show("Please insert integers only");
            }
        }

        private void txtNumberOfHours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
            if (new Regex("[^0-9]+").IsMatch(e.Text))
            {
                MessageBox.Show("Please insert integers only");
            }
        }
    }
}