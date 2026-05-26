namespace InventorySystem.API.Model
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
