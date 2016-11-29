namespace SampleFramework.Shared.Constants
{
    public struct DocTypeAliases
    {
        public struct HomePage
        {
            public const string Alias = "homePage";
        }

        public struct NewsletterFolder
        {
            public const string Alias = "newsletterFolder";
        }

        public struct Newsletter
        {
            public const string Alias = "newsletter";

            public struct Properties
            {
                public const string Email = "email";
            }
        }
    }
}
