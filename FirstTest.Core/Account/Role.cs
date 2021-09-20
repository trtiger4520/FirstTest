using System;

namespace FirstTest.Core.Account
{
    public class Role : IRole
    {
        /// <summary>
        /// 使用者ID
        /// </summary>
        public Guid Id { get; }
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string Name { get; set; }
    }
}
