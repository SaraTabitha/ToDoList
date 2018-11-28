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
using ToDoList.Classes;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for dashboard.xaml
    /// </summary>
    public partial class dashboard : Page
    {

        private ToDoUser user;
        private String username;


        public dashboard()
        {
            InitializeComponent();
        }

        public dashboard(ToDoUser user )
        {

            InitializeComponent();
            
        
            this.username = user.Name;
            setUsername( this.username);
        }

        private void setUsername(String username)
        {
           this.usernameText.Text = username;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void generateAllTasks()
        {
            //loop through tasks and display them on the dashboard
            //foreach(var task in )//in TaskList's List
            //{

            //}

        }


        private void createList(object sender, RoutedEventArgs e)
        {
            CreateList ct = new CreateList(user);
            NavigationService.Navigate(ct);

            //NavigationService nav = NavigationService.GetNavigationService(this);
           // nav.Navigate(new Uri("/GUI/CreateTask.xaml", UriKind.RelativeOrAbsolute));
        }

        private void taskClick(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("/GUI/CompleteTask.xaml", UriKind.RelativeOrAbsolute));
        }

       
        //need: +add button always goes to bottom of display

        //need: when lists are added, add a new RowDefinition (increase grid.rowspan on navyBackground & whiteBackground)
    }
}
