# HostsY
Just a simplified and multi-threaded revamp of [HostsX](http://github.com/Laicure/HostsX) for Windows.

###### Minimum Requirement: [.NET v4.6.2](https://www.microsoft.com/en-us/download/details.aspx?id=53344)

#### Auto Parameters (requires admin privileges):
Required:
* \-auto
	* Initializes Auto Generate State
	* Directly replaces the hosts file in **C:\\Windows\\System32\\drivers\\etc**
	* Requires Data folder beside the app
		* Must have the **source.txt** that contains the _host sources_
		* Optional: **black.txt** for domain _blacklist_
		* Optional: **white.txt** for domain _whitelist_
		* Optional: **loopback.txt** for domain _loopbacks_
```
HostsY.exe
Data
\black.txt
\source.txt
\white.txt
\loopback.txt
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
	* Generate generation logs; auto-generates a logs.txt file
* \-dpl<n>
	* indicates that it will generate <2 to 9> number of domains per line (e.g. -dpl4) to reduce the file size
* \-zip
	* Generates a zipped hosts file inside the Data folder
	
### _DNS Client_ service (on Windows) must be [disabled](http://support.simpledns.com/kb/a61/disabling-the-windows-dns-client-service.aspx) if using one of the hosts file below!


##### Frequent/Weekly Updated Generated [custom](https://github.com/Laicure/HostsY/blob/master/sources.md#custom-hosts-files-sources-and-whitelist) host file _with whitelist_; mostly for my personal usage:
```
https://bitbucket.org/Laicure/publicview/downloads/hosts
```
##### Frequent/Weekly Updated Generated hosts file from [StevenBlack/hosts' main sources](https://github.com/StevenBlack/hosts/tree/master/data) _with no whitelist_:
```
https://bitbucket.org/Laicure/publicview/downloads/hosts2
```
##### Frequent/Weekly Updated Generated hosts file from [hpHosts](https://hosts-file.net/?s=Download) (Individual Classifications merged) _with no whitelist_:
```
https://bitbucket.org/Laicure/publicview/downloads/hosts3
```
###### Other sources can be found from AdAway's [wiki](https://github.com/AdAway/AdAway/wiki/HostsSources)

