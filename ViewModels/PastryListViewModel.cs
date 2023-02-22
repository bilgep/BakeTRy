using BakeTRy.Models;

namespace BakeTRy.ViewModels
{
    public class PastryListViewModel
    {
        public IEnumerable<Pastry> Pastries { get; }
        public string CurrentCategory { get; set; }
        public PastryListViewModel(IEnumerable<Pastry> pastries, string currentCategory)
        {
            Pastries = pastries;
            CurrentCategory = currentCategory;
        }




    }
}
