using BurgerShop.Model;
using BurgerShop.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using BurgerShop.ViewModel;


namespace BurgerSpot.ViewModel
{
    public class LandingViewModel : BaseViewModel
    {
        public LandingViewModel()
        {
            burgers = GetBurgers();
        }

        ObservableCollection<Burger> burgers;
        public ObservableCollection<Burger> Burgers
        {
            get { return burgers; }
            set
            {
                burgers = value;
                OnPropertyChanged();
            }
        }

        private Burger selectedBurger;
        public Burger SelectedBurger
        {
            get { return selectedBurger; }
            set
            {
                selectedBurger = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(DisplayBurger);

        private void DisplayBurger()
        {
            if (selectedBurger != null)
            {
                var viewModel = new DetailsViewModels { SelectedBurger = selectedBurger, Burgers = burgers, Position = burgers.IndexOf(selectedBurger) };
                var detailsPage = new DetailsPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);
            }
        }

        private ObservableCollection<Burger> GetBurgers()
        {
            return new ObservableCollection<Burger>
            {
                new Burger { Name = "CLASSIC", Price = 20.99f, Image = "classic.png", Description = "Classic bacon burger with melted cheesse, lettuce and tomatoes"},
                new Burger { Name = "DOUBLE", Price = 21.99f, Image = "doublpatty.png", Description = "Double beef patty with mayonnase and lettuce"},
                new Burger { Name = "SHARK", Price = 16.29f, Image = "shark.png", Description = "Combined with beef and bacon meat with cheese, lettuce and tomatoes"},
                new Burger { Name = "CHICKEN", Price = 18.99f, Image = "Chicken-burger.jpeg", Description = "Classic healthy chicken burger"},
                new Burger { Name = "MEAT", Price = 23.99f, Image = "meat.png", Description = "Double Patty with melted cheese and bbq sauc"},
                new Burger { Name = "BBQ", Price = 16.99f, Image = "bbq.png", Description = "Single beef patty, with tomatoes, lettuce, mustard ketchup and onions"}
            };
        }
    }
}
