using FirstTest.Core.Account;
using Microsoft.AspNetCore.Identity;
using System;

namespace FirstTest.WebServer.Model
{
    public class AppUser : IdentityUser<Guid>, IUser
    {
        /// <summary>
        /// 使用者ID
        /// </summary>
        public override Guid Id { get; set; }
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public override string UserName { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 完整名稱
        /// </summary>
        public string[] FullName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public Address Address { get; set; }
        /// <summary>
        /// 電子郵件
        /// </summary>
        public override string Email { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// 已停用
        /// </summary>
        public bool Deactivate { get; set; }
        /// <summary>
        /// 註冊時間
        /// </summary>
        public DateTime RegistrationTime { get; set; }
    }
}
