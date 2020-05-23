namespace Com.OPPO.Mo.Identity
{
    public class IdentityRoleNameChangedEvent
    {
        public IdentityRole IdentityRole { get; set; }
        public string OldName { get; set; }
    }
}
