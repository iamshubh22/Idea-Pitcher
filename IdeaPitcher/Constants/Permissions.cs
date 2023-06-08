namespace IdeaPitcher.Constants
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.SuperAmin",
                $"Permissions.{module}.TeamMapping",
                $"Permissions.{module}.EnableDisable",
                $"Permissions.{module}.FactorAuthentication",
                $"Permissions.{module}.ChangeIdea",
                $"Permissions.{module}.PromoteIdea",
            };
        }

        public static class AccessIdea
        {
            public const string SuperAdmin = "Permissions.AccessIdea.SuperAdmin";
            public const string TeamMapping = "Permissions.AccessIdea.TeamMapping";
            public const string EnableDisable = "Permissions.AccessIdea.EnableDisable";
            public const string FactorAuthentication = "Permissions.AccessIdea.FactorAuthentication";
            public const string ChangeIdea = "Permissions.AccessIdea.ChangeIdea";
            public const string PromoteIdea = "Permissions.AccessIdea.PromoteIdea";
        }
    }
}
