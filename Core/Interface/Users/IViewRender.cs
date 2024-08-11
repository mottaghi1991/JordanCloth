namespace Core.Interface.Users
{
    public interface IViewRender
    {
        string RenderToStringAsync(string viewName, object model);

    }
}