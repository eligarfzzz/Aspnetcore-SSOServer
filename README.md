# Aspnetcore-SSOServer
 SSO单点登录 服务器和JS Demo

### 服务器

服务器的用户名密码验证被硬编码，实际使用需要配置数据库

关键：

- HTTPS配置
- API跨域配置访问
- 写入cookie时跨域访问配置

### JS XmlHttpRequest

关键：`xhr.withCredentials = true;`使`xhr`发送时带上`cookie`

项目中的`./test/index.html `需要使用服务器加载，不能直接使用浏览器打开文件

服务器开启不同端口和域名即可模拟单点登录

```javascript
      function isLogin() {
        let xhr = new XMLHttpRequest();
        xhr.open("GET", "https://localhost:44344/api/login/Islogin");
        xhr.withCredentials = true;
        xhr.onreadystatechange=() => {
          if (xhr.readyState == 4 && xhr.status == 200) {
            console.log(xhr.responseText);
          }
        };
        xhr.send();
      }
      function login(){
        let xhr = new XMLHttpRequest();
        xhr.open("GET", "https://localhost:44344/api/login/login?Username=admin&Pwdmd5=md5");
        xhr.withCredentials = true;
        xhr.onreadystatechange=() => {
          if (xhr.readyState == 4 && xhr.status == 200) {
            console.log(xhr.responseText);
          }
        };
        xhr.send();
      }
```

