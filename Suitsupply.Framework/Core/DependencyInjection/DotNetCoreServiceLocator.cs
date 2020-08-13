namespace Suitsupply.Framework.Core.DependencyInjection
{
    public class DotNetCoreServiceLocator
    {
        public static void Initial(IDotNetCoreServiceLocator container)
        {
            Current = container;
        }

        public static IDotNetCoreServiceLocator Current { get; private set; }
    }
}
