namespace BulkDeleteUtil;

static class Program {
	[STAThread]
	static void Main(){
		ApplicationConfiguration.Initialize();
		Application.EnableVisualStyles();
		Application.SetHighDpiMode(HighDpiMode.SystemAware);
		Application.Run(new MainForm());
	}    
}
