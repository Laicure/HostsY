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

Added [my custom list](https://github.com/Laicure/HostsY/blob/master/custHost) here (pop-ups, ads, malware sites that I stumble upon using the list [below](https://github.com/Laicure/HostsY#weekly-updated-custom-host-file-with-whitelist--88k-entries)); for concerns, please don't hesitate to create a [new issue](https://github.com/Laicure/HostsY/issues) :D

~~------------------------------~~

##### [Weekly Updated](https://forum.xda-developers.com/showpost.php?p=68978460&postcount=2) custom host file with whitelist  (88k+ entries):
```
https://bitbucket.org/Laicure/publicview/downloads/hosts
```
##### You can use [StevenBlack/hosts' data](https://github.com/StevenBlack/hosts/tree/master/data) sources with no whitelist:
```
https://raw.githubusercontent.com/mitchellkrogza/Badd-Boyz-Hosts/master/hosts
https://raw.githubusercontent.com/azet12/KADhosts/master/KADhosts.txt
https://raw.githubusercontent.com/FadeMind/hosts.extras/master/SpotifyAds/hosts
https://raw.githubusercontent.com/StevenBlack/hosts/master/data/StevenBlack/hosts
https://raw.githubusercontent.com/FadeMind/hosts.extras/master/UncheckyAds/hosts
https://raw.githubusercontent.com/AdAway/adaway.github.io/master/hosts.txt
https://raw.githubusercontent.com/FadeMind/hosts.extras/master/add.2o7Net/hosts
https://raw.githubusercontent.com/FadeMind/hosts.extras/master/add.Dead/hosts
https://raw.githubusercontent.com/FadeMind/hosts.extras/master/add.Risk/hosts
https://raw.githubusercontent.com/FadeMind/hosts.extras/master/add.Spam/hosts
http://www.malwaredomainlist.com/hostslist/hosts.txt
http://winhelp2002.mvps.org/hosts.txt
http://someonewhocares.org/hosts/zero/hosts
https://raw.githubusercontent.com/tyzbit/hosts/master/data/tyzbit/hosts
https://pgl.yoyo.org/adservers/serverlist.php?hostformat=hosts&mimetype=plaintext&useip=0.0.0.0
https://raw.githubusercontent.com/Laicure/HostsY/master/custHost
```
##### (Weekly Updated) Generated hosts file from StevenBlack/hosts' sources with no whitelist (36k+ entries):
```
https://bitbucket.org/Laicure/publicview/downloads/hosts2
```

###### hpHosts' _Individual Classifications_:
```
http://hosts-file.net/ad_servers.txt
http://hosts-file.net/emd.txt
http://hosts-file.net/exp.txt
http://hosts-file.net/fsa.txt
http://hosts-file.net/grm.txt
http://hosts-file.net/hfs.txt
http://hosts-file.net/hjk.txt
http://hosts-file.net/mmt.txt
http://hosts-file.net/pha.txt
http://hosts-file.net/psh.txt
http://hosts-file.net/pup.txt
http://hosts-file.net/wrz.txt
```
##### (Weekly Updated) Generated hosts file from [hpHosts' _Individual Classifications_](https://hosts-file.net/?s=Download) sources with no whitelist (664k+ entries):
```
https://bitbucket.org/Laicure/publicview/downloads/hosts3
```
###### Other sources can be found from AdAway's [wiki](https://github.com/AdAway/AdAway/wiki/HostsSources)
