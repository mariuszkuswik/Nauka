Configure your Host Name, IP Address, Gateway and DNS. 
Host name: station.domain40.example.com 
/etc/sysconfig/network 
hostname=abc.com hostname abc.com IP Address:172.24.40.40/24 - Gateway172.24.40.1 - DNS:172.24.40.1 -

Create a catalog under /home named admins. Its respective group is requested to be the admin group. The group users could read and write, while other users are not allowed to access it. The files created by users from the same group should also be the admin group.

Configure a task: plan to run echo hello command at 14:23 every day.


Find the files owned by harry, and copy it to catalog: /opt/dir


Find the rows that contain abcde from file /etc/testfile, and write it to the file/tmp/testfile, and the sequence is requested as the same as /etc/testfile.


Install a FTP server, and request to anonymous download from /var/ftp/pub catalog. (it needs you to configure yum direct to the already existing file server.)


Configure a HTTP server, which can be accessed through http://station.domain40.example.com. Please download the released page from http://ip/dir/example.html.


Configure autofs to make sure after login successfully, it has the home directory autofs, which is shared as /rhome/ldapuser40 at the ip: 172.24.40.10. and it also requires that, other ldap users can use the home directory normally.


- Configure the system synchronous as 172.24.40.10.
```bash
# FOR RHEL8:
sudo yum -y install chrony
sudo vi /etc/chrony.conf
server 192.168.25.3
sudo timedatectl set-ntp true
sudo systemctl enable --now chronyd
```


- Create a volume group, and set 16M as a extends. And divided a volume group containing 50 extends on volume group lv, make it as ext4 file system, and mounted automatically under /mnt/data.
```bash
# assume that /dev/sdb2 and /dev/sdb3 were created (lsblk to verify it)

pvcreate /dev/sdb{2,3}
pvdisplay /dev/sdb* (verify)

vgcreate VG01 --physicalextentsize 16M /dev/sdb{2,3}
vgdisplay /dev/VG01 (verify)

lvcreate --extents 50 --name LV01 VG01
lvdisplay /dev/VG01 (verify)

blkid /dev/VG01/LV01 (get UUID=XXX-XX-XX)
mkdir -p /mnt/data
echo "UUID=XXX-XX-XX /mnt/data ext4 defaults 0 0" | tee -a /etc/fstab
mount -a
```


- Upgrading the kernel as 2.6.36.7.1, and configure the system to Start the default kernel, keep the old kernel available.
```bash
# To update Kernel:
rpm -ivh [kernel.rmp] --> Install a rpm package in verbose mode
# OR
yum install kernel --> (If you're using repositories)

# It's important to know that this doesn't replace the actual kernel. It is installed along the actual kernel and you can select any available kernel to boot the system in case of troubleshooting.
# Also, the system onlny saves a maximum of 4 kernels. If you already have 4, and install a 5th kernel, this one will replace the oldest kernel.
# -----------
# To set a default kernel:
# - We can use grubby command tool.
grubby --default-kernel --> Get default kernel (It's probably that the latest installed be selected)
grubby --info=ALL | grep ^kernel --> This command list all kernel paths for the available kernels.
grubby --set-default=[kernel path obtained from the above command]

# Reboot and verify
uname -r --> Get the loaded kernel
```


- Create a 512M partition, make it as ext4 file system, mounted automatically under /mnt/data and which take effect automatically at boot-start.
```bash
#fdisk -l (to check for empty disk)
#fdisk /dev/sdd (format disk in question)
#n (new partition)
#p (for primary)
#Enter (use the first sector by default)
#+size 512M (to specify the size)
#Enter
#w (to write the changes)
#fdisk -l /dev/sdd1 (to verify partition has been created)
#mkfs.ext4 /dev/sdd1 (to format the partition with ext4 file system)
#mkdir /mnt/data (to create the mount point)
#mount /dev/sdd1 (mount the partition)
#vi /etc/fstab (to configure auto mount after each boot)
Press Shift G to go to the last line and press O to start in new line in Insert mode. Enter the following (ensure you press TAB for each part of the entry):
/dev/sdd1 /mnt/data /ext4 defaults 0 0
Exit out of the Insert mode and type: :wq!
```


