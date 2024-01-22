namespace EdTech
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            School_Management SYS = new School_Management();

            Login main = new Login(SYS);


            Application.Run(main);
        }
    }
}