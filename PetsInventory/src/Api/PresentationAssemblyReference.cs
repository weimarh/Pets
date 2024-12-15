using System.Reflection;

namespace Api;

public class PresentationAssemblyReference
{
    internal static readonly Assembly Assembly = 
        typeof(PresentationAssemblyReference).Assembly;
}
