using System;

namespace Orleans.Http.Abstractions
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Method, AllowMultiple = true)]
    public class RouteAttribute : Attribute
    {
        public string Pattern { get; private set; }
        public string Name { get; private set; }

        public RouteAttribute(string pattern = "", string name = "")
        {
            this.Pattern = pattern;
            this.Name = name;
        }
    }

    public abstract class MethodAttribute : Attribute
    {
        public abstract string Method { get; }
        public string Pattern { get; private set; }
        public string Name { get; private set; }

        public MethodAttribute(string pattern = "", string name = "")
        {
            this.Pattern = pattern;
            this.Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class HttpGetAttribute : MethodAttribute
    {
        public override string Method { get => "GET"; }
        public HttpGetAttribute(string pattern = "", string name = "") : base(pattern, name) { }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class HttpPostAttribute : MethodAttribute
    {
        public override string Method { get => "POST"; }
        public HttpPostAttribute(string pattern = "", string name = "") : base(pattern, name) { }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class HttpPutAttribute : MethodAttribute
    {
        public override string Method { get => "PUT"; }
        public HttpPutAttribute(string pattern = "", string name = "") : base(pattern, name) { }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class HttpDeleteAttribute : MethodAttribute
    {
        public override string Method { get => "DELETE"; }
        public HttpDeleteAttribute(string pattern = "", string name = "") : base(pattern, name) { }
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class FromBodyAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class FromQueryAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AuthorizeAttribute : Attribute
    {
        public AuthorizeAttribute() { }
        public AuthorizeAttribute(string policy) { this.Policy = policy; }
        public string AuthenticationSchemes { get; set; }
        public string Policy { get; set; }
        public string Roles { get; set; }
    }
}