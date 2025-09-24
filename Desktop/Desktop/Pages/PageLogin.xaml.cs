using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Desktop.Pages
{
    public partial class PageLogin : Page
    {
        private bool _isAnimating = false;

        public PageLogin()
        {
            InitializeComponent();
        }

        private async void BtnSignup_Click(object sender, RoutedEventArgs e)
        {
            if (_isAnimating) return;
            _isAnimating = true;
            
            var fadeOutLoginRight = (Storyboard)FindResource("FadeOut");
            fadeOutLoginRight.Begin(StackLoginRigth);

            var fadeOutLoginLeft = (Storyboard)FindResource("FadeOut");
            fadeOutLoginLeft.Begin(StackLoginLeft);

            await Task.Delay(200);

            StackLoginLeft.Visibility = Visibility.Collapsed;
            StackLoginRigth.Visibility = Visibility.Collapsed;

            StackSignupLeft.Visibility = Visibility.Visible;
            StackSignupRigth.Visibility = Visibility.Visible;

            var slideLeft = (Storyboard)FindResource("SlideLeftToRight");
            slideLeft.Begin(StackSignupRigth);

            var slideRight = (Storyboard)FindResource("SlideRightToLeft");
            slideRight.Begin(StackSignupLeft);

            await Task.Delay(300);
            _isAnimating = false;
        }

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (_isAnimating) return;
            _isAnimating = true;

            var fadeOutSignupRight = (Storyboard)FindResource("FadeOut");
            fadeOutSignupRight.Begin(StackSignupRigth);

            var fadeOutSignupLeft = (Storyboard)FindResource("FadeOut");
            fadeOutSignupLeft.Begin(StackSignupLeft);

            await Task.Delay(200);

            StackSignupLeft.Visibility = Visibility.Collapsed;
            StackSignupRigth.Visibility = Visibility.Collapsed;

            StackLoginLeft.Visibility = Visibility.Visible;
            StackLoginRigth.Visibility = Visibility.Visible;

            var slideLeft = (Storyboard)FindResource("SlideLeftToRight");
            slideLeft.Begin(StackLoginLeft);

            var slideRight = (Storyboard)FindResource("SlideRightToLeft");
            slideRight.Begin(StackLoginRigth);

            await Task.Delay(300);
            _isAnimating = false;
        }
    }
}