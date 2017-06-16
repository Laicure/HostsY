# HostsY
Just a simplified and multi-threaded revamp of [HostsX](http://github.com/Laicure/HostsX) for Windows.

###### Auto Parameters (requires admin privileges):
Required:
* \-auto
	* Initializes Auto Generate State
	* Directly replaces the hosts file in **C:\\Windows\\System32\\drivers\\etc**
	* Requires Data folder beside the app
		* Must have the **source.txt** that contains the _host sources_
		* Optional: **black.txt** for domain _blacklist_
		* Optional: **white.txt** for domain _whitelist_
```
HostsY.exe
Data
\black.txt
\source.txt
\white.txt
```

Optional:
* \-sort
	* Sorts the Domains (ascending; source-wise)
* \-tab
	* Uses tab instead of spaces between Target IP and Domain Name
* \-logs
	* Generate generation logs; auto-generates a logs.txt file
* \-IPv6
	* [experimental] Generate with IPv6 variant (doubles the file size)
* \-min
	* removes most of the generated comments
* \-zip
	* Generates a zipped hosts file inside the Data folder

~~------------------------------~~

Added [my custom list](https://github.com/Laicure/HostsY/blob/master/custHost) here (pop-ups, ads, malware sites that I stumble upon; for concerns, please don't hesitate to create a [new issue](https://github.com/Laicure/HostsY/issues) :D

~~------------------------------~~

##### Weekly Updated Generated custom host file _with whitelist_:
```
https://bitbucket.org/Laicure/publicview/downloads/hosts
```
##### Weekly Updated Generated hosts file from [StevenBlack/hosts' main sources](https://github.com/StevenBlack/hosts/tree/master/data) _with no whitelist_:
```
https://bitbucket.org/Laicure/publicview/downloads/hosts2
```
##### Weekly Updated Generated hosts file from [hpHosts](https://hosts-file.net/?s=Download) (Individual Classifications merged) _with no whitelist_:
```
https://bitbucket.org/Laicure/publicview/downloads/hosts3
```
##### Weekly Updated Generated hosts file from [StevenBlack/hosts' main sources](https://github.com/StevenBlack/hosts/tree/master/data) and [hpHosts](https://hosts-file.net/?s=Download) _with no whitelist_:
```
https://bitbucket.org/Laicure/publicview/downloads/hosts4
```

###### Other sources can be found from AdAway's [wiki](https://github.com/AdAway/AdAway/wiki/HostsSources)
