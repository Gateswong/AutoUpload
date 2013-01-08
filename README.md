# 文件自动上传FTP工具

监视某个特定的目录，并将新文件上传到FTP服务器中。

## 可以使用的占位符：

%file% - 文件名

%year%, %month%, %day%, %hour%, %minute%, %second% - 日期时间

%client user% - 本地用户名

%server user% - FTP登录名

%random(x)% - 一个1到x的随机数，x必须是整数并且大于1。

%md5% - MD5 Hash

## 注意

编译好的文件需要将FlagFTP.dll和FlagFTP.xml放到程序同一目录下。

## 引用的项目

### FlagFTP
https://github.com/flagbug/FlagFtp

### SilkCompanion1 Icon Sets
http://damieng.com/creative/icons/silk-companion-1-icons