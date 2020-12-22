using System;

namespace WebServices
{
    public class LoginService
    {
        public const string AccountUserTokenCookieKey = "AccountUserToken";
        /// <summary>
        /// login
        /// 省略了数据库验证，实际项目需要添加数据库
        /// </summary>
        /// <param name="username">账户名</param>
        /// <param name="pwdmd5">密码的MD5</param>
        /// <param name="token">token</param>
        /// <returns>是否登录成功</returns>
        public bool Login(string username, string pwdmd5, out string token)
        {
            if (username == "admin" && pwdmd5 == "md5")
            {
                token = "token";
                return true;
            }
            else
            {
                token = null;
                return false;
            }
        }

        public bool IsTokenAvalible(string v)
        {
            throw new NotImplementedException();
        }
    }
}
