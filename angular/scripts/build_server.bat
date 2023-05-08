@echo off

del im-web-server.zip

md im-web-server
md im-web-server\server

xcopy /s/e ..\aspnet-core\src\tmss.Web.Host\bin\Release\netcoreapp3.1\publish im-web-server\server /EXCLUDE:scripts\list.txt

"C:\Program Files\7-Zip\7z.exe" a im-web-server.zip .\im-web-server\*

rd /s/q im-web-server