- Create a volume group, and set 8M as a extends. Divided a volume group containing 50 extends on volume group lv (lvshare), make it as ext4 file system, and mounted automatically under /mnt/data. And the size of the floating range should set between 380M and 400M.

```bash
-- lets say we are going to work on /dev/vda3 ,
make sure this disk has no mount point,if any than unmount them
ex. umount /mnt/data

partprobe
vgcreate -s 8M vg1 /dev/vda3
lvcreate -n lvshare -l 50 vg1
mkfs.ext4 /dev/vg1/lvshare
mkdir -p /mnt/data
vim /etc/fstab
/dev/vg1/lvshare /mnt/data ext4 defaults 0 0
mount -a
partprobe
df -h

```


- Add admin group and set gid=600 -
```bash
groupadd -g 600 admin
```

- Add users: user2, user3. The Additional group of the two users: user2, user3 is the admin group Password: redhat
```bash
useradd -G admin user2
useradd -G admin user3
echo “redhat” | passwd --stdin user2
echo “redhat” | passwd --stdin user3
```


- Copy /etc/fstab to /var/tmp name admin, the user1 could read, write and modify it, while user2 without any permission.
```bash
useradd -M user1
useradd -M user2
cp /etc/fstab /vat/tmp/
setfacl -m u:user1:rw- /var/tmp/fstab
setfacl -m u:user2:--- /vat/tmp/fstab
````


- Configure a task: plan to run echo "file" command at 14:23 every day.
```bash
cat <<EOF> /etc/cron.d/echo_file
23 14 * * * /usr/bin/echo 'file'
EOF
```

- Configure a default software repository for your system. One YUM has already provided to configure your system on http://server.domain11.example.com/pub/ x86_64/Server, and can be used normally.
```bash
dnf config-manager --add-repo=http://server.domain11.example.com/pub/ x86_64/Server/BaseOs

vi local-rhel8.repo
# add gpgcheck=0 in the config file

[LocalRepo_BaseOS]
name=LocalRepo_BaseOS
metadata_expire=-1
enabled=1
gpgcheck=0
baseurl=http://server.domain11.example.com/pub/ x86_64/Server/BaseOS/

```

- Adjust the size of the Logical Volume. Adjust the size of the vo Logical Volume, its file system size should be 290M. Make sure that the content of this system is complete. Note: the partition size is rarely accurate to the same size as required, so in the range 270M to 320M is acceptable.
```bash
# rhel8
umount /dev/mapper/my_vol2-lvshare /mnt/data
lvreduce -r -L 290M /dev/my_vol2/lvshare
lsblk
mount -a
```

- Configure /var/tmp/fstab Permission. Copy the file /etc/fstab to /var/tmp/fstab. Configure var/tmp/fstab permissions as the following: Owner of the file /var/tmp/fstab is Root, belongs to group root File /var/tmp/fstab cannot be executed by any user User natasha can read and write /var/tmp/fstab User harry cannot read and write /var/tmp/fstab All other users (present and future) can read var/tmp/fstab.
```bash
cp /etc/fstab /var/tmp/
/var/tmp/fstab view the owner setfacl -m u:natasha:rw- /var/tmp/fstab setfacl -m u:haryy:--- /var/tmp/fstab
Use getfacl /var/tmp/fstab to view permissions
```


- Please open the ip_forward, and take effect permanently.
```bash

```


- Open kmcrl value of 5 , and can verify in /proc/ cmdline
```bash
# this is not found in rhcsa 2021

grubby --update-kernel=ALL --args="kmcrl=5"
cat /boot/grub2/grubenv
systemctl reboot
cat /proc/cmdline

