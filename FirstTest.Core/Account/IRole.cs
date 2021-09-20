using System;

namespace FirstTest.Core.Account
{
    public interface IRole
    {
        /// <summary>
        /// 使用者ID
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// 使用者名稱
        /// </summary>
        string Name { get; set; }
    }
}
