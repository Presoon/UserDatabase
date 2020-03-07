﻿using System;
using System.Windows;
using System.Windows.Controls;


namespace UserDatabase
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int selection = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void sliderWiek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int wiek = Convert.ToInt32(sliderWiek.Value);
            labelWiek.Content = $"Wiek: {wiek}";
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            string imie = textBoxName.Text;
            string nazwisko = textBoxNazwisko.Text;
            int wiek = (int)sliderWiek.Value;

            listBoxUsers.Items.Add($"{imie} {nazwisko},{wiek}lat");

            textBoxName.Text = "";
            textBoxNazwisko.Text = "";
            labelWiek.Content = "Wiek: 21";
            sliderWiek.Value = Convert.ToInt32(21);
        }

        private void listBoxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selection = listBoxUsers.SelectedIndex;
            if (selection == -1) return;
            try
            {
                string tmp = listBoxUsers.SelectedItem.ToString();
                string imie = tmp.Substring(0, tmp.IndexOf(' '));
                string nazwisko = tmp.Substring(tmp.IndexOf(' ') + 1, tmp.IndexOf(',') - tmp.IndexOf(' ') - 1);
                string wiek = tmp.Substring(tmp.IndexOf(',') + 1, tmp.Length - tmp.IndexOf(',') - 4); ;
                    
                textBoxName.Text = $"{imie}";
                textBoxNazwisko.Text = $"{nazwisko}";
                labelWiek.Content = $"Wiek: {wiek}";
                sliderWiek.Value = Convert.ToInt32(wiek);
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd w odczycie danych!");
            }
        }

        private void buttonEdytuj_Click(object sender, RoutedEventArgs e)
        {
            string imie = textBoxName.Text;
            string nazwisko = textBoxNazwisko.Text;
            int wiek = (int)sliderWiek.Value;

            if (selection == -1) return;
            listBoxUsers.Items.RemoveAt(selection);
            listBoxUsers.Items.Add($"{imie} {nazwisko},{wiek}lat");
            selection = -1;
        }


    }
}