```


- Configure iptables, there are two domains in the network, the address of local domain is 172.24.0.0/16 other domain is 172.25.0.0/16, now refuse domain 172.25.0.0/16 to access the server.
```bash
Use fdisk /dev/hda ->To create new partition.

Type n-> For New partition -
It will ask for Logical or Primary Partitions. Press l for logical.
It will ask for the Starting Cylinder: Use the Default by pressing Enter Key.
Type the Size: +100M ->You can Specify either Last cylinder of Size here.
Press P to verify the partitions lists and remember the partitions name. Default System ID is 83 that means Linux Native.
Type t to change the System ID of partition.

Type Partition Number -
Type 82 that means Linux Swap.
Press w to write on partitions table.
Either Reboot or use partprobe command.
mkswap /dev/hda? ->To create Swap File system on partition.
swapon /dev/hda? ->To enable the Swap space from partition.
free -m ->Verify Either Swap is enabled or not.
vi /etc/fstab/dev/hda? swap swap defaults 0 0
Reboot the System and verify that swap is automatically enabled or not.


In RHEL8 for fstab configuration is not more recommended to use absolute patch to the device like /dev/sda7.
The recommendation is to use the UUID identifier instead.
To get the swap or any other filesystem's UUID use the command blkid.
This will show you all filesystems UUIDs in example:
/dev/sda7: UUID="361ed5b5-872a-4e49-ba70-91efb28b2bb4" TYPE="swap" PARTUUID="caa5e8f6-01"

Copy the section UUID="361ed5b5-872a-4e49-ba70-91efb28b2bb4" and use it in fstab as follows.
UUID="361ed5b5-872a-4e49-ba70-91efb28b2bb4" swap swap defaults 0 0
```


There are two different networks, 192.168.0.0/24 and 192.168.1.0/24. Your System is in 192.168.0.0/24 Network. One RHEL6 Installed System is going to use as a Router. All required configuration is already done on Linux Server. Where 192.168.0.254 and 192.168.1.254 IP Address are assigned on that Server. How will make successfully ping to 192.168.1.0/24 Network's Host?



Make a swap partition having 100MB. Make Automatically Usable at System Boot Time.



One Logical Volume is created named as myvol under vo volume group and is mounted. The Initial Size of that Logical Volume is 400MB. Make successfully that the size of Logical Volume 200MB without losing any data. The size of logical volume 200MB to 210MB will be acceptable.



We are working on /data initially the size is 2GB. The /dev/test0/lvtestvolume is mount on /data. Now you required more space on /data but you already added all disks belong to physical volume. You saw that you have unallocated space around 5 GB on your harddisk. Increase the size of lvtestvolume by 5GB.


- Make on data that only the user owner and group owner member can fully access.
```bash
chmod 770 /data
Verify using : ls -ld /data Preview should be like:
drwxrwx--- 2 root sysadmin 4096 Mar 16 18:08 /data
To change the permission on directory we use the chmod command.
According to the question that only the owner user (root) and group member (sysadmin) can fully access the directory so: chmod 770 /data
```


- Who ever creates the files/directories on a data group owner should automatically be in the same group owner as data.
```bash
1. chmod g+s /data
2. Verify using: ls -ld /data
Permission should be like this: drwxrws--- 2 root sysadmin 4096 Mar 16 18:08 /data
If SGID bit is set on directory then who every users creates the files on directory group owner automatically the owner of parent directory. To set the SGID bit: chmod g+s directory To Remove the SGID bit: chmod g-s directory
```


- Your System is going to use as a Router for two networks. One Network is 192.168.0.0/24 and Another Network is 192.168.1.0/24. Both network's IP address has assigned. How will you forward the packets from one network to another network?
```bash


```


- /data Directory is shared from the server1.example.com server. Mount the shared directory that:
```bash
# In RHEL8 and because de request is not with autofs, we can proceed in this way:
mount server1.example.com server:/data /mnt

