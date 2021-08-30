using System;

namespace FirstTest.Core.Account
{
    /// <summary>
    /// 使用者
    /// </summary>
    public partial class User
    {
        private User()
        {
        }

        /// <summary>
        /// 使用者ID
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string UserName { get; set; }
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
    /// <summary>
    /// 性別
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// 男性
        /// </summary>
        Male,
        /// <summary>
        /// 女性
        /// </summary>
        Female,
        /// <summary>
        /// 通用
        /// </summary>
        Unisex
    }
}
