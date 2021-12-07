namespace Herman.Base.Authorization
{
    public class AccessOutput
    {
        public string AccessToken { get; set; }
        public int ExpireSeconds { get; set; }

        public string UserName { get; set; }
    }
}
