# Spis treści 

### [Screenshot](egzamin_praktyczny_cg_png.md)

 1. [Create Users/Groups and Configure Superuser Access on Both Servers](#1-create-usersgroups-and-configure-superuser-access-on-both-servers)
 2. [Configure yum Repositories on Both Servers and Install Packages/Modules](#2-configure-yum-repositories-on-both-servers-and-install-packagesmodules) 
 3. [Configure IP Addresses on the Second Network Interface on the First Server](#3-configure-ip-addresses-on-the-second-network-interface-on-the-first-server)
 4. [Managing Tuned Profiles and Individual Processes](#managing-tuned-profiles-and-individual-processes)
6. [manage-scheduled-tasks-on-the-first-server ](#6-manage-scheduled-tasks-on-the-first-server)
7. [configure-time-service-clients-for-both-servers](#7-configure-time-service-clients-for-both-servers)
8. [managing-the-system-bootloader](#8-managing-the-system-bootloader)
9. [configure-persistent-storage-with-lvm-on-top-of-vdo](#9-configure-persistent-storage-with-lvm-on-top-of-vdo)
10. [add-swap-space-persistently-and-nondisruptive](#10-add-swap-space-persistently-and-nondisruptive)
11. [configure-stratis-storage-persistently](#11-configure-stratis-storage-persistently)
12. [configure-autofs-for-home-directories](#12-configure-autofs-for-home-directories)
13. [configure-a-shared-directory-for-collaboration](#13-configure-a-shared-directory-for-collaboration)
14. [create-a-persistent-systemd-container-using-podman](#14-create-a-persistent-systemd-container-using-podman)
15. [troubleshoot-selinux-issues](#15-troubleshoot-selinux-issues)
16. [configure-the-firewall-on-both-servers](#16-configure-the-firewall-on-both-servers)

[Koniec](#koniec)



# Managing RHEL 8 Servers

## 1. Create Users/Groups and Configure Superuser Access on Both Servers
[Spis treści](#spis-treści)

We're going to lay the groundwork here and use these local accounts for all the subsequent tasks. You can write a script to do this, or do it by hand, from the data in the input file for the script. The file contents are:  
  
```console
manny:1010:dba_admin,dba_managers,dba_staff
moe:1011:dba_admin,dba_staff
jack:1012:dba_intern,dba_staff
marcia:1013:it_staff,it_managers
jan:1014:dba_admin,dba_staff
cindy:1015:dba_intern,dba_staff
```
  
Set all user passwords to ```dbapass```. Also, change the users' PRIMARY groups' GID to match their UID. Don't forget to check their home directories to make sure permisisons are correct!  
    
  
Configure superuser access:  

Enable the following command aliases:  

- SOFTWARE
- SERVICES
- PROCESSES
Add a new command alias named "MESSAGES":

/bin/tail -f /var/log/messages  

Enable superuser privilages for the following local groups:    
- dba_managers: everything  
- dba_admin: Command aliases: SOFTWARE, SERVICES, PROCESSES  
- dba_intern: Command alias: MESSAGES   
  
  
## 2. Configure yum Repositories on Both Servers and Install Packages/Modules  
[Spis treści](#spis-treści)

You'll need to configure three repositories and install some software:    
  
**RHEL 8 BaseOS:**
  
```console
Repository ID: [rhel-8-baseos-rhui-rpms]
The mirrorlist is: https://rhui3.REGION.aws.ce.redhat.com/pulp/mirror/content/dist/rhel8/rhui/$releasever/$basearch/baseos/os
The GPG key is located at: /etc/pki/rpm-gpg/RPM-GPG-KEY-redhat-release
You will need to add SSL configuration:
sslverify=1
sslclientkey=/etc/pki/rhui/content-rhel8.key
sslclientcert=/etc/pki/rhui/product/content-rhel8.crt
sslcacert=/etc/pki/rhui/cdn.redhat.com-chain.crt
```

**RHEL 8 AppStream:**

```console
Repository ID: [rhel-8-appstream-rhui-rpms]
The mirrorlist is: https://rhui3.REGION.aws.ce.redhat.com/pulp/mirror/content/dist/rhel8/rhui/$releasever/$basearch/appstream/os
The GPG key is located at: /etc/pki/rpm-gpg/RPM-GPG-KEY-redhat-release
You will need to add SSL configuration:
sslverify=1
sslclientkey=/etc/pki/rhui/content-rhel8.key
sslclientcert=/etc/pki/rhui/product/content-rhel8.crt
sslcacert=/etc/pki/rhui/cdn.redhat.com-chain.crt
```

**EPEL:**
- Repository ID: [epel]
- The baseurl is: https://download.fedoraproject.org/pub/epel/$releasever/Everything/$basearch  

Configure the repositories on the first server, then make an archive of the files, securely copy them to the second server, then unarchive the repository files on the second server.


**Install software on both servers:**

- Install the default AppStream stream/profile for ```container-tools```
- Install the ```youtube-dl``` package (from EPEL)
- Check for system updates, but don't install them


## 3. Configure IP Addresses on the Second Network Interface on the First Server
[Spis treści](#spis-treści)  

On the first server, configure the second interface's IPv4/IPv6 addresses using ```nmtui```.

**IP Addresses:**

```console
IPv4: 10.0.1.20/24
IPv6: 2002:0a00:0114::/64
Manual, not Automatic (DHCP) for both interfaces
Only IP addresses, no other fields
Configure only, do not activate
```

## 4. Configure Persistent Journals on Both Servers  
[Spis treści](#spis-treści)  

By default, the ```systemd``` journal logs to memory in RHEL 8, in the location ```/run/log/journal```. While this works fine, we'd like to make our journals persistent across reboots.  
Configure the ```systemd``` journal logs to be persistent on both servers, logging to ```/var/log/journal```.  


## Managing Tuned Profiles and Individual Processes
[Spis treści](#spis-treści)  

**On the first server:**

- Set a merged ```tuned``` profile using the the ```powersave``` and ```virtual-guest``` profiles.
- Start one ```stress``` process and adjust the ```niceness``` value to 19.
- Adjust the ```niceness``` value of the ```stress``` process to 10.
- Kill the ```stress``` process.


## 6. Manage Scheduled Tasks on the First Server
[Spis treści](#spis-treści)   

Create one ```at``` task and one ```cron``` job on the first server:

- The ```at``` job will create a file containing the string "The at job ran" in the file named ```/web/html/at.html```, two minutes from the time you schedule it.
- The ```cron``` job will append to the ```/web/html/cron.html``` file every minute, echoing the ```date``` to the file.  
  
These files will be available via the web server on the first server after the "Troubleshoot SELinux issues" objective is completed.


## 7. Configure Time Service Clients for Both Servers
[Spis treści](#spis-treści)  

Time sync is not working on either of our servers. We need to fix that.
Configure ```chrony``` to use the following server:
  
```console
server 169.254.169.123 iburst
```
  
Make sure your work is persistent and check your work!


## 8. Managing the System Bootloader
[Spis treści](#spis-treści)  

**On server1, make the following changes:**
  
- Increase the timeout using ```GRUB_TIMEOUT=10```
- Add the following line: ```GRUB_TIMEOUT_STYLE=hidden```
- Add ```quiet``` to the end of the ```GRUB_CMDLINE_LINUX ```line
  
Validate the changes in ```/boot/grub2/grub.cfg```. Do not reboot the server.


# Managing Storage on RHEL 8

## 9. Configure Persistent Storage with LVM on Top of VDO
[Spis treści](#spis-treści)

**On the second server:**

Create a VDO device with the first unused 5GB device.  
  
- Name: web_storage
- Logical Size: 10GB
  
Use the VDO device as an LVM physical volume. Create the following:  

- Volume Group: web_vg
    - Three 2G Logical Volumes with xfs file systems:
        - web_storage_dev
        - web_storage_qa
        - web_storage_prod
  
Mount these persistently at /mnt/web_storage_{dev,qa,prod}.  


## 10. Add Swap Space Persistently and Nondisruptive
[Spis treści](#spis-treści) 

We need to increase the swap on the second server. We're going to use half of our first unused 2G disk for this additional swap space.  
Configure the swap space ```non-destructively``` and ```persistently```.  


## 11. Configure Stratis Storage Persistently
[Spis treści](#spis-treści) 

**On the second server, using the second 2G disk, create the following:**

- Stratis pool: appteam
- Stratis file system: appfs1
    - Mount this persistently at ```/mnt/app_storage```

## 12. Configure autofs for Home Directories
[Spis treści](#spis-treści) 

Configure ```autofs``` on the first server to mount the user home directories on the second server at ```/export/home```.

- On the second server, configure a NFS server with the following export:
```console
/home	<first_server_private_IP>(rw,sync,no_root_squash)
```

- On the first server, configure ```autofs``` to mount the exported ```/home``` directory on the second server at ```/export/home```. Change the home directories for our six users (manny|moe|jack|marcia|jan|cindy) to be ```/export/home/<user>``` and test.


## 13. Configure a Shared Directory for Collaboration
[Spis treści](#spis-treści) 

**On the second server:**

Create a directory at ```/home/dba_docs``` with:
- Group ownership: dba_staff
- Permissions: 770
- Set-GID set
- Sticky bit set

Create a link in each shared user's home directory to this directory, for easy access.

Set the following ACLs:
- Read-only for ```jack``` and ```cindy```
- Full permissions for ```marcia```


# Managing Containers Using Podman

## 14. Create a Persistent systemd Container Using Podman
[Spis treści](#spis-treści) 

**As the ```cloud_user``` user on the first server, create a persistent ```systemd``` container with the following:**

- Image: registry.access.redhat.com/rhscl/httpd-24-rhel7
- Port mappings: 8080 on the container to 8000 on the host
- Persistent storage at ```~/web_data```, mounted at ```/var/www/html``` in the container
- Container name: web_server


# Managing Security on RHEL 8

## 15. Troubleshoot SELinux Issues
[Spis treści](#spis-treści) 

The Apache web server on the first server won't start! Investigate this issue, and correct any other SELinux issues related to ```httpd``` that you may find.

## 16. Configure the Firewall on Both Servers
[Spis treści](#spis-treści) 

Make sure the firewall is installed, enabled and started on both servers. Configure the following services/ports:

**Server 1:**
- ssh
- http
- Port 85 (tcp)
- Port 8000 (tcp)

**Server 2:**
- ssh
- nfs
- nfs3
- rpc-bind
- mountd


##### Koniec