using System.ComponentModel.DataAnnotations;

namespace Herman.Base.Authorization
{
    public class AccessDto
    {
        [Required(ErrorMessage ="请输入用户名")]
        public string Username { get; set; }

        [Required(ErrorMessage ="请输入密码")]

        public string Password { get; set; }

    }
}
