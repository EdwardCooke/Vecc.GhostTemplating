namespace Vecc.GhostTemplating
{
    public class NavigationPart
    {
        public bool RenderSitename { get; set; }
        public Header Header { get; set; }

        public NavigationPart(bool renderSitename, IGetHeader header)
        {
            RenderSitename = renderSitename;
            Header = header.GetHeader();
        }
    }
}
