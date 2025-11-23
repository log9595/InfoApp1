namespace InfoApp
{
    public class UserInstance
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public UserAccessLevel AccessLevel { get; set; } = UserAccessLevel.Read;
    }
}
