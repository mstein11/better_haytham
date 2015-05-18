@echo off

FOR /R . %%X IN (obj) DO (RD /S /Q "%%X" 2>nul)
FOR /R . %%X IN (Debug) DO (RD /S /Q "%%X" 2>nul)