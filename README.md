# HuionKeydialSuite

This is custom driver suite for Huion KD100 keydial keyboard (https://store.huion.com/products/mini-keydial-kd100). I buy this device to speed-up coding and have shortcuts for IDE actions. 
However, drivers from manufacturer allow only to set simple keystroke (like "ctrl+s") - I need to send more advanced keystrokes (like "ctrl+k+d; ctrl+k+e; ctrl+s" on one click on keydial).

This is why I decided to build something custom.

This code is depending on virtual hid driver from tetherscript (https://github.com/tetherscript/hvdk) and genuine Huion low-level drivers.

# Getting started

* install HVDK drivers from tetherscript website (https://tetherscript.com/hid-driver-kit-download/)
* install Huion drivers form Huion website
* build code
* install windows service (InstallUtil HuionKeydialSuite.WindowsService.exe)
* configure key mappings in mapConfig.xml
* run windows service
* enjoy :)

#Key map config

Config is done via mapConfig.xml xml file. Windows service is loading this file only once, on start, so when you change mapping during service run, you need to restart windows service. 
Can be improved, but for me is enought.


