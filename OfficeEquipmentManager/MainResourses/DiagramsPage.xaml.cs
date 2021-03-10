﻿
using OfficeEquipmentManager.LocalDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting;

namespace OfficeEquipmentManager.MainResourses
{
    /// <summary>
    /// Interaction logic for DiagramsPage.xaml
    /// </summary>
    public partial class DiagramsPage : Page
    {
        public DiagramsPage()
        {
            InitializeComponent();

            DataContext = new ViewModel.ApplicationViewModel();
            List<EquipmentCategory> categories = ContextConnector.db.EquipmentCategory.ToList();
            List<Equipment> equipment = ContextConnector.db.Equipment.ToList();
            int count = 0;
            series.Name = "Категория оргтехники";
            for (int i = 0; i < categories.Count(); i++)
            {
                count = equipment.Count(x => x.EquipmentCategory.Name == categories[i].Name);

                series.Points.AddXY(categories[i].Name, count);
            }
        }
        void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Frames.MainFrame.GoBack();
        }

        private void comboDiagramTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            series.ChartType = (SeriesChartType)comboDiagramTypes.SelectedItem;
        }
    }
}