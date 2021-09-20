using FirstTest.Core.Account;
using System.ComponentModel.DataAnnotations;

namespace FirstTest.Service.Account
{
    public class UserRegisterContent
    {
        /// <summary>
        /// 使用者名稱
        /// </summary>
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string UserName { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,30}$")]
        public string Password { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        [Required]
        public Gender Gender { get; set; }
    }
}