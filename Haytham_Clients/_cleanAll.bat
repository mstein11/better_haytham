@echo off

FOR /R . %%X IN (obj) DO (RD /S /Q "%%X" 2>nul)
FOR /R . %%X IN (bin) DO (RD /S /Q "%%X" 2>nul)