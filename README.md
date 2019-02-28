# HostsY
<a href="https://github.com/Laicure/HostsY/releases/latest"><img src="https://img.shields.io/github/downloads/Laicure/HostsY/total.svg"></img></a>

Simple hosts file compiler for Windows.
_Inspired by [Steven Black](https://github.com/StevenBlack)'s [hosts repository](https://github.com/StevenBlack/hosts)._

###### Minimum Requirement: [.NET v4.5.2](https://www.microsoft.com/en/download/details.aspx?id=42642)

#### Auto Parameters (requires admin privileges):
Required:
* \-auto
	* Initializes Auto Generate State
	* Directly replaces the hosts file in **C:\\Windows\\System32\\drivers\\etc**
	* Requires a **Data** folder beside the app
		* Required: **source.txt** for the _host sources_
		* Optional: **black.txt** for domain _blacklist_
		* Optional: **white.txt** for domain _whitelist_
		* Optional: **loopback.txt** for domain _loopbacks_
```
HostsY.exe
Data
----\black.txt
----\source.txt
----\white.txt
----\loopback.txt
```

###### Possible loopbacks:
```
0.0.0.0
broadcasthost
ip6-allhosts
ip6-allnodes
ip6-allrouters
ip6-localhost
ip6-localnet
ip6-loopback
ip6-mcastprefix
local
localhost
localhost.localdomain

```
Optional:
* \-sort
	* Sorts the Domains (ascending; source-wise)
* \-tab
	* Uses tab instead of spaces between Target IP and Domain Name
* \-logs
	* Generate generation logs; auto-generates a logs.txt inside the **Data** folder
* \-dpl<n>
	* Indicates that it will generate <2~9> number of domains per line (e.g. -dpl4) to reduce the file size
* \-zip
	* Generates a zipped hosts file inside the **Data** folder
	
###### Check [HostY_host](https://github.com/Laicure/HostsY_hosts) for the generated files

