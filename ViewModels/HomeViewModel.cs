using BakeTRy.Models;

namespace BakeTRy.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pastry> HomePagePastries { get; }
        public HomeViewModel(IEnumerable<Pastry> homePastries)
        {
            HomePagePastries = homePastries;
        }

        
    }
}
