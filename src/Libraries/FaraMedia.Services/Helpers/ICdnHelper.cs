namespace FaraMedia.Services.Helpers {
    public interface ICdnHelper {
        string GetImagePath(string fileName);
        string GetStylePath(string fileName);
        string GetScriptPath(string fileName);
    }
}