1. vi /etc/auto.master
/mnt /etc /auto.misc --timeout=50
vi /etc/auto.misc
data -rw,soft,intr server1.example.com:/data
service autofs restart
chkconfig autofs on
When you mount the other filesystem, you should unmount the mounted filesystem, Automount feature of linux helps to mount at access time and after certain seconds, when user unaccess the mounted directory, automatically unmount the filesystem.
/etc/auto.master is the master configuration file for autofs service. When you start the service, it reads the mount point as defined in /etc/auto.master.

```


- You are new System Administrator and from now you are going to handle the system and your main task is Network monitoring, Backup and Restore. But you don't know the root password. Change the root password to redhat and login in default Runlevel.
```bash
# In RHEL8
- reboot the system
- press "e" letter
- Add "rd.break" at the end of de line thet begening with "Linux" in grub menu
- ctrl + x
- # mount -o remount,rw /sysroot
- # chroot /sysroot
- # passwd
- #  touch /.autorelabel
- # exit
- # logout
```



- You are a System administrator. Using Log files very easy to monitor the system. Now there are 50 servers running as Mail, Web, Proxy, DNS services etc. You want to centralize the logs from all servers into on LOG Server. How will you configure the LOG Server to accept logs from remote host?
```bash
By default, system accept the logs only generated from local host. To accept the Log from other host configure: vi /etc/sysconfig/syslog SYSLOGD_OPTIONS="-m 0 -r"

Where -
-m 0 disables 'MARK' messages.
-r enables logging from remote machines
-x disables DNS lookups on messages received with -r
service syslog restart
```



- Create a Shared Directory. Create a shared directory /home/admins, make it has the following characteristics: /home/admins belongs to group adminuser This directory can be read and written by members of group adminuser Any files created in /home/ admin, group automatically set as adminuser.
```bash
mkdir -p /home/admins
groupadd adminuser
chown :adminuser /home/admins
setfacl -m g:adminuser:rwx /home/admins
chmod g+s /home/admins/
```


- Configure NTP. Configure NTP service, Synchronize the server time, NTP server: classroom.example.com
```bash
yum -y install chrony
systemctl enable --now chronyd
vim etc/chrony.conf
# (change on server classroom.example.com iburs)
systemctl reload chronyd
timedatectl set-ntp true
```



- Configure a user account. Create a user iar uid is 3400. Password is redhat ï¼Œ
```bash
useradd -u 3400 iar
id iar
passwd iar
```


- Search files. Find out files owned by jack, and copy them to directory /root/findresults
```bash
mkdir -p /root/findresults
find / -user jack -type f -exec cp -avrf {} /root/findresults/ \;
ls -l /root/findresults
```


- Search a String - Find out all the columns that contains the string seismic within /usr/share/dict/words, then copy all these columns to /root/lines.tx in original order, there is no blank line, all columns must be the accurate copy of the original columns.
```bash
grep seismic /usr/share/dict/words > /root/lines.txt
```


- Create a backup - Create a backup file named /root/backup.tar.bz2, contains the content of /usr/local, tar must use bzip2 to compress.
```bash
# Simple to understand and execute,

[root@station ~]# yum install bzip2
[root@station ~]# tar -cvf /root/backup.tar /usr/local/
[root@station ~]# du -sh /root/backup.tar
20K /root/backup.tar
[root@station ~]# bzip2 /root/backup.tar
[root@station ~]# du -sh /root/backup.tar.bz2
4.0K /root/backup.tar.bz2
[root@station ~]#
```


- Create a logical volume - Create a new logical volume as required: Name the logical volume as database, belongs to datastore of the volume group, size is 50 PE. Expansion size of each volume in volume group datastore is 16MB. Use ext3 to format this new logical volume, this logical volume should automatically mount to /mnt/database
```bash
# vgcreate -s 16M datastore /dev/sdxx
# lvcreate -l 50 -n database datastore
# lvs
# mkdir /mnt/database
# mkfs.ext3 /dev/datastore/database
# echo "/dev/datastore/database /mnt/database/ ext3 defaults 0 0" >> /etc/fstab
# mount -a
# df -h



