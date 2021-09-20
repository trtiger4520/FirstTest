using System;

namespace FirstTest.Service.Account
{
    public class RoleDto
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
