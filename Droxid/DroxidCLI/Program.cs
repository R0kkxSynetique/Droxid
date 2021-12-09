using System;
using Droxid.ViewModel;

namespace DroxidCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            UserViewModel userViewModel = new UserViewModel();

            userViewModel.GetUserByUsername("asd");
        }
    }
}
