﻿%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe WindowsService.exe
Net Start ServiceTest
sc config ServiceTest start= auto
pause