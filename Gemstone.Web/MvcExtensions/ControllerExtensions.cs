namespace Gemstone.Web.MvcExtensions
{
    public static class ControllerExtensions
    {
        public static string Short(this string controllerName)
        {
            return (controllerName as string).Replace("Controller", "");
        }
    }
}