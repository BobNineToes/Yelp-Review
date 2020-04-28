﻿namespace Team4_YelpProject.View
{
    using System.Windows;
    using Team4_YelpProject.Model;
    using Team4_YelpProject.ViewModel;

    /// <summary>
    /// Interaction logic for BusinessTipsView.xaml
    /// </summary>
    public partial class BusinessTipsView : Window
    {
        TipsViewModel tipsViewModel;

        public BusinessTipsView(Business B, YelpUser U)
        {
            InitializeComponent();
            tipsViewModel = new TipsViewModel(B, U);
            this.DataContext = tipsViewModel;
        }
    }
}