fdisk -cu /dev/vda// Create a 1G partition, modified when needed partx ""a /dev/vda pvcreate /dev/vdax vgcreate datastore /dev/vdax ""s 16M lvcreate"" l 50 ""n database datastore mkfs.ext3 /dev/datastore/database mkdir /mnt/database mount /dev/datastore/database /mnt/database/ df ""Th vi /etc/fstab
/dev/datastore /database /mnt/database/ ext3 defaults 0 0 mount ""a
Restart and check all the questions requirements.
```

- Your System is configured in 192.168.0.0/24 Network and your nameserver is 192.168.0.254. Make successfully resolve to server1.example.com.
```bash
nameserver is specified in question,
1. Vi /etc/resolv.conf
nameserver 192.168.0.254
2. host server1.example.com
```

- Some users home directory is shared from your system. Using showmount -e localhost command, the shared directory is not shown. Make access the shared users home directory.
```bash
NFS Server:
- dnf install nfs-utils libnfsidmap
- systemctl enable rpcbind & nfs-server
- systemctl start rpcbind, nfs-server, rpc-statd, nfs-idmapd
- vi /etc/exports
- add /home/user 192.168.x.x (rw,sync,no_root_squash)
- exportfs -rv
- showmount -e
- Optional: may need to enable the rule on firewalld or stop it altogether for it to work on remote clients

