public static class AjaxRequest
{
    public static bool AjaxOnly(this HttpContext httpContext)
    {
        var Request = httpContext.Request;
        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        {
            return true;
        }
        return false;
    }
}