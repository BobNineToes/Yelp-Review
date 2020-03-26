﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;

namespace Team4_YelpProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Business
        {
            public string name { get; set; }
            public string state { get; set; }
            public string city { get; set; }
            public string bid { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            addState();
            addGridColumns();
        }

        private string buildConnectionString()
        {
            return "Host = localhost; Username = postgres; Database = milestone1db; password = spiffy";
        }

        private void addState()
        {
            using (var connection = new NpgsqlConnection(buildConnectionString()))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT distinct state FROM business ORDER BY state";

                    try
                    {
                        var reader = cmd.ExecuteReader();
                        //while (reader.Read())
                            //stateList.Items.Add(reader.GetString(0));
                    }
                    catch (NpgsqlException ex)
                    {
                        System.Windows.MessageBox.Show("SQL Error - " + ex.Message.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void addGridColumns()
        {
            DataGridTextColumn col1 = new DataGridTextColumn();
            col1.Binding = new Binding("name");
            col1.Header = "Business Name";
            col1.Width = 255;
            //businessGrid.Columns.Add(col1);

            DataGridTextColumn col2 = new DataGridTextColumn();
            col2.Binding = new Binding("state");
            col2.Header = "State";
            col2.Width = 60;
            //businessGrid.Columns.Add(col2);

            DataGridTextColumn col3 = new DataGridTextColumn();
            col3.Binding = new Binding("city");
            col3.Header = "City";
            col3.Width = 150;
            //businessGrid.Columns.Add(col3);

            DataGridTextColumn col4 = new DataGridTextColumn();
            col4.Binding = new Binding("bid");
            col4.Header = "";
            col4.Width = 0;
            //businessGrid.Columns.Add(col4);
        }

        private void executeQuery(string sqlstr, Action<NpgsqlDataReader> myf)
        {
            using (var connection = new NpgsqlConnection(buildConnectionString()))
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = sqlstr;

                    try
                    {
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                            myf(reader);
                    }
                    catch (NpgsqlException ex)
                    {
                        System.Windows.MessageBox.Show("SQL Error - " + ex.Message.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void addGridRow(NpgsqlDataReader R)
        {
            //businessGrid.Items.Add(new Business() { name = R.GetString(0), state = R.GetString(1), city = R.GetString(2), bid = R.GetString(3) });

        }

        private void addCity(NpgsqlDataReader R)
        {
            //cityList.Items.Add(R.GetString(0));
        }

        private void stateList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //cityList.Items.Clear();
            //if (stateList.SelectedIndex >= 0)
            //{
            //    string sqlStr = "SELECT distinct city FROM business WHERE state = '" + stateList.SelectedItem.ToString() + "' ORDER BY city";
            //    executeQuery(sqlStr, addCity);
            //}
        }

        private void cityList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //businessGrid.Items.Clear();
            //if (cityList.SelectedIndex >= 0)
            //{
            //    string sqlStr = "SELECT name, state, city, business_id FROM business WHERE state = '" + stateList.SelectedItem.ToString() + "' AND city = '" + cityList.SelectedItem.ToString() + "' ORDER BY name";
            //    executeQuery(sqlStr, addGridRow);
            //}
        }

        private void businessGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (businessGrid.SelectedIndex >= 0)
            //{
            //    Business B = businessGrid.Items[businessGrid.SelectedIndex] as Business;
            //    if ((B.bid != null) && (B.bid.ToString().CompareTo("") != 0))
            //    {
            //        Window1 businessWindow = new Window1(B.bid.ToString());
            //        businessWindow.Show();
            //    }
            //}
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (UserNameTextBox.Text == "")
            {

            }
            else
            {
                UserNameTextBox.Background = Brushes.White;

            }
        }

        private void UserIDListBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}
    }
}
