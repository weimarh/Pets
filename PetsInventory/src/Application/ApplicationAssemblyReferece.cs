using System.Reflection;

namespace Application;

public class ApplicationAssemblyReferece
{
    internal static readonly Assembly Assembly = 
        typeof(ApplicationAssemblyReferece).Assembly;
}
