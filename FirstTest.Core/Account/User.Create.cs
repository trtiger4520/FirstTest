using System;

namespace FirstTest.Core.Account
{

    /// <summary>
    /// 使用者
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// 建立使用者
        /// </summary>
        /// <param name="userName">帳號</param>
        /// <param name="password">密碼</param>
        /// <param name="gender">性別</param>
        /// <returns></returns>
        public static User CreateUser(
            string userName,
            string password,
            Gender gender)
        {
            return new User()
            {
                Id = GenerateUserId(),
                UserName = userName,
                Password = password,
                Gender = gender,
                RegistrationTime = DateTime.Now
            };
        }
        /// <summary>
        /// 建立使用者
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="fullName"></param>
        /// <param name="address"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="email"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static User CreateUser(
            string userName,
            string password,
            string[] fullName,
            Address address,
            DateTime dateOfBirth,
            string email,
            Gender gender)
        {
            return new User()
            {
                Id = GenerateUserId(),
                UserName = userName,
                Password = password,
                Gender = gender,
                FullName = fullName,
                Address = address,
                DateOfBirth = dateOfBirth,
                Email = email,
                RegistrationTime = DateTime.Now
            };
        }
        /// <summary>
        /// 產生使用者ID
        /// </summary>
        /// <returns></returns>
        private static Guid GenerateUserId()
        {
            return Guid.NewGuid();
        }
    }
}
