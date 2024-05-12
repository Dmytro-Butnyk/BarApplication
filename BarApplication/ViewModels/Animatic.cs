using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;

namespace BarApplication.ViewModels
{
    public class Animatic
    {
        private static Animatic? instance;
        private static Border _updateElement = null!;
        protected Animatic()
        {

        }
        public static void SetElement(Border updateElement)
        {
            _updateElement = updateElement;
        }
        public static Animatic Instance()
        {
            if (instance == null)
                instance = new Animatic();
            return instance;
        }
        public static void Show(int from, int to)
        {
            _updateElement.Visibility = Visibility.Visible;
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = from;
            animation.To = to;
            animation.Duration = TimeSpan.FromSeconds(0.4);
            _updateElement.BeginAnimation(Grid.WidthProperty, animation);
        }
        public static void Show(int from, int to, float seconds)
        {
            _updateElement.Visibility = Visibility.Visible;
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = from;
            animation.To = to;
            animation.Duration = TimeSpan.FromSeconds(seconds);
            _updateElement.BeginAnimation(Grid.WidthProperty, animation);
        }
        public static void Show(double from, double to, bool isLeftToRight, float seconds)
        {
            _updateElement.Visibility = Visibility.Visible;
            ThicknessAnimation animation = new ThicknessAnimation();
            animation.Duration = TimeSpan.FromSeconds(seconds);

            if (isLeftToRight)
            {
                animation.From = new Thickness(-from, 0, to, 0);
                animation.To = new Thickness(0, 0, 0, 0);
            }
            else
            {
                animation.From = new Thickness(from, 0, -to, 0);
                animation.To = new Thickness(0, 0, 0, 0);
            }

            _updateElement.BeginAnimation(Border.MarginProperty, animation);
        }
        public static void Hide()
        {
        }
    }
}
