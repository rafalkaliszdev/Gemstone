namespace Gemstone.Core.Enums
{
    public enum AccountRole
    {
        None = 0, // required - otherwise implicit Assignor role can cause shadow issues
        Assignor,
        Specialist
    }
}