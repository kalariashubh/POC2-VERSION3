@echo off
echo ======================================
echo Starting SVF → AutoCAD Automation
echo ======================================

REM Start backend
echo Starting backend server...
start cmd /k "cd server && node server.js"

REM Give backend time to start
timeout /t 3 >nul

REM Start AutoCAD Automation Agent
echo Starting AutoCAD Runner...
start cmd /k "cd autocad-runner\AutoCadRunner\bin\x64\Release && AutoCadRunner.exe"

REM Open browser
timeout /t 2 >nul
start http://localhost:3000

echo ======================================
echo System is READY
echo ======================================
