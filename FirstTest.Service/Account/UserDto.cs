using FirstTest.Core.Account;
using System;

namespace FirstTest.Service.Account
{
    public class UserDto
    {
        /// <summary>
        /// 使用者ID
        /// </summary>
        public Guid Id { get; }
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 完整名稱
        /// </summary>
        public string[] FullName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public AddressDto Address { get; set; }
        /// <summary>
        /// 電子郵件
        /// </summary>
        public string Email { get; set; }
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
