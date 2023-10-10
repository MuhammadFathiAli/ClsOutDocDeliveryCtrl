using ClsOutDocDeliveryCtrl.Context;
using ClsOutDocDeliveryCtrl.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClsOutDocDeliveryCtrl
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
            PrepareDatabase();
            Application.Run(new frm_StartUp());
        }

        static void PrepareDatabase()
        {
            try
            {
                using (var context = new AppDBContext())
                {
                    context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}