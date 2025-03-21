using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using Photino.NET;
using RFGR.SaveEditor.Services;
using Sotsera.Blazor.Toaster.Core.Models;

namespace RFGR.SaveEditor;

internal class Program
{
    public static PhotinoWindow MainWindow { get; private set; } = null!;

    [STAThread]
    private static void Main(string[] args)
    {
        var builder = PhotinoBlazorAppBuilder.CreateDefault(args);
        var services = builder.Services;
        
        builder.RootComponents.Add<App>("app");

        services
            .AddScoped<SaveFileService>()
            .AddScoped<TabStateService>()
            .AddTransient<LocatorService>()
            .AddToaster(config =>
            {
                config.PositionClass = Defaults.Classes.Position.TopRight;
                config.PreventDuplicates = false;
                config.NewestOnTop = false;
                config.MaxDisplayedToasts = 10;
                config.ShowProgressBar = false;
                config.ShowCloseIcon = false;
                config.MaximumOpacity = 100;

                config.HideTransitionDuration = 200;
                config.ShowTransitionDuration = 200;
                
            });
        
        var app = builder.Build();
        
        var version = Assembly.GetExecutingAssembly()
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
        //var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString(3);
        var title = "RFGR.SaveEditor" + (version is null ? "" : $" (v{version})");
        
        MainWindow = app.MainWindow
            .SetTitle(title)
            .SetUseOsDefaultLocation(true)
            .SetWidth(850)
            .SetMinWidth(850)
            .SetHeight(550)
            .SetFileSystemAccessEnabled(true);
            
        AppDomain.CurrentDomain.UnhandledException += (_, error) =>
        {
            app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
        };
        
        app.Run();
    }
}