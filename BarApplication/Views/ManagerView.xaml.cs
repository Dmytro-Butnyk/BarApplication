﻿using BarApplication.ViewModels.ManVM;
using System.Windows.Controls;

namespace BarApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для ManagerView.xaml
    /// </summary>
    public partial class ManagerView : Page
    {
        public ManagerView()
        {
            InitializeComponent();
            DataContext = new ManagerViewModel();
        }
    }
}
