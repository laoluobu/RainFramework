namespace WMS.Data.Entity
{
    public class UserInfo 
    {
        public int Id { get; private set; }

        public string? Email { get; set; }

        public string? Nickname { get; set; }

        public bool IsDisable { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }
    }
}