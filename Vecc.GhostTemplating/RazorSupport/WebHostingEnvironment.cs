using Microsoft.Extensions.FileProviders;

namespace Vecc.GhostTemplating.RazorSupport
{
    public class WebHostingEnvironment : IWebHostEnvironment
    {
        public string WebRootPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IFileProvider WebRootFileProvider { get; set; } = new PhysicalFileProvider(Environment.CurrentDirectory);
        public string ApplicationName { get; set; } = "Vecc.GhostTemplating";
        public IFileProvider ContentRootFileProvider { get; set; } = new PhysicalFileProvider(Environment.CurrentDirectory);
        public string ContentRootPath { get; set; } = Environment.CurrentDirectory;
        public string EnvironmentName { get; set; } = "Production";
    }
}
