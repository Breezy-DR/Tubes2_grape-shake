using WinFormsApp1;
namespace src;

static class Program
{
    [STAThread]
    static void Main()
    {
        // Menjalankan GUI
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }    
}