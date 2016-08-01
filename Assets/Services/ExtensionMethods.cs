using System.Text;

namespace Assets.Services
{
    public static class ExtensionMethods
    {
        public static void Clear(this StringBuilder value)
        {
            value.Length = 0;
            value.Capacity = 0;
        }
    }
}
