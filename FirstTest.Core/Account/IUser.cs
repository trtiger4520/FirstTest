using System;

namespace FirstTest.Core.Account
{
    /// <summary>
    /// 使用者
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// 使用者ID
        /// </summary>
        Guid Id { get; set; }
        /// <summary>
        /// 使用者名稱
        /// </summary>
        string UserName { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// 完整名稱
        /// </summary>
        string[] FullName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        Address Address { get; set; }
        /// <summary>
        /// 電子郵件
        /// </summary>
        string Email { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        Gender Gender { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        DateTime DateOfBirth { get; set; }
        /// <summary>
        /// 已停用
        /// </summary>
        bool Deactivate { get; set; }
        /// <summary>
        /// 註冊時間
        /// </summary>
        DateTime RegistrationTime { get; set; }
    }
}
