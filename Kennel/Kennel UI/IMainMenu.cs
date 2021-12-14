namespace Kennel
{
    public interface IMainMenu
    {
        bool IsRunning { get; set; }
        string menuOption { get; set; }

        public void Menu();
    }
}