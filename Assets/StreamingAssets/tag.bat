@echo off
echo name:feeddog
echo version:v3.1
echo type:general
echo.

git checkout master 
git pull 
echo. 
 
git add -A
git commit -m "v3.1"
git push 
echo.

git tag -d v3.1
git push origin :v3.1
git tag v3.1
git push origin v3.1
echo. 

git log --decorate -3