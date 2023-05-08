@echo off

REM build app production
call npm run publish

del im-web-client.zip

"C:\Program Files\7-Zip\7z.exe" a im-web-client.zip .\dist
