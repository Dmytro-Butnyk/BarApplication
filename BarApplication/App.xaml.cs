using System.Net.NetworkInformation;
using System.Windows;

namespace BarApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (!IsInternetAvailable())
            {
                MessageBox.Show("No internet connection detected. The application will now exit.", "Internet Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Current.Shutdown();
            }
        }

        private bool IsInternetAvailable()
        {
            try
            {
                if (!NetworkInterface.GetIsNetworkAvailable())
                    return false;

                using (var ping = new Ping())
                {
                    var reply = ping.Send("www.google.com", 3000);
                    return reply.Status == IPStatus.Success;
                }
            }
            catch
            {
                return false;
            }
        }

    }

}
