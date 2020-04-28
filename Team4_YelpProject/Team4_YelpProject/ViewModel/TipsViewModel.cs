﻿namespace Team4_YelpProject.ViewModel
{
    using Team4_YelpProject.Commands;
    using Team4_YelpProject.Model;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System;
    using Team4_YelpProject.View;

    public class TipsViewModel : INotifyPropertyChanged
    {
        YelpServices ObjYelpService;
        private Business ObjBusiness;
        private YelpUser ObjUser;

        public TipsViewModel(Business B, YelpUser U)
        {
            ObjYelpService = new YelpServices();
            ObjBusiness = B;
            ObjUser = U;
            Console.WriteLine(ObjBusiness.BusinessName);
            Console.WriteLine(ObjUser.Name);
            LoadBusinessTips();
            LoadFriendsList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        #region Load Business Tips Grid
        private ObservableCollection<Tips> tipsList;
        public ObservableCollection<Tips> TipsList
        {
            get { return tipsList; }
            set { tipsList = value; OnPropertyChanged("TipsList"); }
        }

        private void LoadBusinessTips()
        {
            TipsList = new ObservableCollection<Tips>(ObjYelpService.GetTips(ObjBusiness.BusinessID));
            Console.WriteLine(TipsList.Count);
        }

        #endregion

        #region Load Friends Grid
        private ObservableCollection<Tips> friendTipsList;
        public ObservableCollection<Tips> FriendTipsList
        {
            get { return friendTipsList; }
            set { friendTipsList = value; OnPropertyChanged("FriendTipsList"); }
        }

        private void LoadFriendsList()
        {
            FriendTipsList = new ObservableCollection<Tips>(ObjYelpService.GetFriendTips(ObjBusiness.BusinessID, ObjUser.User_id));
            Console.WriteLine(FriendTipsList.Count);
        }
        #endregion
    }
}