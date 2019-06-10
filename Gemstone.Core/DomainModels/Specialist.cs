namespace Gemstone.Core.DomainModels
{
    /// <summary>
    /// Represents a Specialist web app user
    /// </summary>
    public class Specialist : Account
    {
        public string CraftAreaName { get; set; }
        public bool IsBusy { get; set; }
    }
}