using Music.WPF.Commands;
using SimpleInjector;
using System;


namespace Music.WPF
{

    static class Program
    {
        [STAThread]
        static void Main()
        {
            var container = Bootstrap();

            RunApplication(container);
        }

        private static Container Bootstrap()
        {
            var container = new Container();

            container.Register<MainWindowModel>();
            container.Register<DischiGridCommands>();

            container.Verify();

            return container;
        }

        private static void RunApplication(Container container)
        {
            try
            {
                var app = new App();
                app.InitializeComponent();
                var mainWindow = container.GetInstance<MainWindow>();
                app.Run(mainWindow);
            }
            catch (Exception ex)
            {
                //Log the exception and exit
            }
        }
    }
}
