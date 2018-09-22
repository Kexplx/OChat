using System.Windows.Media;

namespace OChat.ClientUI1.ViewModels
{
    internal class UserView
    {
        public string Name
        {
            get;
            set;
        }

        public Brush Color
        {
            get;
            set;
        }

        public string FontWeight
        {
            get;
            set;
        } = "Normal";
    }
}
