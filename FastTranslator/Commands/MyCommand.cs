using System.Linq;

namespace FastTranslator
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var docView = await VS.Documents.GetActiveDocumentViewAsync();
            var selection = docView?.TextView.Selection.SelectedSpans.FirstOrDefault();

            if (selection.HasValue)
            {
                VsShellUtilities.OpenBrowser("https://translate.google.com/?hl=ru&sl=en&tl=ru&text=" + selection.Value.ToString());
            }
        }
    }
}
