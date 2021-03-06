namespace OM.App
{
    public interface IShell
    {

        void ShowTab<T>(bool show = true, bool allowMuti = false) where T : BaseVM;

        void ShowTab<T>(T vm, bool show = true, bool allowMuti = false) where T : BaseVM;
    }
}