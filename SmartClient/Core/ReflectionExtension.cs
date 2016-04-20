namespace Core
{
    using System.ComponentModel;
    using System.Reflection;

    public static class ReflectionExtension
    {
        public static string Description(this MemberInfo member)
        {
            var descriptions = (DescriptionAttribute[])member.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptions.Length == 0)
            {
                return member.Name;
            }

            return descriptions[0].Description;
        }

        public static string Description(this object self)
        {
            return self?.GetType().Description();
        }
    }
}