NFS Client:
- dnf install nfs-utils rpcbind
- systemctl start rpcbind
- ps -ef | egrep “firewalld:iptables” (may need to stop these two services, or add appropriate rules for mounting to work across server and client)
- Create a mount point
- Mount 192.168.x.x:/dir /mountpoint
```





Verify the File whether Shared or not ? : cat /etc/exports Start the nfs service: service nfs start Start the portmap service: service portmap start Make automatically start the nfs service on next reboot: chkconfig nfs on Make automatically start the portmap service on next reboot: chkconfig portmap on Verify either sharing or not: showmount -e localhost Check that default firewall is running on system? If running flush the iptables using iptables -F and stop the iptables service.



Successfully resolve to server1.example.com where your DNS server is 172.24.254.254.



Who ever creates the files/directories on archive group owner should be automatically should be the same group owner of archive.



Make on /archive directory that only the user owner and group owner member can fully access.



SELinux must run in force mode.



In the system, mounted the iso image /root/examine.iso to/mnt/iso directory. And enable automatically mount (permanent mount) after restart system.



1. Find all sizes of 10k file or directory under the /etc directory, and copy to /tmp/findfiles directory. 2. Find all the files or directories with Lucy as the owner, and copy to /tmp/findfiles directory.



There is a local logical volumes in your system, named with common and belong to VGSRV volume group, mount to the /common directory. The definition of size is 128 MB. Requirement: Extend the logical volume to 190 MB without any loss of data. The size is allowed between 160-160 MB after extending.




Create a swap space, set the size is 600 MB, and make it be mounted automatically after rebooting the system (permanent mount).


According the following requirements to create a local directory /common/admin. This directory has admin group. This directory has read, write and execute permissions for all admin group members. Other groups and users don't have any permissions. All the documents or directories created in the/common/admin are automatically inherit the admin group.



User mary must configure a task. Requirement: The local time at 14:23 every day echo "Hello World.".



- Copy /etc/fstab document to /var/TMP directory. According the following requirements to configure the permission of this document. ? The owner of this document must be root. ? This document belongs to root group. ? User mary have read and write permissions for this document. ? User alice have read and execute permissions for this document. ? Create user named bob, set uid is 1000. Bob have read and write permissions for this document. ? All users has read permission for this document in the system.




Configure your web services, download from http://instructor.example.com/pub/serverX.html And the services must be still running after system rebooting.




Download the document from ftp://instructor.example.com/pub/testfile, find all lines containing [abcde] and redirect to /MNT/answer document, then rearrange the order according the original content.




SELinux must be running in the Enforcing mode.



Create the following users, groups, and group memberships: A group named adminuser. A user natasha who belongs to adminuser as a secondary group A user harry who also belongs to adminuser as a secondary group. A user sarah who does not have access to an interactive shell on the system, and who is not a member of adminuser, natasha, harry, and sarah should all have the password of redhat.



Set cronjob for user natasha to do /bin/echo hiya at 14:23.


Install the appropriate kernel update from http://server.domain11.example.com/pub/updates. The following criteria must also be met: The updated kernel is the default kernel when the system is rebooted The original kernel remains available and bootable on the system



Locate all the files owned by ira and copy them to the / root/findresults directory.


Find all lines in the file /usr/share/dict/words that contain the string seismic. Put a copy of all these lines in their original order in the file /root/wordlist. /root/wordlist should contain no empty lines and all lines must be exact copies of the original lines in /usr/share/dict/words.


Create a backup file named /root/backup.tar.bz2, which contains the contents of /usr/local, bar must use the bzip2 compression.


Configure your Host Name, IP Address, Gateway and DNS. Host name: station.domain40.example.com /etc/sysconfig/network hostname=abc.com hostname abc.com IP Address:172.24.40.40/24 - Gateway172.24.40.1 - DNS:172.24.40.1 -


Add 3 users: harry, natasha, tom. The requirements: The Additional group of the two users: harry, Natasha is the admin group. The user: tom's login shell should be non-interactive.


Create a catalog under /home named admins. Its respective group is requested to be the admin group. The group users could read and write, while other users are not allowed to access it. The files created by users from the same group should also be the admin group.


Find the files owned by harry, and copy it to catalog: /opt/dir


Create a user named alex, and the user id should be 1234, and the password should be alex111.


echo alex111|passwd -stdin alex


Configure a HTTP server, which can be accessed through http://station.domain40.example.com. Please download the released page from http://ip/dir/example.html.


Part 2 (on Node2 Server) Task 2 [Installing and Updating Software Packages] Configure your system to use this location as a default repository: http://utility.domain15.example.com/BaseOS http://utility.domain15.example.com/AppStream Also configure your GPG key to use this location http://utility.domain15.example.com/RPM-GPG-KEY-redhat-release


Part 1 (on Node1 Server) Task 10 [Configuring NTP/Time Synchronization] Configure your system so that it is an NTP client of utility.domain15.example.com The system time should be set to your (or nearest to you) timezone and ensure NTP sync is configured



SELinux must be running in the Enforcing mode.


The system ldap.example.com provides an LDAP authentication service. Your system should bind to this service as follows: The base DN for the authentication service is dc=domain11, dc=example, dc=com LDAP is used to provide both account information and authentication information. The connection should be encrypted using the certificate at http://host.domain11.example.com/pub/domain11.crt When properly configured, ldapuserX should be able to log into your system, but will not have a home directory until you have completed the autofs requirement. Username: ldapuser11 Password: password



Create the user named eric and deny to interactive login.


Find all lines in the file /usr/share/dict/words that contain the string seismic. Put a copy of all these lines in their original order in the file /root/wordlist. /root/wordlist should contain no empty lines and all lines must be exact copies of the original lines in /usr/share/dict/words.


Part 1 (on Node1 Server) Task 14 [Managing SELinux Security] You will configure a web server running on your system serving content using a non-standard port (82)


Create a 512M partition, make it as ext4 file system, mounted automatically under /mnt/data and which take effect automatically at boot-start.


Locate all the files owned by ira and copy them to the / root/findresults directory.



Part 2 (on Node2 Server) Task 1 [Controlling the Boot Process] Interrupt the boot process and reset the root password. Change it to kexdrams to gain access to the system



