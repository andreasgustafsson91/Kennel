using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel
{
    public class Application : IApplication
    {
        IMainMenu MainMenu;
        


        public Application(IMainMenu mainMenu)
        {
            MainMenu = mainMenu;
            
        }

        public void Run()
        {
            MainMenu.Menu();
            Factory factory = new Factory();
            
        }
    }
}
